// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.WebJobs.Host.Blobs
{
    internal class FixedBlobPathSource : IBlobPathSource
    {
        private readonly BlobPath _innerPath;

        public FixedBlobPathSource(BlobPath innerPath)
        {
            _innerPath = innerPath;
        }

        public string ContainerNamePattern
        {
            get { return _innerPath.ContainerName; }
        }

        public string BlobNamePattern
        {
            get { return _innerPath.BlobName; }
        }

        public IEnumerable<string> ParameterNames
        {
            get { return Enumerable.Empty<string>(); }
        }

        public IReadOnlyDictionary<string, object> CreateBindingData(BlobPath actualBlobPath)
        {
            if (actualBlobPath == null)
            {
                return null;
            }

            // The path source may be a container name only. In that case, ignore the blob name for determining a match.
            if (actualBlobPath.ToString() == ToString() ||
                (String.IsNullOrEmpty(_innerPath.BlobName) && actualBlobPath.ContainerName == _innerPath.ContainerName))
            {
                // Some consumers understand null as "blob didn't match". Return an empty dictionary instead for that case.
                return new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            }
            else
            {
                return null;
            }
        }

        public override string ToString()
        {
            return _innerPath.ToString();
        }
    }
}
