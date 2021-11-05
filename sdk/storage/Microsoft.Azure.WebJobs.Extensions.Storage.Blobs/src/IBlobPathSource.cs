// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    internal interface IBlobPathSource
    {
        string ContainerNamePattern { get; }

        string BlobNamePattern { get; }

        IEnumerable<string> ParameterNames { get; }

        IReadOnlyDictionary<string, object> CreateBindingData(BlobPath actualBlobPath);

        string ToString();
    }
}
