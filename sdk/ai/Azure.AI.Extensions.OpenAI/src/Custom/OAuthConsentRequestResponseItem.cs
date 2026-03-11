// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;

namespace Azure.AI.Extensions.OpenAI;

public partial class OAuthConsentRequestResponseItem
{
    [CodeGenMember("ConsentLink")]
    internal string InternalConsentLink { get; }

    public Uri ConsentLink { get => new(InternalConsentLink); }
}
