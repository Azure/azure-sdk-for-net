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

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// The format definition of a storage.
    /// </summary>
    public abstract class StorageFormat : IRegisteredType
    {
        /// <summary>
        /// The serializer.
        /// </summary>
        public string Serializer { get; set; }

        /// <summary>
        /// The deserializer.
        /// </summary>
        public string Deserializer { get; set; }
        
#if ADF_INTERNAL
        /// <summary>
        /// Encryption.
        /// </summary>
        public string Encryption { get; set; }
#endif
    }
}