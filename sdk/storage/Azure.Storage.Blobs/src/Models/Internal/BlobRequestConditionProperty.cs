﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    internal enum BlobRequestConditionProperty
    {
        None = 0,
        LeaseId = 1,
        TagConditions = 2,
        IfModifiedSince = 4,
        IfUnmodifiedSince = 8,
        IfMatch = 16,
        IfNoneMatch = 32,
        IfAppendPositionEqual = 64,
        IfMaxSizeLessThanOrEqual = 128,
        IfSequenceNumberLessThan = 256,
        IfSequenceNumberLessThanOrEqual = 512,
        IfSequenceNumberEqual = 1024
    }
}
