// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;

namespace Azure.AI.FormRecognizer.Tests
{
    public class FormRecognizerRecordMatcher : RecordMatcher
    {
        public FormRecognizerRecordMatcher(RecordedTestSanitizer sanitizer) : base(sanitizer)
        {
            // TODO:
            // "Content-Length" header is being ignored because we are not sanitizing the request body, which
            // contains the FORM_RECOGNIZER_BLOB_CONTAINER_SAS_URL sanitized variable. For this reason, a length
            // mismatch happens. We can safely remove this entire file when body sanitizing is in place.

            ExcludeHeaders.Add("Content-Length");
        }
    }
}
