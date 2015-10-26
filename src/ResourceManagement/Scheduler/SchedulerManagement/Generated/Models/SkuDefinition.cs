
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for SkuDefinition.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SkuDefinition
    {
        [EnumMember(Value = "Standard")]
        Standard,
        [EnumMember(Value = "Free")]
        Free,
        [EnumMember(Value = "Premium")]
        Premium
    }
}
