// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Net;

namespace Azure.Storage.Common
{
    /// <summary>
    /// Represents a SAS IP range's start IP and (optionally) end IP.
    /// </summary>
    public struct IPRange : IEquatable<IPRange>
    {
        /// <summary>
        /// Not specified if equal to IPAddress.None
        /// </summary>
        public IPAddress Start { get; set; }

        /// <summary>
        /// Not specified if equal to IPAddress.None
        /// </summary>
        public IPAddress End { get; set; }

        /// <summary>
        /// String returns a string representation of an IPRange.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var start = this.Start ?? IPAddress.None;
            var end = this.End ?? IPAddress.None;

            return
                start == IPAddress.None
                ? String.Empty
                : end == IPAddress.None
                ? start.ToString()
                : start.ToString() + "-" + end.ToString();
        }
        public static IPRange Parse(string s)
        {
            var dashIndex = s.IndexOf('-');
            return dashIndex == -1
                ? new IPRange { Start = IPAddress.Parse(s) }
                : new IPRange
                {
                    Start = IPAddress.Parse(s.Substring(0, dashIndex)) ?? IPAddress.None,
                    End = IPAddress.Parse(s.Substring(dashIndex + 1)) ?? IPAddress.None
                };
        }

        public override bool Equals(object obj)
            => obj is IPRange other
            && this.Equals(other)
            ;

        public override int GetHashCode()
            => this.Start.GetHashCode() ^ this.End.GetHashCode();

        public static bool operator ==(IPRange left, IPRange right) => left.Equals(right);

        public static bool operator !=(IPRange left, IPRange right) => !(left == right);

        public bool Equals(IPRange other)
            => ((this.Start == null && other.Start == null)
                || this.Start.Equals(other.Start))
            && ((this.End == null && other.End == null)
                || this.End.Equals(other.End));
    }
}
