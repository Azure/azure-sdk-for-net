// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;

namespace Azure.Provisioning.ResourceManager
{
    /// <summary>
    /// Tenant resource.
    /// </summary>
#pragma warning disable AZC0012 // Avoid single word type names
    public class Tenant : Resource<TenantData>
#pragma warning restore AZC0012 // Avoid single word type names
    {
        private const string ResourceTypeName = "Microsoft.Resources/tenants";
        internal const string TenantIdExpression = "tenant().tenantId";

        /// <summary>
        /// Initializes a new instance of the <see cref="Tenant"/>.
        /// </summary>
        /// <param name="scope">The scope the tenant belongs to.</param>
        /// <param name="tenantId">The tenant id.</param>
        public Tenant(IConstruct scope, Guid? tenantId = null)
            : base(scope, null, tenantId?.ToString()!, ResourceTypeName, "2022-12-01", (name) => ResourceManagerModelFactory.TenantData(
                tenantId: tenantId.HasValue ? tenantId.Value : Guid.Parse(name)))
        {
        }

        /// <inheritdoc/>
        protected override string GetAzureName(IConstruct scope, string? resourceName)
        {
            if (scope.Configuration?.UseInteractiveMode == true)
            {
                return "tenant()";
            }
            return resourceName ?? Environment.GetEnvironmentVariable("AZURE_TENANT_ID") ?? throw new InvalidOperationException("No environment variable named 'AZURE_TENANT_ID' found");
        }
    }
}
