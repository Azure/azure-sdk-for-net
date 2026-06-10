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
    public readonly partial struct SecurityControlType : System.IEquatable<SecurityControlType>
    {
        public SecurityControlType(string value) { _value = value ?? throw new ArgumentNullException(nameof(value)); }
        public static SecurityControlType BuiltIn => new SecurityControlType("BuiltIn");
        public static SecurityControlType Custom => new SecurityControlType("Custom");
        public bool Equals(SecurityControlType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is SecurityControlType other && Equals(other);
        public override int GetHashCode() => _value is null ? 0 : StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value);
        public static bool operator ==(SecurityControlType left, SecurityControlType right) => left.Equals(right);
        public static implicit operator SecurityControlType(string value) => new SecurityControlType(value);
        public static bool operator !=(SecurityControlType left, SecurityControlType right) => !left.Equals(right);
        public override string ToString() => _value;
    }
}
