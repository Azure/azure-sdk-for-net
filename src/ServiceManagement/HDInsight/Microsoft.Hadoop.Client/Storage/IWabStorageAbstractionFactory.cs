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
namespace Microsoft.Hadoop.Client.Storage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Provides a factory for connecting to a Wab (Windows Azure Blob) storage account.
    /// </summary>
    internal interface IWabStorageAbstractionFactory
    {
        /// <summary>
        /// Creates a new instance of the WabStroageAbstraction.
        /// </summary>
        /// <param name="credentials">
        /// The credentials to be used to connect to the storage account.
        /// </param>
        /// <returns>
        /// A new Windows Azure Storage Account abstraction object.
        /// </returns>
        IStorageAbstraction Create(WindowsAzureStorageAccountCredentials credentials);
    }
}
