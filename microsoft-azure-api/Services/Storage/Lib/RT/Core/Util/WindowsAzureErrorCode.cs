// -----------------------------------------------------------------------------------------
// <copyright file="WindowsAzureErrorCode.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Core.Util
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// A collection of well-known error codes.
    /// </summary>
    /// 
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "*", Justification = "For Readability.")]
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "*", Justification = "For Readability.")]
    public sealed class WindowsAzureErrorCode
    {
        // Internal HRESULT structure: 
        // Bits 31 - 16:    HRESULT flags indicating an error (Severity: ERROR; facility: ITF)
        // Bits 12 - 15:    error source (HTTP, WRAP, etc)
        // Bits 0 - 11:     source-specific information, if any. Contains status code for HTTP errors.

        // Basic error code mark
        internal const int ComErrorMask = unchecked((int)0x80040000);        // Mask for all COM error codes
        internal const int HttpErrorMask = ComErrorMask | 0x1000;           // Mask for HTTP exceptions
        internal const int ClientErrorMask = ComErrorMask | 0x2000;           // Mask for exceptions from client side.

        // HTTP status mapping
        public static int HttpBadRequest                      { get { return HttpErrorMask | (int)HttpStatusCode.BadRequest; } }
        public static int HttpUnauthorized                    { get { return HttpErrorMask | (int)HttpStatusCode.Unauthorized; } }
        public static int HttpPaymentRequired                 { get { return HttpErrorMask | (int)HttpStatusCode.PaymentRequired; } }
        public static int HttpForbidden                       { get { return HttpErrorMask | (int)HttpStatusCode.Forbidden; } }
        public static int HttpNotFound                        { get { return HttpErrorMask | (int)HttpStatusCode.NotFound; } }
        public static int HttpMethodNotAllowed                { get { return HttpErrorMask | (int)HttpStatusCode.MethodNotAllowed; } }
        public static int HttpNotAcceptable                   { get { return HttpErrorMask | (int)HttpStatusCode.NotAcceptable; } }
        public static int HttpProxyAuthenticationRequired     { get { return HttpErrorMask | (int)HttpStatusCode.ProxyAuthenticationRequired; } }
        public static int HttpRequestTimeout                  { get { return HttpErrorMask | (int)HttpStatusCode.RequestTimeout; } }
        public static int HttpConflict                        { get { return HttpErrorMask | (int)HttpStatusCode.Conflict; } }
        public static int HttpGone                            { get { return HttpErrorMask | (int)HttpStatusCode.Gone; } }
        public static int HttpLengthRequired                  { get { return HttpErrorMask | (int)HttpStatusCode.LengthRequired; } }
        public static int HttpPreconditionFailed              { get { return HttpErrorMask | (int)HttpStatusCode.PreconditionFailed; } }
        public static int HttpRequestEntityTooLarge           { get { return HttpErrorMask | (int)HttpStatusCode.RequestEntityTooLarge; } }
        public static int HttpRequestUriTooLong               { get { return HttpErrorMask | (int)HttpStatusCode.RequestUriTooLong; } }
        public static int HttpUnsupportedMediaType            { get { return HttpErrorMask | (int)HttpStatusCode.UnsupportedMediaType; } }
        public static int HttpRequestedRangeNotSatisfiable    { get { return HttpErrorMask | (int)HttpStatusCode.RequestedRangeNotSatisfiable; } }
        public static int HttpExpectationFailed               { get { return HttpErrorMask | (int)HttpStatusCode.ExpectationFailed; } }
        public static int HttpUpgradeRequired                 { get { return HttpErrorMask | (int)HttpStatusCode.UpgradeRequired; } }
        public static int HttpInternalServerError             { get { return HttpErrorMask | (int)HttpStatusCode.InternalServerError; } }
        public static int HttpNotImplemented                  { get { return HttpErrorMask | (int)HttpStatusCode.NotImplemented; } }
        public static int HttpBadGateway                      { get { return HttpErrorMask | (int)HttpStatusCode.BadGateway; } }
        public static int HttpServiceUnavailable              { get { return HttpErrorMask | (int)HttpStatusCode.ServiceUnavailable; } }
        public static int HttpGatewayTimeout                  { get { return HttpErrorMask | (int)HttpStatusCode.GatewayTimeout; } }
        public static int HttpVersionNotSupported             { get { return HttpErrorMask | (int)HttpStatusCode.HttpVersionNotSupported; } }

        // Client side exception. 
        public static int UnknownException { get { return ClientErrorMask | (int)0xfff; } }
        
        // Pre-defined hresult code.
        public static int TimeoutException { get { return unchecked((int)0x80131505); } }
    }
}
