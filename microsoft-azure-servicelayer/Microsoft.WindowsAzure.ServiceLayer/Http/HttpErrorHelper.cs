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
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer.Http
{
    /// <summary>
    /// Helper methods for working with HTTP error codes.
    /// </summary>
    /// <remarks>HRESULT structure for HTTP errors:
    /// Severity: SEVERITY_ERROR
    /// Facility: FACILITY_ITF
    /// 6 bits for error source
    /// 10 bits for the HTTP status code.</remarks>
    public static class HttpErrorHelper
    {
        private const uint ComErrorMask = 0x80040000;       // severity: error; facility: intf.
        private const uint ErrorSourceMask = 0x0000FC00;    // 6 bits.
        private const int ErrorSourceOffset = 10;           // Offset of the error source.
        private const uint HttpStatusMask = 0x000003FF;     // Last 10 bits.

        /// <summary>
        /// Generates HRESULT for the given HTTP error.
        /// </summary>
        /// <param name="source">The source of error.</param>
        /// <param name="httpStatusCode">HTTP status code.</param>
        /// <returns>HRESULT with embedded source and status code.</returns>
        public static int GetComErrorCode(ErrorSource source, int httpStatusCode)
        {
            Validator.ArgumentIsValidEnumValue<ErrorSource>("source", source);
            Validator.ArgumentIsValidEnumValue<System.Net.HttpStatusCode>("source", httpStatusCode);

            // 10 bits should be enough for the error code!
            Debug.Assert((httpStatusCode & ErrorSourceMask) == 0);
            uint code = ComErrorMask;
            code |= ((uint)source) << ErrorSourceOffset;
            code |= (uint)httpStatusCode;
            return (int)code;
        }

        /// <summary>
        /// Extracts source and HTTP status code from the given HRESULT.
        /// </summary>
        /// <param name="hresult">HRESULT code.</param>
        /// <param name="source">Error source.</param>
        /// <param name="httpStatusCode">HTTP status code.</param>
        public static void TranslateComErrorCode(int hresult, out ErrorSource source, out int httpStatusCode)
        {
            if (!TryTranslateErrorCode(hresult, out source, out httpStatusCode))
            {
                string message = string.Format(CultureInfo.CurrentUICulture, Resources.ErrorArgumentInvalidHresult, "hresult");
                throw new ArgumentException(message);
            }
        }

        /// <summary>
        /// Attempts to extract source and HTTP status code from the given HRESULT.
        /// </summary>
        /// <param name="hresult">HRESULT code.</param>
        /// <param name="source">Error source.</param>
        /// <param name="httpStatusCode">HTTP status code.</param>
        /// <returns>True if HRESULT was successfully parsed.</returns>
        public static bool TryTranslateErrorCode(int hresult, out ErrorSource source, out int httpStatusCode)
        {
            source = 0;
            httpStatusCode = 0;

            if ((hresult & ComErrorMask) != ComErrorMask)
            {
                return false;
            }

            ErrorSource tempErrorSource = (ErrorSource)((hresult & ErrorSourceMask) >> ErrorSourceOffset);
            if (!Enum.IsDefined(typeof(ErrorSource), tempErrorSource))
            {
                return false;
            }

            int tempStatusCode = (int)((uint)hresult & HttpStatusMask);
            if (!Enum.IsDefined(typeof(System.Net.HttpStatusCode), tempStatusCode))
            {
                return false;
            }

            source = tempErrorSource;
            httpStatusCode = tempStatusCode;
            return true;
        }
    }
}
