// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.IotOperations.Models
{
    public abstract partial class DataflowGraphNode
    {
        /// <summary> Initializes a new instance of <see cref="DataflowGraphNode"/>. </summary>
        /// <param name="name"> Name of the node. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        protected DataflowGraphNode(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
        }
    }
}
