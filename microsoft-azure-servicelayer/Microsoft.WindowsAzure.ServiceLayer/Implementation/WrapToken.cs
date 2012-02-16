using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer.Implementation
{
    /// <summary>
    /// WRAP token; used for authenticating outgoing web requests.
    /// </summary>
    class WrapToken
    {
        /// <summary>
        /// Specifies the scope of the token.
        /// </summary>
        internal string Scope { get { throw new NotImplementedException(); } }

        /// <summary>
        /// Gets the value saying whether the token is expired.
        /// </summary>
        internal bool IsExpired { get { throw new NotImplementedException(); } }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="response">HTTP response with the token</param>
        internal WrapToken(HttpResponseMessage response)
        {
            Debug.Assert(response.IsSuccessStatusCode);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Authorizes the request.
        /// </summary>
        /// <param name="request">Source request</param>
        /// <returns>Authorized request</returns>
        internal HttpRequestMessage Authorize(HttpRequestMessage request)
        {
            //TODO: implement
            return request;
        }
    }
}
