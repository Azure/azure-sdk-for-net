// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.ResourceManager.Avs
{
    public partial class AvsHostData
    {
        // Keep the GA property type while the generated model uses a mutable list internally.
        /// <summary> The availability zones. </summary>
        public IReadOnlyList<string> Zones { get; }
    }
}
