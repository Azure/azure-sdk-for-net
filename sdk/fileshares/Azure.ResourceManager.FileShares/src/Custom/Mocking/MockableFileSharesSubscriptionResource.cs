// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.FileShares.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.FileShares.Mocking
{
    [CodeGenSuppress("GetLimitsAsync", typeof(AzureLocation), typeof(FileShareLimitsContent), typeof(CancellationToken))]
    [CodeGenSuppress("GetLimits", typeof(AzureLocation), typeof(FileShareLimitsContent), typeof(CancellationToken))]
    public partial class MockableFileSharesSubscriptionResource
    {
        /// <summary>
        /// Get file shares limits.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.FileShares/locations/{location}/getLimits. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> InformationalOperations_GetLimits. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-09-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks>
        /// When <paramref name="content"/> is null, this dispatches to
        /// <see cref="GetLimitsAsync(AzureLocation, CancellationToken)"/> so that overrides of the 1.0.0 overload keep
        /// receiving calls that pass no request body.
        /// </remarks>
        public virtual Task<Response<FileShareLimitsResult>> GetLimitsAsync(AzureLocation location, FileShareLimitsContent content = default, CancellationToken cancellationToken = default)
            => content is null ? GetLimitsAsync(location, cancellationToken) : GetLimitsCoreAsync(location, content, cancellationToken);

        /// <summary>
        /// Get file shares limits.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.FileShares/locations/{location}/getLimits. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> InformationalOperations_GetLimits. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-09-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks>
        /// When <paramref name="content"/> is null, this dispatches to
        /// <see cref="GetLimits(AzureLocation, CancellationToken)"/> so that overrides of the 1.0.0 overload keep
        /// receiving calls that pass no request body.
        /// </remarks>
        public virtual Response<FileShareLimitsResult> GetLimits(AzureLocation location, FileShareLimitsContent content = default, CancellationToken cancellationToken = default)
            => content is null ? GetLimits(location, cancellationToken) : GetLimitsCore(location, content, cancellationToken);

        /// <summary>
        /// Get file shares limits.
        /// </summary>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Task"/> that resolves to the file share limits for the given location. </returns>
        /// <remarks>
        /// Back-compatibility overload from 1.0.0. Calls to
        /// <see cref="GetLimitsAsync(AzureLocation, FileShareLimitsContent, CancellationToken)"/> without a request body
        /// dispatch here, so overrides of this overload keep working.
        /// </remarks>
        public virtual Task<Response<FileShareLimitsResult>> GetLimitsAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetLimitsCoreAsync(location, null, cancellationToken);

        /// <summary>
        /// Get file shares limits.
        /// </summary>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The file share limits for the given location. </returns>
        /// <remarks>
        /// Back-compatibility overload from 1.0.0. Calls to
        /// <see cref="GetLimits(AzureLocation, FileShareLimitsContent, CancellationToken)"/> without a request body
        /// dispatch here, so overrides of this overload keep working.
        /// </remarks>
        public virtual Response<FileShareLimitsResult> GetLimits(AzureLocation location, CancellationToken cancellationToken)
            => GetLimitsCore(location, null, cancellationToken);

        private async Task<Response<FileShareLimitsResult>> GetLimitsCoreAsync(AzureLocation location, FileShareLimitsContent content, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = InformationalOperationsClientDiagnostics.CreateScope("MockableFileSharesSubscriptionResource.GetLimits");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = InformationalOperationsRestClient.CreateGetLimitsRequest(Guid.Parse(Id.SubscriptionId), location, FileShareLimitsContent.ToRequestContent(content), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<FileShareLimitsResult> response = Response.FromValue(FileShareLimitsResult.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response<FileShareLimitsResult> GetLimitsCore(AzureLocation location, FileShareLimitsContent content, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = InformationalOperationsClientDiagnostics.CreateScope("MockableFileSharesSubscriptionResource.GetLimits");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = InformationalOperationsRestClient.CreateGetLimitsRequest(Guid.Parse(Id.SubscriptionId), location, FileShareLimitsContent.ToRequestContent(content), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<FileShareLimitsResult> response = Response.FromValue(FileShareLimitsResult.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
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
