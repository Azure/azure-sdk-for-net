// -----------------------------------------------------------------------------------------
// <copyright file="SharedAccessQueuePermissions.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Queue
{
    using System;

    /// <summary>
    /// Specifies the set of possible permissions for a shared access queue policy.
    /// </summary>
    [Flags]
    public enum SharedAccessQueuePermissions
    {
        /// <summary>
        /// No shared access granted.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// Permission to peek messages and get queue metadata granted.
        /// </summary>
        Read = 0x1,

        /// <summary>
        /// Permission to get and delete messages granted.
        /// </summary>
        ProcessMessages = 0x2,

        /// <summary>
        /// Permission to add messages granted.
        /// </summary>
        Add = 0x4,

        /// <summary>
        /// Permissions to update messages granted.
        /// </summary>
        Update = 0x8
    }
}
