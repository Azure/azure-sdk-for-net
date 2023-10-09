﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ServiceModel.Rest.Internal;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core.Pipeline;

public class KeyCredentialPolicy : IPipelinePolicy<PipelineMessage, InvocationOptions>
{
    private readonly string _name;
    private readonly KeyCredential _credential;
    private readonly string? _prefix;

    /// <summary>
    /// Initializes a new instance of the <see cref="KeyCredentialPolicy"/> class.
    /// </summary>
    /// <param name="credential">The <see cref="KeyCredential"/> used to authenticate requests.</param>
    /// <param name="name">The name of the key header used for the credential.</param>
    /// <param name="prefix">The prefix to apply before the credential key. For example, a prefix of "SharedAccessKey" would result in
    /// a value of "SharedAccessKey {credential.Key}" being stamped on the request header with header key of <paramref name="name"/>.</param>
    public KeyCredentialPolicy(KeyCredential credential, string name, string? prefix = null)
    {
        ClientUtilities.AssertNotNull(credential, nameof(credential));
        ClientUtilities.AssertNotNullOrEmpty(name, nameof(name));

        _credential = credential;
        _name = name;
        _prefix = prefix;
    }

    public void Process(PipelineMessage message, InvocationOptions options, IPipelineEnumerator pipeline)
    {
        _credential.TryGetKey(out string key);
        message.Request.SetHeaderValue(_name, _prefix != null ? $"{_prefix} {key}" : key);

        pipeline.ProcessNext();
    }

    public async ValueTask ProcessAsync(PipelineMessage message, InvocationOptions options, IPipelineEnumerator pipeline)
    {
        _credential.TryGetKey(out string key);
        message.Request.SetHeaderValue(_name, _prefix != null ? $"{_prefix} {key}" : key);

        await pipeline.ProcessNextAsync().ConfigureAwait(false);
    }
}
