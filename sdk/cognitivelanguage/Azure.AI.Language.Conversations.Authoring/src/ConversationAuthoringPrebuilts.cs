// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;
using Azure.AI.Language.Conversations.Authoring.Models;
using System.Threading.Tasks;
using System;
using Azure.Core.Pipeline;
using Autorest.CSharp.Core;

namespace Azure.AI.Language.Conversations.Authoring
{
    [CodeGenSuppress("GetSupportedPrebuiltEntitiesAsync", typeof(int?), typeof(int?), typeof(int?), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSupportedPrebuiltEntities", typeof(int?), typeof(int?), typeof(int?), typeof(string), typeof(string), typeof(CancellationToken))]
    public partial class ConversationAuthoringPrebuilts
    {
    }
}
