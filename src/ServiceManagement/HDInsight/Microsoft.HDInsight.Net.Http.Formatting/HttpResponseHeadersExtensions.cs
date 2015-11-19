// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Net.Http.Headers;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;
    using Microsoft.HDInsight.Net.Http.Formatting.Headers;

    /// <summary>
    /// Provides extension methods for the <see cref="HttpResponseHeaders"/> class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static class HttpResponseHeadersExtensions
    {
        private const string SetCookie = "Set-Cookie";

        /// <summary>
        /// Adds cookies to a response. Each <c>Set-Cookie</c> header is 
        /// represented as one <see cref="CookieHeaderValue"/> instance. A <see cref="CookieHeaderValue"/>
        /// contains information about the domain, path, and other cookie information as well as one or
        /// more <see cref="CookieState"/> instances. Each <see cref="CookieState"/> instance contains
        /// a cookie name and whatever cookie state is associate with that name. The state is in the form of a 
        /// <see cref="System.Collections.Specialized.NameValueCollection"/> which on the wire is encoded as HTML Form URL-encoded data. 
        /// This representation allows for multiple related "cookies" to be carried within the same
        /// <c>Cookie</c> header while still providing separation between each cookie state. A sample
        /// <c>Cookie</c> header is shown below. In this example, there are two <see cref="CookieState"/>
        /// with names <c>state1</c> and <c>state2</c> respectively. Further, each cookie state contains two name/value
        /// pairs (name1/value1 and name2/value2) and (name3/value3 and name4/value4).
        /// <code>
        /// Set-Cookie: state1:name1=value1&amp;name2=value2; state2:name3=value3&amp;name4=value4; domain=domain1; path=path1;
        /// </code>
        /// </summary>
        /// <param name="headers">The response headers</param>
        /// <param name="cookies">The cookie values to add to the response.</param>
        public static void AddCookies(this HttpResponseHeaders headers, IEnumerable<CookieHeaderValue> cookies)
        {
            if (headers == null)
            {
                throw Error.ArgumentNull("headers");
            }

            if (cookies == null)
            {
                throw Error.ArgumentNull("cookies");
            }

            foreach (CookieHeaderValue cookie in cookies)
            {
                if (cookie == null)
                {
                    throw Error.Argument("cookies", Resources.CookieNull);
                }

                headers.TryAddWithoutValidation(SetCookie, cookie.ToString());
            }
        }
    }
}
