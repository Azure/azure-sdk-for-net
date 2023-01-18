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
        /// <summary> Upload input file for a given test name. File size can&apos;t be more than 50 MB. Existing file with same name for the given test will be overwritten. File should be provided in the request body as application/octet-stream. </summary>
        /// <param name="waitUntil"> Defines how to use the LRO, if passed WaitUntil.Completed then waits for complete file validation</param>
        /// <param name="testId"> Unique name for the load test, must contain only lower-case alphabetic, numeric, underscore or hyphen characters. </param>
        /// <param name="fileName"> Unique name for test file with file extension like : App.jmx. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="timeSpan"> pollingInterval for poller class, default value or null value is treated as 5 secs</param>
        /// <param name="fileType"> File type. Allowed values: &quot;JMX_FILE&quot; | &quot;USER_PROPERTIES&quot; | &quot;ADDITIONAL_ARTIFACTS&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="testId"/>, <paramref name="fileName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="testId"/> or <paramref name="fileName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        public virtual FileUploadOperation UploadTestFile(WaitUntil waitUntil, string testId, string fileName, RequestContent content, TimeSpan? timeSpan = null, string fileType = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(testId, nameof(testId));
            Argument.AssertNotNullOrEmpty(fileName, nameof(fileName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("LoadTestAdministrationClient.UploadTestFile");
            scope.Start();

            if (timeSpan == null)
            {
                timeSpan = TimeSpan.FromSeconds(5);
            }

            try
            {
                Response initialResponse = UploadTestFile(testId, fileName, content, fileType, context);
                FileUploadOperation operation = new(testId, fileName, this, initialResponse);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion((TimeSpan)timeSpan, cancellationToken: default);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Upload input file for a given test name. File size can&apos;t be more than 50 MB. Existing file with same name for the given test will be overwritten. File should be provided in the request body as application/octet-stream. </summary>
        /// <param name="waitUntil"> Defines how to use the LRO, if passed WaitUntil.Completed then waits for complete file validation</param>
        /// <param name="testId"> Unique name for the load test, must contain only lower-case alphabetic, numeric, underscore or hyphen characters. </param>
        /// <param name="fileName"> Unique name for test file with file extension like : App.jmx. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="timeSpan"> pollingInterval for poller class, default value or null value is treated as 5 secs</param>
        /// <param name="fileType"> File type. Allowed values: &quot;JMX_FILE&quot; | &quot;USER_PROPERTIES&quot; | &quot;ADDITIONAL_ARTIFACTS&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="testId"/>, <paramref name="fileName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="testId"/> or <paramref name="fileName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        public virtual async Task<FileUploadOperation> UploadTestFileAsync(WaitUntil waitUntil, string testId, string fileName, RequestContent content, TimeSpan? timeSpan = null, string fileType = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(testId, nameof(testId));
            Argument.AssertNotNullOrEmpty(fileName, nameof(fileName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("LoadTestAdministrationClient.UploadTestFile");
            scope.Start();

            if (timeSpan == null)
            {
                timeSpan = TimeSpan.FromSeconds(5);
            }

            try
            {
                Response initialResponse = await UploadTestFileAsync(testId, fileName, content, fileType, context).ConfigureAwait(false);
                FileUploadOperation operation = new(testId, fileName, this, initialResponse);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync((TimeSpan)timeSpan, cancellationToken: default).ConfigureAwait(false);
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
