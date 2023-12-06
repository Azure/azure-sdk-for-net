// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public class KeyCredentialAuthenticationPolicy : PipelinePolicy
{
    private readonly string _headerName;
    private readonly string? _keyPrefix;

    private readonly KeyCredential _credential;

    /// <summary>
    /// Initializes a new instance of the <see cref="KeyCredentialAuthenticationPolicy"/> class.
    /// </summary>
    /// <param name="credential">The <see cref="KeyCredential"/> used to authenticate requests.</param>
    /// <param name="headerName">The name of the request header used to send the key credential in the request.</param>
    /// <param name="keyPrefix">A prefix to prepend before the key credential in the header value.
    /// If provided, the prefix string will be followed by a space and then the credential string.
    /// For example, setting <c>valuePrefix</c> to "SharedAccessKey" will result in the header value
    /// being set fo "SharedAccessKey {credential.Key}".</param>
    public KeyCredentialAuthenticationPolicy(KeyCredential credential, string headerName, string? keyPrefix = null)
    {
        ClientUtilities.AssertNotNull(credential, nameof(credential));
        ClientUtilities.AssertNotNullOrEmpty(headerName, nameof(headerName));

        _credential = credential;

        _headerName = headerName;
        _keyPrefix = keyPrefix;
    }

    public sealed override void Process(PipelineMessage message, PipelineProcessor pipeline)
    {
        string key = _credential.GetValue();

        message.Request.Headers.Set(_headerName, _keyPrefix != null ? $"{_keyPrefix} {key}" : key);

        pipeline.ProcessNext();
    }

    public sealed override async ValueTask ProcessAsync(PipelineMessage message, PipelineProcessor pipeline)
    {
        string key = _credential.GetValue();

        message.Request.Headers.Set(_headerName, _keyPrefix != null ? $"{_keyPrefix} {key}" : key);

        await pipeline.ProcessNextAsync().ConfigureAwait(false);
    }
}
