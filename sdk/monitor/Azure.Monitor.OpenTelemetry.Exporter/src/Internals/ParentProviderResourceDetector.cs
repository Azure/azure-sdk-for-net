// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using OpenTelemetry.Resources;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    /// <summary>
    /// A custom resource detector that retrieves resource attributes from a parent provider.
    /// This is used by StandardMetricsExtractionProcessor to ensure performance counter metrics
    /// inherit the resource attributes from the main TracerProvider.
    /// </summary>
    internal sealed class ParentProviderResourceDetector : IResourceDetector
    {
        private readonly Func<Resource?> _resourceProvider;

        public ParentProviderResourceDetector(Func<Resource?> resourceProvider)
        {
            _resourceProvider = resourceProvider ?? throw new ArgumentNullException(nameof(resourceProvider));
        }

        public Resource Detect()
        {
            var parentResource = _resourceProvider();
            if (parentResource == null)
            {
                return Resource.Empty;
            }

            // Extract all attributes from the parent resource and create a new resource with them
            var attributes = new List<KeyValuePair<string, object>>();
            foreach (var attribute in parentResource.Attributes)
            {
                attributes.Add(attribute);
            }

            return new Resource(attributes);
        }
    }
}
