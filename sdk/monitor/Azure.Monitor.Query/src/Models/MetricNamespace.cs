// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.Query.Models
{
    public partial class MetricNamespace
    {
        /// <summary> Properties which include the fully qualified namespace name. </summary>
        private MetricNamespaceName Properties { get; }

        /// <summary> The fully qualified namespace name. </summary>
        public string FullyQualifiedName => Properties.MetricNamespaceNameProperty;
    }
}
