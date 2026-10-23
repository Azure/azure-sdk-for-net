# Azure Provisioning Billing client library for .NET

Azure.Provisioning.Billing simplifies declarative resource provisioning for Azure Billing in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.Billing --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using .NET. You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain Bicep or ARM templates.

## Examples

### Configure a billing account policy

This example creates a policy for an existing billing account.

```C# Snippet:BillingAccountPolicyBasic
Infrastructure infra = new() { TargetScope = DeploymentScope.Tenant };

BillingAccount billingAccount = BillingAccount.FromExisting(
    nameof(billingAccount),
    BillingAccount.ResourceVersions.V2024_04_01);
billingAccount.Name = "1234567";
infra.Add(billingAccount);

BillingAccountPolicy billingAccountPolicy =
    new(nameof(billingAccountPolicy), BillingAccountPolicy.ResourceVersions.V2024_04_01)
    {
        Parent = billingAccount,
        Properties = new BillingAccountPolicyProperties
        {
            MarketplacePurchases = MarketplacePurchasesPolicy.AllAllowed,
            ReservationPurchases = ReservationPurchasesPolicy.Allowed,
            SavingsPlanPurchases = SavingsPlanPurchasesPolicy.NotAllowed,
        },
    };
infra.Add(billingAccountPolicy);

infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = billingAccountPolicy.Id });
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
your contribution. For details, visit <https://cla.microsoft.com>. When
you submit a pull request, a CLA bot will automatically determine whether
you need to provide a CLA and decorate the PR appropriately (for example,
label, comment). Simply follow the instructions provided by the bot. You
will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq] or contact
[opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com