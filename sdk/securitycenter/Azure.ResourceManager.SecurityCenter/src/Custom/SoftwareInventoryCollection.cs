// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591 // Hidden obsolete compatibility shims do not need public docs.

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityCenter;
using Azure.ResourceManager.SecurityCenter.Mocking;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // The previous GA SDK generated this from softwareInventories preview swagger. That legacy
    // swagger is not part of the current TypeSpec generation, so this hidden obsolete shim is
    // retained only for ApiCompat.
    [Obsolete("This API is no longer supported by the service.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SoftwareInventoryCollection : ArmCollection, IAsyncEnumerable<SoftwareInventoryResource>, IEnumerable<SoftwareInventoryResource>, IEnumerable
    {
        protected SoftwareInventoryCollection() { }
        public virtual Response<bool> Exists(string softwareName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<Response<bool>> ExistsAsync(string softwareName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Response<SoftwareInventoryResource> Get(string softwareName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Pageable<SoftwareInventoryResource> GetAll(CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual AsyncPageable<SoftwareInventoryResource> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<Response<SoftwareInventoryResource>> GetAsync(string softwareName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual NullableResponse<SoftwareInventoryResource> GetIfExists(string softwareName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<NullableResponse<SoftwareInventoryResource>> GetIfExistsAsync(string softwareName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        IAsyncEnumerator<SoftwareInventoryResource> IAsyncEnumerable<SoftwareInventoryResource>.GetAsyncEnumerator(CancellationToken cancellationToken) { throw new NotSupportedException("This API is no longer supported by the service."); }
        IEnumerator<SoftwareInventoryResource> IEnumerable<SoftwareInventoryResource>.GetEnumerator() { throw new NotSupportedException("This API is no longer supported by the service."); }
        IEnumerator IEnumerable.GetEnumerator() { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
