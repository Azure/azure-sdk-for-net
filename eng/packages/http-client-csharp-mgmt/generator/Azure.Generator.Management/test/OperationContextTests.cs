// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Models;
using Microsoft.TypeSpec.Generator.Expressions;
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
            Assert.That(registry.TryGetValue("name", out var nameMapping), Is.True);
            Assert.That(nameMapping!.ContextualParameter, Is.Not.Null);
            Assert.That(nameMapping.ContextualParameter!.Key, Is.EqualTo("fleets"));
            Assert.That(nameMapping.ContextualParameter.VariableName, Is.EqualTo("fleetName"));

            // subscriptionId and resourceGroupName should also map correctly
            Assert.That(registry.TryGetValue("subscriptionId", out var subscriptionMapping), Is.True);
            Assert.That(subscriptionMapping!.ContextualParameter!.Key, Is.EqualTo("subscriptions"));
            Assert.That(subscriptionMapping.ContextualParameter.VariableName, Is.EqualTo("subscriptionId"));

            Assert.That(registry.TryGetValue("resourceGroupName", out var resourceGroupMapping), Is.True);
            Assert.That(resourceGroupMapping!.ContextualParameter!.Key, Is.EqualTo("resourceGroups"));
            Assert.That(resourceGroupMapping.ContextualParameter.VariableName, Is.EqualTo("resourceGroupName"));
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
            Assert.That(registry.TryGetValue("name", out var nameMapping), Is.True);
            Assert.That(nameMapping!.ContextualParameter!.Key, Is.EqualTo("examples"));
            Assert.That(nameMapping.ContextualParameter.VariableName, Is.EqualTo("exampleName"));

            // "childName" should not match anything in contextual path (it's a pass-through parameter)
            Assert.That(registry.TryGetValue("childName", out var childMapping), Is.True);
            Assert.That(childMapping!.ContextualParameter, Is.Null);
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
            Assert.That(registry.TryGetValue("subscriptionId", out var subscriptionMapping), Is.True);
            Assert.That(subscriptionMapping!.ContextualParameter, Is.Not.Null);
            Assert.That(registry.TryGetValue("resourceGroupName", out var resourceGroupMapping), Is.True);
            Assert.That(resourceGroupMapping!.ContextualParameter, Is.Not.Null);
            Assert.That(registry.TryGetValue("vmName", out var vmMapping), Is.True);
            Assert.That(vmMapping!.ContextualParameter, Is.Not.Null);

            // "name" is a pass-through parameter (not in contextual path)
            Assert.That(registry.TryGetValue("name", out var nameMapping), Is.True);
            Assert.That(nameMapping!.ContextualParameter, Is.Null);
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
            Assert.That(registry.TryGetValue("subscriptionId", out var subscriptionMapping), Is.True);
            Assert.That(subscriptionMapping!.ContextualParameter, Is.Null);
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
            Assert.That(operationContext.ContextualPathParameters.Count, Is.EqualTo(2));
            Assert.That(operationContext.ContextualPathParameters[0].VariableName, Is.EqualTo("subscriptionId"));
            Assert.That(operationContext.ContextualPathParameters[1].VariableName, Is.EqualTo("resourceGroupName"));

            // Secondary contextual parameters should only contain exampleName (the extra part)
            Assert.That(operationContext.SecondaryContextualPathParameters.Count, Is.EqualTo(1));
            Assert.That(operationContext.SecondaryContextualPathParameters[0].Key, Is.EqualTo("examples"));
            Assert.That(operationContext.SecondaryContextualPathParameters[0].VariableName, Is.EqualTo("exampleName"));
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
            Assert.That(operationContext.ContextualPathParameters.Count, Is.EqualTo(1));
            Assert.That(operationContext.ContextualPathParameters[0].VariableName, Is.EqualTo("subscriptionId"));

            // Secondary should have resourceGroupName and exampleName
            Assert.That(operationContext.SecondaryContextualPathParameters.Count, Is.EqualTo(2));
            Assert.That(operationContext.SecondaryContextualPathParameters[0].Key, Is.EqualTo("resourceGroups"));
            Assert.That(operationContext.SecondaryContextualPathParameters[0].VariableName, Is.EqualTo("resourceGroupName"));
            Assert.That(operationContext.SecondaryContextualPathParameters[1].Key, Is.EqualTo("examples"));
            Assert.That(operationContext.SecondaryContextualPathParameters[1].VariableName, Is.EqualTo("exampleName"));
        }

        [Test]
        public void ValidateSecondaryContextualParameters_NoSecondaryPath()
        {
            // Test that when no secondary path is provided, SecondaryContextualPathParameters is empty
            var primaryPath = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}");
            var operationContext = OperationContext.Create(primaryPath);

            Assert.That(operationContext.ContextualPathParameters.Count, Is.EqualTo(2));
            Assert.That(operationContext.SecondaryContextualPathParameters.Count, Is.EqualTo(0));
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
            Assert.That(registry.TryGetValue("subscriptionId", out var subscriptionMapping), Is.True);
            Assert.That(subscriptionMapping!.ContextualParameter, Is.Not.Null);
            Assert.That(subscriptionMapping.ContextualParameter!.Key, Is.EqualTo("subscriptions"));

            Assert.That(registry.TryGetValue("resourceGroupName", out var resourceGroupMapping), Is.True);
            Assert.That(resourceGroupMapping!.ContextualParameter, Is.Not.Null);
            Assert.That(resourceGroupMapping.ContextualParameter!.Key, Is.EqualTo("resourceGroups"));

            // "name" should map to secondary contextual parameter (exampleName)
            Assert.That(registry.TryGetValue("name", out var nameMapping), Is.True);
            Assert.That(nameMapping!.ContextualParameter, Is.Not.Null);
            Assert.That(nameMapping.ContextualParameter!.Key, Is.EqualTo("examples"));
            Assert.That(nameMapping.ContextualParameter.VariableName, Is.EqualTo("exampleName"));

            // "childName" should be pass-through (beyond both contextual paths)
            Assert.That(registry.TryGetValue("childName", out var childMapping), Is.True);
            Assert.That(childMapping!.ContextualParameter, Is.Null);
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
            Assert.That(operationContext.SecondaryContextualPathParameters.Count, Is.EqualTo(1));
            Assert.That(operationContext.SecondaryContextualPathParameters[0].Key, Is.EqualTo("examples"));
            Assert.That(operationContext.SecondaryContextualPathParameters[0].VariableName, Is.EqualTo("exampleName"));
        }

        [TestCase]
        public void ValidateContextualParameters_VariableKeySegment()
        {
            // Test path like /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{parentProviderNamespace}/{parentResourceType}/{parentResourceName}/providers/Microsoft.Example/targets/{targetName}
            // where {parentResourceType} is the key for {parentResourceName}
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{parentProviderNamespace}/{parentResourceType}/{parentResourceName}/providers/Microsoft.Example/targets/{targetName}");
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;

            // Should have 6 parameters: subscriptionId, resourceGroupName, parentProviderNamespace, parentResourceName, parentResourceType, targetName
            // Note: When key is variable, the value (parentResourceName) is pushed after key (parentResourceType) to the stack,
            // so in the final list, parentResourceName appears before parentResourceType due to stack LIFO behavior.
            Assert.That(contextualParameters.Count, Is.EqualTo(6));

            Assert.That(contextualParameters[0].Key, Is.EqualTo("subscriptions"));
            Assert.That(contextualParameters[0].VariableName, Is.EqualTo("subscriptionId"));
            Assert.That(contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.SubscriptionId"));

            Assert.That(contextualParameters[1].Key, Is.EqualTo("resourceGroups"));
            Assert.That(contextualParameters[1].VariableName, Is.EqualTo("resourceGroupName"));
            Assert.That(contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.ResourceGroupName"));

            // parentProviderNamespace comes from providers segment
            Assert.That(contextualParameters[2].Key, Is.EqualTo("providers"));
            Assert.That(contextualParameters[2].VariableName, Is.EqualTo("parentProviderNamespace"));
            Assert.That(contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.ResourceType.Namespace"));

            // parentResourceType is a variable key - should use ResourceType().Type()
            Assert.That(contextualParameters[3].Key, Is.EqualTo("parentResourceType"));
            Assert.That(contextualParameters[3].VariableName, Is.EqualTo("parentResourceType"));
            Assert.That(contextualParameters[3].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.ResourceType.Type"));

            // parentResourceName uses Name
            Assert.That(contextualParameters[4].Key, Is.EqualTo("parentResourceName"));
            Assert.That(contextualParameters[4].VariableName, Is.EqualTo("parentResourceName"));
            Assert.That(contextualParameters[4].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Parent.Name"));

            Assert.That(contextualParameters[5].Key, Is.EqualTo("targets"));
            Assert.That(contextualParameters[5].VariableName, Is.EqualTo("targetName"));
            Assert.That(contextualParameters[5].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
        }

        [TestCase]
        public void ValidateContextualParameters_VariableKeySegment_ParentResource()
        {
            // Test path with variable key at parent level (without the child resource)
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{parentProviderNamespace}/{parentResourceType}/{parentResourceName}");
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;

            // Should have 5 parameters: subscriptionId, resourceGroupName, parentProviderNamespace, parentResourceName, parentResourceType
            Assert.That(contextualParameters.Count, Is.EqualTo(5));

            Assert.That(contextualParameters[0].Key, Is.EqualTo("subscriptions"));
            Assert.That(contextualParameters[0].VariableName, Is.EqualTo("subscriptionId"));

            Assert.That(contextualParameters[1].Key, Is.EqualTo("resourceGroups"));
            Assert.That(contextualParameters[1].VariableName, Is.EqualTo("resourceGroupName"));

            // parentProviderNamespace comes from providers segment
            Assert.That(contextualParameters[2].Key, Is.EqualTo("providers"));
            Assert.That(contextualParameters[2].VariableName, Is.EqualTo("parentProviderNamespace"));
            Assert.That(contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.ResourceType.Namespace"));

            // parentResourceType is a variable key
            Assert.That(contextualParameters[3].Key, Is.EqualTo("parentResourceType"));
            Assert.That(contextualParameters[3].VariableName, Is.EqualTo("parentResourceType"));
            Assert.That(contextualParameters[3].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.ResourceType.Type"));

            // parentResourceName uses Name
            Assert.That(contextualParameters[4].Key, Is.EqualTo("parentResourceName"));
            Assert.That(contextualParameters[4].VariableName, Is.EqualTo("parentResourceName"));
            Assert.That(contextualParameters[4].BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("id.Name"));
        }

        [Test]
        public void ValidateSecondaryContextualParameters_VariableKeySegment()
        {
            // Test secondary contextual path with variable key segment
            var primaryPath = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}");
            var secondaryPath = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{parentProviderNamespace}/{parentResourceType}/{parentResourceName}/providers/Microsoft.Example/targets/{targetName}");

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

            // Primary should have subscriptionId and resourceGroupName
            Assert.That(operationContext.ContextualPathParameters.Count, Is.EqualTo(2));
            Assert.That(operationContext.ContextualPathParameters[0].VariableName, Is.EqualTo("subscriptionId"));
            Assert.That(operationContext.ContextualPathParameters[1].VariableName, Is.EqualTo("resourceGroupName"));

            // Secondary should have parentProviderNamespace, parentResourceType, parentResourceName, and targetName
            // Note: providers/Microsoft.Example is constant pair so skipped, targets/{targetName} has constant key
            Assert.That(operationContext.SecondaryContextualPathParameters.Count, Is.EqualTo(4));

            Assert.That(operationContext.SecondaryContextualPathParameters[0].Key, Is.EqualTo("providers"));
            Assert.That(operationContext.SecondaryContextualPathParameters[0].VariableName, Is.EqualTo("parentProviderNamespace"));

            // parentResourceType is a variable key - should be included
            Assert.That(operationContext.SecondaryContextualPathParameters[1].Key, Is.EqualTo("parentResourceType"));
            Assert.That(operationContext.SecondaryContextualPathParameters[1].VariableName, Is.EqualTo("parentResourceType"));

            // parentResourceName uses the variable key
            Assert.That(operationContext.SecondaryContextualPathParameters[2].Key, Is.EqualTo("parentResourceName"));
            Assert.That(operationContext.SecondaryContextualPathParameters[2].VariableName, Is.EqualTo("parentResourceName"));

            Assert.That(operationContext.SecondaryContextualPathParameters[3].Key, Is.EqualTo("targets"));
            Assert.That(operationContext.SecondaryContextualPathParameters[3].VariableName, Is.EqualTo("targetName"));
        }

        [TestCase]
        public void PopulateArguments_NullableEnumToString_UsesNullConditional()
        {
            // Set up a pass-through parameter mapping (ContextualParameter is null)
            var mapping = new ParameterContextMapping("testParam", null);
            var registry = new ParameterContextRegistry(new List<ParameterContextMapping> { mapping });

            // Request parameter expects string type with matching serialized name
            var requestParam = new ParameterProvider("testParam", $"", typeof(string));
            requestParam.Update(wireInfo: new WireInformation(default, "testParam"));

            // Method parameter is a nullable enum type
            var nullableEnumType = new CSharpType(typeof(DayOfWeek), isNullable: true);
            var methodParam = new ParameterProvider("testParam", $"", nullableEnumType);
            methodParam.Update(wireInfo: new WireInformation(default, "testParam"));

            var contextVariable = new VariableExpression(typeof(RequestContext), "context");

            var arguments = registry.PopulateArguments(
                _idVariable,
                new List<ParameterProvider> { requestParam },
                contextVariable,
                new List<ParameterProvider> { methodParam });

            Assert.That(arguments.Count, Is.EqualTo(1));
            // Should use null-conditional: testParam?.ToString()
            Assert.That(arguments[0].ToDisplayString(), Does.Contain("?.ToString()"));
        }

        [TestCase]
        public void PopulateArguments_NonNullableEnumToString_UsesDirectToString()
        {
            // Set up a pass-through parameter mapping (ContextualParameter is null)
            var mapping = new ParameterContextMapping("testParam", null);
            var registry = new ParameterContextRegistry(new List<ParameterContextMapping> { mapping });

            // Request parameter expects string type
            var requestParam = new ParameterProvider("testParam", $"", typeof(string));
            requestParam.Update(wireInfo: new WireInformation(default, "testParam"));

            // Method parameter is a non-nullable enum type
            var methodParam = new ParameterProvider("testParam", $"", typeof(DayOfWeek));
            methodParam.Update(wireInfo: new WireInformation(default, "testParam"));

            var contextVariable = new VariableExpression(typeof(RequestContext), "context");

            var arguments = registry.PopulateArguments(
                _idVariable,
                new List<ParameterProvider> { requestParam },
                contextVariable,
                new List<ParameterProvider> { methodParam });

            Assert.That(arguments.Count, Is.EqualTo(1));
            // Should use direct ToString without null-conditional: testParam.ToString()
            var displayString = arguments[0].ToDisplayString();
            Assert.That(displayString, Does.Contain(".ToString()"));
            Assert.That(displayString, Does.Not.Contain("?.ToString()"));
        }

        [TestCase]
        public void PopulateArguments_NullableResourceIdentifierToString_UsesNullConditional()
        {
            // Set up a pass-through parameter mapping (ContextualParameter is null)
            var mapping = new ParameterContextMapping("testParam", null);
            var registry = new ParameterContextRegistry(new List<ParameterContextMapping> { mapping });

            // Request parameter expects string type with matching serialized name
            var requestParam = new ParameterProvider("testParam", $"", typeof(string));
            requestParam.Update(wireInfo: new WireInformation(default, "testParam"));

            // Method parameter is a nullable ResourceIdentifier type
            var nullableResourceIdType = new CSharpType(typeof(ResourceIdentifier), isNullable: true);
            var methodParam = new ParameterProvider("testParam", $"", nullableResourceIdType);
            methodParam.Update(wireInfo: new WireInformation(default, "testParam"));

            var contextVariable = new VariableExpression(typeof(RequestContext), "context");

            var arguments = registry.PopulateArguments(
                _idVariable,
                new List<ParameterProvider> { requestParam },
                contextVariable,
                new List<ParameterProvider> { methodParam });

            Assert.That(arguments.Count, Is.EqualTo(1));
            // Should use null-conditional: testParam?.ToString()
            Assert.That(arguments[0].ToDisplayString(), Does.Contain("?.ToString()"));
        }

        [TestCase]
        public void PopulateArguments_NonNullableResourceIdentifierToString_UsesDirectToString()
        {
            // Set up a pass-through parameter mapping (ContextualParameter is null)
            var mapping = new ParameterContextMapping("testParam", null);
            var registry = new ParameterContextRegistry(new List<ParameterContextMapping> { mapping });

            // Request parameter expects string type
            var requestParam = new ParameterProvider("testParam", $"", typeof(string));
            requestParam.Update(wireInfo: new WireInformation(default, "testParam"));

            // Method parameter is a non-nullable ResourceIdentifier type
            var methodParam = new ParameterProvider("testParam", $"", typeof(ResourceIdentifier));
            methodParam.Update(wireInfo: new WireInformation(default, "testParam"));

            var contextVariable = new VariableExpression(typeof(RequestContext), "context");

            var arguments = registry.PopulateArguments(
                _idVariable,
                new List<ParameterProvider> { requestParam },
                contextVariable,
                new List<ParameterProvider> { methodParam });

            Assert.That(arguments.Count, Is.EqualTo(1));
            // Should use direct ToString without null-conditional: testParam.ToString()
            var displayString = arguments[0].ToDisplayString();
            Assert.That(displayString, Does.Contain(".ToString()"));
            Assert.That(displayString, Does.Not.Contain("?.ToString()"));
        }

        [TestCase]
        public void PopulateArguments_MatchConditionsType_FindsMethodParameterByType()
        {
            // When the request parameter is a MatchConditions type (processed by MatchConditionsHeadersVisitor),
            // it should find the corresponding MatchConditions method parameter by type
            var registry = new ParameterContextRegistry(new List<ParameterContextMapping>());

            // Request parameter is MatchConditions with empty serialized name (set by visitor)
            var requestMatchConditions = new ParameterProvider("matchConditions", $"",
                new CSharpType(typeof(MatchConditions)).WithNullable(true));
            requestMatchConditions.Update(wireInfo: new WireInformation(default, string.Empty));

            // Method parameter is also MatchConditions (set by visitor on convenience method)
            var methodMatchConditions = new ParameterProvider("matchConditions", $"",
                new CSharpType(typeof(MatchConditions)).WithNullable(true));
            methodMatchConditions.Update(wireInfo: new WireInformation(default, string.Empty));

            var contextVariable = new VariableExpression(typeof(RequestContext), "context");

            var arguments = registry.PopulateArguments(
                _idVariable,
                new List<ParameterProvider> { requestMatchConditions },
                contextVariable,
                new List<ParameterProvider> { methodMatchConditions });

            Assert.That(arguments.Count, Is.EqualTo(1));
            Assert.That(arguments[0].ToDisplayString(), Does.Contain("matchConditions"));
        }

        [TestCase]
        public void PopulateArguments_RequestConditionsType_FindsMethodParameterByType()
        {
            // When the request parameter is a RequestConditions type, it should find the
            // corresponding RequestConditions method parameter by type
            var registry = new ParameterContextRegistry(new List<ParameterContextMapping>());

            var requestConditions = new ParameterProvider("requestConditions", $"",
                new CSharpType(typeof(RequestConditions)).WithNullable(true));
            requestConditions.Update(wireInfo: new WireInformation(default, string.Empty));

            var methodConditions = new ParameterProvider("requestConditions", $"",
                new CSharpType(typeof(RequestConditions)).WithNullable(true));
            methodConditions.Update(wireInfo: new WireInformation(default, string.Empty));

            var contextVariable = new VariableExpression(typeof(RequestContext), "context");

            var arguments = registry.PopulateArguments(
                _idVariable,
                new List<ParameterProvider> { requestConditions },
                contextVariable,
                new List<ParameterProvider> { methodConditions });

            Assert.That(arguments.Count, Is.EqualTo(1));
            Assert.That(arguments[0].ToDisplayString(), Does.Contain("requestConditions"));
        }

        [TestCase]
        public void PopulateArguments_MatchConditionsType_ReturnsDefaultWhenNoMethodParameter()
        {
            // When the request parameter is a MatchConditions type but no matching method parameter exists,
            // it should return default
            var registry = new ParameterContextRegistry(new List<ParameterContextMapping>());

            var requestMatchConditions = new ParameterProvider("matchConditions", $"",
                new CSharpType(typeof(MatchConditions)).WithNullable(true));
            requestMatchConditions.Update(wireInfo: new WireInformation(default, string.Empty));

            var contextVariable = new VariableExpression(typeof(RequestContext), "context");

            var arguments = registry.PopulateArguments(
                _idVariable,
                new List<ParameterProvider> { requestMatchConditions },
                contextVariable,
                new List<ParameterProvider>());

            Assert.That(arguments.Count, Is.EqualTo(1));
            Assert.That(arguments[0].ToDisplayString(), Does.Contain("default"));
        }
        [TestCase]
        public void PopulateArguments_StringBodyParameter_UsesRequestContentCreate()
        {
            // When the body parameter is a string (framework type), should generate
            // RequestContent.Create(BinaryData.FromObjectAsJson(body)) instead of
            // string.ToRequestContent(body) which doesn't exist.
            var registry = new ParameterContextRegistry(new List<ParameterContextMapping>());

            var requestContentParam = new ParameterProvider("content", $"", typeof(RequestContent));
            requestContentParam.Update(wireInfo: new WireInformation(default, string.Empty));

            var contextVariable = new VariableExpression(typeof(RequestContext), "context");

            var bodyParam = new ParameterProvider("body", $"", new CSharpType(typeof(string), isNullable: true));
            bodyParam.Update(wireInfo: new WireInformation(default, string.Empty), location: ParameterLocation.Body);

            var arguments = registry.PopulateArguments(
                _idVariable,
                new List<ParameterProvider> { requestContentParam },
                contextVariable,
                new List<ParameterProvider> { bodyParam });

            Assert.That(arguments.Count, Is.EqualTo(1));
            var displayString = arguments[0].ToDisplayString();
            // Should use RequestContent.Create(body), not string.ToRequestContent(body)
            Assert.That(displayString, Does.Not.Contain("string.ToRequestContent"));
            Assert.That(displayString, Does.Contain("RequestContent"));
            Assert.That(displayString, Does.Not.Contain("FromObjectAsJson"));
        }

        [TestCase]
        public void PopulateArguments_NonNullableFixedEnumToString_UsesToSerialString()
        {
            // Set up a pass-through parameter mapping (ContextualParameter is null)
            var mapping = new ParameterContextMapping("testParam", null);
            var registry = new ParameterContextRegistry(new List<ParameterContextMapping> { mapping });

            // Request parameter expects string type
            var requestParam = new ParameterProvider("testParam", $"", typeof(string));
            requestParam.Update(wireInfo: new WireInformation(default, "testParam"));

            // Method parameter is a non-nullable fixed enum type (IsStruct=false)
            // Create a CSharpType with IsEnum=true and IsStruct=false to simulate a generated fixed enum
            var fixedEnumType = CreateFixedEnumCSharpType("TestFixedEnum", "TestNs", isNullable: false);
            var methodParam = new ParameterProvider("testParam", $"", fixedEnumType);
            methodParam.Update(wireInfo: new WireInformation(default, "testParam"));

            var contextVariable = new VariableExpression(typeof(RequestContext), "context");

            var arguments = registry.PopulateArguments(
                _idVariable,
                new List<ParameterProvider> { requestParam },
                contextVariable,
                new List<ParameterProvider> { methodParam });

            Assert.That(arguments.Count, Is.EqualTo(1));
            // Fixed enums should use ToSerialString() instead of ToString()
            var displayString = arguments[0].ToDisplayString();
            Assert.That(displayString, Does.Contain(".ToSerialString()"));
            Assert.That(displayString, Does.Not.Contain("?.ToSerialString()"));
        }

        [TestCase]
        public void PopulateArguments_NullableFixedEnumToString_UsesNullConditionalToSerialString()
        {
            // Set up a pass-through parameter mapping (ContextualParameter is null)
            var mapping = new ParameterContextMapping("testParam", null);
            var registry = new ParameterContextRegistry(new List<ParameterContextMapping> { mapping });

            // Request parameter expects string type with matching serialized name
            var requestParam = new ParameterProvider("testParam", $"", typeof(string));
            requestParam.Update(wireInfo: new WireInformation(default, "testParam"));

            // Method parameter is a nullable fixed enum type (IsStruct=false)
            var fixedEnumType = CreateFixedEnumCSharpType("TestFixedEnum", "TestNs", isNullable: true);
            var methodParam = new ParameterProvider("testParam", $"", fixedEnumType);
            methodParam.Update(wireInfo: new WireInformation(default, "testParam"));

            var contextVariable = new VariableExpression(typeof(RequestContext), "context");

            var arguments = registry.PopulateArguments(
                _idVariable,
                new List<ParameterProvider> { requestParam },
                contextVariable,
                new List<ParameterProvider> { methodParam });

            Assert.That(arguments.Count, Is.EqualTo(1));
            // Nullable fixed enums should use null-conditional ToSerialString(): testParam?.ToSerialString()
            Assert.That(arguments[0].ToDisplayString(), Does.Contain("?.ToSerialString()"));
        }

        /// <summary>
        /// Creates a CSharpType that simulates a generated fixed enum (IsEnum=true, IsStruct=false).
        /// Uses reflection because the multi-param CSharpType constructor is internal.
        /// </summary>
        private static CSharpType CreateFixedEnumCSharpType(string name, string ns, bool isNullable)
        {
            // The internal CSharpType constructor signature:
            // CSharpType(string name, string ns, bool isValueType, bool isNullable,
            //            CSharpType declaringType, IReadOnlyList<CSharpType> args,
            //            bool isPublic, bool isStruct, CSharpType baseType, Type underlyingEnumType)
            var ctor = typeof(CSharpType).GetConstructor(
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
                null,
                new[] { typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(CSharpType),
                        typeof(IReadOnlyList<CSharpType>), typeof(bool), typeof(bool), typeof(CSharpType), typeof(Type) },
                null);

            bool isValueType = true;
            CSharpType? declaringType = null;
            IReadOnlyList<CSharpType> args = Array.Empty<CSharpType>();
            bool isPublic = true;
            bool isStruct = false; // false = fixed enum (C# enum), true = extensible enum (readonly struct)
            CSharpType? baseType = null;
            Type underlyingEnumType = typeof(string); // non-null marks this as an enum type

            return (CSharpType)ctor!.Invoke(new object?[] {
                name, ns, isValueType, isNullable, declaringType,
                args, isPublic, isStruct, baseType, underlyingEnumType
            });
        }

        [Test]
        public void ValidateParameterMapping_ContextualPathConstant_SubstitutedAndContextual()
        {
            // This test validates that when the resource's ContextualPath has a constant segment
            // at a position where the operation path has a variable (e.g. {parentType}), the
            // operation variable is substituted with the contextual constant and treated as a
            // contextual parameter that emits the literal value.
            //
            // Scenario: A resource at path .../topics/{parentName}/privateEndpointConnections/{name}
            // has an operation path with {parentType}/{parentName}/... where {parentType} should be
            // substituted with the constant "topics".

            var contextualPath = new RequestPathPattern(
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/topics/{parentName}/privateEndpointConnections/{privateEndpointConnectionName}");
            var operationContext = OperationContext.Create(contextualPath);

            // Operation path uses {parentType} (dynamic) instead of "topics" (constant)
            var operationPath = new RequestPathPattern(
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/{parentType}/{parentName}/privateEndpointConnections/{privateEndpointConnectionName}");

            var registry = operationContext.BuildParameterMapping(operationPath);

            // parentType should be contextual (not pass-through) and emit the literal "topics"
            Assert.That(registry.TryGetValue("parentType", out var parentTypeMapping), Is.True);
            Assert.That(parentTypeMapping!.ContextualParameter, Is.Not.Null, "parentType should be a contextual parameter");
            Assert.That(parentTypeMapping.ContextualParameter!.Key, Is.EqualTo("topics"));
            Assert.That(parentTypeMapping.ContextualParameter.VariableName, Is.EqualTo("parentType"));
            Assert.That(parentTypeMapping.ContextualParameter.BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("\"topics\""));

            // subscriptionId and resourceGroupName should still be contextual from the resource path
            Assert.That(registry.TryGetValue("subscriptionId", out var subscriptionMapping), Is.True);
            Assert.That(subscriptionMapping!.ContextualParameter, Is.Not.Null);
            Assert.That(registry.TryGetValue("resourceGroupName", out var resourceGroupMapping), Is.True);
            Assert.That(resourceGroupMapping!.ContextualParameter, Is.Not.Null);

            // parentName should be contextual (from the expanded resource path)
            Assert.That(registry.TryGetValue("parentName", out var parentNameMapping), Is.True);
            Assert.That(parentNameMapping!.ContextualParameter, Is.Not.Null);

            // privateEndpointConnectionName is in the contextual path (it's the resource name)
            Assert.That(registry.TryGetValue("privateEndpointConnectionName", out var pecNameMapping), Is.True);
            Assert.That(pecNameMapping!.ContextualParameter, Is.Not.Null, "privateEndpointConnectionName should be contextual (it's the resource name)");
        }

        [Test]
        public void ValidateParameterMapping_ContextualPathConstant_MultipleConstants()
        {
            // Test with multiple constant segments in the contextual path that line up with
            // variable segments in the operation path.
            var contextualPath = new RequestPathPattern(
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Example/topics/{parentName}/children/{childName}");
            var operationContext = OperationContext.Create(contextualPath);

            var operationPath = new RequestPathPattern(
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Example/{parentType}/{parentName}/{childType}/{childName}");

            var registry = operationContext.BuildParameterMapping(operationPath);

            // Both parentType and childType should be contextual with literal values
            Assert.That(registry.TryGetValue("parentType", out var parentTypeMapping), Is.True);
            Assert.That(parentTypeMapping!.ContextualParameter, Is.Not.Null);
            Assert.That(parentTypeMapping.ContextualParameter!.BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("\"topics\""));

            Assert.That(registry.TryGetValue("childType", out var childTypeMapping), Is.True);
            Assert.That(childTypeMapping!.ContextualParameter, Is.Not.Null);
            Assert.That(childTypeMapping.ContextualParameter!.BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("\"children\""));

            // parentName and childName should be contextual from the resource path
            Assert.That(registry.TryGetValue("parentName", out var parentNameMapping), Is.True);
            Assert.That(parentNameMapping!.ContextualParameter, Is.Not.Null);
            Assert.That(registry.TryGetValue("childName", out var childNameMapping), Is.True);
            Assert.That(childNameMapping!.ContextualParameter, Is.Not.Null);
        }

        [Test]
        public void ValidateParameterMapping_NoSubstitutionNeeded_BehavesNormally()
        {
            // Verify that when the contextual path has no constants aligned with operation
            // variables, BuildParameterMapping behaves as the basic position-based matching.
            var contextualPath = new RequestPathPattern(
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Example/examples/{exampleName}");
            var operationContext = OperationContext.Create(contextualPath);

            var operationPath = new RequestPathPattern(
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Example/examples/{name}/children/{childName}");

            var registry = operationContext.BuildParameterMapping(operationPath);

            // "name" should match contextual (position-based matching)
            Assert.That(registry.TryGetValue("name", out var nameMapping), Is.True);
            Assert.That(nameMapping!.ContextualParameter, Is.Not.Null);

            // "childName" should be pass-through
            Assert.That(registry.TryGetValue("childName", out var childMapping), Is.True);
            Assert.That(childMapping!.ContextualParameter, Is.Null);
        }

        [Test]
        public void ValidateParameterMapping_DivergentContextualPath_DoesNotSubstituteAcrossDivergence()
        {
            // Regression test for the SubscriptionRaiPolicy scenario from cognitiveservices: the
            // contextual path (the parent's resource id) diverges from the operation path early
            // — operation has /providers/Microsoft.X/raiPolicy/{raiPolicyName} while contextual
            // has /resourceGroups/{rg}/providers/Microsoft.X/accounts/{accountName}. After the
            // divergence at index 2 (providers vs resourceGroups), no later segment from the
            // contextual path may be substituted into the operation path. In particular,
            // {raiPolicyName} must NOT be replaced with the literal "Microsoft.X" that happens
            // to sit at the same index in the contextual path.
            var contextualPath = new RequestPathPattern(
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Example/accounts/{accountName}");
            var operationContext = OperationContext.Create(contextualPath);

            var operationPath = new RequestPathPattern(
                "/subscriptions/{subscriptionId}/providers/Microsoft.Example/raiPolicy/{raiPolicyName}");

            var registry = operationContext.BuildParameterMapping(operationPath);

            // subscriptionId is in the still-aligned prefix.
            Assert.That(registry.TryGetValue("subscriptionId", out var subscriptionMapping), Is.True);
            Assert.That(subscriptionMapping!.ContextualParameter, Is.Not.Null);

            // raiPolicyName must remain a pass-through caller parameter — alignment broke at
            // the providers-vs-resourceGroups divergence so no substitution should happen.
            Assert.That(registry.TryGetValue("raiPolicyName", out var raiPolicyMapping), Is.True);
            Assert.That(raiPolicyMapping!.ContextualParameter, Is.Null,
                "raiPolicyName must not be substituted with a contextual constant after path divergence");
        }

        [Test]
        public void ValidateParameterMapping_SecondaryPath_WithContextualPathConstant_SubstitutedAndContextual()
        {
            // Validates that when an expanded dynamic-parent resource also has a List operation
            // (which causes the collection to be created via the secondary-path overload of
            // OperationContext.Create), the contextual constant ("topics") substitution still
            // applies to the operation path so the dynamic {parentType} parameter is replaced
            // with its constant value rather than appearing in the generated method signature.

            var primaryPath = new RequestPathPattern(
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/topics/{parentName}");
            var secondaryPath = new RequestPathPattern(
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/topics/{parentName}/privateEndpointConnections");

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

            // Operation path uses the dynamic {parentType} segment instead of the literal "topics".
            var operationPath = new RequestPathPattern(
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/{parentType}/{parentName}/privateEndpointConnections/{privateEndpointConnectionName}");

            var registry = operationContext.BuildParameterMapping(operationPath);

            // parentType should be contextual and emit the literal "topics" rather than passing through.
            Assert.That(registry.TryGetValue("parentType", out var parentTypeMapping), Is.True);
            Assert.That(parentTypeMapping!.ContextualParameter, Is.Not.Null, "parentType should be a contextual parameter even on the secondary-path overload");
            Assert.That(parentTypeMapping.ContextualParameter!.BuildValueExpression(_idVariable).ToDisplayString(), Is.EqualTo("\"topics\""));

            // subscriptionId/resourceGroupName/parentName come from the primary contextual path.
            Assert.That(registry.TryGetValue("subscriptionId", out var subscriptionMapping), Is.True);
            Assert.That(subscriptionMapping!.ContextualParameter, Is.Not.Null);
            Assert.That(registry.TryGetValue("resourceGroupName", out var resourceGroupMapping), Is.True);
            Assert.That(resourceGroupMapping!.ContextualParameter, Is.Not.Null);
            Assert.That(registry.TryGetValue("parentName", out var parentNameMapping), Is.True);
            Assert.That(parentNameMapping!.ContextualParameter, Is.Not.Null);
        }
    }
}
