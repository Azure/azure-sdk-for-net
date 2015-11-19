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
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;

    internal class HadoopClientFactoryManager : IHadoopClientFactoryManager
    {
        private Dictionary<Type, Type> credentialsMap = new Dictionary<Type, Type>();
        private IServiceLocationRuntimeManager manager;
        private IServiceLocator locator;

        public HadoopClientFactoryManager(IServiceLocationRuntimeManager manager, IServiceLocator locator)
        {
            this.manager = manager;
            this.locator = locator;
        }

        /// <inheritdoc />
        public void RegisterFactory<T, S, R>()
            where T : IJobSubmissionClientCredential
                                               where S : IHadoopClientFactory<T>
                                               where R : class, S
        {
            this.credentialsMap.Add(typeof(T), typeof(S));
            this.manager.RegisterType<S, R>();
        }

        /// <inheritdoc />
        public void UnregisterFactory<T>() where T : IJobSubmissionClientCredential
        {
            var type = typeof(T);
            if (this.credentialsMap.ContainsKey(type))
            {
                this.credentialsMap.Remove(type);
            }
        }

        /// <inheritdoc />
        public IJobSubmissionClient Create(IJobSubmissionClientCredential credentials)
        {
            credentials.ArgumentNotNull("credentials");
            Type type;
            if (!this.credentialsMap.TryGetValue(credentials.GetType(), out type))
            {
                throw new InvalidOperationException("Attempt to use a Hadoop credentials class that has not been registered.");
            }
            var factory = this.locator.Locate(type);
            var createMethod = factory.GetType().GetMethod("Create", new Type[] { credentials.GetType() });
            return (IJobSubmissionClient)createMethod.Invoke(factory, new object[] { credentials });
        }

        /// <inheritdoc />
        public IJobSubmissionClient Create(IJobSubmissionClientCredential credentials, string userAgentString)
        {
            credentials.ArgumentNotNull("credentials");
            Type type;
            if (!this.credentialsMap.TryGetValue(credentials.GetType(), out type))
            {
                throw new InvalidOperationException("Attempt to use a Hadoop credentials class that has not been registered.");
            }
            var factory = this.locator.Locate(type);
            var createMethod = factory.GetType().GetMethod("Create", new Type[] { credentials.GetType(), typeof(string) });
            return (IJobSubmissionClient)createMethod.Invoke(factory, new object[] { credentials, userAgentString });
        }

        public IHadoopApplicationHistoryClient CreateHadoopApplicationHistoryClient(IJobSubmissionClientCredential credentials)
        {
            credentials.ArgumentNotNull("credentials");
            Type type;
            if (!this.credentialsMap.TryGetValue(credentials.GetType(), out type))
            {
                throw new InvalidOperationException("Attempt to use a Hadoop credentials class that has not been registered.");
            }
            var factory = this.locator.Locate(type);
            var createMethod = factory.GetType().GetMethod("CreateHadoopApplicationHistoryClient");
            return (IHadoopApplicationHistoryClient)createMethod.Invoke(factory, new object[] { credentials });
        }
    }
}
