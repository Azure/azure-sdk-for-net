// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: restore protected constructor on output-only type.

using System.Collections.Generic;

namespace Azure.ResourceManager.Kusto.Models
{
    public partial class EndpointDependency
    {
        /// <summary> Initializes a new instance of <see cref="EndpointDependency"/>. </summary>
        protected EndpointDependency(string domainName, IList<EndpointDetail> endpointDetails)
        {
            DomainName = domainName;
            EndpointDetails = endpointDetails ?? new List<EndpointDetail>();
        }
    }
}
