// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.DevTestLabs.Models;

namespace Azure.ResourceManager.DevTestLabs
{
    /// <summary>
    /// A class representing a collection of <see cref="DevTestLabSecretResource" /> and their operations.
    /// Each <see cref="DevTestLabSecretResource" /> in the collection will belong to the same instance of <see cref="DevTestLabUserResource" />.
    /// To get a <see cref="DevTestLabSecretCollection" /> instance call the GetDevTestLabSecrets method from an instance of <see cref="DevTestLabUserResource" />.
    /// </summary>
    public partial class DevTestLabSecretCollection : ArmCollection, IEnumerable<DevTestLabSecretResource>, IAsyncEnumerable<DevTestLabSecretResource>
    {
        /// <summary>
        /// List secrets in a given user profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/users/{userName}/secrets
        /// Operation Id: Secrets_List
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=value)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DevTestLabSecretResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DevTestLabSecretResource> GetAllAsync(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new DevTestLabSecretCollectionGetAllOptions
            {
                Expand = expand,
                Filter = filter,
                Top = top,
                Orderby = orderby
            }, cancellationToken);

        /// <summary>
        /// List secrets in a given user profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/users/{userName}/secrets
        /// Operation Id: Secrets_List
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=value)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DevTestLabSecretResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DevTestLabSecretResource> GetAll(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetAll(new DevTestLabSecretCollectionGetAllOptions
            {
                Expand = expand,
                Filter = filter,
                Top = top,
                Orderby = orderby
            }, cancellationToken);
    }
}
