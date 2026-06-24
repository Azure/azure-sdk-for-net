// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    // The generated create/update content model flattens these envelope properties from the
    // REST shape, but the shipped SDK exposed location/tags only on the nested
    // ConnectionMonitorCreateOrUpdateContent compatibility model. Suppress them here to avoid
    // adding duplicate public properties with different ownership.
    /// <summary> Compatibility declaration for the ConnectionMonitorContent type. </summary>
    [CodeGenSuppress("Location")]
    [CodeGenSuppress("Tags")]
    public partial class ConnectionMonitorContent
    {
    }
}
