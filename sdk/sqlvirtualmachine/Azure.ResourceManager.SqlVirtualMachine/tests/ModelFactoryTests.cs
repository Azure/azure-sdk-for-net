// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.SqlVirtualMachine.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SqlVirtualMachine.Tests
{
    public class ModelFactoryTests
    {
        [TestCase("resource", "legacy", "legacy")]
        [TestCase(null, "legacy", "legacy")]
        [TestCase("resource", null, "resource")]
        public void SqlVmDataPreservesLegacyName(string name, string legacyName, string expected)
        {
            var data = ArmSqlVirtualMachineModelFactory.SqlVmData(name: name, sqlVmName: legacyName);
            Assert.That(data.Name, Is.EqualTo(name));
            Assert.That(data.SqlVmName, Is.EqualTo(expected));
        }

        [TestCase("resource", "legacy", "legacy")]
        [TestCase(null, "legacy", "legacy")]
        [TestCase("resource", null, "resource")]
        public void SqlVmGroupDataPreservesLegacyName(string name, string legacyName, string expected)
        {
            var data = ArmSqlVirtualMachineModelFactory.SqlVmGroupData(name: name, sqlVmGroupName: legacyName);
            Assert.That(data.Name, Is.EqualTo(name));
            Assert.That(data.SqlVmGroupName, Is.EqualTo(expected));
        }
    }
}
