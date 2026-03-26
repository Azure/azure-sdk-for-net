// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    // Backward compatibility: old SDK had a protected parameterless constructor.
    // New generator uses internal parameterless ctor in Serialization file. Suppress it and add protected.
    public abstract partial class ServiceAlertMetadataProperties
    {
        /// <summary> Initializes a new instance of <see cref="ServiceAlertMetadataProperties"/> for mocking. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected ServiceAlertMetadataProperties() : this(default(ServiceAlertMetadataIdentifier))
        {
        }
    }
}
