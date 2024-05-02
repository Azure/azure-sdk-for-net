// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Identity
{
    /// <summary>
    /// Options used to configure the <see cref="AzurePipelinesCredential"/>.
    /// </summary>
    public class AzurePipelinesCredentialOptions : TokenCredentialOptions, ISupportsDisableInstanceDiscovery, ISupportsAdditionallyAllowedTenants, ISupportsTokenCachePersistenceOptions
    {
        internal CredentialPipeline Pipeline { get; set; }

        internal MsalConfidentialClient MsalClient { get; set; }

        /// <summary>
        /// The security token used by the running build.
        /// </summary>
        internal string SystemAccessToken { get; set; } = Environment.GetEnvironmentVariable("SYSTEM_ACCESSTOKEN");

        /// <summary>
        /// The URI of the TFS collection or Azure DevOps organization.
        /// </summary>
        internal string CollectionUri { get; set; } = Environment.GetEnvironmentVariable("SYSTEM_TEAMFOUNDATIONCOLLECTIONURI");

        /// <summary>
        /// A unique identifier for a single attempt of a single job. The value is unique to the current pipeline.
        /// </summary>
        internal string JobId { get; set; } = Environment.GetEnvironmentVariable("SYSTEM_JOBID");

        /// <summary>
        /// A string-based identifier for a single pipeline run.
        /// </summary>
        internal string PlanId { get; set; } = Environment.GetEnvironmentVariable("SYSTEM_PLANID");

        /// <summary>
        /// The ID of the project that this build belongs to.
        /// </summary>
        internal string TeamProjectId { get; set; } = Environment.GetEnvironmentVariable("SYSTEM_TEAMPROJECTID");

        /// <inheritdoc/>
        public IList<string> AdditionallyAllowedTenants { get; internal set; } = new List<string>();

        /// <inheritdoc/>
        public bool DisableInstanceDiscovery { get; set; }

        /// <inheritdoc/>
        public TokenCachePersistenceOptions TokenCachePersistenceOptions { get; set; }
    }
}
