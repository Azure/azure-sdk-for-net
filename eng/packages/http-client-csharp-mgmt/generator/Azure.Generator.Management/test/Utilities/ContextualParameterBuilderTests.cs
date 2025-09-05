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
    }
}
