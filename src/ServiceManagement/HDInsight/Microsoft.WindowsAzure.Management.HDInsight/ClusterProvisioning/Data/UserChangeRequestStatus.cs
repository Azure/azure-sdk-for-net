// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The type of a user change request.
    /// </summary>
    public enum UserChangeRequestUserType
    {
        /// <summary>
        /// An Rdp request.
        /// </summary>
        Rdp,

        /// <summary>
        /// An http request.
        /// </summary>
        Http
    }

    /// <summary>
    /// The type of change request to make.
    /// </summary>
    public enum UserChangeRequestOperationType
    {
        /// <summary>
        /// Enable the user.
        /// </summary>
        Enable,

        /// <summary>
        /// Disable the user.
        /// </summary>
        Disable
    }

    /// <summary>
    /// The status of the change request.
    /// </summary>
    internal enum UserChangeRequestOperationStatus
    {
        /// <summary>
        /// The request is pending.
        /// </summary>
        Pending,

        /// <summary>
        /// The request is completed.
        /// </summary>
        Completed,

        /// <summary>
        /// The request resulted in an error.
        /// </summary>
        Error
    }

    /// <summary>
    /// Provides the status of the User Change Request.
    /// </summary>
    internal class UserChangeRequestStatus
    {
        /// <summary>
        /// Gets or sets the type of operation requested.
        /// </summary>
        public UserChangeRequestOperationType OperationType { get; set; }

        /// <summary>
        /// Gets or sets the type of user change requested.
        /// </summary>
        public UserChangeRequestUserType UserType { get; set; }

        /// <summary>
        /// Gets or sets the time the request was issued.
        /// </summary>
        public DateTime RequestIssueDate { get; set; }

        /// <summary>
        /// Gets or sets the state of the request.
        /// </summary>
        public UserChangeRequestOperationStatus State { get; set; }

        /// <summary>
        /// Gets or sets any error details relating to the request.
        /// </summary>
        public PayloadErrorDetails ErrorDetails { get; set; }
    }
}
