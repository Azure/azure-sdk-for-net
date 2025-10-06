// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    public enum TestScenarioName
    {
        UploadSingleBlockBlob,
        UploadDirectoryBlockBlob,
        DownloadSingleBlockBlob,
        DownloadDirectoryBlockBlob,
        CopySingleBlockBlob,
        CopyDirectoryBlockBlob,
        UploadSingleAppendBlob,
        UploadDirectoryAppendBlob,
        DownloadSingleAppendBlob,
        DownloadDirectoryAppendBlob,
        CopySingleAppendBlob,
        CopyDirectoryAppendBlob,
        UploadSinglePageBlob,
        UploadDirectoryPageBlob,
        DownloadSinglePageBlob,
        DownloadDirectoryPageBlob,
        CopySinglePageBlob,
        CopyDirectoryPageBlob,
        None = default
    }
}
