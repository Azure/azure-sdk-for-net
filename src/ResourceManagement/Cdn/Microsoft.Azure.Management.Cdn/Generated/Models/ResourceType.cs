
namespace Microsoft.Azure.Management.Cdn.Models
{

    /// <summary>
    /// Defines values for ResourceType.
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum ResourceType
    {
        [System.Runtime.Serialization.EnumMember(Value = "Microsoft.Cdn/Profiles/Endpoints")]
        MicrosoftCdnProfilesEndpoints
    }
}
