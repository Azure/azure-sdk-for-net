
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for ServiceBusAuthenticationType.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ServiceBusAuthenticationType
    {
        [EnumMember(Value = "NotSpecified")]
        NotSpecified,
        [EnumMember(Value = "SharedAccessKey")]
        SharedAccessKey
    }
}
