# Microsoft Azure Playwright Testing client library for .NET

**Deprecation message**
 
This package has been deprecated and will no longer be maintained after **March 8, 2026**. Upgrade to the replacement package, **Azure.Developer.Playwright**, to continue receiving updates. Refer to the [migration guide](https://aka.ms/mpt/migration-guidance) for guidance on upgrading. Refer to our [deprecation policy](https://azure.github.io/azure-sdk/policies_support.html) for more details.

Microsoft Playwright Testing is a fully managed service that uses the cloud to enable you to run Playwright tests with much higher parallelization across different operating system-browser combinations simultaneously. This means faster test runs with broader scenario coverage, which helps speed up delivery of features without sacrificing quality. The service also enables you to publish test results and related artifacts to the service and view them in the service portal enabling faster and easier troubleshooting. With Microsoft Playwright Testing service, you can release features faster and more confidently.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Developer.MicrosoftPlaywrightTesting.TestLogger --prerelease
```

### Authenticate the client

To learn more about options for Microsoft Entra Id authentication, refer to [Azure.Identity credentials](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity#credentials). You can also refer to [our samples]<!--(https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/playwrighttesting/Azure.Developer.MicrosoftPlaywrightTesting.NUnit/samples/Sample1_CustomisingServiceParameters.md)--> on how to configurate different Azure Identity credentials.

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

## Key concepts

Key concepts of the Microsoft Playwright Testing NUnit SDK for .NET can be found [here](https://aka.ms/mpt/what-is-mpt)

## Examples

Code samples for using this SDK can be found in the following locations
- [.NET Microsoft Playwright Testing NUnit Library Code Samples](https://aka.ms/mpt/sample)

## Troubleshooting

-   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
-   Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

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
