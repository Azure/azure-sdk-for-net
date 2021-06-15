// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Net;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// Represents a range of allowed IP addresses for constructing a Shared
    /// Access Signature.
    /// </summary>
    public readonly struct SasIPRange : IEquatable<SasIPRange>
    {
        /// <summary>
        /// Gets the start of the IP range.  Not specified if equal to null or
        /// <see cref="IPAddress.None"/>.
        /// </summary>
        public IPAddress Start { get; }

        /// <summary>
        /// Gets the optional end of the IP range.  Not specified if equal to
        /// null or <see cref="IPAddress.None"/>.
        /// </summary>
        public IPAddress End { get; }

        /// <summary>
        /// Creates a new <see cref="SasIPRange"/>.
        /// </summary>
        /// <param name="start">
        /// The range's start <see cref="IPAddress"/>.
        /// </param>
        /// <param name="end">
        /// The range's optional end <see cref="IPAddress"/>.
        /// </param>
        public SasIPRange(IPAddress start, IPAddress end = null)
        {
            Start = start ?? IPAddress.None;
            End = end ?? IPAddress.None;
        }

        /// <summary>
        /// Check if an <see cref="IPAddress"/> was not provided.
        /// </summary>
        /// <param name="address">The address to check.</param>
        /// <returns>True if it's empty, false otherwise.</returns>
        private static bool IsEmpty(IPAddress address) =>
            address == null || address == IPAddress.None;

        /// <summary>
        /// Creates a string representation of an <see cref="SasIPRange"/>.
        /// </summary>
        /// <returns>
        /// A string representation of an <see cref="SasIPRange"/>.
        /// </returns>
        public override string ToString() =>
            IsEmpty(Start) ? string.Empty :
            IsEmpty(End) ? Start.ToString() :
            Start.ToString() + "-" + End.ToString();

        /// <summary>
        /// Parse an IP range string into a new <see cref="SasIPRange"/>.
        /// </summary>
        /// <param name="s">IP range string to parse.</param>
        /// <returns>The parsed <see cref="SasIPRange"/>.</returns>
        public static SasIPRange Parse(string s)
        {
            var dashIndex = s.IndexOf('-');
            return dashIndex == -1 ?
                new SasIPRange(IPAddress.Parse(s)) :
                new SasIPRange(
                    IPAddress.Parse(s.Substring(0, dashIndex)),
                    IPAddress.Parse(s.Substring(dashIndex + 1)));
        }

        /// <summary>
        /// Check if two <see cref="SasIPRange"/> instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) =>
            obj is SasIPRange other && Equals(other);

        /// <summary>
        /// Get a hash code for the <see cref="SasIPRange"/>.
        /// </summary>
        /// <returns>Hash code for the <see cref="SasIPRange"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            (Start?.GetHashCode() ?? 0) ^ (End?.GetHashCode() ?? 0);

        /// <summary>
        /// Check if two <see cref="SasIPRange"/> instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(SasIPRange left, SasIPRange right) =>
            left.Equals(right);

        /// <summary>
        /// Check if two <see cref="SasIPRange"/> instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(SasIPRange left, SasIPRange right) =>
            !(left == right);

        /// <summary>
        /// Check if two <see cref="SasIPRange"/> instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(SasIPRange other) =>
            ((IsEmpty(Start) && IsEmpty(other.Start)) ||
             (Start != null && Start.Equals(other.Start))) &&
            ((IsEmpty(End) && IsEmpty(other.End)) ||
             (End != null && End.Equals(other.End)));
    }
}
