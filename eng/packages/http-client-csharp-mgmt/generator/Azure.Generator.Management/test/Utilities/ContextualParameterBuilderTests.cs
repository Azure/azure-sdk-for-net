// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Models;
using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using NUnit.Framework;

namespace Azure.Generator.Mgmt.Tests.Utilities
{
    public class ContextualParameterBuilderTests
    {
        private readonly ScopedApi<ResourceIdentifier> _idVariable;

        public ContextualParameterBuilderTests()
        {
            _idVariable = new ParameterProvider("id", $"", typeof(ResourceIdentifier)).As<ResourceIdentifier>();
        }

        [TestCase]
        public void ValidateContextualParameters_Tenant()
        {
            var requestPathPattern = new RequestPathPattern(string.Empty);
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.That(contextualParameters, Is.Empty, "Tenant path should not have any contextual parameters.");
        }

        [TestCase]
        public void ValidateContextualParameters_Subscription()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}");

            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);

            Assert.That(contextualParameters.Count, Is.EqualTo(1));
            Assert.Multiple(() =>
            {
                Assert.That(contextualParameters[0].Key, Is.EqualTo("subscriptions"));
                Assert.That(contextualParameters[0].VariableName, Is.EqualTo("subscriptionId"));

                Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.SubscriptionId"));
            });
        }

        [TestCase]
        public void ValidateContextualParameters_ResourceGroup()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}");

            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);

            Assert.That(contextualParameters.Count, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(contextualParameters[0].Key, Is.EqualTo("subscriptions"));
                Assert.That(contextualParameters[0].VariableName, Is.EqualTo("subscriptionId"));
                Assert.That(contextualParameters[1].Key, Is.EqualTo("resourceGroups"));
                Assert.That(contextualParameters[1].VariableName, Is.EqualTo("resourceGroupName"));

                Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.SubscriptionId"));
                Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.ResourceGroupName"));
            });
        }

        [TestCase]
        public void ValidateContextualParameters_ManagementGroup()
        {
            var requestPathPattern = new RequestPathPattern("/providers/Microsoft.Management/managementGroups/{managementGroupId}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.That(contextualParameters.Count, Is.EqualTo(1));
            Assert.Multiple(() =>
            {
                Assert.That(contextualParameters[0].Key, Is.EqualTo("managementGroups"));
                Assert.That(contextualParameters[0].VariableName, Is.EqualTo("managementGroupId"));
                Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
            });
        }

        [TestCase]
        public void ValidateContextualParameters_TenantResource()
        {
            var requestPathPattern = new RequestPathPattern("/providers/Microsoft.Example/examples/{name}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.That(contextualParameters.Count, Is.EqualTo(1));
            Assert.Multiple(() =>
            {
                Assert.That(contextualParameters[0].Key, Is.EqualTo("examples"));
                Assert.That(contextualParameters[0].VariableName, Is.EqualTo("name"));
                Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
            });
        }

        [TestCase]
        public void ValidateContextualParameters_TenantResource_ChildResource()
        {
            var requestPathPattern = new RequestPathPattern("/providers/Microsoft.Example/examples/{exampleName}/childResources/{name}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.That(contextualParameters.Count, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(contextualParameters[0].Key, Is.EqualTo("examples"));
                Assert.That(contextualParameters[0].VariableName, Is.EqualTo("exampleName"));
                Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Name"));
                Assert.That(contextualParameters[1].Key, Is.EqualTo("childResources"));
                Assert.That(contextualParameters[1].VariableName, Is.EqualTo("name"));
                Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
            });
        }

        [TestCase]
        public void ValidateContextualParameters_TenantResource_GrandChildResource()
        {
            var requestPathPattern = new RequestPathPattern("/providers/Microsoft.Example/examples/{exampleName}/childResources/{childName}/grandChildResources/{name}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.That(contextualParameters.Count, Is.EqualTo(3));
            Assert.Multiple(() =>
            {
                Assert.That(contextualParameters[0].Key, Is.EqualTo("examples"));
                Assert.That(contextualParameters[0].VariableName, Is.EqualTo("exampleName"));
                Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Parent.Name"));
                Assert.That(contextualParameters[1].Key, Is.EqualTo("childResources"));
                Assert.That(contextualParameters[1].VariableName, Is.EqualTo("childName"));
                Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Name"));
                Assert.That(contextualParameters[2].Key, Is.EqualTo("grandChildResources"));
                Assert.That(contextualParameters[2].VariableName, Is.EqualTo("name"));
                Assert.That(contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
            });
        }

        [TestCase]
        public void ValidateContextualParameters_ResourceGroupResource()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{name}");

            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.That(contextualParameters.Count, Is.EqualTo(3));
            Assert.Multiple(() =>
            {
                Assert.That(contextualParameters[0].Key, Is.EqualTo("subscriptions"));
                Assert.That(contextualParameters[0].VariableName, Is.EqualTo("subscriptionId"));
                Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.SubscriptionId"));
                Assert.That(contextualParameters[1].Key, Is.EqualTo("resourceGroups"));
                Assert.That(contextualParameters[1].VariableName, Is.EqualTo("resourceGroupName"));
                Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.ResourceGroupName"));
                Assert.That(contextualParameters[2].Key, Is.EqualTo("virtualMachines"));
                Assert.That(contextualParameters[2].VariableName, Is.EqualTo("name"));
                Assert.That(contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
            });
        }

        [TestCase]
        public void ValidateContextualParameters_ResourceGroupResource_ChildResource()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{name}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.That(contextualParameters.Count, Is.EqualTo(4));
            Assert.Multiple(() =>
            {
                Assert.That(contextualParameters[0].Key, Is.EqualTo("subscriptions"));
                Assert.That(contextualParameters[0].VariableName, Is.EqualTo("subscriptionId"));
                Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.SubscriptionId"));
                Assert.That(contextualParameters[1].Key, Is.EqualTo("resourceGroups"));
                Assert.That(contextualParameters[1].VariableName, Is.EqualTo("resourceGroupName"));
                Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.ResourceGroupName"));
                Assert.That(contextualParameters[2].Key, Is.EqualTo("virtualMachines"));
                Assert.That(contextualParameters[2].VariableName, Is.EqualTo("vmName"));
                Assert.That(contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Name"));
                Assert.That(contextualParameters[3].Key, Is.EqualTo("extensions"));
                Assert.That(contextualParameters[3].VariableName, Is.EqualTo("name"));
                Assert.That(contextualParameters[3].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
            });
        }

        [TestCase]
        public void ValidateContextualParameters_ResourceGroupResource_GrandChildResource()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{extensionName}/childResources/{name}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.That(contextualParameters.Count, Is.EqualTo(5));
            Assert.Multiple(() =>
            {
                Assert.That(contextualParameters[0].Key, Is.EqualTo("subscriptions"));
                Assert.That(contextualParameters[0].VariableName, Is.EqualTo("subscriptionId"));
                Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.SubscriptionId"));
                Assert.That(contextualParameters[1].Key, Is.EqualTo("resourceGroups"));
                Assert.That(contextualParameters[1].VariableName, Is.EqualTo("resourceGroupName"));
                Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.ResourceGroupName"));
                Assert.That(contextualParameters[2].Key, Is.EqualTo("virtualMachines"));
                Assert.That(contextualParameters[2].VariableName, Is.EqualTo("vmName"));
                Assert.That(contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Parent.Name"));
                Assert.That(contextualParameters[3].Key, Is.EqualTo("extensions"));
                Assert.That(contextualParameters[3].VariableName, Is.EqualTo("extensionName"));
                Assert.That(contextualParameters[3].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Name"));
                Assert.That(contextualParameters[4].Key, Is.EqualTo("childResources"));
                Assert.That(contextualParameters[4].VariableName, Is.EqualTo("name"));
                Assert.That(contextualParameters[4].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
            });
        }

        [TestCase]
        public void ValidateContextualParameters_SubscriptionResource()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/providers/Microsoft.Example/examples/{name}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.That(contextualParameters.Count, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(contextualParameters[0].Key, Is.EqualTo("subscriptions"));
                Assert.That(contextualParameters[0].VariableName, Is.EqualTo("subscriptionId"));
                Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.SubscriptionId"));
                Assert.That(contextualParameters[1].Key, Is.EqualTo("examples"));
                Assert.That(contextualParameters[1].VariableName, Is.EqualTo("name"));
                Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
            });
        }

        [TestCase]
        public void ValidateContextualParameters_SubscriptionResource_ChildResource()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/providers/Microsoft.Example/examples/{exampleName}/childResources/{name}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.That(contextualParameters.Count, Is.EqualTo(3));
            Assert.Multiple(() =>
            {
                Assert.That(contextualParameters[0].Key, Is.EqualTo("subscriptions"));
                Assert.That(contextualParameters[0].VariableName, Is.EqualTo("subscriptionId"));
                Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.SubscriptionId"));
                Assert.That(contextualParameters[1].Key, Is.EqualTo("examples"));
                Assert.That(contextualParameters[1].VariableName, Is.EqualTo("exampleName"));
                Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Name"));
                Assert.That(contextualParameters[2].Key, Is.EqualTo("childResources"));
                Assert.That(contextualParameters[2].VariableName, Is.EqualTo("name"));
                Assert.That(contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
            });
        }

        [TestCase]
        public void ValidateContextualParameters_SubscriptionResource_GrandChildResource()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/providers/Microsoft.Example/examples/{exampleName}/childResources/{childName}/grandChildResources/{name}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.That(contextualParameters.Count, Is.EqualTo(4));
            Assert.Multiple(() =>
            {
                Assert.That(contextualParameters[0].Key, Is.EqualTo("subscriptions"));
                Assert.That(contextualParameters[0].VariableName, Is.EqualTo("subscriptionId"));
                Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.SubscriptionId"));
                Assert.That(contextualParameters[1].Key, Is.EqualTo("examples"));
                Assert.That(contextualParameters[1].VariableName, Is.EqualTo("exampleName"));
                Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Parent.Name"));
                Assert.That(contextualParameters[2].Key, Is.EqualTo("childResources"));
                Assert.That(contextualParameters[2].VariableName, Is.EqualTo("childName"));
                Assert.That(contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Name"));
                Assert.That(contextualParameters[3].Key, Is.EqualTo("grandChildResources"));
                Assert.That(contextualParameters[3].VariableName, Is.EqualTo("name"));
                Assert.That(contextualParameters[3].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
            });
        }

        [TestCase]
        public void ValidateContextualParameters_ManagementGroupResource()
        {
            var requestPathPattern = new RequestPathPattern("/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Example/examples/{name}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.That(contextualParameters.Count, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(contextualParameters[0].Key, Is.EqualTo("managementGroups"));
                Assert.That(contextualParameters[0].VariableName, Is.EqualTo("managementGroupId"));
                Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Name"));
                Assert.That(contextualParameters[1].Key, Is.EqualTo("examples"));
                Assert.That(contextualParameters[1].VariableName, Is.EqualTo("name"));
                Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
            });
        }

        [TestCase]
        public void ValidateContextualParameters_ManagementGroupResource_ChildResource()
        {
            var requestPathPattern = new RequestPathPattern("/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Example/examples/{exampleName}/childResources/{name}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.That(contextualParameters.Count, Is.EqualTo(3));
            Assert.Multiple(() =>
            {
                Assert.That(contextualParameters[0].Key, Is.EqualTo("managementGroups"));
                Assert.That(contextualParameters[0].VariableName, Is.EqualTo("managementGroupId"));
                Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Parent.Name"));
                Assert.That(contextualParameters[1].Key, Is.EqualTo("examples"));
                Assert.That(contextualParameters[1].VariableName, Is.EqualTo("exampleName"));
                Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Name"));
                Assert.That(contextualParameters[2].Key, Is.EqualTo("childResources"));
                Assert.That(contextualParameters[2].VariableName, Is.EqualTo("name"));
                Assert.That(contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
            });
        }

        [TestCase]
        public void ValidateContextualParameters_ManagementGroupResource_GrandChildResource()
        {
            var requestPathPattern = new RequestPathPattern("/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Example/examples/{exampleName}/childResources/{childName}/grandChildResources/{name}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.That(contextualParameters.Count, Is.EqualTo(4));
            Assert.Multiple(() =>
            {
                Assert.That(contextualParameters[0].Key, Is.EqualTo("managementGroups"));
                Assert.That(contextualParameters[0].VariableName, Is.EqualTo("managementGroupId"));
                Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Parent.Parent.Name"));
                Assert.That(contextualParameters[1].Key, Is.EqualTo("examples"));
                Assert.That(contextualParameters[1].VariableName, Is.EqualTo("exampleName"));
                Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Parent.Name"));
                Assert.That(contextualParameters[2].Key, Is.EqualTo("childResources"));
                Assert.That(contextualParameters[2].VariableName, Is.EqualTo("childName"));
                Assert.That(contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Name"));
                Assert.That(contextualParameters[3].Key, Is.EqualTo("grandChildResources"));
                Assert.That(contextualParameters[3].VariableName, Is.EqualTo("name"));
                Assert.That(contextualParameters[3].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
            });
        }

        [TestCase]
        public void ValidateContextualParameters_ProviderNamespaceAsAVariable()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}/examples/{name}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.That(contextualParameters.Count, Is.EqualTo(3));
            Assert.Multiple(() =>
            {
                Assert.That(contextualParameters[0].Key, Is.EqualTo("subscriptions"));
                Assert.That(contextualParameters[0].VariableName, Is.EqualTo("subscriptionId"));
                Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.SubscriptionId"));
                Assert.That(contextualParameters[1].Key, Is.EqualTo("providers"));
                Assert.That(contextualParameters[1].VariableName, Is.EqualTo("resourceProviderNamespace"));
                Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.ResourceType.Namespace"));
                Assert.That(contextualParameters[2].Key, Is.EqualTo("examples"));
                Assert.That(contextualParameters[2].VariableName, Is.EqualTo("name"));
                Assert.That(contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
            });
        }

        [TestCase]
        public void ValidateContextualParameters_ExtensionResource()
        {
            var requestPathPattern = new RequestPathPattern("/{resourceUri}/providers/Microsoft.Example/examples/{exampleName}/childResources/{name}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.Multiple(() =>
            {
                Assert.That(contextualParameters[0].Key, Is.EqualTo("resourceUri"));
                Assert.That(contextualParameters[0].VariableName, Is.EqualTo("resourceUri"));
                Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Parent"));
                Assert.That(contextualParameters.Count, Is.EqualTo(3));
            });
            Assert.Multiple(() =>
            {
                Assert.That(contextualParameters[1].Key, Is.EqualTo("examples"));
                Assert.That(contextualParameters[1].VariableName, Is.EqualTo("exampleName"));
                Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Name"));
                Assert.That(contextualParameters[2].Key, Is.EqualTo("childResources"));
                Assert.That(contextualParameters[2].VariableName, Is.EqualTo("name"));
                Assert.That(contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
            });
        }

        [TestCase]
        public void ValidateContextualParameters_SubscriptionSingletonResource()
        {
            // This test case represents the Spot Placement Scores scenario
            // Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/placementScores/spot
            // This is a singleton resource (ends with constant "spot")
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/placementScores/spot");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);

            Assert.That(contextualParameters.Count, Is.EqualTo(2), "Should have subscriptionId and location parameters");

            Assert.Multiple(() =>
            {
                Assert.That(contextualParameters[0].Key, Is.EqualTo("subscriptions"));
                Assert.That(contextualParameters[0].VariableName, Is.EqualTo("subscriptionId"));
                Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.SubscriptionId"));

                Assert.That(contextualParameters[1].Key, Is.EqualTo("locations"));
                Assert.That(contextualParameters[1].VariableName, Is.EqualTo("location"));
                // For a singleton resource, the location should be extracted from Id.Parent.Name
                // because Id.Name would return "spot" (the singleton name)
                Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Name"));
            });
        }
    }
}
