# Azure Provisioning Compute client library for .NET

Azure.Provisioning.Compute simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Provisioning.Compute --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

Create an availability set:

```C# Snippet:ComputeAvailabilitySetBasic
Infrastructure infra = new();

ProvisioningParameter availabilitySetName = new(nameof(availabilitySetName), typeof(string))
{
    Description = "Availability Set Name",
    Value = "myAvSet"
};
infra.Add(availabilitySetName);

ProvisioningParameter faultDomainCount = new(nameof(faultDomainCount), typeof(int))
{
    Description = "Number of fault domains",
    Value = 3
};
infra.Add(faultDomainCount);

ProvisioningParameter updateDomainCount = new(nameof(updateDomainCount), typeof(int))
{
    Description = "Number of update domains",
    Value = 20
};
infra.Add(updateDomainCount);

AvailabilitySet avset = new(nameof(avset), AvailabilitySet.ResourceVersions.V2025_04_01)
{
    Name = availabilitySetName,
    Sku = new ComputeSku { Name = "Aligned" },
    PlatformFaultDomainCount = faultDomainCount,
    PlatformUpdateDomainCount = updateDomainCount
};
infra.Add(avset);
```

## Troubleshooting

## Next steps

## Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [https://cla.microsoft.com](https://cla.microsoft.com).

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).  For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
