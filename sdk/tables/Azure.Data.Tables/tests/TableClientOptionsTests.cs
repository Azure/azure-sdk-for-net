// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.Collections.Generic;

namespace Azure.Data.Tables.Tests
{
    public class TableClientOptionsTests
    {
        // This test validates that the token audience scope is correctly parsed
        [TestCaseSource(nameof(GetDefaultScopeTestCases))]
        public void TestGetDefaultScope(
            TableAudience? audience,
            bool isCosmosEndpoint,
            string expectedScope)
        {
            var options = new TableClientOptions
            {
                Audience = audience
            };
            var defaultScope = options.GetDefaultScope(isCosmosEndpoint);
            Assert.AreEqual(expectedScope, defaultScope);
        }

        public static IEnumerable<TestCaseData> GetDefaultScopeTestCases
        {
            get
            {
                // cosmos audience
                yield return new TestCaseData(TableAudience.AzureCosmosPublicCloud, true, $"{TableAudience.AzureCosmosPublicCloud}/.default");
                yield return new TestCaseData(TableAudience.AzureCosmosChina, true, $"{TableAudience.AzureCosmosChina}/.default");
                yield return new TestCaseData(TableAudience.AzureCosmosGovernment, true, $"{TableAudience.AzureCosmosGovernment}/.default");
                // storage audience
                yield return new TestCaseData(TableAudience.AzureStoragePublicCloud, false, $"{TableAudience.AzureStoragePublicCloud}/.default");
                yield return new TestCaseData(TableAudience.AzureStorageChina, false, $"{TableAudience.AzureStorageChina}/.default");
                yield return new TestCaseData(TableAudience.AzureStorageGovernment, false, $"{TableAudience.AzureStorageGovernment}/.default");
                // default audience with cosmos endpoint should be public cloud
                yield return new TestCaseData(null, true, $"{TableAudience.AzureCosmosPublicCloud}/.default");
                // default audience with storage endpoint should be public cloud
                yield return new TestCaseData(null, false, $"{TableAudience.AzureStoragePublicCloud}/.default");
                // custom audience
                yield return new TestCaseData(new TableAudience("my.custom.audience"), false, "my.custom.audience/.default");
                yield return new TestCaseData(new TableAudience("my.custom.audience/"), false, "my.custom.audience/.default");
            }
        }
    }
}
