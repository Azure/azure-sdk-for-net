// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        internal bool IsFromOutput { get; }
        internal bool IsLiteral { get; }
        internal string? Value { get; }
        internal IConstruct? Source { get; }

        internal Parameter(Output output)
        {
            Name = output.Name;
            IsSecure = output.IsSecure;
            IsFromOutput = true;
            IsLiteral = output.IsLiteral;
            Value = output.Value;
            Source = output.Source;
        }

        internal Parameter(string name, string? description, object? defaultValue, bool isSecure, IConstruct source, string? value)
        {
            Name = name;
            Description = description;
            DefaultValue = defaultValue;
            IsSecure = isSecure;
            Source = source;
            Value = value;
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
    }
}
