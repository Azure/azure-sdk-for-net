﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Interface for operations that allow manipulating resource tags.
    /// </summary>
    /// <typeparam name="TIdentifier"> The identifier type for this resource. </typeparam>
    /// <typeparam name="TOperations"> The typed operations for a specific resource. </typeparam>
    public interface ITaggableResource<TIdentifier, TOperations> 
        where TOperations : ResourceOperationsBase<TIdentifier, TOperations>
        where TIdentifier : TenantResourceIdentifier
    {
        /// <summary>
        /// Add a tag to the resource.
        /// </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="value"> The tag value. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns>An <see cref="Response{TOperations}"/> that allows the user to control polling and waiting for Tag completion.</returns>
        Response<TOperations> AddTag(
            string key,
            string value,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Add a tag to the resource.
        /// </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="value"> The tag value. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that performs the Tag operation.  The Task yields an an
        /// <see cref="Response{TOperations}"/> that allows the user to control polling and waiting for
        /// Tag completion. </returns>
        Task<Response<TOperations>> AddTagAsync(
            string key,
            string value,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Add a tag to the resource.
        /// </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="value"> The tag value. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns>An <see cref="Operation{TOperations}"/> that allows the user to control polling and waiting for Tag completion.</returns>
        Operation<TOperations> StartAddTag(
            string key,
            string value,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Add a tag to the resource.
        /// </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="value"> The tag value. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that performs the Tag operation.  The Task yields an an
        /// <see cref="Operation{TOperations}"/> that allows the user to control polling and waiting for
        /// Tag completion. </returns>
        Task<Operation<TOperations>> StartAddTagAsync(
            string key,
            string value,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Set the resource tags.
        /// </summary>
        /// <param name="tags"> The resource tags. </param>
        /// <param name="cancellationToken"> A token allowing immediate cancellation of any blocking call performed during the deletion. </param>
        /// <returns> The status of the delete operation. </returns>
        Response<TOperations> SetTags(
            IDictionary<string, string> tags,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Set the resource tags.
        /// </summary>
        /// <param name="tags"> The resource tags. </param>
        /// <param name="cancellationToken"> A token allowing immediate cancellation of any blocking call performed during the deletion. </param>
        /// <returns> A <see cref="Task"/> that on completion returns the status of the delete operation. </returns>
        Task<Response<TOperations>> SetTagsAsync(
            IDictionary<string, string> tags,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Set the resource tags.
        /// </summary>
        /// <param name="tags"> The resource tags. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns>An <see cref="Operation{TOperations}"/> that allows the user to control polling and waiting for Tag completion.</returns>
        Operation<TOperations> StartSetTags(
            IDictionary<string, string> tags,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Set the resource tags.
        /// </summary>
        /// <param name="tags"> The resource tags. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that performs the Tag operation.  The Task yields an an
        /// <see cref="Operation{TOperations}"/> that allows the user to control polling and waiting for
        /// Tag completion. </returns>
        Task<Operation<TOperations>> StartSetTagsAsync(
            IDictionary<string, string> tags,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Remove the resource tag.
        /// </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="cancellationToken"> A token allowing immediate cancellation of any blocking call performed during the deletion. </param>
        /// <returns> The status of the delete operation. </returns>
        Response<TOperations> RemoveTag(
            string key,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Remove the resource tag.
        /// </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="cancellationToken"> A token allowing immediate cancellation of any blocking call performed during the deletion. </param>
        /// <returns> A <see cref="Task"/> that on completion returns the status of the delete operation. </returns>
        Task<Response<TOperations>> RemoveTagAsync(
            string key,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Remove the resource tag.
        /// </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns>An <see cref="Operation{TOperations}"/> that allows the user to control polling and waiting for Tag completion.</returns>
        Operation<TOperations> StartRemoveTag(
            string key,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Remove the resource tag.
        /// </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that performs the Tag operation.  The Task yields an an
        /// <see cref="Operation{TOperations}"/> that allows the user to control polling and waiting for
        /// Tag completion. </returns>
        Task<Operation<TOperations>> StartRemoveTagAsync(
            string key,
            CancellationToken cancellationToken = default);
    }
}
