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
    /// Specifies which user accounts on a compute node should have access to
    /// the private data of a certificate.
    /// </summary>
    [Flags]
    public enum CertificateVisibility
    {
        /// <summary>
        /// The certificate has no visibility.
        /// </summary>
        None = 0,

        /// <summary>
        /// The user account under which the start task is run.
        /// </summary>
        StartTask = 1,
        
        /// <summary>
        /// The accounts under which job tasks are run.
        /// </summary>
        Task = 2,
        
        /// <summary>
        /// The accounts under which users remotely access the node (using
        /// Remote Desktop).
        /// </summary>
        RemoteUser = 4,

        /// <summary>
        /// The service reported an option that is not recognized by this
        /// version of the Batch client.
        /// </summary>
        Unmapped = 8,
    }
}
