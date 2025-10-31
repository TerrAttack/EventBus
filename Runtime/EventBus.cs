using System.Collections.Generic;

namespace Utils.EventBus
{
    public class EventBus<T> where T : IEvent
    {
        private static readonly HashSet<IEventBinding<T>> Bindings = new();
        private static readonly HashSet<IEventBinding<T>> TempBindings = new();
        private static readonly HashSet<IEventBinding<T>> ToRemove = new();

        public static void Register(IEventBinding<T> binding)
        {
            TempBindings.Add(binding);
        }

        public static void Deregister(IEventBinding<T> binding)
        {
            ToRemove.Add(binding);
        }

        public static void Raise(T @event)
        {
            foreach (var tempBinding in TempBindings)
                Bindings.Add(tempBinding);
            TempBindings.Clear();

            foreach (var binding in ToRemove) Bindings.Remove(binding);
            ToRemove.Clear();

            if (@event is IAutoExecutableEvent autoExecutable) autoExecutable.Execute();

            foreach (var binding in Bindings)
                if (binding != null)
                {
                    binding.OnEvent?.Invoke(@event);
                    binding.OnEventNoArgs?.Invoke();
                }
        }

        public static void Clear()
        {
            Bindings.Clear();
            TempBindings.Clear();
            ToRemove.Clear();
        }
    }
}