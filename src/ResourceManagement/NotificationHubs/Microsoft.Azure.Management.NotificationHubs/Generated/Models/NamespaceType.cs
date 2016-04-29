
namespace Microsoft.Azure.Management.NotificationHubs.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for NamespaceType.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum NamespaceType
    {
        [EnumMember(Value = "Messaging")]
        Messaging,
        [EnumMember(Value = "NotificationHub")]
        NotificationHub
    }
}
