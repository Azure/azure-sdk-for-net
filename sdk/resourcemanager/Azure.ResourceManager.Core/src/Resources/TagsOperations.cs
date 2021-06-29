// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// TODO: Add summary.
    /// </summary>
    public class TagsOperations : OperationsBase
    {
        /// <summary> Initializes a new instance of the <see cref="TagsOperations"/> class for mocking. </summary>
        protected TagsOperations()
        {
        }

        internal TagsOperations(OperationsBase options, ResourceIdentifier id) : base(options, id)
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
        private TagsRestOperations RestClient => new TagsRestOperations(_clientDiagnostics, Pipeline, _subscriptionId, BaseUri);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceIdentifier Id => base.Id as ResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceIdentifier.RootResourceIdentifier.ResourceType;

        /// <summary>
        /// Create or update tags with the resource.
        /// </summary>
        /// <param name="parameters"> The tags to create or update. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The created or updated tags. </returns>
        public virtual Response<TagsResource> CreateOrUpdateAtScope(TagsResourceData parameters, CancellationToken cancellationToken = default)
        {
            if (parameters is null)
                throw new ArgumentException($"{nameof(parameters)} provided cannot be null.", nameof(parameters));

            using var scope = Diagnostics.CreateScope("TagsOperations.CreateOrUpdateAtScope");
            scope.Start();

            try
            {
                var operation = StartCreateOrUpdateAtScope(parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or update tags with the resource
        /// </summary>
        /// <param name="parameters"> The tags to create or update. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The created or updated tags. </returns>
        public virtual async Task<Response<TagsResource>> CreateOrUpdateAtScopeAsync(TagsResourceData parameters, CancellationToken cancellationToken = default)
        {
            if (parameters is null)
                throw new ArgumentException($"{nameof(parameters)} provided cannot be null.", nameof(parameters));

            using var scope = Diagnostics.CreateScope("TagsOperations.CreateOrUpdateAtScope");
            scope.Start();

            try
            {
                var operation = await StartCreateOrUpdateAtScopeAsync(parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
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
        public virtual Response<TagsResource> UpdateAtScope(TagsPatchResource parameters, CancellationToken cancellationToken = default)
        {
            if (parameters is null)
                throw new ArgumentNullException(nameof(parameters));

            using var scope = Diagnostics.CreateScope("TagsOperations.UpdateAtScope");
            scope.Start();

            try
            {
                var operation = StartUpdateAtScope(parameters, cancellationToken);
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
        public virtual async Task<Response<TagsResource>> UpdateAtScopeAsync(TagsPatchResource parameters, CancellationToken cancellationToken = default)
        {
            if (parameters is null)
                throw new ArgumentNullException(nameof(parameters));

            using var scope = Diagnostics.CreateScope("TagsOperations.UpdateAtScope");
            scope.Start();

            try
            {
                var operation = await StartUpdateAtScopeAsync(parameters, cancellationToken).ConfigureAwait(false);
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
        public virtual Response<TagsResource> GetAtScope(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("TagsOperations.GetAtScope");
            scope.Start();

            try
            {
                var operation = StartGetAtScope(cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
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
        public virtual async Task<Response<TagsResource>> GetAtScopeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("TagsOperations.GetAtScope");
            scope.Start();

            try
            {
                var operation = await StartGetAtScopeAsync(cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
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
        public virtual Response DeleteAtScope(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("TagsOperations.DeleteAtScope");
            scope.Start();

            try
            {
                return StartDeleteAtScope(cancellationToken);
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
        public virtual async Task<Response> DeleteAtScopeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("TagsOperations.DeleteAtScope");
            scope.Start();

            try
            {
                return await StartDeleteAtScopeAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or update tags with the resource.
        /// </summary>
        /// <param name="parameters"> The tags to create or update. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The created or updated tags. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public virtual TagCreateOrUpdateOperation StartCreateOrUpdateAtScope(TagsResourceData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("TagsOperations.StartCreateOrUpdateAtScope");
            scope.Start();
            try
            {
                var response = RestClient.CreateOrUpdateAtScope(Id, parameters, cancellationToken);
                return new TagCreateOrUpdateOperation(this, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or update tags with the resource.
        /// </summary>
        /// <param name="parameters"> The tags to create or update. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The created or updated tags. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public virtual async Task<TagCreateOrUpdateOperation> StartCreateOrUpdateAtScopeAsync(TagsResourceData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("TagsOperations.StartCreateOrUpdateAtScope");
            scope.Start();
            try
            {
                var response = await RestClient.CreateOrUpdateAtScopeAsync(Id, parameters, cancellationToken).ConfigureAwait(false);
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
        public virtual TagCreateOrUpdateOperation StartUpdateAtScope(TagsPatchResource parameters, CancellationToken cancellationToken = default)
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
        public virtual async Task<TagCreateOrUpdateOperation> StartUpdateAtScopeAsync(TagsPatchResource parameters, CancellationToken cancellationToken = default)
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
        /// Get tags with the resource.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The tags associate with resource. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public virtual TagCreateOrUpdateOperation StartGetAtScope(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("TagsOperations.StartGetAtScope");
            scope.Start();
            try
            {
                var response = RestClient.GetAtScope(Id, cancellationToken);
                return new TagCreateOrUpdateOperation(this, response);
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
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public virtual async Task<TagCreateOrUpdateOperation> StartGetAtScopeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("TagsOperations.StartGetAtScope");
            scope.Start();
            try
            {
                var response = await RestClient.GetAtScopeAsync(Id, cancellationToken).ConfigureAwait(false);
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
        public virtual Response StartDeleteAtScope(CancellationToken cancellationToken = default)
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
        public virtual async Task<Response> StartDeleteAtScopeAsync(CancellationToken cancellationToken = default)
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
