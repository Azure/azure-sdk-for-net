// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.MixedReality.Authentication
{
    /// <summary>
    /// Represents a token credential that can be used to access a Mixed Reality service.
    /// Implements <see cref="TokenCredential" />.
    /// </summary>
    /// <seealso cref="TokenCredential" />
    /// <remarks>
    /// This type us used to disambiguate other types of <see cref="TokenCredential"/> from one that is ready to
    /// be used to access a Mixed Reality service directly. <see cref="MixedRealityTokenProvider"/> can be used to
    /// exchange a traditional <see cref="TokenCredential"/> for a <see cref="MixedRealityTokenCredential"/>.
    /// Other types of <see cref="MixedRealityTokenCredential"/> are <see cref="StaticAccessTokenCredential"/>
    /// and <see cref="MixedRealityAccountKeyCredential"/>.
    /// </remarks>
    internal abstract class MixedRealityTokenCredential : TokenCredential
    {
    }
}
