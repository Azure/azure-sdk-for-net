// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary>
    /// Represents an Azure geography region where supported resource providers live.
    /// </summary>
    public partial class Location
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        protected Location()
        {
        }

        /// <summary> Initializes a new instance of Location. </summary>
        /// <param name="name"> The location name. </param>
        /// <param name="displayName"> The display name of the location. </param>
        /// <param name="regionalDisplayName"> The display name of the location and its region. </param>
        /// <param name="canonicalName"> The canonical name of the location. </param>
        internal Location(string name, string displayName, string regionalDisplayName, string canonicalName)
        {
            Name = name;
            DisplayName = displayName;
            RegionalDisplayName = regionalDisplayName;
            CanonicalName = canonicalName;
        }

        /// <summary>
        /// Gets a location canonical name consisting of only lowercase chararters with a '-' between words, e.g. "west-us".
        /// </summary>
        public string CanonicalName { get; private set; }

        /// <summary> The display name of the location and its region. </summary>
        public string RegionalDisplayName { get; private set; }

        /// <summary>
        /// Gets a location name consisting of only lowercase characters without white spaces or any separation character between words, e.g. "westus".
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets a location display name consisting of titlecase words or alphanumeric characters separated by whitespaces, e.g. "West US"
        /// </summary>
        public string DisplayName { get; private set; }
    }
}
