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
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.CustomMessageHandlers;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;

    internal class HadoopApplicationHistoryRestClientFactory : IHadoopApplicationHistoryRestClientFactory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope",
            Justification = "When the rest read client is disposed, this will be as well.")]
        public IHadoopApplicationHistoryRestClient Create(BasicAuthCredential credentials, IAbstractionContext context, bool ignoreSslErrors)
        {
            IHadoopApplicationHistoryRestReadClient readProxy = new HadoopApplicationHistoryRestReadClient(
                credentials.Server,
                new HttpRestClientConfiguration(new HadoopRestWebRequestHandler(credentials, ignoreSslErrors),
                   new[] { new HttpLoggingHandler(context.Logger) },
                   new HttpRestClientRetryPolicy(RetryPolicyFactory.CreateExponentialRetryPolicy())));

            return new HadoopApplicationHistoryRestClient(readProxy);
        }
    }
}
