// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ContainerRegistry.Tasks.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerRegistry.Tasks.Mocking
{
    [CodeGenSuppress("GetBuildSourceUploadUriAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetBuildSourceUploadUri", typeof(string), typeof(CancellationToken))]
    public partial class MockableContainerRegistryTasksResourceGroupResource
    {
        // TODO: Remove these custom methods after https://github.com/microsoft/typespec/issues/11708 is fixed.
        /// <summary> Gets the upload location for the user to be able to upload the source. </summary>
        public virtual async Task<Response<ContainerRegistryTaskSourceUploadResult>> GetBuildSourceUploadUrlAsync(string registryName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(registryName, nameof(registryName));

            using DiagnosticScope scope = RegistriesClientDiagnostics.CreateScope("MockableContainerRegistryTasksResourceGroupResource.GetBuildSourceUploadUrl");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = RegistriesRestClient.CreateGetBuildSourceUploadUrlRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, registryName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<ContainerRegistryTaskSourceUploadResult> response = Response.FromValue(ContainerRegistryTaskSourceUploadResult.FromResponse(result), result);
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

        /// <summary> Gets the upload location for the user to be able to upload the source. </summary>
        public virtual Response<ContainerRegistryTaskSourceUploadResult> GetBuildSourceUploadUrl(string registryName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(registryName, nameof(registryName));

            using DiagnosticScope scope = RegistriesClientDiagnostics.CreateScope("MockableContainerRegistryTasksResourceGroupResource.GetBuildSourceUploadUrl");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = RegistriesRestClient.CreateGetBuildSourceUploadUrlRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, registryName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<ContainerRegistryTaskSourceUploadResult> response = Response.FromValue(ContainerRegistryTaskSourceUploadResult.FromResponse(result), result);
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
