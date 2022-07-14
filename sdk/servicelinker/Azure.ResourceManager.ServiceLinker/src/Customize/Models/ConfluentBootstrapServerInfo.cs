// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.ServiceLinker.Models
{
    /// <summary> The service properties when target service type is ConfluentBootstrapServer. </summary>
    [CodeGenSuppress("ConfluentBootstrapServerInfo", typeof(TargetServiceType), typeof(string))]
    public partial class ConfluentBootstrapServerInfo : TargetServiceBaseInfo
    {
        /// <summary> Initializes a new instance of ConfluentBootstrapServerInfo. </summary>
        /// <param name="targetServiceType"> The target service type. </param>
        /// <param name="endpoint"> The endpoint of service. </param>
        internal ConfluentBootstrapServerInfo(TargetServiceType targetServiceType, string endpoint)
        {
            Endpoint = endpoint;
            TargetServiceType = targetServiceType;
        }
    }
}
