// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Azure.WebJobs.Host.Bindings.Path;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    internal class ParameterizedBlobPathSource : IBlobPathSource
    {
        private readonly string _containerNamePattern;
        private readonly string _blobNamePattern;
        private readonly BindingTemplateSource _template;

        public ParameterizedBlobPathSource(string containerNamePattern, string blobNamePattern,
            BindingTemplateSource template)
        {
            Debug.Assert(template != null, "template must not be null");
            Debug.Assert(template.ParameterNames.Any(), "template must contain one or more parameters");

            _containerNamePattern = containerNamePattern;
            _blobNamePattern = blobNamePattern;
            _template = template;
        }

        public string ContainerNamePattern
        {
            get { return _containerNamePattern; }
        }

        public string BlobNamePattern
        {
            get { return _blobNamePattern; }
        }

        public IEnumerable<string> ParameterNames
        {
            get { return _template.ParameterNames; }
        }

        public IReadOnlyDictionary<string, object> CreateBindingData(BlobPath actualBlobPath)
        {
            if (actualBlobPath == null)
            {
                return null;
            }

            // Containers must match
            if (!String.Equals(ContainerNamePattern, actualBlobPath.ContainerName, StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            // Pattern is container only
            if (String.IsNullOrEmpty(BlobNamePattern))
            {
                return new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            }

            return _template.CreateBindingData(actualBlobPath.ToString());
        }

        public override string ToString()
        {
            return _template.Pattern;
        }
    }
}
