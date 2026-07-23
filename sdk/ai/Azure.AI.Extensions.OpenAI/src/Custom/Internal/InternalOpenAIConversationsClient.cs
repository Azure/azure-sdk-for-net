// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.AI.Extensions.OpenAI.Internal;

namespace Azure.AI.Extensions.OpenAI;

[CodeGenSuppress("CreateConversation", typeof(InternalMetadataContainer), typeof(IEnumerable<global::OpenAI.Responses.ResponseItem>), typeof(CancellationToken))]
[CodeGenSuppress("CreateConversation", typeof(InternalMetadataContainer), typeof(IEnumerable<global::OpenAI.Responses.ResponseItem>), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("CreateConversationAsync", typeof(InternalMetadataContainer), typeof(IEnumerable<global::OpenAI.Responses.ResponseItem>), typeof(CancellationToken))]
[CodeGenSuppress("CreateConversationAsync", typeof(InternalMetadataContainer), typeof(IEnumerable<global::OpenAI.Responses.ResponseItem>), typeof(string), typeof(CancellationToken))]
internal partial class Conversations { }
