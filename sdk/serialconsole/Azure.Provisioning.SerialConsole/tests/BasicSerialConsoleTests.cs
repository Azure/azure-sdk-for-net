// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Compute;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.SerialConsole.Tests;

public class BasicSerialConsoleTests
{
    internal static Trycep CreateSerialPortTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:SerialConsoleBasic
                Infrastructure infra = new();

                ProvisioningParameter virtualMachineName = new(nameof(virtualMachineName), typeof(string))
                {
                    Description = "The name of an existing virtual machine in this resource group.",
                };
                infra.Add(virtualMachineName);

                VirtualMachine vm = VirtualMachine.FromExisting(nameof(vm), VirtualMachine.ResourceVersions.V2025_04_01);
                vm.Name = virtualMachineName;
                infra.Add(vm);

                SerialPort port = new(nameof(port), SerialPort.ResourceVersions.V2024_07_01)
                {
                    Name = "0",
                    Scope = vm,
                    State = SerialPortState.Enabled,
                };
                infra.Add(port);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://learn.microsoft.com/en-us/azure/templates/microsoft.serialconsole/2024-07-01/serialports")]
    public async Task CreateSerialPort()
    {
        await using Trycep test = CreateSerialPortTest();
        test.Compare(
            """
            @description('The name of an existing virtual machine in this resource group.')
            param virtualMachineName string

            resource vm 'Microsoft.Compute/virtualMachines@2025-04-01' existing = {
              name: virtualMachineName
            }

            resource port 'Microsoft.SerialConsole/serialPorts@2024-07-01' = {
              name: '0'
              scope: vm
              properties: {
                state: 'enabled'
              }
            }
            """);
    }
}
