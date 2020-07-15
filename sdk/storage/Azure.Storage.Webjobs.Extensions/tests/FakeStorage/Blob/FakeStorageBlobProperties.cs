// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.Storage.Blob;

namespace FakeStorage
{
    internal class FakeStorageBlobProperties
    {
        public string ETag { get; set; }

        public DateTimeOffset? LastModified { get; set; }

        public LeaseState LeaseState { get; set; }

        public LeaseStatus LeaseStatus { get; set; }

        public BlobProperties SdkObject { get; set; }


        public BlobProperties GetRealProperties()
        {
            var props = new BlobProperties();
            props.SetInternalProperty(nameof(BlobProperties.LastModified), this.LastModified);
            props.SetEtag(this.ETag);
            return props;
        }
    }
}
