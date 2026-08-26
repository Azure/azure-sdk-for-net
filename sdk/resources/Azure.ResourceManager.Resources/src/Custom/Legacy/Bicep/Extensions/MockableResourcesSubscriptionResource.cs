// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources.Mocking
{
    public partial class MockableResourcesSubscriptionResource
    {
        private ClientDiagnostics _decompileClientDiagnostics;
        private DecompileRestOperations _decompileRestClient;

        private ClientDiagnostics DecompileClientDiagnostics => _decompileClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Resources", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private DecompileRestOperations DecompileRestClient => _decompileRestClient ??= new DecompileRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);

        /// <summary> Decompiles an ARM JSON template into a Bicep template. </summary>
        /// <param name="content"> The decompile operation request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("Use Azure.ResourceManager.Resources.Bicep.Mocking.MockableResourcesBicepSubscriptionResource.BicepDecompileAsync instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DecompileOperationSuccessResult>> BicepDecompileAsync(DecompileOperationContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = DecompileClientDiagnostics.CreateScope("MockableResourcesSubscriptionResource.BicepDecompile");
            scope.Start();
            try
            {
                var response = await DecompileRestClient.BicepAsync(Id.SubscriptionId, content, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Decompiles an ARM JSON template into a Bicep template. </summary>
        /// <param name="content"> The decompile operation request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("Use Azure.ResourceManager.Resources.Bicep.Mocking.MockableResourcesBicepSubscriptionResource.BicepDecompile instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DecompileOperationSuccessResult> BicepDecompile(DecompileOperationContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = DecompileClientDiagnostics.CreateScope("MockableResourcesSubscriptionResource.BicepDecompile");
            scope.Start();
            try
            {
                var response = DecompileRestClient.Bicep(Id.SubscriptionId, content, cancellationToken);
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
