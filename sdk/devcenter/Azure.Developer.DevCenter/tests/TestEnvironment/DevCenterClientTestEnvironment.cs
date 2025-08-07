// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Developer.DevCenter.Tests
{
    public class DevCenterClientTestEnvironment : TestEnvironment
    {
        private TokenCredential _credential;
        public Uri Endpoint => new(GetRecordedVariable("DEVCENTER_ENDPOINT"));
        public string ProjectName => GetRecordedVariable("DEFAULT_PROJECT_NAME");
        public string PoolName => GetRecordedVariable("DEFAULT_POOL_NAME");
        public string CatalogName => GetRecordedVariable("DEFAULT_CATALOG_NAME");
        public string EnvironmentTypeName => GetRecordedVariable("DEFAULT_ENVIRONMENT_TYPE_NAME");
        public string UserId => GetRecordedVariable("STATIC_TEST_USER_ID");
        public string MeUserId => "me";

        public override TokenCredential Credential
        {
            get
            {
                if (_credential != null)
                {
                    return _credential;
                }
                if (Mode == RecordedTestMode.Playback)
                {
                    _credential = new MockCredential();
                }
                else
                {
                    return new DevCenterTestUserCredential(
                        GetVariable("CLIENT_ID"),
                        GetVariable("CLIENT_SECRET"),
                        GetVariable("DEFAULT_TEST_USER_SECRET"),
                        GetVariable("DEFAULT_TEST_USER_NAME"),
                        GetVariable("DEFAULT_DEVCENTER_SCOPE"),
                        new(GetVariable("AZURE_AUTHORITY_HOST") ?? AzureAuthorityHosts.AzurePublicCloud.ToString()),
                        GetVariable("TENANT_ID"));
                }

                return _credential;
            }
        }
    }
}
