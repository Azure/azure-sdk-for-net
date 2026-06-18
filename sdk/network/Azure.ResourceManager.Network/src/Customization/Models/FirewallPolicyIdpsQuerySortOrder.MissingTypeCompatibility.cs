// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Firewall policy IDPS query sort order. </summary>
    public readonly partial struct FirewallPolicyIdpsQuerySortOrder : IEquatable<FirewallPolicyIdpsQuerySortOrder>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="FirewallPolicyIdpsQuerySortOrder"/>. </summary>
        /// <param name="value"> The value. </param>
        public FirewallPolicyIdpsQuerySortOrder(string value) => _value = value;

        /// <summary> Ascending. </summary>
        public static FirewallPolicyIdpsQuerySortOrder Ascending { get; } = new FirewallPolicyIdpsQuerySortOrder("Ascending");
        /// <summary> Descending. </summary>
        public static FirewallPolicyIdpsQuerySortOrder Descending { get; } = new FirewallPolicyIdpsQuerySortOrder("Descending");

        /// <inheritdoc/>
        public bool Equals(FirewallPolicyIdpsQuerySortOrder other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is FirewallPolicyIdpsQuerySortOrder other && Equals(other);
        /// <inheritdoc/>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <summary> Compares two <see cref="FirewallPolicyIdpsQuerySortOrder"/> values for equality. </summary>
        public static bool operator ==(FirewallPolicyIdpsQuerySortOrder left, FirewallPolicyIdpsQuerySortOrder right) => left.Equals(right);
        /// <summary> Converts a string to a <see cref="FirewallPolicyIdpsQuerySortOrder"/>. </summary>
        public static implicit operator FirewallPolicyIdpsQuerySortOrder(string value) => new FirewallPolicyIdpsQuerySortOrder(value);
        /// <summary> Compares two <see cref="FirewallPolicyIdpsQuerySortOrder"/> values for inequality. </summary>
        public static bool operator !=(FirewallPolicyIdpsQuerySortOrder left, FirewallPolicyIdpsQuerySortOrder right) => !left.Equals(right);
        /// <inheritdoc/>
        public override string ToString() => _value ?? string.Empty;
    }
}
