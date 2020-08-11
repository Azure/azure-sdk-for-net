// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Processor
{
    /// <summary>
    /// BlobErrorCodeStrings isn't public in Storage UWP API, therefore we need to provide error code strings here.
    /// </summary>
    static class BlobErrorCodeStrings
    {
        public static readonly string BlobAlreadyExists = "BlobAlreadyExists";
        public static readonly string LeaseIdMissing = "LeaseIdMissing";
        public static readonly string LeaseLost = "LeaseLost";
        public static readonly string LeaseAlreadyPresent = "LeaseAlreadyPresent";
        public static readonly string LeaseIdMismatchWithLeaseOperation = "LeaseIdMismatchWithLeaseOperation";
        public static readonly string LeaseIdMismatchWithBlobOperation = "LeaseIdMismatchWithBlobOperation";
    }
}
