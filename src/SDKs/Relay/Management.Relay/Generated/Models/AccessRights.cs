// %~6

namespace Microsoft.Azure.Management.Relay.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.Relay;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for AccessRights.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AccessRights
    {
        [EnumMember(Value = "Manage")]
        Manage,
        [EnumMember(Value = "Send")]
        Send,
        [EnumMember(Value = "Listen")]
        Listen
    }
}
