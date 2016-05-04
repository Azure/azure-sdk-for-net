
namespace Microsoft.Azure.Management.ServerManagement.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for AutoUpgrade.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AutoUpgrade
    {
        [EnumMember(Value = "On")]
        On,
        [EnumMember(Value = "Off")]
        Off
    }
}
