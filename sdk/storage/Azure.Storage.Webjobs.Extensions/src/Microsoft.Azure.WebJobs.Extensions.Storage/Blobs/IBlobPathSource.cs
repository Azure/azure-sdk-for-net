// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.WebJobs.Host.Blobs
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
