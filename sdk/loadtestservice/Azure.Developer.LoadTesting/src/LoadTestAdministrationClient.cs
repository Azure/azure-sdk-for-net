// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Developer.LoadTesting
{
    public partial class LoadTestAdministrationClient
    {
        /// <summary>
        /// UploadTestFile.
        /// </summary>
        public FileUploadOperation UploadTestFile(WaitUntil waitUntil, string testId, string fileName, RequestContent content, string fileType = null, RequestContext context = null)
        {
            Response initialResponse = UploadTestFile(testId, fileName, content, fileType, context);
            FileUploadOperation operation = new(testId, fileName, this, initialResponse);
            if (waitUntil == WaitUntil.Completed)
            {
                operation.WaitForCompletion();
            }
            return operation;
        }
    }
}
