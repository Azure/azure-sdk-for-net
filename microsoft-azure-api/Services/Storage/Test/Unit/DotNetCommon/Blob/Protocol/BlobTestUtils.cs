// -----------------------------------------------------------------------------------------
// <copyright file="BlobTestUtils.cs" company="Microsoft">
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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;

namespace Microsoft.WindowsAzure.Storage.Blob.Protocol
{
    internal class BlobTestUtils
    {
        #region Request Validation

        public static void DateHeader(HttpWebRequest request, bool required)
        {
            bool standardHeader = request.Headers[HttpRequestHeader.Date] != null;
            bool msHeader = request.Headers["x-ms-date"] != null;

            Assert.IsFalse(standardHeader && msHeader);
            Assert.IsFalse(required && !(standardHeader ^ msHeader));

            if (request.Headers[HttpRequestHeader.Date] != null)
            {
                try
                {
                    DateTime parsed = DateTime.Parse(request.Headers[HttpRequestHeader.Date]).ToUniversalTime();
                }
                catch (Exception)
                {
                    Assert.Fail();
                }
            }
            else if (request.Headers[HttpRequestHeader.Date] != null)
            {
                try
                {
                    DateTime parsed = DateTime.Parse(request.Headers["x-ms-date"]).ToUniversalTime();
                }
                catch (Exception)
                {
                    Assert.Fail();
                }
            }
        }

        public static void VersionHeader(HttpWebRequest request, bool required)
        {
            Assert.IsFalse(required && (request.Headers["x-ms-version"] == null));
            if (request.Headers["x-ms-version"] != null)
            {
                Assert.AreEqual("2012-02-12", request.Headers["x-ms-version"]);
            }
        }

        public static void ContentLengthHeader(HttpWebRequest request, long expectedValue)
        {
            Assert.AreEqual(expectedValue, request.ContentLength);
        }

        public static void ContentTypeHeader(HttpWebRequest request, string expectedValue)
        {
            Assert.IsFalse((expectedValue != null) && (request.ContentType == null));
            if (request.ContentType != null)
            {
                Assert.AreEqual(expectedValue, request.ContentType);
            }
        }

        public static void ContentEncodingHeader(HttpWebRequest request, string expectedValue)
        {
            Assert.IsFalse((expectedValue != null) && (request.Headers[HttpRequestHeader.ContentEncoding] == null));
            if (request.Headers[HttpRequestHeader.ContentEncoding] != null)
            {
                Assert.AreEqual(expectedValue, request.Headers[HttpRequestHeader.ContentEncoding]);
            }
        }

        public static void ContentLanguageHeader(HttpWebRequest request, string expectedValue)
        {
            Assert.IsFalse((expectedValue != null) && (request.Headers[HttpRequestHeader.ContentLanguage] == null));
            if (request.Headers[HttpRequestHeader.ContentLanguage] != null)
            {
                Assert.AreEqual(expectedValue, request.Headers[HttpRequestHeader.ContentLanguage]);
            }
        }

        public static void ContentMd5Header(HttpWebRequest request, string expectedValue)
        {
            Assert.IsFalse((expectedValue != null) && (request.Headers[HttpRequestHeader.ContentMd5] == null));
            if (request.Headers[HttpRequestHeader.ContentMd5] != null)
            {
                Assert.AreEqual(expectedValue, request.Headers[HttpRequestHeader.ContentMd5]);
            }
        }

        public static void CacheControlHeader(HttpWebRequest request, string expectedValue)
        {
            Assert.IsFalse((expectedValue != null) && (request.Headers[HttpRequestHeader.CacheControl] == null));
            if (request.Headers[HttpRequestHeader.CacheControl] != null)
            {
                Assert.AreEqual(expectedValue, request.Headers[HttpRequestHeader.CacheControl]);
            }
        }

        public static void BlobTypeHeader(HttpWebRequest request, BlobType? expectedValue)
        {
            Assert.IsFalse((expectedValue != null) && (request.Headers["x-ms-blob-type"] == null));
            if (request.Headers["x-ms-blob-type"] != null)
            {
                string blobTypeString = request.Headers["x-ms-blob-type"];
                Assert.IsNotNull(blobTypeString);
                BlobType? blobType = null;
                switch (blobTypeString)
                {
                    case "PageBlob":
                        blobType = BlobType.PageBlob;
                        break;
                    case "BlockBlob":
                        blobType = BlobType.BlockBlob;
                        break;
                }

                Assert.AreEqual(expectedValue, blobType);
            }
        }

