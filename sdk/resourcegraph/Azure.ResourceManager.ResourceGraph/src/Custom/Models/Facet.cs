// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ResourceGraph.Models
{
    // Backward compatibility: GA SDK exposed a protected ctor(string expression) on Facet.
    public abstract partial class Facet
    {
        /// <summary> Initializes a new instance of <see cref="Facet"/>. </summary>
        /// <param name="expression"> Facet expression, same as in the corresponding facet request. </param>
        protected Facet(string expression) : this(expression, null)
        {
        }
    }
}
