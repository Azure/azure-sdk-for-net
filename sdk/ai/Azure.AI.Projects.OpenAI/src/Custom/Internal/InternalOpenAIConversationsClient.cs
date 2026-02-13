// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Threading;

using OpenAI;

namespace Azure.AI.Projects.OpenAI;

[CodeGenSuppress("CreateConversation", typeof(InternalMetadataContainer), typeof(IEnumerable<InputItem>), typeof(CancellationToken))]
[CodeGenSuppress("CreateConversationAsync", typeof(InternalMetadataContainer), typeof(IEnumerable<InputItem>), typeof(CancellationToken))]
internal partial class Conversations {}