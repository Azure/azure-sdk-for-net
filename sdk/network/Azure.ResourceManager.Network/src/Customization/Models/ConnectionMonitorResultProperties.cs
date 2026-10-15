// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    public partial class ConnectionMonitorResultProperties
    {
        // The TypeSpec migration accidentally exposed this properties model publicly and assigned
        // the endpoint enum to its monitor-category property. That shipped getter is now a public
        // compatibility contract, even though its enum describes the wrong concept.
        //
        // CodeGenMember binds MonitorType to the service's existing connectionMonitorType field.
        // Giving the correctly typed property a different CLR name preserves the old getter's
        // signature while ensuring constructors and serialization use ConnectionMonitorType.
        // The obsolete getter below is only a projection of this value: it must not acquire its
        // own storage or become a second serialized property.
        /// <summary> Type of connection monitor. </summary>
        [CodeGenMember("ConnectionMonitorType")]
        public ConnectionMonitorType? MonitorType { get; }

        /// <summary> Gets the type of connection monitor using the legacy enum type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use MonitorType instead.")]
        public ConnectionMonitorEndpointType? ConnectionMonitorType
        {
            get
            {
                if (MonitorType is not { } value)
                {
                    return null;
                }

                // Preserve unknown wire values and a present default struct without parsing an enum
                // or invoking its string constructor with null.
                return value.ToString() is string text ? new ConnectionMonitorEndpointType(text) : default(ConnectionMonitorEndpointType);
            }
        }
    }
}
