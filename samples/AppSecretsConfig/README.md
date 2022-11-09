---
page_type: sample
languages:
- aspx-csharp
- csharp
products:
- azure
- azure-app-configuration
- azure-key-vault
urlFragment: app-secrets-configuration
name: Configure Applications with App Configuration and Key Vault
description: Improve application startup performance when configuring secrets in Key Vault using Azure App Configuration.
---

# Configure Applications with App Configuration and Key Vault

The [Azure Key Vault][keyvault_overview] provides a great service to store application secrets and use them to configure your applications; however, with relatively [low limits][keyvault_limits] some applications referencing Key Vault with a lot of secrets or even clustered applications referencing fewer secrets can get rate limited and experience slow startup performance. You should instead use [Azure App Configuration][appconfig_overview] to store non-secrets and define references to secrets in Key Vault to reduce the number of calls made to Key Vault.

Examples of non-secrets that should be stored in App Configuration:

* Client application IDs
* IP addresses
* Service endpoints
* Service configuration parameters
* Usernames

Examples of secrets that should be stored in Key Vault:

* Client application secrets
* Connection strings
* Passwords
* Shared access keys
* SSH keys

## Getting started

To build and run this sample you will need:

Software:

* [.NET][dotnet_install]
* [Azure CLI][azure_cli]

Azure services:

* [App Configuration][appconfig_overview]
* [Key Vault][keyvault_overview]
* (Optional) [App Service][appservice_overview] - needed to deploy the web application to Azure, which is provisioned in the [Bicep][bicep_overview] [template][sample_template].

  > [!NOTE]
  > App Service has [support for referencing Key Vault secrets][appservice_secrets] directly, but is used only as an example how to configure a web site to use App Configuration.
  > If you choose to deploy your web application to another service, the same principles to configure the App Configuration connection string still apply.

* (Optional) [Application Insights][appinsights_overview] - to monitor web traffic and application traces, which is *not* provisioned in the Bicep template.

