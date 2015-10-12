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

using Hyak.Common;

using Microsoft.Azure.Management.DataFactories.Conversion;
using Microsoft.Azure.Management.DataFactories.Models;

namespace Microsoft.Azure.Management.DataFactories
{
    /// <summary>
    /// Operations for registering Dataset types. 
    /// </summary>
    internal partial class DatasetOperations
    {
        internal DatasetConverter Converter { get; set; }

        public void RegisterType<T>(bool force = false)
        {
            this.Converter.RegisterType<T>(force, typeof(Dataset));
        }

        public bool TypeIsRegistered<T>()
        {
            return this.Converter.TypeIsRegistered<T>();
        }

        public void ValidateObject(Dataset dataset)
        {
            this.Converter.ValidateWrappedObject(dataset);
        }
    }
}
