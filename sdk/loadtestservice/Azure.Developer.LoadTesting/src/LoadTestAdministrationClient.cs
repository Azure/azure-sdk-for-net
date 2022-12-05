// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core.Pipeline;
using Azure.Core;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading;

namespace Azure.Developer.LoadTesting
{
    public partial class LoadTestAdministrationClient
    {
        internal LoadTestAdministrationClient(string endpoint, TokenCredential credential) : this(endpoint, credential, new AzureLoadTestingClientOptions())
        {
        }

        internal LoadTestAdministrationClient(string endpoint, TokenCredential credential, AzureLoadTestingClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new AzureLoadTestingClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary> Upload input file for a given test name. File size can&apos;t be more than 50 MB. Existing file with same name for the given test will be overwritten. File should be provided in the request body as multipart/form-data. </summary>
        /// <param name="testId"> Unique name for load test, must be a valid URL character ^[a-z0-9_-]*$. </param>
        /// <param name="fileId"> Unique identifier for test file, must be a valid URL character ^[a-z0-9_-]*$. </param>
        /// <param name="fileName"> Filename to upload to loadtest. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="fileType"> Integer representation of the file type (0 = JMX_FILE, 1 = USER_PROPERTIES, 2 = ADDITIONAL_ARTIFACTS). </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="testId"/>, <paramref name="fileId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="testId"/> or <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call UploadTestFile with required parameters and request content, and how to parse the result.
        /// <code><![CDATA[
        /// var credential = new DefaultAzureCredential();
        /// var client = new LoadTestAdministrationClient("<https://my-service.azure.com>", credential);
        /// var data = File.OpenRead("<filePath>");
        /// Response response = client.UploadTestFile("<testId>", "<fileId>", RequestContent.Create(data));
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.ToString());
        /// ]]></code>
        /// This sample shows how to call UploadTestFile with all parameters and request content, and how to parse the result.
        /// <code><![CDATA[
        /// var credential = new DefaultAzureCredential();
        /// var client = new LoadTestAdministrationClient("<https://my-service.azure.com>", credential);
        /// var data = File.OpenRead("<filePath>");
        /// Response response = client.UploadTestFile("<testId>", "<fileId>", RequestContent.Create(data), 1234);
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("url").ToString());
        /// Console.WriteLine(result.GetProperty("fileId").ToString());
        /// Console.WriteLine(result.GetProperty("filename").ToString());
        /// Console.WriteLine(result.GetProperty("fileType").ToString());
        /// Console.WriteLine(result.GetProperty("expireTime").ToString());
        /// Console.WriteLine(result.GetProperty("validationStatus").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// Response Body:
        /// Schema for <c>FileUrl</c>:
        /// <code>{
        ///   url: string, # Optional. File URL.
        ///   fileId: string, # Optional. File unique identifier.
        ///   filename: string, # Optional. Name of the file.
        ///   fileType: &quot;0&quot; | &quot;1&quot; | &quot;2&quot;, # Optional. Integer representation of the file type (0 = JMX_FILE, 1 = USER_PROPERTIES, 2 = ADDITIONAL_ARTIFACTS)
        ///   expireTime: string (ISO 8601 Format), # Optional. Expiry time of the file
        ///   validationStatus: string, # Optional. Validation status of the file
        /// }
        /// </code>
        /// </remarks>
        public virtual Response UploadTestFile(string testId, string fileId, string fileName, RequestContent content, int? fileType = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(testId, nameof(testId));
            Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("LoadTestAdministrationClient.UploadTestFile");
            scope.Start();
            try
            {
                //Random random = new Random();

                //const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
                //string randomBoundry = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());

                string randomBoundry = "hybboH2feH";
                string boundary = "----WebkitFormBoundary" + randomBoundry;

                String newline = "" + (char)0x0D + (char)0x0A;
                Stream body = new MemoryStream();
                StreamWriter writer = new StreamWriter(body);
                writer.Write("--" + boundary + newline);
                writer.Write("Content-Disposition: form-data; name=\"file\"; filename=\"" + fileName + "\"" + newline);
                writer.Write("Content-Type: application/octet-stream" + newline + newline);
                writer.Flush();

                writer.Write(content);
                //content.WriteTo(body, new System.Threading.CancellationToken());

                writer.Write(newline + newline + "--" + boundary + "--");
                writer.Flush();
                body.Position = 0;
                Console.WriteLine(body);

                using HttpMessage message = CreateUploadTestFileRequest(testId, fileId, RequestContent.Create(body), fileType, context);
                message.Request.Headers.SetValue("Content-Type", "multipart/form-data;boundary=" + boundary);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Upload input file for a given test name. File size can&apos;t be more than 50 MB. Existing file with same name for the given test will be overwritten. File should be provided in the request body as multipart/form-data. </summary>
        /// <param name="testId"> Unique name for load test, must be a valid URL character ^[a-z0-9_-]*$. </param>
        /// <param name="fileId"> Unique identifier for test file, must be a valid URL character ^[a-z0-9_-]*$. </param>
        /// <param name="file"> FileStream to upload to loadtest. </param>
        /// <param name="fileType"> Integer representation of the file type (0 = JMX_FILE, 1 = USER_PROPERTIES, 2 = ADDITIONAL_ARTIFACTS). </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="testId"/>, <paramref name="fileId"/> </exception>
        /// <exception cref="ArgumentException"> <paramref name="testId"/> or <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call UploadTestFile with required parameters and request content, and how to parse the result.
        /// <code><![CDATA[
        /// var credential = new DefaultAzureCredential();
        /// var client = new LoadTestAdministrationClient("<https://my-service.azure.com>", credential);
        /// var data = File.OpenRead("<filePath>");
        /// Response response = client.UploadTestFile("<testId>", "<fileId>", data);
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.ToString());
        /// ]]></code>
        /// This sample shows how to call UploadTestFile with all parameters and request content, and how to parse the result.
        /// <code><![CDATA[
        /// var credential = new DefaultAzureCredential();
        /// var client = new LoadTestAdministrationClient("<https://my-service.azure.com>", credential);
        /// var data = File.OpenRead("<filePath>");
        /// Response response = client.UploadTestFile("<testId>", "<fileId>", data, 1234);
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("url").ToString());
        /// Console.WriteLine(result.GetProperty("fileId").ToString());
        /// Console.WriteLine(result.GetProperty("filename").ToString());
        /// Console.WriteLine(result.GetProperty("fileType").ToString());
        /// Console.WriteLine(result.GetProperty("expireTime").ToString());
        /// Console.WriteLine(result.GetProperty("validationStatus").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// Response Body:
        /// Schema for <c>FileUrl</c>:
        /// <code>{
        ///   url: string, # Optional. File URL.
        ///   fileId: string, # Optional. File unique identifier.
        ///   filename: string, # Optional. Name of the file.
        ///   fileType: &quot;0&quot; | &quot;1&quot; | &quot;2&quot;, # Optional. Integer representation of the file type (0 = JMX_FILE, 1 = USER_PROPERTIES, 2 = ADDITIONAL_ARTIFACTS)
        ///   expireTime: string (ISO 8601 Format), # Optional. Expiry time of the file
        ///   validationStatus: string, # Optional. Validation status of the file
        /// }
        /// </code>
        /// </remarks>
        public virtual Response UploadTestFile(string testId, string fileId, FileStream file, int? fileType = null, RequestContext context = null)
        {
            string fileName = Path.GetFileName(file.Name);
            Console.WriteLine(fileName);

            return UploadTestFile(testId, fileId, fileName, RequestContent.Create(file), fileType, context);
        }

