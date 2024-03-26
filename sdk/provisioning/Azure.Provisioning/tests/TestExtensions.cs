// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.KeyVaults;

namespace Azure.Provisioning.Tests
{
    public static class TestExtensions
    {
        public static TestAppInsightsConstruct AddAppInsightsConstruct(this IConstruct construct)
        {
            return new TestAppInsightsConstruct(construct);
        }

        public static TestCommonSqlDatabase AddCommonSqlDatabase(this IConstruct construct, KeyVault? keyVault = null)
        {
            return new TestCommonSqlDatabase(construct, keyVault);
        }
    }
}
