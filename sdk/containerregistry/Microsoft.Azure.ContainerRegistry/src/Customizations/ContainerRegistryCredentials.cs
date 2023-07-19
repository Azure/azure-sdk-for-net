using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.ContainerRegistry
{

    /// <summary>
    /// Robust handling of Basic and OAUTH2 authentication flows for the Azure Container Registry Runtime .Net SDK.
    /// This class handles Basic Authentication as well as JWT token authentication using both username and password
    /// routes as well as through exchanging AAD tokens.
    /// </summary>
    public class ContainerRegistryCredentials : ServiceClientCredentials
    {

        #region Definitions

        /// <summary>
        /// Authentication type
        /// </summary>
        public enum LoginMode
        {
            /// <summary> Basic authentication </summary>
            Basic,
            /// <summary> Authentication using oauth2 with login and password </summary>
            TokenAuth,
            /// <summary> Authentication using an AAD access token.</summary>
            TokenAad
        }

        #endregion

        #region Instance Variables
        private string _authHeader { get; set; }
        private LoginMode _mode { get; set; }
        private string _loginServerUrl { get; set; } // does not contain scheme prefix (e.g. "https://")
        private string _username { get; set; }
        private string _password { get; set; }
        private CancellationToken _requestCancellationToken { get; set; }

        // Structure : Scope : Token
        // Key Scope retrieved from header from service which shouldn't change culture.
        private Dictionary<string, ContainerRegistryAccessToken> _acrAccessTokens = new Dictionary<string, ContainerRegistryAccessToken>(StringComparer.OrdinalIgnoreCase);

        // Structure : Method>Operation : Scope
        // Key contains operation url which could potentially change culture...
        private Dictionary<string, string> _acrScopes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        // Internal simplified client for Token Acquisition
        private ContainerRegistryRefreshToken _acrRefresh;
        private AuthToken _aadAccess;
        private const string pattern = "\".+:.+:.+\"";  //Pattern to get the scope from headers
        private static readonly Regex scopeFromHeaderRegex = new Regex(pattern);

        #endregion

        #region Constructors

        /// <summary>
        /// Construct a ContainerRegistryCredentials object from user credentials. Users may specify basic authentication or the more secure oauth2 (token) based authentication.
        /// <exception cref="Exception"> Throws an exception if LoginMode is set to TokenAad </exception>
        /// <paramref name="mode"/> The credential acquisition mode, one of Basic, TokenAuth, or TokenAad
        /// <paramref name="loginUrl"/> The url of the registry to be used
        /// <paramref name="username"/> The username for the registry
        /// <paramref name="password"/> The password for the registry
        /// </summary>
        public ContainerRegistryCredentials(LoginMode mode, string loginUrl, string username, string password, CancellationToken cancellationToken = default)
        {
            if (mode == LoginMode.TokenAad)
            {
                throw new ArgumentException("This constructor does not permit AAD Authentication. Please use an appropriate constructor.");
            }

            _mode = mode;
            _loginServerUrl = ProcessLoginUrl(loginUrl);
            _username = username;
            _password = password;
            _requestCancellationToken = cancellationToken;

            if (_mode == LoginMode.Basic) // Basic Authentication
            {
                _authHeader = Helpers.EncodeTo64($"{_username}:{_password}");
            }
        }

        /// <summary>
        /// Construct a ContainerRegistryCredentials object from an AAD Token. A callback can be provided to renew the AAD token when it expires.
        /// <paramref name="aadAccessToken"/> The password for the registry
        /// <paramref name="loginUrl"/> The Azure active directory access token to be used
        /// <paramref name="tenant"/> The tenant of the aad access token (optional)
        /// <paramref name="acquireNewAad"/> Callback function to refresh the <paramref name="aadAccessToken">. Without this parameter, the AAD token cannot be refreshed.
        /// </summary>
        public ContainerRegistryCredentials(string aadAccessToken, string loginUrl, AuthToken.AcquireCallback acquireNewAad = null, CancellationToken cancellationToken = default)
        {
            _mode = LoginMode.TokenAad;
            _loginServerUrl = ProcessLoginUrl(loginUrl);
            _requestCancellationToken = cancellationToken;
            _aadAccess = new AuthToken(aadAccessToken, acquireNewAad);
            _acrRefresh = new ContainerRegistryRefreshToken(_aadAccess, _loginServerUrl);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Called on initialization of client. Sets the Client's LoginUri from the Credentials LoginUrl.
        /// </summary>
        public override void InitializeServiceClient<T>(ServiceClient<T> client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            // if this is an ACRClient, add the loginUri that this credential was created for
            if (client is AzureContainerRegistryClient acrClient)
            {
                if (string.IsNullOrEmpty(acrClient.LoginUri))
                {
                    acrClient.LoginUri = $"https://{this._loginServerUrl}";
                }
                // if the login uris don't match
                else if (acrClient.LoginUri.ToLowerInvariant() != this._loginServerUrl.ToLowerInvariant())
                {
                    throw new ValidationException($"\"{nameof(AzureContainerRegistryClient)}'s\" LoginUrl: '{acrClient.LoginUri}' does not match \"{nameof(ContainerRegistryCredentials)} LoginUrl: '{this._loginServerUrl}'");
                }
            }
        }

        /// <summary>
        /// Apply the credentials to the HTTP request.
        /// </summary>
        public override async Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (_mode == LoginMode.Basic)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", _authHeader);
            }
            else
            {
                string operation = $"https://{_loginServerUrl}{request.RequestUri.AbsolutePath}";
                string scope = await GetScope(operation, request.Method.Method, request.RequestUri.AbsolutePath);

                request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {GetAcrAccessToken(scope)}");
            }

            await base.ProcessHttpRequestAsync(request, cancellationToken);
        }

        #endregion

        #region Helpers

        private static string ProcessLoginUrl(string loginUrl)
        {
            // in case passed in loginurl includes https start. We also don't want 'http://' to be in the url.
            string[] schemes = new string[] { "https://", "http://" };
            foreach (var scheme in schemes)
            {
                if (loginUrl.ToLower().StartsWith(scheme))
                {
                    loginUrl.Substring(scheme.Length);
                    break; // strip at most once.
                }
            }

            if (loginUrl.EndsWith("/"))
            {
                loginUrl.Substring(0, loginUrl.Length - 1);
            }

            return loginUrl;
        }

        /// <summary>
        /// Acquires a new ACR access token if necessary. It can also acquire a cached access token in order to avoid extra requests to
        /// the oauth2 endpoint improving efficiency.
        /// <param name='scope'> The scope for the particuar operation. Can be obtained from the Www-Authenticate header.
        /// </summary>
        private string GetAcrAccessToken(string scope)
        {
            if (_mode == LoginMode.Basic)
            {
                throw new Exception("This Function cannot be invoked for requested Login Mode. Basic Authentication does not support JWT Tokens ");
            }

            // if token is stale, hit refresh
            if (_acrAccessTokens.TryGetValue(scope, out ContainerRegistryAccessToken token))
            {
                if (!token.CheckAndRefresh())
                {
                    throw new Exception($"Access Token for scope {scope} expired and could not be refreshed");
                }

                return token.Value;
            }

            if (_mode == LoginMode.TokenAad)
            {
                _acrAccessTokens[scope] = new ContainerRegistryAccessToken(_acrRefresh, scope, _loginServerUrl);
            }
            else if (_mode == LoginMode.TokenAuth)
            {
                _acrAccessTokens[scope] = new ContainerRegistryAccessToken(_username, _password, scope, _loginServerUrl);
            }

            return _acrAccessTokens[scope].Value;
        }

        /// <summary>
        /// Acquires the required scope for a specific operation. This will be done by obtaining a challenge and parsing out the scope
        /// from the ww-Authenticate header. In the event of failure (Some endpoints do not seem to return the scope) it will attempt
        /// resolution through a local resolver <see cref="ResolveScopeLocally">.
        /// <param name='scope'> The scope for the particuar operation. Can be obtained from the Www-Authenticate header.
        /// </summary>

        private async Task<string> GetScope(string operation, string method, string path)
        {
            string methodOperationKey = $"{method}>{operation}";

            if (_acrScopes.TryGetValue(methodOperationKey, out string result))
            {
                return result;
            }

            string scope;
            try
            {
                HttpClient runtimeClient = new HttpClient();
                HttpResponseMessage response = await runtimeClient.SendAsync(new HttpRequestMessage(new HttpMethod(method), operation));
                scope = GetScopeFromHeaders(response.Headers)?? ResolveScopeLocally(path);
                _acrScopes[methodOperationKey] = scope;
            }
            catch (Exception e)
            {
                throw new Exception($"Could not identify appropriate Token scope: {e.Message}");
            }
            return scope;
        }

        /// <summary>
        /// Local resolver for endpoints that will often return no scope.
        /// <param name='operation'> Operation for which a scope is necessary
        /// </summary>
        private string ResolveScopeLocally(string operation)
        {
            const string v1Operation = "/acr/v1/_catalog";
            const string v2Operation = "/v2/";
            switch (operation)
            {
                case v1Operation:
                case v2Operation:
                    return "registry:catalog:*";
                default:
                    throw new Exception("Could not determine appropriate scope for the specified operation");
            }
        }

        /// <summary>
        /// Parse value of scope key from the 'Www-Authenticate' challenge header. See RFC 7235 section 4.1 for more info on the
        /// Ex challenge header value:
        ///  Bearer realm="https://test.azurecr.io/oauth2/token",service="test.azurecr.io",scope="repository:hello-txt:metadata_read"
        /// Return null if it is not present
        /// </summary>
        public string GetScopeFromHeaders(HttpHeaders headers)
        {
            if (headers == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, nameof(headers));
            }

            string challengeHeader = "Www-Authenticate".ToLower();
            string headerValue = "";
            foreach (var headerKVP in headers)
            {
                if (headerKVP.Key.ToLower() == challengeHeader)
                {
                    headerValue = string.Join(",", headerKVP.Value);

                    break;
                }
            }

            int position = headerValue.IndexOf("scope=");
            string scope = headerValue.Substring(position);
            string[] keyValues = scope.Split('=');
            int length = keyValues.Length;

            if (length < 2)
            {
               throw new Exception($"Could not find a scope in the {headerValue}");
            }
            else if(length > 2)
            {
                string scopeContainedIn = keyValues[1];
                return TrimDoubleQuotes(scopeFromHeaderRegex.Match(scopeContainedIn).Value);
            }
            else
            {
                return TrimDoubleQuotes(keyValues[1]);
            }
        }

        /// <summary>
        /// Removes trailing whitespace or " characters.
        /// </summary>
        private string TrimDoubleQuotes(string toTrim)
        {
            toTrim = toTrim.Trim();
            if (toTrim.StartsWith("\"")) toTrim = toTrim.Substring(1);
            if (toTrim.EndsWith("\"")) toTrim = toTrim.Substring(0, toTrim.Length - 1);
            return toTrim;
        }

        #endregion
    }
}



