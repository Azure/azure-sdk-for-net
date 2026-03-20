// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.KubernetesConfiguration.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.KubernetesConfiguration
{
    // Note: Some old API members on KubernetesClusterExtensionData cannot be re-added as stubs:
    //
    // - AksAssignedIdentity changed type from ManagedServiceIdentity to KubernetesClusterExtensionAksAssignedIdentity
    //   (cannot have two properties with the same name but different types in C#)
    // - PackageUri changed type from System.Uri to string
    //   (same constraint)
    // - ConfigurationProtectedSettings, ConfigurationSettings, and Statuses lost their setters
    //   (cannot add a setter to a property already fully defined in the generated partial class)
    //
    // The old factory method overload with ManagedServiceIdentity/Uri parameter types
    // is already preserved in the generated ArmKubernetesConfigurationModelFactory with [EditorBrowsable(Never)].
}
