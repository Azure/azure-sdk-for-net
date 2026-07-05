# Azure Provisioning Monitor client library for .NET

Azure.Provisioning.Monitor simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Provisioning.Monitor --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

### Create a Service Health Alert with Action Group

This example demonstrates how to create an Azure service health alert that sends email notifications using an action group.

```C# Snippet:MonitorServiceHealthAlert
Infrastructure infra = new();

ProvisioningParameter alertName =
    new(nameof(alertName), typeof(string))
    {
        Description = "Specify the name of the alert."
    };
infra.Add(alertName);

ProvisioningParameter emailAddress =
    new(nameof(emailAddress), typeof(string))
    {
        Value = "email@example.com",
        Description = "Specify the email address where the alerts are sent to."
    };
infra.Add(emailAddress);

ProvisioningParameter emailName =
    new(nameof(emailName), typeof(string))
    {
        Value = "Example",
        Description = "Specify the email address name where the alerts are sent to."
    };
infra.Add(emailName);

ActionGroup emailActionGroup =
    new(nameof(emailActionGroup), ActionGroup.ResourceVersions.V2023_01_01)
    {
        Location = new AzureLocation("global"),
        GroupShortName = "string",
        IsEnabled = true,
        EmailReceivers =
        {
            new MonitorEmailReceiver
            {
                Name = emailName,
                EmailAddress = emailAddress,
                UseCommonAlertSchema = true
            }
        }
    };
infra.Add(emailActionGroup);

ActivityLogAlert alert =
    new(nameof(alert), ActivityLogAlert.ResourceVersions.V2020_10_01)
    {
        Name = alertName,
        Location = new AzureLocation("global"),
        IsEnabled = true,
        Scopes =
        {
            BicepFunction.GetSubscription().Id
        },
        ConditionAllOf =
        {
            new ActivityLogAlertAnyOfOrLeafCondition
            {
                Field = "category",
                EqualsValue = "ResourceHealth"
            }
        },
        ActionsActionGroups =
        {
            new ActivityLogAlertActionGroup
            {
                ActionGroupId = emailActionGroup.Id
            }
        }
    };
infra.Add(alert);
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