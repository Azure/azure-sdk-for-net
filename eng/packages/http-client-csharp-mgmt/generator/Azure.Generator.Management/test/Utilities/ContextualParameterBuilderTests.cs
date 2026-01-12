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
            Assert.AreEqual(0, contextualParameters.Count, "Tenant path should not have any contextual parameters.");
        }

        [TestCase]
        public void ValidateContextualParameters_Subscription()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}");

            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);

            Assert.AreEqual(1, contextualParameters.Count);
            Assert.AreEqual("subscriptions", contextualParameters[0].Key);
            Assert.AreEqual("subscriptionId", contextualParameters[0].VariableName);

            Assert.AreEqual("id.SubscriptionId", contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString());
        }

        [TestCase]
        public void ValidateContextualParameters_ResourceGroup()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}");

            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);

            Assert.AreEqual(2, contextualParameters.Count);
            Assert.AreEqual("subscriptions", contextualParameters[0].Key);
            Assert.AreEqual("subscriptionId", contextualParameters[0].VariableName);
            Assert.AreEqual("resourceGroups", contextualParameters[1].Key);
            Assert.AreEqual("resourceGroupName", contextualParameters[1].VariableName);

            Assert.AreEqual("id.SubscriptionId", contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("id.ResourceGroupName", contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString());
        }

        [TestCase]
        public void ValidateContextualParameters_ManagementGroup()
        {
            var requestPathPattern = new RequestPathPattern("/providers/Microsoft.Management/managementGroups/{managementGroupId}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.AreEqual(1, contextualParameters.Count);
            Assert.AreEqual("managementGroups", contextualParameters[0].Key);
            Assert.AreEqual("managementGroupId", contextualParameters[0].VariableName);
            Assert.AreEqual("id.Name", contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString());
        }

        [TestCase]
        public void ValidateContextualParameters_TenantResource()
        {
            var requestPathPattern = new RequestPathPattern("/providers/Microsoft.Example/examples/{name}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.AreEqual(1, contextualParameters.Count);
            Assert.AreEqual("examples", contextualParameters[0].Key);
            Assert.AreEqual("name", contextualParameters[0].VariableName);
            Assert.AreEqual("id.Name", contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString());
        }

        [TestCase]
        public void ValidateContextualParameters_TenantResource_ChildResource()
        {
            var requestPathPattern = new RequestPathPattern("/providers/Microsoft.Example/examples/{exampleName}/childResources/{name}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.AreEqual(2, contextualParameters.Count);
            Assert.AreEqual("examples", contextualParameters[0].Key);
            Assert.AreEqual("exampleName", contextualParameters[0].VariableName);
            Assert.AreEqual("id.Parent.Name", contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("childResources", contextualParameters[1].Key);
            Assert.AreEqual("name", contextualParameters[1].VariableName);
            Assert.AreEqual("id.Name", contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString());
        }

        [TestCase]
        public void ValidateContextualParameters_TenantResource_GrandChildResource()
        {
            var requestPathPattern = new RequestPathPattern("/providers/Microsoft.Example/examples/{exampleName}/childResources/{childName}/grandChildResources/{name}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.AreEqual(3, contextualParameters.Count);
            Assert.AreEqual("examples", contextualParameters[0].Key);
            Assert.AreEqual("exampleName", contextualParameters[0].VariableName);
            Assert.AreEqual("id.Parent.Parent.Name", contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("childResources", contextualParameters[1].Key);
            Assert.AreEqual("childName", contextualParameters[1].VariableName);
            Assert.AreEqual("id.Parent.Name", contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("grandChildResources", contextualParameters[2].Key);
            Assert.AreEqual("name", contextualParameters[2].VariableName);
            Assert.AreEqual("id.Name", contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString());
        }

        [TestCase]
        public void ValidateContextualParameters_ResourceGroupResource()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{name}");

            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.AreEqual(3, contextualParameters.Count);
            Assert.AreEqual("subscriptions", contextualParameters[0].Key);
            Assert.AreEqual("subscriptionId", contextualParameters[0].VariableName);
            Assert.AreEqual("id.SubscriptionId", contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("resourceGroups", contextualParameters[1].Key);
            Assert.AreEqual("resourceGroupName", contextualParameters[1].VariableName);
            Assert.AreEqual("id.ResourceGroupName", contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("virtualMachines", contextualParameters[2].Key);
            Assert.AreEqual("name", contextualParameters[2].VariableName);
            Assert.AreEqual("id.Name", contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString());
        }

        [TestCase]
        public void ValidateContextualParameters_ResourceGroupResource_ChildResource()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{name}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.AreEqual(4, contextualParameters.Count);
            Assert.AreEqual("subscriptions", contextualParameters[0].Key);
            Assert.AreEqual("subscriptionId", contextualParameters[0].VariableName);
            Assert.AreEqual("id.SubscriptionId", contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("resourceGroups", contextualParameters[1].Key);
            Assert.AreEqual("resourceGroupName", contextualParameters[1].VariableName);
            Assert.AreEqual("id.ResourceGroupName", contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("virtualMachines", contextualParameters[2].Key);
            Assert.AreEqual("vmName", contextualParameters[2].VariableName);
            Assert.AreEqual("id.Parent.Name", contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("extensions", contextualParameters[3].Key);
            Assert.AreEqual("name", contextualParameters[3].VariableName);
            Assert.AreEqual("id.Name", contextualParameters[3].BuildValueExpression(_idVariable).ToDisplayString());
        }

        [TestCase]
        public void ValidateContextualParameters_ResourceGroupResource_GrandChildResource()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{extensionName}/childResources/{name}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.AreEqual(5, contextualParameters.Count);
            Assert.AreEqual("subscriptions", contextualParameters[0].Key);
            Assert.AreEqual("subscriptionId", contextualParameters[0].VariableName);
            Assert.AreEqual("id.SubscriptionId", contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("resourceGroups", contextualParameters[1].Key);
            Assert.AreEqual("resourceGroupName", contextualParameters[1].VariableName);
            Assert.AreEqual("id.ResourceGroupName", contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("virtualMachines", contextualParameters[2].Key);
            Assert.AreEqual("vmName", contextualParameters[2].VariableName);
            Assert.AreEqual("id.Parent.Parent.Name", contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("extensions", contextualParameters[3].Key);
            Assert.AreEqual("extensionName", contextualParameters[3].VariableName);
            Assert.AreEqual("id.Parent.Name", contextualParameters[3].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("childResources", contextualParameters[4].Key);
            Assert.AreEqual("name", contextualParameters[4].VariableName);
            Assert.AreEqual("id.Name", contextualParameters[4].BuildValueExpression(_idVariable).ToDisplayString());
        }

        [TestCase]
        public void ValidateContextualParameters_SubscriptionResource()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/providers/Microsoft.Example/examples/{name}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.AreEqual(2, contextualParameters.Count);
            Assert.AreEqual("subscriptions", contextualParameters[0].Key);
            Assert.AreEqual("subscriptionId", contextualParameters[0].VariableName);
            Assert.AreEqual("id.SubscriptionId", contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("examples", contextualParameters[1].Key);
            Assert.AreEqual("name", contextualParameters[1].VariableName);
            Assert.AreEqual("id.Name", contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString());
        }

        [TestCase]
        public void ValidateContextualParameters_SubscriptionResource_ChildResource()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/providers/Microsoft.Example/examples/{exampleName}/childResources/{name}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.AreEqual(3, contextualParameters.Count);
            Assert.AreEqual("subscriptions", contextualParameters[0].Key);
            Assert.AreEqual("subscriptionId", contextualParameters[0].VariableName);
            Assert.AreEqual("id.SubscriptionId", contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("examples", contextualParameters[1].Key);
            Assert.AreEqual("exampleName", contextualParameters[1].VariableName);
            Assert.AreEqual("id.Parent.Name", contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("childResources", contextualParameters[2].Key);
            Assert.AreEqual("name", contextualParameters[2].VariableName);
            Assert.AreEqual("id.Name", contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString());
        }

        [TestCase]
        public void ValidateContextualParameters_SubscriptionResource_GrandChildResource()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/providers/Microsoft.Example/examples/{exampleName}/childResources/{childName}/grandChildResources/{name}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.AreEqual(4, contextualParameters.Count);
            Assert.AreEqual("subscriptions", contextualParameters[0].Key);
            Assert.AreEqual("subscriptionId", contextualParameters[0].VariableName);
            Assert.AreEqual("id.SubscriptionId", contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("examples", contextualParameters[1].Key);
            Assert.AreEqual("exampleName", contextualParameters[1].VariableName);
            Assert.AreEqual("id.Parent.Parent.Name", contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("childResources", contextualParameters[2].Key);
            Assert.AreEqual("childName", contextualParameters[2].VariableName);
            Assert.AreEqual("id.Parent.Name", contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("grandChildResources", contextualParameters[3].Key);
            Assert.AreEqual("name", contextualParameters[3].VariableName);
            Assert.AreEqual("id.Name", contextualParameters[3].BuildValueExpression(_idVariable).ToDisplayString());
        }

        [TestCase]
        public void ValidateContextualParameters_ManagementGroupResource()
        {
            var requestPathPattern = new RequestPathPattern("/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Example/examples/{name}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.AreEqual(2, contextualParameters.Count);
            Assert.AreEqual("managementGroups", contextualParameters[0].Key);
            Assert.AreEqual("managementGroupId", contextualParameters[0].VariableName);
            Assert.AreEqual("id.Parent.Name", contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("examples", contextualParameters[1].Key);
            Assert.AreEqual("name", contextualParameters[1].VariableName);
            Assert.AreEqual("id.Name", contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString());
        }

        [TestCase]
        public void ValidateContextualParameters_ManagementGroupResource_ChildResource()
        {
            var requestPathPattern = new RequestPathPattern("/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Example/examples/{exampleName}/childResources/{name}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.AreEqual(3, contextualParameters.Count);
            Assert.AreEqual("managementGroups", contextualParameters[0].Key);
            Assert.AreEqual("managementGroupId", contextualParameters[0].VariableName);
            Assert.AreEqual("id.Parent.Parent.Name", contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("examples", contextualParameters[1].Key);
            Assert.AreEqual("exampleName", contextualParameters[1].VariableName);
            Assert.AreEqual("id.Parent.Name", contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("childResources", contextualParameters[2].Key);
            Assert.AreEqual("name", contextualParameters[2].VariableName);
            Assert.AreEqual("id.Name", contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString());
        }

        [TestCase]
        public void ValidateContextualParameters_ManagementGroupResource_GrandChildResource()
        {
            var requestPathPattern = new RequestPathPattern("/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Example/examples/{exampleName}/childResources/{childName}/grandChildResources/{name}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.AreEqual(4, contextualParameters.Count);
            Assert.AreEqual("managementGroups", contextualParameters[0].Key);
            Assert.AreEqual("managementGroupId", contextualParameters[0].VariableName);
            Assert.AreEqual("id.Parent.Parent.Parent.Name", contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("examples", contextualParameters[1].Key);
            Assert.AreEqual("exampleName", contextualParameters[1].VariableName);
            Assert.AreEqual("id.Parent.Parent.Name", contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("childResources", contextualParameters[2].Key);
            Assert.AreEqual("childName", contextualParameters[2].VariableName);
            Assert.AreEqual("id.Parent.Name", contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("grandChildResources", contextualParameters[3].Key);
            Assert.AreEqual("name", contextualParameters[3].VariableName);
            Assert.AreEqual("id.Name", contextualParameters[3].BuildValueExpression(_idVariable).ToDisplayString());
        }

        [TestCase]
        public void ValidateContextualParameters_ProviderNamespaceAsAVariable()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}/examples/{name}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.AreEqual(3, contextualParameters.Count);
            Assert.AreEqual("subscriptions", contextualParameters[0].Key);
            Assert.AreEqual("subscriptionId", contextualParameters[0].VariableName);
            Assert.AreEqual("id.SubscriptionId", contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("providers", contextualParameters[1].Key);
            Assert.AreEqual("resourceProviderNamespace", contextualParameters[1].VariableName);
            Assert.AreEqual("id.ResourceType.Namespace", contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("examples", contextualParameters[2].Key);
            Assert.AreEqual("name", contextualParameters[2].VariableName);
            Assert.AreEqual("id.Name", contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString());
        }

        [TestCase]
        public void ValidateContextualParameters_ExtensionResource()
        {
            var requestPathPattern = new RequestPathPattern("/{resourceUri}/providers/Microsoft.Example/examples/{exampleName}/childResources/{name}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.AreEqual("resourceUri", contextualParameters[0].Key);
            Assert.AreEqual("resourceUri", contextualParameters[0].VariableName);
            Assert.AreEqual("id.Parent.Parent", contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual(3, contextualParameters.Count);
            Assert.AreEqual("examples", contextualParameters[1].Key);
            Assert.AreEqual("exampleName", contextualParameters[1].VariableName);
            Assert.AreEqual("id.Parent.Name", contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString());
            Assert.AreEqual("childResources", contextualParameters[2].Key);
            Assert.AreEqual("name", contextualParameters[2].VariableName);
            Assert.AreEqual("id.Name", contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString());
        }

        [TestCase]
        public void ValidateContextualParameters_SubscriptionSingletonResource()
        {
            // This test case represents the Spot Placement Scores scenario
            // Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/placementScores/spot
            // This is a singleton resource (ends with constant "spot")
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/placementScores/spot");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);

            Assert.AreEqual(2, contextualParameters.Count, "Should have subscriptionId and location parameters");

            Assert.AreEqual("subscriptions", contextualParameters[0].Key);
            Assert.AreEqual("subscriptionId", contextualParameters[0].VariableName);
            Assert.AreEqual("id.SubscriptionId", contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString());

            Assert.AreEqual("locations", contextualParameters[1].Key);
            Assert.AreEqual("location", contextualParameters[1].VariableName);
            // For a singleton resource, the location should be extracted from Id.Parent.Name
            // because Id.Name would return "spot" (the singleton name)
            Assert.AreEqual("id.Parent.Name", contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString());
        }

        [Test]
        public void ValidateParameterMapping_ComputeFleetScenario()
        {
            // This test validates the fix for issue #54817
            // Contextual path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureFleet/fleets/{fleetName}
            // Operation path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureFleet/fleets/{name}/virtualMachineScaleSets
            // The {name} parameter in the operation path should match {fleetName} in the contextual path because they both follow the "fleets" key

            var contextualPath = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureFleet/fleets/{fleetName}");
            var operationPath = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureFleet/fleets/{name}/virtualMachineScaleSets");

            var mapping = ContextualParameterBuilder.BuildParameterMapping(contextualPath, operationPath);

            // The "name" parameter from operation path should map to contextual parameter with key "fleets" and variableName "fleetName"
            Assert.IsTrue(mapping.TryGetContextualParameter("name", out var contextualParameter));
            Assert.IsNotNull(contextualParameter);
            Assert.AreEqual("fleets", contextualParameter!.Key);
            Assert.AreEqual("fleetName", contextualParameter!.VariableName);

            // subscriptionId and resourceGroupName should also map correctly
            Assert.IsTrue(mapping.TryGetContextualParameter("subscriptionId", out var subscriptionParam));
            Assert.AreEqual("subscriptions", subscriptionParam!.Key);
            Assert.AreEqual("subscriptionId", subscriptionParam!.VariableName);

            Assert.IsTrue(mapping.TryGetContextualParameter("resourceGroupName", out var resourceGroupParam));
            Assert.AreEqual("resourceGroups", resourceGroupParam!.Key);
            Assert.AreEqual("resourceGroupName", resourceGroupParam!.VariableName);
        }

        [Test]
        public void ValidateParameterMapping_DifferentParameterNames()
        {
            // Test case where operation parameters have different names than contextual parameters
            // but should still match by key
            var contextualPath = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Example/examples/{exampleName}");
            var operationPath = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Example/examples/{name}/children/{childName}");

            var mapping = ContextualParameterBuilder.BuildParameterMapping(contextualPath, operationPath);

            // "name" should match "exampleName" because both follow "examples" key
            Assert.IsTrue(mapping.TryGetContextualParameter("name", out var exampleParam));
            Assert.AreEqual("examples", exampleParam!.Key);
            Assert.AreEqual("exampleName", exampleParam!.VariableName);

            // "childName" should not match anything in contextual path (it's a pass-through parameter)
            Assert.IsFalse(mapping.TryGetContextualParameter("childName", out _));
        }

        [Test]
        public void ValidateParameterMapping_SameParameterNames()
        {
            // Test case where parameter names match exactly
            var contextualPath = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}");
            var operationPath = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{name}");

            var mapping = ContextualParameterBuilder.BuildParameterMapping(contextualPath, operationPath);

            // All matching parameters should be found
            Assert.IsTrue(mapping.TryGetContextualParameter("subscriptionId", out _));
            Assert.IsTrue(mapping.TryGetContextualParameter("resourceGroupName", out _));
            Assert.IsTrue(mapping.TryGetContextualParameter("vmName", out _));

            // "name" is a pass-through parameter (not in contextual path)
            Assert.IsFalse(mapping.TryGetContextualParameter("name", out _));
        }

        [Test]
        public void ValidateParameterMapping_EmptyContextualPath()
        {
            // Test with tenant-level operations
            var contextualPath = RequestPathPattern.Tenant;
            var operationPath = new RequestPathPattern("/subscriptions/{subscriptionId}");

            var mapping = ContextualParameterBuilder.BuildParameterMapping(contextualPath, operationPath);

            // No contextual parameters available, so nothing should match
            Assert.IsFalse(mapping.TryGetContextualParameter("subscriptionId", out _));
        }
    }
}
