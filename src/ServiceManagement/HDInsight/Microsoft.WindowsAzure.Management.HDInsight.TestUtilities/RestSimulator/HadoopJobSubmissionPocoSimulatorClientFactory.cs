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
namespace Microsoft.WindowsAzure.Management.HDInsight.TestUtilities.RestSimulator
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.HadoopJobSubmissionPocoClient;
    using Microsoft.Hadoop.Client.HadoopJobSubmissionPocoClient.RemoteHadoop;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.JobSubmission.PocoClient;

    internal class HadoopJobSubmissionPocoSimulatorClientFactory : IRemoteHadoopJobSubmissionPocoClientFactory, IHDInsightJobSubmissionPocoClientFactory
    {
        internal static IDictionary<string, HadoopJobSubmissionPocoSimulatorClient> pocoSimulators = new Dictionary<string, HadoopJobSubmissionPocoSimulatorClient>();
        public IHadoopJobSubmissionPocoClient Create(IJobSubmissionClientCredential credentials, IAbstractionContext context, bool ignoreSslErrors, string userAgentString)
        {
            var remoteCredentials = credentials as BasicAuthCredential;
            if (remoteCredentials == null)
            {
                throw new NotSupportedException();
            }
            string clusterKey = remoteCredentials.Server.AbsoluteUri.ToUpperInvariant();
            if (pocoSimulators.ContainsKey(clusterKey))
            {
                var simulator = pocoSimulators[clusterKey];
                simulator.credentials = remoteCredentials;
                simulator.context = context;
                return simulator;
            }
            else
            {
                var simulator = new HadoopJobSubmissionPocoSimulatorClient(remoteCredentials, context, userAgentString);
                pocoSimulators.Add(clusterKey, simulator);
                return simulator;
            }
        }
    }
}
