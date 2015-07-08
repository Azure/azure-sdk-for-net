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
namespace Microsoft.WindowsAzure.Management.HDInsight
{
    using System;
    using System.Globalization;
    using System.Security.Authentication;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;

    /// <summary>
    ///     Provides a factory for a class that Abstracts Http client requests.
    /// </summary>
    internal class HDInsightHttpClientAbstractionFactory : IHDInsightHttpClientAbstractionFactory
    {
        /// <inheritdoc />
        public IHttpClientAbstraction Create(IHDInsightSubscriptionCredentials credentials, HDInsight.IAbstractionContext context, bool ignoreSslErrors)
        {
            IHDInsightCertificateCredential certCreds = credentials as IHDInsightCertificateCredential;
            IHDInsightAccessTokenCredential tokenCreds = credentials as IHDInsightAccessTokenCredential;
            if (certCreds != null)
            {
                return
                    ServiceLocator.Instance.Locate<IHttpClientAbstractionFactory>()
                                  .Create(certCreds.Certificate, context, ignoreSslErrors);
            }
            if (tokenCreds != null)
            {
                return
                    ServiceLocator.Instance.Locate<IHttpClientAbstractionFactory>()
                                  .Create(tokenCreds.AccessToken, context, ignoreSslErrors);
            }
            throw new NotSupportedException("Credential Type is not supported");
        }

        /// <inheritdoc />
        public IHttpClientAbstraction Create(IHDInsightSubscriptionCredentials credentials, bool ignoreSslErrors)
        {
            IHDInsightCertificateCredential certCreds = credentials as IHDInsightCertificateCredential;
            IHDInsightAccessTokenCredential tokenCreds = credentials as IHDInsightAccessTokenCredential;
            if (certCreds != null)
            {
                return
                    ServiceLocator.Instance.Locate<IHttpClientAbstractionFactory>()
                                  .Create(certCreds.Certificate, ignoreSslErrors);
            }
            if (tokenCreds != null)
            {
                return
                    ServiceLocator.Instance.Locate<IHttpClientAbstractionFactory>()
                                  .Create(tokenCreds.AccessToken, ignoreSslErrors);
            }
            throw new NotSupportedException("Credential Type is not supported");
        }

        /// <inheritdoc />
        public IHttpClientAbstraction Create(HDInsight.IAbstractionContext context, bool ignoreSslErrors)
        {
            return ServiceLocator.Instance.Locate<IHttpClientAbstractionFactory>()
                              .Create(context, ignoreSslErrors);
        }

        /// <inheritdoc />
        public IHttpClientAbstraction Create(bool ignoreSslErrors)
        {
            return ServiceLocator.Instance.Locate<IHttpClientAbstractionFactory>().Create(ignoreSslErrors);
        }
    }
}
