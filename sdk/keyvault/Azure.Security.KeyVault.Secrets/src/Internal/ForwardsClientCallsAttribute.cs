// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    // Local copy of Azure.Core's internal ForwardsClientCallsAttribute so the
    // DiagnosticScopeValidatingInterceptor in Azure.Core.TestFramework
    // recognizes paged + LRO methods on <see cref="Azure.Security.KeyVault.Secrets.SecretClient"/>
    // as legitimate forwarders that delegate to KeyVaultSecretsClient. The
    // validator matches by full type name (Azure.Core.ForwardsClientCallsAttribute).
    [AttributeUsage(AttributeTargets.Method)]
    internal sealed class ForwardsClientCallsAttribute : Attribute { }
}
