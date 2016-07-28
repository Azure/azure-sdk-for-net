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
    
    /// <summary>
    /// The state of a certificate
    /// </summary>
    public enum CertificateState
    {
        /// <summary>
        /// The certificate is available for use in pools.
        /// </summary>
        Active,
        
        /// <summary>
        /// The user has requested that the certificate be deleted, but the
        /// delete operation has not yet completed. You may not reference the
        /// certificate when creating or updating pools .
        /// </summary>
        Deleting,
        
        /// <summary>
        /// The user requested that the certificate be deleted, but there are
        /// pools that still have references to the certificate, or it is
        /// still installed on one or more compute nodes.
        /// </summary>
        DeleteFailed,
    }
}
