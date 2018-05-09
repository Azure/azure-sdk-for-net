 using System;
using System.Collections.Generic;
 using System.IO;
 using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.BotService.Models;
 using Microsoft.Azure.Management.BotService.Resources;
 using Microsoft.Azure.Management.ResourceManager;
 using Microsoft.Azure.Management.ResourceManager.Models;
 using Microsoft.Rest;
 using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Management.BotService.Customizations
{
    public class BotDeploymentInfo
    {
        public string DeploymentLocation { get; set; } = "East US";
        public bool CreateStorage { get; set; } = true;
        public string StorageAccountName { get; set; }
        public string StorageAccountResourceId { get; set; } = string.Empty;
        public bool CreateAppInsights { get; set; } = true;
        public string AppInsightsLocation { get; set; } = "East US";
        public bool CreateServerFarm { get; set; } = true;
        public string ServerFarmLocation { get; set; } = "eastus";
        public string SiteName { get; set; }
        public string AzureWebJobsDirectLineSecret { get; set; } = string.Empty;
        public string BotZipUrl { get; set; }

    }

    public static partial class BotsOperationsExtensions
    {
        private const string DefaultWebAppBotZipUrl = "https://connectorprod.blob.core.windows.net/bot-packages/csharp-abs-webapp_simpleechobot_precompiled.zip";
        private const string DefaultFunctionBotZipUrl = "https://connectorprod.blob.core.windows.net/bot-packages/csharp-abs-functions_emptybot.zip";

        /// <summary>
        /// Creates a Bot Service. Bot Service is a resource group wide resource type.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group within the user's subscription.
        /// </param>
        /// <param name='resourceName'>
        /// The name of the Bot resource.
        /// </param>
        /// <param name='parameters'>
        /// The parameters to provide for the created bot.
        /// </param>
        public static Bot CreateRegistrationBot(this IBotsOperations operations, string resourceGroupName, string resourceName, Bot parameters)
        {
            return operations.CreateRegistrationBotAsync(resourceGroupName, resourceName, parameters).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Creates a Bot Service. Bot Service is a resource group wide resource type.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group within the user's subscription.
        /// </param>
        /// <param name='resourceName'>
        /// The name of the Bot resource.
        /// </param>
        /// <param name='parameters'>
        /// The parameters to provide for the created bot.
        /// </param>
        /// <param name='deploymentInfo'>
        /// The deployment parameters to provide for the bot creation.
        /// </param>
        public static Bot CreateWebAppBot(this IBotsOperations operations, string resourceGroupName, string resourceName, Bot parameters, BotDeploymentInfo deploymentInfo)
        {
            return operations.CreateWebAppBotAsync(resourceGroupName, resourceName, parameters, deploymentInfo).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Creates a Bot Service. Bot Service is a resource group wide resource type.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group within the user's subscription.
        /// </param>
        /// <param name='resourceName'>
        /// The name of the Bot resource.
        /// </param>
        /// <param name='parameters'>
        /// The parameters to provide for the created bot.
        /// </param>
        /// <param name='deploymentInfo'>
        /// The deployment parameters to provide for the bot creation.
        /// </param>
        public static Bot CreateFunctionBot(this IBotsOperations operations, string resourceGroupName, string resourceName, Bot parameters, BotDeploymentInfo deploymentInfo)
        {
            return operations.CreateWebAppBotAsync(resourceGroupName, resourceName, parameters, deploymentInfo).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Creates a Bot Service. Bot Service is a resource group wide resource type.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group within the user's subscription.
        /// </param>
        /// <param name='resourceName'>
        /// The name of the Bot resource.
        /// </param>
        /// <param name='parameters'>
        /// The parameters to provide for the created bot.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Bot> CreateRegistrationBotAsync(this IBotsOperations operations, string resourceGroupName, string resourceName, Bot parameters, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(operations.Client.TenantId))
            {
                throw new ValidationException(ValidationRules.CannotBeNull, nameof(operations.Client.TenantId));
            }

            try
            {
                MsaAppIdInfo appInfo = await GetOrCreateMsaAppId(operations.Client, parameters, operations.Client.TenantId, resourceName).ConfigureAwait(false);
                parameters.Properties.MsaAppId = appInfo.AppId;
                parameters.Properties.MsaAppPassword = appInfo.Password;

                using (var _result = await operations.CreateWithHttpMessagesAsync(resourceGroupName, resourceName, parameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }
            catch (Exception ex)
            {
                throw new ErrorException(BotServiceErrorMessages.CreateOperationFailed, ex);
            }
        }

        /// <summary>
        /// Creates a Bot Service. Bot Service is a resource group wide resource type.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group within the user's subscription.
        /// </param>
        /// <param name='resourceName'>
        /// The name of the Bot resource.
        /// </param>
        /// <param name='parameters'>
        /// The parameters to provide for the created bot.
        /// </param>
        /// <param name='deploymentInfo'>
        /// The deployment parameters to provide for the bot creation.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Bot> CreateWebAppBotAsync(this IBotsOperations operations, string resourceGroupName, string resourceName, Bot parameters, BotDeploymentInfo deploymentInfo, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(operations.Client.TenantId))
            {
                throw new ValidationException(ValidationRules.CannotBeNull, nameof(operations.Client.TenantId));
            }

            try
            {
                MsaAppIdInfo appInfo = await GetOrCreateMsaAppId(operations.Client, parameters, operations.Client.TenantId, resourceName).ConfigureAwait(false);
                parameters.Properties.MsaAppId = appInfo.AppId;
                parameters.Properties.MsaAppPassword = appInfo.Password;
                parameters.Kind = Kind.Bot;

                var templateParams = new Dictionary<string, Dictionary<string, object>>{
                        {"zipUrl", new Dictionary<string, object>{{"value", deploymentInfo.BotZipUrl ?? DefaultWebAppBotZipUrl } }},
                        {"botId", new Dictionary<string, object>{{"value", resourceName} }},
                        {"location", new Dictionary<string, object>{{"value", deploymentInfo.DeploymentLocation } }},
                        {"kind", new Dictionary<string, object>{{"value", parameters.Kind}}},
                        {"sku", new Dictionary<string, object>{{"value", parameters.Sku.Name}}},
                        {"siteName", new Dictionary<string, object>{{"value", resourceName + "fd"} }},
                        {"appId", new Dictionary<string, object>{{"value", parameters.Properties.MsaAppId}}},
                        {"appSecret", new Dictionary<string, object>{{"value", appInfo.Password}}},
                        {"createNewStorage", new Dictionary<string, object>{{"value", deploymentInfo.CreateStorage}}},
                        {"storageAccountName", new Dictionary<string, object>{{"value", resourceName + "f32d"} }},
                        {"storageAccountResourceId", new Dictionary<string, object>{{"value", deploymentInfo.StorageAccountResourceId}}},
                        {"botEnv", new Dictionary<string, object>{{"value", "prod"}}},
                        {"useAppInsights", new Dictionary<string, object>{{"value", deploymentInfo.CreateAppInsights }}},
                        {"appInsightsLocation", new Dictionary<string, object>{{"value", deploymentInfo.AppInsightsLocation}}},
                        {"createServerFarm", new Dictionary<string, object>{{"value", true}}},
                        {"serverFarmId", new Dictionary<string, object>{{"value", $"/subscriptions/{operations.Client.SubscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{resourceName}" }}},
                        {"serverFarmLocation", new Dictionary<string, object>{{"value", deploymentInfo.ServerFarmLocation}}},
                        {"azureWebJobsBotFrameworkDirectLineSecret", new Dictionary<string, object>{{"value", ""}}},
                    };

                var deployParams = new Deployment
                {
                    Properties = new DeploymentProperties
                    {
                        Template = JObject.Parse(File.ReadAllText(@"Templates\webapp.template.json")),
                        Parameters = templateParams,
                        Mode = DeploymentMode.Incremental
                    }
                };

                var resourceClient = new ResourceManagementClient(operations.Client.Credentials);
                resourceClient.SubscriptionId = operations.Client.SubscriptionId;

                try
                {

                    var deployResult =
                        resourceClient.Deployments.CreateOrUpdate(resourceGroupName, "bot-deploy", deployParams);

                }
                catch (Exception)
                {
                    var deploy = resourceClient.Deployments.GetAsync(resourceGroupName, "bot-deploy").GetAwaiter()
                        .GetResult();
                    var ops = resourceClient.DeploymentOperations.GetAsync(resourceGroupName, "bot-deploy", deploy.Id).GetAwaiter().GetResult();
                }
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, resourceName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }
            catch (Exception ex)
            {
                throw new ErrorException(BotServiceErrorMessages.CreateOperationFailed, ex);
            }
        }

        /// <summary>
        /// Creates a Bot Service. Bot Service is a resource group wide resource type.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group within the user's subscription.
        /// </param>
        /// <param name='resourceName'>
        /// The name of the Bot resource.
        /// </param>
        /// <param name='parameters'>
        /// The parameters to provide for the created bot.
        /// </param>
        /// <param name='deploymentInfo'>
        /// The deployment parameters to provide for the bot creation.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Bot> CreateFunctionBotAsync(this IBotsOperations operations, string resourceGroupName, string resourceName, Bot parameters, BotDeploymentInfo deploymentInfo, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(operations.Client.TenantId))
            {
                throw new ValidationException(ValidationRules.CannotBeNull, nameof(operations.Client.TenantId));
            }

            try
            {
                MsaAppIdInfo appInfo = await GetOrCreateMsaAppId(operations.Client, parameters, operations.Client.TenantId, resourceName).ConfigureAwait(false);
                parameters.Properties.MsaAppId = appInfo.AppId;
                parameters.Properties.MsaAppPassword = appInfo.Password;
                parameters.Kind = Kind.Bot;

                var templateParams = new Dictionary<string, Dictionary<string, object>>{
                        {"zipUrl", new Dictionary<string, object>{{"value", deploymentInfo.BotZipUrl ?? DefaultFunctionBotZipUrl} }},
                        {"botId", new Dictionary<string, object>{{"value", resourceName} }},
                        {"location", new Dictionary<string, object>{{"value", deploymentInfo.DeploymentLocation } }},
                        {"kind", new Dictionary<string, object>{{"value", parameters.Kind}}},
                        {"sku", new Dictionary<string, object>{{"value", parameters.Sku.Name}}},
                        {"siteName", new Dictionary<string, object>{{"value", resourceName} }},
                        {"appId", new Dictionary<string, object>{{"value", parameters.Properties.MsaAppId}}},
                        {"appSecret", new Dictionary<string, object>{{"value", appInfo.Password}}},
                        {"createNewStorage", new Dictionary<string, object>{{"value", deploymentInfo.CreateStorage}}},
                        {"storageAccountName", new Dictionary<string, object>{{"value", resourceName} }},
                        {"storageAccountResourceId", new Dictionary<string, object>{{"value", deploymentInfo.StorageAccountResourceId}}},
                        {"botEnv", new Dictionary<string, object>{{"value", "prod"}}},
                        {"useAppInsights", new Dictionary<string, object>{{"value", deploymentInfo.CreateAppInsights }}},
                        {"appInsightsLocation", new Dictionary<string, object>{{"value", deploymentInfo.AppInsightsLocation}}},
                        {"createServerFarm", new Dictionary<string, object>{{"value", true}}},
                        {"serverFarmId", new Dictionary<string, object>{{"value", $"/subscriptions/{operations.Client.SubscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{resourceName}" }}},
                        {"serverFarmLocation", new Dictionary<string, object>{{"value", deploymentInfo.ServerFarmLocation}}},
                        {"azureWebJobsBotFrameworkDirectLineSecret", new Dictionary<string, object>{{"value", ""}}},
                    };

                var deployParams = new Deployment
                {
                    Properties = new DeploymentProperties
                    {
                        Template = JObject.Parse(File.ReadAllText(@"Templates\functionapp.template.json")),
                        Parameters = templateParams,
                        Mode = DeploymentMode.Incremental
                    }
                };

                var resourceClient = new ResourceManagementClient(operations.Client.Credentials);
                resourceClient.SubscriptionId = operations.Client.SubscriptionId;

                var deployResult = resourceClient.Deployments.CreateOrUpdate(resourceGroupName, "bot-deploy", deployParams);

                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, resourceName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }
            catch (Exception ex)
            {
                throw new ErrorException(BotServiceErrorMessages.CreateOperationFailed, ex);
            }
        }

        private static async Task<MsaAppIdInfo> GetOrCreateMsaAppId(AzureBotServiceClient client, Bot parameters, string tenantId, string resourceName)
        {
            MsaAppIdInfo appInfo = new MsaAppIdInfo();

            // If an MsaAppId is provided, then we use it. Otherwise, we provision one.
            if (string.IsNullOrEmpty(parameters.Properties.MsaAppId))
            {
#if NET452
                // Obtain user token with bot first party app as audience
                var authenticator = new MsaAuthenticator(tenantId);
#endif

#if NETSTANDARD1_4
                // Obtain user token with bot first party app as audience
                var authenticator = new MsaAuthenticator(tenantId, client.DeviceCodeAuthCallback);
#endif

                var authResult = await authenticator.AcquireTokenAsync().ConfigureAwait(false);

                // Provision msa app id and password
                var msaAppProvider = new MsaAppProvider(authResult);
                appInfo = await msaAppProvider.ProvisionApp(resourceName).ConfigureAwait(false);

                parameters.Properties.MsaAppId = appInfo.AppId;
            }
            else
            {
                if (string.IsNullOrEmpty(parameters.Properties.MsaAppPassword))
                {
                    throw new ArgumentException(nameof(parameters.Properties.MsaAppPassword));
                }
                appInfo.AppId = parameters.Properties.MsaAppId;
                appInfo.Password = parameters.Properties.MsaAppPassword;
            }
            return appInfo;
        }
    }
}
