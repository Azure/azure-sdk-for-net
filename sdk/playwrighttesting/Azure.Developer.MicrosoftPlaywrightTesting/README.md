# Microsoft Playwright Testing preview

Microsoft Playwright Testing is a fully managed service that uses the cloud to enable you to run Playwright tests with much higher parallelization across different operating system-browser combinations simultaneously. This means faster test runs with broader scenario coverage, which helps speed up delivery of features without sacrificing quality. The service also enables you to publish test results and related artifacts to the service and view them in the service portal enabling faster and easier troubleshooting. With Microsoft Playwright Testing service, you can release features faster and more confidently.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Developer.MicrosoftPlaywrightTesting --prerelease
```

### Prerequisites

- An [Azure subscription](https://azure.microsoft.com/free/dotnet/)
- Your Azure account must be assigned the [Owner](https://learn.microsoft.com/azure/role-based-access-control/built-in-roles#owner), [Contributor](https://learn.microsoft.com/azure/role-based-access-control/built-in-roles#contributor), or one of the [classic administrator roles](https://learn.microsoft.com/azure/role-based-access-control/rbac-and-directory-admin-roles#classic-subscription-administrator-roles).

## Useful links
- [Quickstart: Run end-to-end tests at scale](https://aka.ms/mpt/quickstart)
- [Quickstart: Set up continuous end-to-end testing across different browsers and operating systems](https://aka.ms/mpt/ci)
- [Explore features and benefits](https://aka.ms/mpt/about)
- [View Microsoft Playwright Testing service demo](https://youtu.be/GenC1jAeTZE)
- [Documentation](https://aka.ms/mpt/docs) 
- [Pricing](https://aka.ms/mpt/pricing)
- [Share feedback](https://aka.ms/mpt/feedback)

## Next steps

- Run tests in a [CI/CD pipeline.](https://aka.ms/mpt/configure-pipeline)

- Learn how to [manage access](https://aka.ms/mpt/manage-access) to the created workspace.

- Experiment with different number of workers to [determine the optimal configuration of your test suite](https://aka.ms/mpt/parallelism).

## Contributing

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq] or contact
[opencode@microsoft.com][coc_contact] with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/playwrighttesting/Azure.Developer.MicrosoftPlaywrightTesting/README.png)