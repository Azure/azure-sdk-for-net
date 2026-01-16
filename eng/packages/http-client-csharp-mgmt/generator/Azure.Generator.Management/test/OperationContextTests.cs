// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Models;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using NUnit.Framework;
using System;
using System.Collections.Generic;

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
            Assert.That(contextualParameters.Count, Is.EqualTo(0), "Tenant path should not have any contextual parameters.");
        }

        [TestCase]
        public void ValidateContextualParameters_Subscription()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}");
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;

            Assert.That(contextualParameters.Count, Is.EqualTo(1));
            Assert.That(contextualParameters[0].Key, Is.EqualTo("subscriptions"));
            Assert.That(contextualParameters[0].VariableName, Is.EqualTo("subscriptionId"));

            Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.SubscriptionId"));
        }

        [TestCase]
        public void ValidateContextualParameters_ResourceGroup()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}");
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;

            Assert.That(contextualParameters.Count, Is.EqualTo(2));
            Assert.That(contextualParameters[0].Key, Is.EqualTo("subscriptions"));
            Assert.That(contextualParameters[0].VariableName, Is.EqualTo("subscriptionId"));
            Assert.That(contextualParameters[1].Key, Is.EqualTo("resourceGroups"));
            Assert.That(contextualParameters[1].VariableName, Is.EqualTo("resourceGroupName"));

            Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.SubscriptionId"));
            Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.ResourceGroupName"));
        }

        [TestCase]
        public void ValidateContextualParameters_ManagementGroup()
        {
            var requestPathPattern = new RequestPathPattern("/providers/Microsoft.Management/managementGroups/{managementGroupId}");
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
            Assert.That(contextualParameters.Count, Is.EqualTo(1));
            Assert.That(contextualParameters[0].Key, Is.EqualTo("managementGroups"));
            Assert.That(contextualParameters[0].VariableName, Is.EqualTo("managementGroupId"));
            Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
        }

        [TestCase]
        public void ValidateContextualParameters_TenantResource()
        {
            var requestPathPattern = new RequestPathPattern("/providers/Microsoft.Example/examples/{name}");
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
            Assert.That(contextualParameters.Count, Is.EqualTo(1));
            Assert.That(contextualParameters[0].Key, Is.EqualTo("examples"));
            Assert.That(contextualParameters[0].VariableName, Is.EqualTo("name"));
            Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
        }

        [TestCase]
        public void ValidateContextualParameters_TenantResource_ChildResource()
        {
            var requestPathPattern = new RequestPathPattern("/providers/Microsoft.Example/examples/{exampleName}/childResources/{name}");
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
            Assert.That(contextualParameters.Count, Is.EqualTo(2));
            Assert.That(contextualParameters[0].Key, Is.EqualTo("examples"));
            Assert.That(contextualParameters[0].VariableName, Is.EqualTo("exampleName"));
            Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Name"));
            Assert.That(contextualParameters[1].Key, Is.EqualTo("childResources"));
            Assert.That(contextualParameters[1].VariableName, Is.EqualTo("name"));
            Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
        }

        [TestCase]
        public void ValidateContextualParameters_TenantResource_GrandChildResource()
        {
            var requestPathPattern = new RequestPathPattern("/providers/Microsoft.Example/examples/{exampleName}/childResources/{childName}/grandChildResources/{name}");
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
            Assert.That(contextualParameters.Count, Is.EqualTo(3));
            Assert.That(contextualParameters[0].Key, Is.EqualTo("examples"));
            Assert.That(contextualParameters[0].VariableName, Is.EqualTo("exampleName"));
            Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Parent.Name"));
            Assert.That(contextualParameters[1].Key, Is.EqualTo("childResources"));
            Assert.That(contextualParameters[1].VariableName, Is.EqualTo("childName"));
            Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Name"));
            Assert.That(contextualParameters[2].Key, Is.EqualTo("grandChildResources"));
            Assert.That(contextualParameters[2].VariableName, Is.EqualTo("name"));
            Assert.That(contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
        }

        [TestCase]
        public void ValidateContextualParameters_ResourceGroupResource()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{name}");
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
            Assert.That(contextualParameters.Count, Is.EqualTo(3));
            Assert.That(contextualParameters[0].Key, Is.EqualTo("subscriptions"));
            Assert.That(contextualParameters[0].VariableName, Is.EqualTo("subscriptionId"));
            Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.SubscriptionId"));
            Assert.That(contextualParameters[1].Key, Is.EqualTo("resourceGroups"));
            Assert.That(contextualParameters[1].VariableName, Is.EqualTo("resourceGroupName"));
            Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.ResourceGroupName"));
            Assert.That(contextualParameters[2].Key, Is.EqualTo("virtualMachines"));
            Assert.That(contextualParameters[2].VariableName, Is.EqualTo("name"));
            Assert.That(contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
        }

        [TestCase]
        public void ValidateContextualParameters_ResourceGroupResource_ChildResource()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{name}");
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
            Assert.That(contextualParameters.Count, Is.EqualTo(4));
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
        }

        [TestCase]
        public void ValidateContextualParameters_ResourceGroupResource_GrandChildResource()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{extensionName}/childResources/{name}");
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
            Assert.That(contextualParameters.Count, Is.EqualTo(5));
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
        }

        [TestCase]
        public void ValidateContextualParameters_SubscriptionResource()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/providers/Microsoft.Example/examples/{name}");
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
            Assert.That(contextualParameters.Count, Is.EqualTo(2));
            Assert.That(contextualParameters[0].Key, Is.EqualTo("subscriptions"));
            Assert.That(contextualParameters[0].VariableName, Is.EqualTo("subscriptionId"));
            Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.SubscriptionId"));
            Assert.That(contextualParameters[1].Key, Is.EqualTo("examples"));
            Assert.That(contextualParameters[1].VariableName, Is.EqualTo("name"));
            Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
        }

        [TestCase]
        public void ValidateContextualParameters_SubscriptionResource_ChildResource()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/providers/Microsoft.Example/examples/{exampleName}/childResources/{name}");
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
            Assert.That(contextualParameters.Count, Is.EqualTo(3));
            Assert.That(contextualParameters[0].Key, Is.EqualTo("subscriptions"));
            Assert.That(contextualParameters[0].VariableName, Is.EqualTo("subscriptionId"));
            Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.SubscriptionId"));
            Assert.That(contextualParameters[1].Key, Is.EqualTo("examples"));
            Assert.That(contextualParameters[1].VariableName, Is.EqualTo("exampleName"));
            Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Name"));
            Assert.That(contextualParameters[2].Key, Is.EqualTo("childResources"));
            Assert.That(contextualParameters[2].VariableName, Is.EqualTo("name"));
            Assert.That(contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
        }

        [TestCase]
        public void ValidateContextualParameters_SubscriptionResource_GrandChildResource()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/providers/Microsoft.Example/examples/{exampleName}/childResources/{childName}/grandChildResources/{name}");
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
            Assert.That(contextualParameters.Count, Is.EqualTo(4));
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
        }

        [TestCase]
        public void ValidateContextualParameters_ManagementGroupResource()
        {
            var requestPathPattern = new RequestPathPattern("/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Example/examples/{name}");
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
            Assert.That(contextualParameters.Count, Is.EqualTo(2));
            Assert.That(contextualParameters[0].Key, Is.EqualTo("managementGroups"));
            Assert.That(contextualParameters[0].VariableName, Is.EqualTo("managementGroupId"));
            Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Name"));
            Assert.That(contextualParameters[1].Key, Is.EqualTo("examples"));
            Assert.That(contextualParameters[1].VariableName, Is.EqualTo("name"));
            Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
        }

        [TestCase]
        public void ValidateContextualParameters_ManagementGroupResource_ChildResource()
        {
            var requestPathPattern = new RequestPathPattern("/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Example/examples/{exampleName}/childResources/{name}");
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
            Assert.That(contextualParameters.Count, Is.EqualTo(3));
            Assert.That(contextualParameters[0].Key, Is.EqualTo("managementGroups"));
            Assert.That(contextualParameters[0].VariableName, Is.EqualTo("managementGroupId"));
            Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Parent.Name"));
            Assert.That(contextualParameters[1].Key, Is.EqualTo("examples"));
            Assert.That(contextualParameters[1].VariableName, Is.EqualTo("exampleName"));
            Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Name"));
            Assert.That(contextualParameters[2].Key, Is.EqualTo("childResources"));
            Assert.That(contextualParameters[2].VariableName, Is.EqualTo("name"));
            Assert.That(contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
        }

        [TestCase]
        public void ValidateContextualParameters_ManagementGroupResource_GrandChildResource()
        {
            var requestPathPattern = new RequestPathPattern("/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Example/examples/{exampleName}/childResources/{childName}/grandChildResources/{name}");
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
            Assert.That(contextualParameters.Count, Is.EqualTo(4));
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
        }

        [TestCase]
        public void ValidateContextualParameters_ProviderNamespaceAsAVariable()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}/examples/{name}");
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
            Assert.That(contextualParameters.Count, Is.EqualTo(3));
            Assert.That(contextualParameters[0].Key, Is.EqualTo("subscriptions"));
            Assert.That(contextualParameters[0].VariableName, Is.EqualTo("subscriptionId"));
            Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.SubscriptionId"));
            Assert.That(contextualParameters[1].Key, Is.EqualTo("providers"));
            Assert.That(contextualParameters[1].VariableName, Is.EqualTo("resourceProviderNamespace"));
            Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.ResourceType.Namespace"));
            Assert.That(contextualParameters[2].Key, Is.EqualTo("examples"));
            Assert.That(contextualParameters[2].VariableName, Is.EqualTo("name"));
            Assert.That(contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
        }

        [TestCase]
        public void ValidateContextualParameters_ExtensionResource()
        {
            var requestPathPattern = new RequestPathPattern("/{resourceUri}/providers/Microsoft.Example/examples/{exampleName}/childResources/{name}");
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;
            Assert.That(contextualParameters[0].Key, Is.EqualTo("resourceUri"));
            Assert.That(contextualParameters[0].VariableName, Is.EqualTo("resourceUri"));
            Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Parent"));
            Assert.That(contextualParameters.Count, Is.EqualTo(3));
            Assert.That(contextualParameters[1].Key, Is.EqualTo("examples"));
            Assert.That(contextualParameters[1].VariableName, Is.EqualTo("exampleName"));
            Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Name"));
            Assert.That(contextualParameters[2].Key, Is.EqualTo("childResources"));
            Assert.That(contextualParameters[2].VariableName, Is.EqualTo("name"));
            Assert.That(contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
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

            Assert.That(contextualParameters.Count, Is.EqualTo(2), "Should have subscriptionId and location parameters");

            Assert.That(contextualParameters[0].Key, Is.EqualTo("subscriptions"));
            Assert.That(contextualParameters[0].VariableName, Is.EqualTo("subscriptionId"));
            Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.SubscriptionId"));

            Assert.That(contextualParameters[1].Key, Is.EqualTo("locations"));
            Assert.That(contextualParameters[1].VariableName, Is.EqualTo("location"));
            // For a singleton resource, the location should be extracted from Id.Parent.Name
            // because Id.Name would return "spot" (the singleton name)
            Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Name"));
        }

        [Test]
        public void ValidateParameterMapping_OperationPathExtendsContextualPath()
        {
            // This test validates that when an operation path extends beyond the contextual path,
            // parameters in the shared portion are correctly mapped even if they have different names.
            // The {name} parameter in the operation path should match {fleetName} in the contextual path
            // because they both follow the same key segment.

            var contextualPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureFleet/fleets/{fleetName}");
            var operationContext = OperationContext.Create(contextualPathPattern);
            var operationPath = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureFleet/fleets/{name}/virtualMachineScaleSets");

            var registry = operationContext.BuildParameterMapping(operationPath);

            // The "name" parameter from operation path should map to contextual parameter with key "fleets" and variableName "fleetName"
            Assert.IsTrue(registry.TryGetValue("name", out var nameMapping));
            Assert.IsNotNull(nameMapping!.ContextualParameter);
            Assert.AreEqual("fleets", nameMapping.ContextualParameter!.Key);
            Assert.AreEqual("fleetName", nameMapping.ContextualParameter.VariableName);

            // subscriptionId and resourceGroupName should also map correctly
            Assert.IsTrue(registry.TryGetValue("subscriptionId", out var subscriptionMapping));
            Assert.AreEqual("subscriptions", subscriptionMapping!.ContextualParameter!.Key);
            Assert.AreEqual("subscriptionId", subscriptionMapping.ContextualParameter.VariableName);

            Assert.IsTrue(registry.TryGetValue("resourceGroupName", out var resourceGroupMapping));
            Assert.AreEqual("resourceGroups", resourceGroupMapping!.ContextualParameter!.Key);
            Assert.AreEqual("resourceGroupName", resourceGroupMapping.ContextualParameter.VariableName);
        }

        [Test]
        public void ValidateParameterMapping_MatchesByPositionNotByName()
        {
            // Test case where operation parameters have different names than contextual parameters
            // but should still match by position in the shared path segments
            var contextualPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Example/examples/{exampleName}");
            var operationContext = OperationContext.Create(contextualPathPattern);
            var operationPath = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Example/examples/{name}/children/{childName}");

            var registry = operationContext.BuildParameterMapping(operationPath);

            // "name" should match "exampleName" because both follow "examples" key
            Assert.IsTrue(registry.TryGetValue("name", out var nameMapping));
            Assert.AreEqual("examples", nameMapping!.ContextualParameter!.Key);
            Assert.AreEqual("exampleName", nameMapping.ContextualParameter.VariableName);

            // "childName" should not match anything in contextual path (it's a pass-through parameter)
            Assert.IsTrue(registry.TryGetValue("childName", out var childMapping));
            Assert.IsNull(childMapping!.ContextualParameter);
        }

        [Test]
        public void ValidateParameterMapping_ChildResourceWithPassThroughParameter()
        {
            // Test case where operation path represents a child resource with an additional parameter
            // that is not in the contextual path (pass-through parameter)
            var contextualPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}");
            var operationContext = OperationContext.Create(contextualPathPattern);
            var operationPath = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{name}");

            var registry = operationContext.BuildParameterMapping(operationPath);

            // All matching parameters should be found
            Assert.IsTrue(registry.TryGetValue("subscriptionId", out var subscriptionMapping));
            Assert.IsNotNull(subscriptionMapping!.ContextualParameter);
            Assert.IsTrue(registry.TryGetValue("resourceGroupName", out var resourceGroupMapping));
            Assert.IsNotNull(resourceGroupMapping!.ContextualParameter);
            Assert.IsTrue(registry.TryGetValue("vmName", out var vmMapping));
            Assert.IsNotNull(vmMapping!.ContextualParameter);

            // "name" is a pass-through parameter (not in contextual path)
            Assert.IsTrue(registry.TryGetValue("name", out var nameMapping));
            Assert.IsNull(nameMapping!.ContextualParameter);
        }

        [Test]
        public void ValidateParameterMapping_TenantContextAllParametersPassThrough()
        {
            // Test with tenant-level context where all operation parameters are pass-through
            // since the tenant path has no contextual parameters
            var operationContext = OperationContext.Create(RequestPathPattern.Tenant);
            var operationPath = new RequestPathPattern("/subscriptions/{subscriptionId}");

            var registry = operationContext.BuildParameterMapping(operationPath);

            // No contextual parameters available, so subscriptionId should not be contextual
            Assert.IsTrue(registry.TryGetValue("subscriptionId", out var subscriptionMapping));
            Assert.IsNull(subscriptionMapping!.ContextualParameter);
        }

        [Test]
        public void ValidateSecondaryContextualParameters_ExtractsParametersBeyondPrimaryPath()
        {
            // Test that secondary contextual parameters are extracted from the portion
            // of the secondary path that extends beyond the primary contextual path
            var primaryPath = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}");
            var secondaryPath = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Example/examples/{exampleName}");

            // Create a mock field selector that returns a simple field provider
            var mockFields = new Dictionary<string, FieldProvider>();
            Func<string, FieldProvider> fieldSelector = name =>
            {
                if (!mockFields.TryGetValue(name, out var field))
                {
                    field = new FieldProvider(FieldModifiers.Private, typeof(string), name, enclosingType: null!);
                    mockFields[name] = field;
                }
                return field;
            };

            var operationContext = OperationContext.Create(primaryPath, secondaryPath, fieldSelector);

            // Primary contextual parameters should be subscriptionId and resourceGroupName
            Assert.AreEqual(2, operationContext.ContextualPathParameters.Count);
            Assert.AreEqual("subscriptionId", operationContext.ContextualPathParameters[0].VariableName);
            Assert.AreEqual("resourceGroupName", operationContext.ContextualPathParameters[1].VariableName);

            // Secondary contextual parameters should only contain exampleName (the extra part)
            Assert.AreEqual(1, operationContext.SecondaryContextualPathParameters.Count);
            Assert.AreEqual("examples", operationContext.SecondaryContextualPathParameters[0].Key);
            Assert.AreEqual("exampleName", operationContext.SecondaryContextualPathParameters[0].VariableName);
        }

        [Test]
        public void ValidateSecondaryContextualParameters_MultipleExtraParameters()
        {
            // Test with multiple parameters in the secondary path beyond the primary path
            var primaryPath = new RequestPathPattern("/subscriptions/{subscriptionId}");
            var secondaryPath = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Example/examples/{exampleName}");

            var mockFields = new Dictionary<string, FieldProvider>();
            Func<string, FieldProvider> fieldSelector = name =>
            {
                if (!mockFields.TryGetValue(name, out var field))
                {
                    field = new FieldProvider(FieldModifiers.Private, typeof(string), name, enclosingType: null!);
                    mockFields[name] = field;
                }
                return field;
            };

            var operationContext = OperationContext.Create(primaryPath, secondaryPath, fieldSelector);

            // Primary should only have subscriptionId
            Assert.AreEqual(1, operationContext.ContextualPathParameters.Count);
            Assert.AreEqual("subscriptionId", operationContext.ContextualPathParameters[0].VariableName);

            // Secondary should have resourceGroupName and exampleName
            Assert.AreEqual(2, operationContext.SecondaryContextualPathParameters.Count);
            Assert.AreEqual("resourceGroups", operationContext.SecondaryContextualPathParameters[0].Key);
            Assert.AreEqual("resourceGroupName", operationContext.SecondaryContextualPathParameters[0].VariableName);
            Assert.AreEqual("examples", operationContext.SecondaryContextualPathParameters[1].Key);
            Assert.AreEqual("exampleName", operationContext.SecondaryContextualPathParameters[1].VariableName);
        }

        [Test]
        public void ValidateSecondaryContextualParameters_NoSecondaryPath()
        {
            // Test that when no secondary path is provided, SecondaryContextualPathParameters is empty
            var primaryPath = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}");
            var operationContext = OperationContext.Create(primaryPath);

            Assert.AreEqual(2, operationContext.ContextualPathParameters.Count);
            Assert.AreEqual(0, operationContext.SecondaryContextualPathParameters.Count);
        }

        [Test]
        public void ValidateParameterMapping_WithSecondaryContextualPath()
        {
            // Test that parameter mapping correctly uses secondary contextual parameters
            // when the operation path extends beyond the primary but within secondary path
            var primaryPath = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}");
            var secondaryPath = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Example/examples/{exampleName}");
            var operationPath = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Example/examples/{name}/children/{childName}");

            var mockFields = new Dictionary<string, FieldProvider>();
            Func<string, FieldProvider> fieldSelector = name =>
            {
                if (!mockFields.TryGetValue(name, out var field))
                {
                    field = new FieldProvider(FieldModifiers.Private, typeof(string), name, enclosingType: null!);
                    mockFields[name] = field;
                }
                return field;
            };

            var operationContext = OperationContext.Create(primaryPath, secondaryPath, fieldSelector);
            var registry = operationContext.BuildParameterMapping(operationPath);

            // subscriptionId and resourceGroupName should map to primary contextual parameters
            Assert.IsTrue(registry.TryGetValue("subscriptionId", out var subscriptionMapping));
            Assert.IsNotNull(subscriptionMapping!.ContextualParameter);
            Assert.AreEqual("subscriptions", subscriptionMapping.ContextualParameter!.Key);

            Assert.IsTrue(registry.TryGetValue("resourceGroupName", out var resourceGroupMapping));
            Assert.IsNotNull(resourceGroupMapping!.ContextualParameter);
            Assert.AreEqual("resourceGroups", resourceGroupMapping.ContextualParameter!.Key);

            // "name" should map to secondary contextual parameter (exampleName)
            Assert.IsTrue(registry.TryGetValue("name", out var nameMapping));
            Assert.IsNotNull(nameMapping!.ContextualParameter);
            Assert.AreEqual("examples", nameMapping.ContextualParameter!.Key);
            Assert.AreEqual("exampleName", nameMapping.ContextualParameter.VariableName);

            // "childName" should be pass-through (beyond both contextual paths)
            Assert.IsTrue(registry.TryGetValue("childName", out var childMapping));
            Assert.IsNull(childMapping!.ContextualParameter);
        }

        [Test]
        public void ValidateSecondaryContextualParameters_SkipsConstantValueSegments()
        {
            // Test that constant value segments (like singleton resources) are skipped
            // in secondary contextual parameters
            var primaryPath = new RequestPathPattern("/subscriptions/{subscriptionId}");
            var secondaryPath = new RequestPathPattern("/subscriptions/{subscriptionId}/providers/Microsoft.Example/examples/{exampleName}/singletons/default");

            var mockFields = new Dictionary<string, FieldProvider>();
            Func<string, FieldProvider> fieldSelector = name =>
            {
                if (!mockFields.TryGetValue(name, out var field))
                {
                    field = new FieldProvider(FieldModifiers.Private, typeof(string), name, enclosingType: null!);
                    mockFields[name] = field;
                }
                return field;
            };

            var operationContext = OperationContext.Create(primaryPath, secondaryPath, fieldSelector);

            // Secondary should only have exampleName (singletons/default is constant pair, skipped)
            Assert.AreEqual(1, operationContext.SecondaryContextualPathParameters.Count);
            Assert.AreEqual("examples", operationContext.SecondaryContextualPathParameters[0].Key);
            Assert.AreEqual("exampleName", operationContext.SecondaryContextualPathParameters[0].VariableName);
        }
    }
}
