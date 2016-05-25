
namespace Microsoft.Azure.Management.Dns.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for HtpStatusCode.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum HtpStatusCode
    {
        [EnumMember(Value = "Continue")]
        Continue,
        [EnumMember(Value = "SwitchingProtocols")]
        SwitchingProtocols,
        [EnumMember(Value = "OK")]
        OK,
        [EnumMember(Value = "Created")]
        Created,
        [EnumMember(Value = "Accepted")]
        Accepted,
        [EnumMember(Value = "NonAuthoritativeInformation")]
        NonAuthoritativeInformation,
        [EnumMember(Value = "NoContent")]
        NoContent,
        [EnumMember(Value = "ResetContent")]
        ResetContent,
        [EnumMember(Value = "PartialContent")]
        PartialContent,
        [EnumMember(Value = "MultipleChoices")]
        MultipleChoices,
        [EnumMember(Value = "Ambiguous")]
        Ambiguous,
        [EnumMember(Value = "MovedPermanently")]
        MovedPermanently,
        [EnumMember(Value = "Moved")]
        Moved,
        [EnumMember(Value = "Found")]
        Found,
        [EnumMember(Value = "Redirect")]
        Redirect,
        [EnumMember(Value = "SeeOther")]
        SeeOther,
        [EnumMember(Value = "RedirectMethod")]
        RedirectMethod,
        [EnumMember(Value = "NotModified")]
        NotModified,
        [EnumMember(Value = "UseProxy")]
        UseProxy,
        [EnumMember(Value = "Unused")]
        Unused,
        [EnumMember(Value = "TemporaryRedirect")]
        TemporaryRedirect,
        [EnumMember(Value = "RedirectKeepVerb")]
        RedirectKeepVerb,
        [EnumMember(Value = "BadRequest")]
        BadRequest,
        [EnumMember(Value = "Unauthorized")]
        Unauthorized,
        [EnumMember(Value = "PaymentRequired")]
        PaymentRequired,
        [EnumMember(Value = "Forbidden")]
        Forbidden,
        [EnumMember(Value = "NotFound")]
        NotFound,
        [EnumMember(Value = "MethodNotAllowed")]
        MethodNotAllowed,
        [EnumMember(Value = "NotAcceptable")]
        NotAcceptable,
        [EnumMember(Value = "ProxyAuthenticationRequired")]
        ProxyAuthenticationRequired,
        [EnumMember(Value = "RequestTimeout")]
        RequestTimeout,
        [EnumMember(Value = "Conflict")]
        Conflict,
        [EnumMember(Value = "Gone")]
        Gone,
        [EnumMember(Value = "LengthRequired")]
        LengthRequired,
        [EnumMember(Value = "PreconditionFailed")]
        PreconditionFailed,
        [EnumMember(Value = "RequestEntityTooLarge")]
        RequestEntityTooLarge,
        [EnumMember(Value = "RequestUriTooLong")]
        RequestUriTooLong,
        [EnumMember(Value = "UnsupportedMediaType")]
        UnsupportedMediaType,
        [EnumMember(Value = "RequestedRangeNotSatisfiable")]
        RequestedRangeNotSatisfiable,
        [EnumMember(Value = "ExpectationFailed")]
        ExpectationFailed,
        [EnumMember(Value = "UpgradeRequired")]
        UpgradeRequired,
        [EnumMember(Value = "InternalServerError")]
        InternalServerError,
        [EnumMember(Value = "NotImplemented")]
        NotImplemented,
        [EnumMember(Value = "BadGateway")]
        BadGateway,
        [EnumMember(Value = "ServiceUnavailable")]
        ServiceUnavailable,
        [EnumMember(Value = "GatewayTimeout")]
        GatewayTimeout,
        [EnumMember(Value = "HttpVersionNotSupported")]
        HttpVersionNotSupported
    }
}
