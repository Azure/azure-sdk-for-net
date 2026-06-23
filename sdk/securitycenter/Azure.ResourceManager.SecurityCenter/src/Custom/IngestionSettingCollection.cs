// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.SecurityCenter
{
    /// <summary> Provides a compatibility shim for the IngestionSettingCollection class. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class IngestionSettingCollection : ArmCollection, IAsyncEnumerable<IngestionSettingResource>, IEnumerable<IngestionSettingResource>
    {
        /// <summary> Initializes a new instance of <see cref="IngestionSettingCollection"/>. </summary>
        protected IngestionSettingCollection()
        {
        }

        internal IngestionSettingCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Creates or updates an ingestion setting. </summary>
        [System.Obsolete("This API is no longer supported by the service.")]
        public virtual ArmOperation<IngestionSettingResource> CreateOrUpdate(WaitUntil waitUntil, string ingestionSettingName, IngestionSettingData data, System.Threading.CancellationToken cancellationToken = default) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        /// <summary> Creates or updates an ingestion setting. </summary>
        [System.Obsolete("This API is no longer supported by the service.")]
        public virtual System.Threading.Tasks.Task<ArmOperation<IngestionSettingResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string ingestionSettingName, IngestionSettingData data, System.Threading.CancellationToken cancellationToken = default) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        /// <summary> Gets an ingestion setting. </summary>
        [System.Obsolete("This API is no longer supported by the service.")]
        public virtual Azure.Response<IngestionSettingResource> Get(string ingestionSettingName, System.Threading.CancellationToken cancellationToken = default) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        /// <summary> Gets an ingestion setting. </summary>
        [System.Obsolete("This API is no longer supported by the service.")]
        public virtual System.Threading.Tasks.Task<Azure.Response<IngestionSettingResource>> GetAsync(string ingestionSettingName, System.Threading.CancellationToken cancellationToken = default) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        /// <summary> Checks whether an ingestion setting exists. </summary>
        [System.Obsolete("This API is no longer supported by the service.")]
        public virtual Azure.Response<bool> Exists(string ingestionSettingName, System.Threading.CancellationToken cancellationToken = default) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        /// <summary> Checks whether an ingestion setting exists. </summary>
        [System.Obsolete("This API is no longer supported by the service.")]
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ingestionSettingName, System.Threading.CancellationToken cancellationToken = default) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        /// <summary> Gets all ingestion settings. </summary>
        [System.Obsolete("This API is no longer supported by the service.")]
        public virtual Azure.Pageable<IngestionSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        /// <summary> Gets all ingestion settings. </summary>
        [System.Obsolete("This API is no longer supported by the service.")]
        public virtual Azure.AsyncPageable<IngestionSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        System.Collections.Generic.IAsyncEnumerator<IngestionSettingResource> IAsyncEnumerable<IngestionSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        IEnumerator<IngestionSettingResource> IEnumerable<IngestionSettingResource>.GetEnumerator() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        IEnumerator IEnumerable.GetEnumerator() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
