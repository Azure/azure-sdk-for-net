// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

public partial class OAuthConsentRequestResponseItem
{
    /// <summary> Initializes a new instance of <see cref="OAuthConsentRequestResponseItem"/>. </summary>
    /// <param name="consentLink"> The link the user can use to perform OAuth consent. </param>
    /// <param name="serverLabel"> The server label for the OAuth consent request. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="consentLink"/> or <paramref name="serverLabel"/> is null. </exception>
    public OAuthConsentRequestResponseItem(Uri consentLink, string serverLabel) : base(ResponseItemKind.OAuthConsentRequest)
    {
        Argument.AssertNotNull(consentLink, nameof(consentLink));
        Argument.AssertNotNull(serverLabel, nameof(serverLabel));

        ConsentLink = consentLink;
        ServerLabel = serverLabel;
    }

    /// <summary> Initializes a new instance of <see cref="OAuthConsentRequestResponseItem"/>. </summary>
    /// <param name="consentLink"> The link the user can use to perform OAuth consent. </param>
    /// <param name="serverLabel"> The server label for the OAuth consent request. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="consentLink"/> or <paramref name="serverLabel"/> is null. </exception>
    public OAuthConsentRequestResponseItem(string consentLink, string serverLabel) : this(new Uri(consentLink), serverLabel)
    { }

    /// <summary> Initializes a new instance of <see cref="OAuthConsentRequestResponseItem"/> for deserialization. </summary>
    internal OAuthConsentRequestResponseItem() : base(ResponseItemKind.OAuthConsentRequest)
    {
    }
}
