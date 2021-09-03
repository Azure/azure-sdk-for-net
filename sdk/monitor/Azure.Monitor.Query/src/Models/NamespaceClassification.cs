// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    /// <summary> Kind of namespace. </summary>
    public readonly partial struct NamespaceClassification : IEquatable<NamespaceClassification>
    {
        /// <summary> Qos. </summary>
        [CodeGenMember("Qos")]
        public static NamespaceClassification QualityOfService { get; } = new NamespaceClassification("QualityOfService");
    }
}
