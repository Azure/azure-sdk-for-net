// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Gets access tokens to authenticate to Azure services using the developer's (Azure AD/ Microsoft) account during development, 
    /// and using the app's identity (using OAuth 2.0 Client Credentials flow) when deployed to Azure.
    /// </summary>
    public class AzureServiceTokenProvider
    {
        private readonly string _connectionString;
        private Principal _principalUsed;
        private readonly string _azureAdInstance;

        // Base provider instance. A derived instance is selected based on the connection string or discovery. 
        private NonInteractiveAzureServiceTokenProviderBase _selectedAccessTokenProvider;

        // List of potential token providers. 
        private readonly List<NonInteractiveAzureServiceTokenProviderBase> _potentialAccessTokenProviders;

        // Ensures only one thread gets the token from the actual source. It is then cached, so other threads can get it from the cache. 
        private static readonly SemaphoreSlim Semaphore = new SemaphoreSlim(1, 1);

        /// <summary>
        /// Token callback for Key Vault. 
        /// </summary>
        /// <param name="authority"></param>
        /// <param name="resource"></param>
        /// <param name="scope"></param>
        public delegate Task<string> TokenCallback(string authority, string resource, string scope);

        /// <summary>
        /// Property to get authentication callback to be used with KeyVaultClient.  
        /// </summary>
        /// <example>
        /// <code>
        /// KeyVaultClient keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
        /// </code>
        /// </example>
        public TokenCallback KeyVaultTokenCallback => GetAccessTokenAsyncImpl;

        /// <summary>
        /// The principal used to acquire token. This will be of type "User" for local development scenarios, and "App" when client credentials flow is used. 
        /// </summary>
        public Principal PrincipalUsed => _principalUsed;

        /// <summary>
        /// Creates an instance of the AzureServiceTokenProvider class.
        /// If no connection string is specified, Managed Service Identity, Visual Studio, Azure CLI, and Integrated Windows Authentication are tried to get a token.
        /// Even If no connection string is specified in code, one can be specified in the AzureServicesAuthConnectionString environment variable. 
        /// </summary>
        /// <param name="connectionString">Connection string to specify which option to use to get the token.</param>
        /// <param name="azureAdInstance">Specify a value for clouds other than the Public Cloud.</param>
        public AzureServiceTokenProvider(string connectionString = default(string), string azureAdInstance = "https://login.microsoftonline.com/")
        {
            if (string.IsNullOrEmpty(azureAdInstance))
            {
                throw new ArgumentNullException(nameof(azureAdInstance));
            }

            if (!azureAdInstance.ToLower().StartsWith("https"))
            {
                throw new ArgumentException($"azureAdInstance {azureAdInstance} is not valid. It must use https.");
            }

            _azureAdInstance = azureAdInstance;

            // Check the environment variable to see if a connection string is specified. 
            if (connectionString == default(string))
            {
                connectionString = Environment.GetEnvironmentVariable("AzureServicesAuthConnectionString");
            }

            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                _selectedAccessTokenProvider = AzureServiceTokenProviderFactory.Create(connectionString, azureAdInstance);

                _connectionString = connectionString;
            }
            else
            {
                _potentialAccessTokenProviders = new List<NonInteractiveAzureServiceTokenProviderBase>
                {
                    new MsiAccessTokenProvider(),
                    new VisualStudioAccessTokenProvider(new ProcessManager()),
                    new AzureCliAccessTokenProvider(new ProcessManager()),
#if FullNetFx
                    new WindowsAuthenticationAzureServiceTokenProvider(new AdalAuthenticationContext(), azureAdInstance)
#endif
                };
            }
            
        }

        /// <summary>
        /// This method is for testing only
        /// </summary>
        internal AzureServiceTokenProvider(NonInteractiveAzureServiceTokenProviderBase accessTokenProvider)
        {
            _selectedAccessTokenProvider = accessTokenProvider;
        }

        /// <summary>
        /// This method is for testing only
        /// </summary>
        internal AzureServiceTokenProvider(List<NonInteractiveAzureServiceTokenProviderBase> accessTokenProviders)
        {
            _potentialAccessTokenProviders = accessTokenProviders;
        }

        /// <summary>
        /// This is the core method to get a token. It checks if the token is in cache, and if so, returns it. 
        /// If not in cache, asks one or more token providers to get the token. 
        /// </summary>
        /// <param name="authority"></param>
        /// <param name="resource"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        private async Task<string> GetAccessTokenAsyncImpl(string authority, string resource, string scope)
        {
            // Check if the token is present in cache, for the given connection string, authority, and resource
            // This is an in-memory global cache, that will be used across instances of this class. 
            string cacheKey = $"ConnectionString:{_connectionString};Authority:{authority};Resource:{resource}";

            Tuple<AccessToken, Principal> tokenResult = AccessTokenCache.Get(cacheKey);

            if (tokenResult != null)
            {
                _principalUsed = tokenResult.Item2;

                return tokenResult.Item1.ToString();
            }

            // If not in cache, lock. One of multiple threads that reach here will be allowed to get the token.
            // When the first thread gets the token, another thread will be let in the lock.
            await Semaphore.WaitAsync().ConfigureAwait(false);

            // This is to store the list of exceptions while trying to get the token.
            List<Exception> exceptions = new List<Exception>();

            try
            {
                // Check again if the token is in the cache now, the first thread may have got it.
                tokenResult = AccessTokenCache.Get(cacheKey);

                if (tokenResult != null)
                {
                    _principalUsed = tokenResult.Item2;

                    return tokenResult.Item1.ToString();
                }

                // If the token was not in cache, try to get it
                List<NonInteractiveAzureServiceTokenProviderBase> tokenProviders = GetTokenProviders();
                
                // Try to get the token using the selected providers
                foreach (var tokenProvider in tokenProviders)
                {
                    try
                    {
                        // Get the token, add to the cache, and return the token.
                        string token = await tokenProvider.GetTokenAsync(authority, resource,
                                string.Empty)
                            .ConfigureAwait(false);

                        // Set the token provider to the one that worked. 
                        // Future calls to get token in this instance will directly use this provider.
                        _selectedAccessTokenProvider = tokenProvider;

                        _principalUsed = tokenProvider.PrincipalUsed;

                        AccessTokenCache.AddOrUpdate(cacheKey,
                            new Tuple<AccessToken, Principal>(AccessToken.Parse(token), tokenProvider.PrincipalUsed));

                        return token;
                    }
                    catch (AzureServiceTokenProviderException exp)
                    {
                        exceptions.Add(exp);
                    }

                }
            }
            finally
            {
                // Whichever way the try block exits, the semaphore must be released. 
                Semaphore.Release();
            }
            
            // Throw exception so that the caller knows why the token could not be acquired.
            if (exceptions.Count == 1)
            {
                throw exceptions.First();
            }

            string message = $"Tried the following {exceptions.Count} methods to get an access token, but none of them worked.{Environment.NewLine}";

            foreach (var exception in exceptions)
            {
                message += $"{exception.Message}{Environment.NewLine}";
            }

            throw new AzureServiceTokenProviderException(null, resource, authority, message);
        }

        /// <summary>
        /// If a connection string was specified, or discovery of provider has already happened (in which case _selectedAccessTokenProvider would have been set),
        /// Use the approproate access token provider. 
        /// </summary>
        /// <returns></returns>
        private List<NonInteractiveAzureServiceTokenProviderBase> GetTokenProviders()
        {
            return _selectedAccessTokenProvider != null 
                ? new List<NonInteractiveAzureServiceTokenProviderBase> { _selectedAccessTokenProvider } 
                : _potentialAccessTokenProviders;
        }

        /// <summary>
        /// Gets an access token to access the given Azure resource. 
        /// </summary>
        /// <example>
        /// <code>
        /// var azureServiceTokenProvider = new AzureServiceTokenProvider();
        /// string accessToken = await azureServiceTokenProvider.GetAccessTokenAsync("https://management.azure.com/").ConfigureAwait(false);
        /// </code>
        /// </example>
        /// <param name="resource">Resource to access. e.g. https://management.azure.com/.</param>
        /// <param name="tenantId">If not specified, default tenant is used. Managed Service Identity REST protocols do not accept tenantId, so this can only be used with certificate and client secret based authentication.</param>
        /// <returns>Access token</returns>
        /// <exception cref="ArgumentNullException">Thrown if resource is null or empty.</exception>
        /// <exception cref="AzureServiceTokenProviderException">Thrown if access token cannot be acquired.</exception>
        public async Task<string> GetAccessTokenAsync(string resource, string tenantId = default(string))
        {
            if (string.IsNullOrWhiteSpace(resource))
            {
                throw new ArgumentNullException(nameof(resource));
            }

            string authority = string.IsNullOrEmpty(tenantId) ? string.Empty : $"{_azureAdInstance}{tenantId}";

            return await GetAccessTokenAsyncImpl(authority, resource, string.Empty).ConfigureAwait(false);
        }
    }
}
