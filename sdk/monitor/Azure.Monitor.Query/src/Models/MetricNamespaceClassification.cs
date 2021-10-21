// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    /// <summary> Kind of namespace. </summary>
    [CodeGenModel("NamespaceClassification")]
    public readonly partial struct MetricNamespaceClassification : IEquatable<MetricNamespaceClassification>
    {
        /// <summary> Qos. </summary>
        [CodeGenMember("Qos")]
        public static MetricNamespaceClassification QualityOfService { get; } = new MetricNamespaceClassification("QualityOfService");
    }
}
