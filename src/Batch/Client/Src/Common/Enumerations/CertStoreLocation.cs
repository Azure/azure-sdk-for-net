// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.

// 

namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Linq;
    
    //TODO: If we are doing major breaking changes we could consider renaming this type to "Certificate..."

    /// <summary>
    /// The location of a certificate store on a pool's compute nodes.
    /// </summary>
    public enum CertStoreLocation
    {
        /// <summary>
        /// The X.509 certificate store used by the current user.
        /// </summary>
        CurrentUser,
        
        /// <summary>
        /// The X.509 certificate store assigned to the local machine.
        /// </summary>
        LocalMachine,

        /// <summary>
        /// The service reported an option that is not recognized by this
        /// version of the Batch client.
        /// </summary>
        Unmapped,
    }
}
