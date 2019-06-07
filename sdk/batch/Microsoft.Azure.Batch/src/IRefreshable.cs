// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
