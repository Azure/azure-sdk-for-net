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

            Assert.That(header.Name, Is.EqualTo("Header"));
            Assert.That(header.Value, Is.EqualTo("Value"));
        }

        [Test]
        public void ComparisonWorks()
        {
            var header = new HttpHeader("Header", "Value");
            var header2 = new HttpHeader("header", "Value");

            Assert.That(header2, Is.EqualTo(header));
            Assert.That(header2.GetHashCode(), Is.EqualTo(header.GetHashCode()));
        }

        [Test]
        public void DateReturnsDateHeaderValue()
        {
            var mockResponse = new MockResponse(200);
            mockResponse.AddHeader(new HttpHeader("Date", "Sun, 29 Sep 2013 01:02:03 GMT"));

            Assert.That(mockResponse.Headers.Date, Is.EqualTo(new DateTimeOffset(2013, 9, 29, 1, 2, 3, TimeSpan.Zero)));
        }

        [Test]
        public void DateReturnsXMsDateHeaderValue()
        {
            var mockResponse = new MockResponse(200);
            mockResponse.AddHeader(new HttpHeader("x-ms-date", "Sun, 29 Sep 2013 01:02:03 GMT"));

            Assert.That(mockResponse.Headers.Date, Is.EqualTo(new DateTimeOffset(2013, 9, 29, 1, 2, 3, TimeSpan.Zero)));
        }

        [Test]
        public void DateReturnsDateHeaderValueFirst()
        {
            var mockResponse = new MockResponse(200);
            mockResponse.AddHeader(new HttpHeader("x-ms-date", "Sun, 29 Sep 2013 01:02:03 GMT"));
            mockResponse.AddHeader(new HttpHeader("Date", "Sun, 29 Sep 2013 09:02:03 GMT"));

            Assert.That(mockResponse.Headers.Date, Is.EqualTo(new DateTimeOffset(2013, 9, 29, 9, 2, 3, TimeSpan.Zero)));
        }

        [Test]
        public void ETagParsedIfExist()
        {
            var mockResponse = new MockResponse(200);
            mockResponse.AddHeader(new HttpHeader("ETag", "\"ABCD\""));

            Assert.That(mockResponse.Headers.ETag, Is.EqualTo(new ETag("ABCD")));
        }

        [Test]
        public void ContentLengthParsedIfExist()
        {
            var mockResponse = new MockResponse(200);
            mockResponse.AddHeader(new HttpHeader("Content-Length", "100"));

            Assert.That(mockResponse.Headers.ContentLength, Is.EqualTo(100));
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
                Assert.That(ex.Message.Contains("Headers.ContentLengthLong"), Is.True);
            }

            Assert.That(threw, Is.True);
        }

        [Test]
        public void ContentLengthLongParsedIfExists()
        {
            long size = int.MaxValue;
            size += 1;

            var bigResponse = new MockResponse(200);
            bigResponse.AddHeader(new HttpHeader("Content-Length", size.ToString()));

            Assert.That(bigResponse.Headers.ContentLengthLong, Is.EqualTo(size));

            var smallResponse = new MockResponse(200);
            smallResponse.AddHeader(new HttpHeader("Content-Length", "100"));

            Assert.That(smallResponse.Headers.ContentLengthLong, Is.EqualTo(100));
        }

        [Test]
        public void DateReturnsNullForNoHeader()
        {
            var mockResponse = new MockResponse(200);
            Assert.That(mockResponse.Headers.Date, Is.Null);
        }

        [Test]
        public void ContentTypeReturnsContentTypeHeaderValue()
        {
            var mockResponse = new MockResponse(200);
            mockResponse.AddHeader(new HttpHeader("Content-Type", "text/xml"));

            Assert.That(mockResponse.Headers.ContentType, Is.EqualTo("text/xml"));
        }

        [Test]
        public void ContentTypeReturnsNullForNoHeader()
        {
            var mockResponse = new MockResponse(200);
            Assert.That(mockResponse.Headers.ContentType, Is.Null);
        }

        [Test]
        public void RequestIdReturnsRequestIdHeaderValue()
        {
            var mockResponse = new MockResponse(200);
            mockResponse.AddHeader(new HttpHeader("x-ms-request-id", "abcde"));

            Assert.That(mockResponse.Headers.RequestId, Is.EqualTo("abcde"));
        }

        [Test]
        public void RequestIdReturnsNullForNoHeader()
        {
            var mockResponse = new MockResponse(200);
            Assert.That(mockResponse.Headers.RequestId, Is.Null);
        }
    }
}
