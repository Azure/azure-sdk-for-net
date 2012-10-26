// -----------------------------------------------------------------------------------------
// <copyright file="StockResponses.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------


namespace Microsoft.WindowsAzure.Test.Network
{
    /// <summary>
    /// StockResponses holds the filenames associated with several stock responses from HTTP servers.
    /// </summary>
    public static class StockResponses
    {
        /// <summary>
        /// Returns status code 200 and a GIF file.
        /// </summary>
        public const string FiddlerGif200 = "200_FiddlerGif.dat";

        /// <summary>
        /// Returns status code 200 and a simple HTML file.
        /// </summary>
        public const string SimpleHTML200 = "200_SimpleHTML.dat";

        /// <summary>
        /// Returns status code 200 and a transparent pixel.
        /// </summary>
        public const string TransPixel200 = "200_TransPixel.dat";

        /// <summary>
        /// Returns status code 204 (No Content) and no content.
        /// </summary>
        public const string NoContent204 = "204_NoContent.dat";

        /// <summary>
        /// Returns status code 302 (Found) with a redirect.
        /// </summary>
        public const string Redirect302 = "302_Redirect.dat";

        /// <summary>
        /// Returns status code 303 (See Other) with a redirect.
        /// </summary>
        public const string RedirectWithGet303 = "303_RedirectWithGet.dat";

        /// <summary>
        /// Returns status code 304 (Not Modified) with no content.
        /// </summary>
        public const string NotModified304 = "304_NotModified.dat";

        /// <summary>
        /// Returns status code 307 (Temporary Redirect) with a redirection method.
        /// </summary>
        public const string RedirectWithMethod307 = "307_RedirectWithMethod.dat";

        /// <summary>
        /// Returns status code 401 (Unauthorized) asking for basic auth.
        /// </summary>
        public const string AuthBasic401 = "401_AuthBasic.dat";

        /// <summary>
        /// Returns status code 401 (Unauthorized) asking for Digest auth.
        /// </summary>
        public const string AuthDigest401 = "401_AuthDigest.dat";

        /// <summary>
        /// Returns status code 403 (Forbidden), indicating that access to this resource is denied.
        /// </summary>
        public const string AuthDeny403 = "403_AuthDeny.dat";

        /// <summary>
        /// Returns status code 404 (Not Found) with nothing else attached.
        /// </summary>
        public const string Plain404 = "404_Plain.dat";

        /// <summary>
        /// Returns status code 407 (Proxy Authentication Required), asking for basic auth.
        /// </summary>
        public const string ProxyAuthBasic407 = "407_ProxyAuthBasic.dat";

        /// <summary>
        /// Returns status code 502 (Bad Gateway) indicating there was an issue reaching the proxy server.
        /// </summary>
        public const string Unreachable502 = "502_Unreachable.dat";
    }
}
