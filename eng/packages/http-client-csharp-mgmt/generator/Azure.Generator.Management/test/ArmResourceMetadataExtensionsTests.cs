// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Utilities;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests
{
    public class ArmResourceMetadataExtensionsTests
    {
        // Resource id pattern of an extension/scope-based resource (e.g., PolicyAssignment):
        // /{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}
        private const string ExtensionResourceId =
            "/{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}";

        // Resource id pattern of a resource-group-rooted resource (e.g., StorageAccount):
        // /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}
        private const string ResourceGroupResourceId =
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}";

        // Each of these four list operations targets the same PolicyAssignment resource type
        // at different scopes. All four should be recognized as collection-scope list ops.
        [TestCase("/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments")]
        [TestCase("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments")]
        [TestCase("/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policyAssignments")]
        [TestCase("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePath}/{resourceType}/{resourceName}/providers/Microsoft.Authorization/policyAssignments")]
        public void IsCollectionScopeListOperation_PolicyAssignmentMultiScopeListsAllMatch(string operationPath)
        {
            var resourceId = new RequestPathPattern(ExtensionResourceId);
            var opPath = new RequestPathPattern(operationPath);
            Assert.That(ArmResourceMetadataExtensions.IsCollectionScopeListOperation(opPath, resourceId), Is.True);
        }

        [Test]
        public void IsCollectionScopeListOperation_StandardRGListMatches()
        {
            var resourceId = new RequestPathPattern(ResourceGroupResourceId);
            var opPath = new RequestPathPattern(
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts");
            Assert.That(ArmResourceMetadataExtensions.IsCollectionScopeListOperation(opPath, resourceId), Is.True);
        }

        [Test]
        public void IsCollectionScopeListOperation_DifferentResourceTypeDoesNotMatch()
        {
            var resourceId = new RequestPathPattern(ExtensionResourceId);
            // Same provider namespace, different resource type.
            var opPath = new RequestPathPattern(
                "/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions");
            Assert.That(ArmResourceMetadataExtensions.IsCollectionScopeListOperation(opPath, resourceId), Is.False);
        }

        [Test]
        public void IsCollectionScopeListOperation_DifferentProviderNamespaceDoesNotMatch()
        {
            var resourceId = new RequestPathPattern(ExtensionResourceId);
            // Same resource type name "policyAssignments" but under a different namespace.
            var opPath = new RequestPathPattern(
                "/subscriptions/{subscriptionId}/providers/Microsoft.Other/policyAssignments");
            Assert.That(ArmResourceMetadataExtensions.IsCollectionScopeListOperation(opPath, resourceId), Is.False);
        }

        [Test]
        public void IsCollectionScopeListOperation_OperationPathTooShortDoesNotMatch()
        {
            var resourceId = new RequestPathPattern(ExtensionResourceId);
            var opPath = new RequestPathPattern("/providers/Microsoft.Authorization");
            Assert.That(ArmResourceMetadataExtensions.IsCollectionScopeListOperation(opPath, resourceId), Is.False);
        }

        // Nested sub-type resource (e.g., MgmtTypeSpec/locations/{location}/playwrightQuotas/{name})
        // The "type signature tail" includes the parametrized parent segment, and the list op
        // must reproduce that nested tail exactly.
        [Test]
        public void IsCollectionScopeListOperation_NestedSubTypeMatches()
        {
            var resourceId = new RequestPathPattern(
                "/subscriptions/{subscriptionId}/providers/MgmtTypeSpec/locations/{location}/playwrightQuotas/{name}");
            var opPath = new RequestPathPattern(
                "/subscriptions/{subscriptionId}/providers/MgmtTypeSpec/locations/{location}/playwrightQuotas");
            Assert.That(ArmResourceMetadataExtensions.IsCollectionScopeListOperation(opPath, resourceId), Is.True);
        }

        [Test]
        public void IsCollectionScopeListOperation_NestedSubTypeWithDifferentParentSegmentDoesNotMatch()
        {
            var resourceId = new RequestPathPattern(
                "/subscriptions/{subscriptionId}/providers/MgmtTypeSpec/locations/{location}/playwrightQuotas/{name}");
            var opPath = new RequestPathPattern(
                "/subscriptions/{subscriptionId}/providers/MgmtTypeSpec/regions/{location}/playwrightQuotas");
            Assert.That(ArmResourceMetadataExtensions.IsCollectionScopeListOperation(opPath, resourceId), Is.False);
        }
    }
}
