// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.CostManagement.Models
{
    // public ctor is added via customization, the generator suppresses its own flattened public ctor on regen,
    // which then breaks the flattened base-call emitted on the ExportProperties subtype.
    // Workaround: copy the generated flattened public ctor here AND add the non-flattened ctor (for ApiCompat).
    public partial class CommonExportProperties
    {
        /// <summary> Initializes a new instance of <see cref="CommonExportProperties"/>. </summary>
        /// <param name="deliveryInfoDestination"> Has destination for the export being delivered. </param>
        /// <param name="definition"> Has the definition for the export. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deliveryInfoDestination"/> or <paramref name="definition"/> is null. </exception>
        public CommonExportProperties(ExportDeliveryDestination deliveryInfoDestination, ExportDefinition definition)
        {
            Argument.AssertNotNull(deliveryInfoDestination, nameof(deliveryInfoDestination));
            Argument.AssertNotNull(definition, nameof(definition));

            DeliveryInfo = new ExportDeliveryInfo(deliveryInfoDestination);
            Definition = definition;
        }

        /// <summary> Initializes a new instance of <see cref="CommonExportProperties"/>. </summary>
        /// <param name="deliveryInfo"> Has delivery information for the export. </param>
        /// <param name="definition"> Has the definition for the export. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deliveryInfo"/> or <paramref name="definition"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CommonExportProperties(ExportDeliveryInfo deliveryInfo, ExportDefinition definition)
            : this(GetDestination(deliveryInfo), definition)
        {
        }

        private static ExportDeliveryDestination GetDestination(ExportDeliveryInfo deliveryInfo)
        {
            Argument.AssertNotNull(deliveryInfo, nameof(deliveryInfo));
            return deliveryInfo.Destination;
        }
    }
}
