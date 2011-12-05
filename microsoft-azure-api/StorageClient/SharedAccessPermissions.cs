//-----------------------------------------------------------------------
// <copyright file="SharedAccessPermissions.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
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
// <summary>
//    Contains code for the SharedAccessPermissions enumeration.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Text;

    /// <summary>
    /// Specifies the set of possible permissions for a shared access policy.
    /// </summary>
    [Flags]
    public enum SharedAccessPermissions
    {
        /// <summary>
        /// No shared access granted.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// Read access granted.
        /// </summary>
        Read = 0x1,

        /// <summary>
        /// Write access granted.
        /// </summary>
        Write = 0x2,

        /// <summary>
        /// Delete access granted for blobs.
        /// </summary>
        Delete = 0x4,

        /// <summary>
        /// List access granted.
        /// </summary>
        List = 0x8
    }
}