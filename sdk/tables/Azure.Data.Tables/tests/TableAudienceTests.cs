// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.Collections.Generic;

namespace Azure.Data.Tables.Tests
{
    public class TableAudienceTests
    {
        // This test validates that the token audience scope is correctly parsed
        [TestCaseSource(nameof(GetDefaultScopeTestCases))]
        public void TestGetDefaultScope(
            TableAudience? audience,
            bool isCosmosEndpoint,
            string expectedScope)
        {
            audience ??= TableAudience.AzurePublicCloud;
            var defaultScope = audience.Value.GetDefaultScope(isCosmosEndpoint);
            Assert.AreEqual(expectedScope, defaultScope);
        }

        public static IEnumerable<TestCaseData> GetDefaultScopeTestCases
        {
            get
            {
                // cosmos audience
                yield return new TestCaseData(TableAudience.AzurePublicCloud, true, "https://cosmos.azure.com/.default");
                yield return new TestCaseData(TableAudience.AzureChina, true, "https://cosmos.azure.cn/.default");
                yield return new TestCaseData(TableAudience.AzureGovernment, true, "https://cosmos.azure.us/.default");
                // storage audience
                yield return new TestCaseData(TableAudience.AzurePublicCloud, false, "https://storage.azure.com/.default");
                yield return new TestCaseData(TableAudience.AzureChina, false, "https://storage.azure.cn/.default");
                yield return new TestCaseData(TableAudience.AzureGovernment, false, "https://storage.azure.us/.default");
                // default audience with cosmos endpoint should be public cloud
                yield return new TestCaseData(null, true, "https://cosmos.azure.com/.default");
                // default audience with storage endpoint should be public cloud
                yield return new TestCaseData(null, false, "https://storage.azure.com/.default");
                // custom audience
                yield return new TestCaseData(new TableAudience("my.custom.audience"), false, "my.custom.audience/.default");
                yield return new TestCaseData(new TableAudience("my.custom.audience/"), false, "my.custom.audience/.default");
                yield return new TestCaseData(new TableAudience("my.custom.audience/.default"), false, "my.custom.audience/.default");
            }
        }
    }
}