[![Deploy to Azure](https://aka.ms/deploytoazurebutton)][sample_deploy]

To deploy the template manually, make sure your [Azure CLI][azure_cli] is up to date and run:

```bash
az bicep install # if deploying azuredeploy.bicep
az group create --location {location} --resource-group {group-name}
az deployment group create --resource-group {group-name} --template-file azuredeploy.bicep # or azuredeploy.json
```

There are a number of parameters you can optional set. [View the template][sample_template] for details.

After deployment completes, make note of the output variables as shown in the example below:

```json
{
  "outputs": {
    "appConfigConnectionString": {
      "type": "String",
      "value": "Endpoint=https://{appconfig-host-name}.azconfig.io;Id={id};Secret={secret}"
    },
    "siteUrl": {
      "type": "String",
      "value": "https://{site-host-name}.azurewebsites.net/"
    },
    "vaultUrl": {
      "type": "String",
      "value": "https://{vault-host-name}.vault.azure.net/"
    }
  }
}
```

### Building the sample

You can build, run, and even deploy the sample using [Visual Studio][visualstudio], [Visual Studio Code][visualstudiocode], or the [.NET command line interface (CLI)][dotnet_cli]. Using the `dotnet` CLI, for example, within the directory containing the sample application source run:

```dotnetcli
dotnet build
```

### Running the sample

Before you can run the sample locally you'll need to grant access to the Key Vault for your local user account or service principal. If you're logged into your tenant in Visual Studio and the Azure CLI using the same principal, you can find the UPN or SPN the same way:

```bash
az account show
```

If you're logged in as a user, you will see your email address and can pass that to the `--upn` parameter:

```bash
az keyvault set-policy -n {vault-host-name} --upn {user@domain.com} --secret-permissions get
```

If you're logged in as a service principal, the `user.type` will be `servicePrincipal` and you'll pass the the `user.name` to the `--spn` parameter:

```bash
az keyvault set-policy -n {vault-host-name} --spn {spn} --secret-permissions get
```

Next you'll need to add the App Configuration connection string from the template deployment outputs to your local user secrets:

#### [Visual Studio](#tab/visualstudio)

1. Right-click on the project
2. Click **Managed User Secrets**
3. Add a variable named `ConnectionStrings:AppConfig` with the `value` of the `appConfigurationConnectionString` output variable:

   ```json
   {
     "ConnectionStrings:AppConfig": "Endpoint=https://{appconfig-host-name}.azconfig.io;Id={id};Secret={secret}"
   }
   ```

4. Click **Debug -> Start debugging (F5)** to run.

#### [Visual Studio Code](#tab/visualstudiocode)

1. In the project folder, run the following to add a variable named `ConnectionStrings:AppConfig` with the `value` of the `appConfigurationConnectionString` output variable:

   ```dotnetcli
   dotnet user-secrets set "ConnectionStrings:AppConfig" "Endpoint=https://{appconfig-host-name}.azconfig.io;Id={id};Secret={secret}"
   ```

2. With a *.cs* file open the command palette and run `Debug: Start debugging` or press `F5` (default binding).
3. If prompted, select ".NET Core" to create a launch configuration and start debugging.

#### [.NET](#tab/dotnet)

1. In the project folder, run the following to add a variable named `ConnectionStrings:AppConfig` with the `value` of the `appConfigurationConnectionString` output variable:

   ```dotnetcli
   dotnet user-secrets set "ConnectionStrings:AppConfig" "Endpoint=https://{appconfig-host-name}.azconfig.io;Id={id};Secret={secret}"
   ```

2. Run the project:

   ```dotnetcli
   dotnet run
   ```

---

### Deploying the sample

See the [ASP.NET quickstart][aspnet_quickstart] for instructions to deploy for Visual Studio, Visual Studio Code, and the `dotnet` CLI. For Visual Studio and Visual Studio Code, make sure you select your existing resource if you deployed the Bicep template above; otherwise, for the `dotnet` CLI you can deploy to an existing resource by [configuring Git support][aspnet_deploy_localgit] and pushing source, which will be built automatically on the host.

## Configuring App Configuration with Key Vault references

Using [Azure App Configuration][appconfig_overview] is an efficient way to store application configuration key-value pairs, and can [reference][keyvault_references] [Key Vault][keyvault_overview] secrets. The App Configuration service itself doesn't need access to these secrets, but your application - like the sample web application here - will need nothing more than `get` access to Key Vault secrets. [Configuration in ASP.NET][aspnet_config] enumerates key-value pairs from a number of configured providers, which not only requires both `list` and `get` permissions to Key Vault but is the main cause of application startup performance problems or even failures. By using the [Microsoft.Extensions.Configuration.AzureAppConfiguration][nuget_azureappconfig] package you can reduce the calls to Key Vault while the package itself will automatically fetch secrets' values as needed.

1. Add the following package to your project:

   ```dotnetcli
   dotnet add package Azure.Identity
   dotnet add package Microsoft.Extensions.Configuration.AzureAppConfiguration
   ```

2. At the top of _Program.cs_ (or wherever your entry point is defined) add the following `using` statements:

   ```csharp
   using Azure.Identity;
   using Microsoft.Extensions.Configuration;
   ```

3. Update the `CreateHostBuilder` method to call the `ConfigureAppConfiguration` extension method as shown below:

   ```csharp
   public static IHostBuilder CreateHostBuilder(string[] args) =>
       Host.CreateDefaultBuilder(args)
           .ConfigureWebHostDefaults(webBuilder =>
           {
               webBuilder.ConfigureAppConfiguration(config =>
               {
                   var settings = config.Build();
                   var connectionString = settings.GetConnectionString("AppConfig");
   
                   config.AddAzureAppConfiguration(options =>
                   {
                       options.Connect(connectionString);
                       options.ConfigureKeyVault(options =>
                       {
                           options.SetCredential(new DefaultAzureCredential());
                       });
                   });
               })
               .UseStartup<Startup>();
           });
   ```

This uses the `ConnectionStrings:AppConfig` defined within the deployed web application or locally in your user secrets to connect to Azure App Configuration. Whenever a referenced secret is enumerated, the configuration provider will automatically retrieve it using the [`DefaultAzureCredential`][identity_defaultazurecredential] that is designed to work optimally in both development and production environments without code changes. When running from the deployed web application, the web application's system identity is used to connect to Key Vault. When running locally, a number of your local credentials are attempted including your [Visual Studio][visualstudio], [Visual Studio Code][visualstudiocode], and [Azure CLI][azure_cli] credentials. If you see an error message that your local application is not authorized for the deployed Key Vault, see our [troubleshooting section][identity_troubleshooting] for help.

## Caching clients

You can also reduce the number of calls to [Azure Key Vault][keyvault_overview] by caching your [`SecretClient`][keyvault_secretclient] or any other Key Vault SDK client. Our clients are designed to reuse an `HttpClient` by default and cache authentication bearer tokens for service like Key Vault to reduce the number of calls to authenticate. You can use our [Microsoft.Extensions.Azure][nuget_azureextensions] to [cache clients][keyvault_injection] and use them elsewhere:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddAzureClients(config =>
    {
        config.UseCredential(new DefaultAzureCredential());

        // Assumes the deployed Key Vault URL is stored in a variable named KEYVAULT_URL.
        config.AddSecretClient(new Uri(Configuration["KEYVAULT_URL"]));
    });

    services.AddRazorPages();
}
```

In [ASP.NET Razor pages][aspnet_razor] as an example, you can then inject them into the page:

```aspx-csharp
@using Azure.Security.KeyVault.Secrets;
@inject SecretClient SecretClient

<p>Connected to @SecretClient.VaultUri</p>
```

## Additional documentation

* [Azure App Configuration][appconfig_overview]
* [Azure Key Vault][keyvault_overview]
* [Deploy an ASP.NET web app][aspnet_quickstart]
* [Use Key Vault references in an ASP.NET Core app][keyvault_references]

[appconfig_overview]: https://docs.microsoft.com/azure/azure-app-configuration/overview
[appinsights_overview]: https://docs.microsoft.com/azure/azure-monitor/app/app-insights-overview
[appservice_overview]: https://docs.microsoft.com/azure/app-service/overview
[appservice_secrets]: https://docs.microsoft.com/azure/app-service/app-service-key-vault-references#rotation
[aspnet_config]: https://docs.microsoft.com/aspnet/core/fundamentals/configuration
[aspnet_deploy_localgit]: https://docs.microsoft.com/azure/app-service/deploy-local-git
[aspnet_quickstart]: https://docs.microsoft.com/azure/app-service/quickstart-dotnetcore
[aspnet_razor]: https://docs.microsoft.com/aspnet/core/razor-pages/
[azure_cli]: https://docs.microsoft.com/cli/azure/
[bicep_overview]: https://docs.microsoft.com/azure/azure-resource-manager/bicep/overview
[dotnet_cli]: https://docs.microsoft.com/dotnet/core/tools/
[dotnet_install]: https://dotnet.microsoft.com/download
[identity_defaultazurecredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential
[identity_troubleshooting]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#troubleshooting
[keyvault_injection]: https://docs.microsoft.com/dotnet/api/overview/azure/microsoft.extensions.azure-readme
[keyvault_limits]: https://docs.microsoft.com/azure/key-vault/general/service-limits
[keyvault_overview]: https://docs.microsoft.com/azure/key-vault/general/overview
[keyvault_references]: https://docs.microsoft.com/azure/azure-app-configuration/use-key-vault-references-dotnet-core
[keyvault_secretclient]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Secrets/README.md#secretclient
[nuget_azureappconfig]: https://nuget.org/packages/Microsoft.Extensions.Configuration.AzureAppConfiguration
[nuget_azureextensions]: https://nuget.org/packages/Microsoft.Extensions.Azure
[sample_deploy]: https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FAzure%2Fazure-sdk-for-net%2Fmain%2Fsamples%2FAppSecretsConfig%2Fazuredeploy.json
[sample_template]: https://github.com/Azure/azure-sdk-for-net/blob/main/samples/AppSecretsConfig/azuredeploy.bicep
[visualstudio]: https://visualstudio.microsoft.com/
[visualstudiocode]: https://code.visualstudio.com/
