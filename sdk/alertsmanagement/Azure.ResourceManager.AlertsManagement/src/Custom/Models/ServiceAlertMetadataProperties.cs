// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Restore the protected parameterless constructor required by the GA 1.1.x binary contract
// (the TypeSpec generator emits it as internal, which would seal the type from external
// subclasses and break ApiCompat against the published NuGet).

#nullable disable

namespace Azure.ResourceManager.AlertsManagement.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("ServiceAlertMetadataProperties")]
    public abstract partial class ServiceAlertMetadataProperties
    {
        /// <summary> Initializes a new instance of <see cref="ServiceAlertMetadataProperties"/> for deserialization. </summary>
        protected ServiceAlertMetadataProperties() { }
    }
}
