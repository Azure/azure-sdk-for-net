// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591, SA1402, SA1508, CS0618

using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    [Obsolete("Moved to Azure.ResourceManager.ContainerRegistryTasks")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal partial class UnknownTaskStepProperties : ContainerRegistryTaskStepProperties { }
}
