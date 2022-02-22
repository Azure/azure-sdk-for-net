// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class IdentityRecordedTestSanitizer : RecordedTestSanitizer
    {
        public IdentityRecordedTestSanitizer()
        {
            SanitizedHeaders.Add("secret");
            AddJsonPathSanitizer("$..refresh_token");
            AddJsonPathSanitizer("$..access_token");
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"=[^&|}|""]+", "=" + SanitizeValue)
            {
                Condition = new Condition { UriRegex = ".*/token([?].*)?$" }
            });
            HeaderTransforms.Add(new HeaderTransform(
                "WWW-Authenticate",
                $"Basic realm={Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "mock-arc-mi-key.key")}")
            {
                Condition = new Condition
                {
                    ResponseHeader = new HeaderCondition
                    {
                        Key = "WWW-Authenticate",
                        ValueRegex = "Basic realm=.*"
                    }
                }
            });
        }
    }
}
