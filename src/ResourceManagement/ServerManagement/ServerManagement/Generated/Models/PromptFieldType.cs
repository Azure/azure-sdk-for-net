
namespace Microsoft.Azure.Management.ServerManagement.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for PromptFieldType.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PromptFieldType
    {
        [EnumMember(Value = "String")]
        String,
        [EnumMember(Value = "SecureString")]
        SecureString,
        [EnumMember(Value = "Credential")]
        Credential
    }
}
