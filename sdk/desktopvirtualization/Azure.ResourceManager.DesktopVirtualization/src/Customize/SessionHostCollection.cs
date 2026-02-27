// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace Azure.ResourceManager.DesktopVirtualization
{
    /// <summary>
    /// A class representing a collection of <see cref="SessionHostResource" /> and their operations.
    /// Each <see cref="SessionHostResource" /> in the collection will belong to the same instance of <see cref="HostPoolResource" />.
    /// To get a <see cref="SessionHostCollection" /> instance call the GetSessionHosts method from an instance of <see cref="HostPoolResource" />.
    /// </summary>
    public partial class SessionHostCollection : ArmCollection, IEnumerable<SessionHostResource>, IAsyncEnumerable<SessionHostResource>
    {
        /// <summary> List sessionHosts. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SessionHostResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SessionHostResource> GetAllAsync(CancellationToken cancellationToken) => GetAllAsync(null, null, null, null, cancellationToken);

        /// <summary> List sessionHosts. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SessionHostResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SessionHostResource> GetAll(CancellationToken cancellationToken) => GetAll(null, null, null, null, cancellationToken);

        /// <summary> List sessionHosts. </summary>
        /// <param name="pageSize"> Number of items per page. </param>
        /// <param name="isDescending"> Indicates whether the collection is descending. </param>
        /// <param name="initialSkip"> Initial number of items to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SessionHostResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SessionHostResource> GetAllAsync(int? pageSize, bool? isDescending, int? initialSkip, CancellationToken cancellationToken)
            => GetAllAsync(pageSize, isDescending, initialSkip, null, cancellationToken);

        /// <summary> List sessionHosts. </summary>
        /// <param name="pageSize"> Number of items per page. </param>
        /// <param name="isDescending"> Indicates whether the collection is descending. </param>
        /// <param name="initialSkip"> Initial number of items to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SessionHostResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SessionHostResource> GetAll(int? pageSize, bool? isDescending, int? initialSkip, CancellationToken cancellationToken)
            => GetAll(pageSize, isDescending, initialSkip, null, cancellationToken);
    }
}
