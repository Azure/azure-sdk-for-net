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
    /// <summary>
    /// Class that wraps an error status of an HDInsight Cluster.
    /// </summary>
    public sealed class ClusterErrorStatus
    {
        /// <summary>
        /// Gets the error code of the error status.
        /// </summary>
        public int HttpCode { get; private set; }

        /// <summary>
        /// Gets or sets the message detailing the error status.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets the operation that triggered the error status.
        /// </summary>
        public string OperationType { get; private set; }

        internal ClusterErrorStatus(int httpCode, string message, string operationType)
        {
            this.HttpCode = httpCode;
            this.Message = message;
            this.OperationType = operationType;
        }

        internal ClusterErrorStatus()
        {
        }
    }
}
