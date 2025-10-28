# System.String[] client library for .NET

Azure.Provisioning.Dns simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Provisioning.Dns --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

### Create a DNS Zone

This template shows how to create a DNS zone within Azure DNS and how to add some record sets to it.

```C# Snippet:CreateAzureDnsNewZone
Infrastructure infra = new();

ProvisioningParameter zoneName = new(nameof(zoneName), typeof(string))
{
    Description = "The name of the DNS zone to be created.  Must have at least 2 segments, e.g. hostname.org",
    Value = BicepFunction.Interpolate($"{BicepFunction.GetUniqueString(BicepFunction.GetResourceGroup().Id)}.azurequickstart.org")
};
infra.Add(zoneName);

ProvisioningParameter recordName = new(nameof(recordName), typeof(string))
{
    Description = "The name of the DNS record to be created.  The name is relative to the zone, not the FQDN.",
    Value = "www"
};
infra.Add(recordName);

DnsZone zone = new(nameof(zone), DnsZone.ResourceVersions.V2018_05_01)
{
    Name = zoneName,
    Location = new AzureLocation("global")
};
infra.Add(zone);

DnsARecord aRecord = new(nameof(aRecord), DnsARecord.ResourceVersions.V2018_05_01)
{
    Parent = zone,
    Name = recordName,
    TtlInSeconds = 3600,
    ARecords =
    {
        new DnsARecordInfo() { Ipv4Addresses = IPAddress.Parse("203.0.113.1") },
        new DnsARecordInfo() { Ipv4Addresses = IPAddress.Parse("203.0.113.2") }
    }
};
infra.Add(aRecord);
```

## Troubleshooting

-   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
-   Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

## Contributing

For details on contributing to this repository, see the [contributing
guide][cg].

This project welcomes contributions and suggestions. Most contributions
require you to agree to a Contributor License Agreement (CLA) declaring
that you have the right to, and actually do, grant us the rights to use
your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine
whether you need to provide a CLA and decorate the PR appropriately
(for example, label, comment). Follow the instructions provided by the
bot. You'll only need to do this action once across all repositories
using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For
more information, see the [Code of Conduct FAQ][coc_faq] or contact
<opencode@microsoft.com> with any other questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
