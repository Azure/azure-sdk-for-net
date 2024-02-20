// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning
{
    /// <summary>
    /// Represents an output of an <see cref="IConstruct"/>.
    /// </summary>
#pragma warning disable AZC0012 // Avoid single word type names
    public class Output
#pragma warning restore AZC0012 // Avoid single word type names
    {
        /// <summary>
        /// Gets the name of the output.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Gets the value of the output.
        /// </summary>
        public string Value { get; }
        /// <summary>
        /// Gets a value indicating whether the output is a literal value.
        /// </summary>
        public bool IsLiteral { get; }
        /// <summary>
        /// Gets a value indicating whether the output is secure.
        /// </summary>
        public bool IsSecure { get; }
        internal IConstruct Source { get; }

        internal Resource Resource { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Output"/>.
        /// </summary>
        /// <param name="name">The output name.</param>
        /// <param name="value">The output value.</param>
        /// <param name="source">The output source.</param>
        /// <param name="isLiteral">Is the output a literal value.</param>
        /// <param name="isSecure">Is the output secure.</param>
        /// <param name="resource"></param>
        internal Output(string name, string value, IConstruct source, Resource resource, bool isLiteral = false, bool isSecure = false)
        {
            Name = name;
            Value = value;
            IsLiteral = isLiteral;
            IsSecure = isSecure;
            Source = source;
            Resource = resource;
        }
    }
}
