// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.AppService;
using Azure.ResourceManager.AppService.Models;

namespace Azure.Provisioning.AppService
{
    /// <summary>
    /// Represents a web site publishing credential policy.
    /// </summary>
    public class WebSitePublishingCredentialPolicy : Resource<CsmPublishingCredentialsPoliciesEntityData>
    {
        private const string ResourceTypeName = "Microsoft.Web/sites/basicPublishingCredentialsPolicies";

        private static string GetName(string? name) => name is null ? $"publishingCredentialPolicy-{Infrastructure.Seed}" : $"{name}-{Infrastructure.Seed}";

        /// <summary>
        /// Initializes a new instance of the <see cref="WebSitePublishingCredentialPolicy"/> class.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="resourceName">The resource name.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        public WebSitePublishingCredentialPolicy(IConstruct scope, string resourceName, string version = "2021-02-01", AzureLocation? location = default)
            : base(scope, null, GetName(resourceName), ResourceTypeName, version, ArmAppServiceModelFactory.CsmPublishingCredentialsPoliciesEntityData(
                name: GetName(resourceName),
                allow: false))
        {
        }
    }
}
