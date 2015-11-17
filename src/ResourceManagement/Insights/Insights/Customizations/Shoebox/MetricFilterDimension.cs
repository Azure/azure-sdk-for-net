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
using System.Globalization;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Insights
{
    /// <summary>
    /// MetricFilterDimension class represents a dimension name and corresponding (optional) dimension values
    /// </summary>
    public class MetricFilterDimension
    {
        private string name;
        private IEnumerable<string> values;

        /// <summary>
        /// Gets or sets the Name of the dimension
        /// </summary>
        public string Name
        {
            get
            {
                if (this.name == null)
                {
                    throw new InvalidOperationException("(dimension) Name is not set");
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
        public IEnumerable<string> Values
        {
            get
            {
                return this.values;
            }

            set
            {
                if (this.values != null)
                {
                    throw new InvalidOperationException("Values (collection) is already set");
                }

                if (!(value == null || value.Any()))
                {
                    throw new InvalidOperationException("Values (collection) must be null or non-empty");
                }

                this.values = value;
            }
        }
    }
}
