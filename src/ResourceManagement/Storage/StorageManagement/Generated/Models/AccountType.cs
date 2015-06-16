namespace Microsoft.Azure.Management.Storage.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for AccountType
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AccountType
    {
        [EnumMember(Value = "StandardLRS")]
        StandardLRS,
        [EnumMember(Value = "StandardZRS")]
        StandardZRS,
        [EnumMember(Value = "StandardGRS")]
        StandardGRS,
        [EnumMember(Value = "StandardRAGRS")]
        StandardRAGRS,
        [EnumMember(Value = "PremiumLRS")]
        PremiumLRS
    }
}
