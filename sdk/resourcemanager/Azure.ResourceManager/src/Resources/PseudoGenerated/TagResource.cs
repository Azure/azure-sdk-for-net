// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// The tag client.
    /// </summary>
    public class TagResource : ArmResource
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly TagRestOperations _restClient;
        private readonly TagResourceData _data;

        /// <summary> Initializes a new instance of the <see cref="TagResource"/> class for mocking. </summary>
        protected TagResource()
        {
        }

        internal TagResource(ArmResource options, ResourceIdentifier id)
            : base(options, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new TagRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
        }

        /// <summary> Initializes a new instance of the <see cref = "TagResource"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal TagResource(ArmResource options, TagResourceData resource)
            : base(options, resource.Id)
        {
            _data = resource;
            HasData = true;
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new TagRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => Id.ResourceType;

        /// <summary>
        /// Gets whether or not the current instance has data.
        /// </summary>
        public bool HasData { get; }

        /// <summary> Gets the TagsResourceData. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual TagResourceData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data you must call Get first");
                return _data;
            }
        }

        /// <summary>
        /// Update tags with the resource.
        /// </summary>
        /// <param name="parameters"> The tags to update. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated tags. </returns>
        public virtual TagCreateOrUpdateOperation Update(TagPatchResource parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (parameters is null)
                throw new ArgumentNullException(nameof(parameters));

            using var scope = _clientDiagnostics.CreateScope("TagResource.UpdateAtScope");
            scope.Start();

            try
            {
                var response = _restClient.UpdateAtScope(Id, parameters, cancellationToken);
                var operation = new TagCreateOrUpdateOperation(this, response);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
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
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated tags. </returns>
        public virtual async Task<TagCreateOrUpdateOperation> UpdateAsync(TagPatchResource parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (parameters is null)
                throw new ArgumentNullException(nameof(parameters));

            using var scope = _clientDiagnostics.CreateScope("TagResource.UpdateAtScope");
            scope.Start();

            try
            {
                var response = await _restClient.UpdateAtScopeAsync(Id, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new TagCreateOrUpdateOperation(this, response);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
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
            using var scope = _clientDiagnostics.CreateScope("TagResource.GetAtScope");
            scope.Start();

            try
            {
                var response = _restClient.GetAtScope(Id, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());

                return Response.FromValue(new TagResource(this, response.Value), response.GetRawResponse());
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
            using var scope = _clientDiagnostics.CreateScope("TagResource.GetAtScope");
            scope.Start();

            try
            {
                var response = await _restClient.GetAtScopeAsync(Id, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);

                return Response.FromValue(new TagResource(this, response.Value), response.GetRawResponse());
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
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The delete response. </returns>
        public virtual TagDeleteOperation Delete(bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TagResource.DeleteAtScope");
            scope.Start();

            try
            {
                var response = _restClient.DeleteAtScope(Id, cancellationToken);
                var operation = new TagDeleteOperation(response);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
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
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The delete response. </returns>
        public virtual async Task<TagDeleteOperation> DeleteAsync(bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TagResource.DeleteAtScope");
            scope.Start();

            try
            {
                var response = await _restClient.DeleteAtScopeAsync(Id, cancellationToken).ConfigureAwait(false);
                var operation = new TagDeleteOperation(response);
                if (waitForCompletion)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
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
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The created or updated tags. </returns>
        public virtual TagCreateOrUpdateOperation CreateOrUpdate(TagResourceData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (parameters is null)
                throw new ArgumentException($"{nameof(parameters)} provided cannot be null.", nameof(parameters));

            using var scope = _clientDiagnostics.CreateScope("TagResource.CreateOrUpdate");
            scope.Start();

            try
            {
                var response = _restClient.CreateOrUpdateAtScope(Id, parameters, cancellationToken);
                var operation = new TagCreateOrUpdateOperation(this, response);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
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
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The created or updated tags. </returns>
        public virtual async Task<TagCreateOrUpdateOperation> CreateOrUpdateAsync(TagResourceData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (parameters is null)
                throw new ArgumentException($"{nameof(parameters)} provided cannot be null.", nameof(parameters));

            using var scope = _clientDiagnostics.CreateScope("TagResource.CreateOrUpdate");
            scope.Start();

            try
            {
                var response = await _restClient.CreateOrUpdateAtScopeAsync(Id, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new TagCreateOrUpdateOperation(this, response);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
