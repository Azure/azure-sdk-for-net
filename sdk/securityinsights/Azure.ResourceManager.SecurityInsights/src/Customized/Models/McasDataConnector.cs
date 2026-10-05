// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityInsights.Models
{
    public partial class McasDataConnector
    {
        // TODO: Remove when https://github.com/Azure/azure-sdk-for-net/pull/62632 is available in the generator.
        /// <summary> The available data types for the connector. </summary>
        public McasDataConnectorDataTypes DataTypes
        {
            get => Properties?.DataTypes;
            set
            {
                Properties ??= new McasDataConnectorProperties();
                Properties.DataTypes = value;
            }
        }
    }
}
