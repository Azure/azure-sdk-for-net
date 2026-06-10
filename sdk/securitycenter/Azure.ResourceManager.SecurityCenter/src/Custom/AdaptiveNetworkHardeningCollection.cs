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
    [Obsolete("This API is no longer supported by the service.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AdaptiveNetworkHardeningCollection : ArmCollection, IAsyncEnumerable<AdaptiveNetworkHardeningResource>, IEnumerable<AdaptiveNetworkHardeningResource>, IEnumerable
    {
        protected AdaptiveNetworkHardeningCollection() { }
        public virtual Response<bool> Exists(string adaptiveNetworkHardeningResourceName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<Response<bool>> ExistsAsync(string adaptiveNetworkHardeningResourceName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Response<AdaptiveNetworkHardeningResource> Get(string adaptiveNetworkHardeningResourceName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Pageable<AdaptiveNetworkHardeningResource> GetAll(CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual AsyncPageable<AdaptiveNetworkHardeningResource> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<Response<AdaptiveNetworkHardeningResource>> GetAsync(string adaptiveNetworkHardeningResourceName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual NullableResponse<AdaptiveNetworkHardeningResource> GetIfExists(string adaptiveNetworkHardeningResourceName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<NullableResponse<AdaptiveNetworkHardeningResource>> GetIfExistsAsync(string adaptiveNetworkHardeningResourceName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        IAsyncEnumerator<AdaptiveNetworkHardeningResource> IAsyncEnumerable<AdaptiveNetworkHardeningResource>.GetAsyncEnumerator(CancellationToken cancellationToken) { throw new NotSupportedException("This API is no longer supported by the service."); }
        IEnumerator<AdaptiveNetworkHardeningResource> IEnumerable<AdaptiveNetworkHardeningResource>.GetEnumerator() { throw new NotSupportedException("This API is no longer supported by the service."); }
        IEnumerator IEnumerable.GetEnumerator() { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
