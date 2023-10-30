// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.ClientModel.Internal;
using System.Threading.Tasks;

namespace System.Net.ClientModel.Core;

public class KeyCredentialAuthenticationPolicy : PipelinePolicy
{
    private readonly string _name;
    private readonly KeyCredential _credential;
    private readonly string? _prefix;

    /// <summary>
    /// Initializes a new instance of the <see cref="KeyCredentialAuthenticationPolicy"/> class.
    /// </summary>
    /// <param name="credential">The <see cref="KeyCredential"/> used to authenticate requests.</param>
    /// <param name="header">The name of the request header used to send the key credential in the request.</param>
    /// <param name="keyPrefix">A prefix to prepend before the key credential in the header value.
    /// If provided, the prefix string will be followed by a space and then the credential string.
    /// For example, setting <c>valuePrefix</c> to "SharedAccessKey" will result in the header value
    /// being set fo "SharedAccessKey {credential.Key}".</param>
    public KeyCredentialAuthenticationPolicy(KeyCredential credential, string header, string? keyPrefix = null)
    {
        ClientUtilities.AssertNotNull(credential, nameof(credential));
        ClientUtilities.AssertNotNullOrEmpty(header, nameof(header));

        _credential = credential;
        _name = header;
        _prefix = keyPrefix;
    }

    public override void Process(ClientMessage message, PipelineEnumerator pipeline)
    {
        _credential.TryGetKey(out string key);

        message.Request.Headers.Set(_name, _prefix != null ? $"{_prefix} {key}" : key);

        pipeline.ProcessNext();
    }

    public override async ValueTask ProcessAsync(ClientMessage message, PipelineEnumerator pipeline)
    {
        _credential.TryGetKey(out string key);

        message.Request.Headers.Set(_name, _prefix != null ? $"{_prefix} {key}" : key);

        await pipeline.ProcessNextAsync().ConfigureAwait(false);
    }
}
