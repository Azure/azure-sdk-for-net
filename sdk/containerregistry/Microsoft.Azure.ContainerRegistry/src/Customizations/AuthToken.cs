using Microsoft.Rest;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.ContainerRegistry
{
    /// <summary>
    /// Simple authentication class for use with Token related api calls for determining scopes and other such things
    /// </summary>
    public class TokenCredentials : ServiceClientCredentials
    {
        private string _authHeader { get; set; }

        /*To be used for General Login Scheme*/
        public TokenCredentials(string username, string password)
        {
            _authHeader = EncodeTo64(username + ":" + password);
        }

        /*To be used for exchanging AAD Tokens for ACR Tokens*/
        public TokenCredentials()
        {
            _authHeader = null;
        }

        public override async Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            if (_authHeader != null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", _authHeader);
            }
            await base.ProcessHttpRequestAsync(request, cancellationToken);
        }

        static public string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }
    }

    /// <summary>
    /// This allows us to have refresh token chains. For example if an access token needs a refresh
    /// it can use the refresh token which can be refreshed using an aad access token which can be
    /// refreshed using an aad refresh token which can be obtained using service principals.This
    /// will all be done internally and thus abstracts much of the checking away.
    /// </summary>
    public class AuthToken
    {

        public delegate string acquireCallback();
        private static readonly JwtSecurityTokenHandler JwtSecurityClient = new JwtSecurityTokenHandler();

        // Constant to refresh tokens slightly before they are to expire guarding against possible latency related crashes
        private TimeSpan LATENCY_SAFETY { get; set; } = TimeSpan.FromMinutes(2);

        public string Value { get; set; }
        public DateTime Expiration { get; set; }
        public acquireCallback RefreshFn { get; set; }

        public AuthToken(string token)
        {
            Value = token;
            Expiration = JwtSecurityClient.ReadToken(Value).ValidTo;
        }

        public AuthToken(string token, acquireCallback refreshFn) : this(token)
        {
            RefreshFn = refreshFn;
        }

        //Extensibility purposes
        protected AuthToken() { }


        /* Returns true if refresh was successful. */
        public bool Refresh()
        {
            if (RefreshFn == null)
            {
                return false;
            }
            Value = RefreshFn();
            Expiration = JwtSecurityClient.ReadToken(Value).ValidTo;

            return true;
        }

        public bool NeedsRefresh()
        {
            return Expiration < DateTime.UtcNow.Add(LATENCY_SAFETY);
        }

        // Returns true if token is ready for use or false if token was expired and unable to refresh
        public bool CheckAndRefresh()
        {
            if (NeedsRefresh())
                return Refresh();
            return true;
        }
    }
    /// <summary>
    /// Refreshing this requires an aad access token. This provides the built in exchange functionality.
    /// </summary>

    public class AcrRefreshToken : AuthToken
    {
        private AzureContainerRegistryClient _authClient;
        public AcrRefreshToken(string token) : base(token) { }
        public AcrRefreshToken(AuthToken aadToken, string loginUrl)
        {
            _authClient = new AzureContainerRegistryClient(new TokenCredentials())
            {
                LoginUri = "https://" + loginUrl
            };
            RefreshFn = () =>
            {
                // Note: should be using real new access token
                aadToken.CheckAndRefresh();
                return _authClient.RefreshTokens.GetFromExchangeAsync("access_token", loginUrl, "", null, aadToken.Value).GetAwaiter().GetResult().RefreshTokenProperty;
            };
            Refresh();
        }
        public AcrRefreshToken(string token, acquireCallback refreshFn) : base(token, refreshFn) { }

    }
    /// <summary>
    /// Refreshing this requires an ACR refresh token or username and password. Both constructors are provided.
    /// </summary>
    public class AcrAccessToken : AuthToken
    {
        private AzureContainerRegistryClient _authClient;
        public string Scope { get; set; }
        public AcrAccessToken(string token) : base(token) { }
        public AcrAccessToken(string token, acquireCallback refreshFn) : base(token, refreshFn) { }
        public AcrAccessToken(AcrRefreshToken acrRefresh, string scope, string loginUrl)
        {
            Scope = scope;
            _authClient = new AzureContainerRegistryClient(new TokenCredentials())
            {
                LoginUri = "https://" + loginUrl
            };
            RefreshFn = () =>
            {
                acrRefresh.CheckAndRefresh();
                return _authClient.AccessTokens.GetAsync(loginUrl, scope, acrRefresh.Value).GetAwaiter().GetResult().AccessTokenProperty;
            };
            Refresh();
        }
        public AcrAccessToken(string username, string password, string scope, string loginUrl)
        {
            Scope = scope;
            _authClient = new AzureContainerRegistryClient(new TokenCredentials(username, password))
            {
                LoginUri = "https://" + loginUrl
            };
            RefreshFn = () =>
            {
                return _authClient.AccessTokens.GetFromLoginAsync(loginUrl, scope).GetAwaiter().GetResult().AccessTokenProperty;
            };
            Refresh();
        }
    }
}


