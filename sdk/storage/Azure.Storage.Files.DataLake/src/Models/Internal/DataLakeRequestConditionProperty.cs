// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.DataLake.Models
{
    [Flags]
    internal enum DataLakeRequestConditionProperty
    {
        None = 0,
        LeaseId = 1,
        TagConditions = 2,
        IfModifiedSince = 4,
        IfUnmodifiedSince = 8,
        IfMatch = 16,
        IfNoneMatch = 32,
    }
}
