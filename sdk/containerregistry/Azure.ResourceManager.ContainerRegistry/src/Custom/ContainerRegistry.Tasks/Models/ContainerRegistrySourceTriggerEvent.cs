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
    /// <summary> The event type that can trigger a source-based run. </summary>
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct ContainerRegistrySourceTriggerEvent : IEquatable<ContainerRegistrySourceTriggerEvent>
    {
        private readonly string _value;
        /// <summary> Initializes a new instance of this compatibility shim type. </summary>
        public ContainerRegistrySourceTriggerEvent(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        public static ContainerRegistrySourceTriggerEvent Commit { get; } = new ContainerRegistrySourceTriggerEvent("commit");
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        public static ContainerRegistrySourceTriggerEvent PullRequest { get; } = new ContainerRegistrySourceTriggerEvent("pullrequest");
        /// <summary> Determines whether two values are equal. </summary>
        public static bool operator ==(ContainerRegistrySourceTriggerEvent left, ContainerRegistrySourceTriggerEvent right) => left.Equals(right);
        /// <summary> Determines whether two values are not equal. </summary>
        public static bool operator !=(ContainerRegistrySourceTriggerEvent left, ContainerRegistrySourceTriggerEvent right) => !left.Equals(right);
        /// <summary> Converts a string value to the corresponding strongly typed value. </summary>
        public static implicit operator ContainerRegistrySourceTriggerEvent(string value) => new ContainerRegistrySourceTriggerEvent(value);
        /// <summary> Determines whether the specified value is equal to the current value. </summary>
        public override bool Equals(object obj) => obj is ContainerRegistrySourceTriggerEvent other && Equals(other);
        /// <summary> Determines whether the specified value is equal to the current value. </summary>
        public bool Equals(ContainerRegistrySourceTriggerEvent other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <summary> Returns the hash code for this value. </summary>
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <summary> Returns the string representation of this value. </summary>
        public override string ToString() => _value;
    }
}
