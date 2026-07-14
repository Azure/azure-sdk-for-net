// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.AppConfiguration
{
    public partial class FeatureFlag
    {
        /// <summary>
        /// The name that uniquely identifies the feature flag.
        /// A <see cref="Name"/> is used together with a <see cref="Label"/> to uniquely identify a feature flag.
        /// </summary>
        [CodeGenMember("Name")]
        public string Name { get; set; }

        /// <summary>
        /// A label used to group this feature flag with others.
        /// A <see cref="Label"/> is used together with a <see cref="Name"/> to uniquely identify a feature flag.
        /// </summary>
        [CodeGenMember("Label")]
        public string Label { get; set; }
    }
}
