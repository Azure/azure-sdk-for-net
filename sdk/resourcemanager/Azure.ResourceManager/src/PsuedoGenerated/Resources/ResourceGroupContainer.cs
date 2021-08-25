// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing collection of ResourceGroupContainer and their operations over a ResourceGroup.
    /// </summary>
    public class ResourceGroupContainer : ArmContainer
    {
        private ClientDiagnostics _clientDiagnostics;
        private ResourceGroupsRestOperations _restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroupContainer"/> class for mocking.
        /// </summary>
        protected ResourceGroupContainer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroupContainer"/> class.
        /// </summary>
        /// <param name="subscription"> The parent subscription. </param>
        internal ResourceGroupContainer(Subscription subscription)
            : base(subscription)
        {
        }

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => Subscription.ResourceType;

        /// <summary>
        /// Gets the parent resource of this resource.
        /// </summary>
        protected new Subscription Parent { get {return base.Parent as Subscription;} }

        private ResourceGroupsRestOperations RestClient => _restClient ??= new ResourceGroupsRestOperations(Diagnostics, Pipeline, Id.SubscriptionId, BaseUri);

        private ClientDiagnostics Diagnostics => _clientDiagnostics ??= new ClientDiagnostics(ClientOptions);

        /// <summary>
        /// Returns the resource from Azure if it exists.
        /// </summary>
        /// <param name="resourceGroupName"> The name of the resource you want to get. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public virtual Response<ResourceGroup> GetIfExists(string resourceGroupName, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceGroupContainer.GetIfExists");
            scope.Start();

            try
            {
                var response = RestClient.Get(resourceGroupName, cancellationToken);
                return response.Value == null
                   ? Response.FromValue<ResourceGroup>(null, response.GetRawResponse())
                   : Response.FromValue(new ResourceGroup(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns the resource from Azure if it exists.
        /// </summary>
        /// <param name="resourceGroupName"> The name of the resource you want to get. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public virtual async Task<Response<ResourceGroup>> GetIfExistsAsync(string resourceGroupName, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceGroupContainer.GetIfExists");
            scope.Start();

            try
            {
                var response = await RestClient.GetAsync(resourceGroupName, cancellationToken).ConfigureAwait(false);
                return response.Value == null
                     ? Response.FromValue<ResourceGroup>(null, response.GetRawResponse())
                     : Response.FromValue(new ResourceGroup(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Determines whether or not the azure resource exists in this container.
        /// </summary>
        /// <param name="resourceGroupName"> The name of the resource you want to check. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public virtual Response<bool> CheckIfExists(string resourceGroupName, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceGroupContainer.CheckIfExists");
            scope.Start();
            try
            {
                var response = GetIfExists(resourceGroupName, cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Determines whether or not the azure resource exists in this container.
        /// </summary>
        /// <param name="resourceGroupName"> The name of the resource you want to check. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public virtual async Task<Response<bool>> CheckIfExistsAsync(string resourceGroupName, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceGroupContainer.CheckIfExists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(resourceGroupName, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Constructs an object used to create a resource group.
        /// </summary>
        /// <param name="location"> The location of the resource group. </param>
        /// <param name="tags"> The tags of the resource group. </param>
        /// <param name="managedBy"> Who the resource group is managed by. </param>
        /// <returns> A builder with <see cref="ResourceGroup"/> and <see cref="ResourceGroupData"/>. </returns>
        /// <exception cref="ArgumentNullException"> Location cannot be null. </exception>
        internal ResourceGroupBuilder Construct(Location location, IDictionary<string, string> tags = default, string managedBy = default)
        {
            if (location is null)
                throw new ArgumentNullException(nameof(location));

            var model = new ResourceGroupData(location);
            if (!(tags is null))
                model.Tags.ReplaceWith(tags);
            model.ManagedBy = managedBy;
            return new ResourceGroupBuilder(this, model);
        }

        /// <summary>
        /// The operation to create or update a resource group. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the resource group. </param>
        /// <param name="resourceDetails"> The desired resource group configuration. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="Response{ResourceGroup}"/> operation for this resource. </returns>
        /// <exception cref="ArgumentException"> Name of the resource group cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> resourceDetails cannot be null. </exception>
        public Response<ResourceGroup> CreateOrUpdate(string name, ResourceGroupData resourceDetails, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name cannot be null or a whitespace.", nameof(name));
            if (resourceDetails is null)
                throw new ArgumentNullException(nameof(resourceDetails));

            using var scope = Diagnostics.CreateScope("ResourceGroupContainer.CreateOrUpdate");
            scope.Start();

            try
            {
                var operation = StartCreateOrUpdate(name, resourceDetails, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The operation to create or update a resource group. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the resource group. </param>
        /// <param name="resourceDetails"> The desired resource group configuration. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="Response{ResourceGroup}"/> operation for this resource group. </returns>
        /// <exception cref="ArgumentException"> Name of the resource group cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> resourceDetails cannot be null. </exception>
        public virtual async Task<Response<ResourceGroup>> CreateOrUpdateAsync(string name, ResourceGroupData resourceDetails, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name cannot be null or a whitespace.", nameof(name));
            if (resourceDetails is null)
                throw new ArgumentNullException(nameof(resourceDetails));

            using var scope = Diagnostics.CreateScope("ResourceGroupContainer.CreateOrUpdate");
            scope.Start();

            try
            {
                var operation = await StartCreateOrUpdateAsync(name, resourceDetails, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The operation to create or update a resource group. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the resource group. </param>
        /// <param name="resourceDetails"> The desired resource group configuration. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An <see cref="Operation{ResourceGroup}"/> that allows polling for completion of the operation. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        /// <exception cref="ArgumentException"> Name of the resource group cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> resourceDetails cannot be null. </exception>
        public ResourceGroupCreateOrUpdateOperation StartCreateOrUpdate(string name, ResourceGroupData resourceDetails, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name cannot be null or a whitespace.", nameof(name));
            if (resourceDetails is null)
                throw new ArgumentNullException(nameof(resourceDetails));

            using var scope = Diagnostics.CreateScope("ResourceGroupContainer.StartCreateOrUpdate");
            scope.Start();

            try
            {
                var originalResponse = RestClient.CreateOrUpdate(name, resourceDetails, cancellationToken);
                return new ResourceGroupCreateOrUpdateOperation(this, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The operation to create or update a resource group. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the resource group. </param>
        /// <param name="resourceDetails"> The desired resource group configuration. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="Operation{ResourceGroup}"/> that allows polling for completion of the operation. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        /// <exception cref="ArgumentException"> Name of the resource group cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> resourceDetails cannot be null. </exception>
        public virtual async Task<ResourceGroupCreateOrUpdateOperation> StartCreateOrUpdateAsync(string name, ResourceGroupData resourceDetails, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name cannot be null or a whitespace.", nameof(name));
            if (resourceDetails is null)
                throw new ArgumentNullException(nameof(resourceDetails));

            using var scope = Diagnostics.CreateScope("ResourceGroupContainer.StartCreateOrUpdate");
            scope.Start();

            try
            {
                var originalResponse = await RestClient.CreateOrUpdateAsync(name, resourceDetails, cancellationToken).ConfigureAwait(false);
                return new ResourceGroupCreateOrUpdateOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List the resource groups for this subscription.
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation.&lt;br&gt;&lt;br&gt;You can filter by tag names and values. For example, to filter for a tag name and value, use $filter=tagName eq &apos;tag1&apos; and tagValue eq &apos;Value1&apos;. </param>
        /// <param name="top"> The number of results to return. If null is passed, returns all resource groups. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public virtual Pageable<ResourceGroup> GetAll(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Page<ResourceGroup> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("ResourceGroupContainer.GetAll");
                scope.Start();
                try
                {
                    var response = RestClient.List(filter, top, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(data => new ResourceGroup(Parent, data)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ResourceGroup> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("ResourceGroupContainer.GetAll");
                scope.Start();
                try
                {
                    var response = RestClient.ListNextPage(nextLink, filter, top, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(data => new ResourceGroup(Parent, data)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// List the resource groups for this subscription.
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation.&lt;br&gt;&lt;br&gt;You can filter by tag names and values. For example, to filter for a tag name and value, use $filter=tagName eq &apos;tag1&apos; and tagValue eq &apos;Value1&apos;. </param>
        /// <param name="top"> The number of results to return. If null is passed, returns all resource groups. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource operations that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public virtual AsyncPageable<ResourceGroup> GetAllAsync(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ResourceGroup>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("ResourceGroupContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await RestClient.ListAsync(filter, top, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(data => new ResourceGroup(Parent, data)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ResourceGroup>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = Diagnostics.CreateScope("ResourceGroupContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await RestClient.ListNextPageAsync(nextLink, filter, top, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(data => new ResourceGroup(Parent, data)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets details for this resource group from the service.
        /// </summary>
        /// <param name="resourceGroupName"> The name of the resource group get. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="Response{ResourceGroup}"/> operation for this resource group. </returns>
        /// <exception cref="ArgumentException"> resourceGroupName cannot be null or a whitespace. </exception>
        public Response<ResourceGroup> Get(string resourceGroupName, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceGroupContainer.Get");
            scope.Start();

            try
            {
                var result = RestClient.Get(resourceGroupName, cancellationToken);
                if (result.Value == null)
                    throw Diagnostics.CreateRequestFailedException(result.GetRawResponse());

                return Response.FromValue(new ResourceGroup(Parent, result), result.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets details for this resource group from the service.
        /// </summary>
        /// <param name="resourceGroupName"> The name of the resource group get. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="Response{ResourceGroup}"/> operation for this resource group. </returns>
        /// <exception cref="ArgumentException"> resourceGroupName cannot be null or a whitespace. </exception>
        public virtual async Task<Response<ResourceGroup>> GetAsync(string resourceGroupName, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceGroupContainer.Get");
            scope.Start();

            try
            {
                var response = await RestClient.GetAsync(resourceGroupName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await Diagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);

                return Response.FromValue(new ResourceGroup(Parent, response), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
