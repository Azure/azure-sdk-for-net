// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;

namespace Azure.AI.Extensions.OpenAI;

public partial class OAuthConsentRequestResponseItem
{
    [CodeGenMember("ConsentLink")]
    internal string InternalConsentLink { get; }

    public Uri ConsentLink { get => new(InternalConsentLink); }

    /// <summary> Initializes a new instance of <see cref="OAuthConsentRequestResponseItem"/>. </summary>
    /// <param name="consentLink"> The link the user can use to perform OAuth consent. </param>
    /// <param name="serverLabel"> The server label for the OAuth consent request. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="consentLink"/> or <paramref name="serverLabel"/> is null. </exception>
    public OAuthConsentRequestResponseItem(Uri consentLink, string serverLabel) : this(consentLink?.AbsoluteUri, serverLabel)
    { }

    /// <summary> Initializes a new instance of <see cref="OAuthConsentRequestResponseItem"/>. </summary>
    /// <param name="consentLink"> The link the user can use to perform OAuth consent. </param>
    /// <param name="serverLabel"> The server label for the OAuth consent request. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="consentLink"/> or <paramref name="serverLabel"/> is null. </exception>
    public OAuthConsentRequestResponseItem(string consentLink, string serverLabel) : base(AgentResponseItemKind.OauthConsentRequest)
    {
        Argument.AssertNotNull(consentLink, nameof(consentLink));
        Argument.AssertNotNull(serverLabel, nameof(serverLabel));

        InternalConsentLink = consentLink;
        ServerLabel = serverLabel;
    }
}
