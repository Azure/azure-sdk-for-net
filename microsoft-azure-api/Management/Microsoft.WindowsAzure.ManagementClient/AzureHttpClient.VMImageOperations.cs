//-----------------------------------------------------------------------
// <copyright file="AzureHttpClient.StorageAccountOperations.cs" company="Microsoft">
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
//    Contains code for the StorageAccount operations on the AzureHttpClient class.
// </summary>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    /// <summary>
    /// The main class of the client library, contains all of the Async methods that 
    /// represent Azure APIs
    /// </summary>
    public partial class AzureHttpClient
    {
        /// <summary>
        /// Begins an asychronous operation to list the storage accounts in the subscription.
        /// </summary>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a <see cref="StorageAccountPropertiesCollection"/></returns>
        public Task<OSImageCollection> ListVMOSImagesAsync(CancellationToken token = default(CancellationToken))
        {
            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.OSImages));

            return StartGetTask<OSImageCollection>(message, token);
        }
    }
}
