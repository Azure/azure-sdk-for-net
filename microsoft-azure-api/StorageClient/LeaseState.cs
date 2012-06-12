//-----------------------------------------------------------------------
// <copyright file="LeaseState.cs" company="Microsoft">
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
// <summary>
//    Contains code for the LeaseState enumeration.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    /// <summary>
    /// The lease state of a resource.
    /// </summary>
    public enum LeaseState
    {
        /// <summary>
        /// The lease state is not specified.
        /// </summary>
        Unspecified,

        /// <summary>
        /// The lease is in the Available state.
        /// </summary>
        Available,

        /// <summary>
        /// The lease is in the Leased state.
        /// </summary>
        Leased,

        /// <summary>
        /// The lease is in the Expired state.
        /// </summary>
        Expired,

        /// <summary>
        /// The lease is in the Breaking state.
        /// </summary>
        Breaking,

        /// <summary>
        /// The lease is in the Broken state.
        /// </summary>
        Broken,
    }
}
