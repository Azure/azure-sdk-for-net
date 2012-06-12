//-----------------------------------------------------------------------
// <copyright file="ProtocolHelper.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the ProtocolHelper class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.IO;
    using System.Net;
    using Microsoft.WindowsAzure.StorageClient.Protocol;
    using Microsoft.WindowsAzure.StorageClient.Tasks;
    using TaskSequence = System.Collections.Generic.IEnumerable<Microsoft.WindowsAzure.StorageClient.Tasks.ITask>;

    /// <summary>
    /// Assists in protocol implementation.
    /// </summary>
    internal static class ProtocolHelper
    {
        /// <summary>
        /// Gets the web request.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="options">The options.</param>
        /// <param name="retrieveRequest">The retrieve request.</param>
        /// <returns>The web request.</returns>
        internal static HttpWebRequest GetWebRequest(CloudBlobClient serviceClient, BlobRequestOptions options, Func<int, HttpWebRequest> retrieveRequest)
        {
            CommonUtils.AssertNotNull("options", options);            

            int timeoutInSeconds = options.Timeout.RoundUpToSeconds();

            var webRequest = retrieveRequest(timeoutInSeconds);
            CommonUtils.ApplyRequestOptimizations(webRequest, -1);

            return webRequest;
        }

        /// <summary>
        /// Generates a task sequence for accessing a cloud service where the content size is computed from an input stream.
        /// </summary>
        /// <param name="webRequest">A web request for accessing a cloud service.</param>
        /// <param name="writeRequestAction">An action for writing data to the body of a web request.</param>
        /// <param name="signRequestAction">An action for signing a web request.</param>
        /// <param name="getResponseTaskFunction">A delegate that generates a task for getting the response to a web request.</param>
        /// <param name="processResponseAction">An action for processing the response received.</param>
        /// <param name="readResponseAction">An action for reading data from a web response.</param>
        /// <returns>A task sequence for the operation.</returns>
        internal static TaskSequence GenerateServiceTask(
            HttpWebRequest webRequest,
            Action<Stream> writeRequestAction,
            Action<HttpWebRequest> signRequestAction,
            Func<HttpWebRequest, Task<WebResponse>> getResponseTaskFunction,
            Action<HttpWebResponse> processResponseAction,
            Action<Stream> readResponseAction)
        {
            if (writeRequestAction == null)
            {
                PrepareRequestWithoutBody(webRequest, signRequestAction);
            }
            else
            {
                // Flatten the tasks so exceptions at this level are not wrapped.
                TaskSequence tasks = UploadRequestBody(webRequest, writeRequestAction, signRequestAction);
                foreach (ITask task in tasks)
                {
                    yield return task;
                }
            }

            Task<WebResponse> responseTask = getResponseTaskFunction(webRequest);

            yield return responseTask;

            using (HttpWebResponse webResponse = responseTask.Result as HttpWebResponse)
            {
                if (processResponseAction != null)
                {
                    processResponseAction(webResponse);
                }

                if (readResponseAction != null)
                {
                    using (Stream responseStream = webResponse.GetResponseStream())
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        readResponseAction(responseStream);
                    }
                }
            }
        }

        /// <summary>
        /// Generates a task sequence that uploads the body of a request.
        /// </summary>
        /// <param name="webRequest">The web request.</param>
        /// <param name="writeRequestAction">An action for writing data to the request body.</param>
        /// <param name="signRequestAction">An action for signing the request.</param>
        /// <returns>A task sequence for the upload.</returns>
        private static TaskSequence UploadRequestBody(
            HttpWebRequest webRequest,
            Action<Stream> writeRequestAction,
            Action<HttpWebRequest> signRequestAction)
        {
            using (Stream memoryStream = new SmallBlockMemoryStream(Constants.DefaultBufferSize))
            {
                writeRequestAction(memoryStream);

                memoryStream.Seek(0, System.IO.SeekOrigin.Begin);

                CommonUtils.ApplyRequestOptimizations(webRequest, memoryStream.Length);

                signRequestAction(webRequest);

                Task<Stream> requestStreamTask = webRequest.GetRequestStreamAsync();
                yield return requestStreamTask;

                using (Stream requestStream = requestStreamTask.Result)
                {
                    // Copy the data
                    InvokeTaskSequenceTask copyTask = new InvokeTaskSequenceTask(() => { return memoryStream.WriteTo(requestStream); });
                    yield return copyTask;

                    // Materialize any exceptions
                    NullTaskReturn scratch = copyTask.Result;
                }
            }
        }

        /// <summary>
        /// Prepares a request that has no body.
        /// </summary>
        /// <param name="webRequest">The web request.</param>
        /// <param name="signRequestAction">An action for signing the request.</param>
        private static void PrepareRequestWithoutBody(
            HttpWebRequest webRequest,
            Action<HttpWebRequest> signRequestAction)
        {
            CommonUtils.ApplyRequestOptimizations(webRequest, -1);
            signRequestAction(webRequest);
        }
    }
}
