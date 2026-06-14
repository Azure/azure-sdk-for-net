// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591 // Hidden obsolete compatibility shims do not need public docs.

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityCenter;
using Azure.ResourceManager.SecurityCenter.Mocking;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    public readonly partial struct AutoProvisionState
    {
        public AutoProvisionState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public static AutoProvisionState Off => new AutoProvisionState("Off");
        public static AutoProvisionState On => new AutoProvisionState("On");
        public static implicit operator AutoProvisionState(string value) => new AutoProvisionState(value);
        public bool Equals(AutoProvisionState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is AutoProvisionState other && Equals(other);
        public override int GetHashCode() => _value is null ? 0 : StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value);
        public static bool operator ==(AutoProvisionState left, AutoProvisionState right) => left.Equals(right);
        public static bool operator !=(AutoProvisionState left, AutoProvisionState right) => !left.Equals(right);
        public override string ToString() => _value;
    }
}
