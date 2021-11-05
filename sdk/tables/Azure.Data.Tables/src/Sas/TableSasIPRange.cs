// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Net;

namespace Azure.Data.Tables.Sas
{
    /// <summary>
    /// Represents a range of allowed IP addresses for constructing a Shared
    /// Access Signature.
    /// </summary>
    public readonly struct TableSasIPRange : IEquatable<TableSasIPRange>
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
        /// Creates a new <see cref="TableSasIPRange"/>.
        /// </summary>
        /// <param name="start">
        /// The range's start <see cref="IPAddress"/>.
        /// </param>
        /// <param name="end">
        /// The range's optional end <see cref="IPAddress"/>.
        /// </param>
        public TableSasIPRange(IPAddress start, IPAddress end = null)
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
        /// Creates a string representation of an <see cref="TableSasIPRange"/>.
        /// </summary>
        /// <returns>
        /// A string representation of an <see cref="TableSasIPRange"/>.
        /// </returns>
        public override string ToString() =>
            IsEmpty(Start) ? string.Empty :
            IsEmpty(End) ? Start.ToString() :
            Start.ToString() + "-" + End.ToString();

        /// <summary>
        /// Parse an IP range string into a new <see cref="TableSasIPRange"/>.
        /// </summary>
        /// <param name="s">IP range string to parse.</param>
        /// <returns>The parsed <see cref="TableSasIPRange"/>.</returns>
        public static TableSasIPRange Parse(string s)
        {
            var dashIndex = s.IndexOf('-');
            return dashIndex == -1 ?
                new TableSasIPRange(IPAddress.Parse(s)) :
                new TableSasIPRange(
                    IPAddress.Parse(s.Substring(0, dashIndex)),
                    IPAddress.Parse(s.Substring(dashIndex + 1)));
        }

        /// <summary>
        /// Check if two <see cref="TableSasIPRange"/> instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) =>
            obj is TableSasIPRange other && Equals(other);

        /// <summary>
        /// Get a hash code for the <see cref="TableSasIPRange"/>.
        /// </summary>
        /// <returns>Hash code for the <see cref="TableSasIPRange"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            (Start?.GetHashCode() ?? 0) ^ (End?.GetHashCode() ?? 0);

        /// <summary>
        /// Check if two <see cref="TableSasIPRange"/> instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(TableSasIPRange left, TableSasIPRange right) =>
            left.Equals(right);

        /// <summary>
        /// Check if two <see cref="TableSasIPRange"/> instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(TableSasIPRange left, TableSasIPRange right) =>
            !(left == right);

        /// <summary>
        /// Check if two <see cref="TableSasIPRange"/> instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(TableSasIPRange other) =>
            ((IsEmpty(Start) && IsEmpty(other.Start)) ||
             (Start != null && Start.Equals(other.Start))) &&
            ((IsEmpty(End) && IsEmpty(other.End)) ||
             (End != null && End.Equals(other.End)));
    }
}
