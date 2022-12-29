// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Developer.LoadTesting
{
    public partial class LoadTestAdministrationClient
    {
        /// <summary>
        /// UploadTestFile.
        /// </summary>
        public virtual FileUploadOperation BeginUploadTestFile(string testId, string fileName, RequestContent content, WaitUntil waitUntil = WaitUntil.Started, string fileType = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(testId, nameof(testId));
            Argument.AssertNotNullOrEmpty(fileName, nameof(fileName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("LoadTestAdministrationClient.BeginUploadTestFile");
            scope.Start();

            try
            {
                Response initialResponse = UploadTestFile(testId, fileName, content, fileType, context);
                FileUploadOperation operation = new(testId, fileName, this, initialResponse);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion();
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// UploadTestFileAsync
        /// </summary>
        public virtual async Task<FileUploadOperation> BeginUploadTestFileAsync(string testId, string fileName, RequestContent content, WaitUntil waitUntil = WaitUntil.Started, string fileType = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(testId, nameof(testId));
            Argument.AssertNotNullOrEmpty(fileName, nameof(fileName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("LoadTestAdministrationClient.BeginUploadTestFile");
            scope.Start();

            try
            {
                Response initialResponse = await UploadTestFileAsync(testId, fileName, content, fileType, context).ConfigureAwait(false);
                FileUploadOperation operation = new(testId, fileName, this, initialResponse);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync().ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
