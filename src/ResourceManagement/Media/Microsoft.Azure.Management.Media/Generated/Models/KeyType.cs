
namespace Microsoft.Azure.Management.Media.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for KeyType.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KeyType
    {
        [EnumMember(Value = "Primary")]
        Primary,
        [EnumMember(Value = "Secondary")]
        Secondary
    }
}
