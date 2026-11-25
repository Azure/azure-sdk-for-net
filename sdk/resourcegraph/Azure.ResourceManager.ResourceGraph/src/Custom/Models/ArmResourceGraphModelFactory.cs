// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Azure.ResourceManager.ResourceGraph.Models
{
    /// <summary> Factory for models in Azure.ResourceManager.ResourceGraph. </summary>
    public static partial class ArmResourceGraphModelFactory
    {
        /// <param name="subscriptions"> Azure subscriptions against which to execute the query. </param>
        /// <param name="query"> The resources query. </param>
        /// <param name="options"> The history request evaluation options. </param>
        /// <param name="managementGroups"> Azure management groups against which to execute the query. </param>
        /// <returns> A new <see cref="Models.ResourcesHistoryRequest"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use ArmResourceGraphModelFactory.ResourcesHistoryContent instead.")]
        public static ResourcesHistoryRequest ResourcesHistoryRequest(IEnumerable<string> subscriptions = default, string query = default, ResourcesHistoryRequestOptions options = default, IEnumerable<string> managementGroups = default)
        {
            subscriptions ??= new ChangeTrackingList<string>();
            managementGroups ??= new ChangeTrackingList<string>();

            return new ResourcesHistoryRequest(subscriptions.ToList(), query, options, managementGroups.ToList(), default);
        }
    }
}
