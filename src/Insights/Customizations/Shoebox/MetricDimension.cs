//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Insights
{
    /// <summary>
    /// MetricFilterDimensionFilter class represents a dimension filter tied to a particular metric (by name) and containing an optional list of dimensions
    /// </summary>
    public class MetricDimension
    {
        private string name;
        private IEnumerable<Dimension> dimensions;

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
        public IEnumerable<Dimension> Dimensions
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
