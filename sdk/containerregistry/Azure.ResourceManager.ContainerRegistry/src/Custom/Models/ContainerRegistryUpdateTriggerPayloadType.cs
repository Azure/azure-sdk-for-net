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
    // ContainerRegistryTriggerStatus is now fully generated from the spec (via @@clientName on TriggerStatus).
    // No additional partial declaration is needed.

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct ContainerRegistryUpdateTriggerPayloadType : IEquatable<ContainerRegistryUpdateTriggerPayloadType>
    {
        private readonly string _value;
        public ContainerRegistryUpdateTriggerPayloadType(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        public static ContainerRegistryUpdateTriggerPayloadType Default { get; } = new ContainerRegistryUpdateTriggerPayloadType("Default");
        public static ContainerRegistryUpdateTriggerPayloadType Token { get; } = new ContainerRegistryUpdateTriggerPayloadType("Token");
        public static bool operator ==(ContainerRegistryUpdateTriggerPayloadType left, ContainerRegistryUpdateTriggerPayloadType right) => left.Equals(right);
        public static bool operator !=(ContainerRegistryUpdateTriggerPayloadType left, ContainerRegistryUpdateTriggerPayloadType right) => !left.Equals(right);
        public static implicit operator ContainerRegistryUpdateTriggerPayloadType(string value) => new ContainerRegistryUpdateTriggerPayloadType(value);
        public override bool Equals(object obj) => obj is ContainerRegistryUpdateTriggerPayloadType other && Equals(other);
        public bool Equals(ContainerRegistryUpdateTriggerPayloadType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }
}
