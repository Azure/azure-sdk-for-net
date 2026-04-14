// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.CostManagement.Models
{
    // Backward-compat: baseline ctor took ExportDeliveryInfo; generator now flattens to ExportDeliveryDestination.
    // Ideally we'd delegate to the generated public ctor: this(deliveryInfo?.Destination, definition).
    // However, due to https://github.com/microsoft/typespec/issues/10272, the generator skips emitting its own
    // public ctor when a custom one exists in the partial class (stale FQN detection). So we chain to the
    // internal full-param ctor instead until that bug is fixed.
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
