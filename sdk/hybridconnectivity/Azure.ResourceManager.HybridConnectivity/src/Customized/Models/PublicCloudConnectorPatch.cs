// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.HybridConnectivity.Models
{
    /// <summary> Public Cloud Connector. </summary>
    public partial class PublicCloudConnectorPatch
    {
        /// <summary> List of AWS accounts which need to be excluded. </summary>
        /// <remarks>
        /// Retained for compatibility with 1.1.1, where the connector patch carried the AWS
        /// excluded accounts directly. Starting with API version 2027-01-01 the properties can
        /// describe either an AWS or a GCP profile, so they are no longer flattened onto the
        /// patch. Prefer <see cref="Properties"/>; this member forwards to
        /// <see cref="PublicCloudConnectorPropertiesPatch.AwsCloudExcludedAccounts"/> and
        /// materializes <see cref="Properties"/> on first access so that callers written against
        /// 1.1.1 continue to work.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> AwsCloudExcludedAccounts
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new PublicCloudConnectorPropertiesPatch();
                }
                return Properties.AwsCloudExcludedAccounts;
            }
        }
    }
}
