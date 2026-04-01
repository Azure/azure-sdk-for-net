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
    public readonly partial struct ContainerRegistrySourceTriggerEvent : IEquatable<ContainerRegistrySourceTriggerEvent>
    {
        private readonly string _value;
        public ContainerRegistrySourceTriggerEvent(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        public static ContainerRegistrySourceTriggerEvent Commit { get; } = new ContainerRegistrySourceTriggerEvent("commit");
        public static ContainerRegistrySourceTriggerEvent PullRequest { get; } = new ContainerRegistrySourceTriggerEvent("pullrequest");
        public static bool operator ==(ContainerRegistrySourceTriggerEvent left, ContainerRegistrySourceTriggerEvent right) => left.Equals(right);
        public static bool operator !=(ContainerRegistrySourceTriggerEvent left, ContainerRegistrySourceTriggerEvent right) => !left.Equals(right);
        public static implicit operator ContainerRegistrySourceTriggerEvent(string value) => new ContainerRegistrySourceTriggerEvent(value);
        public override bool Equals(object obj) => obj is ContainerRegistrySourceTriggerEvent other && Equals(other);
        public bool Equals(ContainerRegistrySourceTriggerEvent other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }
}
