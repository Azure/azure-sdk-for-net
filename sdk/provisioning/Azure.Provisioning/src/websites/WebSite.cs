// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.AppService;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.Models;
using Azure.Provisioning.ResourceManager;
using System;
using System.Collections.Generic;

namespace Azure.Provisioning.AppService
{
    /// <summary>
    /// Runtime for the web site.
    /// </summary>
    public enum WebSiteRuntime
    {
        /// <summary>
        /// Node runtime.
        /// </summary>
        Node,
        /// <summary>
        /// Dotnet runtime.
        /// </summary>
        Dotnetcore
    }

    /// <summary>
    /// The web site resource.
    /// </summary>
    public class WebSite : Resource<WebSiteData>
    {
        private const string ResourceTypeName = "Microsoft.Web/sites";
        private static WebSiteData Empty(string name) => ArmAppServiceModelFactory.WebSiteData();

        private ApplicationSettingsResource AppSettings { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebSite"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="appServicePlan">The appServicePlan.</param>
        /// <param name="runtime">The runtime.</param>
        /// <param name="runtimeVersion">The runtime version</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        /// <param name="parent">The resource group. </param>
        public WebSite(IConstruct scope, string name, AppServicePlan appServicePlan, WebSiteRuntime runtime, string runtimeVersion, string version = "2021-02-01", AzureLocation? location = default, ResourceGroup? parent = null)
            : this(scope, name, appServicePlan, runtime, runtimeVersion, version, location, parent, false, (name) => ArmAppServiceModelFactory.WebSiteData(
                name: name,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                resourceType: ResourceTypeName,
                kind: "app,linux",
                appServicePlanId: appServicePlan?.Id,
                siteConfig: ArmAppServiceModelFactory.SiteConfigProperties(
                    linuxFxVersion: $"{runtime.ToString().ToLower()}|{runtimeVersion}",
                    isAlwaysOn: true,
                    ftpsState: AppServiceFtpsState.FtpsOnly,
                    minTlsVersion: "1.2",
                    appCommandLine: runtime == WebSiteRuntime.Dotnetcore ? string.Empty : "./entrypoint.sh -o ./env-config.js && pm2 serve /home/site/wwwroot --no-daemon --spa",
                    cors: new AppServiceCorsSettings()
                    {
                        AllowedOrigins =
                        {
                            "https://portal.azure.com",
                            "https://ms.portal.azure.com"
                        }
                    }),
                isHttpsOnly: true,
                identity: new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)))
        {
        }

        private WebSite(IConstruct scope, string name, AppServicePlan? appServicePlan = default, WebSiteRuntime runtime = default, string? runtimeVersion = default, string version = "2021-02-01", AzureLocation? location = default, ResourceGroup? parent = null, bool isExisting = false, Func<string, WebSiteData>? creator = null)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
            var appSettings = runtime == WebSiteRuntime.Dotnetcore
            ? new Dictionary<string, string>()
            {
                    { "SCM_DO_BUILD_DURING_DEPLOYMENT", "False"},
                    { "ENABLE_ORYX_BUILD", "True"}
            }
            : new Dictionary<string, string>();
            AppSettings = new ApplicationSettingsResource(Scope, appSettings, this);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="AppServicePlan"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static WebSite FromExisting(IConstruct scope, string name, ResourceGroup? parent = null)
            => new WebSite(scope, parent: parent, name: name, isExisting: true);

        /// <summary>
        /// Adds an application setting to the web site.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void AddApplicationSetting(string key, string value)
        {
            AppSettings.AddApplicationSetting(key, value);
        }

        /// <summary>
        /// Adds an application setting to the web site.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void AddApplicationSetting(string key, Parameter value)
        {
            AppSettings.AddApplicationSetting(key, value);
        }

        /// <summary>
        /// Adds a log configuration to the web site.
        /// </summary>
        /// <param name="resourceName">The resource name.</param>
        public void AddLogConfig(string resourceName)
        {
            var logConfig = new WebSiteConfigLogs(Scope, resourceName, this);
            logConfig.AddDependency(AppSettings);
        }
    }
}
