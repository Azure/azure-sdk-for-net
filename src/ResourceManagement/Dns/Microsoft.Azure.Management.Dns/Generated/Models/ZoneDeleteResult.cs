
namespace Microsoft.Azure.Management.Dns.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The response to a Zone Delete operation.
    /// </summary>
    public partial class ZoneDeleteResult
    {
        /// <summary>
        /// Initializes a new instance of the ZoneDeleteResult class.
        /// </summary>
        public ZoneDeleteResult() { }

        /// <summary>
        /// Initializes a new instance of the ZoneDeleteResult class.
        /// </summary>
        public ZoneDeleteResult(string azureAsyncOperation = default(string), OperationStatus? status = default(OperationStatus?), HtpStatusCode? statusCode = default(HtpStatusCode?), string requestId = default(string))
        {
            AzureAsyncOperation = azureAsyncOperation;
            Status = status;
            StatusCode = statusCode;
            RequestId = requestId;
        }

        /// <summary>
        /// Users can perform a Get on Azure-AsyncOperation to get the status
        /// of their delete Zone operations
        /// </summary>
        [JsonProperty(PropertyName = "azureAsyncOperation")]
        public string AzureAsyncOperation { get; set; }

        /// <summary>
        /// Possible values include: 'InProgress', 'Succeeded', 'Failed'
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public OperationStatus? Status { get; set; }

        /// <summary>
        /// Possible values include: 'Continue', 'SwitchingProtocols', 'OK',
        /// 'Created', 'Accepted', 'NonAuthoritativeInformation',
        /// 'NoContent', 'ResetContent', 'PartialContent', 'MultipleChoices',
        /// 'Ambiguous', 'MovedPermanently', 'Moved', 'Found', 'Redirect',
        /// 'SeeOther', 'RedirectMethod', 'NotModified', 'UseProxy',
        /// 'Unused', 'TemporaryRedirect', 'RedirectKeepVerb', 'BadRequest',
        /// 'Unauthorized', 'PaymentRequired', 'Forbidden', 'NotFound',
        /// 'MethodNotAllowed', 'NotAcceptable',
        /// 'ProxyAuthenticationRequired', 'RequestTimeout', 'Conflict',
        /// 'Gone', 'LengthRequired', 'PreconditionFailed',
        /// 'RequestEntityTooLarge', 'RequestUriTooLong',
        /// 'UnsupportedMediaType', 'RequestedRangeNotSatisfiable',
        /// 'ExpectationFailed', 'UpgradeRequired', 'InternalServerError',
        /// 'NotImplemented', 'BadGateway', 'ServiceUnavailable',
        /// 'GatewayTimeout', 'HttpVersionNotSupported'
        /// </summary>
        [JsonProperty(PropertyName = "statusCode")]
        public HtpStatusCode? StatusCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "requestId")]
        public string RequestId { get; set; }

    }
}
