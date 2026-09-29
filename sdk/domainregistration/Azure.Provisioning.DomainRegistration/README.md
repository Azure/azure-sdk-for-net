# Azure Provisioning DomainRegistration client library for .NET

Azure.Provisioning.DomainRegistration simplifies declarative resource provisioning for Azure App Service domains in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.DomainRegistration --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet. You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

### Create an App Service domain

This example demonstrates how to create an App Service domain resource.

```C# Snippet:DomainRegistrationBasic
Infrastructure infra = new();

RegistrationContactInfo CreateContact() =>
  new()
  {
      AddressMailing = new RegistrationAddressInfo
      {
          Address1 = "1 Microsoft Way",
          City = "Redmond",
          Country = "US",
          PostalCode = "98052",
          State = "WA",
      },
      Email = "admin@example.com",
      NameFirst = "Azure",
      NameLast = "SDK",
      Phone = "+1.4255550100",
  };

AppServiceDomain domain =
    new(nameof(domain), AppServiceDomain.ResourceVersions.V2024_11_01)
    {
        Name = "example.com",
        ContactAdmin = CreateContact(),
        ContactBilling = CreateContact(),
        ContactRegistrant = CreateContact(),
        ContactTech = CreateContact(),
        Consent = new DomainPurchaseConsent
        {
            AgreementKeys = { "agreement-key" },
            AgreedBy = "192.0.2.1",
            AgreedOn = DateTimeOffset.Parse("2026-01-01T00:00:00Z"),
        },
        IsAutoRenew = true,
        IsDomainPrivacyEnabled = true,
    };
infra.Add(domain);
```

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
- Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

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
