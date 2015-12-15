// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using System.Globalization;
    using Microsoft.Spatial;

    /// <summary>
    /// Represents a parameter value to be used in scoring functions (for example, referencePointParameter).
    /// </summary>
    public class ScoringParameter
    {
        /// <summary>
        /// Initializes a new instance of the ScoringParameter class with the given name and string value.
        /// </summary>
        /// <param name="name">Name of the scoring parameter.</param>
        /// <param name="value">Value of the scoring parameter.</param>
        public ScoringParameter(string name, string value)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            Name = name;
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the ScoringParameter class with the given name and GeographyPoint value.
        /// </summary>
        /// <param name="name">Name of the scoring parameter.</param>
        /// <param name="value">Value of the scoring parameter.</param>
        public ScoringParameter(string name, GeographyPoint value) : this(name, ToLonLatString(value)) { }

        /// <summary>
        /// Gets the name of the scoring parameter.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the value of the scoring parameter.
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Returns the scoring parameter in a format that can be used in a Search API request.
        /// </summary>
        /// <returns>
        /// The scoring parameter as a colon-separated name-value pair (for example, mylocation:-122.2,44.8)
        /// </returns>
        public override string ToString()
        {
            return String.Format(CultureInfo.InvariantCulture, "{0}:{1}", this.Name, this.Value);
        }

        private static string ToLonLatString(GeographyPoint point)
        {
            if (point == null)
            {
                return null;
            }

            return String.Format(CultureInfo.InvariantCulture, "{0},{1}", point.Longitude, point.Latitude);
        }
    }
}