        public static void BlobSizeHeader(HttpWebRequest request, long? expectedValue)
        {
            Assert.IsFalse((expectedValue != null) && (request.Headers["x-ms-blob-content-length"] == null));
            if (request.Headers["x-ms-blob-content-length"] != null)
            {
                long? parsed = long.Parse(request.Headers["x-ms-blob-content-length"]);
                Assert.IsNotNull(parsed);
                Assert.AreEqual(expectedValue, parsed);
            }
        }

        /// <summary>
        /// Tests for a range header in an HTTP request, where no end range is expected.
        /// </summary>
        /// <param name="request">The HTTP request.</param>
        /// <param name="expectedStart">The expected beginning of the range, or null if no range is expected.</param>
        public static void RangeHeader(HttpWebRequest request, long? expectedStart)
        {
            RangeHeader(request, expectedStart, null);
        }

        /// <summary>
        /// Tests for a range header in an HTTP request.
        /// </summary>
        /// <param name="request">The HTTP request.</param>
        /// <param name="expectedStart">The expected beginning of the range, or null if no range is expected.</param>
        /// <param name="expectedEnd">The expected end of the range, or null if no end is expected.</param>
        public static void RangeHeader(HttpWebRequest request, long? expectedStart, long? expectedEnd)
        {
            // The range in "x-ms-range" is used if it exists, or else "Range" is used.
            string requestRange = request.Headers["x-ms-range"] ?? request.Headers[HttpRequestHeader.Range];

            // We should find a range if and only if we expect one.
            Assert.AreEqual(expectedStart.HasValue, requestRange != null);

            // If we expect a range, the range we find should be identical.
            if (expectedStart.HasValue)
            {
                string rangeStart = expectedStart.Value.ToString();
                string rangeEnd = expectedEnd.HasValue ? expectedEnd.Value.ToString() : string.Empty;
                string expectedValue = string.Format("bytes={0}-{1}", rangeStart, rangeEnd);
                Assert.AreEqual(expectedValue.ToString(), requestRange);
            }
        }

        public static void SetRequest(HttpWebRequest request, BlobContext context, byte[] content)
        {
            Assert.IsNotNull(request);
            if (context.IsAsync)
            {
                BlobTestUtils.SetRequestAsync(request, context, content);
            }
            else
            {
                BlobTestUtils.SetRequestSync(request, context, content);
            }
        }

        static AutoResetEvent setRequestAsyncSem = new AutoResetEvent(false);
        static Stream setRequestAsyncStream;
        static void SetRequestAsync(HttpWebRequest request, BlobContext context, byte[] content)
        {
            request.BeginGetRequestStream(new AsyncCallback(BlobTestUtils.ReadCallback), request);
            setRequestAsyncSem.WaitOne();
            Assert.IsNotNull(setRequestAsyncStream);
            setRequestAsyncStream.Write(content, 0, content.Length);
            setRequestAsyncStream.Close();
        }

        static void ReadCallback(IAsyncResult result)
        {
            HttpWebRequest request = (HttpWebRequest)result.AsyncState;
            setRequestAsyncStream = request.EndGetRequestStream(result);
            setRequestAsyncSem.Set();
        }

        static void SetRequestSync(HttpWebRequest request, BlobContext context, byte[] content)
        {
            Stream stream = request.GetRequestStream();
            Assert.IsNotNull(stream);
            stream.Write(content, 0, content.Length);
            stream.Close();
        }

        #endregion

        #region Response Validation

        /// <summary>
        /// Tests for a content range header in an HTTP response.
        /// </summary>
        /// <param name="response">The HTTP response.</param>
        /// <param name="expectedStart">The expected beginning of the range.</param>
        /// <param name="expectedEnd">The expected end of the range.</param>
        /// <param name="expectedTotal">The expected total number of bytes in the range.</param>
        public static void ContentRangeHeader(HttpWebResponse response, long expectedStart, long expectedEnd, long expectedTotal)
        {
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Headers[HttpResponseHeader.ContentRange]);
            string expectedRange = string.Format("bytes {0}-{1}/{2}", expectedStart, expectedEnd, expectedTotal);
            Assert.AreEqual(expectedRange, response.Headers[HttpResponseHeader.ContentRange]);
        }

