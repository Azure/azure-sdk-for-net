// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.MySql
{
    public partial class MySqlServerData
    {
        /// <summary> The master server id of a replica server. </summary>
        [CodeGenMemberSerializationHooks(DeserializationValueHook = nameof(ReadMasterServerId))]
        public ResourceIdentifier MasterServerId { get; set; }

        internal static void ReadMasterServerId(JsonProperty property, ref Optional<ResourceIdentifier> masterServerId)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            // customize here to let it treat empty string as null resource identifier
            var idStr = property.Value.GetString();
            if (string.IsNullOrEmpty(idStr))
                return;
            // Customized code end
            masterServerId = new ResourceIdentifier(idStr);
        }
    }
}
