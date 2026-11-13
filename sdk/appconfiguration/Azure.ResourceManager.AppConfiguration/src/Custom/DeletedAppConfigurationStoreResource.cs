// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.AppConfiguration
{
    /// <summary>
    /// A Class representing a DeletedAppConfigurationStore along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="DeletedAppConfigurationStoreResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetDeletedAppConfigurationStoreResource method.
    /// Otherwise you can get one from its parent resource <see cref="SubscriptionResource" /> using the GetDeletedAppConfigurationStore method.
    /// </summary>
    public partial class DeletedAppConfigurationStoreResource : ArmResource
    {
        /// <summary>
        /// Add a tag to the current resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.AppConfiguration/locations/{location}/deletedConfigurationStores/{configStoreName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ConfigurationStores_GetDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DeletedAppConfigurationStoreResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            // Don't need to implement tags operations here since it's not a real tags, check this issue https://github.com/Azure/autorest.csharp/issues/5096
            throw new NotSupportedException("This method is no longer supported because the resource does not have a tags property.");
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.AppConfiguration/locations/{location}/deletedConfigurationStores/{configStoreName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ConfigurationStores_GetDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DeletedAppConfigurationStoreResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            // Don't need to implement tags operations here since it's not a real tags, check this issue https://github.com/Azure/autorest.csharp/issues/5096
            throw new NotSupportedException("This method is no longer supported because the resource does not have a tags property.");
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.AppConfiguration/locations/{location}/deletedConfigurationStores/{configStoreName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ConfigurationStores_GetDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DeletedAppConfigurationStoreResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            // Don't need to implement tags operations here since it's not a real tags, check this issue https://github.com/Azure/autorest.csharp/issues/5096
            throw new NotSupportedException("This method is no longer supported because the resource does not have a tags property.");
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.AppConfiguration/locations/{location}/deletedConfigurationStores/{configStoreName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ConfigurationStores_GetDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DeletedAppConfigurationStoreResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            // Don't need to implement tags operations here since it's not a real tags, check this issue https://github.com/Azure/autorest.csharp/issues/5096
            throw new NotSupportedException("This method is no longer supported because the resource does not have a tags property.");
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.AppConfiguration/locations/{location}/deletedConfigurationStores/{configStoreName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ConfigurationStores_GetDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DeletedAppConfigurationStoreResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            // Don't need to implement tags operations here since it's not a real tags, check this issue https://github.com/Azure/autorest.csharp/issues/5096
            throw new NotSupportedException("This method is no longer supported because the resource does not have a tags property.");
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.AppConfiguration/locations/{location}/deletedConfigurationStores/{configStoreName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ConfigurationStores_GetDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DeletedAppConfigurationStoreResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            // Don't need to implement tags operations here since it's not a real tags, check this issue https://github.com/Azure/autorest.csharp/issues/5096
            throw new NotSupportedException("This method is no longer supported because the resource does not have a tags property.");
        }
    }
}
