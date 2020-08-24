// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.DigitalTwins.Core
{
    [CodeGenModel("ModelData")]
    public partial class ModelData
    {
        // This class declaration makes the generated class of the same name declare Model as a **string** rather than an **object**.
        // It also changes the namespace.
        // Do not remove.

        /// <summary>
        /// The model definition.
        /// </summary>
        public string Model { get; }

        #region null overrides

#pragma warning disable CA1801 // Remove unused parameter

        private ModelData(string id)
        {
        }

#pragma warning restore CA1801 // Remove unused parameter

        #endregion null overrides
    }
}
