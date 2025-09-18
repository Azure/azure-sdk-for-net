// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests
{
    public class RequestPathPatternTests
    {
        [TestCase("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}", "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}", true)]
        [TestCase("/subscriptions/{subscriptionId}", "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}", true)]
        [TestCase("/subscriptions/{subscriptionId}", "/providers/Microsoft.Management/managementGroups/{managementGroupId}", false)]
        public void IsAncestorOf_BasicCases(string ancestor, string descendant, bool expected)
        {
            var ancestorPattern = new RequestPathPattern(ancestor);
            var descendantPattern = new RequestPathPattern(descendant);
            Assert.AreEqual(expected, ancestorPattern.IsAncestorOf(descendantPattern));
        }

        [Test]
        public void IsAncestorOf_AncestorMustBeShorterThanDescendant()
        {
            var ancestorPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}");
            var childPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}");
            // Ancestor and child are the same length, should return false
            Assert.IsFalse(ancestorPattern.IsAncestorOf(childPattern));

            var longerAncestor = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage");
            var shorterChild = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}");
            // Ancestor is longer than child, should return false
            Assert.IsFalse(longerAncestor.IsAncestorOf(shorterChild));
        }

        [Test]
        public void IsAncestorOf_VariableSegmentCheck()
        {
            var ancestorPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}");
            var descendantPattern = new RequestPathPattern("/subscriptions/{otherSub}/resourceGroups/{otherGroup}/providers/Microsoft.Storage/storageAccounts/{accountName}");
            Assert.IsTrue(ancestorPattern.IsAncestorOf(descendantPattern));
        }

        [Test]
        public void IsAncestorOf_ConstantSegmentMismatch()
        {
            var ancestorPattern = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}");
            var descendantPattern = new RequestPathPattern("/tenants/{tenantId}/resourceGroups/{resourceGroupName}");
            Assert.IsFalse(ancestorPattern.IsAncestorOf(descendantPattern));
        }
    }
}
