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
            var sanitizer = new RecordedTestSanitizer();
            sanitizer.SanitizedQueryParametersInHeaders.Add(("headerKey", "queryParameter"));
            HeaderRegexSanitizer headerSanitizer = sanitizer.HeaderRegexSanitizers.First();
            Assert.AreEqual("headerKey", headerSanitizer.Key);
            Assert.AreEqual(@"([\x0026|&|?]queryParameter=)(?<group>[\w\d%]+)", headerSanitizer.Regex);
        }

        [Test]
        public void CanSanitizeQueryParamsInUri()
        {
            var sanitizer = new RecordedTestSanitizer();
            sanitizer.SanitizedQueryParameters.Add("queryParameter");
            UriRegexSanitizer uriSanitizer = sanitizer.UriRegexSanitizers.First();
            Assert.AreEqual(@"([\x0026|&|?]queryParameter=)(?<group>[\w\d%]+)", uriSanitizer.Regex);
        }
    }
}
