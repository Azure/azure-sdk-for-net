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
        public Location(string name, string displayName)
        {
            Name = name;
            DisplayName = displayName;
        }

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
