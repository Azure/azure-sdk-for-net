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

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Insights.Models;

namespace Microsoft.Azure.Insights
{
    public static partial class MetricOperationsExtensions
    {

        /// <summary>
        /// Non-async version returns the MetricListResponse straight (consistent with overload for get metrics by name functions)
        /// </summary>
        /// <param name="operations">Reference to IMetricOperations</param>
        /// <param name="resourceUri">Resource Uri for the metrics</param>
        /// <param name="filterString">OData filter string (no name specifitations allowed in this one)</param>
        /// <param name="definitions">The MetricDefinitions</param>
        /// <returns>The requested Metrics</returns>
        public static MetricListResponse GetMetrics(this IMetricOperations operations, string resourceUri, string filterString, IEnumerable<MetricDefinition> definitions)
        {
            try
            {
                return operations.GetMetricsAsync(resourceUri, filterString, definitions).Result;
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions.Count > 1)
                {
                    throw;
                }
                else
                {
                    throw ex.InnerException;
                }
            }
        }

        /// <summary>
        /// Overload for get metrics by definitions that does not require cancellation token (consistent with overload for get metrics by name functions)
        /// </summary>
        /// <param name="operations">Reference to IMetricOperations</param>
        /// <param name="resourceUri">Resource Uri for the metrics</param>
        /// <param name="filterString">OData filter string (no name specifitations allowed in this one)</param>
        /// <param name="definitions">The MetricDefinitions</param>
        /// <returns>The requested Metrics</returns>
        public static Task<MetricListResponse> GetMetricsAsync(this IMetricOperations operations, string resourceUri, string filterString, IEnumerable<MetricDefinition> definitions)
        {
            return operations.GetMetricsAsync(resourceUri, filterString, definitions, CancellationToken.None);
        }
    }
}
