// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.CommonProperties;
using Azure.ResourceManager.CommonProperties.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ResourceManager.CommonProperties
{
    public class CommonPropertiesTests : SpectorTestBase
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000000";
        private const string ResourceGroupName = "test-rg";
        private const string ResourceGroupId = $"/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}";
        private const string UserAssignedIdentityId = $"{ResourceGroupId}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/id1";
        private const string VirtualNetworkId = $"{ResourceGroupId}/providers/Microsoft.Network/virtualNetworks/myVnet";
        private const string VirtualMachineId = $"{ResourceGroupId}/providers/Microsoft.Compute/virtualMachines/myVm";
        private const string ServiceGroupRoleId = $"/providers/Microsoft.Management/serviceGroups/test-sg/providers/Microsoft.Authorization/roleDefinitions/{SubscriptionId}";

        [SpectorTest]
        public Task ManagedIdentityGet() => Test(async host =>
        {
            ManagedIdentityTrackedResource resource = await GetResourceGroup(host)
                .GetManagedIdentityTrackedResources().GetAsync("identity");

            AssertManagedIdentity(resource.Data, ManagedServiceIdentityType.SystemAssigned);
            Assert.That(resource.Data.Identity.UserAssignedIdentities, Is.Empty);
        });

        [SpectorTest]
        public Task ManagedIdentityCreateWithSystemAssigned() => Test(async host =>
        {
            ManagedIdentityTrackedResourceData data = new(AzureLocation.EastUS)
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            data.Tags.Add("tagKey1", "tagValue1");

            var operation = await GetResourceGroup(host).GetManagedIdentityTrackedResources()
                .CreateOrUpdateAsync(WaitUntil.Completed, "identity", data);

            Assert.That(operation.HasCompleted, Is.True);
            AssertManagedIdentity(operation.Value.Data, ManagedServiceIdentityType.SystemAssigned);
            Assert.That(operation.Value.Data.Identity.UserAssignedIdentities, Is.Empty);
        });

        [SpectorTest]
        public Task ManagedIdentityUpdateWithUserAssignedAndSystemAssigned() => Test(async host =>
        {
            var resource = GetArmClient(host).GetManagedIdentityTrackedResource(
                ManagedIdentityTrackedResource.CreateResourceIdentifier(SubscriptionId, ResourceGroupName, "identity"));
            ManagedIdentityTrackedResourceData data = new(AzureLocation.EastUS)
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned)
            };
            data.Identity.UserAssignedIdentities.Add(new ResourceIdentifier(UserAssignedIdentityId), new UserAssignedIdentity());

            var response = await resource.UpdateAsync(data);

            AssertManagedIdentity(response.Value.Data, ManagedServiceIdentityType.SystemAssignedUserAssigned);
            var identities = response.Value.Data.Identity.UserAssignedIdentities;
            Assert.That(identities, Has.Count.EqualTo(1));
            Assert.That(identities.ContainsKey(new ResourceIdentifier(UserAssignedIdentityId)), Is.True);
            Assert.That(identities[new ResourceIdentifier(UserAssignedIdentityId)].PrincipalId, Is.EqualTo(Guid.Empty));
            Assert.That(identities[new ResourceIdentifier(UserAssignedIdentityId)].ClientId, Is.EqualTo(Guid.Empty));
        });

        [SpectorTest]
        public Task ErrorGetForPredefinedError() => Test(host =>
        {
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
                await GetResourceGroup(host).GetConfidentialResources().GetAsync("confidential"));

            Assert.That(exception!.Status, Is.EqualTo(404));
            Assert.That(exception.ErrorCode, Is.EqualTo("ResourceNotFound"));
            Assert.That(exception.Message, Does.Contain("The Resource 'Azure.ResourceManager.CommonProperties/confidentialResources/confidential' under resource group 'test-rg' was not found."));
            return Task.CompletedTask;
        });

        [SpectorTest]
        public Task ErrorCreateForUserDefinedError() => Test(host =>
        {
            ConfidentialResourceData data = new(AzureLocation.EastUS)
            {
                Properties = new ConfidentialResourceProperties("00")
            };
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
                await GetResourceGroup(host).GetConfidentialResources()
                    .CreateOrUpdateAsync(WaitUntil.Completed, "confidential", data));

            Assert.That(exception!.Status, Is.EqualTo(400));
            Assert.That(exception.ErrorCode, Is.EqualTo("BadRequest"));
            Assert.That(exception.Message, Does.Contain("Username should not contain only numbers."));
            using var error = JsonDocument.Parse(exception.GetRawResponse()!.Content);
            Assert.That(error.RootElement.GetProperty("error").GetProperty("innererror").GetProperty("exceptiontype").GetString(), Is.EqualTo("general"));
            return Task.CompletedTask;
        });

        [SpectorTest]
        public Task ArmResourceIdentifiersGet() => Test(async host =>
        {
            ArmResourceIdentifierResource resource = await GetResourceGroup(host)
                .GetArmResourceIdentifierResources().GetAsync("armId");

            AssertArmResourceIdentifiers(resource.Data);
        });

        [SpectorTest]
        public Task ArmResourceIdentifiersCreateOrReplace() => Test(async host =>
        {
            ArmResourceIdentifierResourceData data = new(AzureLocation.EastUS)
            {
                Properties = new ArmResourceIdentifierResourceProperties(
                    new ResourceIdentifier(VirtualNetworkId),
                    new ResourceIdentifier(VirtualNetworkId),
                    new ResourceIdentifier(VirtualNetworkId),
                    new ResourceIdentifier(VirtualMachineId),
                    new ResourceIdentifier(ServiceGroupRoleId))
            };

            var operation = await GetResourceGroup(host).GetArmResourceIdentifierResources()
                .CreateOrUpdateAsync(WaitUntil.Completed, "armId", data);

            Assert.That(operation.HasCompleted, Is.True);
            AssertArmResourceIdentifiers(operation.Value.Data);
        });

        private static ResourceGroupResource GetResourceGroup(Uri host)
            => GetArmClient(host).GetResourceGroupResource(new ResourceIdentifier(ResourceGroupId));

        private static ArmClient GetArmClient(Uri host)
        {
            ArmClientOptions options = new()
            {
                Environment = new ArmEnvironment(new UriBuilder(host) { Scheme = Uri.UriSchemeHttps }.Uri, host.AbsoluteUri),
                Transport = new InsecureTransport()
            };
            return new ArmClient(new TestCredential(), SubscriptionId, options);
        }

        private static void AssertManagedIdentity(ManagedIdentityTrackedResourceData data, ManagedServiceIdentityType identityType)
        {
            Assert.That(data.Id.ToString(), Is.EqualTo($"{ResourceGroupId}/providers/Azure.ResourceManager.CommonProperties/managedIdentityTrackedResources/identity"));
            Assert.That(data.Location, Is.EqualTo(AzureLocation.EastUS));
            Assert.That(data.Tags["tagKey1"], Is.EqualTo("tagValue1"));
            Assert.That(data.ManagedIdentityTrackedResourceProvisioningState, Is.EqualTo("Succeeded"));
            Assert.That(data.Identity.ManagedServiceIdentityType, Is.EqualTo(identityType));
            Assert.That(data.Identity.PrincipalId, Is.EqualTo(Guid.Empty));
            Assert.That(data.Identity.TenantId, Is.EqualTo(Guid.Empty));
        }

        private static void AssertArmResourceIdentifiers(ArmResourceIdentifierResourceData data)
        {
            Assert.That(data.Id.ToString(), Is.EqualTo($"{ResourceGroupId}/providers/Azure.ResourceManager.CommonProperties/armResourceIdentifierResources/armId"));
            Assert.That(data.Name, Is.EqualTo("armId"));
            Assert.That(data.ResourceType.ToString(), Is.EqualTo("Azure.ResourceManager.CommonProperties/armResourceIdentifierResources"));
            Assert.That(data.Location, Is.EqualTo(AzureLocation.EastUS));
            Assert.That(data.Properties.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
            Assert.That(data.Properties.SimpleArmId, Is.EqualTo(new ResourceIdentifier(VirtualNetworkId)));
            Assert.That(data.Properties.ArmIdWithType, Is.EqualTo(new ResourceIdentifier(VirtualNetworkId)));
            Assert.That(data.Properties.ArmIdWithTypeAndScope, Is.EqualTo(new ResourceIdentifier(VirtualNetworkId)));
            Assert.That(data.Properties.ArmIdWithAllScopes, Is.EqualTo(new ResourceIdentifier(VirtualMachineId)));
            Assert.That(data.Properties.ArmIdWithGroupScope, Is.EqualTo(new ResourceIdentifier(ServiceGroupRoleId)));
        }

        private sealed class InsecureTransport : HttpPipelineTransport
        {
            private readonly HttpClientTransport _transport = new();

            public override Request CreateRequest() => _transport.CreateRequest();

            public override void Process(HttpMessage message)
            {
                message.Request.Uri.Scheme = Uri.UriSchemeHttp;
                _transport.Process(message);
            }

            public override ValueTask ProcessAsync(HttpMessage message)
            {
                message.Request.Uri.Scheme = Uri.UriSchemeHttp;
                return _transport.ProcessAsync(message);
            }
        }

        private sealed class TestCredential : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new("token", DateTimeOffset.MaxValue);

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new(GetToken(requestContext, cancellationToken));
        }
    }
}
