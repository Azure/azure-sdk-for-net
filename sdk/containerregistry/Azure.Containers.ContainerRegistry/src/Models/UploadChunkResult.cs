// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Containers.ContainerRegistry.Models
{
    public class UploadChunkResult
    {
        internal UploadChunkResult(string blobLocation, string progress, Guid dockerUploadId)
        {
            // From docstring comments: /// <param name="location"> Link acquired from upload start or previous chunk. Note, do not include initial / (must do substring(1) ). </param>
            // TODO: is there a way to rejig this in the swagger file rather than doing it in code?
            BlobLocation = new Uri(blobLocation.Substring(1));
            Progress = progress;
            DockerUploadId = dockerUploadId;
        }

        public Uri BlobLocation { get; }

        // TODO: what strings are returned here, and is this best modeled as a string, or a numerical type?
        public string Progress { get; }

        // TODO: Not sure how customers would use this, so wonder if we need to expose it or not
        // TODO: For now, calling this DockerUploadID because of the header name, but does it work the same way
        // with OCI artifact uploads and therefore should just be called UploadId?
        public Guid DockerUploadId { get; }
    }
}
