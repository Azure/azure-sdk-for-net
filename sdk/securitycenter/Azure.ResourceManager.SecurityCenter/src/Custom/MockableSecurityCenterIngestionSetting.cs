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
        public virtual IngestionSettingResource GetIngestionSettingResource(ResourceIdentifier id)
        {
            return new IngestionSettingResource(Client, id);
        }
    }
}
