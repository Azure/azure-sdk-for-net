//-----------------------------------------------------------------------
// <copyright file="CommonUtility.cs" company="Microsoft">
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
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Xml;

#if WINDOWS_DESKTOP
    using System.Net;
#endif

    internal static class CommonUtility
    {
        /// <summary>
        /// Create an ExecutionState object that can be used for pre-request operations
        /// such as buffering user's data.
        /// </summary>
        /// <param name="options">Request options</param>
        /// <returns>Temporary ExecutionState object</returns>
        internal static ExecutionState<NullType> CreateTemporaryExecutionState(BlobRequestOptions options)
        {
            RESTCommand<NullType> cmdWithTimeout = new RESTCommand<NullType>(new StorageCredentials(), null /* Uri */);
            if (options != null)
            {
                cmdWithTimeout.ApplyRequestOptions(options);
            }

            return new ExecutionState<NullType>(cmdWithTimeout, options.RetryPolicy, new OperationContext());
        }

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
            throw new ArgumentOutOfRangeException(paramName, string.Format(CultureInfo.InvariantCulture, SR.ArgumentOutOfRangeError, value));
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
                throw new ArgumentOutOfRangeException(paramName, string.Format(CultureInfo.InvariantCulture, SR.ArgumentTooSmallError, paramName, min));
            }

            if (val.CompareTo(max) > 0)
            {
                throw new ArgumentOutOfRangeException(paramName, string.Format(CultureInfo.InvariantCulture, SR.ArgumentTooLargeError, paramName, max));
            }
        }

        /// <summary>
        /// Throw an exception if the argument is out of bounds.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="val">The value of the parameter.</param>
        /// <param name="min">The minimum value for the parameter.</param>
        internal static void AssertInBounds<T>(string paramName, T val, T min)
            where T : IComparable
        {
            if (val.CompareTo(min) < 0)
            {
                throw new ArgumentOutOfRangeException(paramName, string.Format(CultureInfo.InvariantCulture, SR.ArgumentTooSmallError, paramName, min));
            }
        }

        /// <summary>
        /// Checks that the given timeout in within allowed bounds.
        /// </summary>
        /// <param name="timeout">The timeout to check.</param>
        /// <exception cref="ArgumentOutOfRangeException">The timeout is not within allowed bounds.</exception>
        internal static void CheckTimeoutBounds(TimeSpan timeout)
        {
            CommonUtility.AssertInBounds("Timeout", timeout, TimeSpan.FromSeconds(1), Constants.MaximumAllowedTimeout);
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

            return false;
        }

        /// <summary>
        /// Read the value of an element in the XML.
        /// </summary>
        /// <param name="elementName">The name of the element whose value is retrieved.</param>
        /// <param name="reader">A reader that provides access to XML data.</param>
        /// <returns>A string representation of the element's value.</returns>
        internal static string ReadElementAsString(string elementName, XmlReader reader)
        {
            string res = null;

            if (reader.IsStartElement(elementName))
            {
                if (reader.IsEmptyElement)
                {
                    reader.Skip();
                }
                else
                {
                    res = reader.ReadElementContentAsString();
                }
            }
            else
            {
                throw new XmlException(elementName);
            }

            reader.MoveToContent();

            return res;
        }

        /// <summary>
        /// Returns an enumerable collection of results that is retrieved lazily.
        /// </summary>
        /// <typeparam name="T">The type of ResultSegment like Blob, Container, Queue and Table.</typeparam>
        /// <param name="segmentGenerator">The segment generator.</param>
        /// <param name="maxResults">>A non-negative integer value that indicates the maximum number of results to be returned 
        /// in the result segment, up to the per-operation limit of 5000.</param>
        /// <returns></returns>
        internal static IEnumerable<T> LazyEnumerable<T>(Func<IContinuationToken, ResultSegment<T>> segmentGenerator, long maxResults)
        {
            ResultSegment<T> currentSeg = segmentGenerator(null);
            long count = 0;
            while (true)
            {
                foreach (T result in currentSeg.Results)
                {
                    yield return result;
                    count++;
                    if (count >= maxResults)
                    {
                        break;
                    }
                }

                if (count >= maxResults)
                {
                    break;
                }

                if (currentSeg.ContinuationToken != null)
                {
                    currentSeg = segmentGenerator(currentSeg.ContinuationToken);
                }
                else
                {
                    break;
                }
            }
        }

#if WINDOWS_DESKTOP
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

#if !WINDOWS_PHONE
            // Disable the Expect 100-Continue
            request.ServicePoint.Expect100Continue = false;
#endif
        }
#endif
    }
}
