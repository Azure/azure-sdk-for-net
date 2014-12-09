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
namespace Microsoft.Hadoop.Client.ClientLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Provides a manager for registering and creating hadoop clients.
    /// </summary>
    internal interface IHadoopClientFactoryManager 
    {
        /// <summary>
        /// Method to register Hadoop Client factories.
        /// </summary>
        /// <typeparam name="TCredentials">The Type of credentials used by the factory to register.</typeparam>
        /// <typeparam name="TServiceInterface">The client factory interface.</typeparam>
        /// <typeparam name="TServiceImplementation">The concrete to be registered.</typeparam>
        void RegisterFactory<TCredentials, TServiceInterface, TServiceImplementation>()
            where TCredentials : IJobSubmissionClientCredential
            where TServiceInterface : IHadoopClientFactory<TCredentials>
            where TServiceImplementation : class, TServiceInterface;

        /// <summary>
        /// Removes a factory registration.
        /// </summary>
        /// <typeparam name="TCredentials">The Type of credentials used by the factory to remove.</typeparam>
        void UnregisterFactory<TCredentials>() where TCredentials : IJobSubmissionClientCredential;

        /// <summary>
        /// Creates a new Hadoop Client given the credentials.
        /// </summary>
        /// <param name="credentials">
        /// The credentials.
        /// </param>
        /// <param name="userAgentString">
        /// Custome useragent string to pass.
        /// </param>
        /// <returns>
        /// A new Hadoop client capable of communicating with a Hadoop cluster.
        /// </returns>
        IJobSubmissionClient Create(IJobSubmissionClientCredential credentials, string userAgentString);

        /// <summary>
        /// Creates a new Hadoop Application History Client with the given credentials.
        /// </summary>
        /// <param name="credentials">
        /// The credentials.
        /// </param>
        /// <returns>
        /// A new Hadoop Application History client capable of communicating with a Hadoop cluster and listing application history.
        /// </returns>
        IHadoopApplicationHistoryClient CreateHadoopApplicationHistoryClient(IJobSubmissionClientCredential credentials);
    }
}
