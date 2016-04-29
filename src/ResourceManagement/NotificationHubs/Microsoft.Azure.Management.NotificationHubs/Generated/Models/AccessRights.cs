
namespace Microsoft.Azure.Management.NotificationHubs.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
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
