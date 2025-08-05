// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Azure.ResourceManager.EdgeOrder.Models
{
    public partial class ConfigurationsContent
    {
        /// <summary> Initializes a new instance of <see cref="ConfigurationsContent"/>. </summary>
        /// <param name="configurationFilters"> Holds details about product hierarchy information and filterable property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="configurationFilters"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ConfigurationsContent(IEnumerable<ConfigurationFilters> configurationFilters)
        {
            Argument.AssertNotNull(configurationFilters, nameof(configurationFilters));

            ConfigurationFilters = configurationFilters.ToList();
            ConfigurationFilter = configurationFilters.FirstOrDefault();
        }

        /// <summary> Holds details about product hierarchy information and filterable property. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ConfigurationFilters> ConfigurationFilters { get; }
    }
}
