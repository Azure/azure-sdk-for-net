// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;

namespace Azure.Tests
{
    public class TestAzureCredentialsFactory : AzureCredentialsFactory
    {
        public override AzureCredentials FromFile(string authFile)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                var env = new AzureEnvironment()
                {
                    AuthenticationEndpoint = "https://www.contoso.com",
                    ManagementEnpoint = "https://www.contoso.com",
                    ResourceManagerEndpoint = "https://www.contoso.com",
                    GraphEndpoint = "https://www.contoso.com"
                };

                AzureCredentials credentials = new TestAzureCredentials(
                    new ServicePrincipalLoginInformation
                    {
                        ClientId = HttpMockServer.Variables.ContainsKey(ConnectionStringKeys.AADTenantKey) ?
                            HttpMockServer.Variables[ConnectionStringKeys.ServicePrincipalKey] : "servicePrincipalNotRecorded",
                        ClientSecret = null
                    }, 
                    HttpMockServer.Variables.ContainsKey(ConnectionStringKeys.AADTenantKey) ?
                        HttpMockServer.Variables[ConnectionStringKeys.AADTenantKey] : "tenantIdNotRecorded", env);
                credentials.WithDefaultSubscription(
                    HttpMockServer.Variables.ContainsKey(ConnectionStringKeys.SubscriptionIdKey) ?
                        HttpMockServer.Variables[ConnectionStringKeys.SubscriptionIdKey] : "subscriptionIdNotRecorded");

                return credentials;
            }

            var retValue = base.FromFile(authFile);

            HttpMockServer.Variables[ConnectionStringKeys.ServicePrincipalKey] = retValue.ClientId;
            HttpMockServer.Variables[ConnectionStringKeys.AADTenantKey] = retValue.TenantId;
            HttpMockServer.Variables[ConnectionStringKeys.SubscriptionIdKey] = retValue.DefaultSubscriptionId;

            return retValue;
        }
    }
}
