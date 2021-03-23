namespace Azure.Core.Amqp
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct AmqpAddress : System.IEquatable<Azure.Core.Amqp.AmqpAddress>
    {
        private object _dummy;
        private int _dummyPrimitive;
        public AmqpAddress(string address) { throw null; }
        public bool Equals(Azure.Core.Amqp.AmqpAddress other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public bool Equals(string other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Core.Amqp.AmqpAddress left, Azure.Core.Amqp.AmqpAddress right) { throw null; }
        public static bool operator !=(Azure.Core.Amqp.AmqpAddress left, Azure.Core.Amqp.AmqpAddress right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AmqpAnnotatedMessage
    {
        public AmqpAnnotatedMessage(Azure.Core.Amqp.AmqpMessageBody body) { }
        public System.Collections.Generic.IDictionary<string, object> ApplicationProperties { get { throw null; } }
        public Azure.Core.Amqp.AmqpMessageBody Body { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> DeliveryAnnotations { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> Footer { get { throw null; } }
        public Azure.Core.Amqp.AmqpMessageHeader Header { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> MessageAnnotations { get { throw null; } }
        public Azure.Core.Amqp.AmqpMessageProperties Properties { get { throw null; } }
    }
    public partial class AmqpMessageBody
    {
        public AmqpMessageBody(System.Collections.Generic.IEnumerable<System.ReadOnlyMemory<byte>> data) { }
        public Azure.Core.Amqp.AmqpMessageBodyType BodyType { get { throw null; } }
        public bool TryGetData(out System.Collections.Generic.IEnumerable<System.ReadOnlyMemory<byte>>? data) { throw null; }
    }
    public enum AmqpMessageBodyType
    {
        Data = 0,
        Value = 1,
        Sequence = 2,
    }
    public partial class AmqpMessageHeader
    {
        internal AmqpMessageHeader() { }
        public uint? DeliveryCount { get { throw null; } set { } }
        public bool? Durable { get { throw null; } set { } }
        public bool? FirstAcquirer { get { throw null; } set { } }
        public byte? Priority { get { throw null; } set { } }
        public System.TimeSpan? TimeToLive { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct AmqpMessageId : System.IEquatable<Azure.Core.Amqp.AmqpMessageId>
    {
        private object _dummy;
        private int _dummyPrimitive;
        public AmqpMessageId(string messageId) { throw null; }
        public bool Equals(Azure.Core.Amqp.AmqpMessageId other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public bool Equals(string other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Core.Amqp.AmqpMessageId left, Azure.Core.Amqp.AmqpMessageId right) { throw null; }
        public static bool operator !=(Azure.Core.Amqp.AmqpMessageId left, Azure.Core.Amqp.AmqpMessageId right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AmqpMessageProperties
    {
        internal AmqpMessageProperties() { }
        public System.DateTimeOffset? AbsoluteExpiryTime { get { throw null; } set { } }
        public string? ContentEncoding { get { throw null; } set { } }
        public string? ContentType { get { throw null; } set { } }
        public Azure.Core.Amqp.AmqpMessageId? CorrelationId { get { throw null; } set { } }
        public System.DateTimeOffset? CreationTime { get { throw null; } set { } }
        public string? GroupId { get { throw null; } set { } }
        public uint? GroupSequence { get { throw null; } set { } }
        public Azure.Core.Amqp.AmqpMessageId? MessageId { get { throw null; } set { } }
        public Azure.Core.Amqp.AmqpAddress? ReplyTo { get { throw null; } set { } }
        public string? ReplyToGroupId { get { throw null; } set { } }
        public string? Subject { get { throw null; } set { } }
        public Azure.Core.Amqp.AmqpAddress? To { get { throw null; } set { } }
        public System.ReadOnlyMemory<byte>? UserId { get { throw null; } set { } }
    }
}
