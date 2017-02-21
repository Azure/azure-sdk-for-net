// MIT

namespace Microsoft.Azure.Management.IotHub.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for JobStatus.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum JobStatus
    {
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "enqueued")]
        Enqueued,
        [EnumMember(Value = "running")]
        Running,
        [EnumMember(Value = "completed")]
        Completed,
        [EnumMember(Value = "failed")]
        Failed,
        [EnumMember(Value = "cancelled")]
        Cancelled
    }
}
