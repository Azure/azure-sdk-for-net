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

using Microsoft.Azure.Management.DataFactories.Registration.Models;
using CoreRegistrationModel = Microsoft.Azure.Management.DataFactories.Core.Registration.Models;

namespace Microsoft.Azure.Management.DataFactories.Conversion
{
    internal class ComputeTypeConverter : AdfRegisteredTypeConverter<CoreRegistrationModel.ComputeType, ComputeType>
    {
        public override CoreRegistrationModel.ComputeType ToCoreType(ComputeType wrappedObject)
        {
            return new CoreRegistrationModel.ComputeType()
            {
                Name = wrappedObject.Name,
                Properties = new CoreRegistrationModel.ComputeTypeProperties()
                {
                    SupportedActivities = wrappedObject.Properties.SupportedActivities,
                    Transport = wrappedObject.Properties.Transport,
                    Scope = wrappedObject.Properties.Scope,
                    Schema = wrappedObject.Properties.Schema.Serialize()
                }
            };
        }

        public override ComputeType ToWrapperType(CoreRegistrationModel.ComputeType coreObject)
        {
            return new ComputeType()
            {
                Name = coreObject.Name,
                Properties = new ComputeTypeProperties()
                {
                    SupportedActivities = coreObject.Properties.SupportedActivities,
                    Transport = coreObject.Properties.Transport,
                    Scope = coreObject.Properties.Scope,
                    Schema = AdfTypeSchema.Deserialize(coreObject.Properties.Schema)
                }
            };
        }
    }
}
