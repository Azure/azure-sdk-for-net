//-----------------------------------------------------------------------
// <copyright file="HttpWebUtility.cs" company="Microsoft">
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
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Core.Util
{
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

#if WINDOWS_RT
    using System.Net.Http;
#else
    using System.Net;
#endif

    /// <summary>
    /// Provides helper functions for http request/response processing. 
    /// </summary>
    internal static class HttpWebUtility
    {
        /// <summary>
        /// Parse the http query string.
        /// </summary>
        /// <param name="query">Http query string.</param>
        /// <returns></returns>
        public static Dictionary<string, string> ParseQueryString(string query)
        {
            Dictionary<string, string> retVal = new Dictionary<string, string>();
            if (query == null || query.Length == 0)
            {
                return retVal;
            }

            // remove ? if present
            if (query.StartsWith("?", StringComparison.Ordinal))
            {
                query = query.Substring(1);
            }

            string[] valuePairs = query.Split(new string[] { "&" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string vp in valuePairs)
            {
                int equalDex = vp.IndexOf("=", StringComparison.Ordinal);
                if (equalDex < 0)
                {
                    retVal.Add(Uri.UnescapeDataString(vp), null);
                    continue;
                }

                string key = vp.Substring(0, equalDex);
                string value = vp.Substring(equalDex + 1);

                retVal.Add(Uri.UnescapeDataString(key), Uri.UnescapeDataString(value));
            }

            return retVal;
        }

        /// <summary>
        /// Converts the DateTimeOffset object to an Http string of form: Sun, 28 Jan 2008 12:11:37 GMT.
        /// </summary>
        /// <param name="dateTime">The DateTimeOffset object to convert to an Http string.</param>
        /// <returns>String of form: Sun, 28 Jan 2008 12:11:37 GMT.</returns>
        public static string ConvertDateTimeToHttpString(DateTimeOffset dateTime)
        {
            // 'R' means rfc1123 date which is what the storage services use for all dates...
            // It will be in the following format:
            // Sun, 28 Jan 2008 12:11:37 GMT
            return dateTime.UtcDateTime.ToString("R", CultureInfo.InvariantCulture);
        }

#if WINDOWS_RT
        /// <summary>
        /// Combine all the header values in the IEnumerable to a single comma separated string.
        /// </summary>
        /// <param name="headerValues">An IEnumerable<string> object representing the header values.</string></param>
        /// <returns>A comma separated string of header values.</returns>
        public static string CombineHttpHeaderValues(IEnumerable<string> headerValues)
        {
            if (headerValues == null)
            {
                return null;
            }

            return (headerValues.Count() == 0) ?
                null :
                string.Join(",", headerValues);
        }
#endif

#if WINDOWS_DESKTOP
        /// <summary>
        /// Try to get the value of the specified header name.
        /// </summary>
        /// <param name="resp">The Http web response from which to get the header value.</param>
        /// <param name="headerName">The name of the header whose value is to be retrieved.</param>
        /// <param name="defaultValue">The default value for the header that is returned if we can't get the actual header value.</param>
        /// <returns>A string representing the header value.</returns>
        public static string TryGetHeader(HttpWebResponse resp, string headerName, string defaultValue)
        {
            string value = resp.Headers[headerName];
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }
#endif
    }
}
