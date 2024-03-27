// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Provisioning
{
    /// <summary>
    /// Represents a parameter of an <see cref="IConstruct"/>.
    /// </summary>
#pragma warning disable AZC0012 // Avoid single word type names
    public readonly struct Parameter
#pragma warning restore AZC0012 // Avoid single word type names
    {
        /// <summary>
        /// Gets the name of the parameter.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Gets the description of the parameter.
        /// </summary>
        public string? Description { get; }
        /// <summary>
        /// Gets the default value of the parameter.
        /// </summary>
        public object? DefaultValue { get; }
        /// <summary>
        /// Gets a value indicating whether the parameter is secure.
        /// </summary>
        public bool IsSecure { get; }
        /// <summary>
        /// Gets a value indicating whether the parameter is an expression.
        /// </summary>
        internal bool IsExpression { get; }

        internal bool IsFromOutput => Output != null;
        internal bool IsLiteral => Output?.IsLiteral ?? false;
        internal string? Value { get; }
        internal IConstruct? Source { get; }
        internal Output? Output { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="output"></param>
        public Parameter(Output output)
        {
            Name = output.Name;
            IsSecure = output.IsSecure;
            Value = output.Value;
            Source = output.Source;
            Output = output;
        }

        internal Parameter(string name, string? description, object? defaultValue, bool isSecure, IConstruct source, string? value, Output? output)
        {
            Name = name;
            Description = description;
            DefaultValue = defaultValue;
            IsSecure = isSecure;
            Source = source;
            Value = value;
            Output = output;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter"/>.
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="description">The parameter description.</param>
        /// <param name="defaultValue">The parameter defaultValue.</param>
        /// <param name="isSecure">Is the parameter secure.</param>
        public Parameter(string name, string? description = default, object? defaultValue = default, bool isSecure = false)
        {
            Name = name;
            Description = description;
            DefaultValue = defaultValue;
            IsSecure = isSecure;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter"/>.
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="description">The parameter description.</param>
        /// <param name="defaultValue">The parameter defaultValue.</param>
        /// <param name="isSecure">Is the parameter secure.</param>
        /// <param name="isExpression">Is the parameter an expression.</param>
        internal Parameter(string name, string? description, object? defaultValue = default, bool isSecure = false, bool isExpression = false)
        : this (name, description, defaultValue, isSecure)
        {
            IsExpression = isExpression;
        }
        internal string GetParameterString(IConstruct parentScope)
        {
            // If the parameter is not from an output, use the parameter name.
            if (Output == null)
            {
                return Name;
            }

            // If the parameter is from an output that is not in the current scope, use the parameter name.
            if (!parentScope.GetOutputs().Contains(Output))
            {
                return Name;
            }

            // If the parameter is an output from the current scope, use its Value.
            if (ReferenceEquals(Output!.Resource.ModuleScope, parentScope))
            {
                return Value!;
            }

            // Otherwise it is an output from a different scope, use the full reference.
            return $"{Output!.Resource.ModuleScope!.Name}.outputs.{Name}";
        }
    }
}
