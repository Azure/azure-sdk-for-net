// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core.Pipeline;
using Azure.Core;
using Azure.Compute.Batch.Custom;
using System.Threading.Tasks;
using static Azure.Core.HttpPipelineExtensions;
using System.Threading;

namespace Azure.Compute.Batch
{
    public partial class BatchClient
    {
        private readonly AzureNamedKeyCredential _namedKeyCredential;

        /// <summary> Initializes a new instance of BatchClient. </summary>
        /// <param name="endpoint"> Batch account endpoint (for example: https://batchaccount.eastus2.batch.azure.com). </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public BatchClient(Uri endpoint, AzureNamedKeyCredential credential) : this(endpoint, credential, new BatchClientOptions())
        {
        }

        /// <summary> Initializes a new instance of BatchClient. </summary>
        /// <param name="endpoint"> Batch account endpoint (for example: https://batchaccount.eastus2.batch.azure.com). </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public BatchClient(Uri endpoint, AzureNamedKeyCredential credential, BatchClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new BatchClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _namedKeyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BatchNamedKeyCredentialPolicy(credential) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Gets basic properties of a Pool.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="poolId"> The ID of the Pool to get. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpdate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="poolId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="poolId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="../Generated/Docs/BatchClient.xml" path="doc/members/member[@name='PoolExistsAsync(string,int?,DateTimeOffset?,RequestConditions,RequestContext)']/*" />
        public virtual async Task<Response<bool>> PoolExistsAsync(string poolId, int? timeOutInSeconds = null, DateTimeOffset? ocpdate = null, RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(poolId, nameof(poolId));

            using var scope = ClientDiagnostics.CreateScope("BatchClient.PoolExists");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePoolExistsRequest(poolId, timeOutInSeconds, ocpdate, requestConditions, context);
                return await _pipeline.ProcessHeadAsBoolMessageAsync(message, ClientDiagnostics, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Gets basic properties of a Pool.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="poolId"> The ID of the Pool to get. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpdate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="poolId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="poolId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="../Generated/Docs/BatchClient.xml" path="doc/members/member[@name='PoolExists(string,int?,DateTimeOffset?,RequestConditions,RequestContext)']/*" />
        public virtual Response<bool> PoolExists(string poolId, int? timeOutInSeconds = null, DateTimeOffset? ocpdate = null, RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(poolId, nameof(poolId));

            using var scope = ClientDiagnostics.CreateScope("BatchClient.PoolExists");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePoolExistsRequest(poolId, timeOutInSeconds, ocpdate, requestConditions, context);
                return _pipeline.ProcessHeadAsBoolMessage(message, ClientDiagnostics, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Checks the specified Job Schedule exists.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobScheduleId"> The ID of the Job Schedule which you want to check. </param>
        /// <param name="timeOut">
        /// The maximum number of items to return in the response. A maximum of 1000
        /// applications can be returned.
        /// </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobScheduleId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobScheduleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="../Generated/Docs/BatchClient.xml" path="doc/members/member[@name='JobScheduleExistsAsync(string,int?,DateTimeOffset?,RequestConditions,RequestContext)']/*" />
        public virtual async Task<Response<bool>> JobScheduleExistsAsync(string jobScheduleId, int? timeOut = null, DateTimeOffset? ocpDate = null, RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(jobScheduleId, nameof(jobScheduleId));

            using var scope = ClientDiagnostics.CreateScope("BatchClient.JobScheduleExists");
            scope.Start();
            try
            {
                using HttpMessage message = CreateJobScheduleExistsRequest(jobScheduleId, timeOut, ocpDate, requestConditions, context);
                return await _pipeline.ProcessHeadAsBoolMessageAsync(message, ClientDiagnostics, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Checks the specified Job Schedule exists.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobScheduleId"> The ID of the Job Schedule which you want to check. </param>
        /// <param name="timeOut">
        /// The maximum number of items to return in the response. A maximum of 1000
        /// applications can be returned.
        /// </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobScheduleId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobScheduleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="../Generated/Docs/BatchClient.xml" path="doc/members/member[@name='JobScheduleExists(string,int?,DateTimeOffset?,RequestConditions,RequestContext)']/*" />
        public virtual Response<bool> JobScheduleExists(string jobScheduleId, int? timeOut = null, DateTimeOffset? ocpDate = null, RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(jobScheduleId, nameof(jobScheduleId));

            using var scope = ClientDiagnostics.CreateScope("BatchClient.JobScheduleExists");
            scope.Start();
            try
            {
                using HttpMessage message = CreateJobScheduleExistsRequest(jobScheduleId, timeOut, ocpDate, requestConditions, context);
                return _pipeline.ProcessHeadAsBoolMessage(message, ClientDiagnostics, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Gets the properties of the specified Task file.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> The ID of the Job that contains the Task. </param>
        /// <param name="taskId"> The ID of the Task whose file you want to retrieve. </param>
        /// <param name="filePath"> The path to the Task file that you want to get the content of. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpdate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/>, <paramref name="taskId"/> or <paramref name="filePath"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/>, <paramref name="taskId"/> or <paramref name="filePath"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="../Generated/Docs/BatchClient.xml" path="doc/members/member[@name='GetTaskFilePropertiesAsync(string,string,string,int?,DateTimeOffset?,RequestConditions,RequestContext)']/*" />
        public virtual async Task<Response<BatchFileProperties>> GetTaskFilePropertiesAsync(string jobId, string taskId, string filePath, int? timeOutInSeconds = null, DateTimeOffset? ocpdate = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.GetTaskFileProperties");
            scope.Start();
            try
            {
                Response response = await GetTaskFilePropertiesInternalAsync(jobId, taskId, filePath, timeOutInSeconds, ocpdate, null, null).ConfigureAwait(false);
                return Response.FromValue(BatchFileProperties.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Gets the properties of the specified Task file.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> The ID of the Job that contains the Task. </param>
        /// <param name="taskId"> The ID of the Task whose file you want to retrieve. </param>
        /// <param name="filePath"> The path to the Task file that you want to get the content of. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpdate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/>, <paramref name="taskId"/> or <paramref name="filePath"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/>, <paramref name="taskId"/> or <paramref name="filePath"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="../Generated/Docs/BatchClient.xml" path="doc/members/member[@name='GetTaskFilePropertiesInternal(string,string,string,int?,DateTimeOffset?,RequestConditions,RequestContext)']/*" />
        public virtual Response<BatchFileProperties> GetTaskFileProperties(string jobId, string taskId, string filePath, int? timeOutInSeconds = null, DateTimeOffset? ocpdate = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.GetTaskFileProperties");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = GetTaskFilePropertiesInternal(jobId, taskId, filePath, timeOutInSeconds, ocpdate, null, context);
                return Response.FromValue(BatchFileProperties.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Gets the properties of the specified Compute Node file.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="poolId"> The ID of the Pool that contains the Compute Node. </param>
        /// <param name="nodeId"> The ID of the Compute Node. </param>
        /// <param name="filePath"> The path to the file or directory. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpdate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="poolId"/>, <paramref name="nodeId"/> or <paramref name="filePath"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="poolId"/>, <paramref name="nodeId"/> or <paramref name="filePath"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response<BatchFileProperties>> GetNodeFilePropertiesAsync(string poolId, string nodeId, string filePath, int? timeOutInSeconds = null, DateTimeOffset? ocpdate = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.GetNodeFileProperties");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await GetNodeFilePropertiesInternalAsync(poolId, nodeId, filePath, timeOutInSeconds, ocpdate, null, context).ConfigureAwait(false);
                return Response.FromValue(BatchFileProperties.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Gets the properties of the specified Compute Node file.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="poolId"> The ID of the Pool that contains the Compute Node. </param>
        /// <param name="nodeId"> The ID of the Compute Node. </param>
        /// <param name="filePath"> The path to the file or directory. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpdate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="poolId"/>, <paramref name="nodeId"/> or <paramref name="filePath"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="poolId"/>, <paramref name="nodeId"/> or <paramref name="filePath"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response<BatchFileProperties> GetNodeFileProperties(string poolId, string nodeId, string filePath, int? timeOutInSeconds = null, DateTimeOffset? ocpdate = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.GetTaskFileProperties");
            scope.Start();
            try
            {
                Response response = GetNodeFilePropertiesInternal(poolId, nodeId, filePath, timeOutInSeconds, ocpdate, null, null);
                return Response.FromValue(BatchFileProperties.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
