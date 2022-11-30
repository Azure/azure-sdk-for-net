// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ScopeUtilitiesTests
    {
        [TestCase("https://vaults.azure.net/.default")]
        [TestCase("https://management.core.windows.net//.default")]
        [TestCase("https://graph.microsoft.com/User.Read")]
        [TestCase("api://0478121b-afdc-4ecd-91d8-fe015a9e1826/user_impersonation")]
        public void ValidateScopesAcceptsValidScopes(string scope)
        {
            Assert.DoesNotThrow(() => ScopeUtilities.ValidateScope(scope));
        }

        [TestCase("api://0478121b-afdc-4ecd-91d8-fe015a9e1826/invalid scope")]
        [TestCase("api://0478121b-afdc-4ecd-91d8-fe015a9e1826/invalid\"scope")]
        [TestCase("api://0478121b-afdc-4ecd-91d8-fe015a9e1826/invalid\\scope")]
        public void ValidateScopesRejectsInvalidScopes(string scope)
        {
            Assert.Throws<ArgumentException>(() => ScopeUtilities.ValidateScope(scope));
        }
    }
}
