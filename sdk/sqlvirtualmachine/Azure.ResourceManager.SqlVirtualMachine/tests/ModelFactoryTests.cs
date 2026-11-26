// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.SqlVirtualMachine.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SqlVirtualMachine.Tests
{
    public class ModelFactoryTests
    {
        [TestCase("resource", "legacy")]
        [TestCase(null, "legacy")]
        [TestCase("resource", null)]
        public void SqlVmDataIgnoresLegacyName(string name, string legacyName)
        {
            var data = ArmSqlVirtualMachineModelFactory.SqlVmData(name: name, sqlVmName: legacyName);
            Assert.That(data.Name, Is.EqualTo(name));
#pragma warning disable CS0618 // Verify the obsolete alias behavior.
            Assert.That(data.SqlVmName, Is.EqualTo(name));
#pragma warning restore CS0618
        }

        [TestCase("resource", "legacy")]
        [TestCase(null, "legacy")]
        [TestCase("resource", null)]
        public void SqlVmGroupDataIgnoresLegacyName(string name, string legacyName)
        {
            var data = ArmSqlVirtualMachineModelFactory.SqlVmGroupData(name: name, sqlVmGroupName: legacyName);
            Assert.That(data.Name, Is.EqualTo(name));
#pragma warning disable CS0618 // Verify the obsolete alias behavior.
            Assert.That(data.SqlVmGroupName, Is.EqualTo(name));
#pragma warning restore CS0618
        }
    }
}
