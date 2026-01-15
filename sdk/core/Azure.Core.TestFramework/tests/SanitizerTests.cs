// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class SanitizerTests
    {
        [Test]
        public void CanSanitizeQueryParamsInHeader()
        {
            var sanitizer = HeaderRegexSanitizer.CreateWithQueryParameter("headerKey", "queryParameter", "value");
            Assert.That(sanitizer.Key, Is.EqualTo("headerKey"));
            Assert.That(sanitizer.Regex, Is.EqualTo(@"([\x0026|&|?]queryParameter=)(?<group>[^&]+)"));
        }

        [Test]
        public void CanSanitizeQueryParamsInUri()
        {
            var sanitizer = UriRegexSanitizer.CreateWithQueryParameter("queryParameter", "value");
            Assert.That(sanitizer.Regex, Is.EqualTo(@"([\x0026|&|?]queryParameter=)(?<group>[^&]+)"));
        }
    }
}
