// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.CarbonOptimization.Models;

namespace Azure.ResourceManager.CarbonOptimization.Mocking
{
    /// <summary> A class to add extension methods to TenantResource. </summary>
    [CodeGenSuppress("QueryCarbonEmissionReportsAsync", typeof(CarbonEmissionQueryFilter), typeof(CancellationToken))]
    [CodeGenSuppress("QueryCarbonEmissionReports", typeof(CarbonEmissionQueryFilter), typeof(CancellationToken))]
    public partial class MockableCarbonOptimizationTenantResource : ArmResource
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
        /// </summary>
        /// <param name="queryParameters"> Query parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queryParameters"/> is null. </exception>
        public virtual async Task<Response<CarbonEmissionListResult>> QueryCarbonEmissionReportsAsync(CarbonEmissionQueryFilter queryParameters, CancellationToken cancellationToken = default)
        {
            using var scope = CarbonServiceClientDiagnostics.CreateScope("MockableCarbonOptimizationTenantResource.QueryCarbonEmissionReports");
            scope.Start();
            try
            {
                var response = await CarbonServiceRestClient.QueryCarbonEmissionReportsAsync(queryParameters, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        /// </summary>
        /// <param name="queryParameters"> Query parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queryParameters"/> is null. </exception>
        public virtual Response<CarbonEmissionListResult> QueryCarbonEmissionReports(CarbonEmissionQueryFilter queryParameters, CancellationToken cancellationToken = default)
        {
            using var scope = CarbonServiceClientDiagnostics.CreateScope("MockableCarbonOptimizationTenantResource.QueryCarbonEmissionReports");
            scope.Start();
            try
            {
                var response = CarbonServiceRestClient.QueryCarbonEmissionReports(queryParameters, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
