// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Data.AppConfiguration
{
    /// <summary>
    /// <see cref="FeatureFlagLabelSelector"/> is a set of options that allows selecting a filtered set of feature flag
    /// <see cref="SettingLabel"/> entities.
    /// </summary>
    public class FeatureFlagLabelSelector
    {
        /// <summary>
        /// Initializes a new instance of <see cref="FeatureFlagLabelSelector"/>.
        /// </summary>
        public FeatureFlagLabelSelector()
        {
            Fields = new List<SettingLabelFields>();
        }

        /// <summary>
        /// A filter for the name of the returned labels.
        /// </summary>
        public string NameFilter { get; set; }

        /// <summary>
        /// A list of fields used to specify which fields are included in the returned resource(s).
        /// </summary>
        public IList<SettingLabelFields> Fields { get; }

        /// <summary>
        /// Indicates the point in time in the revision history of the selected <see cref="SettingLabel"/> entities to retrieve.
        /// If set, all properties of the <see cref="SettingLabel"/> entities in the returned group will be exactly what they
        /// were at this time.
        /// </summary>
        public DateTimeOffset? AcceptDateTime { get; set; }
    }
}
