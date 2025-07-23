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
/// TODO.
/// </summary>
public class MockCredential : AuthenticationTokenProvider
{
    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="properties"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override GetTokenOptions? CreateTokenOptions(IReadOnlyDictionary<string, object> properties)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="options"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override AuthenticationToken GetToken(GetTokenOptions options, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="options"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
