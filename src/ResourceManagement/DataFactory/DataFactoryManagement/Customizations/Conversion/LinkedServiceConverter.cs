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
using Core = Microsoft.Azure.Management.DataFactories.Core.Models;

namespace Microsoft.Azure.Management.DataFactories.Conversion
{
   internal class LinkedServiceConverter :
        CoreTypeConverter<Core.Models.LinkedService, LinkedService, LinkedServiceTypeProperties, GenericLinkedService>
    {
        /// <summary> 
        /// Convert <paramref name="linkedService"/> to an <see cref="Microsoft.Azure.Management.DataFactories.Core.Models.LinkedService"/> instance.
        /// This method should be called only after type is validated, otherwise type-specific logic will break
        /// </summary>
        /// <param name="linkedService">The <see cref="Microsoft.Azure.Management.DataFactories.Models.LinkedService"/> instance to convert.</param>
        /// <returns>An <see cref="Microsoft.Azure.Management.DataFactories.Core.Models.LinkedService"/> 
        /// instance equivalent to <paramref name="linkedService"/>.</returns>
        public override Core.Models.LinkedService ToCoreType(LinkedService linkedService)
        {
            Ensure.IsNotNull(linkedService, "linkedService");
            Ensure.IsNotNull(linkedService.Properties, "linkedService.Properties");
            Ensure.IsNotNull(linkedService.Properties.TypeProperties, "linkedService.Properties.TypeProperties");

            string typeProperties = linkedService.Properties.TypeProperties.SerializeObject();

            Core.Models.LinkedService internalLinkedService = new Core.Models.LinkedService()
            {
                Name = linkedService.Name,
                Properties = new Core.Models.LinkedServiceProperties()
                {
                    Type = linkedService.Properties.Type,
                    Description = linkedService.Properties.Description,
                    HubName = linkedService.Properties.HubName,
                    TypeProperties = typeProperties
                }
            };

            return internalLinkedService; 
        }

        /// <summary> 
        /// Convert <see cref="Microsoft.Azure.Management.DataFactories.Core.Models.LinkedService"/> 
        /// to a <see cref="Microsoft.Azure.Management.DataFactories.Models.LinkedService"/> instance.
        /// </summary>
        /// <param name="internalLinkedService">
        /// The <see cref="Microsoft.Azure.Management.DataFactories.Core.Models.LinkedService"/> 
        /// instance to convert.</param>
        /// <returns>A <see cref="LinkedService"/> instance equivalent to <paramref name="internalLinkedService"/>.</returns>
        public override LinkedService ToWrapperType(Core.Models.LinkedService internalLinkedService)
        {
            Ensure.IsNotNull(internalLinkedService, "internalLinkedService");
            Ensure.IsNotNull(internalLinkedService.Properties, "internalLinkedService.Properties");

            Type type;
            LinkedServiceTypeProperties typeProperties = this.DeserializeTypeProperties(
                internalLinkedService.Properties.Type,
                internalLinkedService.Properties.TypeProperties, out type);

            string typeName = GetTypeName(type, internalLinkedService.Properties.Type);
            LinkedServiceProperties properties = new LinkedServiceProperties(typeProperties, typeName)
                         {
                             Description = internalLinkedService.Properties.Description,
                             ErrorMessage = internalLinkedService.Properties.ErrorMessage,
                             HubName = internalLinkedService.Properties.HubName,
                             ProvisioningState = internalLinkedService.Properties.ProvisioningState
                         };

            return new LinkedService() { Name = internalLinkedService.Name, Properties = properties };
        }

        /// <summary>
        /// Validate a LinkedService instance, specifically its type properties.
        /// </summary>
        /// <param name="linkedService">The <see cref="LinkedService"/> instance to validate.</param>
        public override void ValidateWrappedObject(LinkedService linkedService)
        {
            Ensure.IsNotNull(linkedService, "linkedService");
            Ensure.IsNotNull(linkedService.Properties, "linkedService.Properties");
            Ensure.IsNotNull(linkedService.Properties.Type, "linkedService.Properties.Type");

            Type type;
            if (this.TryGetRegisteredType(linkedService.Properties.Type, out type))
            {
                // We can do validation if a class has been registered for the type
                this.ValidateTypeProperties(linkedService.Properties.TypeProperties, type);
            }
        }
    }
}
