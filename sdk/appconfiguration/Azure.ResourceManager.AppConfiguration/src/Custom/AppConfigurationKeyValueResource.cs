// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.AppConfiguration
{
    // in this resource, the `Tags` property is not on this resource, but in the properties envelope,
    // this means this `Tags` property is not an ARM managed tags, we should not generate these methods.
    public partial class AppConfigurationKeyValueResource
    {
        /// <summary>
        /// Add a tag to the current resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}/keyValues/{keyValueName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>KeyValues_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-05-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppConfigurationKeyValueResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<AppConfigurationKeyValueResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            // Don't need to implement tags operations here since it's not a real tags, check this issue https://github.com/Azure/autorest.csharp/issues/5096
            throw new NotSupportedException("This method is no longer supported because the resource does not have a tags property.");
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}/keyValues/{keyValueName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>KeyValues_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-05-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppConfigurationKeyValueResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<AppConfigurationKeyValueResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            // Don't need to implement tags operations here since it's not a real tags, check this issue https://github.com/Azure/autorest.csharp/issues/5096
            throw new NotSupportedException("This method is no longer supported because the resource does not have a tags property.");
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}/keyValues/{keyValueName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>KeyValues_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-05-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppConfigurationKeyValueResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<AppConfigurationKeyValueResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            // Don't need to implement tags operations here since it's not a real tags, check this issue https://github.com/Azure/autorest.csharp/issues/5096
            throw new NotSupportedException("This method is no longer supported because the resource does not have a tags property.");
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}/keyValues/{keyValueName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>KeyValues_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-05-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppConfigurationKeyValueResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<AppConfigurationKeyValueResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            // Don't need to implement tags operations here since it's not a real tags, check this issue https://github.com/Azure/autorest.csharp/issues/5096
            throw new NotSupportedException("This method is no longer supported because the resource does not have a tags property.");
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}/keyValues/{keyValueName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>KeyValues_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-05-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppConfigurationKeyValueResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<AppConfigurationKeyValueResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            // Don't need to implement tags operations here since it's not a real tags, check this issue https://github.com/Azure/autorest.csharp/issues/5096
            throw new NotSupportedException("This method is no longer supported because the resource does not have a tags property.");
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}/keyValues/{keyValueName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>KeyValues_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-05-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppConfigurationKeyValueResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<AppConfigurationKeyValueResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            // Don't need to implement tags operations here since it's not a real tags, check this issue https://github.com/Azure/autorest.csharp/issues/5096
            throw new NotSupportedException("This method is no longer supported because the resource does not have a tags property.");
        }
    }
}
