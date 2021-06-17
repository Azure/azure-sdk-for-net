// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary> The Tags service client. </summary>
    public class PreDefinedTagsOperations : OperationsBase
    {
        /// <summary>
        /// The resource type for Tags.
        /// </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Resources/subscriptions/tagNames";

        /// <summary>
        /// Initializes a new instance of the <see cref="PreDefinedTagsOperations"/> class for mocking.
        /// </summary>
        protected PreDefinedTagsOperations()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PreDefinedTagsOperations"/> class.
        /// </summary>
        /// <param name="clientContext"></param>
        /// <param name="subscriptionGuid"> The Guid of the subscription. </param>
        /// <param name="tagData"> The Guid of the subscription. </param>
        internal PreDefinedTagsOperations(ClientContext clientContext, string subscriptionGuid, PreDefinedTagData tagData)
            : base(clientContext, new PreDefinedTagsResourceIdentifier(subscriptionGuid, tagData))
        {
        }

        /// <summary>
        /// Gets the valid resource type for this operation class.
        /// </summary>
        protected override ResourceType ValidResourceType => ResourceType;

        private TagsRestOperations RestClient => new TagsRestOperations(Diagnostics, Pipeline, ((SubscriptionResourceIdentifier)Id).SubscriptionId, BaseUri);

        /// <summary> This operation allows deleting a value from the list of predefined values for an existing predefined tag name. The value being deleted must not be in use as a tag value for the given tag name for any resource. </summary>
        /// <param name="tagName"> The name of the tag. </param>
        /// <param name="tagValue"> The value of the tag to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DeleteValueAsync(string tagName, string tagValue, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("PreDefinedTagsOperations.DeleteValue");
            scope.Start();
            try
            {
                return await RestClient.DeleteValueAsync(tagName, tagValue, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> This operation allows deleting a value from the list of predefined values for an existing predefined tag name. The value being deleted must not be in use as a tag value for the given tag name for any resource. </summary>
        /// <param name="tagName"> The name of the tag. </param>
        /// <param name="tagValue"> The value of the tag to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response DeleteValue(string tagName, string tagValue, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("PreDefinedTagsOperations.DeleteValue");
            scope.Start();
            try
            {
                return RestClient.DeleteValue(tagName, tagValue, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> This operation allows adding a value to the list of predefined values for an existing predefined tag name. A tag value can have a maximum of 256 characters. </summary>
        /// <param name="tagName"> The name of the tag. </param>
        /// <param name="tagValue"> The value of the tag to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PreDefinedTagValue>> CreateOrUpdateValueAsync(string tagName, string tagValue, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("PreDefinedTagsOperations.CreateOrUpdateValue");
            scope.Start();
            try
            {
                return await RestClient.CreateOrUpdateValueAsync(tagName, tagValue, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> This operation allows adding a value to the list of predefined values for an existing predefined tag name. A tag value can have a maximum of 256 characters. </summary>
        /// <param name="tagName"> The name of the tag. </param>
        /// <param name="tagValue"> The value of the tag to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PreDefinedTagValue> CreateOrUpdateValue(string tagName, string tagValue, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("PreDefinedTagsOperations.CreateOrUpdateValue");
            scope.Start();
            try
            {
                return RestClient.CreateOrUpdateValue(tagName, tagValue, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> This operation allows deleting a name from the list of predefined tag names for the given subscription. The name being deleted must not be in use as a tag name for any resource. All predefined values for the given name must have already been deleted. </summary>
        /// <param name="tagName"> The name of the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DeleteAsync(string tagName, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("PreDefinedTagsOperations.Delete");
            scope.Start();
            try
            {
                return await RestClient.DeleteAsync(tagName, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> This operation allows deleting a name from the list of predefined tag names for the given subscription. The name being deleted must not be in use as a tag name for any resource. All predefined values for the given name must have already been deleted. </summary>
        /// <param name="tagName"> The name of the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Delete(string tagName, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("PreDefinedTagsOperations.Delete");
            scope.Start();
            try
            {
                return RestClient.Delete(tagName, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        protected override void Validate(ResourceIdentifier identifier)
        {
            if (identifier is null)
                throw new ArgumentException("Invalid resource type for TagsOperation", nameof(identifier));
        }
    }
}
