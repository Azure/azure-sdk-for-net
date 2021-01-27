// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Quantum;
using Microsoft.Azure.Management.Quantum.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using ResourceGroups.Tests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;

namespace Quantum.Tests.Helpers
{
    public static class QuantumManagementTestUtilities
    {
        public static bool IsTestTenant = false;
        private static HttpClientHandler Handler = null;

        private const string testSubscription = null;
        private static Uri testUri = null;

        // These are used to create default accounts
        public static string DefaultLocation = IsTestTenant ? null : "westus";
        public const string DefaultSkuName = "S1";
        public const string DefaultKind = "TextAnalytics";
        public static Dictionary<string, string> DefaultTags = new Dictionary<string, string>
            {
                {"key1","value1"},
                {"key2","value2"}
            };

        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            if (IsTestTenant)
            {
                return null;
            }
            else
            {
                handler.IsPassThrough = true;
                ResourceManagementClient resourcesClient = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
                return resourcesClient;
            }
        }

        public static QuantumManagementClient GetQuantumManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            QuantumManagementClient QuantumClient;
            if (IsTestTenant)
            {
                QuantumClient = new QuantumManagementClient(new TokenCredentials("xyz"), GetHandler());
                QuantumClient.SubscriptionId = testSubscription;
                QuantumClient.BaseUri = testUri;
            }
            else
            {
                handler.IsPassThrough = true;
                QuantumClient = context.GetServiceClient<QuantumManagementClient>(handlers: handler);
            }
            return QuantumClient;
        }

        private static HttpClientHandler GetHandler()
        {
            return Handler;
        }

        public static QuantumWorkspace GetDefaultQuantumWorkspaceParameters()
        {
            QuantumWorkspace account = new QuantumWorkspace
            {
                Location = DefaultLocation,
                Tags = DefaultTags,
            };

            return account;
        }

        public static string CreateResourceGroup(ResourceManagementClient resourcesClient)
        {
            const string testPrefix = "res";
            var rgname = TestUtilities.GenerateName(testPrefix);

            if (!IsTestTenant)
            {
                var resourceGroup = resourcesClient.ResourceGroups.CreateOrUpdate(
                    rgname,
                    new ResourceGroup
                    {
                        Location = DefaultLocation
                    });
            }

            return rgname;
        }

        public static string CreateQuantumWorkspace(QuantumManagementClient quantumMgmtClient, string rgname, string kind = null)
        {
            string workspaceName = TestUtilities.GenerateName("csa");
            var parameters = GetDefaultQuantumWorkspaceParameters();
            var createRequest2 = quantumMgmtClient.Workspaces.CreateOrUpdate(rgname, workspaceName, parameters);

            return workspaceName;
        }

        public static QuantumWorkspace CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumManagementClient quantumMgmtClient, string rgName, string skuName, string accountType = "TextAnalytics", string location = null)
        {
            // Create account with only required params
            var workspaceName = TestUtilities.GenerateName("csa");
            var parameters = new QuantumWorkspace
            {
                Location = location ?? DefaultLocation,
            };
            var workspace = quantumMgmtClient.Workspaces.CreateOrUpdate(rgName, workspaceName, parameters);
            VerifyWorkspaceProperties(workspace, false, accountType, skuName, location ?? DefaultLocation);

            return workspace;
        }

        public static void VerifyWorkspaceProperties(QuantumWorkspace workspace, bool useDefaults, string kind = DefaultKind, string skuName = DefaultSkuName, string location = "westus")
        {
            Assert.NotNull(workspace); // verifies that the account is actually created
            Assert.NotNull(workspace.Id);
            Assert.NotNull(workspace.Location);
            Assert.NotNull(workspace.Name);
            Assert.NotNull(workspace.EndpointUri);
            Assert.Equal("Succeeded", workspace.ProvisioningState);

            if (useDefaults)
            {
                Assert.Equal(QuantumManagementTestUtilities.DefaultLocation, workspace.Location);

                Assert.NotNull(workspace.Tags);
                Assert.Equal(2, workspace.Tags.Count);
                Assert.Equal("value1", workspace.Tags["key1"]);
                Assert.Equal("value2", workspace.Tags["key2"]);
            }
            else
            {
                Assert.Equal(location, workspace.Location);
            }
        }

        public static void ValidateExpectedException(Action action, string expectedErrorCode)
        {
            try
            {
                action();
                Assert.True(false, "Expected an Exception");
            }
            catch (ErrorResponseException e)
            {
                Assert.Equal(expectedErrorCode, e.Body.Error.Code);
            }
        }
    }
}