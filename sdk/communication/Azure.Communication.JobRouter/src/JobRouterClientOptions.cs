// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("AzureCommunicationJobRouterClientOptions")]
    public partial class JobRouterClientOptions
    {
        /// <summary>
        /// The latest version of the Router service.
        /// </summary>
        private const ServiceVersion LatestVersion = ServiceVersion.V2023_11_01;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobRouterClientOptions"/>.
        /// </summary>
        public JobRouterClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2023_11_01 => "2023-11-01",
                _ => throw new ArgumentOutOfRangeException(nameof(version)),
            };
        }
    }
}
