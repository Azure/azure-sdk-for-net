// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using Azure;

namespace Azure.ResourceManager.Compute
{
    public partial class CapacityReservationCollection
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<CapacityReservationResource> GetAllAsync(CancellationToken cancellationToken)
            => GetAllAsync(null, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<CapacityReservationResource> GetAll(CancellationToken cancellationToken)
            => GetAll(null, cancellationToken);
    }
}
