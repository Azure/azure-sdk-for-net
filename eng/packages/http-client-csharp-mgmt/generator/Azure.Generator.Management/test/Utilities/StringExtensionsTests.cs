// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Utilities;
using NUnit.Framework;

namespace Azure.Generator.Mgmt.Tests.Utilities
{
    public class StringExtensionsTests
    {
        [TestCase("PlaywrightQuota", "GetAllPlaywrightQuota")]
        [TestCase("PlaywrightWorkspaceQuota", "GetAllPlaywrightWorkspaceQuota")]
        [TestCase("ChaosTargetMetadata", "GetAllChaosTargetMetadata")]
        public void GetCollectionMethodName_ReturnsGetAllPrefix_WhenPluralUnchanged(string input, string expected)
        {
            // Act
            var result = input.GetCollectionMethodName();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase("Resource", "GetResources")]
        [TestCase("VirtualMachine", "GetVirtualMachines")]
        [TestCase("Policy", "GetPolicies")]
        public void GetCollectionMethodName_ReturnsGetPrefix_WhenPluralChanged(string input, string expected)
        {
            // Act
            var result = input.GetCollectionMethodName();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase("", "")]
        [TestCase(null, null)]
        public void GetCollectionMethodName_HandlesEmptyAndNullStrings(string input, string expected)
        {
            // Act
            var result = input.GetCollectionMethodName();

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
