
namespace Microsoft.Azure.Management.Cdn.Models
{

    /// <summary>
    /// Defines values for QueryStringCachingBehavior.
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum QueryStringCachingBehavior
    {
        [System.Runtime.Serialization.EnumMember(Value = "IgnoreQueryString")]
        IgnoreQueryString,
        [System.Runtime.Serialization.EnumMember(Value = "BypassCaching")]
        BypassCaching,
        [System.Runtime.Serialization.EnumMember(Value = "UseQueryString")]
        UseQueryString,
        [System.Runtime.Serialization.EnumMember(Value = "NotSet")]
        NotSet
    }
}
