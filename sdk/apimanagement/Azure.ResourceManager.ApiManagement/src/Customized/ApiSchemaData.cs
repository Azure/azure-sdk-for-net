// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiSchemaData
    {
        /// <summary> Json escaped string defining the document representing the Schema. Used for schemas other than Swagger/OpenAPI. </summary>
        [WirePath("properties.value")]
        public string Value
        {
            get => Properties is null ? default : Properties.Value;
            set
            {
                if (Properties is null)
                {
                    Properties = new SchemaContractProperties();
                }
                Properties.Value = value;
            }
        }

        /// <summary> Types definitions. Used for Swagger/OpenAPI v1 schemas only, null otherwise. </summary>
        [WirePath("properties.definitions")]
        public BinaryData Definitions
        {
            get => Properties is null ? default : Properties.Definitions;
            set
            {
                if (Properties is null)
                {
                    Properties = new SchemaContractProperties();
                }
                Properties.Definitions = value;
            }
        }

        /// <summary> Types definitions. Used for Swagger/OpenAPI v2/v3 schemas only, null otherwise. </summary>
        [WirePath("properties.components")]
        public BinaryData Components
        {
            get => Properties is null ? default : Properties.Components;
            set
            {
                if (Properties is null)
                {
                    Properties = new SchemaContractProperties();
                }
                Properties.Components = value;
            }
        }
    }
}
