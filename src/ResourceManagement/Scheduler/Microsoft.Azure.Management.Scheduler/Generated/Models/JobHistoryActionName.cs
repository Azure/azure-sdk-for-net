
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for JobHistoryActionName.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum JobHistoryActionName
    {
        [EnumMember(Value = "MainAction")]
        MainAction,
        [EnumMember(Value = "ErrorAction")]
        ErrorAction
    }
}
