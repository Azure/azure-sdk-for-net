// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.PolicyInsights.Models;

namespace Azure.ResourceManager.PolicyInsights
{
    public partial class PolicyRemediationData : ResourceData
    {
        /// <summary> The resource locations that will be remediated. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<AzureLocation> FilterLocations
        {
            get
            {
                if (Filter is null)
                    Filter = new RemediationFilters();
                return Filter.Locations;
            }
        }
    }
}
