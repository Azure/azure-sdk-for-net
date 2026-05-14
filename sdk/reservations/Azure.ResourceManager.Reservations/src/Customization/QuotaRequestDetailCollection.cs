// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Justification: GA exposed Guid-typed overloads for the quota request id. The new TypeSpec-based
// generator emits string-typed parameters; these partial methods preserve the legacy Guid API surface
// by forwarding to the generated string-based methods.

using System;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations
{
    public partial class QuotaRequestDetailCollection
    {
        /// <summary> Get the details and status of the quota request by quota request id. </summary>
        public virtual Task<Response<QuotaRequestDetailResource>> GetAsync(Guid id, CancellationToken cancellationToken = default)
            => GetAsync(id.ToString(), cancellationToken);

        /// <summary> Get the details and status of the quota request by quota request id. </summary>
        public virtual Response<QuotaRequestDetailResource> Get(Guid id, CancellationToken cancellationToken = default)
            => Get(id.ToString(), cancellationToken);

        /// <summary> Checks to see if the resource exists in azure. </summary>
        public virtual Task<Response<bool>> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
            => ExistsAsync(id.ToString(), cancellationToken);

        /// <summary> Checks to see if the resource exists in azure. </summary>
        public virtual Response<bool> Exists(Guid id, CancellationToken cancellationToken = default)
            => Exists(id.ToString(), cancellationToken);

        /// <summary> Tries to get details for this resource from the service. </summary>
        public virtual Task<NullableResponse<QuotaRequestDetailResource>> GetIfExistsAsync(Guid id, CancellationToken cancellationToken = default)
            => GetIfExistsAsync(id.ToString(), cancellationToken);

        /// <summary> Tries to get details for this resource from the service. </summary>
        public virtual NullableResponse<QuotaRequestDetailResource> GetIfExists(Guid id, CancellationToken cancellationToken = default)
            => GetIfExists(id.ToString(), cancellationToken);
    }
}
