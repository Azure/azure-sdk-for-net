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
    /// <summary>
    /// The elevation level of the user account used by the Batch service to execute a task.
    /// </summary>
    public enum ElevationLevel
    {
        /// <summary>
        /// The user has standard access permissions.
        /// </summary>
        NonAdmin,

        /// <summary>
        /// The user has elevated access and operates with full Administrator permissions.
        /// </summary>
        Admin
    }
}
