// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

        /// <summary>
        /// Initializes a new instance of the <see cref="WebSiteConfigLogs"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="resourceName">The resource name.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        public WebSiteConfigLogs(IConstruct scope, string resourceName, WebSite? parent = null, string version = "2021-02-01", AzureLocation? location = default)
            : base(scope, parent, resourceName, ResourceTypeName, version, (name) => ArmAppServiceModelFactory.SiteLogsConfigData(
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
                }),
                null)
        {
        }

        /// <inheritdoc/>
        protected override string GetAzureName(IConstruct scope, string resourceName) => resourceName;
    }
}
