// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific ResourceGroup.
    /// </summary>
    public class ResourceGroup : ArmResource
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ResourceGroupsRestOperations _restClient;
        private readonly ResourcesRestOperations _genericRestClient;
        private readonly ResourceGroupData _data;

        /// <summary>
        /// Gets the resource type definition for a ResourceType.
        /// </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Resources/resourceGroups";

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroup"/> class for mocking.
        /// </summary>
        protected ResourceGroup()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroup"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The id of the resource group to use. </param>
        internal ResourceGroup(ClientContext options, ResourceIdentifier id)
            : base(options, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new ResourceGroupsRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);
            _genericRestClient ??= new ResourcesRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroup"/> class.
        /// </summary>
        /// <param name="operations"> The operations to copy the client options from. </param>
        /// <param name="resource"> The ResourceGroupData to use in these operations. </param>
        internal ResourceGroup(ArmResource operations, ResourceGroupData resource)
            : base(operations, resource.Id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new ResourceGroupsRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);
            _genericRestClient ??= new ResourcesRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);
            _data = resource;
            HasData = true;
        }

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => ResourceType;

        /// <summary>
        /// Gets whether or not the current instance has data.
        /// </summary>
        public bool HasData { get; }

        /// <summary>
        /// Gets the data representing this ResourceGroup.
        /// </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual ResourceGroupData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data you must call Get first");
                return _data;
            }
        }

        /// <summary>
        /// When you delete a resource group, all of its resources are also deleted. Deleting a resource group deletes all of its template deployments and currently stored operations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="Response"/> operation for this resource. </returns>
        public virtual Response Delete(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResourceGroup.Delete");
            scope.Start();

            try
            {
                var operation = StartDelete(cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// When you delete a resource group, all of its resources are also deleted. Deleting a resource group deletes all of its template deployments and currently stored operations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="Response"/> operation for this resource. </returns>
        public virtual async Task<Response> DeleteAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResourceGroup.Delete");
            scope.Start();

            try
            {
                var operation = await StartDeleteAsync(cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// When you delete a resource group, all of its resources are also deleted. Deleting a resource group deletes all of its template deployments and currently stored operations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="ResourceGroupDeleteOperation"/> operation for this resource. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public virtual ResourceGroupDeleteOperation StartDelete(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResourceGroup.StartDelete");
            scope.Start();

            try
            {
                var originalResponse = _restClient.Delete(Id.Name, cancellationToken);
                return new ResourceGroupDeleteOperation(_clientDiagnostics, Pipeline, _restClient.CreateDeleteRequest(Id.Name).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// When you delete a resource group, all of its resources are also deleted. Deleting a resource group deletes all of its template deployments and currently stored operations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="ResourceGroupDeleteOperation"/> operation for this resource. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public virtual async Task<ResourceGroupDeleteOperation> StartDeleteAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResourceGroup.StartDelete");
            scope.Start();

            try
            {
                var originalResponse = await _restClient.DeleteAsync(Id.Name, cancellationToken).ConfigureAwait(false);
                return new ResourceGroupDeleteOperation(_clientDiagnostics, Pipeline, _restClient.CreateDeleteRequest(Id.Name).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Captures the specified resource group as a template. </summary>
        /// <param name="parameters"> Parameters for exporting the template. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ResourceGroupExportTemplateOperation StartExportTemplate(ExportTemplateRequest parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResourceGroup.StartExportTemplate");
            scope.Start();
            try
            {
                var originalResponse = _restClient.ExportTemplate(Id.Name, parameters, cancellationToken);
                return new ResourceGroupExportTemplateOperation(_clientDiagnostics, Pipeline, _restClient.CreateExportTemplateRequest(Id.Name, parameters).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Captures the specified resource group as a template. </summary>
        /// <param name="parameters"> Parameters for exporting the template. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ResourceGroupExportTemplateOperation> StartExportTemplateAsync(ExportTemplateRequest parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResourceGroup.StartExportTemplate");
            scope.Start();
            try
            {
                var originalResponse = await _restClient.ExportTemplateAsync(Id.Name, parameters, cancellationToken).ConfigureAwait(false);
                return new ResourceGroupExportTemplateOperation(_clientDiagnostics, Pipeline, _restClient.CreateExportTemplateRequest(Id.Name, parameters).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the current ResourceGroup from Azure. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ResourceGroup> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResourceGroup.Get");
            scope.Start();

            try
            {
                var result = _restClient.Get(Id.Name, cancellationToken);
                if (result.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(result.GetRawResponse());

                return Response.FromValue(new ResourceGroup(this, result), result.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the current ResourceGroup from Azure. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ResourceGroup>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResourceGroup.Get");
            scope.Start();

            try
            {
                var response = await _restClient.GetAsync(Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);

                return Response.FromValue(new ResourceGroup(this, response), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Resource groups can be updated through a simple PATCH operation to a group address. The format of the request is the same as that for creating a resource group. If a field is unspecified, the current value is retained. </summary>
        /// <param name="parameters"> Parameters supplied to update a resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ResourceGroup> Update(ResourceGroupPatchable parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResourceGroup.Update");
            scope.Start();
            try
            {
                var originalResponse = _restClient.Update(Id.Name, parameters, cancellationToken);
                return Response.FromValue(new ResourceGroup(this, originalResponse), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Resource groups can be updated through a simple PATCH operation to a group address. The format of the request is the same as that for creating a resource group. If a field is unspecified, the current value is retained. </summary>
        /// <param name="parameters"> Parameters supplied to update a resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ResourceGroup>> UpdateAsync(ResourceGroupPatchable parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResourceGroup.Update");
            scope.Start();
            try
            {
                var originalResponse = await _restClient.UpdateAsync(Id.Name, parameters, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ResourceGroup(this, originalResponse), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag added. </returns>
        public virtual Response<ResourceGroup> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));

            using var scope = _clientDiagnostics.CreateScope("ResourceGroup.AddTag");
            scope.Start();

            try
            {
                var originalTags = TagResource.Get(cancellationToken).Value;
                originalTags.Data.Properties.TagsValue[key] = value;
                TagContainer.CreateOrUpdate(originalTags.Data, cancellationToken);
                var originalResponse = _restClient.Get(Id.Name, cancellationToken);
                return Response.FromValue(new ResourceGroup(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag added. </returns>
        public virtual async Task<Response<ResourceGroup>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));

            using var scope = _clientDiagnostics.CreateScope("ResourceGroup.AddTag");
            scope.Start();

            try
            {
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue[key] = value;
                await TagContainer.CreateOrUpdateAsync(originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
                var originalResponse = await _restClient.GetAsync(Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ResourceGroup(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag added. </returns>
        public virtual Response<ResourceGroup> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            if (tags == null)
                throw new ArgumentNullException(nameof(tags));

            using var scope = _clientDiagnostics.CreateScope("ResourceGroup.SetTags");
            scope.Start();

            try
            {
                TagResource.Delete(cancellationToken);
                var newTags = TagResource.Get(cancellationToken);
                newTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);
                TagContainer.CreateOrUpdate(new TagResourceData(newTags.Value.Data.Properties), cancellationToken);
                var originalResponse = _restClient.Get(Id.Name, cancellationToken);
                return Response.FromValue(new ResourceGroup(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag added. </returns>
        public virtual async Task<Response<ResourceGroup>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            if (tags == null)
                throw new ArgumentNullException(nameof(tags));

            using var scope = _clientDiagnostics.CreateScope("ResourceGroup.SetTags");
            scope.Start();

            try
            {
                await TagResource.DeleteAsync(cancellationToken).ConfigureAwait(false);
                var newTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                newTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);
                await TagContainer.CreateOrUpdateAsync(new TagResourceData(newTags.Value.Data.Properties), cancellationToken).ConfigureAwait(false);
                var originalResponse = await _restClient.GetAsync(Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ResourceGroup(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// </summary>
        /// <param name="key"> The key of the tag to remove. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag added. </returns>
        public virtual Response<ResourceGroup> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));

            using var scope = _clientDiagnostics.CreateScope("ResourceGroup.RemoveTag");
            scope.Start();

            try
            {
                var originalTags = TagResource.Get(cancellationToken).Value;
                originalTags.Data.Properties.TagsValue.Remove(key);
                TagContainer.CreateOrUpdate(originalTags.Data, cancellationToken);
                var originalResponse = _restClient.Get(Id.Name, cancellationToken);
                return Response.FromValue(new ResourceGroup(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// </summary>
        /// <param name="key"> The key of the tag to remove. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag added. </returns>
        public virtual async Task<Response<ResourceGroup>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));

            using var scope = _clientDiagnostics.CreateScope("ResourceGroup.RemoveTag");
            scope.Start();

            try
            {
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue.Remove(key);
                await TagContainer.CreateOrUpdateAsync(originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
                var originalResponse = await _restClient.GetAsync(Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ResourceGroup(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of location that may take multiple service requests to iterate over. </returns>
        public virtual IEnumerable<Location> GetAvailableLocations(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResourceGroup.GetAvailableLocations");
            scope.Start();

            try
            {
                return ListAvailableLocations(ResourceType, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of location that may take multiple service requests to iterate over. </returns>
        /// <exception cref="InvalidOperationException"> The default subscription id is null. </exception>
        public virtual async Task<IEnumerable<Location>> GetAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResourceGroup.GetAvailableLocations");
            scope.Start();

            try
            {
                return await ListAvailableLocationsAsync(ResourceType, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The resources to move must be in the same source resource group. The target resource group may be in a different subscription. When moving resources, both the source group and the target group are locked for the duration of the operation. Write and delete operations are blocked on the groups until the move completes. </summary>
        /// <param name="parameters"> Parameters for moving resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual Response MoveResources(ResourcesMoveInfo parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResourceGroup.MoveResources");
            scope.Start();
            try
            {
                var originalResponse = StartMoveResources(parameters, cancellationToken);
                return originalResponse.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The resources to move must be in the same source resource group. The target resource group may be in a different subscription. When moving resources, both the source group and the target group are locked for the duration of the operation. Write and delete operations are blocked on the groups until the move completes. </summary>
        /// <param name="parameters"> Parameters for moving resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual async Task<Response> MoveResourcesAsync(ResourcesMoveInfo parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResourceGroup.MoveResources");
            scope.Start();
            try
            {
                var originalResponse = await StartMoveResourcesAsync(parameters, cancellationToken).ConfigureAwait(false);
                return await originalResponse.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The resources to move must be in the same source resource group. The target resource group may be in a different subscription. When moving resources, both the source group and the target group are locked for the duration of the operation. Write and delete operations are blocked on the groups until the move completes. </summary>
        /// <param name="parameters"> Parameters for moving resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual ResourceMoveResourcesOperation StartMoveResources(ResourcesMoveInfo parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResourceGroup.StartMoveResources");
            scope.Start();
            try
            {
                var originalResponse = _genericRestClient.MoveResources(Id.Name, parameters, cancellationToken);
                return new ResourceMoveResourcesOperation(_clientDiagnostics, Pipeline, _genericRestClient.CreateMoveResourcesRequest(Id.Name, parameters).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The resources to move must be in the same source resource group. The target resource group may be in a different subscription. When moving resources, both the source group and the target group are locked for the duration of the operation. Write and delete operations are blocked on the groups until the move completes. </summary>
        /// <param name="parameters"> Parameters for moving resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ResourceMoveResourcesOperation> StartMoveResourcesAsync(ResourcesMoveInfo parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResourceGroup.StartMoveResources");
            scope.Start();
            try
            {
                var originalResponse = await _genericRestClient.MoveResourcesAsync(Id.Name, parameters, cancellationToken).ConfigureAwait(false);
                return new ResourceMoveResourcesOperation(_clientDiagnostics, Pipeline, _genericRestClient.CreateMoveResourcesRequest(Id.Name, parameters).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> This operation checks whether the specified resources can be moved to the target. The resources to move must be in the same source resource group. The target resource group may be in a different subscription. If validation succeeds, it returns HTTP response code 204 (no content). If validation fails, it returns HTTP response code 409 (Conflict) with an error message. Retrieve the URL in the Location header value to check the result of the long-running operation. </summary>
        /// <param name="parameters"> Parameters for moving resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual Response ValidateMoveResources(ResourcesMoveInfo parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResourceGroup.ValidateMoveResources");
            scope.Start();
            try
            {
                var operation = StartValidateMoveResources(parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> This operation checks whether the specified resources can be moved to the target. The resources to move must be in the same source resource group. The target resource group may be in a different subscription. If validation succeeds, it returns HTTP response code 204 (no content). If validation fails, it returns HTTP response code 409 (Conflict) with an error message. Retrieve the URL in the Location header value to check the result of the long-running operation. </summary>
        /// <param name="parameters"> Parameters for moving resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual async Task<Response> ValidateMoveResourcesAsync(ResourcesMoveInfo parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResourceGroup.ValidateMoveResources");
            scope.Start();
            try
            {
                var operation = await StartValidateMoveResourcesAsync(parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> This operation checks whether the specified resources can be moved to the target. The resources to move must be in the same source resource group. The target resource group may be in a different subscription. If validation succeeds, it returns HTTP response code 204 (no content). If validation fails, it returns HTTP response code 409 (Conflict) with an error message. Retrieve the URL in the Location header value to check the result of the long-running operation. </summary>
        /// <param name="parameters"> Parameters for moving resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual ResourceValidateMoveResourcesOperation StartValidateMoveResources(ResourcesMoveInfo parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResourceGroup.StartValidateMoveResources");
            scope.Start();
            try
            {
                var originalResponse = _genericRestClient.ValidateMoveResources(Id.Name, parameters, cancellationToken);
                return new ResourceValidateMoveResourcesOperation(_clientDiagnostics, Pipeline, _genericRestClient.CreateValidateMoveResourcesRequest(Id.Name, parameters).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> This operation checks whether the specified resources can be moved to the target. The resources to move must be in the same source resource group. The target resource group may be in a different subscription. If validation succeeds, it returns HTTP response code 204 (no content). If validation fails, it returns HTTP response code 409 (Conflict) with an error message. Retrieve the URL in the Location header value to check the result of the long-running operation. </summary>
        /// <param name="parameters"> Parameters for moving resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ResourceValidateMoveResourcesOperation> StartValidateMoveResourcesAsync(ResourcesMoveInfo parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResourceGroup.StartValidateMoveResources");
            scope.Start();
            try
            {
                var originalResponse = await _genericRestClient.ValidateMoveResourcesAsync(Id.Name, parameters, cancellationToken).ConfigureAwait(false);
                return new ResourceValidateMoveResourcesOperation(_clientDiagnostics, Pipeline, _genericRestClient.CreateValidateMoveResourcesRequest(Id.Name, parameters).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Provides a way to reuse the protected client context.
        /// </summary>
        /// <typeparam name="T"> The actual type returned by the delegate. </typeparam>
        /// <param name="func"> The method to pass the internal properties to. </param>
        /// <returns> Whatever the delegate returns. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual T UseClientContext<T>(Func<Uri, TokenCredential, ArmClientOptions, HttpPipeline, T> func)
        {
            return func(BaseUri, Credential, ClientOptions, Pipeline);
        }
    }
}
