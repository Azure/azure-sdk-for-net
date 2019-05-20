// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Storage.Blobs
{
    partial class Errors
    {
        public static ArgumentOutOfRangeException IfUnmodifiedIfMatchIfNoneMatchMustBeDefault() => new ArgumentOutOfRangeException($"The {nameof(HttpAccessConditions.IfUnmodifiedSince)}, {nameof(HttpAccessConditions.IfMatch)}, and {nameof(HttpAccessConditions.IfNoneMatch)} conditions must have their default values because they are ignored by the blob service");

        public static ArgumentOutOfRangeException IfMatchIfNoneMatchMustBeDefault() => new ArgumentOutOfRangeException($"The {nameof(HttpAccessConditions.IfMatch)}, and {nameof(HttpAccessConditions.IfNoneMatch)} conditions must have their default values because they are ignored by the blob service");

        public static NotSupportedException SnapshotsNotSupported() => new NotSupportedException("Snapshots are not supported in this operation");
    }
}
