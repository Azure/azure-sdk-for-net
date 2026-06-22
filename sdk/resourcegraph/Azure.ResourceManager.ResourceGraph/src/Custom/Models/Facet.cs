// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ResourceGraph.Models
{
    // GA SDK (1.1.0) exposed a protected ctor Facet(string expression).
    // The new TypeSpec-based generator only produces a two-parameter ctor Facet(string, string).
    // This single-parameter overload is retained so that existing derived classes compiled against
    // the GA package continue to work without recompilation.
    public abstract partial class Facet
    {
        /// <summary> Initializes a new instance of <see cref="Facet"/>. </summary>
        /// <param name="expression"> Facet expression, same as in the corresponding facet request. </param>
        protected Facet(string expression) : this(expression, null)
        {
        }
    }
}
