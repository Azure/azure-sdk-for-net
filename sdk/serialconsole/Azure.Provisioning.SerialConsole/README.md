# Azure Provisioning Serial Console client library for .NET

Azure.Provisioning.SerialConsole simplifies declarative resource provisioning for Azure Serial Console in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.SerialConsole --prerelease
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).
The example below requires an existing virtual machine in the target resource group and the `Azure.Provisioning.Compute` package.

### Authenticate the client

Defining infrastructure and generating Bicep does not require authentication.
Deploying the generated infrastructure requires Azure credentials with permission to manage the target resources.

## Key concepts

This library allows you to specify your infrastructure declaratively using .NET.
You can then use Azure Developer CLI (`azd`) to deploy it without writing or maintaining Bicep or ARM templates.
Serial ports are extension resources: set `Scope` to the virtual machine or virtual machine scale set instance that owns the port.

## Examples

### Enable a serial port on an existing virtual machine

Provide the name of an existing virtual machine through the `virtualMachineName` parameter when deploying.

```C# Snippet:SerialConsoleBasic
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
```

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
- Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) on Stack Overflow using the Azure and .NET tags.

## Next steps

See the [Azure Provisioning documentation](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/provisioning) for building and deploying infrastructure.

## Contributing

For details on contributing to this repository, see the [contributing guide](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md).

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information, see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact <opencode@microsoft.com> with any additional questions or comments.
