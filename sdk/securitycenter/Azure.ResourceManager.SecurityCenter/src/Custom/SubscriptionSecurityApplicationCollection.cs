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
    // The previous GA SDK generated this legacy AutoRest support type from older Security swagger.
    // Current TypeSpec either emits the updated resource/model name or no longer includes that
    // legacy schema, so this hidden obsolete shim is retained only for ApiCompat.
    [Obsolete("This API is no longer supported by the service.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SubscriptionSecurityApplicationCollection : ArmCollection, IAsyncEnumerable<SubscriptionSecurityApplicationResource>, IEnumerable<SubscriptionSecurityApplicationResource>, IEnumerable
    {
        protected SubscriptionSecurityApplicationCollection() { }
        public virtual ArmOperation<SubscriptionSecurityApplicationResource> CreateOrUpdate(WaitUntil waitUntil, string applicationId, SecurityApplicationData data, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<ArmOperation<SubscriptionSecurityApplicationResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string applicationId, SecurityApplicationData data, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Response<bool> Exists(string applicationId, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<Response<bool>> ExistsAsync(string applicationId, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Response<SubscriptionSecurityApplicationResource> Get(string applicationId, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Pageable<SubscriptionSecurityApplicationResource> GetAll(CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual AsyncPageable<SubscriptionSecurityApplicationResource> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<Response<SubscriptionSecurityApplicationResource>> GetAsync(string applicationId, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual NullableResponse<SubscriptionSecurityApplicationResource> GetIfExists(string applicationId, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<NullableResponse<SubscriptionSecurityApplicationResource>> GetIfExistsAsync(string applicationId, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        IAsyncEnumerator<SubscriptionSecurityApplicationResource> IAsyncEnumerable<SubscriptionSecurityApplicationResource>.GetAsyncEnumerator(CancellationToken cancellationToken) { throw new NotSupportedException("This API is no longer supported by the service."); }
        IEnumerator<SubscriptionSecurityApplicationResource> IEnumerable<SubscriptionSecurityApplicationResource>.GetEnumerator() { throw new NotSupportedException("This API is no longer supported by the service."); }
        IEnumerator IEnumerable.GetEnumerator() { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
