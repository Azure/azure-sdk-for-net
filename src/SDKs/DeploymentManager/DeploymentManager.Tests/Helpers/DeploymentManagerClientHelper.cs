// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Management.DeploymentManager.Tests
{
    public class DeploymentManagerClientHelper
    {
        private ResourceManagementClient _client;
        private MockContext _context;
        private TestBase _testBase;

        public DeploymentManagerClientHelper(TestBase testBase, MockContext context) : this(
                testBase,
                context,
                new RecordedDelegatingHandler() { StatusCodeToReturn = System.Net.HttpStatusCode.OK })
        {
            this.ResourceGroupName = TestUtilities.GenerateName("deploymentmanager-sdk-net-test-rg");
        }

        public DeploymentManagerClientHelper(TestBase testBase, MockContext context, RecordedDelegatingHandler handler)
        {
            _client = DeploymentManagerTestUtilities.GetResourceManagementClient(context, handler);
            _testBase = testBase;
            _context = context;
        }

        public string ResourceGroupName { get; private set; }

        public void TryRegisterSubscriptionForResource()
        {
            var reg = _client.Providers.Register(DeploymentManagerTestUtilities.ProviderName);
            ThrowIfTrue(reg == null, "_client.Providers.Register returned null.");

            var resultAfterRegister = _client.Providers.Get(DeploymentManagerTestUtilities.ProviderName);
            ThrowIfTrue(resultAfterRegister == null, "_client.Providers.Get returned null.");
            ThrowIfTrue(string.IsNullOrEmpty(resultAfterRegister.Id), "Provider.Id is null or empty.");
            ThrowIfTrue(resultAfterRegister.ResourceTypes == null || resultAfterRegister.ResourceTypes.Count == 0, "Provider.ResourceTypes is empty.");
            ThrowIfTrue(resultAfterRegister.ResourceTypes[0].Locations == null || resultAfterRegister.ResourceTypes[0].Locations.Count == 0, "Provider.ResourceTypes[0].Locations is empty.");
        }

        public void TryCreateResourceGroup(string location)
        {
            ResourceGroup result = _client.ResourceGroups.CreateOrUpdate(this.ResourceGroupName, new ResourceGroup { Location = location });
            var newlyCreatedGroup = _client.ResourceGroups.Get(this.ResourceGroupName);
            ThrowIfTrue(newlyCreatedGroup == null, "_client.ResourceGroups.Get returned null.");
            ThrowIfTrue(!this.ResourceGroupName.Equals(newlyCreatedGroup.Name), string.Format("resourceGroupName is not equal to {0}", this.ResourceGroupName));
        }

        public void DeleteResourceGroup(string resourceGroupName)
        {
            _client.ResourceGroups.Delete(resourceGroupName);
        }

        private void ThrowIfTrue(bool condition, string message)
        {
            if (condition)
            {
                throw new Exception(message);
            }
        }
    }
}
