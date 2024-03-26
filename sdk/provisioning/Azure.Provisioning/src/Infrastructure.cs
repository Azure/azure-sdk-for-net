// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning
{
    /// <summary>
    /// A class representing a set of <see cref="IConstruct"/> that make up the Azure infrastructure.
    /// </summary>
#pragma warning disable AZC0012 // Avoid single word type names
    public abstract class Infrastructure : Construct
#pragma warning restore AZC0012 // Avoid single word type names
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Infrastructure"/> class.
        /// </summary>
        /// <param name="constructScope">The <see cref="ConstructScope"/> to use for the root <see cref="IConstruct"/>.</param>
        /// <param name="tenantId">The tenant id to use.  If not passed in will try to load from AZURE_TENANT_ID environment variable.</param>
        /// <param name="subscriptionId">The subscription id to use.  If not passed, the subscription will be loaded from the deployment context.</param>
        /// <param name="envName">The environment name to use.  If not passed in will try to load from AZURE_ENV_NAME environment variable.</param>
        /// <param name="configuration">The configuration for the infrastructure.</param>
        public Infrastructure(ConstructScope constructScope = ConstructScope.Subscription, Guid? tenantId = null, Guid? subscriptionId = null, string? envName = null, Configuration? configuration = null)
            : base(null, "default", constructScope, tenantId, subscriptionId, envName ?? Environment.GetEnvironmentVariable("AZURE_ENV_NAME") ?? throw new Exception("No environment variable found named 'AZURE_ENV_NAME'"), resourceGroup: null)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Converts the infrastructure to Bicep files.
        /// </summary>
        /// <param name="outputPath">Path to put the files.</param>
        public void Build(string? outputPath = null)
        {
            var moduleInfrastructure = new ModuleInfrastructure(this);

            moduleInfrastructure.Write(outputPath);
        }
    }
}
