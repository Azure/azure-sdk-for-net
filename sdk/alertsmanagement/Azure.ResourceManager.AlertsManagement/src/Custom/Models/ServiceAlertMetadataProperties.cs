// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    // Backward compatibility: the old SDK (AutoRest-based, v1.1.1) exposed a protected
    // parameterless constructor on ServiceAlertMetadataProperties for mocking/testing.
    // The new TypeSpec generator only generates an internal parameterless constructor in the
    // Serialization file. This custom code adds the protected constructor back.
    public abstract partial class ServiceAlertMetadataProperties
    {
        /// <summary> Initializes a new instance of <see cref="ServiceAlertMetadataProperties"/> for mocking. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected ServiceAlertMetadataProperties() : this(default(ServiceAlertMetadataIdentifier))
        {
        }
    }
}
