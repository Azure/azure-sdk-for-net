// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.Tests
{
    public class FormRecognizerRecordMatcher : RecordMatcher
    {
        public FormRecognizerRecordMatcher() : base(compareBodies: false)
        {
            // TODO:
            // "Content-Length" header is being ignored because we are not sanitizing the request body, which
            // contains the FORM_RECOGNIZER_BLOB_CONTAINER_SAS_URL sanitized variable. For this reason, a length
            // mismatch happens. We can safely remove this line when body sanitizing is in place (we may want to
            // enable request body matching as well).

            ExcludeHeaders.Add("Content-Length");
        }
    }
}
