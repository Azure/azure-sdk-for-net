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
    /// <summary> The current status of the run. </summary>
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct ContainerRegistryRunStatus : IEquatable<ContainerRegistryRunStatus>
    {
        private readonly string _value;
        /// <summary> Initializes a new instance of this compatibility shim type. </summary>
        public ContainerRegistryRunStatus(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        public static ContainerRegistryRunStatus Canceled { get; } = new ContainerRegistryRunStatus("Canceled");
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        public static ContainerRegistryRunStatus Error { get; } = new ContainerRegistryRunStatus("Error");
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        public static ContainerRegistryRunStatus Failed { get; } = new ContainerRegistryRunStatus("Failed");
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        public static ContainerRegistryRunStatus Queued { get; } = new ContainerRegistryRunStatus("Queued");
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        public static ContainerRegistryRunStatus Running { get; } = new ContainerRegistryRunStatus("Running");
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        public static ContainerRegistryRunStatus Started { get; } = new ContainerRegistryRunStatus("Started");
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        public static ContainerRegistryRunStatus Succeeded { get; } = new ContainerRegistryRunStatus("Succeeded");
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        public static ContainerRegistryRunStatus Timeout { get; } = new ContainerRegistryRunStatus("Timeout");
        /// <summary> Determines whether two values are equal. </summary>
        public static bool operator ==(ContainerRegistryRunStatus left, ContainerRegistryRunStatus right) => left.Equals(right);
        /// <summary> Determines whether two values are not equal. </summary>
        public static bool operator !=(ContainerRegistryRunStatus left, ContainerRegistryRunStatus right) => !left.Equals(right);
        /// <summary> Converts a string value to the corresponding strongly typed value. </summary>
        public static implicit operator ContainerRegistryRunStatus(string value) => new ContainerRegistryRunStatus(value);
        /// <summary> Determines whether the specified value is equal to the current value. </summary>
        public override bool Equals(object obj) => obj is ContainerRegistryRunStatus other && Equals(other);
        /// <summary> Determines whether the specified value is equal to the current value. </summary>
        public bool Equals(ContainerRegistryRunStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <summary> Returns the hash code for this value. </summary>
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <summary> Returns the string representation of this value. </summary>
        public override string ToString() => _value;
    }
}
