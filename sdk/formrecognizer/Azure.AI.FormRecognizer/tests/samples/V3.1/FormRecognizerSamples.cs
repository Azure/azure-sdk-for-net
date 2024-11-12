// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.FormRecognizer.Tests;
using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.Samples
{
    [LiveOnly]
    [AsyncOnly] // Ensure that each sample will only run once.
    public partial class FormRecognizerSamples : RecordedTestBase<FormRecognizerTestEnvironment>
    {
        public FormRecognizerSamples(bool isAsync) : base(isAsync, RecordedTestMode.Live)
        {
        }
    }
}
