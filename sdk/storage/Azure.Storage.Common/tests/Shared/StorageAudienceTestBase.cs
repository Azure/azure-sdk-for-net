// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Storage.Tests.Shared
{
    /// <summary>
    /// Abstract base class that provides shared assertions for storage audience tests.
    /// Derived classes supply the concrete audience values used by these common tests.
    /// </summary>
    public abstract class StorageAudienceTestBase
    {
        /// <summary>Returns the built-in default audience string (e.g. BlobAudience.DefaultAudience.ToString()).</summary>
        protected abstract string GetDefaultAudienceValue();

        /// <summary>Returns the account-specific audience string from the factory method.</summary>
        protected abstract string GetAccountAudienceValue(string accountName);

        /// <summary>Calls CreateDefaultScope on an audience constructed from the given value.</summary>
        protected abstract string CreateDefaultScope(string audienceValue);

        [Test]
        public void ServiceAudience_MatchesDefaultAudience()
        {
            string value = GetDefaultAudienceValue();
            Assert.AreEqual(Constants.DefaultAudience, value,
                $"Service default audience should match Constants.DefaultAudience. Actual: '{value}'");
        }

        [Test]
        public void AccountAudience_DoesNotHaveTrailingSlash()
        {
            string value = GetAccountAudienceValue("myaccount");
            Assert.IsFalse(
                value.EndsWith("/"),
                $"Account audience should not end with a trailing slash. Actual: '{value}'");
        }

        [TestCaseSource(nameof(DefaultScopeTestCases))]
        public void CreateDefaultScope_ProducesCorrectScope(string audienceValue, string expectedScope)
        {
            Assert.AreEqual(expectedScope, CreateDefaultScope(audienceValue));
        }

        public static IEnumerable<TestCaseData> DefaultScopeTestCases
        {
            get
            {
                yield return new TestCaseData(
                    "https://storage.azure.com",
                    "https://storage.azure.com/.default")
                    .SetName("Without trailing slash");

                yield return new TestCaseData(
                    "https://storage.azure.com/",
                    "https://storage.azure.com/.default")
                    .SetName("With trailing slash");

                yield return new TestCaseData(
                    "https://myaccount.blob.core.windows.net",
                    "https://myaccount.blob.core.windows.net/.default")
                    .SetName("Account audience without trailing slash");

                yield return new TestCaseData(
                    "https://myaccount.blob.core.windows.net/",
                    "https://myaccount.blob.core.windows.net/.default")
                    .SetName("Account audience with trailing slash");
            }
        }
    }
}
