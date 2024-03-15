// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.AppService;
using Azure.ResourceManager.AppService.Models;

namespace Azure.Provisioning.AppService
{
    /// <summary>
    /// The logs configuration for a web site.
    /// </summary>
    public class WebSiteConfigLogs : Resource<SiteLogsConfigData>
    {
        private const string ResourceTypeName = "Microsoft.Web/sites/config";
        private static SiteLogsConfigData Empty(string name) => ArmAppServiceModelFactory.SiteLogsConfigData();

        /// <summary>
        /// Initializes a new instance of the <see cref="WebSiteConfigLogs"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        public WebSiteConfigLogs(IConstruct scope, string name, WebSite? parent = null, string version = "2021-02-01", AzureLocation? location = default)
            : this(scope, name, parent, version, location, false, (name) => ArmAppServiceModelFactory.SiteLogsConfigData(
                name: name,
                applicationLogs: new ApplicationLogsConfig()
                {
                    FileSystemLevel = WebAppLogLevel.Verbose
                },
                isDetailedErrorMessagesEnabled: true,
                isFailedRequestsTracingEnabled: true,
                httpLogs: new AppServiceHttpLogsConfig()
                {
                    FileSystem = new FileSystemHttpLogsConfig()
                    {
                        IsEnabled = true,
                        RetentionInDays = 1,
                        RetentionInMb = 35
                    }
                }))
        {
        }

        private WebSiteConfigLogs(IConstruct scope, string name, WebSite? parent = null, string version = "2021-02-01", AzureLocation? location = default, bool isExisting = false, Func<string, SiteLogsConfigData>? creator = null)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="AppServicePlan"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static WebSiteConfigLogs FromExisting(IConstruct scope, string name, WebSite? parent = null)
            => new WebSiteConfigLogs(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override string GetAzureName(IConstruct scope, string resourceName) => resourceName;
    }
}
