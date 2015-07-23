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
    /// MetricFilterDimensionFilter class represents a dimension filter tied to a particular metric (by name) and containing an optional list of dimensions
    /// </summary>
    public class MetricDimension
    {
        private string name;
        private IEnumerable<MetricFilterDimension> dimensions;

        /// <summary>
        /// Gets or sets the Name of the dimension
        /// </summary>
        public string Name
        {
            get
            {
                if (this.name == null)
                {
                    throw new InvalidOperationException("(metric) Name is not set");
                }

                return this.name;
            }

            set
            {
                if (this.name != null)
                {
                    throw new InvalidOperationException("Name is already set");
                }

                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidOperationException("Name must not be null or empty");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets the Values of the dimension
        /// </summary>
        public IEnumerable<MetricFilterDimension> Dimensions
        {
            get
            {
                return this.dimensions;
            }

            set
            {
                if (this.dimensions != null)
                {
                    throw new InvalidOperationException("Values (collection) is already set");
                }

                if (!(value == null || value.Any()))
                {
                    throw new InvalidOperationException("Values (collection) must be null or non-empty");
                }

                this.dimensions = value;
            }
        }
    }
}
