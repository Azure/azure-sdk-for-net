// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // Restore baseline public surface:
    // - ctor takes typed CassandraKeyspaceResourceInfo (not flattened string)
    // - Options has setter
    // - ResourceKeyspaceName has setter (passes through to Resource.KeyspaceName)
    [CodeGenSuppress("CassandraKeyspaceCreateOrUpdateContent", typeof(AzureLocation), typeof(string))]
    [CodeGenSuppress("Properties")]
    [CodeGenSuppress("Options")]
    [CodeGenSuppress("ResourceKeyspaceName")]
    public partial class CassandraKeyspaceCreateOrUpdateContent
    {
        public CassandraKeyspaceCreateOrUpdateContent(AzureLocation location, CassandraKeyspaceResourceInfo resource) : base(location)
        {
            Argument.AssertNotNull(resource, nameof(resource));

            Properties = new CassandraKeyspaceCreateUpdateProperties(resource.KeyspaceName);
        }

        [WirePath("properties")]
        internal CassandraKeyspaceCreateUpdateProperties Properties { get; set; }

        [WirePath("properties.options")]
        public CosmosDBCreateUpdateConfig Options
        {
            get => Properties?.Options;
            set
            {
                if (Properties == null)
                {
                    throw new InvalidOperationException("Options cannot be set before Resource is initialized; set Resource first to establish the inner Properties holder.");
                }
                Properties.Options = value;
            }
        }

        [WirePath("properties.resource.id")]
        public string ResourceKeyspaceName
        {
            get => Properties?.ResourceKeyspaceName;
            set => Properties = new CassandraKeyspaceCreateUpdateProperties(value) { Options = Properties?.Options };
        }
    }
}
