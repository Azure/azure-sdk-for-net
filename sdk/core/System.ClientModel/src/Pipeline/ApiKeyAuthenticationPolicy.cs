// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

/// <summary>
/// A <see cref="PipelinePolicy"/> that uses an <see cref="ApiKeyCredential"/>
/// to set a value on a <see cref="PipelineRequest"/> to authenticate with the
/// cloud service.
/// </summary>
public class ApiKeyAuthenticationPolicy : PipelinePolicy
{
    private readonly string _name;
    private readonly string? _keyPrefix;
    private readonly KeyLocation _location;
    private readonly ApiKeyCredential _credential;

    /// <summary>
    /// Create a new instance of the <see cref="ApiKeyAuthenticationPolicy"/>
    /// class, where the credential value will be specified in a request header.
    /// </summary>
    /// <param name="credential">The <see cref="ApiKeyCredential"/> used to
    /// authenticate requests.</param>
    /// <param name="headerName">The name of the request header used to send
    /// the key credential in the request.</param>
    /// <param name="keyPrefix">A prefix to prepend before the key credential in
    /// the header value.
    /// If provided, the prefix string will be followed by a space and then the
    /// credential string.  For example, setting <c>valuePrefix</c> to
    /// "SharedAccessKey" will result in the header value being set to
    /// "SharedAccessKey {credential.Key}".</param>
    public static ApiKeyAuthenticationPolicy CreateHeaderApiKeyPolicy(ApiKeyCredential credential, string headerName, string? keyPrefix = null)
    {
        Argument.AssertNotNull(credential, nameof(credential));
        Argument.AssertNotNullOrEmpty(headerName, nameof(headerName));

        return new ApiKeyAuthenticationPolicy(credential, headerName, KeyLocation.Header, keyPrefix);
    }

    /// <summary>
    /// Create a new instance of the <see cref="ApiKeyAuthenticationPolicy"/>
    /// class, where the credential value will be set in the <c>Authorization</c>
    /// header on the <see cref="PipelineRequest"/> with a <c>Basic</c> prefix.
    /// </summary>
    /// <param name="credential">The <see cref="ApiKeyCredential"/> used to
    /// authenticate requests.</param>
    public static ApiKeyAuthenticationPolicy CreateBasicAuthorizationPolicy(ApiKeyCredential credential)
    {
        Argument.AssertNotNull(credential, nameof(credential));

        return new ApiKeyAuthenticationPolicy(credential, "Authorization", KeyLocation.Header, "Basic");
    }

    /// <summary>
    /// Create a new instance of the <see cref="ApiKeyAuthenticationPolicy"/>
    /// class, where the credential value will be set in the <c>Authorization</c>
    /// header on the <see cref="PipelineRequest"/> with a <c>Bearer</c> prefix.
    /// </summary>
    /// <param name="credential">The <see cref="ApiKeyCredential"/> used to
    /// authenticate requests.</param>
    public static ApiKeyAuthenticationPolicy CreateBearerAuthorizationPolicy(ApiKeyCredential credential)
    {
        Argument.AssertNotNull(credential, nameof(credential));

        return new ApiKeyAuthenticationPolicy(credential, "Authorization", KeyLocation.Header, "Bearer");
    }

    private ApiKeyAuthenticationPolicy(ApiKeyCredential credential, string name, KeyLocation keyLocation, string? keyPrefix = null)
    {
        Argument.AssertNotNull(credential, nameof(credential));
        Argument.AssertNotNullOrEmpty(name, nameof(name));

        _credential = credential;

        _name = name;
        _location = keyLocation;
        _keyPrefix = keyPrefix;
    }

    /// <inheritdoc/>
    public sealed override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        SetKey(message);

        ProcessNext(message, pipeline, currentIndex);
    }

    /// <inheritdoc/>
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
            default:
                throw new InvalidOperationException($"Unsupported value for Key location: '{_location}'.");
        }
    }

    private void SetHeader(PipelineMessage message)
    {
        _credential.Deconstruct(out string key);

        message.Request.Headers.Set(_name, _keyPrefix != null ? $"{_keyPrefix} {key}" : key);
    }

    private enum KeyLocation
    {
        Header = 0,
        // Query-based keys are tracked by
        // https://github.com/Azure/azure-sdk-for-net/issues/41391
    }
}
