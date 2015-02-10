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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;

    internal class HadoopRestWebRequestHandler : HttpClientHandler
    {
        private readonly string base64AuthorizationCreds;

        public HadoopRestWebRequestHandler(BasicAuthCredential credentials, bool ignoreSslErrors)
        {
            var byteArray = Encoding.ASCII.GetBytes(credentials.UserName + ":" + credentials.Password);
            this.base64AuthorizationCreds = Convert.ToBase64String(byteArray);

            if (ignoreSslErrors)
            {
                ServicePointManager.ServerCertificateValidationCallback += (s, cert, chain, ssl) => true;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Validated by the runtime.", MessageId = "0")]
        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("accept", "application/json");
            request.Headers.Add("useragent", "HDInsight .NET SDK");

            request.Headers.Add("Authorization", "Basic " + this.base64AuthorizationCreds);

            return base.SendAsync(request, cancellationToken);
        }
    }
}
