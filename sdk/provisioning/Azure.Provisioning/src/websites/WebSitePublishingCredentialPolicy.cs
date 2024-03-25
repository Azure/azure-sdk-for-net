// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        private static CsmPublishingCredentialsPoliciesEntityData Empty(string name) => ArmAppServiceModelFactory.CsmPublishingCredentialsPoliciesEntityData();

        /// <summary>
        /// Initializes a new instance of the <see cref="WebSitePublishingCredentialPolicy"/> class.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        public WebSitePublishingCredentialPolicy(IConstruct scope, string name, WebSite? parent = null, string version = "2021-02-01", AzureLocation? location = default)
            : this(scope, name, parent, version, location, false, (name) => ArmAppServiceModelFactory.CsmPublishingCredentialsPoliciesEntityData(
                name: name,
                allow: false))
        {
        }

        private WebSitePublishingCredentialPolicy(IConstruct scope, string name, WebSite? parent = null, string version = "2021-02-01", AzureLocation? location = default, bool isExisting = false, Func<string, CsmPublishingCredentialsPoliciesEntityData>? creator = null)
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
        public static WebSitePublishingCredentialPolicy FromExisting(IConstruct scope, string name, WebSite? parent = null)
            => new WebSitePublishingCredentialPolicy(scope, parent: parent, name: name, isExisting: true);
    }
}
