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
namespace Microsoft.Hadoop.Client
{
    using System;

    /// <summary>
    /// Provides Connection Credentials that can be used to connect to a
    /// Hadoop cluster.
    /// </summary>
    public class BasicAuthCredential : IJobSubmissionClientCredential
    {
        /// <summary>
        /// Gets or sets the Uri for the server to connect to.
        /// </summary>
        public Uri Server { get; set; }

        /// <summary>
        /// Gets or sets the UserName for the connection.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password for the connection.
        /// </summary>
        public string Password { get; set; }
    }
}
