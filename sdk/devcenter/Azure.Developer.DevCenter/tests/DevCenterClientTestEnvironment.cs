// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using Azure.Core.TestFramework;
using Azure.Identity;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Developer.DevCenter.Tests
{
    public class DevCenterClientTestEnvironment : TestEnvironment
    {
        private TokenCredential _credential;
        private Uri _authority => new(AuthorityHostUrl + TenantId);
        private string _scope => GetRecordedVariable("DEFAULT_DEVCENTER_SCOPE");
        private string _testUserSecret => GetRecordedVariable("DEFAULT_TEST_USER_SECRET", options => options.IsSecret());
        private string _testUserName => GetRecordedVariable("DEFAULT_TEST_USER_NAME");
        public Uri Endpoint => new(GetRecordedVariable("DEFAULT_DEVCENTER_ENDPOINT"));
        public string ProjectName => GetRecordedVariable("DEFAULT_PROJECT_NAME");
        public string PoolName => GetRecordedVariable("DEFAULT_POOL_NAME");
        public string CatalogName => GetRecordedVariable("DEFAULT_CATALOG_NAME");
        public string EnvironmentTypeName => GetRecordedVariable("DEFAULT_ENVIRONMENT_TYPE_NAME");
        public string UserId => GetRecordedVariable("STATIC_TEST_USER_ID");

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
                    _credential = new DevCenterTestUserCredential(ClientId,
                        ClientSecret,
                        UserId,
                        _testUserSecret,
                        _testUserName,
                        _scope,
                        new Uri(AuthorityHostUrl + TenantId));
                }

                return _credential;
            }
        }
    }
}
