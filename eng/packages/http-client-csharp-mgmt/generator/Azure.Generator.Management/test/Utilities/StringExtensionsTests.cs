// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Utilities;
using NUnit.Framework;

namespace Azure.Generator.Mgmt.Tests.Utilities
{
    public class StringExtensionsTests
    {
        [TestCase("PlaywrightQuota", "PlaywrightQuota")]
        [TestCase("PlaywrightWorkspaceQuota", "PlaywrightWorkspaceQuota")]
        [TestCase("ChaosTargetMetadata", "ChaosTargetMetadata")]
        public void PluralizeLastWord_ReturnsExpectedPluralizedName(string input, string expected)
        {
            // Act
            var result = input.PluralizeLastWord();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase("", "")]
        [TestCase(null, null)]
        public void PluralizeLastWord_HandlesEmptyAndNullStrings(string input, string expected)
        {
            // Act
            var result = input.PluralizeLastWord();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase("Resource", "Resources")]
        [TestCase("VirtualMachine", "VirtualMachines")]
        [TestCase("Policy", "Policies")]
        public void PluralizeLastWord_PluralizesSingleAndMultiWordNames(string input, string expected)
        {
            // Act
            var result = input.PluralizeLastWord();

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