        /// <summary>
        /// Validates a lease ID header in a request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="expectedValue">The expected value.</param>
        public static void LeaseIdHeader(HttpWebRequest request, string expectedValue)
        {
            Assert.IsFalse((expectedValue != null) && (request.Headers["x-ms-lease-id"] == null));
            if (request.Headers["x-ms-lease-id"] != null)
            {
                Assert.AreEqual(expectedValue, request.Headers["x-ms-lease-id"]);
            }
        }

        /// <summary>
        /// Validates a lease action header in a request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="expectedValue">The expected value.</param>
        public static void LeaseActionHeader(HttpWebRequest request, string expectedValue)
        {
            Assert.IsFalse((expectedValue != null) && (request.Headers["x-ms-lease-action"] == null));
            if (request.Headers["x-ms-lease-action"] != null)
            {
                Assert.AreEqual(expectedValue, request.Headers["x-ms-lease-action"]);
            }
        }

        /// <summary>
        /// Validates a proposed lease ID header in a request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="expectedValue">The expected value.</param>
        public static void ProposedLeaseIdHeader(HttpWebRequest request, string expectedValue)
        {
            Assert.IsFalse((expectedValue != null) && (request.Headers["x-ms-proposed-lease-id"] == null));
            if (request.Headers["x-ms-proposed-lease-id"] != null)
            {
                Assert.AreEqual(expectedValue, request.Headers["x-ms-proposed-lease-id"]);
            }
        }

        /// <summary>
        /// Validates a lease duration header in a request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="expectedValue">The expected value.</param>
        public static void LeaseDurationHeader(HttpWebRequest request, string expectedValue)
        {
            Assert.IsFalse((expectedValue != null) && (request.Headers["x-ms-lease-duration"] == null));
            if (request.Headers["x-ms-lease-duration"] != null)
            {
                Assert.AreEqual(expectedValue, request.Headers["x-ms-lease-duration"]);
            }
        }

        /// <summary>
        /// Validates a break period header in a request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="expectedValue">The expected value.</param>
        public static void BreakPeriodHeader(HttpWebRequest request, string expectedValue)
        {
            Assert.IsFalse((expectedValue != null) && (request.Headers["x-ms-lease-break-period"] == null));
            if (request.Headers["x-ms-lease-break-period"] != null)
            {
                Assert.AreEqual(expectedValue, request.Headers["x-ms-lease-break-period"]);
            }
        }

        public static void AuthorizationHeader(HttpWebRequest request, bool required, string account)
        {
            Assert.IsFalse(required && (request.Headers[HttpRequestHeader.Authorization] == null));
            if (request.Headers[HttpRequestHeader.Authorization] != null)
            {
                string authorization = request.Headers[HttpRequestHeader.Authorization];
                string pattern = String.Format("^(SharedKey|SharedKeyLite) {0}:[0-9a-zA-Z\\+/=]{{20,}}$", account);
                Regex authorizationRegex = new Regex(pattern);
                Assert.IsTrue(authorizationRegex.IsMatch(authorization));
            }
        }

