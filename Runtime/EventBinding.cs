using System;

namespace Utils.EventBus
{
    public class EventBinding<T> : IEventBinding<T> where T : IEvent
    {
        public EventBinding(Action<T> onEvent)
        {
            OnEvent = onEvent;
        }

        public EventBinding(Action onEventNoArgs)
        {
            OnEventNoArgs = onEventNoArgs;
        }

        public Action<T> OnEvent { get; set; }
        public Action OnEventNoArgs { get; set; }

        Action<T> IEventBinding<T>.OnEvent
        {
            get => OnEvent;
            set => OnEvent = value;
        }

        Action IEventBinding<T>.OnEventNoArgs
        {
            get => OnEventNoArgs;
            set => OnEventNoArgs = value;
        }

        public void Add(Action<T> onEvent)
        {
            OnEvent += onEvent;
        }

        public void Add(Action onEvent)
        {
            OnEventNoArgs += onEvent;
        }

        public void Remove(Action<T> onEvent)
        {
            OnEvent -= onEvent;
        }

        public void Remove(Action onEvent)
        {
            OnEventNoArgs -= onEvent;
        }
    }
}