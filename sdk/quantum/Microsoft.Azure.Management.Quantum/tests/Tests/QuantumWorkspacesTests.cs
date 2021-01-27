// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Quantum.Tests.Helpers;
using Microsoft.Azure.Management.Quantum;
using Microsoft.Azure.Management.Quantum.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using ResourceGroups.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace Quantum.Tests
{
    public class QuantumWorkspaceTests
    {
        private const string c_resourceNamespace = "Microsoft.Quantum";
        private const string c_resourceType = "Workspaces";

        public QuantumWorkspaceTests()
        {
        }

        [Fact]
        public void QuantumWorkspaceCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                var rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Prepare Azure Quantum Workspace properties
                string workspaceName = TestUtilities.GenerateName("aq");
                var parameters = QuantumManagementTestUtilities.GetDefaultQuantumWorkspaceParameters();

                // Create Azure Quantum Workspace
                var quantumWorkspace = QuantumMgmtClient.Workspaces.CreateOrUpdate(rgname, workspaceName, parameters);
                QuantumManagementTestUtilities.VerifyWorkspaceProperties(quantumWorkspace, true);

                // Update Azure Quantum Workspace
                quantumWorkspace = QuantumMgmtClient.Workspaces.CreateOrUpdate(rgname, workspaceName, parameters);
                QuantumManagementTestUtilities.VerifyWorkspaceProperties(quantumWorkspace, true);

                // Create account with only required params, for each sku (but free, since we can't have two free accounts in the same subscription)
                QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S1");
                QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S2");
                QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S3");
                QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S4");
            }
        }

        [Fact]
        public void QuantumWorkspaceCreateAllApisTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                var rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S1", "Bing.Autosuggest.v7", "global");
            }
        }

        [Fact]
        public void QuantumWorkspaceDeleteTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                var rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Delete a Quantum Workspace which does not exist
                QuantumMgmtClient.Workspaces.Delete(rgname, "missingaccount");

                // Create Quantum Workspace
                string quantumWorkspace = QuantumManagementTestUtilities.CreateQuantumWorkspace(QuantumMgmtClient, rgname);

                // Delete Quantum Workspace
                QuantumMgmtClient.Workspaces.Delete(rgname, quantumWorkspace);

                // Delete an account which was just deleted
                QuantumMgmtClient.Workspaces.Delete(rgname, quantumWorkspace);
            }
        }

        [Fact]
        public void QuantumWorkspaceListByResourceGroupTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                var rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                var quantumWorkspaces = QuantumMgmtClient.Workspaces.ListByResourceGroup(rgname);
                Assert.Empty(quantumWorkspaces);

                // Create cognitive services accounts
                string workspaceName1 = QuantumManagementTestUtilities.CreateQuantumWorkspace(QuantumMgmtClient, rgname);
                string workspaceName2 = QuantumManagementTestUtilities.CreateQuantumWorkspace(QuantumMgmtClient, rgname);

                quantumWorkspaces = QuantumMgmtClient.Workspaces.ListByResourceGroup(rgname);
                Assert.Equal(2, quantumWorkspaces.Count());

                QuantumManagementTestUtilities.VerifyWorkspaceProperties(quantumWorkspaces.First(), true);
                QuantumManagementTestUtilities.VerifyWorkspaceProperties(quantumWorkspaces.Skip(1).First(), true);
            }
        }

        [Fact]
        public void QuantumWorkspaceListBySubscriptionTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var quantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);


                // Create resource group and cognitive services account
                var rgname1 = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);
                string workspaceName1 = QuantumManagementTestUtilities.CreateQuantumWorkspace(quantumMgmtClient, rgname1);

                // Create different resource group and cognitive account
                var rgname2 = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);
                string workspaceName2 = QuantumManagementTestUtilities.CreateQuantumWorkspace(quantumMgmtClient, rgname2);

                var quantumWorkspaces = quantumMgmtClient.Workspaces.ListBySubscription();

                Assert.True(quantumWorkspaces.Count() >= 2);

                QuantumWorkspace account1 = quantumWorkspaces.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.Name, workspaceName1));
                QuantumManagementTestUtilities.VerifyWorkspaceProperties(account1, true);

                QuantumWorkspace account2 = quantumWorkspaces.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.Name, workspaceName2));
                QuantumManagementTestUtilities.VerifyWorkspaceProperties(account2, true);
            }
        }

        [Fact]
        public void QuantumDeleteWorkspaceErrorTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                var rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // try to delete non-existent account
                QuantumManagementTestUtilities.ValidateExpectedException(
                    () => QuantumMgmtClient.Workspaces.Delete("NotExistedRG", "NonExistedWorkspaceName"),
                    "ResourceGroupNotFound");
            }
        }
    }
}