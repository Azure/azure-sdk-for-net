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

﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Microsoft.Azure.Batch
{
    /// <summary>
    /// Provides a mechanism for refreshing a resource.
    /// </summary>
    public interface IRefreshable
    {
        /// <summary>
        /// Begins asynchronous call to refresh the current object.
        /// </summary>
        /// <param name="detailLevel">Controls the detail level of the data returned by a call to the Azure Batch Service.  If a detail level which omits the "Name" property is specified, refresh will fail.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        System.Threading.Tasks.Task RefreshAsync(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Blocking call to force a refresh of the current object.
        /// </summary>
        /// <param name="detailLevel">Controls the detail level of the data returned by a call to the Azure Batch Service. If a detail level which omits the "Name" property is specified, refresh will fail.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        void Refresh(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null);
    }
}
