// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Text;
using System.Text.RegularExpressions;
using Azure.Core.Http;
using NUnit.Framework;
using static System.Buffers.Text.Encodings;

namespace Azure.Core.Tests
{
    public class HeadersTests
    {
        [Test]
        public void Basics()
        {
            var utf16Name = "XnameX";
            var utf16Value = "YvalueY";
            var utf16Text = $"{utf16Name}:{utf16Value}";

            byte[] utf8Name = Encoding.ASCII.GetBytes(utf16Name);
            byte[] utf8Value = Encoding.ASCII.GetBytes(utf16Value);

            var mixedHeader = new HttpHeader(utf8Name, utf16Value);
            Assert.AreEqual(utf16Text, mixedHeader.ToString());
            Assert.AreEqual(utf16Name, Utf8.ToString(mixedHeader.Name));
            Assert.AreEqual(utf16Value, Utf8.ToString(mixedHeader.Value));

            var utf16Header = new HttpHeader(utf16Name, utf16Value);
            Assert.AreEqual(utf16Text, utf16Header.ToString());
            Assert.AreEqual(utf16Name, Utf8.ToString(utf16Header.Name));
            Assert.AreEqual(utf16Value, Utf8.ToString(utf16Header.Value));

            var utf8Header = new HttpHeader(utf8Name, utf8Value);
            Assert.AreEqual(utf16Text, utf8Header.ToString());       
            Assert.AreEqual(utf16Name, Utf8.ToString(utf8Header.Name));
            Assert.AreEqual(utf16Value, Utf8.ToString(utf8Header.Value));
        }

        [Test]
        public void UserAgentHeaderBasics()
        {
            var userAgent = HttpHeader.Common.CreateUserAgent("sdk_name", "sdk_version", "application_id").ToString();

            var isValidFormat = Regex.IsMatch(userAgent, @"^User-Agent:application_id sdk_name/sdk_version \(.*;.*\)", RegexOptions.IgnoreCase);
            Assert.True(isValidFormat);

            var userAgentWithApplication = HttpHeader.Common.CreateUserAgent("sdk_name", "sdk_version").ToString();

            isValidFormat = Regex.IsMatch(userAgentWithApplication, @"^User-Agent:sdk_name/sdk_version \(.*;.*\)", RegexOptions.IgnoreCase);
            Assert.True(isValidFormat);
        }
    }

}
