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
    public static class WindowsAzureErrorCode2
    {
        // Internal HRESULT structure: 
        // Bits 31 - 16:    HRESULT flags indicating an error (Severity: ERROR; facility: ITF)
        // Bits 12 - 15:    error source (HTTP, WRAP, etc)
        // Bits 0 - 11:     source-specific information, if any. Contains status code for HTTP errors.

        // Generic WRAP authentication failure.
        public static int WrapAuthenticationFailure { get { return Constants.WrapErrorMask; } }

        // HTTP status exceptions
        public static int HttpContinue                        { get { return Constants.HttpErrorMask | (int)HttpStatusCode.Continue; } }
        public static int HttpSwitchingProtocols              { get { return Constants.HttpErrorMask | (int)HttpStatusCode.SwitchingProtocols; } }
        public static int HttpOK                              { get { return Constants.HttpErrorMask | (int)HttpStatusCode.OK; } }
        public static int HttpCreated                         { get { return Constants.HttpErrorMask | (int)HttpStatusCode.Created; } }
        public static int HttpAccepted                        { get { return Constants.HttpErrorMask | (int)HttpStatusCode.Accepted; } }
        public static int HttpNonAuthoritativeInformation     { get { return Constants.HttpErrorMask | (int)HttpStatusCode.NonAuthoritativeInformation; } }
        public static int HttpNoContent                       { get { return Constants.HttpErrorMask | (int)HttpStatusCode.NoContent; } }
        public static int HttpResetContent                    { get { return Constants.HttpErrorMask | (int)HttpStatusCode.ResetContent; } }
        public static int HttpPartialContent                  { get { return Constants.HttpErrorMask | (int)HttpStatusCode.PartialContent; } }
        public static int HttpMultipleChoices                 { get { return Constants.HttpErrorMask | (int)HttpStatusCode.MultipleChoices; } }
        public static int HttpAmbiguous                       { get { return Constants.HttpErrorMask | (int)HttpStatusCode.Ambiguous; } }
        public static int HttpMovedPermanently                { get { return Constants.HttpErrorMask | (int)HttpStatusCode.MovedPermanently; } }
        public static int HttpMoved                           { get { return Constants.HttpErrorMask | (int)HttpStatusCode.Moved; } }
        public static int HttpFound                           { get { return Constants.HttpErrorMask | (int)HttpStatusCode.Found; } }
        public static int HttpRedirect                        { get { return Constants.HttpErrorMask | (int)HttpStatusCode.Redirect; } }
        public static int HttpSeeOther                        { get { return Constants.HttpErrorMask | (int)HttpStatusCode.SeeOther; } }
        public static int HttpRedirectMethod                  { get { return Constants.HttpErrorMask | (int)HttpStatusCode.RedirectMethod; } }
        public static int HttpNotModified                     { get { return Constants.HttpErrorMask | (int)HttpStatusCode.NotModified; } }
        public static int HttpUseProxy                        { get { return Constants.HttpErrorMask | (int)HttpStatusCode.UseProxy; } }
        public static int HttpUnused                          { get { return Constants.HttpErrorMask | (int)HttpStatusCode.Unused; } }
        public static int HttpRedirectKeepVerb                { get { return Constants.HttpErrorMask | (int)HttpStatusCode.RedirectKeepVerb; } }
        public static int HttpTemporaryRedirect               { get { return Constants.HttpErrorMask | (int)HttpStatusCode.TemporaryRedirect; } }
        public static int HttpBadRequest                      { get { return Constants.HttpErrorMask | (int)HttpStatusCode.BadRequest; } }
        public static int HttpUnauthorized                    { get { return Constants.HttpErrorMask | (int)HttpStatusCode.Unauthorized; } }
        public static int HttpPaymentRequired                 { get { return Constants.HttpErrorMask | (int)HttpStatusCode.PaymentRequired; } }
        public static int HttpForbidden                       { get { return Constants.HttpErrorMask | (int)HttpStatusCode.Forbidden; } }
        public static int HttpNotFound                        { get { return Constants.HttpErrorMask | (int)HttpStatusCode.NotFound; } }
        public static int HttpMethodNotAllowed                { get { return Constants.HttpErrorMask | (int)HttpStatusCode.MethodNotAllowed; } }
        public static int HttpNotAcceptable                   { get { return Constants.HttpErrorMask | (int)HttpStatusCode.NotAcceptable; } }
        public static int HttpProxyAuthenticationRequired     { get { return Constants.HttpErrorMask | (int)HttpStatusCode.ProxyAuthenticationRequired; } }
        public static int HttpRequestTimeout                  { get { return Constants.HttpErrorMask | (int)HttpStatusCode.RequestTimeout; } }
        public static int HttpConflict                        { get { return Constants.HttpErrorMask | (int)HttpStatusCode.Conflict; } }
        public static int HttpGone                            { get { return Constants.HttpErrorMask | (int)HttpStatusCode.Gone; } }
        public static int HttpLengthRequired                  { get { return Constants.HttpErrorMask | (int)HttpStatusCode.LengthRequired; } }
        public static int HttpPreconditionFailed              { get { return Constants.HttpErrorMask | (int)HttpStatusCode.PreconditionFailed; } }
        public static int HttpRequestEntityTooLarge           { get { return Constants.HttpErrorMask | (int)HttpStatusCode.RequestEntityTooLarge; } }
        public static int HttpRequestUriTooLong               { get { return Constants.HttpErrorMask | (int)HttpStatusCode.RequestUriTooLong; } }
        public static int HttpUnsupportedMediaType            { get { return Constants.HttpErrorMask | (int)HttpStatusCode.UnsupportedMediaType; } }
        public static int HttpRequestedRangeNotSatisfiable    { get { return Constants.HttpErrorMask | (int)HttpStatusCode.RequestedRangeNotSatisfiable; } }
        public static int HttpExpectationFailed               { get { return Constants.HttpErrorMask | (int)HttpStatusCode.ExpectationFailed; } }
        public static int HttpUpgradeRequired                 { get { return Constants.HttpErrorMask | (int)HttpStatusCode.UpgradeRequired; } }
        public static int HttpInternalServerError             { get { return Constants.HttpErrorMask | (int)HttpStatusCode.InternalServerError; } }
        public static int HttpNotImplemented                  { get { return Constants.HttpErrorMask | (int)HttpStatusCode.NotImplemented; } }
        public static int HttpBadGateway                      { get { return Constants.HttpErrorMask | (int)HttpStatusCode.BadGateway; } }
        public static int HttpServiceUnavailable              { get { return Constants.HttpErrorMask | (int)HttpStatusCode.ServiceUnavailable; } }
        public static int HttpGatewayTimeout                  { get { return Constants.HttpErrorMask | (int)HttpStatusCode.GatewayTimeout; } }
        public static int HttpVersionNotSupported             { get { return Constants.HttpErrorMask | (int)HttpStatusCode.HttpVersionNotSupported; } }
    }

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
