# Microsoft Playwright Testing client library for .NET
Microsoft Playwright Testing is a fully managed service that uses the cloud to enable you to run Playwright tests with much higher parallelization across different operating system-browser combinations simultaneously. This means faster test runs with broader scenario coverage, which helps speed up delivery of features without sacrificing quality. The service also enables you to publish test results and related artifacts to the service and view them in the service portal enabling faster and easier troubleshooting. With Microsoft Playwright Testing service, you can release features faster and more confidently.

Ready to get started? Jump into our [quickstart guide](#get-started)!

## Useful links
- [Quickstart: Run end-to-end tests at scale](https://aka.ms/mpt/quickstart)
- [View Microsoft Playwright Testing service demo](https://youtu.be/GenC1jAeTZE)
- [Documentation](https://aka.ms/mpt/docs) 
- [Pricing](https://aka.ms/mpt/pricing)
- [Share feedback](https://aka.ms/mpt/feedback)

## Get Started
Follow these steps to run your existing Playwright test suite with the service.

### Install Microsoft Playwright Testing package

1. Run this command to install the service package

    ```dotnetcli
- Your Azure account must be assigned the [Owner](https://learn.microsoft.com/azure/role-based-access-control/built-in-roles#owner), [Contributor](https://learn.microsoft.com/azure/role-based-access-control/built-in-roles#contributor), or one of the [classic administrator roles](https://learn.microsoft.com/azure/role-based-access-control/rbac-and-directory-admin-roles#classic-subscription-administrator-roles).

### Prerequisites

- An Azure account with an active subscription. If you don't have an Azure subscription, [create a free account](https://aka.ms/mpt/create-azure-subscription) before you begin.
- Your Azure account must be assigned the [Owner](https://learn.microsoft.com/en-us/azure/role-based-access-control/built-in-roles#owner), [Contributor](https://learn.microsoft.com/en-us/azure/role-based-access-control/built-in-roles#contributor), or one of the [classic administrator roles](https://learn.microsoft.com/en-us/azure/role-based-access-control/rbac-and-directory-admin-roles#classic-subscription-administrator-roles).
- [Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli) must be installed in the machine from where you are running Playwright tests. 
- Your Azure account must be assigned the [Owner](https://learn.microsoft.com/azure/role-based-access-control/built-in-roles#owner), [Contributor](https://learn.microsoft.com/azure/role-based-access-control/built-in-roles#contributor), or one of the [classic administrator roles](https://learn.microsoft.com/azure/role-based-access-control/rbac-and-directory-admin-roles#classic-subscription-administrator-roles).
#### Create a Workspace

1. Sign in to the [Playwright portal](https://aka.ms/mpt/portal) with your Azure account.

2. Create the Workspace.

    ![Create new workspace](https://github.com/microsoft/playwright-testing-service/assets/12104064/d571e86b-9d43-48ac-a2b7-63afb9bb86a8)

    |Field  |Description  |
    |---------|---------|
    |**Workspace Name** | A unique name to identify your workspace.<BR>The name can't contain special characters or whitespace. |
    |**Azure Subscription** | Select an Azure subscription where you want to create the workspace. |
    |**Region** | This is where test run data will be stored for your workspace. |

  > [!NOTE]
  > If you don't see this screen, select an existing workspace and go to the next section.
    ```

### Set up Microsoft Playwright Testing

1. Create a file `PlaywrightServiceSetup.cs` in the root directory with the below content

    ```c#
    using Azure.Developer.MicrosoftPlaywrightTesting.NUnit;

    namespace PlaywrightTests; // Remember to change this as per your project namespace

    [SetUpFixture]
    public class PlaywrightServiceSetup : PlaywrightServiceNUnit;
    ```

> [!NOTE]
> Make sure your project uses `Microsoft.Playwright.NUnit` version 1.37 or above.

### Obtain region endpoint

1. In the [Playwright portal](https://aka.ms/mpt/portal), copy the command under **Add region endpoint in your set up**.

    ![Set workspace endpoint](https://github.com/microsoft/playwright-testing-service/assets/12104064/d81ca629-2b23-4d34-8b70-67b6f7061a83)

    The endpoint URL corresponds to the workspace region. You might see a different endpoint URL in the Playwright portal, depending on the region you selected when creating the workspace.

### Set up environment

Ensure that the `PLAYWRIGHT_SERVICE_URL` that you obtained in previous step is available in your environment.

### Sign in to Azure

You need to sign in to Azure using Azure CLI to enable authentication via Microsoft Entra ID.  Run the command to sign-in

```azurecli
az login
```

**NOTE**: If you are a part of multiple tenants, you will have to login to a particular tenant. Run `az login --tenant=<TENANT_ID>' to sign in to the tenant where the workspace is created. You can find the tenant id through these [steps.](https://learn.microsoft.com/entra/fundamentals/how-to-find-tenant)

### Run the tests

Run Playwright tests against browsers managed by the service using the configuration you created above.

```dotnetcli
dotnet test --logger "ms-playwright-service"
```

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
