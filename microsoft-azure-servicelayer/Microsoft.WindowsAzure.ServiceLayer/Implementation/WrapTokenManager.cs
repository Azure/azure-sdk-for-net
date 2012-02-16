using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Windows.Foundation;

namespace Microsoft.WindowsAzure.ServiceLayer.Implementation
{
    /// <summary>
    /// Manager for WRAP tokens.
    /// </summary>
    class WrapTokenManager
    {
        ServiceBusServiceConfig ServiceConfig { get; set; }                 // Service settings
        HttpClient Client { get; set; }                                     // HTTP channel for processing authentication requests
        Dictionary<string, WrapToken> Tokens { get; set; }                  // Cached tokens
        Object SyncObject { get; set; }                                     // Synchronization object for accessing cached tokens

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="serviceConfig">Configuration</param>
        internal WrapTokenManager(ServiceBusServiceConfig serviceConfig)
        {
            ServiceConfig = serviceConfig;
            Client = new HttpClient();
            Tokens = new Dictionary<string, WrapToken>();
            SyncObject = new Object();
        }

        /// <summary>
        /// Gets a token for the given resource.
        /// </summary>
        /// <param name="resourcePath">Resource path</param>
        /// <returns>WRAP token</returns>
        internal Task<WrapToken> GetTokenAsync(string resourcePath)
        {
            WrapToken token;

            if (Tokens.TryGetValue(resourcePath, out token) && token.IsExpired)
            {
                lock (SyncObject)
                {
                    if (Tokens.TryGetValue(resourcePath, out token) && token.IsExpired)
                    {
                        // The token is still there, and it's the same token; get rid of it.
                        Tokens.Remove(resourcePath);
                        token = null;
                    }
                }
            }

            if (token == null)
            {
                // The token is not there; start a new authentication request.
                Uri scopeUri = new Uri(ServiceConfig.ScopeHostUri, resourcePath);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, scopeUri);
                Dictionary<string, string> settings = new Dictionary<string, string>()
                {
                    {"wrap_name",       ServiceConfig.UserName},
                    {"wrap_password",   ServiceConfig.Password},
                    {"wrap_scope",      scopeUri.ToString()},
                };

                request.Headers.Accept.ParseAdd("application/x-www-form-urlencoded");       //TODO: is there a constant for this type?
                request.Content = new FormUrlEncodedContent(settings);

                return Client.SendAsync(request)
                    .ContinueWith<WrapToken>(t => { return SetToken(t.Result); }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }

            // Return cached token.
            TaskCompletionSource<WrapToken> tcs = new TaskCompletionSource<WrapToken>();
            tcs.SetResult(token);
            return tcs.Task;
        }

        /// <summary>
        /// Creates and caches a token from the given response.
        /// </summary>
        /// <param name="response">HTTP response.</param>
        /// <returns>Cached token</returns>
        internal WrapToken SetToken(HttpResponseMessage response)
        {
            WrapToken newToken = new WrapToken(response);
            WrapToken retToken;

            // Another request may have created a token for the same scope. In this case we simply ignore 
            if (!Tokens.TryGetValue(newToken.Scope, out retToken))
            {
                lock (SyncObject)
                {
                    if (!Tokens.TryGetValue(newToken.Scope, out retToken))
                    {
                        Tokens.Add(newToken.Scope, newToken);
                        retToken = newToken;
                    }
                }
            }
            return retToken;
        }
    }
}
