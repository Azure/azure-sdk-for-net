// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Fluent.Dns.Models
{
    /// <summary>
    /// The response to a Zone Delete operation.
    /// </summary>
    public partial class ZoneDeleteResultInner
    {
        /// <summary>
        /// Users can perform a Get on Azure-AsyncOperation to get the status of
        /// their delete Zone operations.
        /// </summary>
        public string AzureAsyncOperation { get; set; }

        /// <summary>
        /// Possible values include: 'InProgress', 'Succeeded', 'Failed'.
        /// </summary>
        public OperationStatus Status {get; set; }

        /// <summary>
        /// Possible values include: 'Continue', 'SwitchingProtocols', 'OK',
        /// 'Created', 'Accepted', 'NonAuthoritativeInformation', 'NoContent',
        /// 'ResetContent', 'PartialContent', 'MultipleChoices', 'Ambiguous',
        /// 'MovedPermanently', 'Moved', 'Found', 'Redirect', 'SeeOther',
        /// 'RedirectMethod', 'NotModified', 'UseProxy', 'Unused',
        /// 'TemporaryRedirect', 'RedirectKeepVerb', 'BadRequest', 'Unauthorized',
        /// 'PaymentRequired', 'Forbidden', 'NotFound', 'MethodNotAllowed',
        /// 'NotAcceptable', 'ProxyAuthenticationRequired', 'RequestTimeout',
        /// 'Conflict', 'Gone', 'LengthRequired', 'PreconditionFailed',
        /// 'RequestEntityTooLarge', 'RequestUriTooLong', 'UnsupportedMediaType',
        /// 'RequestedRangeNotSatisfiable', 'ExpectationFailed',
        /// 'UpgradeRequired', 'InternalServerError', 'NotImplemented',
        /// 'BadGateway', 'ServiceUnavailable', 'GatewayTimeout',
        /// 'HttpVersionNotSupported'.
        /// </summary>
        public HtpStatusCode StatusCode { get; set; }

        /// <summary>
        /// The requestId property.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Initializes a new instance of the ZoneDeleteResultInner class.
        /// </summary>
        public ZoneDeleteResultInner() { }

        /// <summary>
        /// Initializes a new instance of the ZoneDeleteResultInner class.
        /// </summary>
        /// <param name="azureAsyncOperation">async operation</param>
        /// <param name="status">the status</param>
        /// <param name="statusCode">the http status code</param>
        /// <param name="requestId">the request id</param>
        public ZoneDeleteResultInner(string azureAsyncOperation = default(string), OperationStatus status = default(OperationStatus), HtpStatusCode statusCode = default(HtpStatusCode), string requestId = default(string))
        {
            AzureAsyncOperation = azureAsyncOperation;
            Status = status;
            StatusCode = statusCode;
            RequestId = requestId;
        }
    }
}
