# How to authenticate to Microsoft Playwright Testing service using service access token.

This guide will walk you through the steps to integrate your Playwright project where you are launching browsers from within the tests with the service.

### Prerequisites

- An Azure account with an active subscription. If you don't have an Azure subscription, [create a free account](https://aka.ms/mpt/create-azure-subscription) before you begin.
- Your Azure account must be assigned the [Owner](https://learn.microsoft.com/en-us/azure/role-based-access-control/built-in-roles#owner), [Contributor](https://learn.microsoft.com/en-us/azure/role-based-access-control/built-in-roles#contributor), or one of the [classic administrator roles](https://learn.microsoft.com/en-us/azure/role-based-access-control/rbac-and-directory-admin-roles#classic-subscription-administrator-roles).
- [Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli) must be installed in the machine from where you are running Playwright tests. 

### Create a Workspace

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

### Install Microsoft Playwright Testing package

1. Run this command to install the service package

    ```dotnetcli
    dotnet add package Azure.Developer.MicrosoftPlaywrightTesting.NUnit
    ```

### Setup Microsoft Playwright Testing

1. Create a file `PlaywrightServiceSetup.cs` in the root directory with the following

    ```c#
    using Azure.Developer.MicrosoftPlaywrightTesting.NUnit;

    namespace PlaywrightTests; // Remember to change this as per your project namespace

    [SetUpFixture]
    public class PlaywrightServiceSetup : PlaywrightServiceNUnit;
    ```

2. Create a .runsettings file to modify default authentication mechanism.

    ```xml
    <?xml version="1.0" encoding="utf-8"?>
    <RunSettings>
        <TestRunParameters>
            <!-- Set the default auth as TOKEN -->
            <Parameter name="DefaultAuth" value="TOKEN" />
        </TestRunParameters>
    </RunSettings>
    ```

> [!NOTE]
> Make sure your project uses Microsoft.Playwright.NUnit version 1.37 or above.

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

**NOTE**: If you are a part of multiple tenants, you will have to login to a particular tenant. Run `az login --tenant=<TENANT_ID>' to sign in to the tenant where the workspace is created. You can find the tenant id through these [steps.](https://learn.microsoft.com/en-us/entra/fundamentals/how-to-find-tenant)

### Run the tests

Run Playwright tests against browsers managed by the service using the configuration you created above.

```dotnetcli
dotnet test --settings .runsettings
```