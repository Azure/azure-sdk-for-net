﻿//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.ServiceLayer.Http;

namespace Microsoft.WindowsAzure.ServiceLayer.Http
{
    /// <summary>
    /// WRAP token; used for authenticating outgoing web requests.
    /// </summary>
    internal class WrapToken
    {
        private DateTime _expirationDate;                   // Token's expiration date.

        /// <summary>
        /// Specifies the scope of the token.
        /// </summary>
        internal string Scope { get; private set; }

        /// <summary>
        /// Gets the token string. 
        /// </summary>
        internal string Token { get; private set; }

        /// <summary>
        /// Gets the value saying whether the token is expired.
        /// </summary>
        internal bool IsExpired 
        { 
            get 
            { 
                return DateTime.Now > _expirationDate; 
            } 
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="resourcePath">Path of the authenticated resource.</param>
        /// <param name="response">HTTP response with the token.</param>
        internal WrapToken(string resourcePath, HttpResponse response)
        {
            Debug.Assert(response.IsSuccessStatusCode);
            Scope = resourcePath;
            string content = response.Content.ReadAsStringAsync().AsTask().Result;
            HttpQueryStringParser query = new HttpQueryStringParser(content);

            Token = string.Format(CultureInfo.InvariantCulture, Constants.WrapTokenAuthenticationString, WebUtility.UrlDecode(query["wrap_access_token"]));
            _expirationDate = DateTime.Now + TimeSpan.FromSeconds(int.Parse(query["wrap_access_token_expires_in"]) / 2);
        }

        /// <summary>
        /// Authorizes the request.
        /// </summary>
        /// <param name="request">Source request.</param>
        /// <returns>Authorized request.</returns>
        internal HttpRequest Authorize(HttpRequest request)
        {
            request.Headers.Add("Authorization", Token);
            return request;
        }
    }
}
