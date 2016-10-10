// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

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
