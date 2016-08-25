// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
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
        [Obsolete("This property is obsolete. Please use the constructor overload that takes a list of values instead.")]
        public ScoringParameter(string name, string value)
        {
            Throw.IfArgumentNull(name, "name");
            Throw.IfArgumentNull(value, "value");

            Name = name;
            Values = value.Split(',');
        }

        /// <summary>
        /// Initializes a new instance of the ScoringParameter class with the given name and string values.
        /// </summary>
        /// <param name="name">Name of the scoring parameter.</param>
        /// <param name="values">Values of the scoring parameter.</param>
        public ScoringParameter(string name, IEnumerable<string> values)
        {
            Throw.IfArgumentNull(name, "name");
            Throw.IfArgumentNull(values, "values");

            Name = name;
            Values = values.ToList();   // Deep copy.
        }

        /// <summary>
        /// Initializes a new instance of the ScoringParameter class with the given name and GeographyPoint value.
        /// </summary>
        /// <param name="name">Name of the scoring parameter.</param>
        /// <param name="value">Value of the scoring parameter.</param>
        public ScoringParameter(string name, GeographyPoint value) : this(name, ToLonLatStrings(value)) { }

        /// <summary>
        /// Gets the name of the scoring parameter.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the value of the scoring parameter.
        /// </summary>
        [Obsolete("This property is obsolete. Please use the Values property or ToString() method instead.")]
        public string Value
        {
            get
            {
                return this.Values.ToCommaSeparatedString();
            }
        }

        /// <summary>
        /// Gets the values of the scoring parameter.
        /// </summary>
        public IEnumerable<string> Values{ get; private set; }

        /// <summary>
        /// Returns the scoring parameter in a format that can be used in a Search API request.
        /// </summary>
        /// <returns>
        /// The scoring parameter as a colon-separated name-value pair (for example, mylocation:-122.2,44.8)
        /// </returns>
        public override string ToString()
        {
            return String.Format(
                CultureInfo.InvariantCulture, 
                "{0}-{1}", 
                this.Name, 
                this.Values.Select(v => EscapeValue(v)).ToCommaSeparatedString());
        }

        private static string EscapeValue(string value)
        {
            return String.Format(
                CultureInfo.InvariantCulture, 
                "'{0}'", 
                value != null ? value.Replace("'", "''") : null);
        }

        private static IEnumerable<string> ToLonLatStrings(GeographyPoint point)
        {
            if (point == null)
            {
                yield break;
            }

            yield return point.Longitude.ToString(CultureInfo.InvariantCulture);
            yield return point.Latitude.ToString(CultureInfo.InvariantCulture);
        }
    }
}
