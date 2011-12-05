//-----------------------------------------------------------------------
// <copyright file="LeaseAction.cs" company="Microsoft">
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
//    Contains code for the LeaseAction enumeration.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    /// <summary>
    /// Describes actions that can be performed on a lease.
    /// </summary>
    public enum LeaseAction
    {
        /// <summary>
        /// Acquire the lease.
        /// </summary>
        Acquire,

        /// <summary>
        /// Renew the lease.
        /// </summary>
        Renew,

        /// <summary>
        /// Release the lease.
        /// </summary>
        Release,

        /// <summary>
        /// Break the lease.
        /// </summary>
        Break
    }
}