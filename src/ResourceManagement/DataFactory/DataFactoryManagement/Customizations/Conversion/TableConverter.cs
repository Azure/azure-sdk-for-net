//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using Microsoft.Azure.Management.DataFactories.Models;

namespace Microsoft.Azure.Management.DataFactories.Conversion
{
    internal class TableConverter : CoreTypeConverter<Core.Models.Table, Table, TableTypeProperties, GenericDataset>
    {
        /// <summary> 
        /// Convert <paramref name="table"/> to an <see cref="Core.Models.Table"/> instance.
        /// This method should be called only after type is validated, otherwise type-specific logic will break
        /// </summary>
        /// <param name="table">The <see cref="Core.Models.Table"/> instance to convert.</param>
        /// <returns>An <see cref="Core.Models.Table"/> instance equivalent to <paramref name="table"/>.</returns>
        public override Core.Models.Table ToCoreType(Table table)
        {
            Ensure.IsNotNull(table, "table");
            Ensure.IsNotNull(table.Properties, "table.Properties");
            Ensure.IsNotNull(table.Properties.TypeProperties, "table.Properties.TypeProperties");

            string typeProperties = table.Properties.TypeProperties.SerializeObject();

            Core.Models.Table internalTable = new Core.Models.Table()
            {
                Name = table.Name, 
                Properties = new Core.Models.TableProperties()
                                 {
                                     Type = table.Properties.Type, 
                                     TypeProperties = typeProperties, 
                                     Availability = table.Properties.Availability, 
                                     CreateTime = table.Properties.CreateTime,
                                     Description = table.Properties.Description, 
                                     LinkedServiceName = table.Properties.LinkedServiceName, 
                                     Policy = table.Properties.Policy, 
                                     Published = table.Properties.Published, 
                                     Structure = table.Properties.Structure
                                 }
            };

            return internalTable;
        }

        /// <summary> 
        /// Convert <paramref name="internalTable"/> to a <see cref="Table"/> instance.
        /// </summary>
        /// <param name="internalTable">The <see cref="Core.Models.Table"/> instance to convert.</param>
        /// <returns>A <see cref="Table"/> instance equivalent to <paramref name="internalTable"/>.</returns>
        public override Table ToWrapperType(Core.Models.Table internalTable)
        {
            Ensure.IsNotNull(internalTable, "internalTable");
            Ensure.IsNotNull(internalTable.Properties, "internalTable.Properties");

            Type type;
            TableTypeProperties typeProperties = this.DeserializeTypeProperties(
                internalTable.Properties.Type,
                internalTable.Properties.TypeProperties,
                out type);

            string typeName = GetTypeName(type, internalTable.Properties.Type);
            TableProperties properties = new TableProperties(
                typeProperties,
                internalTable.Properties.Availability,
                internalTable.Properties.LinkedServiceName,
                typeName)
                     {
                         Availability = internalTable.Properties.Availability,
                         CreateTime = internalTable.Properties.CreateTime,
                         Description = internalTable.Properties.Description,
                         ErrorMessage = internalTable.Properties.ErrorMessage,
                         LinkedServiceName = internalTable.Properties.LinkedServiceName,
                         Policy = internalTable.Properties.Policy,
                         ProvisioningState = internalTable.Properties.ProvisioningState,
                         Published = internalTable.Properties.Published,
                         Structure = internalTable.Properties.Structure
                     };

            return new Table() { Name = internalTable.Name, Properties = properties };
        }

        /// <summary>
        /// Validate a <see cref="Table"/> instance, specifically its type properties.
        /// </summary>
        /// <param name="table">The <see cref="Table"/> instance to validate.</param>
        public override void ValidateWrappedObject(Table table)
        {
            Ensure.IsNotNull(table, "table");
            Ensure.IsNotNull(table.Properties, "table.Properties");
            Ensure.IsNotNull(table.Properties.Type, "table.Properties.Type");

            Type type;
            if (this.TryGetRegisteredType(table.Properties.Type, out type))
            {
                this.ValidateTypeProperties(table.Properties.TypeProperties, type);
            }
        }
    }
}
