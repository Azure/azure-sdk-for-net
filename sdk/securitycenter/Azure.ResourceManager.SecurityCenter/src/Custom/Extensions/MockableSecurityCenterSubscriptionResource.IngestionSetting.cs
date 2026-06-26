// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    public partial class MockableSecurityCenterSubscriptionResource
    {
        /// <summary> Gets a collection of ingestion settings. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual IngestionSettingCollection GetIngestionSettings() { throw new System.NotSupportedException("This API is no longer supported by the service. No direct replacement is available."); }
    }
}