        /// <summary> Upload input file for a given test name. File size can&apos;t be more than 50 MB. Existing file with same name for the given test will be overwritten. File should be provided in the request body as multipart/form-data. </summary>
        /// <param name="testId"> Unique name for load test, must be a valid URL character ^[a-z0-9_-]*$. </param>
        /// <param name="fileId"> Unique identifier for test file, must be a valid URL character ^[a-z0-9_-]*$. </param>
        /// <param name="fileName"> Filename to upload to loadtest. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="fileType"> Integer representation of the file type (0 = JMX_FILE, 1 = USER_PROPERTIES, 2 = ADDITIONAL_ARTIFACTS). </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="testId"/>, <paramref name="fileId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="testId"/> or <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call UploadTestFile with required parameters and request content, and how to parse the result.
        /// <code><![CDATA[
        /// var credential = new DefaultAzureCredential();
        /// var client = new LoadTestAdministrationClient("<https://my-service.azure.com>", credential);
        /// var data = File.OpenRead("<filePath>");
        /// Response response = client.UploadTestFile("<testId>", "<fileId>", RequestContent.Create(data));
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.ToString());
        /// ]]></code>
        /// This sample shows how to call UploadTestFile with all parameters and request content, and how to parse the result.
        /// <code><![CDATA[
        /// var credential = new DefaultAzureCredential();
        /// var client = new LoadTestAdministrationClient("<https://my-service.azure.com>", credential);
        /// var data = File.OpenRead("<filePath>");
        /// Response response = client.UploadTestFile("<testId>", "<fileId>", RequestContent.Create(data), 1234);
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("url").ToString());
        /// Console.WriteLine(result.GetProperty("fileId").ToString());
        /// Console.WriteLine(result.GetProperty("filename").ToString());
        /// Console.WriteLine(result.GetProperty("fileType").ToString());
        /// Console.WriteLine(result.GetProperty("expireTime").ToString());
        /// Console.WriteLine(result.GetProperty("validationStatus").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// Response Body:
        /// Schema for <c>FileUrl</c>:
        /// <code>{
        ///   url: string, # Optional. File URL.
        ///   fileId: string, # Optional. File unique identifier.
        ///   filename: string, # Optional. Name of the file.
        ///   fileType: &quot;0&quot; | &quot;1&quot; | &quot;2&quot;, # Optional. Integer representation of the file type (0 = JMX_FILE, 1 = USER_PROPERTIES, 2 = ADDITIONAL_ARTIFACTS)
        ///   expireTime: string (ISO 8601 Format), # Optional. Expiry time of the file
        ///   validationStatus: string, # Optional. Validation status of the file
        /// }
        /// </code>
        /// </remarks>
        public virtual async Task<Response> UploadTestFileAsync(string testId, string fileId, string fileName, RequestContent content, int? fileType = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(testId, nameof(testId));
            Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("LoadTestAdministrationClient.UploadTestFile");
            scope.Start();
            try
            {
                //Random random = new Random();

                //const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
                //string randomBoundry = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());

                string randomBoundry = "hybboH2feH";
                string boundary = "----WebkitFormBoundary" + randomBoundry;

                String newline = "" + (char)0x0D + (char)0x0A;
                Stream body = new MemoryStream();
                StreamWriter writer = new StreamWriter(body);
                writer.Write("--" + boundary + newline);
                writer.Write("Content-Disposition: form-data; name=\"file\"; filename=\"" + fileName + "\"" + newline);
                writer.Write("Content-Type: application/octet-stream" + newline + newline);
                writer.Flush();

                writer.Write(content);
                //content.WriteTo(body, new System.Threading.CancellationToken());

                writer.Write(newline + newline + "--" + boundary + "--");
                writer.Flush();
                body.Position = 0;

                using HttpMessage message = CreateUploadTestFileRequest(testId, fileId, RequestContent.Create(body), fileType, context);
                message.Request.Headers.SetValue("Content-Type", "multipart/form-data;boundary=" + boundary);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Upload input file for a given test name. File size can&apos;t be more than 50 MB. Existing file with same name for the given test will be overwritten. File should be provided in the request body as multipart/form-data. </summary>
        /// <param name="testId"> Unique name for load test, must be a valid URL character ^[a-z0-9_-]*$. </param>
        /// <param name="fileId"> Unique identifier for test file, must be a valid URL character ^[a-z0-9_-]*$. </param>
        /// <param name="file"> FileStream to upload to loadtest. </param>
        /// <param name="fileType"> Integer representation of the file type (0 = JMX_FILE, 1 = USER_PROPERTIES, 2 = ADDITIONAL_ARTIFACTS). </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="testId"/>, <paramref name="fileId"/> </exception>
        /// <exception cref="ArgumentException"> <paramref name="testId"/> or <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call UploadTestFile with required parameters and request content, and how to parse the result.
        /// <code><![CDATA[
        /// var credential = new DefaultAzureCredential();
        /// var client = new LoadTestAdministrationClient("<https://my-service.azure.com>", credential);
        /// var data = File.OpenRead("<filePath>");
        /// Response response = client.UploadTestFile("<testId>", "<fileId>", data);
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.ToString());
        /// ]]></code>
        /// This sample shows how to call UploadTestFile with all parameters and request content, and how to parse the result.
        /// <code><![CDATA[
        /// var credential = new DefaultAzureCredential();
        /// var client = new LoadTestAdministrationClient("<https://my-service.azure.com>", credential);
        /// var data = File.OpenRead("<filePath>");
        /// Response response = client.UploadTestFile("<testId>", "<fileId>", data, 1234);
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("url").ToString());
        /// Console.WriteLine(result.GetProperty("fileId").ToString());
        /// Console.WriteLine(result.GetProperty("filename").ToString());
        /// Console.WriteLine(result.GetProperty("fileType").ToString());
        /// Console.WriteLine(result.GetProperty("expireTime").ToString());
        /// Console.WriteLine(result.GetProperty("validationStatus").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// Response Body:
        /// Schema for <c>FileUrl</c>:
        /// <code>{
        ///   url: string, # Optional. File URL.
        ///   fileId: string, # Optional. File unique identifier.
        ///   filename: string, # Optional. Name of the file.
        ///   fileType: &quot;0&quot; | &quot;1&quot; | &quot;2&quot;, # Optional. Integer representation of the file type (0 = JMX_FILE, 1 = USER_PROPERTIES, 2 = ADDITIONAL_ARTIFACTS)
        ///   expireTime: string (ISO 8601 Format), # Optional. Expiry time of the file
        ///   validationStatus: string, # Optional. Validation status of the file
        /// }
        /// </code>
        /// </remarks>
        public virtual async Task<Response> UploadTestFileAsync(string testId, string fileId, FileStream file, int? fileType = null, RequestContext context = null)
        {
            string fileName = Path.GetFileName(file.Name);
            Console.WriteLine(fileName);

            Response response = await UploadTestFileAsync(testId, fileId, fileName, RequestContent.Create(file), fileType, context).ConfigureAwait(false);
            return response;
        }
    }
}
