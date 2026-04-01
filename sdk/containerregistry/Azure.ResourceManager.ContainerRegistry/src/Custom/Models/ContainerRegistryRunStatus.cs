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
    public readonly partial struct ContainerRegistryRunStatus : IEquatable<ContainerRegistryRunStatus>
    {
        private readonly string _value;
        public ContainerRegistryRunStatus(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        public static ContainerRegistryRunStatus Canceled { get; } = new ContainerRegistryRunStatus("Canceled");
        public static ContainerRegistryRunStatus Error { get; } = new ContainerRegistryRunStatus("Error");
        public static ContainerRegistryRunStatus Failed { get; } = new ContainerRegistryRunStatus("Failed");
        public static ContainerRegistryRunStatus Queued { get; } = new ContainerRegistryRunStatus("Queued");
        public static ContainerRegistryRunStatus Running { get; } = new ContainerRegistryRunStatus("Running");
        public static ContainerRegistryRunStatus Started { get; } = new ContainerRegistryRunStatus("Started");
        public static ContainerRegistryRunStatus Succeeded { get; } = new ContainerRegistryRunStatus("Succeeded");
        public static ContainerRegistryRunStatus Timeout { get; } = new ContainerRegistryRunStatus("Timeout");
        public static bool operator ==(ContainerRegistryRunStatus left, ContainerRegistryRunStatus right) => left.Equals(right);
        public static bool operator !=(ContainerRegistryRunStatus left, ContainerRegistryRunStatus right) => !left.Equals(right);
        public static implicit operator ContainerRegistryRunStatus(string value) => new ContainerRegistryRunStatus(value);
        public override bool Equals(object obj) => obj is ContainerRegistryRunStatus other && Equals(other);
        public bool Equals(ContainerRegistryRunStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }
}
