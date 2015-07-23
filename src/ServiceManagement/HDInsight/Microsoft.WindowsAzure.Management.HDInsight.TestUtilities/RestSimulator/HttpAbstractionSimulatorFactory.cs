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
    using System.Security.Cryptography.X509Certificates;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;

    internal class HttpAbstractionSimulatorFactory : HttpClientAbstractionFactoryBase, IHttpClientAbstractionFactory
    {
        public HttpAbstractionSimulatorFactory(IHttpClientAbstractionFactory underlying)
        {
            this.underlying = underlying;
            this.Clients = new List<Tuple<IHttpClientAbstraction, IHttpResponseMessageAbstraction>>();
        }

        public Func<IHttpClientAbstraction, IHttpResponseMessageAbstraction> AsyncMock { get; set; }

        private IHttpClientAbstractionFactory underlying;

        public ICollection<Tuple<IHttpClientAbstraction, IHttpResponseMessageAbstraction>> Clients { get; private set; }

        public override IHttpClientAbstraction Create(X509Certificate2 cert, bool ignoreSslErrors)
        {
            var loc = this.AsyncMock;
            if (loc.IsNotNull())
            {
                return new HttpAbstractionSimulatorClient(this, this.underlying.Create(cert, ignoreSslErrors), loc);
            }
            else
            {
                return new HttpAbstractionSimulatorClient(this, this.underlying.Create(cert, ignoreSslErrors), null);
            }
        }

        public override IHttpClientAbstraction Create(X509Certificate2 cert, HDInsight.IAbstractionContext context, bool ignoreSslErrors)
        {
            var loc = this.AsyncMock;
            if (loc.IsNotNull())
            {
                return new HttpAbstractionSimulatorClient(this, this.underlying.Create(cert, context, ignoreSslErrors), loc);
            }
            else
            {
                return new HttpAbstractionSimulatorClient(this, this.underlying.Create(cert, context, ignoreSslErrors), null);
            }
        }

        public override IHttpClientAbstraction Create(string token, bool ignoreSslErrors)
        {
            var loc = this.AsyncMock;
            if (loc.IsNotNull())
            {
                return new HttpAbstractionSimulatorClient(this, this.underlying.Create(token, ignoreSslErrors), loc);
            }
            else
            {
                return new HttpAbstractionSimulatorClient(this, this.underlying.Create(token, ignoreSslErrors), null);
            }
        }

        public override IHttpClientAbstraction Create(string token, HDInsight.IAbstractionContext context, bool ignoreSslErrors)
        {
            var loc = this.AsyncMock;
            if (loc.IsNotNull())
            {
                return new HttpAbstractionSimulatorClient(this, this.underlying.Create(token, context, ignoreSslErrors), loc);
            }
            else
            {
                return new HttpAbstractionSimulatorClient(this, this.underlying.Create(token, context, ignoreSslErrors), null);
            }
        }

        public override IHttpClientAbstraction Create(bool ignoreSslErrors)
        {
            var loc = this.AsyncMock;
            if (loc.IsNotNull())
            {
                return new HttpAbstractionSimulatorClient(this, this.underlying.Create(ignoreSslErrors), loc);
            }
            else
            {
                return new HttpAbstractionSimulatorClient(this, this.underlying.Create(ignoreSslErrors), null);
            }
        }

        public override IHttpClientAbstraction Create(bool ignoreSslErrors, bool allowAutoRedirect)
        {
            var loc = this.AsyncMock;
            if (loc.IsNotNull())
            {
                return new HttpAbstractionSimulatorClient(this, this.underlying.Create(ignoreSslErrors, allowAutoRedirect), loc);
            }
            else
            {
                return new HttpAbstractionSimulatorClient(this, this.underlying.Create(ignoreSslErrors, allowAutoRedirect), null);
            }
        }

        public override IHttpClientAbstraction Create(HDInsight.IAbstractionContext context, bool ignoreSslErrors)
        {
            var loc = this.AsyncMock;
            if (loc.IsNotNull())
            {
                return new HttpAbstractionSimulatorClient(this, this.underlying.Create(context, ignoreSslErrors), loc);
            }
            else
            {
                return new HttpAbstractionSimulatorClient(this, this.underlying.Create(context, ignoreSslErrors), null);
            }
        }
    }
}
