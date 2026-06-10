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
    public partial class CustomEntityStoreAssignmentCollection : ArmCollection, IAsyncEnumerable<CustomEntityStoreAssignmentResource>, IEnumerable<CustomEntityStoreAssignmentResource>, IEnumerable
    {
        protected CustomEntityStoreAssignmentCollection() { }
        public virtual ArmOperation<CustomEntityStoreAssignmentResource> CreateOrUpdate(WaitUntil waitUntil, string customEntityStoreAssignmentName, CustomEntityStoreAssignmentCreateOrUpdateContent content, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<ArmOperation<CustomEntityStoreAssignmentResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string customEntityStoreAssignmentName, CustomEntityStoreAssignmentCreateOrUpdateContent content, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Response<bool> Exists(string customEntityStoreAssignmentName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<Response<bool>> ExistsAsync(string customEntityStoreAssignmentName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Response<CustomEntityStoreAssignmentResource> Get(string customEntityStoreAssignmentName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Pageable<CustomEntityStoreAssignmentResource> GetAll(CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual AsyncPageable<CustomEntityStoreAssignmentResource> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<Response<CustomEntityStoreAssignmentResource>> GetAsync(string customEntityStoreAssignmentName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual NullableResponse<CustomEntityStoreAssignmentResource> GetIfExists(string customEntityStoreAssignmentName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<NullableResponse<CustomEntityStoreAssignmentResource>> GetIfExistsAsync(string customEntityStoreAssignmentName, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        IAsyncEnumerator<CustomEntityStoreAssignmentResource> IAsyncEnumerable<CustomEntityStoreAssignmentResource>.GetAsyncEnumerator(CancellationToken cancellationToken) { throw new NotSupportedException("This API is no longer supported by the service."); }
        IEnumerator<CustomEntityStoreAssignmentResource> IEnumerable<CustomEntityStoreAssignmentResource>.GetEnumerator() { throw new NotSupportedException("This API is no longer supported by the service."); }
        IEnumerator IEnumerable.GetEnumerator() { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
