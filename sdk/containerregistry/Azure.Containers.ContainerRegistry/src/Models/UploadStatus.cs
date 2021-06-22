// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Containers.ContainerRegistry.ResumableStorage
{
    internal class UploadStatus
    {
        internal UploadStatus(HttpRange range, Guid dockerUploadId)
        {
            Range = range;
            UploadId = dockerUploadId;
        }

        public HttpRange Range { get; }

        public Guid UploadId { get; }
    }
}
