// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Models;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using NUnit.Framework;

namespace Azure.Generator.Mgmt.Tests
{
    public class OperationContextTests
    {
        private readonly ScopedApi<ResourceIdentifier> _idVariable;

        public OperationContextTests()
        {
            _idVariable = new ParameterProvider("id", $"", typeof(ResourceIdentifier)).As<ResourceIdentifier>();
        }

        [TestCase]
        public void ValidateContextualParameters_Tenant()
        {
            var requestPathPattern = new RequestPathPattern(string.Empty);
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
            Assert.AreEqual(0, contextualParameters.Count, "Tenant path should not have any contextual parameters.");
        }

        [TestCase]
        public void ValidateContextualParameters_Subscription()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}");
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;

            Assert.AreEqual(1, contextualParameters.Count);
            Assert.AreEqual("subscriptions", contextualParameters[0].Key);
            Assert.AreEqual("subscriptionId", contextualParameters[0].VariableName);

            Assert.AreEqual("id.SubscriptionId", contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString());
        }

        [TestCase]
        public void ValidateContextualParameters_ResourceGroup()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}");
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;

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
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
            Assert.AreEqual(1, contextualParameters.Count);
            Assert.AreEqual("managementGroups", contextualParameters[0].Key);
            Assert.AreEqual("managementGroupId", contextualParameters[0].VariableName);
            Assert.AreEqual("id.Name", contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString());
        }

        [TestCase]
        public void ValidateContextualParameters_TenantResource()
        {
            var requestPathPattern = new RequestPathPattern("/providers/Microsoft.Example/examples/{name}");
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
            Assert.AreEqual(1, contextualParameters.Count);
            Assert.AreEqual("examples", contextualParameters[0].Key);
            Assert.AreEqual("name", contextualParameters[0].VariableName);
            Assert.AreEqual("id.Name", contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString());
        }

        [TestCase]
        public void ValidateContextualParameters_TenantResource_ChildResource()
        {
            var requestPathPattern = new RequestPathPattern("/providers/Microsoft.Example/examples/{exampleName}/childResources/{name}");
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
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
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
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
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
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
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
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
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
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
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
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
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
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
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
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
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
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
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
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
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
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
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
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
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
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
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;

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

        /*
        [Test]
        public void ValidateParameterMapping_ComputeFleetScenario()
        {
            // This test validates the fix for issue #54817
            // Contextual path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureFleet/fleets/{fleetName}
            // Operation path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureFleet/fleets/{name}/virtualMachineScaleSets
            // The {name} parameter in the operation path should match {fleetName} in the contextual path because they both follow the "fleets" key

            var contextualPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureFleet/fleets/{fleetName}");
            var contextualPath = new ContextualPath(contextualPathPattern);
            var operationPath = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureFleet/fleets/{name}/virtualMachineScaleSets");

            var registry = contextualPath.BuildParameterMapping(operationPath);

            // The "name" parameter from operation path should map to contextual parameter with key "fleets" and variableName "fleetName"
            Assert.IsTrue(registry.TryGetValue("name", out var nameMapping));
            Assert.IsNotNull(nameMapping.ContextualParameter);
            Assert.AreEqual("fleets", nameMapping.ContextualParameter!.Key);
            Assert.AreEqual("fleetName", nameMapping.ContextualParameter!.VariableName);

            // subscriptionId and resourceGroupName should also map correctly
            Assert.IsTrue(registry.TryGetValue("subscriptionId", out var subscriptionMapping));
            Assert.AreEqual("subscriptions", subscriptionMapping.ContextualParameter!.Key);
            Assert.AreEqual("subscriptionId", subscriptionMapping.ContextualParameter!.VariableName);

            Assert.IsTrue(registry.TryGetValue("resourceGroupName", out var resourceGroupMapping));
            Assert.AreEqual("resourceGroups", resourceGroupMapping.ContextualParameter!.Key);
            Assert.AreEqual("resourceGroupName", resourceGroupMapping.ContextualParameter!.VariableName);
        }

        [Test]
        public void ValidateParameterMapping_DifferentParameterNames()
        {
            // Test case where operation parameters have different names than contextual parameters
            // but should still match by key
            var contextualPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Example/examples/{exampleName}");
            var contextualPath = new ContextualPath(contextualPathPattern);
            var operationPath = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Example/examples/{name}/children/{childName}");

            var registry = contextualPath.BuildParameterMapping(operationPath);

            // "name" should match "exampleName" because both follow "examples" key
            Assert.IsTrue(registry.TryGetValue("name", out var nameMapping));
            Assert.AreEqual("examples", nameMapping.ContextualParameter!.Key);
            Assert.AreEqual("exampleName", nameMapping.ContextualParameter!.VariableName);

            // "childName" should not match anything in contextual path (it's a pass-through parameter)
            Assert.IsTrue(registry.TryGetValue("childName", out var childMapping));
            Assert.IsFalse(childMapping.IsContextual);
        }

        [Test]
        public void ValidateParameterMapping_SameParameterNames()
        {
            // Test case where parameter names match exactly
            var contextualPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}");
            var contextualPath = new ContextualPath(contextualPathPattern);
            var operationPath = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{name}");

            var registry = contextualPath.BuildParameterMapping(operationPath);

            // All matching parameters should be found
            Assert.IsTrue(registry.TryGetValue("subscriptionId", out var subscriptionMapping));
            Assert.IsTrue(subscriptionMapping.IsContextual);
            Assert.IsTrue(registry.TryGetValue("resourceGroupName", out var resourceGroupMapping));
            Assert.IsTrue(resourceGroupMapping.IsContextual);
            Assert.IsTrue(registry.TryGetValue("vmName", out var vmMapping));
            Assert.IsTrue(vmMapping.IsContextual);

            // "name" is a pass-through parameter (not in contextual path)
            Assert.IsTrue(registry.TryGetValue("name", out var nameMapping));
            Assert.IsFalse(nameMapping.IsContextual);
        }

        [Test]
        public void ValidateParameterMapping_EmptyContextualPath()
        {
            // Test with tenant-level operations
            var contextualPath = new ContextualPath(RequestPathPattern.Tenant);
            var operationPath = new RequestPathPattern("/subscriptions/{subscriptionId}");

            var registry = contextualPath.BuildParameterMapping(operationPath);

            // No contextual parameters available, so subscriptionId should not be contextual
            Assert.IsTrue(registry.TryGetValue("subscriptionId", out var subscriptionMapping));
            Assert.IsFalse(subscriptionMapping.IsContextual);
        }
        */
    }
}
