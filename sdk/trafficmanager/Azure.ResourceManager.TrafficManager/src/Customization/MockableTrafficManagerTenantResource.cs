// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.TrafficManager.Mocking
{
    public partial class MockableTrafficManagerTenantResource
    {
        /// <summary> Gets the TrafficManagerGeographicHierarchyResource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual TrafficManagerGeographicHierarchyResource GetTrafficManagerGeographicHierarchy()
        {
            return GetTrafficManagerGeographicHierarchy(default).Value;
        }
    }
}
