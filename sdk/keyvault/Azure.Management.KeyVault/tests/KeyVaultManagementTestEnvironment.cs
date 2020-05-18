// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Management.KeyVault.Tests
{
    public class KeyVaultManagementTestEnvironment : TestEnvironment
    {
        private const string TenantIdKey = "TenantId";
        private const string SubIdKey = "SubId";
        private const string ApplicationIdKey = "ApplicationId";

        public KeyVaultManagementTestEnvironment() : base("keyvalutmgmt")
        {
        }

        //Do not need to save to session record
        public string UserName => GetVariable("AZURE_USER_NAME");

        public string TenantIdTrack1 => GetRecordedVariable(TenantIdKey);

        public string SubscriptionIdTrack1 => GetRecordedVariable(SubIdKey);

        public string ApplicationIdTrack1 => GetRecordedVariable(ApplicationIdKey);
    }
}
