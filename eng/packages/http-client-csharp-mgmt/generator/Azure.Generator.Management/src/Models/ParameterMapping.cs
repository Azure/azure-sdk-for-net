// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.Generator.Management.Models
{
    /// <summary>
    /// Represents a mapping from operation path parameters to contextual parameters.
    /// This mapping is used to determine which parameters from an operation's request path
    /// can be resolved from the contextual path (e.g., from a resource's Id property).
    /// </summary>
    internal class ParameterMapping
    {
        private readonly Dictionary<string, ContextualParameter> _mapping;

        public ParameterMapping(Dictionary<string, ContextualParameter> mapping)
        {
            _mapping = mapping;
        }

        /// <summary>
        /// Try to get the contextual parameter for a given operation parameter name.
        /// </summary>
        /// <param name="operationParameterName">The name of the parameter in the operation's request path.</param>
        /// <param name="contextualParameter">The corresponding contextual parameter if found.</param>
        /// <returns>True if a mapping exists, false otherwise.</returns>
        public bool TryGetContextualParameter(string operationParameterName, [MaybeNullWhen(false)] out ContextualParameter contextualParameter)
        {
            return _mapping.TryGetValue(operationParameterName, out contextualParameter);
        }
    }
}
