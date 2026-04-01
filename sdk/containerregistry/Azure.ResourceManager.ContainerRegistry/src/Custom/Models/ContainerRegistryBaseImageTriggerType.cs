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
    public readonly partial struct ContainerRegistryBaseImageTriggerType : IEquatable<ContainerRegistryBaseImageTriggerType>
    {
        private readonly string _value;
        public ContainerRegistryBaseImageTriggerType(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        public static ContainerRegistryBaseImageTriggerType All { get; } = new ContainerRegistryBaseImageTriggerType("All");
        public static ContainerRegistryBaseImageTriggerType Runtime { get; } = new ContainerRegistryBaseImageTriggerType("Runtime");
        public static bool operator ==(ContainerRegistryBaseImageTriggerType left, ContainerRegistryBaseImageTriggerType right) => left.Equals(right);
        public static bool operator !=(ContainerRegistryBaseImageTriggerType left, ContainerRegistryBaseImageTriggerType right) => !left.Equals(right);
        public static implicit operator ContainerRegistryBaseImageTriggerType(string value) => new ContainerRegistryBaseImageTriggerType(value);
        public override bool Equals(object obj) => obj is ContainerRegistryBaseImageTriggerType other && Equals(other);
        public bool Equals(ContainerRegistryBaseImageTriggerType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }
}
