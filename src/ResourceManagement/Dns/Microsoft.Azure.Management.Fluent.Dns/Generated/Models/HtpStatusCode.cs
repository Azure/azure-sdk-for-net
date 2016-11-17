// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.


namespace Microsoft.Azure.Management.Fluent.Dns.Models
{
    /// <summary>
    /// Defines values for HtpStatusCode.
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum HtpStatusCode
    {
        [System.Runtime.Serialization.EnumMember(Value = "Continue")]
        CONTINUE,
        [System.Runtime.Serialization.EnumMember(Value = "SwitchingProtocols")]
        SWITCHING_PROTOCOLS,
        [System.Runtime.Serialization.EnumMember(Value = "OK")]
        OK,
        [System.Runtime.Serialization.EnumMember(Value = "Created")]
        CREATED,
        [System.Runtime.Serialization.EnumMember(Value = "Accepted")]
        ACCEPTED,
        [System.Runtime.Serialization.EnumMember(Value = "NonAuthoritativeInformation")]
        NON_AUTHORITATIVE_INFORMATION,
        [System.Runtime.Serialization.EnumMember(Value = "NoContent")]
        NO_CONTENT,
        [System.Runtime.Serialization.EnumMember(Value = "ResetContent")]
        RESET_CONTENT,
        [System.Runtime.Serialization.EnumMember(Value = "PartialContent")]
        PARTIAL_CONTENT,
        [System.Runtime.Serialization.EnumMember(Value = "MultipleChoices")]
        MULTIPLE_CHOICES,
        [System.Runtime.Serialization.EnumMember(Value = "Ambiguous")]
        AMBIGUOUS,
        [System.Runtime.Serialization.EnumMember(Value = "MovedPermanently")]
        MOVED_PERMANENTLY,
        [System.Runtime.Serialization.EnumMember(Value = "Moved")]
        MOVED,
        [System.Runtime.Serialization.EnumMember(Value = "Found")]
        FOUND,
        [System.Runtime.Serialization.EnumMember(Value = "Redirect")]
        REDIRECT,
        [System.Runtime.Serialization.EnumMember(Value = "SeeOther")]
        SEE_OTHER,
        [System.Runtime.Serialization.EnumMember(Value = "RedirectMethod")]
        REDIRECT_METHOD,
        [System.Runtime.Serialization.EnumMember(Value = "NotModified")]
        NOT_MODIFIED,
        [System.Runtime.Serialization.EnumMember(Value = "UseProxy")]
        USE_PROXY,
        [System.Runtime.Serialization.EnumMember(Value = "Unused")]
        UNUSED,
        [System.Runtime.Serialization.EnumMember(Value = "TemporaryRedirect")]
        TEMPORARY_REDIRECT,
        [System.Runtime.Serialization.EnumMember(Value = "RedirectKeepVerb")]
        REDIRECT_KEEP_VERB,
        [System.Runtime.Serialization.EnumMember(Value = "BadRequest")]
        BAD_REQUEST,
        [System.Runtime.Serialization.EnumMember(Value = "Unauthorized")]
        UNAUTHORIZED,
        [System.Runtime.Serialization.EnumMember(Value = "PaymentRequired")]
        PAYMENT_REQUIRED,
        [System.Runtime.Serialization.EnumMember(Value = "Forbidden")]
        FORBIDDEN,
        [System.Runtime.Serialization.EnumMember(Value = "NotFound")]
        NOT_FOUND,
        [System.Runtime.Serialization.EnumMember(Value = "MethodNotAllowed")]
        METHOD_NOT_ALLOWED,
        [System.Runtime.Serialization.EnumMember(Value = "NotAcceptable")]
        NOT_ACCEPTABLE,
        [System.Runtime.Serialization.EnumMember(Value = "ProxyAuthenticationRequired")]
        PROXY_AUTHENTICATION_REQUIRED,
        [System.Runtime.Serialization.EnumMember(Value = "RequestTimeout")]
        REQUEST_TIMEOUT,
        [System.Runtime.Serialization.EnumMember(Value = "Conflict")]
        CONFLICT,
        [System.Runtime.Serialization.EnumMember(Value = "Gone")]
        GONE,
        [System.Runtime.Serialization.EnumMember(Value = "LengthRequired")]
        LENGTH_REQUIRED,
        [System.Runtime.Serialization.EnumMember(Value = "PreconditionFailed")]
        PRECONDITION_FAILED,
        [System.Runtime.Serialization.EnumMember(Value = "RequestEntityTooLarge")]
        REQUEST_ENTITY_TOO_LARGE,
        [System.Runtime.Serialization.EnumMember(Value = "RequestUriTooLong")]
        REQUEST_URI_TOO_LONG,
        [System.Runtime.Serialization.EnumMember(Value = "UnsupportedMediaType")]
        UNSUPPORTED_MEDIA_TYPE,
        [System.Runtime.Serialization.EnumMember(Value = "RequestedRangeNotSatisfiable")]
        REQUESTED_RANGE_NOT_SATISFIABLE,
        [System.Runtime.Serialization.EnumMember(Value = "ExpectationFailed")]
        EXPECTATION_FAILED,
        [System.Runtime.Serialization.EnumMember(Value = "UpgradeRequired")]
        UPGRADE_REQUIRED,
        [System.Runtime.Serialization.EnumMember(Value = "InternalServerError")]
        INTERNAL_SERVER_ERROR,
        [System.Runtime.Serialization.EnumMember(Value = "NotImplemented")]
        NOT_IMPLEMENTED,
        [System.Runtime.Serialization.EnumMember(Value = "BadGateway")]
        BAD_GATEWAY,
        [System.Runtime.Serialization.EnumMember(Value = "ServiceUnavailable")]
        SERVICE_UNAVAILABLE,
        [System.Runtime.Serialization.EnumMember(Value = "GatewayTimeout")]
        GATEWAY_TIMEOUT,
        [System.Runtime.Serialization.EnumMember(Value = "HttpVersionNotSupported")]
        HTTP_VERSION_NOT_SUPPORTED,
    }
}
