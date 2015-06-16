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
using Microsoft.Azure.Management.DataFactories.Conversion;
using Microsoft.Azure.Management.DataFactories.Models;
using Microsoft.Azure.Management.DataFactories.Registration.Models;

namespace Microsoft.Azure.Management.DataFactories
{
    public partial class DataFactoryManagementClient
    {
        internal static GenericRegisteredTypeConverter<IRegisteredType> GenericConverter  { get; set; }

        static DataFactoryManagementClient()
        {
            GenericConverter = new GenericRegisteredTypeConverter<IRegisteredType>();
        }

        internal void RegisterType<T>(bool force = false) where T : IRegisteredTypeInternal
        {
            Type type = typeof(T);

            // TODO bgold09: allow registration of CopyLocation, etc. from friend assemblies
            if (typeof(LinkedServiceTypeProperties).IsAssignableFrom(type))
            {
                ((LinkedServiceOperations)this.LinkedServices).RegisterType<T>(force);
            }
            else if (typeof(TableTypeProperties).IsAssignableFrom(type))
            {
                ((TableOperations)this.Tables).RegisterType<T>(force);
            }
            else if (typeof(Models.ActivityTypeProperties).IsAssignableFrom(type))
            {
                ((PipelineOperations)this.Pipelines).RegisterType<T>(force);
            }
            else
            {
                GenericConverter.RegisterType<T>(force);
            }
        }

        internal bool TypeIsRegistered<T>() where T : IRegisteredTypeInternal
        {
            Type type = typeof(T);

            if (typeof(LinkedServiceTypeProperties).IsAssignableFrom(type))
            {
                return ((LinkedServiceOperations)this.LinkedServices).TypeIsRegistered<T>();
            }

            if (typeof(TableTypeProperties).IsAssignableFrom(type))
            {
                return ((TableOperations)this.Tables).TypeIsRegistered<T>();
            }

            if (typeof(Models.ActivityTypeProperties).IsAssignableFrom(type))
            {
                return ((PipelineOperations)this.Pipelines).TypeIsRegistered<T>();
            }

            return GenericConverter.TypeIsRegistered<T>();
        }
    }
}
