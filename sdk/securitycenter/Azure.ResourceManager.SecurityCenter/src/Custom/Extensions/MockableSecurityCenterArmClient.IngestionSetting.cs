// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    public partial class MockableSecurityCenterArmClient
    {
        /// <summary> Gets an object representing an ingestion setting resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
        public virtual IngestionSettingResource GetIngestionSettingResource(ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct replacement is available."); }
    }
}
