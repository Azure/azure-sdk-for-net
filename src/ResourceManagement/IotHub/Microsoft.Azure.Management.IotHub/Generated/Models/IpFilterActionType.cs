// MIT

namespace Microsoft.Azure.Management.IotHub.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for IpFilterActionType.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IpFilterActionType
    {
        [EnumMember(Value = "Accept")]
        Accept,
        [EnumMember(Value = "Reject")]
        Reject
    }
}
