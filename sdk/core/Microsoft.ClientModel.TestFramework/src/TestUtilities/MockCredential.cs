// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// A mock implementation of <see cref="AuthenticationTokenProvider"/> for testing purposes.
/// Provides configurable authentication tokens without requiring real credential validation.
/// </summary>
public class MockCredential : AuthenticationTokenProvider
{
    private readonly string _token;
    private readonly DateTimeOffset _expiresOn;

    /// <summary>
    /// Initializes a new instance of the <see cref="MockCredential"/> class with default values.
    /// </summary>
    public MockCredential() : this("mock-token", DateTimeOffset.UtcNow.AddHours(1))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MockCredential"/> class with the specified token and expiration.
    /// </summary>
    /// <param name="token">The mock authentication token to return.</param>
    /// <param name="expiresOn">The expiration time for the mock token.</param>
    public MockCredential(string token, DateTimeOffset expiresOn)
    {
        _token = token ?? throw new ArgumentNullException(nameof(token));
        _expiresOn = expiresOn;
    }

    /// <summary>
    /// Creates token options from the provided properties.
    /// This mock implementation returns null as no special token options are required for testing.
    /// </summary>
    /// <param name="properties">A dictionary of properties to use for creating token options.</param>
    /// <returns>null, as mock credentials don't require special token options.</returns>
    public override GetTokenOptions? CreateTokenOptions(IReadOnlyDictionary<string, object> properties)
    {
        return null;
    }

    /// <summary>
    /// Retrieves a mock authentication token synchronously.
    /// </summary>
    /// <param name="options">The token options (ignored in this mock implementation).</param>
    /// <param name="cancellationToken">The cancellation token (ignored in this mock implementation).</param>
    /// <returns>A mock <see cref="AuthenticationToken"/> with the configured token and expiration time.</returns>
    public override AuthenticationToken GetToken(GetTokenOptions options, CancellationToken cancellationToken)
    {
        return new AuthenticationToken(_token, "Bearer", _expiresOn, null);
    }

    /// <summary>
    /// Retrieves a mock authentication token asynchronously.
    /// </summary>
    /// <param name="options">The token options (ignored in this mock implementation).</param>
    /// <param name="cancellationToken">The cancellation token (ignored in this mock implementation).</param>
    /// <returns>A <see cref="ValueTask{AuthenticationToken}"/> containing a mock authentication token with the configured token and expiration time.</returns>
    public override ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, CancellationToken cancellationToken)
    {
        return new ValueTask<AuthenticationToken>(new AuthenticationToken(_token, "Bearer", _expiresOn, null));
    }
}
