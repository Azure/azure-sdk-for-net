//-----------------------------------------------------------------------
// <copyright file="OperationStatus.cs" company="Microsoft">
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
//    Contains code for the OperationStatus enum.
// </summary>
//-----------------------------------------------------------------------

using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    /// <summary>
    /// Represents the status of an ongoing, long-running operation
    /// </summary>
    [DataContract(Name = "Status")]
    public enum OperationStatus
    {
        /// <summary>
        /// The operation is in progress
        /// </summary>
        [EnumMember]
        InProgress,

        /// <summary>
        /// The operation has succeeded.
        /// </summary>
        [EnumMember]
        Succeeded,

        /// <summary>
        /// The operation failed.
        /// </summary>
        [EnumMember]
        Failed
    }
}
