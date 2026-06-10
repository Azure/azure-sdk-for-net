// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: restore protected constructor on output-only type.

namespace Azure.ResourceManager.Kusto.Models
{
    public partial class EndpointDetail
    {
        /// <summary> Initializes a new instance of <see cref="EndpointDetail"/>. </summary>
        protected EndpointDetail(int? port)
        {
            Port = port;
        }
    }
}
