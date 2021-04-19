// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

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
        /// HTTP client factory to support HTTP proxy in ADAL
        /// Implemented as a static so that client apps can gain proxy support without having to wait for intermediate packages to support it.
        /// </summary>
        public static IHttpClientFactory HttpClientFactory { get; set; }

        /// <summary>
        /// Property to get authentication callback to be used with KeyVaultClient.  
        /// </summary>
        /// <example>
        /// <code>
        /// KeyVaultClient keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
        /// </code>
        /// </example>
        public virtual TokenCallback KeyVaultTokenCallback => async (authority, resource, scope) =>
        {
            var authResult = await GetAuthResultAsyncImpl(resource, authority).ConfigureAwait(false);
            return authResult.AccessToken;
        };

        /// <summary>
        /// The principal used to acquire token. This will be of type "User" for local development scenarios, and "App" when client credentials flow is used. 
        /// </summary>
        public virtual Principal PrincipalUsed => _principalUsed;

        /// <summary>
        /// Creates an instance of the AzureServiceTokenProvider class.
        /// If no connection string is specified, Managed Service Identity, Visual Studio, Azure CLI, and Integrated Windows Authentication are tried to get a token.
        /// Even If no connection string is specified in code, one can be specified in the AzureServicesAuthConnectionString environment variable. 
        /// </summary>
        /// <param name="connectionString">Connection string to specify which option to use to get the token.</param>
        /// <param name="azureAdInstance">Specify a value for clouds other than the Public Cloud.</param>
        /// <param name="httpClientFactory">Passed to ADAL to allow proxied connections. Takes precedence over the static <see cref="HttpClientFactory"/> property</param>
        public AzureServiceTokenProvider(string connectionString = default, string azureAdInstance = "https://login.microsoftonline.com/", IHttpClientFactory httpClientFactory = default)
        {
            if (string.IsNullOrEmpty(azureAdInstance))
            {
                throw new ArgumentNullException(nameof(azureAdInstance));
            }

            if (!azureAdInstance.ToLowerInvariant().StartsWith("https"))
            {
                throw new ArgumentException($"azureAdInstance {azureAdInstance} is not valid. It must use https.");
            }

            _azureAdInstance = azureAdInstance;

            // Check the environment variable to see if a connection string is specified. 
            if (connectionString == default)
            {
                connectionString = EnvironmentHelper.GetEnvironmentVariable("AzureServicesAuthConnectionString");
            }

            // prefer parameter over static property
            var factory = httpClientFactory ?? HttpClientFactory;

            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                _selectedAccessTokenProvider = AzureServiceTokenProviderFactory.Create(connectionString, azureAdInstance, factory);
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
                    new WindowsAuthenticationAzureServiceTokenProvider(new AdalAuthenticationContext(factory), azureAdInstance)
#endif
                };
            }

        }

        public AzureServiceTokenProvider(string connectionString, string azureAdInstance)
            : this(connectionString, azureAdInstance, default)
        {

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
        private async Task<AppAuthenticationResult> GetAuthResultAsyncImpl(string resource, string authority,
            bool forceRefresh = false, CancellationToken cancellationToken = default)
        {
            // Check if the auth result is present in cache, for the given connection string, authority, and resource
            // This is an in-memory global cache, that will be used across instances of this class. 
            string cacheKey = $"ConnectionString:{_connectionString};Authority:{authority};Resource:{resource}";

            Tuple<AppAuthenticationResult, Principal> cachedAuthResult = AppAuthResultCache.Get(cacheKey);

            if (!forceRefresh && cachedAuthResult != null)
            {
                _principalUsed = cachedAuthResult.Item2;

                return cachedAuthResult.Item1;
            }

            // If not in cache, lock. One of multiple threads that reach here will be allowed to get the token.
            // When the first thread gets the token, another thread will be let in the lock.
            await Semaphore.WaitAsync().ConfigureAwait(false);

            // This is to store the list of exceptions while trying to get the token.
            List<Exception> exceptions = new List<Exception>();

            try
            {
                // Check again if the auth result is in the cache now, the first thread may have gotten it.
                Tuple<AppAuthenticationResult, Principal> cachedAuthResult2 = AppAuthResultCache.Get(cacheKey);

                // If the cache has a hit and we are not forcing a refresh, or we are forcing a refresh but it
                // was already refreshed while waiting on the semaphore.
                if (cachedAuthResult2 != null
                    && (!forceRefresh || !object.ReferenceEquals(cachedAuthResult?.Item1, cachedAuthResult2.Item1)))
                {
                    _principalUsed = cachedAuthResult2.Item2;

                    return cachedAuthResult2.Item1;
                }

                // If the auth result was not in cache, try to get it
                List<NonInteractiveAzureServiceTokenProviderBase> tokenProviders = GetTokenProviders();

                // Try to get the token using the selected providers
                foreach (var tokenProvider in tokenProviders)
                {
                    try
                    {
                        // Get the auth result, add to the cache, and return the auth result.
                        var authResult = await tokenProvider.GetAuthResultAsync(resource, authority, cancellationToken)
                            .ConfigureAwait(false);

                        // Set the token provider to the one that worked. 
                        // Future calls to get token in this instance will directly use this provider.
                        _selectedAccessTokenProvider = tokenProvider;

                        _principalUsed = tokenProvider.PrincipalUsed;

                        AppAuthResultCache.AddOrUpdate(cacheKey,
                            new Tuple<AppAuthenticationResult, Principal>(authResult, tokenProvider.PrincipalUsed));

                        return authResult;
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
        /// Use the appropriate access token provider. 
        /// </summary>
        /// <returns></returns>
        private List<NonInteractiveAzureServiceTokenProviderBase> GetTokenProviders()
        {
            return _selectedAccessTokenProvider != null
                ? new List<NonInteractiveAzureServiceTokenProviderBase> { _selectedAccessTokenProvider }
                : _potentialAccessTokenProviders;
        }

        // <summary>
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
        /// <param name="forceRefresh">True to force refresh this token. False to used a cache value if available.</param> 
        /// <returns>Access token</returns>
        /// <exception cref="ArgumentNullException">Thrown if resource is null or empty.</exception>
        /// <exception cref="AzureServiceTokenProviderException">Thrown if access token cannot be acquired.</exception>
        public virtual async Task<string> GetAccessTokenAsync(string resource, string tenantId, bool forceRefresh,
            CancellationToken cancellationToken = default)
        {
            var authResult = await GetAuthenticationResultAsync(resource, tenantId, forceRefresh, cancellationToken).ConfigureAwait(false);
            return authResult.AccessToken;
        }

        // <summary>
        /// Gets an access token to access the given Azure resource. 
        /// </summary>
        /// <example>
        /// <code>
        /// var azureServiceTokenProvider = new AzureServiceTokenProvider();
        /// string accessToken = await azureServiceTokenProvider.GetAccessTokenAsync("https://management.azure.com/").ConfigureAwait(false);
        /// </code>
        /// </example>
        /// <param name="resource">Resource to access. e.g. https://management.azure.com/.</param>
        /// <param name="forceRefresh">True to force refresh this token. False to used a cache value if available.</param> 
        /// <returns>Access token</returns>
        /// <exception cref="ArgumentNullException">Thrown if resource is null or empty.</exception>
        /// <exception cref="AzureServiceTokenProviderException">Thrown if access token cannot be acquired.</exception>
        public virtual Task<string> GetAccessTokenAsync(string resource, bool forceRefresh,
            CancellationToken cancellationToken = default)
        {
            return GetAccessTokenAsync(resource, tenantId: null, forceRefresh, cancellationToken);
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
        public virtual Task<string> GetAccessTokenAsync(string resource, string tenantId = default,
            CancellationToken cancellationToken = default)
        {
            return GetAccessTokenAsync(resource, tenantId, forceRefresh: false, cancellationToken);
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
        public virtual Task<string> GetAccessTokenAsync(string resource, string tenantId)
        {
            return GetAccessTokenAsync(resource, tenantId, default);
        }

        /// <summary>
        /// Gets an authentication result which contains an access token to access the given Azure resource. 
        /// </summary>
        /// <example>
        /// <code>
        /// var azureServiceTokenProvider = new AzureServiceTokenProvider();
        /// var authResult = await azureServiceTokenProvider.GetAuthResultAsync("https://management.azure.com/").ConfigureAwait(false);
        /// </code>
        /// </example>
        /// <param name="resource">Resource to access. e.g. https://management.azure.com/.</param>
        /// <param name="tenantId">If not specified, default tenant is used. Managed Service Identity REST protocols do not accept tenantId, so this can only be used with certificate and client secret based authentication.</param>
        /// <param name="forceRefresh">True to force refresh this token. False to used a cache value if available.</param> 
        /// <returns>Access token</returns>
        /// <exception cref="ArgumentNullException">Thrown if resource is null or empty.</exception>
        /// <exception cref="AzureServiceTokenProviderException">Thrown if access token cannot be acquired.</exception>
        public virtual Task<AppAuthenticationResult> GetAuthenticationResultAsync(string resource, string tenantId,
            bool forceRefresh, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(resource))
            {
                throw new ArgumentNullException(nameof(resource));
            }

            string authority = string.IsNullOrEmpty(tenantId) ? string.Empty : $"{_azureAdInstance}{tenantId}";

            return GetAuthResultAsyncImpl(resource, authority, forceRefresh, cancellationToken);
        }

        /// <summary>
        /// Gets an authentication result which contains an access token to access the given Azure resource. 
        /// </summary>
        /// <example>
        /// <code>
        /// var azureServiceTokenProvider = new AzureServiceTokenProvider();
        /// var authResult = await azureServiceTokenProvider.GetAuthResultAsync("https://management.azure.com/").ConfigureAwait(false);
        /// </code>
        /// </example>
        /// <param name="resource">Resource to access. e.g. https://management.azure.com/.</param>
        /// <param name="forceRefresh">True to force refresh this token. False to used a cache value if available.</param> 
        /// <returns>Access token</returns>
        /// <exception cref="ArgumentNullException">Thrown if resource is null or empty.</exception>
        /// <exception cref="AzureServiceTokenProviderException">Thrown if access token cannot be acquired.</exception>
        public virtual Task<AppAuthenticationResult> GetAuthenticationResultAsync(string resource, bool forceRefresh,
            CancellationToken cancellationToken = default)
        {
            return GetAuthenticationResultAsync(resource, tenantId: null, forceRefresh, cancellationToken);
        }

        /// <summary>
        /// Gets an authentication result which contains an access token to access the given Azure resource. 
        /// </summary>
        /// <example>
        /// <code>
        /// var azureServiceTokenProvider = new AzureServiceTokenProvider();
        /// var authResult = await azureServiceTokenProvider.GetAuthResultAsync("https://management.azure.com/").ConfigureAwait(false);
        /// </code>
        /// </example>
        /// <param name="resource">Resource to access. e.g. https://management.azure.com/.</param>
        /// <param name="tenantId">If not specified, default tenant is used. Managed Service Identity REST protocols do not accept tenantId, so this can only be used with certificate and client secret based authentication.</param>
        /// <returns>Access token</returns>
        /// <exception cref="ArgumentNullException">Thrown if resource is null or empty.</exception>
        /// <exception cref="AzureServiceTokenProviderException">Thrown if access token cannot be acquired.</exception>
        public virtual Task<AppAuthenticationResult> GetAuthenticationResultAsync(string resource, string tenantId = default,
            CancellationToken cancellationToken = default)
        {
            return GetAuthenticationResultAsync(resource, tenantId, forceRefresh: false, cancellationToken);
        }

        /// <summary>
        /// Gets an authentication result which contains an access token to access the given Azure resource. 
        /// </summary>
        /// <example>
        /// <code>
        /// var azureServiceTokenProvider = new AzureServiceTokenProvider();
        /// var authResult = await azureServiceTokenProvider.GetAuthResultAsync("https://management.azure.com/").ConfigureAwait(false);
        /// </code>
        /// </example>
        /// <param name="resource">Resource to access. e.g. https://management.azure.com/.</param>
        /// <param name="tenantId">If not specified, default tenant is used. Managed Service Identity REST protocols do not accept tenantId, so this can only be used with certificate and client secret based authentication.</param>
        /// <returns>Access token</returns>
        /// <exception cref="ArgumentNullException">Thrown if resource is null or empty.</exception>
        /// <exception cref="AzureServiceTokenProviderException">Thrown if access token cannot be acquired.</exception>
        public virtual Task<AppAuthenticationResult> GetAuthenticationResultAsync(string resource, string tenantId)
        {
            return GetAuthenticationResultAsync(resource, tenantId, default);
        }
    }
}
