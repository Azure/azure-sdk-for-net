
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for ServiceBusTransportType.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ServiceBusTransportType
    {
        [EnumMember(Value = "NotSpecified")]
        NotSpecified,
        [EnumMember(Value = "NetMessaging")]
        NetMessaging,
        [EnumMember(Value = "AMQP")]
        AMQP
    }
}
