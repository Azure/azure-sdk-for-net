namespace Microsoft.Azure.Management.Resources.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for LockLevel
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LockLevel
    {
        [EnumMember(Value = "NotSpecified")]
        NotSpecified,
        [EnumMember(Value = "CanNotDelete")]
        CanNotDelete,
        [EnumMember(Value = "ReadOnly")]
        ReadOnly
    }
}
