// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.LoadTesting.Models
{
    public partial class LoadTestingResourcePatch
    {
        /// <summary> Resource tags. </summary>
        public IDictionary<string, string> Tags { get; set; }
    }
}
