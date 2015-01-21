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
namespace Microsoft.Hadoop.Client.HadoopStorageRestClient
{
    using System;

    internal interface IHadoopStorageRestClientFactory
    {
        /// <summary>
        /// Creates a new instance of a HadoopStorageRest client.
        /// </summary>
        /// <param name="credential">
        /// The connection credentials to use when connecting to the instance.
        /// </param>
        /// <param name="ignoreSslErrors">
        /// Specifies that server side SSL errors should be be ignored.
        /// </param>
        /// <param name="timeout">Maximum time span for storage commands.</param>
        /// <returns>
        /// A new instance of an HadoopStorageRest client.
        /// </returns>
        IHadoopStorageRestClient Create(IStorageClientCredential credential, bool ignoreSslErrors, TimeSpan timeout);
    }
}
