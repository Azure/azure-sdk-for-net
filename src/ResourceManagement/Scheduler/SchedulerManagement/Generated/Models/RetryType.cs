
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for RetryType.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RetryType
    {
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "Fixed")]
        Fixed
    }
}
