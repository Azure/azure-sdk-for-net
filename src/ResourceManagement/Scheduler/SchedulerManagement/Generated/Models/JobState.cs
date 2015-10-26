
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for JobState.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum JobState
    {
        [EnumMember(Value = "Enabled")]
        Enabled,
        [EnumMember(Value = "Disabled")]
        Disabled,
        [EnumMember(Value = "Faulted")]
        Faulted,
        [EnumMember(Value = "Completed")]
        Completed
    }
}
