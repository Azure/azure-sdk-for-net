// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.DataBox.Models
{
    public partial class DataBoxValidateAddressContent : DataBoxValidationInputContent
    {
        /// <summary> Indicates Shipment Logistics type that the customer preferred. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TransportShipmentType? TransportPreferencesPreferredShipmentType
        {
            get => TransportPreferences is null ? default(TransportShipmentType?) : TransportPreferences.PreferredShipmentType;
            set
            {
                TransportPreferences = value.HasValue ? new TransportPreferences(value.Value) : null;
            }
        }
    }
}
