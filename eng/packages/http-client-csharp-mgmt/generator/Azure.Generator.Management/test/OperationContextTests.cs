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
            Assert.AreEqual(6, contextualParameters.Count);

            Assert.AreEqual("subscriptions", contextualParameters[0].Key);
            Assert.AreEqual("subscriptionId", contextualParameters[0].VariableName);
            Assert.AreEqual("id.SubscriptionId", contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString());

            Assert.AreEqual("resourceGroups", contextualParameters[1].Key);
            Assert.AreEqual("resourceGroupName", contextualParameters[1].VariableName);
            Assert.AreEqual("id.ResourceGroupName", contextualParameters[1].BuildValueExpression(_idVariable).ToDisplayString());

            // parentProviderNamespace comes from providers segment
            Assert.AreEqual("providers", contextualParameters[2].Key);
            Assert.AreEqual("parentProviderNamespace", contextualParameters[2].VariableName);
            Assert.AreEqual("id.Parent.ResourceType.Namespace", contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString());

            // parentResourceName uses the variable key - appears first due to stack order
            Assert.AreEqual("parentResourceName", contextualParameters[3].Key);
            Assert.AreEqual("parentResourceName", contextualParameters[3].VariableName);
            Assert.AreEqual("id.Parent.Name", contextualParameters[3].BuildValueExpression(_idVariable).ToDisplayString());

            // parentResourceType is a variable key - should use ResourceType().Type()
            Assert.AreEqual("parentResourceType", contextualParameters[4].Key);
            Assert.AreEqual("parentResourceType", contextualParameters[4].VariableName);
            Assert.AreEqual("id.Parent.ResourceType.Type", contextualParameters[4].BuildValueExpression(_idVariable).ToDisplayString());

            Assert.AreEqual("targets", contextualParameters[5].Key);
            Assert.AreEqual("targetName", contextualParameters[5].VariableName);
            Assert.AreEqual("id.Name", contextualParameters[5].BuildValueExpression(_idVariable).ToDisplayString());
        }

        [TestCase]
        public void ValidateContextualParameters_VariableKeySegment_ParentResource()
        {
            // Test path with variable key at parent level (without the child resource)
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{parentProviderNamespace}/{parentResourceType}/{parentResourceName}");
            var operationContext = OperationContext.Create(requestPathPattern);
            var contextualParameters = operationContext.ContextualPathParameters;

            // Should have 5 parameters: subscriptionId, resourceGroupName, parentProviderNamespace, parentResourceName, parentResourceType
            Assert.AreEqual(5, contextualParameters.Count);

            Assert.AreEqual("subscriptions", contextualParameters[0].Key);
            Assert.AreEqual("subscriptionId", contextualParameters[0].VariableName);

            Assert.AreEqual("resourceGroups", contextualParameters[1].Key);
            Assert.AreEqual("resourceGroupName", contextualParameters[1].VariableName);

            // parentProviderNamespace comes from providers segment
            Assert.AreEqual("providers", contextualParameters[2].Key);
            Assert.AreEqual("parentProviderNamespace", contextualParameters[2].VariableName);
            Assert.AreEqual("id.ResourceType.Namespace", contextualParameters[2].BuildValueExpression(_idVariable).ToDisplayString());

            // parentResourceName uses the variable key - appears first due to stack order
            Assert.AreEqual("parentResourceName", contextualParameters[3].Key);
            Assert.AreEqual("parentResourceName", contextualParameters[3].VariableName);
            Assert.AreEqual("id.Name", contextualParameters[3].BuildValueExpression(_idVariable).ToDisplayString());

            // parentResourceType is a variable key
            Assert.AreEqual("parentResourceType", contextualParameters[4].Key);
            Assert.AreEqual("parentResourceType", contextualParameters[4].VariableName);
            Assert.AreEqual("id.ResourceType.Type", contextualParameters[4].BuildValueExpression(_idVariable).ToDisplayString());
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
            Assert.AreEqual(2, operationContext.ContextualPathParameters.Count);
            Assert.AreEqual("subscriptionId", operationContext.ContextualPathParameters[0].VariableName);
            Assert.AreEqual("resourceGroupName", operationContext.ContextualPathParameters[1].VariableName);

            // Secondary should have parentProviderNamespace, parentResourceType, parentResourceName, and targetName
            // Note: providers/Microsoft.Example is constant pair so skipped, targets/{targetName} has constant key
            Assert.AreEqual(4, operationContext.SecondaryContextualPathParameters.Count);

            Assert.AreEqual("providers", operationContext.SecondaryContextualPathParameters[0].Key);
            Assert.AreEqual("parentProviderNamespace", operationContext.SecondaryContextualPathParameters[0].VariableName);

            // parentResourceType is a variable key - should be included
            Assert.AreEqual("parentResourceType", operationContext.SecondaryContextualPathParameters[1].Key);
            Assert.AreEqual("parentResourceType", operationContext.SecondaryContextualPathParameters[1].VariableName);

            // parentResourceName uses the variable key
            Assert.AreEqual("parentResourceName", operationContext.SecondaryContextualPathParameters[2].Key);
            Assert.AreEqual("parentResourceName", operationContext.SecondaryContextualPathParameters[2].VariableName);

            Assert.AreEqual("targets", operationContext.SecondaryContextualPathParameters[3].Key);
            Assert.AreEqual("targetName", operationContext.SecondaryContextualPathParameters[3].VariableName);
        }
    }
}
