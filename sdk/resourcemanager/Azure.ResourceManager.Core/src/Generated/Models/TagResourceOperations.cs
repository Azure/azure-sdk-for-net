// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// The tag client.
    /// </summary>
    public class TagResourceOperations : OperationsBase
    {
        /// <summary> Initializes a new instance of the <see cref="TagResourceOperations"/> class for mocking. </summary>
        protected TagResourceOperations()
        {
        }

        internal TagResourceOperations(OperationsBase options, ResourceIdentifier id) : base(options, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        private string _subscriptionId
        {
            get {
                string subscriptionId;
                Id.TryGetSubscriptionId(out subscriptionId);
                return subscriptionId;
            }
        }

        /// <summary> Represents the REST operations. </summary>
        private TagRestOperations RestClient => new TagRestOperations(_clientDiagnostics, Pipeline, _subscriptionId, BaseUri);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceIdentifier Id => base.Id as ResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => Id.ResourceType;

        /// <summary>
        /// Update tags with the resource.
        /// </summary>
        /// <param name="parameters"> The tags to update. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated tags. </returns>
        public virtual Response<TagResource> Update(TagPatchResource parameters, CancellationToken cancellationToken = default)
        {
            if (parameters is null)
                throw new ArgumentNullException(nameof(parameters));

            using var scope = Diagnostics.CreateScope("TagsOperations.UpdateAtScope");
            scope.Start();

            try
            {
                var operation = StartUpdate(parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Update tags with the resource.
        /// </summary>
        /// <param name="parameters"> The tags to update. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated tags. </returns>
        public virtual async Task<Response<TagResource>> UpdateAsync(TagPatchResource parameters, CancellationToken cancellationToken = default)
        {
            if (parameters is null)
                throw new ArgumentNullException(nameof(parameters));

            using var scope = Diagnostics.CreateScope("TagsOperations.UpdateAtScope");
            scope.Start();

            try
            {
                var operation = await StartUpdateAsync(parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get tags with the resource.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The tags associate with resource. </returns>
        public virtual Response<TagResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("TagsOperations.GetAtScope");
            scope.Start();

            try
            {
                var response = RestClient.GetAtScope(Id, cancellationToken);
                return Response.FromValue<TagResource>(new TagResource(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get tags with the resource.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The tags associate with resource. </returns>
        public virtual async Task<Response<TagResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("TagsOperations.GetAtScope");
            scope.Start();

            try
            {
                var response = await RestClient.GetAtScopeAsync(Id, cancellationToken).ConfigureAwait(false);
                return Response.FromValue<TagResource>(new TagResource(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete tags with the resource.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The delete response. </returns>
        public virtual Response Delete(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("TagsOperations.DeleteAtScope");
            scope.Start();

            try
            {
                return StartDelete(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete tags with the resource.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The delete response. </returns>
        public virtual async Task<Response> DeleteAsync(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("TagsOperations.DeleteAtScope");
            scope.Start();

            try
            {
                return await StartDeleteAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Update tags with the resource.
        /// </summary>
        /// <param name="parameters"> The tags to update. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated tags. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public virtual TagCreateOrUpdateOperation StartUpdate(TagPatchResource parameters, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("TagsOperations.StartUpdateAtScope");
            scope.Start();
            try
            {
                var response = RestClient.UpdateAtScope(Id, parameters, cancellationToken);
                return new TagCreateOrUpdateOperation(this, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Update tags with the resource.
        /// </summary>
        /// <param name="parameters"> The tags to update. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated tags. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public virtual async Task<TagCreateOrUpdateOperation> StartUpdateAsync(TagPatchResource parameters, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("TagsOperations.StartUpdateAtScope");
            scope.Start();
            try
            {
                var response = await RestClient.UpdateAtScopeAsync(Id, parameters, cancellationToken).ConfigureAwait(false);
                return new TagCreateOrUpdateOperation(this, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete tags with the resource.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The delete response. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public virtual Response StartDelete(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("TagsOperations.StartDeleteAtScope");
            scope.Start();
            try
            {
                return RestClient.DeleteAtScope(Id, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete tags with the resource.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The delete response. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public virtual async Task<Response> StartDeleteAsync(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("TagsOperations.StartDeleteAtScope");
            scope.Start();
            try
            {
                return await RestClient.DeleteAtScopeAsync(Id, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
