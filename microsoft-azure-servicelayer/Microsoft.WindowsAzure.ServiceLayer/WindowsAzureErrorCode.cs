//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer
{
    /// <summary>
    /// A collection of well-known error codes.
    /// </summary>
    public enum WindowsAzureErrorCode
    {
        // Internal HRESULT structure: 
        // Bits 31 - 16:    HRESULT flags indicating an error (Severity: ERROR; facility: ITF)
        // Bits 12 - 15:    error source (HTTP, WRAP, etc)
        // Bits 0 - 11:     source-specific information, if any. Contains status code for HTTP errors.

        // Generic WRAP authentication failure.
        WrapAuthenticationFailure = Constants.WrapErrorMask,

        // HTTP status exceptions
        HttpContinue                        = Constants.HttpErrorMask | HttpStatusCode.Continue,
        HttpSwitchingProtocols              = Constants.HttpErrorMask | HttpStatusCode.SwitchingProtocols,
        HttpOK                              = Constants.HttpErrorMask | HttpStatusCode.OK,
        HttpCreated                         = Constants.HttpErrorMask | HttpStatusCode.Created,
        HttpAccepted                        = Constants.HttpErrorMask | HttpStatusCode.Accepted,
        HttpNonAuthoritativeInformation     = Constants.HttpErrorMask | HttpStatusCode.NonAuthoritativeInformation,
        HttpNoContent                       = Constants.HttpErrorMask | HttpStatusCode.NoContent,
        HttpResetContent                    = Constants.HttpErrorMask | HttpStatusCode.ResetContent,
        HttpPartialContent                  = Constants.HttpErrorMask | HttpStatusCode.PartialContent,
        HttpMultipleChoices                 = Constants.HttpErrorMask | HttpStatusCode.MultipleChoices,
        HttpAmbiguous                       = Constants.HttpErrorMask | HttpStatusCode.Ambiguous,
        HttpMovedPermanently                = Constants.HttpErrorMask | HttpStatusCode.MovedPermanently,
        HttpMoved                           = Constants.HttpErrorMask | HttpStatusCode.Moved,
        HttpFound                           = Constants.HttpErrorMask | HttpStatusCode.Found,
        HttpRedirect                        = Constants.HttpErrorMask | HttpStatusCode.Redirect,
        HttpSeeOther                        = Constants.HttpErrorMask | HttpStatusCode.SeeOther,
        HttpRedirectMethod                  = Constants.HttpErrorMask | HttpStatusCode.RedirectMethod,
        HttpNotModified                     = Constants.HttpErrorMask | HttpStatusCode.NotModified,
        HttpUseProxy                        = Constants.HttpErrorMask | HttpStatusCode.UseProxy,
        HttpUnused                          = Constants.HttpErrorMask | HttpStatusCode.Unused,
        HttpRedirectKeepVerb                = Constants.HttpErrorMask | HttpStatusCode.RedirectKeepVerb,
        HttpTemporaryRedirect               = Constants.HttpErrorMask | HttpStatusCode.TemporaryRedirect,
        HttpBadRequest                      = Constants.HttpErrorMask | HttpStatusCode.BadRequest,
        HttpUnauthorized                    = Constants.HttpErrorMask | HttpStatusCode.Unauthorized,
        HttpPaymentRequired                 = Constants.HttpErrorMask | HttpStatusCode.PaymentRequired,
        HttpForbidden                       = Constants.HttpErrorMask | HttpStatusCode.Forbidden,
        HttpNotFound                        = Constants.HttpErrorMask | HttpStatusCode.NotFound,
        HttpMethodNotAllowed                = Constants.HttpErrorMask | HttpStatusCode.MethodNotAllowed,
        HttpNotAcceptable                   = Constants.HttpErrorMask | HttpStatusCode.NotAcceptable,
        HttpProxyAuthenticationRequired     = Constants.HttpErrorMask | HttpStatusCode.ProxyAuthenticationRequired,
        HttpRequestTimeout                  = Constants.HttpErrorMask | HttpStatusCode.RequestTimeout,
        HttpConflict                        = Constants.HttpErrorMask | HttpStatusCode.Conflict,
        HttpGone                            = Constants.HttpErrorMask | HttpStatusCode.Gone,
        HttpLengthRequired                  = Constants.HttpErrorMask | HttpStatusCode.LengthRequired,
        HttpPreconditionFailed              = Constants.HttpErrorMask | HttpStatusCode.PreconditionFailed,
        HttpRequestEntityTooLarge           = Constants.HttpErrorMask | HttpStatusCode.RequestEntityTooLarge,
        HttpRequestUriTooLong               = Constants.HttpErrorMask | HttpStatusCode.RequestUriTooLong,
        HttpUnsupportedMediaType            = Constants.HttpErrorMask | HttpStatusCode.UnsupportedMediaType,
        HttpRequestedRangeNotSatisfiable    = Constants.HttpErrorMask | HttpStatusCode.RequestedRangeNotSatisfiable,
        HttpExpectationFailed               = Constants.HttpErrorMask | HttpStatusCode.ExpectationFailed,
        HttpUpgradeRequired                 = Constants.HttpErrorMask | HttpStatusCode.UpgradeRequired,
        HttpInternalServerError             = Constants.HttpErrorMask | HttpStatusCode.InternalServerError,
        HttpNotImplemented                  = Constants.HttpErrorMask | HttpStatusCode.NotImplemented,
        HttpBadGateway                      = Constants.HttpErrorMask | HttpStatusCode.BadGateway,
        HttpServiceUnavailable              = Constants.HttpErrorMask | HttpStatusCode.ServiceUnavailable,
        HttpGatewayTimeout                  = Constants.HttpErrorMask | HttpStatusCode.GatewayTimeout,
        HttpVersionNotSupported             = Constants.HttpErrorMask | HttpStatusCode.HttpVersionNotSupported,
    }
}
