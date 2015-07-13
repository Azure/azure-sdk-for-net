namespace Microsoft.Azure.Management.Storage.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for ProvisioningState
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProvisioningState
    {
        [EnumMember(Value = "Creating")]
        Creating,
        [EnumMember(Value = "ResolvingDNS")]
        ResolvingDNS,
        [EnumMember(Value = "Succeeded")]
        Succeeded
    }
}
