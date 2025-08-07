// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.CarbonOptimization.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.CarbonOptimization
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.CarbonOptimization. </summary>
    [CodeGenSuppress("QueryCarbonEmissionReportsAsync", typeof(TenantResource), typeof(CarbonEmissionQueryFilter), typeof(CancellationToken))]
    [CodeGenSuppress("QueryCarbonEmissionReports", typeof(TenantResource), typeof(CarbonEmissionQueryFilter), typeof(CancellationToken))]
    public static partial class CarbonOptimizationExtensions
    {
        /// <summary>
        /// API for Carbon Emissions Reports
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Carbon/carbonEmissionReports</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CarbonService_QueryCarbonEmissionReports</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-04-01</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="queryParameters"> Query parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> or <paramref name="queryParameters"/> is null. </exception>
        public static async Task<Response<CarbonEmissionListResult>> QueryCarbonEmissionReportsAsync(this TenantResource tenantResource, CarbonEmissionQueryFilter queryParameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return await GetMockableCarbonOptimizationTenantResource(tenantResource).QueryCarbonEmissionReportsAsync(queryParameters, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// API for Carbon Emissions Reports
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Carbon/carbonEmissionReports</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CarbonService_QueryCarbonEmissionReports</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-04-01</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="queryParameters"> Query parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> or <paramref name="queryParameters"/> is null. </exception>
        public static Response<CarbonEmissionListResult> QueryCarbonEmissionReports(this TenantResource tenantResource, CarbonEmissionQueryFilter queryParameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return GetMockableCarbonOptimizationTenantResource(tenantResource).QueryCarbonEmissionReports(queryParameters, cancellationToken);
        }
    }
}