        public static void ETagHeader(HttpWebResponse response)
        {
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Headers[HttpResponseHeader.ETag]);
            Regex eTagRegex = new Regex(@"^""0x[A-F0-9]{15,}""$");
            Assert.IsTrue(eTagRegex.IsMatch(response.Headers[HttpResponseHeader.ETag]));
        }

        public static void LastModifiedHeader(HttpWebResponse response)
        {
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Headers[HttpResponseHeader.LastModified]);
            try
            {
                DateTime parsed = DateTime.Parse(response.Headers[HttpResponseHeader.LastModified]).ToUniversalTime();
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        public static void ContentMd5Header(HttpWebResponse response)
        {
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Headers[HttpResponseHeader.ContentMd5]);
        }

        public static void RequestIdHeader(HttpWebResponse response)
        {
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Headers["x-ms-request-id"]);
        }

        public static void ContentLengthHeader(HttpWebResponse response, long expectedValue)
        {
            Assert.IsNotNull(response);
            Assert.AreEqual(expectedValue, response.ContentLength);
        }

        public static void ContentTypeHeader(HttpWebResponse response, string expectedValue)
        {
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.ContentType);
            Assert.AreEqual(expectedValue, response.ContentType);
        }

        public static void ContentRangeHeader(HttpWebResponse response, PageRange expectedValue)
        {
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Headers[HttpResponseHeader.ContentRange]);
            Assert.AreEqual(expectedValue.ToString(), response.Headers[HttpResponseHeader.ContentRange]);
        }

        public static void ContentEncodingHeader(HttpWebResponse response, string expectedValue)
        {
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.ContentEncoding);
            Assert.AreEqual(expectedValue, response.ContentEncoding);
        }

        public static void ContentLanguageHeader(HttpWebResponse response, string expectedValue)
        {
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Headers[HttpResponseHeader.ContentLanguage]);
            Assert.AreEqual(expectedValue, response.Headers[HttpResponseHeader.ContentLanguage]);
        }

        public static void CacheControlHeader(HttpWebResponse response, string expectedValue)
        {
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Headers[HttpResponseHeader.CacheControl]);
            Assert.AreEqual(expectedValue, response.Headers[HttpResponseHeader.CacheControl]);
        }

        public static void BlobTypeHeader(HttpWebResponse response, BlobType expectedValue)
        {
            Assert.IsNotNull(response);
            string header = response.Headers["x-ms-blob-type"];
            BlobType? parsed = null;
            switch (header)
            {
                case "BlockBlob":
                    parsed = BlobType.BlockBlob;
                    break;
                case "PageBlob":
                    parsed = BlobType.PageBlob;
                    break;
            }
            Assert.IsNotNull(parsed);
            Assert.AreEqual(expectedValue, parsed);
        }

        /// <summary>
        /// Validates a lease time header in a response.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="expectedValue">The expected value.</param>
        /// <param name="errorMargin">The margin of error in the value.</param>
        public static void LeaseTimeHeader(HttpWebResponse response, int? expectedValue, int? errorMargin)
        {
            int? leaseTime = BlobHttpResponseParsers.GetRemainingLeaseTime(response);
            Assert.IsFalse((expectedValue != null) && (leaseTime == null));
            if (leaseTime != null)
            {
                int error = Math.Abs(expectedValue.Value - leaseTime.Value);
                Assert.IsTrue(error < errorMargin, "Lease Time header is not within expected range.");
            }
        }

        /// <summary>
        /// Validates a lease ID header in a response.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="expectedValue">The expected value.</param>
        public static void LeaseIdHeader(HttpWebResponse response, string expectedValue)
        {
            string leaseId = BlobHttpResponseParsers.GetLeaseId(response);
            Assert.IsFalse((expectedValue != null) && (leaseId == null));
            if (leaseId != null)
            {
                LeaseIdHeader(response);
                Assert.AreEqual(expectedValue, leaseId);
            }
        }

        /// <summary>
        /// Validates a lease ID header in a response.
        /// </summary>
        /// <param name="response">The response.</param>
        public static void LeaseIdHeader(HttpWebResponse response)
        {
            string leaseId = BlobHttpResponseParsers.GetLeaseId(response);
            Assert.IsNotNull(leaseId);
            Assert.IsTrue(BlobTests.LeaseIdValidator(AccessCondition.GenerateLeaseCondition(leaseId)));
        }

        public static void Contents(HttpWebResponse response, byte[] expectedContent)
        {
            Assert.IsNotNull(response);
            Assert.IsTrue(response.ContentLength >= 0);
            byte[] buf = new byte[response.ContentLength];
            Stream stream = response.GetResponseStream();
            // Have to read one byte each time because of an issue of this stream.
            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] = (byte)(stream.ReadByte());
            }
            stream.Close();
            Assert.IsTrue(buf.SequenceEqual(expectedContent));
        }

        #endregion

        #region Helpers

        public static HttpWebResponse GetResponse(HttpWebRequest request, BlobContext context)
        {
            Assert.IsNotNull(request);
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                response = (HttpWebResponse)ex.Response;
            }
            Assert.IsNotNull(response);
            return response;
        }

        public static bool ContentValidator(byte[] content)
        {
            return content != null;
        }

        #endregion
    }
}
