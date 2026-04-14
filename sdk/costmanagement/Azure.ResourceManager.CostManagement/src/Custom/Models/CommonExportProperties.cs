// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CostManagement.Models
{
    [CodeGenSuppress("CommonExportProperties", typeof(ExportDeliveryDestination), typeof(ExportDefinition))]
    public partial class CommonExportProperties
    {
        /// <summary> Initializes a new instance of <see cref="CommonExportProperties"/>. </summary>
        /// <param name="deliveryInfo"> Has delivery information for the export. </param>
        /// <param name="definition"> Has the definition for the export. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CommonExportProperties(ExportDeliveryInfo deliveryInfo, ExportDefinition definition)
            : this(default, deliveryInfo, definition, default, default, default, default, default, default, default, default)
        {
        }
    }
}
