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
    /// <summary>
    /// Credentials to use when connecting to a Windows Azure Storage Account.
    /// </summary>
    internal class WindowsAzureStorageAccountCredentials
    {
        /// <summary>
        /// Gets or sets the Name of the Storage Account.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Key for the Storage Account.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the ContainerName being used in the Storage Account.
        /// </summary>
        public string ContainerName { get; set; }
    }
}
