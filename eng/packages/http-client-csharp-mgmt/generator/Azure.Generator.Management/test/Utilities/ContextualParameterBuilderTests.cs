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
        public void ValidateContextualParametersForSubscriptionPath()
        {
            var requestPathPattern = new RequestPathPattern("/subscriptions/{subscriptionId}");

            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);

            Assert.AreEqual(1, contextualParameters.Count);
            Assert.AreEqual("subscriptions", contextualParameters[0].Key);
            Assert.AreEqual("subscriptionId", contextualParameters[0].VariableName);

            Assert.AreEqual("id.SubscriptionId", contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString());
        }

        [TestCase]
        public void ValidateContextualParametersForResourceGroupPath()
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
        public void ValidateContextualParametersForManagementGroupPath()
        {
            var requestPathPattern = new RequestPathPattern("/providers/Microsoft.Management/managementGroups/{managementGroupId}");
            var contextualParameters = ContextualParameterBuilder.BuildContextualParameters(requestPathPattern);
            Assert.AreEqual(1, contextualParameters.Count);
            Assert.AreEqual("managementGroups", contextualParameters[0].Key);
            Assert.AreEqual("managementGroupId", contextualParameters[0].VariableName);
            Assert.AreEqual("id.Name", contextualParameters[0].BuildValueExpression(_idVariable).ToDisplayString());
        }

        // TODO -- add more test cases.
    }
}
