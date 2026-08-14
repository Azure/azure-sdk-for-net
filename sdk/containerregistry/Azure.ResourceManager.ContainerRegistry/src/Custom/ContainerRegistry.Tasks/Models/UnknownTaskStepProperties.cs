// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    /// <summary> Provides backward-compatible surface area for UnknownTaskStepProperties. </summary>
    [Obsolete("Moved to Azure.ResourceManager.ContainerRegistry.Tasks")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal partial class UnknownTaskStepProperties : ContainerRegistryTaskStepProperties { }
}
