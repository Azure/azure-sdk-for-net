// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net.Http;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.Azure.Attestation.Tests
{
    public class AttestationTestFixture : TestEnvironment, IDisposable
    {
        public AttestationTestFixture()
        {
            Initialize(this.GetType());
        }

        public void Initialize(Type type)
        {
            HttpMockServer.FileSystemUtilsObject = new FileSystemUtils();
            HttpMockServer.Initialize(type, "InitialCreation", HttpRecorderMode.Record);
            HttpMockServer.CreateInstance();
        }

        public AttestationClient CreateAttestationClient()
        {
            string environmentConnectionString = Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION");
            string accessToken = "fakefakefake";

            // When recording, we should have a connection string passed into the code from the environment
            if (!string.IsNullOrEmpty(environmentConnectionString))
            {
                // Gather test client credential information from the environment
                var connectionInfo = new ConnectionString(Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION"));
                string servicePrincipal = connectionInfo.GetValue<string>(ConnectionStringKeys.ServicePrincipalKey);
                string servicePrincipalSecret = connectionInfo.GetValue<string>(ConnectionStringKeys.ServicePrincipalSecretKey);
                string aadTenant = connectionInfo.GetValue<string>(ConnectionStringKeys.AADTenantKey);

                // Create credentials
                var clientCredentials = new ClientCredential(servicePrincipal, servicePrincipalSecret);
                var authContext = new AuthenticationContext($"https://login.windows.net/{aadTenant}", TokenCache.DefaultShared);
                accessToken = authContext.AcquireTokenAsync("https://attest.azure.net", clientCredentials).Result.AccessToken;
            }

            return new AttestationClient(new AttestationCredentials(accessToken), GetHandlers());
        }

        public DelegatingHandler[] GetHandlers()
        {
            HttpMockServer server = HttpMockServer.CreateInstance();
            var testHttpHandler = new CustomDelegatingHandler();
            return new DelegatingHandler[] { server, testHttpHandler };
        }

        public void Dispose()
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record )
            {
                var testEnv = TestEnvironmentFactory.GetTestEnvironment();
                var context = new MockContext();
                var resourcesClient = context.GetServiceClient<ResourceManagementClient>();
            }
        }
    }
}
