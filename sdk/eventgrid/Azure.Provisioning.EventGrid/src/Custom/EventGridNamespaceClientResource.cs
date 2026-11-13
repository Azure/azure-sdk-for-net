// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.EventGrid;

// The generated EventGridNamespaceClient name is treated as an SDK client by the analyzers.
// Preserve the released Resource suffix so this ARM resource is classified correctly.
[CodeGenType("EventGridNamespaceClient")]
public partial class EventGridNamespaceClientResource
{
    public static partial class ResourceVersions
    {
        /// <summary> API version "2025-02-15". </summary>
        public static readonly string V2025_02_15 = "2025-02-15";
    }
}
