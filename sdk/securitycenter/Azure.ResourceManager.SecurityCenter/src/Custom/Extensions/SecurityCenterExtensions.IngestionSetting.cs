// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.SecurityCenter
{
    /// <summary> Provides compatibility shims for ingestion setting extension methods. </summary>
    public static partial class SecurityCenterExtensions
    {
        /// <summary> Gets an object representing an ingestion setting resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
        public static IngestionSettingResource GetIngestionSettingResource(this ArmClient client, ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct replacement is available."); }

        /// <summary> Gets a collection of ingestion settings. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
        public static IngestionSettingCollection GetIngestionSettings(this SubscriptionResource subscriptionResource) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct replacement is available."); }

        /// <summary> Gets an ingestion setting. </summary>
        [Azure.Core.ForwardsClientCalls]
        [System.Obsolete("This API is no longer supported by the service.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Azure.Response<IngestionSettingResource> GetIngestionSetting(this SubscriptionResource subscriptionResource, string ingestionSettingName, System.Threading.CancellationToken cancellationToken = default) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        /// <summary> Gets an ingestion setting. </summary>
        [Azure.Core.ForwardsClientCalls]
        [System.Obsolete("This API is no longer supported by the service.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<IngestionSettingResource>> GetIngestionSettingAsync(this SubscriptionResource subscriptionResource, string ingestionSettingName, System.Threading.CancellationToken cancellationToken = default) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
