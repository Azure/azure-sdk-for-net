//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Insights.Models;

namespace Microsoft.Azure.Insights
{
    public partial interface IMetricOperations
    {
        /// <summary>
        /// Get Metrics function that takes in the MetricDefinitions (rather than names in the filter string) to allow users to cache the definitions themselves
        /// </summary>
        /// <param name="resourceUri">The Resource Uri for the metrics</param>
        /// <param name="filterString">The filter string (no name specification allowed in this one)</param>
        /// <param name="definitions">The MetricDefinitions</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task<MetricListResponse> GetMetricsAsync(string resourceUri, string filterString, IEnumerable<MetricDefinition> definitions, CancellationToken cancellationToken);
    }
}
