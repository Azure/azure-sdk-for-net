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
namespace Microsoft.Hadoop.Client.InversionOfControl
{
    using System;
    using Microsoft.Hadoop.Client.ClientLayer;
    using Microsoft.Hadoop.Client.HadoopJobSubmissionPocoClient;
    using Microsoft.Hadoop.Client.HadoopJobSubmissionPocoClient.RemoteHadoop;
    using Microsoft.Hadoop.Client.HadoopJobSubmissionRestCleint.Remote;
    using Microsoft.Hadoop.Client.Storage;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;

    /// <summary>
    /// Registers Hadoop Client services with the Service Locator.
    /// </summary>
    internal class HadoopJobSubmissionRegistrar : IServiceLocationRegistrar
    {
        /// <inheritdoc />
        public void Register(IServiceLocationRuntimeManager manager, IServiceLocator locator)
        {
            if (ReferenceEquals(manager, null))
            {
                throw new ArgumentNullException("manager");
            }

            var clientManager = new HadoopClientFactoryManager(manager, locator);
            manager.RegisterInstance<IHadoopClientFactoryManager>(clientManager);
            clientManager.RegisterFactory<BasicAuthCredential, IRemoteHadoopClientFactory, RemoteHadoopClientFactory>();
            manager.RegisterType<IRemoteHadoopJobSubmissionPocoClientFactory, RemoteHadoopJobSubmissionPocoClientFactory>();
            // manager.RegisterType<IHadoopLocalJobSubmissionRestClientFactory, HadoopLocalJobSubmissionRestClientFactory>();
            manager.RegisterType<IHadoopRemoteJobSubmissionRestClientFactory, HadoopRemoteJobSubmissionRestClientFactory>();
            manager.RegisterType<IHadoopApplicationHistoryRestClientFactory, HadoopApplicationHistoryRestClientFactory>();
            manager.RegisterType<IWabStorageAbstractionFactory, WabStorageAbstractionFactory>();
        }
    }
}
