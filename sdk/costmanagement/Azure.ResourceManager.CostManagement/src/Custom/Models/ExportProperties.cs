// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CostManagement.Models
{
    [CodeGenSuppress("ExportProperties", typeof(ExportDeliveryInfo), typeof(ExportDefinition))]
    public partial class ExportProperties
    {
        /// <summary> Initializes a new instance of <see cref="ExportProperties"/>. </summary>
        /// <param name="deliveryInfo"> Has delivery information for the export. </param>
        /// <param name="definition"> Has the definition for the export. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deliveryInfo"/> or <paramref name="definition"/> is null. </exception>
        public ExportProperties(ExportDeliveryInfo deliveryInfo, ExportDefinition definition) : base(deliveryInfo, definition)
        {
            Argument.AssertNotNull(deliveryInfo, nameof(deliveryInfo));
            Argument.AssertNotNull(definition, nameof(definition));
        }
    }
}
