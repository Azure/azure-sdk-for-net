// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific ResourceGroup.
    /// </summary>
    public class ResourceGroupOperations : ResourceOperationsBase<ResourceGroupResourceIdentifier, ResourceGroup>
    {
        /// <summary>
        /// Name of the CreateOrUpdate() method in [Resource]Container classes.
        /// </summary>
        private const string CreateOrUpdateMethodName = "CreateOrUpdate";

        /// <summary>
        /// Name of the CreateOrUpdateAsync() method in [Resource]Container classes.
        /// </summary>
        private const string CreateOrUpdateAsyncMethodName = "CreateOrUpdateAsync";

        /// <summary>
        /// Gets the resource type definition for a ResourceType.
        /// </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Resources/resourceGroups";

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroupOperations"/> class for mocking.
        /// </summary>
        protected ResourceGroupOperations()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroupOperations"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="rgName"> The name of the resource group to use. </param>
        internal ResourceGroupOperations(SubscriptionOperations options, string rgName)
            : base(options, new ResourceGroupResourceIdentifier(options.Id, rgName))
        {
            if (rgName.Length > 90)
                throw new ArgumentOutOfRangeException(nameof(rgName), "ResourceGroupName cannot be longer than 90 characters.");

            if (!ValidationPattern.IsMatch(rgName))
                throw new ArgumentException("The name of the resource group can include alphanumeric, underscore, parentheses, hyphen, period (except at end), and Unicode characters that match the allowed characters.", nameof(rgName));
        }

        private static readonly Regex ValidationPattern = new Regex(@"^[-\w\._\(\)]+$");

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroupOperations"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected ResourceGroupOperations(ResourceOperationsBase options, ResourceGroupResourceIdentifier id)
            : base(options, id)
        {
        }

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => ResourceType;

        private ResourceGroupsRestOperations RestClient => new ResourceGroupsRestOperations(
            Diagnostics,
            Pipeline,
            Id.SubscriptionId,
            BaseUri);

        private ResourcesRestOperations GenericRestClient => new ResourcesRestOperations(Diagnostics, Pipeline, Id.SubscriptionId, BaseUri);

        /// <summary>
        /// When you delete a resource group, all of its resources are also deleted. Deleting a resource group deletes all of its template deployments and currently stored operations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="Response"/> operation for this resource. </returns>
        public virtual Response Delete(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.Delete");
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
            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.Delete");
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
            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.StartDelete");
            scope.Start();

            try
            {
                var originalResponse = RestClient.Delete(Id.Name, cancellationToken);
                return new ResourceGroupDeleteOperation(Diagnostics, Pipeline, RestClient.CreateDeleteRequest(Id.Name).Request, originalResponse);
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
            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.StartDelete");
            scope.Start();

            try
            {
                var originalResponse = await RestClient.DeleteAsync(Id.Name, cancellationToken).ConfigureAwait(false);
                return new ResourceGroupDeleteOperation(Diagnostics, Pipeline, RestClient.CreateDeleteRequest(Id.Name).Request, originalResponse);
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
        public virtual ResourceGroupsExportTemplateOperation StartExportTemplate(ExportTemplateRequest parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.StartExportTemplate");
            scope.Start();
            try
            {
                var originalResponse = RestClient.ExportTemplate(Id.Name, parameters, cancellationToken);
                return new ResourceGroupsExportTemplateOperation(Diagnostics, Pipeline, RestClient.CreateExportTemplateRequest(Id.Name, parameters).Request, originalResponse);
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
        public virtual async Task<ResourceGroupsExportTemplateOperation> StartExportTemplateAsync(ExportTemplateRequest parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.StartExportTemplate");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.ExportTemplateAsync(Id.Name, parameters, cancellationToken).ConfigureAwait(false);
                return new ResourceGroupsExportTemplateOperation(Diagnostics, Pipeline, RestClient.CreateExportTemplateRequest(Id.Name, parameters).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        public override Response<ResourceGroup> Get(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.Get");
            scope.Start();

            try
            {
                var originalResponse = RestClient.Get(Id.Name, cancellationToken);
                return Response.FromValue(new ResourceGroup(this, originalResponse), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        public override async Task<Response<ResourceGroup>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.Get");
            scope.Start();

            try
            {
                var originalResponse = await RestClient.GetAsync(Id.Name, cancellationToken).ConfigureAwait(false);
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
        public virtual Response<ResourceGroup> Update(ResourceGroupPatchable parameters, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.Update");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Update(Id.Name, parameters, cancellationToken);
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
            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.Update");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.UpdateAsync(Id.Name, parameters, cancellationToken).ConfigureAwait(false);
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

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.AddTag");
            scope.Start();

            try
            {
                var originalTags = TagResourceOperations.Get(cancellationToken).Value;
                originalTags.Data.Properties.TagsValue[key] = value;
                TagContainer.CreateOrUpdate(originalTags.Data, cancellationToken);
                var originalResponse = RestClient.Get(Id.Name, cancellationToken);
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

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.AddTag");
            scope.Start();

            try
            {
                var originalTags = await TagResourceOperations.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue[key] = value;
                await TagContainer.CreateOrUpdateAsync(originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
                var originalResponse = await RestClient.GetAsync(Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ResourceGroup(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create a resource with a ResourceGroupOperations.
        /// </summary>
        /// <param name="name"> A string representing the name of the resource />. </param>
        /// <param name="model"> The model representing the object to create. />. </param>
        /// <typeparam name="TContainer"> The type of the class containing the container for the specific resource. </typeparam>
        /// <typeparam name="TOperations"> The type of the operations class for a specific resource. </typeparam>
        /// <typeparam name="TIdentifier"> The type of the resource identifier. </typeparam>
        /// <typeparam name="TResource"> The type of the class containing properties for the underlying resource. </typeparam>
        /// <returns> Returns a response with the <see cref="Response{TOperations}"/> operation for this resource. </returns>
        /// <exception cref="ArgumentException"> Name cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> Model cannot be null. </exception>
        public virtual Response<TOperations> CreateResource<TContainer, TOperations, TIdentifier, TResource>(string name, TResource model)
            where TResource : TrackedResource<TIdentifier>
            where TOperations : ResourceOperationsBase<TIdentifier, TOperations>
            where TContainer : ResourceContainerBase<TIdentifier, TOperations, TResource>
            where TIdentifier : SubscriptionResourceIdentifier
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} provided cannot be null or a whitespace.", nameof(name));
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            var myResource = model as TrackedResource<TIdentifier>;
            TContainer container = Activator.CreateInstance(typeof(TContainer), ClientOptions, myResource) as TContainer;
            var createOrUpdateMethod = typeof(TContainer).GetMethod(CreateOrUpdateMethodName);
            return createOrUpdateMethod.Invoke(container, new object[] { name, model }) as Response<TOperations>;
        }

        /// <summary>
        /// Create a resource with a ResourceGroupOperations.
        /// </summary>
        /// <param name="name"> A string representing the name of the resource />. </param>
        /// <param name="model"> The model representing the object to create. />. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <typeparam name="TContainer"> The type of the class containing the container for the specific resource. </typeparam>
        /// <typeparam name="TIdentifier"> The type of the operations class for a specific resource. </typeparam>
        /// <typeparam name="TOperations"> The type of the resource identifier. </typeparam>
        /// <typeparam name="TResource"> The type of the class containing properties for the underlying resource. </typeparam>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="Response{TOperations}"/> operation for this resource. </returns>
        /// <exception cref="ArgumentException"> Name cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> Model cannot be null. </exception>
        public virtual Task<Response<TOperations>> CreateResourceAsync<TContainer, TIdentifier, TOperations, TResource>(string name, TResource model, CancellationToken cancellationToken = default)
            where TResource : TrackedResource<TIdentifier>
            where TOperations : ResourceOperationsBase<TIdentifier, TOperations>
            where TContainer : ResourceContainerBase<TIdentifier, TOperations, TResource>
            where TIdentifier : SubscriptionResourceIdentifier
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} provided cannot be null or a whitespace.", nameof(name));
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            var myResource = model as TrackedResource<TIdentifier>;

            TContainer container = Activator.CreateInstance(typeof(TContainer), ClientOptions, myResource) as TContainer;
            var createOrUpdateAsyncMethod = typeof(TContainer).GetMethod(CreateOrUpdateAsyncMethodName);
            return createOrUpdateAsyncMethod.Invoke(container, new object[] { name, model, cancellationToken }) as Task<Response<TOperations>>;
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

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.SetTags");
            scope.Start();

            try
            {
                TagResourceOperations.Delete(cancellationToken);
                var newTags = TagResourceOperations.Get(cancellationToken);
                newTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);
                TagContainer.CreateOrUpdate(new TagResourceData(newTags.Value.Data.Properties), cancellationToken);
                var originalResponse = RestClient.Get(Id.Name, cancellationToken);
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

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.SetTags");
            scope.Start();

            try
            {
                await TagResourceOperations.DeleteAsync(cancellationToken).ConfigureAwait(false);
                var newTags = await TagResourceOperations.GetAsync(cancellationToken).ConfigureAwait(false);
                newTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);
                await TagContainer.CreateOrUpdateAsync(new TagResourceData(newTags.Value.Data.Properties), cancellationToken).ConfigureAwait(false);
                var originalResponse = await RestClient.GetAsync(Id.Name, cancellationToken).ConfigureAwait(false);
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

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.RemoveTag");
            scope.Start();

            try
            {
                var originalTags = TagResourceOperations.Get(cancellationToken).Value;
                originalTags.Data.Properties.TagsValue.Remove(key);
                TagContainer.CreateOrUpdate(originalTags.Data, cancellationToken);
                var originalResponse = RestClient.Get(Id.Name, cancellationToken);
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

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.RemoveTag");
            scope.Start();

            try
            {
                var originalTags = await TagResourceOperations.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue.Remove(key);
                await TagContainer.CreateOrUpdateAsync(originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
                var originalResponse = await RestClient.GetAsync(Id.Name, cancellationToken).ConfigureAwait(false);
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
        public virtual IEnumerable<Location> ListAvailableLocations(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.ListAvailableLocations");
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
        public virtual async Task<IEnumerable<Location>> ListAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.ListAvailableLocations");
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

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.MoveResources");
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

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.MoveResources");
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
        public virtual ResourcesMoveResourcesOperation StartMoveResources(ResourcesMoveInfo parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.StartMoveResources");
            scope.Start();
            try
            {
                var originalResponse = GenericRestClient.MoveResources(Id.Name, parameters, cancellationToken);
                return new ResourcesMoveResourcesOperation(Diagnostics, Pipeline, GenericRestClient.CreateMoveResourcesRequest(Id.Name, parameters).Request, originalResponse);
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
        public virtual async Task<ResourcesMoveResourcesOperation> StartMoveResourcesAsync(ResourcesMoveInfo parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.StartMoveResources");
            scope.Start();
            try
            {
                var originalResponse = await GenericRestClient.MoveResourcesAsync(Id.Name, parameters, cancellationToken).ConfigureAwait(false);
                return new ResourcesMoveResourcesOperation(Diagnostics, Pipeline, GenericRestClient.CreateMoveResourcesRequest(Id.Name, parameters).Request, originalResponse);
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

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.ValidateMoveResources");
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

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.ValidateMoveResources");
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
        public virtual ResourcesValidateMoveResourcesOperation StartValidateMoveResources(ResourcesMoveInfo parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.StartValidateMoveResources");
            scope.Start();
            try
            {
                var originalResponse = GenericRestClient.ValidateMoveResources(Id.Name, parameters, cancellationToken);
                return new ResourcesValidateMoveResourcesOperation(Diagnostics, Pipeline, GenericRestClient.CreateValidateMoveResourcesRequest(Id.Name, parameters).Request, originalResponse);
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
        public virtual async Task<ResourcesValidateMoveResourcesOperation> StartValidateMoveResourcesAsync(ResourcesMoveInfo parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.StartValidateMoveResources");
            scope.Start();
            try
            {
                var originalResponse = await GenericRestClient.ValidateMoveResourcesAsync(Id.Name, parameters, cancellationToken).ConfigureAwait(false);
                return new ResourcesValidateMoveResourcesOperation(Diagnostics, Pipeline, GenericRestClient.CreateValidateMoveResourcesRequest(Id.Name, parameters).Request, originalResponse);
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
        public virtual T UseClientContext<T>(Func<Uri, TokenCredential, ArmClientOptions, HttpPipeline, T> func)
        {
            return func(BaseUri, Credential, ClientOptions, Pipeline);
        }
    }
}
