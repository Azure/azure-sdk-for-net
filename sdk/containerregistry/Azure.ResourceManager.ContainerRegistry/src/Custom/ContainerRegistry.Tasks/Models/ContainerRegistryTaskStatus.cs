// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    /// <summary> The current status of task. </summary>
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct ContainerRegistryTaskStatus : IEquatable<ContainerRegistryTaskStatus>
    {
        private readonly string _value;
        /// <summary> Converts a string to a <see cref="ContainerRegistryTaskStatus"/>. </summary>
        /// <param name="value"> The value. </param>
        public ContainerRegistryTaskStatus(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        public static ContainerRegistryTaskStatus Disabled { get; } = new ContainerRegistryTaskStatus("Disabled");
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        public static ContainerRegistryTaskStatus Enabled { get; } = new ContainerRegistryTaskStatus("Enabled");
        /// <summary> Determines whether two values are equal. </summary>
        public static bool operator ==(ContainerRegistryTaskStatus left, ContainerRegistryTaskStatus right) => left.Equals(right);
        /// <summary> Determines whether two values are not equal. </summary>
        public static bool operator !=(ContainerRegistryTaskStatus left, ContainerRegistryTaskStatus right) => !left.Equals(right);
        /// <summary> Converts a string value to the corresponding strongly typed value. </summary>
        public static implicit operator ContainerRegistryTaskStatus(string value) => new ContainerRegistryTaskStatus(value);
        /// <summary> Determines whether the specified value is equal to the current value. </summary>
        public override bool Equals(object obj) => obj is ContainerRegistryTaskStatus other && Equals(other);
        /// <summary> Determines whether the specified value is equal to the current value. </summary>
        public bool Equals(ContainerRegistryTaskStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <summary> Returns the hash code for this value. </summary>
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <summary> Returns the string representation of this value. </summary>
        public override string ToString() => _value;
    }
}
