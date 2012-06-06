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
// <summary>
//    Contains code for the CommonUtils class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Generic;
    using System.Data.Services.Client;
    using System.Diagnostics;
    using System.Globalization;
    using System.Net;
    using System.Text;
    using Protocol;
    using TaskSequence = System.Collections.Generic.IEnumerable<Microsoft.WindowsAzure.StorageClient.Tasks.ITask>;

    /// <summary>
    /// A set of common utilities for use in verfication.
    /// </summary>
    internal static class CommonUtils
    {
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
            throw new ArgumentOutOfRangeException(paramName, value, SR.ArgumentOutOfRangeError);
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
                throw new ArgumentOutOfRangeException(String.Format(SR.ArgumentTooSmallError, paramName, min), paramName);
            }

            if (val.CompareTo(max) > 0)
            {
                throw new ArgumentOutOfRangeException(String.Format(SR.ArgumentTooLargeError, paramName, max), paramName);
            }
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
        /// Throws if the result segment does not have more results.
        /// </summary>
        /// <typeparam name="T">The type of the batch context.</typeparam>
        /// <param name="result">The result segment to check.</param>
        internal static void AssertSegmentResultNotComplete<T>(ResultSegment<T> result)
        {
            if (result != null && result.ContinuationToken == null)
            {
                throw new InvalidOperationException(SR.NoMoreResultsForSegmentCursor);
            }
        }

        /// <summary>
        /// Determines if a Uri requires path style addressing.
        /// </summary>
        /// <param name="uri">The Uri to check.</param>
        /// <returns>Returns <c>true</c> if the Uri uses path style addressing; otherwise, <c>false</c>.</returns>
        internal static bool UsePathStyleAddressing(Uri uri)
        {
            if (uri.HostNameType != UriHostNameType.Dns)
            {
                return true;
            }

            int[] wellKnownDevStorePorts = { 10000, 10001, 10002 };

            foreach (var p in wellKnownDevStorePorts)
            {
                if (uri.Port == p)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Asserts the segment result not empty.
        /// </summary>
        /// <typeparam name="T">The type of the result segment.</typeparam>
        /// <param name="result">The result.</param>
        internal static void AssertSegmentResultNotEmpty<T>(ResultSegment<T> result)
        {
            if (result == null || result.Results == null)
            {
                throw new InvalidOperationException(SR.MustCallEndMoveNextSegmentFirst);
            }
        }

        /// <summary>
        /// Performs a 'magic enumerator' lazy segmented enumeration.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="impl">The task sequence generator that produces the first segment.</param>
        /// <param name="retryPolicy">The retry policy to use.</param>
        /// <returns>A 'magic enumerator' that makes requests when needed and chains segments accordingly.</returns>
        [DebuggerNonUserCode]
        internal static IEnumerable<T> LazyEnumerateSegmented<T>(Func<Action<ResultSegment<T>>, TaskSequence> impl, RetryPolicy retryPolicy)
        {
            var segment = TaskImplHelper.ExecuteImplWithRetry<ResultSegment<T>>(impl, retryPolicy);
            CloudBlobDirectory cloudDirectoryInLastPartition = null;
            T lastElement = default(T);

            while (true)
            {
                foreach (var result in segment.Results)
                {
                    if (cloudDirectoryInLastPartition != null && result is CloudBlobDirectory)
                    {
                        var cloudBlobDirectory = result as CloudBlobDirectory;
                        if (cloudDirectoryInLastPartition.Uri == cloudBlobDirectory.Uri)
                        {
                            continue;
                        }
                    }

                    lastElement = result;
                    yield return result;
                }

                if (!segment.HasMoreResults)
                {
                    break;
                }

                if (lastElement is CloudBlobDirectory)
                {
                    cloudDirectoryInLastPartition = lastElement as CloudBlobDirectory;
                }

                segment = segment.GetNext();
            }
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
        /// Rounds up to seconds.
        /// </summary>
        /// <param name="timeSpan">The time span.</param>
        /// <returns>The time rounded to seconds.</returns>
        internal static int RoundUpToSeconds(this TimeSpan? timeSpan)
        {
            return (int)Math.Ceiling(timeSpan.Value.TotalSeconds);
        }

        /// <summary>
        /// Rounds up to milliseconds.
        /// </summary>
        /// <param name="timeSpan">The time span.</param>
        /// <returns>The time rounded to milliseconds.</returns>
        internal static int RoundUpToMilliseconds(this TimeSpan timeSpan)
        {
            return (int)Math.Ceiling(timeSpan.TotalMilliseconds);
        }

        /// <summary>
        /// Rounds up to milliseconds.
        /// </summary>
        /// <param name="timeSpan">The time span.</param>
        /// <returns>The time rounded to milliseconds.</returns>
        internal static int RoundUpToMilliseconds(this TimeSpan? timeSpan)
        {
            return (int)Math.Ceiling(timeSpan.Value.TotalMilliseconds);
        }

        /// <summary>
        /// When calling the Get() operation on a queue, the content of messages
        /// returned in the REST protocol are represented as Base64-encoded strings.
        /// This internal function transforms the Base64 representation into a byte array.
        /// </summary>
        /// <param name="str">The Base64-encoded string.</param>
        /// <returns>The decoded bytes.</returns>
        internal static byte[] GetContentFromBase64String(string str)
        {
            byte[] base64Content;

            if (string.IsNullOrEmpty(str))
            {
                // we got a message with an empty <MessageText> element
                base64Content = Encoding.UTF8.GetBytes(string.Empty);
            }
            else
            {
                base64Content = Convert.FromBase64String(str);
            }

            return base64Content;
        }

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

        /// <summary>
        /// Look for an inner exception of type DataServiceClientException. Different versions of Sytem.Data.Services.Client
        /// have different levels of wrapping of a DataServiceClientException.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns>The found exception or null.</returns>
        internal static DataServiceClientException FindInnerDataServiceClientException(Exception exception)
        {
            DataServiceClientException dsce = null;

            while (exception != null)
            {
                dsce = exception as DataServiceClientException;

                if (dsce != null)
                {
                    break;
                }

                exception = exception.InnerException;
            }

            return dsce;
        }

        /// <summary>
        /// Asserts the type of the continuation.
        /// </summary>
        /// <param name="continuationToken">The continuation token.</param>
        /// <param name="continuationType">Type of the continuation.</param>
        internal static void AssertContinuationType(ResultContinuation continuationToken, ResultContinuation.ContinuationType continuationType)
        {
            if (continuationToken != null)
            {
                if (!(continuationToken.Type == ResultContinuation.ContinuationType.None || continuationToken.Type == continuationType))
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture, SR.InvalidContinuationType, continuationToken.Type, continuationType);
                    throw new InvalidOperationException(errorMessage);
                }
            }
        }
    }
}
