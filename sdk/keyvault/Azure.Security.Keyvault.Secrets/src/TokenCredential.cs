using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Secrets
{
    // TODO: Remove when TokenCredential is merged to base.
    public abstract class TokenCredential
    {        public abstract ValueTask<string> GetTokenAsync(string[] scopes, CancellationToken cancellationToken);
    }
    public class BearerTokenAuthenticationPolicy : HttpPipelinePolicy
    {
        private readonly TokenCredential _credential;

        private readonly string[] _scopes;

        private string _currentToken;

        private string _headerValue;

        public BearerTokenAuthenticationPolicy(TokenCredential credential, string scope) : this(credential, new[] { scope })
        {
        }

        public BearerTokenAuthenticationPolicy(TokenCredential credential, IEnumerable<string> scopes)
        {
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            if (scopes == null)
            {
                throw new ArgumentNullException(nameof(scopes));
            }

            _credential = credential;
            _scopes = scopes.ToArray();
        }

        public override Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsync(message, pipeline, true);
        }

        public override void Process(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            throw new NotImplementedException();
        }

        public async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            string token = await _credential.GetTokenAsync(_scopes, message.Cancellation).ConfigureAwait(false);

            if (token != _currentToken)
            {
                // Avoid per request allocations
                _currentToken = token;
                _headerValue = "Bearer " + token;
            }

            message.Request.Headers.SetValue("Authorization", _headerValue);

            await ProcessNextAsync(pipeline, message);   
        }
    }
}

