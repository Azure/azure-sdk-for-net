// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;

namespace Azure.ResourceManager.AppConfiguration
{
    public partial class AppConfigurationKeyValueCollection : IEnumerable<AppConfigurationKeyValueResource>, IAsyncEnumerable<AppConfigurationKeyValueResource>
    {
        /// <summary>
        /// Lists the key-values for a given configuration store.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}/keyValues</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>KeyValues_ListByConfigurationStore</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-05-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppConfigurationKeyValueResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skipToken"> A skip token is used to continue retrieving items after an operation returns a partial result. If a previous response contains a nextLink element, the value of the nextLink element will include a skipToken parameter that specifies a starting point to use for subsequent calls. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AppConfigurationKeyValueResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete as it never works, it will be removed in a future release", false)]
        public virtual AsyncPageable<AppConfigurationKeyValueResource> GetAllAsync(string skipToken = null, CancellationToken cancellationToken = default)
        {
            return AsyncPageable<AppConfigurationKeyValueResource>.FromPages(Enumerable.Empty<Page<AppConfigurationKeyValueResource>>());
        }

        /// <summary>
        /// Lists the key-values for a given configuration store.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}/keyValues</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>KeyValues_ListByConfigurationStore</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-05-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppConfigurationKeyValueResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skipToken"> A skip token is used to continue retrieving items after an operation returns a partial result. If a previous response contains a nextLink element, the value of the nextLink element will include a skipToken parameter that specifies a starting point to use for subsequent calls. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AppConfigurationKeyValueResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete as it never works, it will be removed in a future release", false)]
        public virtual Pageable<AppConfigurationKeyValueResource> GetAll(string skipToken = null, CancellationToken cancellationToken = default)
        {
            return Pageable<AppConfigurationKeyValueResource>.FromPages(Enumerable.Empty<Page<AppConfigurationKeyValueResource>>());
        }

        [Obsolete("This method is obsolete as it never works, it will be removed in a future release", false)]
        IEnumerator<AppConfigurationKeyValueResource> IEnumerable<AppConfigurationKeyValueResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        [Obsolete("This method is obsolete as it never works, it will be removed in a future release", false)]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        [Obsolete("This method is obsolete as it never works, it will be removed in a future release", false)]
        IAsyncEnumerator<AppConfigurationKeyValueResource> IAsyncEnumerable<AppConfigurationKeyValueResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
