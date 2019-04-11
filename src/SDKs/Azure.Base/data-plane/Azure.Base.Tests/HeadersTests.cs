// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Text;
using System.Text.RegularExpressions;
using Azure.Base.Pipeline;
using NUnit.Framework;

namespace Azure.Base.Tests
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
        public void UserAgentHeaderBasics()
        {
            var userAgent = HttpHeader.Common.CreateUserAgent("sdk_name", "sdk_version", "application_id").ToString();

            var isValidFormat = Regex.IsMatch(userAgent, @"^User-Agent:application_id azsdk-net-sdk_name/sdk_version \(.*;.*\)", RegexOptions.IgnoreCase);
            Assert.True(isValidFormat);

            var userAgentWithApplication = HttpHeader.Common.CreateUserAgent("sdk_name", "sdk_version").ToString();

            isValidFormat = Regex.IsMatch(userAgentWithApplication, @"^User-Agent:azsdk-net-sdk_name/sdk_version \(.*;.*\)", RegexOptions.IgnoreCase);
            Assert.True(isValidFormat);
        }
    }

    static class Utf8
    {
        public static string ToString(ReadOnlySpan<byte> utf8)
            => Encoding.UTF8.GetString(utf8.ToArray());
    }
}
