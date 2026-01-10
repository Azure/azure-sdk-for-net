// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.HybridConnectivity.Models
{
    /// <summary> Public Cloud Connector. </summary>
    public partial class PublicCloudConnectorPatch
    {
        /// <summary> List of AWS accounts which need to be excluded. </summary>
        public IList<string> AwsCloudExcludedAccounts
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new PublicCloudConnectorPropertiesUpdate();
                }
                return Properties.AwsCloudExcludedAccounts;
            }
        }
    }
}
