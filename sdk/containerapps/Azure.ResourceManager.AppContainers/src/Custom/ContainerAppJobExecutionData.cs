// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AppContainers
{
    [CodeGenSerialization(nameof(Status), new[] { "properties", "status" })]
    [CodeGenSerialization(nameof(StartOn), new[] { "properties", "startTime" })]
    [CodeGenSerialization(nameof(EndOn), new[] { "properties", "endTime" })]
    [CodeGenSerialization(nameof(Template), new[] { "properties", "template" })]
    public partial class ContainerAppJobExecutionData : ResourceData
    {
    }
}
