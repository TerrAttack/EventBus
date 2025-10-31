namespace Utils.EventBus
{
    public interface IAutoExecutableEvent : IEvent
    {
        void Execute();
    }
}