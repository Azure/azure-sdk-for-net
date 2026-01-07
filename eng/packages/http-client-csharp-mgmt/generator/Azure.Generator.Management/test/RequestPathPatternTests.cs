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

        [TestCase("resourceGroup", "resourceGroup", true, Description = "Exact match should return true")]
        [TestCase("resourceGroupName", "resourceGroupName", true, Description = "Exact match with Name suffix should return true")]
        [TestCase("resourceGroup", "resourceGroupName", true, Description = "resourceGroup should match resourceGroupName")]
        [TestCase("resourceGroupName", "resourceGroup", true, Description = "resourceGroupName should match resourceGroup (bidirectional)")]
        [TestCase("subscriptionId", "subscriptionIdName", true, Description = "subscriptionId should match subscriptionIdName")]
        [TestCase("subscriptionIdName", "subscriptionId", true, Description = "subscriptionIdName should match subscriptionId (bidirectional)")]
        [TestCase("RESOURCEGROUP", "resourceGroupName", true, Description = "Case-insensitive matching should work")]
        [TestCase("resourceGroup", "RESOURCEGROUPNAME", true, Description = "Case-insensitive matching should work (reverse)")]
        [TestCase("resource", "resourceName", false, Description = "False positive: resource should NOT match resourceName")]
        [TestCase("resourceName", "resource", false, Description = "False positive: resourceName should NOT match resource")]
        [TestCase("subscription", "subscriptionId", false, Description = "Different parameters should not match")]
        [TestCase("resourceGroup", "subscriptionId", false, Description = "Unrelated parameters should not match")]
        [TestCase("name", "resourceName", false, Description = "Suffix-only match should not work")]
        [TestCase("resourceGroupName", "resourceGroupNameExtra", false, Description = "Extra suffix should not match")]
        public void AreParameterNamesEquivalent_VariousCases(string name1, string name2, bool expected)
        {
            var result = RequestPathPattern.AreParameterNamesEquivalent(name1, name2);
            Assert.AreEqual(expected, result, $"AreParameterNamesEquivalent(\"{name1}\", \"{name2}\") should return {expected}");
        }
    }
}
