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
    internal class DatasetConverter : CoreTypeConverter<Core.Models.Dataset, Dataset, DatasetTypeProperties, GenericDataset>
    {
        /// <summary> 
        /// Convert <paramref name="dataset"/> to an <see cref="Core.Models.Dataset"/> instance.
        /// This method should be called only after type is validated, otherwise type-specific logic will break
        /// </summary>
        /// <param name="dataset">The <see cref="Core.Models.Dataset"/> instance to convert.</param>
        /// <returns>A <see cref="Core.Models.Dataset"/> instance equivalent to <paramref name="dataset"/>.</returns>
        public override Core.Models.Dataset ToCoreType(Dataset dataset)
        {
            Ensure.IsNotNull(dataset, "dataset");
            Ensure.IsNotNull(dataset.Properties, "dataset.Properties");
            Ensure.IsNotNull(dataset.Properties.TypeProperties, "dataset.Properties.TypeProperties");

            string typeProperties = dataset.Properties.TypeProperties.SerializeObject();

            Core.Models.Dataset internalDataset = new Core.Models.Dataset()
            {
                Name = dataset.Name, 
                Properties = new Core.Models.DatasetProperties()
                                 {
                                     Type = dataset.Properties.Type, 
                                     TypeProperties = typeProperties, 
                                     Availability = dataset.Properties.Availability, 
                                     CreateTime = dataset.Properties.CreateTime,
                                     Description = dataset.Properties.Description, 
                                     LinkedServiceName = dataset.Properties.LinkedServiceName, 
                                     Policy = dataset.Properties.Policy, 
                                     Structure = dataset.Properties.Structure,
                                     External = dataset.Properties.External
                                 }
            };

            return internalDataset;
        }

        /// <summary> 
        /// Convert <paramref name="internalDataset"/> to a <see cref="Dataset"/> instance.
        /// </summary>
        /// <param name="internalDataset">The <see cref="Core.Models.Dataset"/> instance to convert.</param>
        /// <returns>A <see cref="Dataset"/> instance equivalent to <paramref name="internalDataset"/>.</returns>
        public override Dataset ToWrapperType(Core.Models.Dataset internalDataset)
        {
            Ensure.IsNotNull(internalDataset, "internalDataset");
            Ensure.IsNotNull(internalDataset.Properties, "internalDataset.Properties");

            Type type;
            DatasetTypeProperties typeProperties = this.DeserializeTypeProperties(
                internalDataset.Properties.Type,
                internalDataset.Properties.TypeProperties,
                out type);

            string typeName = GetTypeName(type, internalDataset.Properties.Type);
            DatasetProperties properties = new DatasetProperties(
                typeProperties,
                internalDataset.Properties.Availability,
                internalDataset.Properties.LinkedServiceName,
                typeName)
                     {
                         Availability = internalDataset.Properties.Availability,
                         CreateTime = internalDataset.Properties.CreateTime,
                         Description = internalDataset.Properties.Description,
                         ErrorMessage = internalDataset.Properties.ErrorMessage,
                         LinkedServiceName = internalDataset.Properties.LinkedServiceName,
                         Policy = internalDataset.Properties.Policy,
                         ProvisioningState = internalDataset.Properties.ProvisioningState,
                         Structure = internalDataset.Properties.Structure,
                         External = internalDataset.Properties.External
                     };

            return new Dataset() { Name = internalDataset.Name, Properties = properties };
        }

        /// <summary>
        /// Validate a <see cref="Dataset"/> instance, specifically its type properties.
        /// </summary>
        /// <param name="dataset">The <see cref="Dataset"/> instance to validate.</param>
        public override void ValidateWrappedObject(Dataset dataset)
        {
            Ensure.IsNotNull(dataset, "dataset");
            Ensure.IsNotNull(dataset.Properties, "dataset.Properties");
            Ensure.IsNotNull(dataset.Properties.Type, "dataset.Properties.Type");

            Type type;
            if (this.TryGetRegisteredType(dataset.Properties.Type, out type))
            {
                this.ValidateTypeProperties(dataset.Properties.TypeProperties, type);
            }
        }
    }
}
