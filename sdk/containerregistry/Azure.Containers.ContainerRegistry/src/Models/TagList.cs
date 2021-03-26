// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Containers.ContainerRegistry
{
    internal partial class TagList
    {
        /// <summary> List of tag attribute details. </summary>
        public IReadOnlyList<TagProperties> Tags { get; }
    }
}
