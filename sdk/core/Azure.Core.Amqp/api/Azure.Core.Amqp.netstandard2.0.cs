namespace Azure.Core.Amqp
{
    public partial class AmqpAnnotatedMessage
    {
        public AmqpAnnotatedMessage(Azure.Core.Amqp.AmqpAnnotatedMessage messageToCopy) { }
        public AmqpAnnotatedMessage(System.Collections.Generic.IEnumerable<Azure.BinaryData> dataBody) { }
        public System.Collections.Generic.IDictionary<string, object> ApplicationProperties { get { throw null; } }
        public Azure.Core.Amqp.AmqpMessageBody Body { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> DeliveryAnnotations { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> Footer { get { throw null; } }
        public Azure.Core.Amqp.AmqpMessageHeader Header { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> MessageAnnotations { get { throw null; } }
        public Azure.Core.Amqp.AmqpMessageProperties Properties { get { throw null; } set { } }
    }
    public partial class AmqpDataMessageBody : Azure.Core.Amqp.AmqpMessageBody
    {
        public AmqpDataMessageBody(System.Collections.Generic.IEnumerable<Azure.BinaryData> data) { }
        public System.Collections.Generic.IEnumerable<Azure.BinaryData> Data { get { throw null; } }
    }
    public abstract partial class AmqpMessageBody
    {
        protected AmqpMessageBody() { }
    }
    public partial class AmqpMessageHeader
    {
        public AmqpMessageHeader() { }
        public uint? DeliveryCount { get { throw null; } set { } }
        public bool? Durable { get { throw null; } set { } }
        public bool? FirstAcquirer { get { throw null; } set { } }
        public byte? Priority { get { throw null; } set { } }
        public System.TimeSpan? TimeToLive { get { throw null; } set { } }
    }
    public partial class AmqpMessageProperties
    {
        public AmqpMessageProperties() { }
        public AmqpMessageProperties(Azure.Core.Amqp.AmqpMessageProperties properties) { }
        public System.DateTimeOffset? AbsoluteExpiryTime { get { throw null; } set { } }
        public string? ContentEncoding { get { throw null; } set { } }
        public string? ContentType { get { throw null; } set { } }
        public string? CorrelationId { get { throw null; } set { } }
        public System.DateTimeOffset? CreationTime { get { throw null; } set { } }
        public string? GroupId { get { throw null; } set { } }
        public uint? GroupSequence { get { throw null; } set { } }
        public string? MessageId { get { throw null; } set { } }
        public string? ReplyTo { get { throw null; } set { } }
        public string? ReplyToGroupId { get { throw null; } set { } }
        public string? Subject { get { throw null; } set { } }
        public string? To { get { throw null; } set { } }
        public Azure.BinaryData? UserId { get { throw null; } set { } }
    }
}
