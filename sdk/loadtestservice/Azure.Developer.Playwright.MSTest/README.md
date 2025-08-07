# Azure Playwright MSTest client library for .NET

Azure Playwright is a fully managed service that uses the cloud to enable you to run Playwright tests with much higher parallelization across different operating system-browser combinations simultaneously. This means faster test runs with broader scenario coverage, which helps speed up delivery of features without sacrificing quality. The service also enables you to publish test results and related artifacts to the service and view them in the service portal enabling faster and easier troubleshooting. With Azure Playwright, you can release features faster and more confidently.

Ready to get started? Jump into our [quickstart guide](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/loadtestservice/Azure.Developer.Playwright.MSTest/README.md#getting-started)!

## Useful links

-   [Quickstart: Run end-to-end tests at scale](https://aka.ms/pww/docs/quickstart)
-   [Documentation](https://aka.ms/pww/docs)
-   [Pricing](https://aka.ms/pww/docs/pricing)
-   [Share feedback](https://aka.ms/pww/docs/feedback)

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Developer.Playwright.MSTest --prerelease
```

### Prerequisites

-   An [Azure subscription](https://azure.microsoft.com/free/dotnet/)
-   Your Azure account must be assigned the [Owner](https://learn.microsoft.com/azure/role-based-access-control/built-in-roles#owner), [Contributor](https://learn.microsoft.com/azure/role-based-access-control/built-in-roles#contributor), or one of the [classic administrator roles](https://learn.microsoft.com/azure/role-based-access-control/rbac-and-directory-admin-roles#classic-subscription-administrator-roles).

### Authenticate the client

To learn more about options for Microsoft Entra Id authentication, refer to [Azure.Identity credentials](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity#credentials).

#### Create a Workspace

1. Sign in to the [Azure portal](https://portal.azure.com/) with your Azure account.

1. Create the Workspace.

   - Select the menu button in the upper-left corner of the portal, and then select Create a resource.

     ![Create a resource in Azure portal](https://aka.ms/pww/docs/createurlsnapshot)

   - Enter **Playwright Workspaces** in the search box.

   - Select the **Playwright Workspaces** card, and then select **Create**.

     ![Search for Playwright Workspaces in Azure Marketplace](https://aka.ms/pww/docs/searchurlsnapshot)

   - Provide the following information to configure a new Playwright workspace:

     | Field | Description |
     |-------|-------------|
     | **Subscription** | Select the Azure subscription that you want to use for this Playwright workspace. |
     | **Resource group** | Select an existing resource group. Or select **Create new**, and then enter a unique name for the new resource group. |
     | **Name** | Enter a unique name to identify your workspace.<br/>The name can only consist of alphanumerical characters, and have a length between 3 and 64 characters. |
     | **Location** | Select a geographic location to host your workspace.<br/>This location also determines where the test execution results are stored. |

     > [!NOTE]
     > Optionally, you can configure more details on the **Tags** tab. Tags are name/value pairs that enable you to categorize resources and view consolidated billing by applying the same tag to multiple resources and resource groups.

   - After you're finished configuring the resource, select **Review + Create**.

   - Review all the configuration settings and select **Create** to start the deployment of the Playwright workspace.

   - When the process has finished, a deployment success message appears.

   - To view the new workspace, select **Go to resource**.

     ![Deployment complete - Go to resource](https://aka.ms/pww/docs/deploymenturlsnapshot)


    ```

### Set up Azure Playwright

Create a file `PlaywrightServiceSetup.cs` in the root directory with the below content

```C# Snippet:MSTest_Sample1_SimpleSetup
using System.Threading.Tasks;
using Azure.Developer.Playwright.MSTest;
using Azure.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlaywrightService.SampleTests; // Remember to change this as per your project namespace

public class PlaywrightServiceMSTestSetup
{
    private static PlaywrightServiceBrowserMSTest playwrightClient = null!;

    [AssemblyInitialize]
    public static async Task AssemblyInitialize(TestContext testContext)
    {
        playwrightClient = new PlaywrightServiceBrowserMSTest(context: testContext, credential: new DefaultAzureCredential());
        await playwrightClient.InitializeAsync();
    }

    [AssemblyCleanup]
    public static async Task AssemblyCleanup()
    {
        await playwrightClient.DisposeAsync();
    }
}
```

> [!NOTE]
> Make sure your project uses `Microsoft.Playwright.MSTest` version 1.37 or above.

### Obtain region endpoint

1. In the [Playwright portal](https://portal.azure.com/), copy the command under **Add region endpoint in your set up**.

    ![Set workspace endpoint](https://aka.ms/pww/docs/copyurlsnapshot)

    The endpoint URL corresponds to the workspace region. You might see a different endpoint URL in the Playwright portal, depending on the region you selected when creating the workspace.

### Set up environment

Ensure that the `PLAYWRIGHT_SERVICE_URL` that you obtained in previous step is available in your environment.

### Run the tests

Run Playwright tests against browsers managed by the service using the configuration you created above.

```dotnetcli
dotnet test
```

## Key concepts

Key concepts of the Azure Playwright MSTest SDK for .NET can be found [here](https://aka.ms/mpt/what-is-mpt)

## Examples

Code samples for using this SDK can be found in the following locations

-   [.NET Azure Playwright MSTest Library Code Samples](https://aka.ms/pww/samples)

## Troubleshooting

-   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
-   Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

-   Run tests in a [CI/CD pipeline.](https://aka.ms/pww/docs/configure-pipeline)

-   Learn how to [manage access](https://aka.ms/pww/docs/manage-access) to the created workspace.

-   Experiment with different number of workers to [determine the optimal configuration of your test suite](https://aka.ms/pww/docs/parallelism).

## Contributing

This project welcomes contributions and suggestions. Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq] or contact
[opencode@microsoft.com][coc_contact] with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/loadtestservice/Azure.Developer.Playwright.MSTest/README.png)
