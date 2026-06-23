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
        public virtual IngestionSettingCollection GetIngestionSettings()
        {
            return new IngestionSettingCollection(Client, Id);
        }
    }
}
