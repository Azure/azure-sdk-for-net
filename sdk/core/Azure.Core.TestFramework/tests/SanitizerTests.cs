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
            Assert.AreEqual("headerKey", sanitizer.Key);
            Assert.AreEqual(@"([\x0026|&|?]queryParameter=)(?<group>[^&]+)", sanitizer.Regex);
        }

        [Test]
        public void CanSanitizeQueryParamsInUri()
        {
            var sanitizer = UriRegexSanitizer.CreateWithQueryParameter("queryParameter", "value");
            Assert.AreEqual(@"([\x0026|&|?]queryParameter=)(?<group>[^&]+)", sanitizer.Regex);
        }
    }
}
