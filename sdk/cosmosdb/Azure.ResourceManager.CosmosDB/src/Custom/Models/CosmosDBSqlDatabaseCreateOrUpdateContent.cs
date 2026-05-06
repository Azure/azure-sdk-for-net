// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Models
{
    [CodeGenSuppress("Properties")]
    [CodeGenSuppress("Resource")]
    [CodeGenSuppress("Options")]
    public partial class CosmosDBSqlDatabaseCreateOrUpdateContent
    {
        [WirePath("properties")]
        internal SqlDatabaseCreateUpdateProperties Properties { get; set; }

        [WirePath("properties.resource")]
        public CosmosDBSqlDatabaseResourceInfo Resource
        {
            get => Properties?.Resource;
            set => Properties = new SqlDatabaseCreateUpdateProperties(value) { Options = Properties?.Options };
        }

        [WirePath("properties.options")]
        public CosmosDBCreateUpdateConfig Options
        {
            get => Properties?.Options;
            set
            {
                if (Properties == null && value != null)
                {
                    return;
                }
                if (Properties != null)
                {
                    Properties.Options = value;
                }
            }
        }
        public string ResourceDatabaseName
        {
            get => Resource?.DatabaseName;
            set => Resource = new CosmosDBSqlDatabaseResourceInfo(value);
        }
    }
}
