// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// Create exceptions for common error cases.
    /// </summary>
    internal class BlobErrors : Errors
    {
        public static ArgumentOutOfRangeException BlobConditionsMustBeDefault(params string[] conditions) =>
            new ArgumentOutOfRangeException($"The {String.Join(" and ", conditions)} conditions must have their default values because they are ignored by the blob service");
    }
}
