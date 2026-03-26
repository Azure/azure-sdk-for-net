// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.Language.Conversations.Authoring
{
    // Suppress broken generated convenience methods that have incorrect return type
    // (generator bug: Operation<BinaryData> cannot convert to Operation<T>)
    [CodeGenType("AuthoringClient")]
    [CodeGenSuppress("Train", typeof(WaitUntil), typeof(string), typeof(ConversationAuthoringTrainingJobDetails), typeof(CancellationToken))]
    [CodeGenSuppress("TrainAsync", typeof(WaitUntil), typeof(string), typeof(ConversationAuthoringTrainingJobDetails), typeof(CancellationToken))]
    [CodeGenSuppress("CancelTrainingJob", typeof(WaitUntil), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CancelTrainingJobAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("EvaluateModel", typeof(WaitUntil), typeof(string), typeof(string), typeof(ConversationAuthoringEvaluationDetails), typeof(CancellationToken))]
    [CodeGenSuppress("EvaluateModelAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(ConversationAuthoringEvaluationDetails), typeof(CancellationToken))]
    public partial class ConversationAnalysisAuthoringClient
    {
    }
}
