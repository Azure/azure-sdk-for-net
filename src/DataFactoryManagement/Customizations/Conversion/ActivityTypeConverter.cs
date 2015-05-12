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

namespace Microsoft.Azure.Management.DataFactories.Conversion
{
#if ADF_INTERNAL
    internal class ActivityTypeConverter : AdfRegisteredTypeConverter<InternalActivityType, ActivityType>
    {
        public override InternalActivityType ToCoreType(ActivityType wrappedObject)
        {
            return new InternalActivityType()
                       {
                           Name = wrappedObject.Name,
                           Properties = new InternalActivityTypeProperties()
                                   {
                                       BaseType = wrappedObject.Properties.BaseType,
                                       Scope = wrappedObject.Properties.Scope,
                                       Schema = wrappedObject.Properties.Schema.Serialize()
                                   }
                       };
        }

        public override ActivityType ToWrapperType(InternalActivityType coreObject)
        {
            return new ActivityType()
                       {
                           Name = coreObject.Name,
                           Properties = new ActivityTypeProperties()
                                   {
                                       BaseType = coreObject.Properties.BaseType,
                                       Scope = coreObject.Properties.Scope,
                                       Schema = AdfTypeSchema.Deserialize(coreObject.Properties.Schema)
                                   }
                       };
        }
    }
#endif
}
