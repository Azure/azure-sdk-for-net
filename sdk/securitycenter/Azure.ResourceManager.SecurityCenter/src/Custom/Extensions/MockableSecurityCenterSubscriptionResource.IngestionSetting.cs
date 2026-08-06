// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    public partial class MockableSecurityCenterSubscriptionResource
    {
        /// <summary> Gets a collection of ingestion settings. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual IngestionSettingCollection GetIngestionSettings() { throw new System.NotSupportedException("This API is no longer supported by the service. No direct replacement is available."); }

        /// <summary> Gets an ingestion setting. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<IngestionSettingResource> GetIngestionSetting(string ingestionSettingName, CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported by the service.");

        /// <summary> Gets an ingestion setting. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<IngestionSettingResource>> GetIngestionSettingAsync(string ingestionSettingName, CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported by the service.");
    }
}
