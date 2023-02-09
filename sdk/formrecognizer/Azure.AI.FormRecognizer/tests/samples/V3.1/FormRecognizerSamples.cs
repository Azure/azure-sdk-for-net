// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.FormRecognizer.Tests;
using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.Samples
{
    [LiveOnly]
    [IgnoreServiceError(200, "3014", Message = "Generic error during training.", Reason = "https://github.com/Azure/azure-sdk-for-net/issues/28913")]
    public partial class FormRecognizerSamples : RecordedTestBase<FormRecognizerTestEnvironment>
    {
        public FormRecognizerSamples(bool isAsync) : base(isAsync, RecordedTestMode.Live)
        {
        }
    }
}
