// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Language.QuestionAnswering.Tests.Samples
{
    public partial class QuestionAnsweringClientSamples : QuestionAnsweringTestBase<QuestionAnsweringClient>
    {
        public QuestionAnsweringClientSamples(bool isAsync, QuestionAnsweringClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }
    }
}
