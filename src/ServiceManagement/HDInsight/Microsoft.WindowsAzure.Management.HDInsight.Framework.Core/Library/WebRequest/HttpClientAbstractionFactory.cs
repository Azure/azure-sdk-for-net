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
namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest
{
    using System.Security.Cryptography.X509Certificates;

    internal class HttpClientAbstractionFactory : HttpClientAbstractionFactoryBase
    {
        public override IHttpClientAbstraction Create(IAbstractionContext context, bool ignoreSslErrors)
        {
            return HttpClientAbstraction.Create(context, ignoreSslErrors);
        }

        public override IHttpClientAbstraction Create(X509Certificate2 cert, bool ignoreSslErrors)
        {
            return HttpClientAbstraction.Create(cert, ignoreSslErrors);
        }

        public override IHttpClientAbstraction Create(X509Certificate2 cert, IAbstractionContext context, bool ignoreSslErrors)
        {
            return HttpClientAbstraction.Create(cert, context, ignoreSslErrors);
        }

        public override IHttpClientAbstraction Create(string token, bool ignoreSslErrors)
        {
            return HttpClientAbstraction.Create(token, ignoreSslErrors);
        }

        public override IHttpClientAbstraction Create(string token, IAbstractionContext context, bool ignoreSslErrors)
        {
            return HttpClientAbstraction.Create(token, context, ignoreSslErrors);
        }

        public override IHttpClientAbstraction Create(bool ignoreSslErrors)
        {
            return HttpClientAbstraction.Create(ignoreSslErrors);
        }

        public override IHttpClientAbstraction Create(bool ignoreSslErrors, bool allowAutoRedirect)
        {
            return HttpClientAbstraction.Create(ignoreSslErrors, allowAutoRedirect);
        }
    }
}
