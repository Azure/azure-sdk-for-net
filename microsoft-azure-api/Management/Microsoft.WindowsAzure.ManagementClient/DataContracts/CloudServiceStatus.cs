//-----------------------------------------------------------------------
// <copyright file="CloudServiceStatus.cs" company="Microsoft">
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
//    Contains code for the CloudServiceStatus enumeration.
// </summary>
//-----------------------------------------------------------------------

using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    /// <summary>
    /// Status values for a Windows Azure cloud service.
    /// </summary>
    [DataContract]
    public enum CloudServiceStatus
    {
        /// <summary>
        /// The cloud service is being created.
        /// </summary>
        [EnumMember]
        Creating,

        /// <summary>
        /// The cloud service has been created.
        /// </summary>
        [EnumMember]
        Created,

        /// <summary>
        /// The cloud service is being deleted.
        /// </summary>
        [EnumMember]
        Deleting,

        /// <summary>
        /// The cloud service has been deleted.
        /// </summary>
        [EnumMember]
        Deleted,

        /// <summary>
        /// The status of the cloud service is changing.
        /// </summary>
        [EnumMember]
        Changing,

        /// <summary>
        /// The DNS name for the cloud service is being resolved.
        /// </summary>
        [EnumMember]
        ResolvingDns
    }
}
