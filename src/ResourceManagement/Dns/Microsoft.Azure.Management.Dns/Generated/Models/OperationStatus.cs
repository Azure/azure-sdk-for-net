
namespace Microsoft.Azure.Management.Dns.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for OperationStatus.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OperationStatus
    {
        [EnumMember(Value = "InProgress")]
        InProgress,
        [EnumMember(Value = "Succeeded")]
        Succeeded,
        [EnumMember(Value = "Failed")]
        Failed
    }
}
