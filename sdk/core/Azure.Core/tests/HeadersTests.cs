// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Text;
using System.Text.RegularExpressions;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HeadersTests
    {
        [Test]
        public void ConstructorWorks()
        {
            var header = new HttpHeader("Header", "Value");

            Assert.AreEqual("Header", header.Name);
            Assert.AreEqual("Value", header.Value);
        }

        [Test]
        public void ComparisonWorks()
        {
            var header = new HttpHeader("Header", "Value");
            var header2 = new HttpHeader("header", "Value");

            Assert.AreEqual(header, header2);
            Assert.AreEqual(header.GetHashCode(), header2.GetHashCode());
        }

        [Test]
        public void DateReturnsDateHeaderValue()
        {
            var mockResponse = new MockResponse(200);
            mockResponse.AddHeader(new HttpHeader("Date", "Sun, 29 Sep 2013 01:02:03 GMT"));

            Assert.AreEqual(new DateTimeOffset(2013, 9, 29, 1, 2, 3, TimeSpan.Zero), mockResponse.Headers.Date);
        }

        [Test]
        public void DateReturnsXMsDateHeaderValue()
        {
            var mockResponse = new MockResponse(200);
            mockResponse.AddHeader(new HttpHeader("x-ms-date", "Sun, 29 Sep 2013 01:02:03 GMT"));

            Assert.AreEqual(new DateTimeOffset(2013, 9, 29, 1, 2, 3, TimeSpan.Zero), mockResponse.Headers.Date);
        }

        [Test]
        public void DateReturnsDateHeaderValueFirst()
        {
            var mockResponse = new MockResponse(200);
            mockResponse.AddHeader(new HttpHeader("x-ms-date", "Sun, 29 Sep 2013 01:02:03 GMT"));
            mockResponse.AddHeader(new HttpHeader("Date", "Sun, 29 Sep 2013 09:02:03 GMT"));

            Assert.AreEqual(new DateTimeOffset(2013, 9, 29, 9, 2, 3, TimeSpan.Zero), mockResponse.Headers.Date);
        }

        [Test]
        public void ETagParsedIfExist()
        {
            var mockResponse = new MockResponse(200);
            mockResponse.AddHeader(new HttpHeader("ETag", "\"ABCD\""));

            Assert.AreEqual(new ETag("ABCD"), mockResponse.Headers.ETag);
        }

        [Test]
        public void ContentLengthParsedIfExist()
        {
            var mockResponse = new MockResponse(200);
            mockResponse.AddHeader(new HttpHeader("Content-Length", "100"));

            Assert.AreEqual(100, mockResponse.Headers.ContentLength);
        }

        [Test]
        public void ContentLengthThrowsIfExceedsMaxInt()
        {
            long size = int.MaxValue;
            size += 1;

            var mockResponse = new MockResponse(200);
            mockResponse.AddHeader(new HttpHeader("Content-Length", size.ToString()));

            bool threw = false;
            try
            {
                _ = mockResponse.Headers.ContentLength;
            }
            catch (OverflowException ex)
            {
                threw = true;
                Assert.IsTrue(ex.Message.Contains("Headers.ContentLengthLong"));
            }

            Assert.IsTrue(threw);
        }

        [Test]
        public void ContentLengthLongParsedIfExists()
        {
            long size = int.MaxValue;
            size += 1;

            var bigResponse = new MockResponse(200);
            bigResponse.AddHeader(new HttpHeader("Content-Length", size.ToString()));

            Assert.AreEqual(size, bigResponse.Headers.ContentLengthLong);

            var smallResponse = new MockResponse(200);
            smallResponse.AddHeader(new HttpHeader("Content-Length", "100"));

            Assert.AreEqual(100, smallResponse.Headers.ContentLengthLong);
        }

        [Test]
        public void DateReturnsNullForNoHeader()
        {
            var mockResponse = new MockResponse(200);
            Assert.Null(mockResponse.Headers.Date);
        }

        [Test]
        public void ContentTypeReturnsContentTypeHeaderValue()
        {
            var mockResponse = new MockResponse(200);
            mockResponse.AddHeader(new HttpHeader("Content-Type", "text/xml"));

            Assert.AreEqual("text/xml", mockResponse.Headers.ContentType);
        }

        [Test]
        public void ContentTypeReturnsNullForNoHeader()
        {
            var mockResponse = new MockResponse(200);
            Assert.Null(mockResponse.Headers.ContentType);
        }

        [Test]
        public void RequestIdReturnsRequestIdHeaderValue()
        {
            var mockResponse = new MockResponse(200);
            mockResponse.AddHeader(new HttpHeader("x-ms-request-id", "abcde"));

            Assert.AreEqual("abcde", mockResponse.Headers.RequestId);
        }

        [Test]
        public void RequestIdReturnsNullForNoHeader()
        {
            var mockResponse = new MockResponse(200);
            Assert.Null(mockResponse.Headers.RequestId);
        }
    }
}
