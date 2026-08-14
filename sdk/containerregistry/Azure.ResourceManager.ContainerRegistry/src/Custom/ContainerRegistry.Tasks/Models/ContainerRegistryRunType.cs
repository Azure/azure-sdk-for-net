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
    /// <summary> The type of run. </summary>
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct ContainerRegistryRunType : IEquatable<ContainerRegistryRunType>
    {
        private readonly string _value;
        /// <summary> Initializes a new instance of this compatibility shim type. </summary>
        public ContainerRegistryRunType(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        public static ContainerRegistryRunType AutoBuild { get; } = new ContainerRegistryRunType("AutoBuild");
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        public static ContainerRegistryRunType AutoRun { get; } = new ContainerRegistryRunType("AutoRun");
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        public static ContainerRegistryRunType QuickBuild { get; } = new ContainerRegistryRunType("QuickBuild");
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        public static ContainerRegistryRunType QuickRun { get; } = new ContainerRegistryRunType("QuickRun");
        /// <summary> Determines whether two values are equal. </summary>
        public static bool operator ==(ContainerRegistryRunType left, ContainerRegistryRunType right) => left.Equals(right);
        /// <summary> Determines whether two values are not equal. </summary>
        public static bool operator !=(ContainerRegistryRunType left, ContainerRegistryRunType right) => !left.Equals(right);
        /// <summary> Converts a string value to the corresponding strongly typed value. </summary>
        public static implicit operator ContainerRegistryRunType(string value) => new ContainerRegistryRunType(value);
        /// <summary> Determines whether the specified value is equal to the current value. </summary>
        public override bool Equals(object obj) => obj is ContainerRegistryRunType other && Equals(other);
        /// <summary> Determines whether the specified value is equal to the current value. </summary>
        public bool Equals(ContainerRegistryRunType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <summary> Returns the hash code for this value. </summary>
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <summary> Returns the string representation of this value. </summary>
        public override string ToString() => _value;
    }
}
