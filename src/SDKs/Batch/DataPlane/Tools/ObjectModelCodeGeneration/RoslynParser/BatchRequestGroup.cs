// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace ProxyLayerParser
{
    using System.Collections.Generic;

    public class BatchRequestGroup
    {
        /// <summary>
        /// Gets the name of the operation group which the collection of <see cref="BatchRequests"/> belong to.  For example "Accounts" or "Pools".
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the collection of BatchRequests in this group.
        /// </summary>
        public IEnumerable<BatchRequestTypeGenerationInfo> BatchRequests { get; }

        public BatchRequestGroup(string name, IEnumerable<BatchRequestTypeGenerationInfo> batchRequests)
        {
            this.Name = name;
            this.BatchRequests = batchRequests;
        }

    }
}
