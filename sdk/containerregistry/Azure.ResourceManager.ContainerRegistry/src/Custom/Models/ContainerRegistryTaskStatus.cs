// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591, SA1402, SA1508, CS0618

using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct ContainerRegistryTaskStatus : IEquatable<ContainerRegistryTaskStatus>
    {
        private readonly string _value;
        public ContainerRegistryTaskStatus(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        public static ContainerRegistryTaskStatus Disabled { get; } = new ContainerRegistryTaskStatus("Disabled");
        public static ContainerRegistryTaskStatus Enabled { get; } = new ContainerRegistryTaskStatus("Enabled");
        public static bool operator ==(ContainerRegistryTaskStatus left, ContainerRegistryTaskStatus right) => left.Equals(right);
        public static bool operator !=(ContainerRegistryTaskStatus left, ContainerRegistryTaskStatus right) => !left.Equals(right);
        public static implicit operator ContainerRegistryTaskStatus(string value) => new ContainerRegistryTaskStatus(value);
        public override bool Equals(object obj) => obj is ContainerRegistryTaskStatus other && Equals(other);
        public bool Equals(ContainerRegistryTaskStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }
}
