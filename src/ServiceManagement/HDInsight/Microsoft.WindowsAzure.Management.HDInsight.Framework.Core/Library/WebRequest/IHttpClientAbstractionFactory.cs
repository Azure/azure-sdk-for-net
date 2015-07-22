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

    /// <summary>
    ///     Provides a factory for a class that Abstracts Http client requests.
    /// </summary>
#if Non_Public_SDK
    public interface IHttpClientAbstractionFactory
#else
    internal interface IHttpClientAbstractionFactory
#endif
    {
        /// <summary>
        ///     Creates a new HttpClientAbstraction class.
        /// </summary>
        /// <param name="cert">
        ///     The X509 cert to use.
        /// </param>
        /// <returns>
        ///     A new instance of the HttpClientAbstraction.
        /// </returns>
        IHttpClientAbstraction Create(X509Certificate2 cert);

        /// <summary>
        ///     Creates a new HttpClientAbstraction class.
        /// </summary>
        /// <param name="cert">
        ///     The X509 cert to use.
        /// </param>
        /// <param name="context">
        /// The abstraction context to use.
        /// </param>
        /// <returns>
        ///     A new instance of the HttpClientAbstraction.
        /// </returns>
        IHttpClientAbstraction Create(X509Certificate2 cert, IAbstractionContext context);

        /// <summary>
        ///     Creates a new HttpClientAbstraction class.
        /// </summary>
        /// <param name="token">
        ///     The access token to use.
        /// </param>
        /// <returns>
        ///     A new instance of the HttpClientAbstraction.
        /// </returns>
        IHttpClientAbstraction Create(string token);

        /// <summary>
        ///     Creates a new HttpClientAbstraction class.
        /// </summary>
        /// <param name="token">
        ///     The access token to use.
        /// </param>
        /// <param name="context">
        /// The abstraction context to use.
        /// </param>
        /// <returns>
        ///     A new instance of the HttpClientAbstraction.
        /// </returns>
        IHttpClientAbstraction Create(string token, IAbstractionContext context);

        /// <summary>
        ///     Creates a new HttpClientAbstraction class.
        /// </summary>
        /// <returns>
        ///     A new instance of the HttpClientAbstraction.
        /// </returns>
        IHttpClientAbstraction Create();

        /// <summary>
        ///     Creates a new HttpClientAbstraction class.
        /// </summary>
        /// <param name="context">
        /// The abstraction context to use.
        /// </param>
        /// <returns>
        ///     A new instance of the HttpClientAbstraction.
        /// </returns>
        IHttpClientAbstraction Create(IAbstractionContext context);

        /// <summary>
        ///     Creates a new HttpClientAbstraction class.
        /// </summary>
        /// <param name="cert">
        ///     The X509 cert to use.
        /// </param>
        /// <param name="ignoreSslErrors">
        /// Instructs that server certificate errors should be ignored.
        /// </param>
        /// <returns>
        ///     A new instance of the HttpClientAbstraction.
        /// </returns>
        IHttpClientAbstraction Create(X509Certificate2 cert, bool ignoreSslErrors);

        /// <summary>
        ///     Creates a new HttpClientAbstraction class.
        /// </summary>
        /// <param name="cert">
        ///     The X509 cert to use.
        /// </param>
        /// <param name="context">
        /// The abstraction context to use.
        /// </param>
        /// <param name="ignoreSslErrors">
        /// Instructs that server certificate errors should be ignored.
        /// </param>
        /// <returns>
        ///     A new instance of the HttpClientAbstraction.
        /// </returns>
        IHttpClientAbstraction Create(X509Certificate2 cert, IAbstractionContext context, bool ignoreSslErrors);

        /// <summary>
        ///     Creates a new HttpClientAbstraction class.
        /// </summary>
        /// <param name="token">
        ///     The access token to use.
        /// </param>
        /// <param name="ignoreSslErrors">
        /// Instructs that server certificate errors should be ignored.
        /// </param>
        /// <returns>
        ///     A new instance of the HttpClientAbstraction.
        /// </returns>
        IHttpClientAbstraction Create(string token, bool ignoreSslErrors);

        /// <summary>
        ///     Creates a new HttpClientAbstraction class.
        /// </summary>
        /// <param name="token">
        ///     The access token to use.
        /// </param>
        /// <param name="context">
        /// The abstraction context to use.
        /// </param>
        /// <param name="ignoreSslErrors">
        /// Instructs that server certificate errors should be ignored.
        /// </param>
        /// <returns>
        ///     A new instance of the HttpClientAbstraction.
        /// </returns>
        IHttpClientAbstraction Create(string token, IAbstractionContext context, bool ignoreSslErrors);

        /// <summary>
        ///     Creates a new HttpClientAbstraction class.
        /// </summary>
        /// <param name="ignoreSslErrors">
        /// Instructs that server certificate errors should be ignored.
        /// </param>
        /// <returns>
        ///     A new instance of the HttpClientAbstraction.
        /// </returns>
        IHttpClientAbstraction Create(bool ignoreSslErrors);

        /// <summary>
        ///     Creates a new HttpClientAbstraction class.
        /// </summary>
        /// <param name="ignoreSslErrors">
        /// Instructs that server certificate errors should be ignored.
        /// </param>
        /// <param name="allowAutoRedirect">Allow auto redirection.</param>
        /// <returns>
        ///     A new instance of the HttpClientAbstraction.
        /// </returns>
        IHttpClientAbstraction Create(bool ignoreSslErrors, bool allowAutoRedirect);

        /// <summary>
        ///     Creates a new HttpClientAbstraction class.
        /// </summary>
        /// <param name="context">
        /// The abstraction context to use.
        /// </param>
        /// <param name="ignoreSslErrors">
        /// Instructs that server certificate errors should be ignored.
        /// </param>
        /// <returns>
        ///     A new instance of the HttpClientAbstraction.
        /// </returns>
        IHttpClientAbstraction Create(IAbstractionContext context, bool ignoreSslErrors);
    }
}
