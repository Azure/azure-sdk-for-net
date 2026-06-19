// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

public partial class OAuthConsentRequestResponseItem
{
    [CodeGenMember("ConsentLink")]
    internal string InternalConsentLink { get; }

    /// <summary> Gets the URI the user can open to provide OAuth consent. </summary>
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
    public OAuthConsentRequestResponseItem(string consentLink, string serverLabel) : base(ResponseItemKind.OauthConsentRequest)
    {
        Argument.AssertNotNull(consentLink, nameof(consentLink));
        Argument.AssertNotNull(serverLabel, nameof(serverLabel));

        InternalConsentLink = consentLink;
        ServerLabel = serverLabel;
    }

    /// <summary> Initializes a new instance of <see cref="OAuthConsentRequestResponseItem"/>. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"> The agent that created the item. </param>
    /// <param name="responseId"> The response on which the item is created. </param>
    /// <param name="internalConsentLink"> The link the user can use to perform OAuth consent. </param>
    /// <param name="serverLabel"> The server label for the OAuth consent request. </param>
    /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
    internal OAuthConsentRequestResponseItem(string id, AgentReference agentReference, string responseId, string internalConsentLink, string serverLabel, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(ResponseItemKind.OauthConsentRequest)
    {
        InternalConsentLink = internalConsentLink;
        ServerLabel = serverLabel;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }

    /// <summary> Initializes a new instance of <see cref="OAuthConsentRequestResponseItem"/> for deserialization. </summary>
    internal OAuthConsentRequestResponseItem(): base(ResponseItemKind.OauthConsentRequest)
    {
    }
}
