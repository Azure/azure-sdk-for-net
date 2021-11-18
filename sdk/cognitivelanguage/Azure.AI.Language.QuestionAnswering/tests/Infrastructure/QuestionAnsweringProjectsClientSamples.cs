// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.Language.QuestionAnswering.Projects;
using Azure.Core.TestFramework;

namespace Azure.AI.Language.QuestionAnswering.Tests.Samples
{
    public partial class QuestionAnsweringProjectsClientSamples : QuestionAnsweringTestBase<QuestionAnsweringProjectsClient>
    {
        public QuestionAnsweringProjectsClientSamples(bool isAsync, QuestionAnsweringClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion,  RecordedTestMode.Live)
        {
        }
    }
}
