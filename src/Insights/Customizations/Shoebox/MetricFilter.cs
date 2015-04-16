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
using System.Linq;

namespace Microsoft.Azure.Insights
{
    /// <summary>
    /// The stucture of the Filter represents an expression in disjunctive-normal-form
    /// Each filter contain a set of subfilters (the conjunctions) with the total filter being the disjunction of them
    /// </summary>
    public class MetricFilter
    {
        private TimeSpan? timeGrain;
        private DateTime? startTime;
        private DateTime? endTime;
        private IEnumerable<MetricDimension> dimensionFilters;

        /// <summary>
        /// Gets or sets the TimeGrain of the filter
        /// </summary>
        public TimeSpan TimeGrain
        {
            get
            {
                if (this.timeGrain == null)
                {
                    throw new InvalidOperationException("TimeGrain is not set");
                }

                return this.timeGrain ?? default(TimeSpan);
            }

            set
            {
                if (this.timeGrain != null)
                {
                    throw new InvalidOperationException("TimeGrain is already set");
                }

                if (value < TimeSpan.Zero)
                {
                    throw new InvalidOperationException("TimeGrain must be a positive duration");
                }

                this.timeGrain = value;
            }
        }

        /// <summary>
        /// Gets or sets the TimeGrain of the filter
        /// </summary>
        public DateTime StartTime
        {
            get
            {
                if (this.startTime == null)
                {
                    throw new InvalidOperationException("StartTime is not set");
                }

                return this.startTime ?? default(DateTime);
            }

            set
            {
                if (this.startTime != null)
                {
                    throw new InvalidOperationException("StartTime is already set");
                }

                if (this.endTime != null && value > this.endTime)
                {
                    throw new InvalidOperationException("StartTime must come before EndTime");
                }

                this.startTime = value;
            }
        }

        /// <summary>
        /// Gets or sets the TimeGrain of the filter
        /// </summary>
        public DateTime EndTime
        {
            get
            {
                if (this.endTime == null)
                {
                    throw new InvalidOperationException("EndTime is not set");
                }

                return this.endTime ?? default(DateTime);
            }

            set
            {
                if (this.endTime != null)
                {
                    throw new InvalidOperationException("EndTime is already set");
                }

                if (this.startTime != null && value < this.startTime)
                {
                    throw new InvalidOperationException("EndTime must come after StartTime");
                }

                this.endTime = value;
            }
        }

        /// <summary>
        /// Gets or sets the DimensionFilters of the filter
        /// </summary>
        public IEnumerable<MetricDimension> DimensionFilters
        {
            get
            {
                return this.dimensionFilters;
            }

            set
            {
                if (this.dimensionFilters != null)
                {
                    throw new InvalidOperationException("Names is already set");
                }

                if (!(value == null || value.Any()))
                {
                    throw new InvalidOperationException("Names must be null or non-empty");
                }

                this.dimensionFilters = value;
            }
        }
    }
}
