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
    public readonly partial struct ContainerRegistryCpuVariant : IEquatable<ContainerRegistryCpuVariant>
    {
        private readonly string _value;
        public ContainerRegistryCpuVariant(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        public static ContainerRegistryCpuVariant V6 { get; } = new ContainerRegistryCpuVariant("v6");
        public static ContainerRegistryCpuVariant V7 { get; } = new ContainerRegistryCpuVariant("v7");
        public static ContainerRegistryCpuVariant V8 { get; } = new ContainerRegistryCpuVariant("v8");
        public static bool operator ==(ContainerRegistryCpuVariant left, ContainerRegistryCpuVariant right) => left.Equals(right);
        public static bool operator !=(ContainerRegistryCpuVariant left, ContainerRegistryCpuVariant right) => !left.Equals(right);
        public static implicit operator ContainerRegistryCpuVariant(string value) => new ContainerRegistryCpuVariant(value);
        public override bool Equals(object obj) => obj is ContainerRegistryCpuVariant other && Equals(other);
        public bool Equals(ContainerRegistryCpuVariant other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }
}
