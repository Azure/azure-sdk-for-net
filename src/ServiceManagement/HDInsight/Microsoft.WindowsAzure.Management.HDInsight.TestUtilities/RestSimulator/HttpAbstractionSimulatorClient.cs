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
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Logging;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;

    internal class HttpAbstractionSimulatorClient : DisposableObject, IHttpClientAbstraction
    {
        private HttpAbstractionSimulatorFactory factory;
        private IHttpClientAbstraction underlying;
        private Func<IHttpClientAbstraction, IHttpResponseMessageAbstraction> asyncMoc;

        public HttpAbstractionSimulatorClient(HttpAbstractionSimulatorFactory factory, IHttpClientAbstraction underlying, Func<IHttpClientAbstraction, IHttpResponseMessageAbstraction> asyncMoc)
        {
            this.factory = factory;
            this.underlying = underlying;
            this.asyncMoc = asyncMoc;
            this.Logger = new Logger();
        }

        public HttpMethod Method
        {
            get { return this.underlying.Method; }
            set { this.underlying.Method = value; }
        }

        public Uri RequestUri
        {
            get { return this.underlying.RequestUri; }
            set { this.underlying.RequestUri = value; }
        }
        public HttpContent Content
        {
            get { return this.underlying.Content; }
            set { this.underlying.Content = value; }
        }

        public IDictionary<string, string> RequestHeaders
        {
            get { return this.underlying.RequestHeaders; }
        }

        public string ContentType
        {
            get { return this.underlying.ContentType; }
            set { this.underlying.ContentType = value; }
        }

        public TimeSpan Timeout
        {
            get { return this.underlying.Timeout; }
            set { this.underlying.Timeout = value; }
        }

        public async Task<IHttpResponseMessageAbstraction> SendAsync()
        {
            var loc = this.asyncMoc;
            IHttpResponseMessageAbstraction responseMessage;
            if (loc.IsNotNull())
            {
                responseMessage = await Task.FromResult(loc(this));
            }
            else
            {
                responseMessage = await this.underlying.SendAsync();
            }

            this.factory.Clients.Add(new Tuple<IHttpClientAbstraction, IHttpResponseMessageAbstraction>(this, responseMessage));
            return responseMessage;
        }

        public void Log(Severity severity, Verbosity verbosity, string message)
        {
        }

        public ILogger Logger { get; private set; }
    }
}
