// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public class KeyCredentialAuthenticationPolicy : PipelinePolicy
{
    private readonly string _name;
    private readonly string? _keyPrefix;
    private readonly KeyLocation _location;
    private readonly KeyCredential _credential;

    /// <summary>
    /// Create a new instance of the <see cref="KeyCredentialAuthenticationPolicy"/> class, where the
    /// credential value will be specified in a request header.
    /// </summary>
    /// <param name="credential">The <see cref="KeyCredential"/> used to authenticate requests.</param>
    /// <param name="headerName">The name of the request header used to send the key credential in the request.</param>
    /// <param name="keyPrefix">A prefix to prepend before the key credential in the header value.
    /// If provided, the prefix string will be followed by a space and then the credential string.
    /// For example, setting <c>valuePrefix</c> to "SharedAccessKey" will result in the header value
    /// being set fo "SharedAccessKey {credential.Key}".</param>
    public static KeyCredentialAuthenticationPolicy CreateHeaderPolicy(KeyCredential credential, string headerName, string? keyPrefix = null)
    {
        ClientUtilities.AssertNotNull(credential, nameof(credential));
        ClientUtilities.AssertNotNullOrEmpty(headerName, nameof(headerName));

        return new KeyCredentialAuthenticationPolicy(credential, headerName, KeyLocation.Header, keyPrefix);
    }

    public static KeyCredentialAuthenticationPolicy CreateQueryPolicy(KeyCredential credential, string queryName)
    {
        // TODO: Add tests for this implementation if the API is approved.
        ClientUtilities.AssertNotNull(credential, nameof(credential));
        ClientUtilities.AssertNotNullOrEmpty(queryName, nameof(queryName));

        return new KeyCredentialAuthenticationPolicy(credential, queryName, KeyLocation.Query);
    }

    /// <summary>
    /// Create a new instance of the <see cref="KeyCredentialAuthenticationPolicy"/> class, where the
    /// credential value will be specified in a request header.
    /// </summary>
    /// <param name="credential">The <see cref="KeyCredential"/> used to authenticate requests.</param>
    /// <param name="headerName">The name of the request header used to send the key credential in the request.</param>
    /// <param name="keyPrefix">A prefix to prepend before the key credential in the header value.
    /// If provided, the prefix string will be followed by a space and then the credential string.
    /// For example, setting <c>valuePrefix</c> to "SharedAccessKey" will result in the header value
    /// being set fo "SharedAccessKey {credential.Key}".</param>
    public KeyCredentialAuthenticationPolicy(KeyCredential credential, string headerName = "Authorization", string? keyPrefix = null)
        : this(credential, headerName, KeyLocation.Header, keyPrefix)
    {
    }

    private KeyCredentialAuthenticationPolicy(KeyCredential credential, string name, KeyLocation keyLocation, string? keyPrefix = null)
    {
        ClientUtilities.AssertNotNull(credential, nameof(credential));
        ClientUtilities.AssertNotNullOrEmpty(name, nameof(name));

        _credential = credential;

        _name = name;
        _location = keyLocation;
        _keyPrefix = keyPrefix;
    }

    public sealed override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        SetKey(message);

        ProcessNext(message, pipeline, currentIndex);
    }

    public sealed override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        SetKey(message);

        await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);
    }

    private void SetKey(PipelineMessage message)
    {
        switch (_location)
        {
            case KeyLocation.Header:
                SetHeader(message);
                break;
            case KeyLocation.Query:
                AddQueryParameter(message);
                break;
            default:
                throw new InvalidOperationException($"Unsupported value for Key location: '{_location}'.");
        }
    }

    private void SetHeader(PipelineMessage message)
    {
        string key = _credential.GetValue();
        message.Request.Headers.Set(_name, _keyPrefix != null ? $"{_keyPrefix} {key}" : key);
    }

    private void AddQueryParameter(PipelineMessage message)
    {
        // TODO: optimize using Span APIs

        string key = _credential.GetValue();

        StringBuilder query = new StringBuilder();
        query.Append(_name);
        query.Append('=');
        query.Append(Uri.EscapeDataString(key));

        UriBuilder uriBuilder = new(message.Request.Uri);
        uriBuilder.Query = (uriBuilder.Query != null && uriBuilder.Query.Length > 1) ?
            uriBuilder.Query.Substring(1) + "&" + query.ToString() :
            query.ToString();

        message.Request.Uri = uriBuilder.Uri;
    }

    private enum KeyLocation
    {
        Header = 0,
        Query = 1,
    }
}
