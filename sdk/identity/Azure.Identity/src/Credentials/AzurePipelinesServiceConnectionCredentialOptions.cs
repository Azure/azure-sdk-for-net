// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Identity
{
    /// <summary>
    /// Options used to configure the <see cref="AzurePipelinesServiceConnectionCredential"/>.
    /// </summary>
    public class AzurePipelinesServiceConnectionCredentialOptions : TokenCredentialOptions, ISupportsDisableInstanceDiscovery, ISupportsAdditionallyAllowedTenants, ISupportsTokenCachePersistenceOptions
    {
        internal CredentialPipeline Pipeline { get; set; }

        internal MsalConfidentialClient MsalClient { get; set; }

        /// <summary>
        /// The URI of the TFS collection or Azure DevOps organization.
        /// </summary>
        public string CollectionUri { get; set; } = Environment.GetEnvironmentVariable("SYSTEM_TEAMFOUNDATIONCOLLECTIONURI");

        /// <summary>
        /// The type of build to get the token for
        /// </summary>
        public string HubName { get; set; } = Environment.GetEnvironmentVariable("SYSTEM_HOSTTYPE");

        /// <summary>
        /// A unique identifier for a single attempt of a single job. The value is unique to the current pipeline.
        /// </summary>
        public string JobId { get; set; } = Environment.GetEnvironmentVariable("SYSTEM_JOBID");

        /// <summary>
        /// A string-based identifier for a single pipeline run.
        /// </summary>
        public string PlanId { get; set; } = Environment.GetEnvironmentVariable("SYSTEM_PLANID");

        /// <summary>
        /// The security token used by the running build.
        /// </summary>
        public string SystemAccessToken { get; set; } = Environment.GetEnvironmentVariable("SYSTEM_ACCESSTOKEN");

        /// <summary>
        /// The ID of the project that this build belongs to.
        /// </summary>
        public string TeamProjectId { get; set; } = Environment.GetEnvironmentVariable("SYSTEM_TEAMPROJECTID");

        /// <summary>
        /// For multi-tenant applications, specifies additional tenants for which the credential may acquire tokens. Add the wildcard value "*" to allow the credential to acquire tokens for any tenant in which the application is installed.
        /// </summary>
        public IList<string> AdditionallyAllowedTenants { get; internal set; } = new List<string>();

        /// <inheritdoc/>
        public bool DisableInstanceDiscovery { get; set; }

        /// <inheritdoc/>
        public TokenCachePersistenceOptions TokenCachePersistenceOptions { get; set; }
    }
}
