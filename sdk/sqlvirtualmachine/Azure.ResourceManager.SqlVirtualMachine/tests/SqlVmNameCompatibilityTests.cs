// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using Azure.ResourceManager.SqlVirtualMachine.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SqlVirtualMachine.Tests
{
    public class SqlVmNameCompatibilityTests
    {
        [Test]
        public void LegacyNamesUseResourceName()
        {
            BinaryData json = BinaryData.FromString("{\"name\":\"resource-name\"}");
            SqlVmData vm = ModelReaderWriter.Read<SqlVmData>(json, ModelReaderWriterOptions.Json, AzureResourceManagerSqlVirtualMachineContext.Default);
            SqlVmGroupData group = ModelReaderWriter.Read<SqlVmGroupData>(json, ModelReaderWriterOptions.Json, AzureResourceManagerSqlVirtualMachineContext.Default);
            Assert.That(vm.SqlVmName, Is.EqualTo("resource-name"));
            Assert.That(group.SqlVmGroupName, Is.EqualTo("resource-name"));

            SqlVmData vmFromFactory = ArmSqlVirtualMachineModelFactory.SqlVmData(name: "vm-name", sqlVmName: "legacy-argument");
            SqlVmGroupData groupFromFactory = ArmSqlVirtualMachineModelFactory.SqlVmGroupData(name: "group-name", sqlVmGroupName: "legacy-argument");
            Assert.That(vmFromFactory.SqlVmName, Is.EqualTo("vm-name"));
            Assert.That(vmFromFactory.Name, Is.EqualTo("vm-name"));
            Assert.That(groupFromFactory.SqlVmGroupName, Is.EqualTo("group-name"));
            Assert.That(groupFromFactory.Name, Is.EqualTo("group-name"));
        }
    }
}
