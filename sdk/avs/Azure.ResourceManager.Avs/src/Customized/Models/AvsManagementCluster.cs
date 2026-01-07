// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.Text.Json;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.Avs.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("ClusterSize", typeof(int?))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("ProvisioningState", typeof(AvsPrivateCloudClusterProvisioningState?))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("ClusterId", typeof(int?))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Hosts", typeof(IList<string>))]
    public partial class AvsManagementCluster : CommonClusterProperties
    {
        /// <summary> Name of the vsan datastore associated with the cluster. </summary>
        public string VsanDatastoreName { get; set; }
        /*
        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(VsanDatastoreName))
            {
                writer.WritePropertyName("vsanDatastoreName"u8);
                writer.WriteStringValue(VsanDatastoreName);
            }
        }*/
    }
}
