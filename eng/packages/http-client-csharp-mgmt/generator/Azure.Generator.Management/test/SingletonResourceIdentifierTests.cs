// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.MgmtTypeSpec.Tests;
using Azure.ResourceManager;
using Moq;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests
{
    internal class SingletonResourceIdentifierTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000000";

        [Test]
        public void GetSingletonResourceRejectsDifferentSingletonWithSameResourceType()
        {
            var client = new ArmClient(Mock.Of<TokenCredential>(), SubscriptionId);
            var expectedId = BarSettingsResource.CreateResourceIdentifier(SubscriptionId, "group", "foo", "bar");
            var otherId = new ResourceIdentifier($"/subscriptions/{SubscriptionId}/resourceGroups/group/providers/MgmtTypeSpec/foos/foo/bars/bar/settings/other");

            Assert.That(otherId.ResourceType, Is.EqualTo(expectedId.ResourceType));
            Assert.Throws<ArgumentException>(() => client.GetBarSettingsResource(otherId));
        }

        [TestCase("current")]
        [TestCase("CURRENT")]
        public void GetSingletonResourceAcceptsExpectedNameIgnoringCase(string name)
        {
            var client = new ArmClient(Mock.Of<TokenCredential>(), SubscriptionId);
            var id = new ResourceIdentifier($"/subscriptions/{SubscriptionId}/resourceGroups/another-group/providers/MgmtTypeSpec/foos/another-foo/bars/another-bar/settings/{name}");

            Assert.That(client.GetBarSettingsResource(id).Id, Is.EqualTo(id));
        }

        [Test]
        public void GetLocationSingletonRejectsNonCanonicalLocation()
        {
            var client = new ArmClient(Mock.Of<TokenCredential>(), SubscriptionId);
            var id = new ResourceIdentifier($"/subscriptions/{SubscriptionId}/providers/MgmtTypeSpec/locations/East US/locationSingletons/current");

            Assert.Throws<ArgumentException>(() => client.GetLocationSingletonResource(id));
        }

        [TestCase("eastus")]
        [TestCase("EASTUS")]
        [TestCase("customregion")]
        public void GetLocationSingletonAcceptsCanonicalLocations(string location)
        {
            var client = new ArmClient(Mock.Of<TokenCredential>(), SubscriptionId);
            var id = new ResourceIdentifier($"/subscriptions/{SubscriptionId}/providers/MgmtTypeSpec/locations/{location}/locationSingletons/current");

            Assert.That(client.GetLocationSingletonResource(id).Id, Is.EqualTo(id));
        }

        [Test]
        public void GetSingletonResourceAcceptsCaseInsensitiveFixedPathSegments()
        {
            var client = new ArmClient(Mock.Of<TokenCredential>(), SubscriptionId);
            var id = new ResourceIdentifier($"/SUBSCRIPTIONS/{SubscriptionId}/RESOURCEGROUPS/group/PROVIDERS/MGMTTYPESPEC/FOOS/foo/BARS/bar/SETTINGS/CURRENT");

            Assert.That(client.GetBarSettingsResource(id).Id, Is.EqualTo(id));
        }

        [TestCase("/subscriptions/00000000-0000-0000-0000-000000000000")]
        [TestCase("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/group/providers/Microsoft.Compute/virtualMachines/vm")]
        public void SingletonExtensionResourceKeepsVariableScopeAndNameValidation(string scope)
        {
            var client = new ArmClient(Mock.Of<TokenCredential>(), SubscriptionId);
            var id = HciVmInstanceResource.CreateResourceIdentifier(scope);
            var otherId = new ResourceIdentifier($"{scope}/providers/MgmtTypeSpec/virtualMachineInstances/other");

            Assert.That(client.GetHciVmInstanceResource(id).Id, Is.EqualTo(id));
            Assert.Throws<ArgumentException>(() => client.GetHciVmInstanceResource(otherId));
        }

        [Test]
        public void ParentAccessorAndOrdinaryResourcesRetainVariableNames()
        {
            var client = new ArmClient(Mock.Of<TokenCredential>(), SubscriptionId);
            var barId = BarResource.CreateResourceIdentifier(SubscriptionId, "group", "foo", "other");
            var bar = client.GetBarResource(barId);

            Assert.That(bar.Id, Is.EqualTo(barId));
            Assert.That(bar.GetBarSettingsResource().Id, Is.EqualTo(BarSettingsResource.CreateResourceIdentifier(SubscriptionId, "group", "foo", "other")));
        }

        [Test]
        public void OrdinaryResourceTypeValidationRetainsItsExistingBuildConfigurationPolicy()
        {
            var client = new ArmClient(Mock.Of<TokenCredential>(), SubscriptionId);
            var otherTypeId = new ResourceIdentifier($"/subscriptions/{SubscriptionId}/resourceGroups/group/providers/MgmtTypeSpec/foos/foo/bars/bar/quotas/other");

#if DEBUG
            Assert.Throws<ArgumentException>(() => client.GetBarResource(otherTypeId));
#else
            Assert.That(client.GetBarResource(otherTypeId).Id, Is.EqualTo(otherTypeId));
#endif
        }

        [Test]
        public void GetSingletonResourceRejectsWrongTypeInAllConfigurations()
        {
            var client = new ArmClient(Mock.Of<TokenCredential>(), SubscriptionId);
            var otherTypeId = new ResourceIdentifier($"/subscriptions/{SubscriptionId}/resourceGroups/group/providers/MgmtTypeSpec/foos/foo/bars/bar/quotas/other");

            Assert.Throws<ArgumentException>(() => client.GetBarSettingsResource(otherTypeId));
        }

        [TestCase("/subscriptions/00000000-0000-0000-0000-000000000000/providers/MgmtTypeSpec/foos/foo/bars/bar/settings/current")]
        [TestCase("/providers/MgmtTypeSpec/foos/foo/bars/bar/settings/current")]
        public void GetSingletonResourceRejectsOtherScopesWithSameResourceType(string value)
        {
            var client = new ArmClient(Mock.Of<TokenCredential>(), SubscriptionId);
            var expectedId = BarSettingsResource.CreateResourceIdentifier(SubscriptionId, "group", "foo", "bar");
            var otherId = new ResourceIdentifier(value);

            Assert.That(otherId.ResourceType, Is.EqualTo(expectedId.ResourceType));
            Assert.Throws<ArgumentException>(() => client.GetBarSettingsResource(otherId));
        }

        [Test]
        public void GetSingletonResourceRejectsTrailingSlash()
        {
            var client = new ArmClient(Mock.Of<TokenCredential>(), SubscriptionId);
            var id = BarSettingsResource.CreateResourceIdentifier(SubscriptionId, "group", "foo", "bar");

            Assert.Throws<ArgumentException>(() => client.GetBarSettingsResource(new ResourceIdentifier(id + "/")));
        }

        [Test]
        public void GetSingletonResourceRejectsNullInAllConfigurations()
        {
            var client = new ArmClient(Mock.Of<TokenCredential>(), SubscriptionId);

            Assert.Throws<ArgumentNullException>(() => client.GetBarSettingsResource(null!));
        }

        [Test]
        public void QuerySuffixedVariableNameIsNotTreatedAsFixedSingletonName()
        {
            var client = new ArmClient(Mock.Of<TokenCredential>(), SubscriptionId);
            var id = new ResourceIdentifier($"/subscriptions/{SubscriptionId}/resourceGroups/group/providers/MgmtTypeSpec/applicationDefinitions/definition");

            Assert.That(client.GetSolutionsApplicationDefinitionResource(id).Id, Is.EqualTo(id));
        }

        [Test]
        public void ServiceResponseIdentifiersAreNotSubjectToAccessorValidation()
        {
            var responseId = $"/subscriptions/{SubscriptionId}/resourceGroups/group/providers/MgmtTypeSpec/foos/foo/bars/bar/settings/other";
            var policy = new ResponsePolicy($$"""{"id":"{{responseId}}","name":"other","type":"MgmtTypeSpec/foos/bars/settings"}""");
            var options = new ArmClientOptions();
            options.AddPolicy(policy, HttpPipelinePosition.PerCall);
            var client = new ArmClient(Mock.Of<TokenCredential>(), SubscriptionId, options);
            var id = BarSettingsResource.CreateResourceIdentifier(SubscriptionId, "group", "foo", "bar");

            var response = client.GetBarSettingsResource(id).Get();

            Assert.That(policy.Uri!.AbsolutePath, Does.EndWith("/foos/foo/bars/bar/settings/current"));
            Assert.That(response.Value.Id.ToString(), Is.EqualTo(responseId));
        }

        private sealed class ResponsePolicy(string response) : HttpPipelinePolicy
        {
            public Uri? Uri { get; private set; }

            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                Uri = message.Request.Uri.ToUri();
                message.Response = new TestResponse(200).SetContent(response);
            }

            public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                Process(message, pipeline);
                return ValueTask.CompletedTask;
            }
        }
    }
}
