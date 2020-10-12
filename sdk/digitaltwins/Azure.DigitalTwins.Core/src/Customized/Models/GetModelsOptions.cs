// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// Optional parameters to use when getting a list of models.
    /// </summary>
    [CodeGenModel("DigitalTwinModelsListOptions")]
    public partial class GetModelsOptions
    {
        // This class declaration changes the name of the generated class and changes the namespace; do not remove.
        // It also adds 2 more options that don't get bundled into DigitalTwinModelsListOptions by the swagger

        /// <summary>
        /// The set of model Ids to have their dependencies retrieved.
        /// </summary>
        public IEnumerable<string> DependenciesFor { get; set; }

        /// <summary>
        /// Whether to include the model definition in the result. If false, only the model metadata will be returned.
        /// </summary>
        public bool IncludeModelDefinition { get; set; } = false;
    }
}
