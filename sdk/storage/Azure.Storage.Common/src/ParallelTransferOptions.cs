// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Storage.Common
{
    // TODO: Make this public
    internal struct ParallelTransferOptions : IEquatable<ParallelTransferOptions>
    {
        public int? MaximumBlockLength { get; set; }
        public int? MaximumThreadCount { get; set; }

        public override bool Equals(object obj)
            => obj is ParallelTransferOptions other
            && this.Equals(other)
            ;

        public override int GetHashCode()
            => this.MaximumBlockLength.GetHashCode()
            ^ this.MaximumThreadCount.GetHashCode()
            ;

        public static bool operator ==(ParallelTransferOptions left, ParallelTransferOptions right) => left.Equals(right);

        public static bool operator !=(ParallelTransferOptions left, ParallelTransferOptions right) => !(left == right);

        public bool Equals(ParallelTransferOptions other)
            => this.MaximumBlockLength == other.MaximumBlockLength
            && this.MaximumThreadCount == other.MaximumThreadCount
            ;
    }
}
