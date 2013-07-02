//-----------------------------------------------------------------------
// <copyright file="CommonUtils.cs" company="Microsoft">
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
    using System;
    using System.Collections.Generic;
    using System.Linq;

#if DNCP
        using System.Net;
#endif

    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    internal static class CommonUtils
    {
        /// <summary>
        /// Gets the first header value or null if no header values exist.
        /// </summary>
        /// <typeparam name="T">The type of header objects contained in the enumerable.</typeparam>
        /// <param name="headerValues">An enumerable that contains header values.</param>
        /// <returns>The first header value or null if no header values exist.</returns>
        public static string GetFirstHeaderValue<T>(IEnumerable<T> headerValues) where T : class
        {
            if (headerValues != null)
            {
                T result = headerValues.FirstOrDefault();
                if (result != null)
                {
                    return result.ToString().TrimStart();
                }
            }

            return null;
        }

        /// <summary>
        /// Throws an exception if the string is empty or null.
        /// </summary>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <exception cref="ArgumentException">Thrown if value is empty.</exception>
        /// <exception cref="ArgumentNullException">Thrown if value is null.</exception>
        internal static void AssertNotNullOrEmpty(string paramName, string value)
        {
            AssertNotNull(paramName, value);

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(SR.ArgumentEmptyError, paramName);
            }
        }

        /// <summary>
        /// Throw an exception if the value is null.
        /// </summary>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <exception cref="ArgumentNullException">Thrown if value is null.</exception>
        internal static void AssertNotNull(string paramName, object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        /// <summary>
        /// Throw an exception indicating argument is out of range.
        /// </summary>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        internal static void ArgumentOutOfRange(string paramName, object value)
        {
            throw new ArgumentOutOfRangeException(paramName, SR.ArgumentOutOfRangeError);
        }

        /// <summary>
        /// Throw an exception if the argument is out of bounds.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="val">The value of the parameter.</param>
        /// <param name="min">The minimum value for the parameter.</param>
        /// <param name="max">The maximum value for the parameter.</param>
        internal static void AssertInBounds<T>(string paramName, T val, T min, T max)
            where T : IComparable
        {
            if (val.CompareTo(min) < 0)
            {
                throw new ArgumentOutOfRangeException(paramName, string.Format(SR.ArgumentTooSmallError, paramName, min));
            }

            if (val.CompareTo(max) > 0)
            {
                throw new ArgumentOutOfRangeException(paramName, string.Format(SR.ArgumentTooLargeError, paramName, max));
            }
        }

        /// <summary>
        /// Checks that the given timeout in within allowed bounds.
        /// </summary>
        /// <param name="timeout">The timeout to check.</param>
        /// <exception cref="ArgumentOutOfRangeException">The timeout is not within allowed bounds.</exception>
        internal static void CheckTimeoutBounds(TimeSpan timeout)
        {
            CommonUtils.AssertInBounds("Timeout", timeout, TimeSpan.FromSeconds(1), Constants.MaximumAllowedTimeout);
        }

        /// <summary>
        /// Combines AssertNotNullOrEmpty and AssertInBounds for convenience.
        /// </summary>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="canBeNullOrEmpty">Turns on or off null/empty checking.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <param name="maxSize">The maximum size of value.</param>
        internal static void CheckStringParameter(string paramName, bool canBeNullOrEmpty, string value, int maxSize)
        {
            if (!canBeNullOrEmpty)
            {
                AssertNotNullOrEmpty(value, paramName);
            }

            AssertInBounds(value, paramName.Length, 0, maxSize);
        }

        /// <summary>
        /// Rounds up to seconds.
        /// </summary>
        /// <param name="timeSpan">The time span.</param>
        /// <returns>The time rounded to seconds.</returns>
        internal static int RoundUpToSeconds(this TimeSpan timeSpan)
        {
            return (int)Math.Ceiling(timeSpan.TotalSeconds);
        }

        /// <summary>
        /// Determines if a URI requires path style addressing.
        /// </summary>
        /// <param name="uri">The URI to check.</param>
        /// <returns>Returns <c>true</c> if the Uri uses path style addressing; otherwise, <c>false</c>.</returns>
        internal static bool UsePathStyleAddressing(Uri uri)
        {
#if !COMMON
            if (uri.HostNameType != UriHostNameType.Dns)
            {
                return true;
            }

            switch (uri.Port)
            {
                case 10000:
                case 10001:
                case 10002:
                case 10003:
                case 10004:
                    return true;
            }
#endif

            return false;
        }

#if DNCP
        /// <summary>
        /// Applies the request optimizations such as disabling buffering and 100 continue.
        /// </summary>
        /// <param name="request">The request to be modified.</param>
        /// <param name="length">The length of the content, -1 if the content length is not settable.</param>
        internal static void ApplyRequestOptimizations(HttpWebRequest request, long length)
        {
            if (length >= Constants.DefaultBufferSize)
            {
                request.AllowWriteStreamBuffering = false;
            }

            // Set the length of the stream if the value is known
            if (length >= 0)
            {
                request.ContentLength = length;
            }

            // Disable the Expect 100-Continue
            request.ServicePoint.Expect100Continue = false;
        }
#endif
    }
}
