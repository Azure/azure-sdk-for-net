// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.Language.QuestionAnswering.Authoring.Tests.Samples
{
    public partial class QuestionAnsweringAuthoringClientSamples : QuestionAnsweringAuthoringLiveTestBase
    {
        public QuestionAnsweringAuthoringClientSamples(bool isAsync, QuestionAnsweringAuthoringClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }
    }
}
