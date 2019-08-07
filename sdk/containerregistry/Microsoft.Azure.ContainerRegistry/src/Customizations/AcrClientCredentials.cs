using Microsoft.IdentityModel.Tokens;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.ContainerRegistry
{
    /*Robust handling of Basic and OAUTH2 authentication flows for the Azure Container Registry Runtime .Net SDK.
     This class handles Basic Authentication as well as JWT token authentication using both username and password
     routes as well as through exchanging AAD tokens. */
    public class AcrClientCredentials : ServiceClientCredentials
    {

        #region Definitions
        private class TokenCredentials : ServiceClientCredentials
        {
            private string AuthHeader { get; set; }

            /*To be used for General Login Scheme*/
            public TokenCredentials(string username, string password)
            {
                AuthHeader = EncodeTo64(username + ":" + password);
            }
            /*To be used for exchanging AAD Tokens for ACR Tokens*/
            public TokenCredentials()
            {
                AuthHeader = null;
            }
            public override async Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                if (request == null)
                {
                    throw new ArgumentNullException("request");
                }
                if (AuthHeader != null)
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", AuthHeader);
                }
                await base.ProcessHttpRequestAsync(request, cancellationToken);
            }
        }

        public struct Token
        {
            public string TokenStr { get; set; }
            public DateTime Expiration { get; set; }
        }

        private static readonly JwtSecurityTokenHandler JwtSecurityClient = new JwtSecurityTokenHandler();

        public static Token MakeToken(string token)
        {
            Token tok = new Token();
            tok.TokenStr = token;
            SecurityToken fields = JwtSecurityClient.ReadToken(token);
            tok.Expiration = fields.ValidTo;
            return tok;
        }

        public enum LoginMode
        {
            Basic,
            TokenAuth,
            TokenAad
        }

        // Constant to refresh tokens slighly before they are to expire guarding against possible latency related crashes
        public const double LATENCY_SAFETY = 2;

        public delegate Token AADAcquireCallback();
        #endregion

        #region Instance Variables        
        private string AuthHeader { get; set; }
        private LoginMode Mode { get; set; }
        private string LoginUrl { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private String Tenant { get; set; }
        private CancellationToken RequestCancellationToken { get; set; }

        // Structure : Scope : Token
        private Dictionary<string, Token> AcrAccessTokens;

        // Structure : Method>Operation : Scope
        private Dictionary<string, string> AcrScopes;

        // Internal simplified client for Token Acquisition
        private Microsoft.Azure.ContainerRegistry.AzureContainerRegistryClient authClient;
        private AADAcquireCallback acquireNewAADToken;
        private Token AcrRefresh;
        private Token AadAccess;

        #endregion

        #region Constructors

        /* Constructor for use when providing user credentials. Users may specify if basic authorization is to be used or if more secure JWT token reliant
           authorization will be used. @Throws If LoginMode is set to TokenAad  */
        public AcrClientCredentials(LoginMode mode, string loginUrl, string username, string password, CancellationToken cancellationToken = default)
        {
            Mode = mode;
            if (Mode == LoginMode.TokenAad)
            {
                throw new Exception("AAD token authorization requires you to provide the AAD_access_token");
            }
            commonInit();
            LoginUrl = loginUrl;
            Username = username;
            Password = password;
            RequestCancellationToken = cancellationToken;
        }

        /*Constructor for use when providing an aad access token to be exchanged for an acr refresh token. Note that token expiration will require manually
         providing new aad tokens. This model assumes the client is able to do this authentication themselves for AAD tokens. A callback can be provided to 
         be executed once the ACR refresh token expires and can no longer be renewed as the provided Aad Token has expired.*/
        public AcrClientCredentials(string AAD_access_token, string loginUrl, string tenant = null, string LoginUri = null, CancellationToken cancellationToken = default, AADAcquireCallback callback = null)
        {
            commonInit();
            Mode = LoginMode.TokenAad;
            LoginUrl = loginUrl;
            RequestCancellationToken = cancellationToken;
            AadAccess = MakeToken(AAD_access_token);
            Tenant = tenant;
            acquireNewAADToken = callback;
        }

        private void commonInit()
        {
            AcrScopes = new Dictionary<string, string>();
            AcrAccessTokens = new Dictionary<string, Token>();
        }
        #endregion

        #region Overrides

        /* Called on initialization of the credentials. This sets forth the type of authorization to be used. */
        public override void InitializeServiceClient<AzureContainerRegistryClient>(ServiceClient<AzureContainerRegistryClient> client)
        {
            if (Mode == LoginMode.Basic) // Basic Authentication
            {
                AuthHeader = EncodeTo64(Username + ":" + Password);
            }
            else if (Mode == LoginMode.TokenAuth) // From Credentials
            {
                authClient = new Microsoft.Azure.ContainerRegistry.AzureContainerRegistryClient(new TokenCredentials(Username, Password));
                authClient.LoginUri = "https://" + LoginUrl;
            }
            else // From AAD Access Token
            {
                authClient = new Microsoft.Azure.ContainerRegistry.AzureContainerRegistryClient(new TokenCredentials());
                authClient.LoginUri = "https://" + LoginUrl;
                AcrRefresh = MakeToken(authClient.GetAcrRefreshTokenFromExchangeAsync("access_token", LoginUrl, Tenant, null, AadAccess.TokenStr).GetAwaiter().GetResult().RefreshTokenProperty);
            }
        }

        /*Handles all requests of the SDK providing the required authentication along the way.*/
        public override async Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (Mode == LoginMode.Basic)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", AuthHeader);
            }
            else
            {
                string operation = "https://" + LoginUrl + request.RequestUri.AbsolutePath;
                string scope = getScope(operation, request.Method.Method, request.RequestUri.AbsolutePath);
                request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + getAcrAccessToken(scope));
            }
            await base.ProcessHttpRequestAsync(request, cancellationToken);

        }

        private void Print(HttpRequestMessage request)
        {
            Console.WriteLine("Method:{0} > {1}", request.Method, request.RequestUri);
            Console.WriteLine("Headers: {0}", request.Headers.ToString());
            Console.WriteLine("Content: ");
            Console.WriteLine(request.Content?.ReadAsStringAsync().GetAwaiter().GetResult());
            Console.WriteLine("");
            //Console.WriteLine(request.Content?.Headers?.ToString());
        }

        #endregion

        #region Helpers

        /* Acquires a new ACR access token if necessary. It can also acquire a cached access token in order to avoid extra requests to
         * the oauth2 endpoint improving efficiency. */
        public string getAcrAccessToken(string scope)
        {
            if (Mode == LoginMode.Basic)
            {
                throw new Exception("This Function cannot be invoked for requested Login Mode. Basic Authentication does not support JWT Tokens ");
            }

            // If Token is available and unexpired
            if (AcrAccessTokens.ContainsKey(scope) && AcrAccessTokens[scope].Expiration > DateTime.UtcNow.AddMinutes(LATENCY_SAFETY))
            {
                return AcrAccessTokens[scope].TokenStr;
            }

            if (Mode == LoginMode.TokenAad)
            {
                validateOrUpdateRefreshToken(); // Validates that refresh token is still valid
                string acrAccess = authClient.GetAcrAccessTokenAsync(this.LoginUrl, scope, AcrRefresh.TokenStr).GetAwaiter().GetResult().AccessTokenProperty;
                AcrAccessTokens[scope] = MakeToken(acrAccess);

            }
            else if (Mode == LoginMode.TokenAuth)
            {
                string acrAccess = authClient.GetAcrAccessTokenFromLoginAsync(this.LoginUrl, scope).GetAwaiter().GetResult().AccessTokenProperty;
                AcrAccessTokens[scope] = MakeToken(acrAccess);
            }

            return AcrAccessTokens[scope].TokenStr;
        }

        private void validateOrUpdateRefreshToken()
        {

            // Token is still valid, no change necessary
            if (AcrRefresh.Expiration > DateTime.UtcNow.AddMinutes(LATENCY_SAFETY)) return;

            // Need to refresh AAD access token to obtain a new ACR refresh token
            if (AadAccess.Expiration < DateTime.UtcNow.AddMinutes(LATENCY_SAFETY))
            {
                if (acquireNewAADToken == null)
                {
                    throw new Exception("The Provided AAD token has expired and no callback was provided. ACR Refresh token cannot be updated.");
                }
                AadAccess = acquireNewAADToken();
            }

            if (AadAccess.Expiration < DateTime.UtcNow.AddMinutes(LATENCY_SAFETY))
            {
                throw new Exception("The newly provided AAD token is expired.");
            }

            // Obtain a new refresh Token using the regenerated / previously valid token
            AcrRefresh = MakeToken(authClient.GetAcrRefreshTokenFromExchangeAsync("access_token", this.LoginUrl, Tenant, null, AadAccess.TokenStr).GetAwaiter().GetResult().RefreshTokenProperty);

        }

        /* Acquires the required scope for a specific operation. This will be done by obtaining a chllange and parsing out the scope
         from the ww-Authenticate header. In the event of failure (Some endpoints do not seem to return the scope) it will attempt
         resolution through a small local resolver. */
        public string getScope(string operation, string method, string path)
        {

            if (AcrScopes.ContainsKey(method + ">" + operation))
            {
                return AcrScopes[method + ">" + operation];
            }

            HttpClient runtimeClient = new HttpClient();
            HttpResponseMessage response = null;
            string scope;
            try
            {
                response = runtimeClient.SendAsync(new HttpRequestMessage(new HttpMethod(method), operation)).GetAwaiter().GetResult();
                Dictionary<string, string> data = parseHeader(response.Headers.GetValues("Www-Authenticate").FirstOrDefault());
                scope = data.ContainsKey("scope") ? data["scope"] : hardcodedScopes(path);
                AcrScopes[method + ">" + operation] = scope;
            }
            catch (Exception e)
            {
                throw new Exception("Could not identify appropiate Token scope: " + e.Message);
            }
            return scope;

        }

        /*Local resolver for endpoints that will often retuen no scope.*/
        private string hardcodedScopes(string operation)
        {
            switch (operation)
            {
                case "/acr/v1/_catalog":
                case "/v2/":
                    return "registry:catalog:*";
                default:
                    throw new Exception("Could not determine appropiate scope for the specified operation");

            }
        }

        /* Meant to parse out comma separated key value pairs delineated by the = sign. Accepts strings of the
         format "key=value,key2=value2..." . Note this method is meant to provide limited functionality and
         is not very robust. */
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

        /* Removes trailing whitespace or " characters */
        private string headerTrim(string toTrim)
        {
            toTrim = toTrim.Trim();
            if (toTrim.StartsWith("\"")) toTrim = toTrim.Substring(1);
            if (toTrim.EndsWith("\"")) toTrim = toTrim.Substring(0, toTrim.Length - 1);
            return toTrim;
        }

        /*Provides cleanup in case Cache is getting large. */
        public void clearCache()
        {
            AcrAccessTokens.Clear();
            AcrScopes.Clear();
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

