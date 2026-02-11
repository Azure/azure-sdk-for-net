// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests
{
    public class RequestPathPatternTests
    {
        [TestCase("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}", "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}", ExpectedResult = true)]
        [TestCase("/subscriptions/{subscriptionId}", "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}", ExpectedResult = true)]
        [TestCase("/subscriptions/{subscriptionId}", "/providers/Microsoft.Management/managementGroups/{managementGroupId}", ExpectedResult = false)]
        public bool IsAncestorOf_BasicCases(string ancestor, string descendant)
        {
            var ancestorPattern = new RequestPathPattern(ancestor);
            var descendantPattern = new RequestPathPattern(descendant);
            return ancestorPattern.IsAncestorOf(descendantPattern);
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

        [TestCase("/subscriptions/{subscriptionId}", "/subscriptions/{subscriptionId}", ExpectedResult = 2)]
        [TestCase("/subscriptions/{subscriptionId}", "/subscriptions/{otherSub}", ExpectedResult = 2)]
        [TestCase("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}", "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}", ExpectedResult = 4)]
        [TestCase("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}", "/subscriptions/{subscriptionId}/providers/Microsoft.Storage", ExpectedResult = 2)]
        [TestCase("/subscriptions/{subscriptionId}", "/tenants/{tenantId}", ExpectedResult = 0)]
        [TestCase("/providers/Microsoft.Management/managementGroups/{managementGroupId}", "/providers/Microsoft.Management/managementGroups/{groupId}", ExpectedResult = 4)]
        public int GetMaximumSharingSegmentsCount_BasicCases(string left, string right)
        {
            var leftPattern = new RequestPathPattern(left);
            var rightPattern = new RequestPathPattern(right);
            return RequestPathPattern.GetMaximumSharingSegmentsCount(leftPattern, rightPattern);
        }

        [Test]
        public void GetMaximumSharingSegmentsCount_EmptyPaths()
        {
            var empty = RequestPathPattern.Tenant;
            var nonEmpty = new RequestPathPattern("/subscriptions/{subscriptionId}");
            Assert.AreEqual(0, RequestPathPattern.GetMaximumSharingSegmentsCount(empty, nonEmpty));
            Assert.AreEqual(0, RequestPathPattern.GetMaximumSharingSegmentsCount(nonEmpty, empty));
            Assert.AreEqual(0, RequestPathPattern.GetMaximumSharingSegmentsCount(empty, empty));
        }

        [Test]
        public void GetMaximumSharingSegmentsCount_DifferentLengths()
        {
            var shorter = new RequestPathPattern("/subscriptions/{subscriptionId}");
            var longer = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}");
            // Should return the count of matching segments up to the shorter path's length
            Assert.AreEqual(2, RequestPathPattern.GetMaximumSharingSegmentsCount(shorter, longer));
            Assert.AreEqual(2, RequestPathPattern.GetMaximumSharingSegmentsCount(longer, shorter));
        }

        [Test]
        public void GetMaximumSharingSegmentsCount_VariableSegmentsMatch()
        {
            var left = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}");
            var right = new RequestPathPattern("/subscriptions/{otherSub}/resourceGroups/{otherGroup}");
            // Variable segments with different names should still match
            Assert.AreEqual(4, RequestPathPattern.GetMaximumSharingSegmentsCount(left, right));
        }

        [Test]
        public void GetMaximumSharingSegmentsCount_ConstantVsVariableMismatch()
        {
            var withConstant = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/myResourceGroup");
            var withVariable = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}");
            // Constant segment vs variable segment should stop the count
            Assert.AreEqual(3, RequestPathPattern.GetMaximumSharingSegmentsCount(withConstant, withVariable));
        }

        [Test]
        public void GetMaximumSharingSegmentsCount_IsSymmetric()
        {
            var left = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}");
            var right = new RequestPathPattern("/subscriptions/{subscriptionId}/providers/Microsoft.Storage");
            // The result should be the same regardless of argument order
            Assert.AreEqual(
                RequestPathPattern.GetMaximumSharingSegmentsCount(left, right),
                RequestPathPattern.GetMaximumSharingSegmentsCount(right, left));
        }
    }
}
