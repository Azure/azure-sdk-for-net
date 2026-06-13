// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Azure.ResourceManager.EdgeOrder.Models
{
    // Manually add to maintain its backward compatibility
    // After https://github.com/microsoft/typespec/issues/9403 is resolved,
    // [CodeGenSerialization(nameof(ConfigurationFilters), "configurationFilter")] needs to be added and regenerated
    public partial class ConfigurationsContent
    {
        /// <summary> Initializes a new instance of <see cref="ConfigurationsContent"/>. </summary>
        /// <param name="configurationFilters"> Holds details about product hierarchy information and filterable property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="configurationFilters"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ConfigurationsContent(IEnumerable<ConfigurationFilters> configurationFilters) : this()
        {
            Argument.AssertNotNull(configurationFilters, nameof(configurationFilters));

            ConfigurationFilters = configurationFilters.ToList();
        }

        /// <summary> Holds details about product hierarchy information and filterable property. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ConfigurationFilters> ConfigurationFilters { get; }
    }
}
