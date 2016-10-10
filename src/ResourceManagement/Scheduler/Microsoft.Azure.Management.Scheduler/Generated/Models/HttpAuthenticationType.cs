
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for HttpAuthenticationType.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum HttpAuthenticationType
    {
        [EnumMember(Value = "NotSpecified")]
        NotSpecified,
        [EnumMember(Value = "ClientCertificate")]
        ClientCertificate,
        [EnumMember(Value = "ActiveDirectoryOAuth")]
        ActiveDirectoryOAuth,
        [EnumMember(Value = "Basic")]
        Basic
    }
}
