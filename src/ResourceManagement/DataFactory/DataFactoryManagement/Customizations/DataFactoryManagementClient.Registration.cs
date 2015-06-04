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
using IRegisteredType = Microsoft.Azure.Management.DataFactories.Registration.Models.IRegisteredType;

namespace Microsoft.Azure.Management.DataFactories
{
    public partial class DataFactoryManagementClient
    {
        internal void RegisterType<T>() where T : IRegisteredType
        {
            Type type = typeof(T);

            if (typeof(LinkedServiceTypeProperties).IsAssignableFrom(type))
            {
                ((LinkedServiceOperations)this.LinkedServices).RegisterType<T>();
            }
            else if (typeof(TableTypeProperties).IsAssignableFrom(type))
            {
                ((TableOperations)this.Tables).RegisterType<T>();
            }
            else if (typeof(ActivityTypeProperties).IsAssignableFrom(type))
            {
                ((PipelineOperations)this.Pipelines).RegisterType<T>();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        internal bool TypeIsRegistered<T>() where T : IRegisteredType
        {
            Type type = typeof(T);

            if (typeof(LinkedServiceTypeProperties).IsAssignableFrom(type))
            {
                return ((LinkedServiceOperations)this.LinkedServices).TypeIsRegistered<T>();
            }
            else if (typeof(TableTypeProperties).IsAssignableFrom(type))
            {
                return ((TableOperations)this.Tables).TypeIsRegistered<T>();
            }
            else if (typeof(ActivityTypeProperties).IsAssignableFrom(type))
            {
                return ((PipelineOperations)this.Pipelines).TypeIsRegistered<T>();
            }
            else
            {
                return false;
            }
        }
    }
}
