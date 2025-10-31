namespace Utils.EventBus
{
    public interface ICallbackEvent<in TReply> : IEvent
    {
        System.Action<TReply> Callback { get; }
    }
}