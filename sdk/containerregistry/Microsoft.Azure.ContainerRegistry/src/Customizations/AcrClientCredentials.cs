using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public class AcrClientCredentials : ServiceClientCredentials
    {

        #region Definitions

        /// <summary>
        /// Authentication type
        /// </summary>
        public enum LoginMode
        {
            Basic, // Basic authentication
            TokenAuth, // Authentication using oauth2 with login and password
            TokenAad // Authentication using an AAD access token.
        }

        #endregion

        #region Instance Variables        
        private string _authHeader { get; set; }
        private LoginMode _mode { get; set; }
        private string _loginUrl { get; set; }
        private string _username { get; set; }
        private string _password { get; set; }
        private String _tenant { get; set; }
        private CancellationToken _requestCancellationToken { get; set; }

        // Structure : Scope : Token
        private Dictionary<string, AcrAccessToken> _acrAccessTokens;

        // Structure : Method>Operation : Scope
        private Dictionary<string, string> _acrScopes;

        // Internal simplified client for Token Acquisition
        private AcrRefreshToken _acrRefresh;
        private AuthToken _aadAccess;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor for use when providing user credentials. Users may specify if basic authorization is to be used or if more secure JWT token reliant
        /// authorization will be used.
        /// @Throws If LoginMode is set to TokenAad
        /// <paramref name="mode"/> The credential acquisition mode, one of Basic, TokenAuth, or TokenAad
        /// <paramref name="loginUrl"/> The url of the registry to be used
        /// <paramref name="username"/> The username for the registry
        /// <paramref name="password"/> The password for the registry
        /// </summary>
        public AcrClientCredentials(LoginMode mode, string loginUrl, string username, string password, CancellationToken cancellationToken = default)
        {
            _acrScopes = new Dictionary<string, string>();
            _acrAccessTokens = new Dictionary<string, AcrAccessToken>();
            _mode = mode;
            if (_mode == LoginMode.TokenAad)
            {
                throw new Exception("AAD token authorization requires you to provide the AAD_access_token");
            }
            // Proofing in case passed in loginurl includes https start.
            if (loginUrl.StartsWith("https://"))
            {
                loginUrl.Substring("https://".Length);
            }
            if (loginUrl.EndsWith("/"))
            {
                loginUrl.Substring(0, loginUrl.Length - 1);
            }

            _loginUrl = loginUrl;
            _username = username;
            _password = password;
            _requestCancellationToken = cancellationToken;
        }

        /// <summary>
        /// Constructor for use when providing an aad access token to be exchanged for an acr refresh token. Note that token expiration will require manually
        /// providing new aad tokens.This model assumes the client is able to do this authentication themselves for AAD tokens. A callback can be provided to
        /// be executed once the ACR refresh token expires and can no longer be renewed as the provided Aad Token has expired.
        /// <paramref name="aadAccessToken"/> The password for the registry
        /// <paramref name="loginUrl"/> The Azure active directory access token to be used
        /// <paramref name="tenant"/> The tenant of the aad access token (optional)
        /// <paramref name="acquireNewAad"/> A function that can be called to refresh an aadAccessToken, providing a new one (optional) note, if this is not
        /// provided the aad access token will expire over time and calls wll cease to work.
        /// </summary>
        public AcrClientCredentials(string aadAccessToken, string loginUrl, string tenant = null,  AuthToken.acquireCallback acquireNewAad = null, CancellationToken cancellationToken = default)
        {
            _acrScopes = new Dictionary<string, string>();
            _acrAccessTokens = new Dictionary<string, AcrAccessToken>();
            _mode = LoginMode.TokenAad;

            // Proofing in case passed in loginurl includes https start.
            if (loginUrl.StartsWith("https://"))
            {
                loginUrl.Substring("https://".Length);
            }
            if (loginUrl.EndsWith("/"))
            {
                loginUrl.Substring(0, loginUrl.Length - 1);
            }
            _loginUrl = loginUrl;
            _requestCancellationToken = cancellationToken;
            _aadAccess = new AuthToken(aadAccessToken, acquireNewAad);
            _acrRefresh = new AcrRefreshToken(_aadAccess, _loginUrl);
            _tenant = tenant;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Called on initialization of the credentials. This sets forth the type of authorization to be used if necessary.
        /// </summary>
        public override void InitializeServiceClient<AzureContainerRegistryClient>(ServiceClient<AzureContainerRegistryClient> client)
        {
            if (_mode == LoginMode.Basic) // Basic Authentication
            {
                _authHeader = EncodeTo64(_username + ":" + _password);
            }
        }

        /// <summary>
        /// Handles all requests of the SDK providing the required authentication along the way.
        /// </summary>
        public override async Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (_mode == LoginMode.Basic)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", _authHeader);
            }
            else
            {
                string operation = "https://" + _loginUrl + request.RequestUri.AbsolutePath;
                string scope = await getScope(operation, request.Method.Method, request.RequestUri.AbsolutePath);

                request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + getAcrAccessToken(scope));
            }
            await base.ProcessHttpRequestAsync(request, cancellationToken);

        }

        #endregion

        #region Helpers

        /// <summary>
        /// Acquires a new ACR access token if necessary. It can also acquire a cached access token in order to avoid extra requests to
        /// the oauth2 endpoint improving efficiency.
        /// <param name='scope'> The scope for the particuar operation. Can be obtained from the Www-Authenticate header.
        /// </summary>
        public string getAcrAccessToken(string scope)
        {
            if (_mode == LoginMode.Basic)
            {
                throw new Exception("This Function cannot be invoked for requested Login Mode. Basic Authentication does not support JWT Tokens ");
            }

            // If Token is available or existed and can be renewed
            if (_acrAccessTokens.ContainsKey(scope))
            {
                if (!_acrAccessTokens[scope].CheckAndRefresh())
                {
                    throw new Exception("Access Token for scope " + scope + " expired and could not be refreshed");
                }

                return _acrAccessTokens[scope].Value;
            }

            if (_mode == LoginMode.TokenAad)
            {
                _acrAccessTokens[scope] = new AcrAccessToken(_acrRefresh, scope, _loginUrl);
            }
            else if (_mode == LoginMode.TokenAuth)
            {
                _acrAccessTokens[scope] = new AcrAccessToken(_username, _password, scope, _loginUrl);
            }

            return _acrAccessTokens[scope].Value;
        }

        /// <summary>
        /// Acquires the required scope for a specific operation. This will be done by obtaining a challenge and parsing out the scope
        /// from the ww-Authenticate header. In the event of failure (Some endpoints do not seem to return the scope) it will attempt
        /// resolution through a small local resolver.
        /// <param name='scope'> The scope for the particuar operation. Can be obtained from the Www-Authenticate header.
        /// </summary>

        public async Task<string> getScope(string operation, string method, string path)
        {

            if (_acrScopes.ContainsKey(method + ">" + operation))
            {
                return _acrScopes[method + ">" + operation];
            }

            HttpClient runtimeClient = new HttpClient();
            HttpResponseMessage response = null;
            string scope;
            try
            {
                response = await runtimeClient.SendAsync(new HttpRequestMessage(new HttpMethod(method), operation));
                Dictionary<string, string> data = parseHeader(response.Headers.GetValues("Www-Authenticate").FirstOrDefault());
                scope = data.ContainsKey("scope") ? data["scope"] : hardcodedScopes(path);
                _acrScopes[method + ">" + operation] = scope;
            }
            catch (Exception e)
            {
                throw new Exception("Could not identify appropriate Token scope: " + e.Message);
            }
            return scope;

        }

        /// <summary>
        /// Local resolver for endpoints that will often return no scope.
        /// <param name='operation'> Operation for which a scope is necessary
        /// </summary>
        private string hardcodedScopes(string operation)
        {
            switch (operation)
            {
                case "/acr/v1/_catalog":
                case "/v2/":
                    return "registry:catalog:*";
                default:
                    throw new Exception("Could not determine appropriate scope for the specified operation");

            }
        }

        /// <summary>
        /// Meant to parse out comma separated key value pairs delineated by the = sign. Accepts strings of the
        /// format "key=value,key2=value2..." . Note this method is meant to provide limited functionality and
        /// is not very robust.
        ///  </summary>
        private Dictionary<string, string> parseHeader(string header)
        {

            Dictionary<string, string> parsed = new Dictionary<string, string>();

            Regex re = new Regex(@"([\w\s]+)=""[^""]+"""); //Regex is required to allow multiple scopes like push,pull
            MatchCollection parts = re.Matches(header);

            foreach (Match part in parts)
            {
                string[] keyValues = part.ToString().Split('=');
                parsed.Add(keyValues[0], headerTrim(keyValues[1]));
            }

            return parsed;
        }

        /// <summary>
        /// Removes trailing whitespace or " characters.
        /// </summary>
        private string headerTrim(string toTrim)
        {
            toTrim = toTrim.Trim();
            if (toTrim.StartsWith("\"")) toTrim = toTrim.Substring(1);
            if (toTrim.EndsWith("\"")) toTrim = toTrim.Substring(0, toTrim.Length - 1);
            return toTrim;
        }

        /// <summary>
        /// Provides cleanup in case Cache is getting large. 
        ///</summary>
        public void clearCache()
        {
            _acrAccessTokens.Clear();
            _acrScopes.Clear();
        }

        static public string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        #endregion

    }
}



