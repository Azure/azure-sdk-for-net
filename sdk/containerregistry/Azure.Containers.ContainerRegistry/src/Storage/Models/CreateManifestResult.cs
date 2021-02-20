// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Containers.ContainerRegistry.Storage.Models
{
    public class CreateManifestResult
    {
        internal CreateManifestResult(string digest, string location, long contentLength)
        {
            Digest = digest;
            Location = new Uri(location.Substring(1));
            ContentLength = contentLength;
        }

        public string Digest { get; }

        public Uri Location { get; }

        public long ContentLength { get; }
    }
}
