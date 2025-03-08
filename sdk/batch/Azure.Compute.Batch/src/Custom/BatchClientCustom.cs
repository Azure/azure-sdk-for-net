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
using System.Diagnostics;

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
            using var scope = ClientDiagnostics.CreateScope("BatchClient.GetNodeFileProperties");
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

        /// <summary>
        /// [Protocol Method] Updates the properties of the specified Pool.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="poolId"> The ID of the Pool to get. </param>
        /// <param name="pool"> The pool properties to update. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpdate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="poolId"/> or <paramref name="pool"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="poolId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="../Generated/Docs/BatchClient.xml" path="doc/members/member[@name='UpdatePoolAsync(string,RequestContent,int?,DateTimeOffset?,RequestConditions,RequestContext)']/*" />
        public virtual async Task<Response> UpdatePoolAsync(string poolId, BatchPoolUpdateContent pool, int? timeOutInSeconds = null, DateTimeOffset? ocpdate = null, RequestConditions requestConditions = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(poolId, nameof(poolId));
            Argument.AssertNotNull(pool, nameof(pool));

            using RequestContent content = pool.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await UpdatePoolAsync(poolId, content, timeOutInSeconds, ocpdate, requestConditions, context).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// [Protocol Method] Updates the properties of the specified Pool.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="poolId"> The ID of the Pool to get. </param>
        /// <param name="pool"> The pool properties to update. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpdate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="poolId"/> or <paramref name="pool"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="poolId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="../Generated/Docs/BatchClient.xml" path="doc/members/member[@name='UpdatePool(string,RequestContent,int?,DateTimeOffset?,RequestConditions,RequestContext)']/*" />
        public virtual Response UpdatePool(string poolId, BatchPoolUpdateContent pool, int? timeOutInSeconds = null, DateTimeOffset? ocpdate = null, RequestConditions requestConditions = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(poolId, nameof(poolId));
            Argument.AssertNotNull(pool, nameof(pool));

            using RequestContent content = pool.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = UpdatePool(poolId, content, timeOutInSeconds, ocpdate, requestConditions, context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] Updates the properties of the specified Job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> The ID of the Job whose properties you want to update. </param>
        /// <param name="job"> The options to use for updating the Job.. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpdate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="job"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="../Generated/Docs/BatchClient.xml" path="doc/members/member[@name='UpdateJobAsync(string,RequestContent,int?,DateTimeOffset?,RequestConditions,RequestContext)']/*" />
        public virtual async Task<Response> UpdateJobAsync(string jobId, BatchJobUpdateContent job, int? timeOutInSeconds = null, DateTimeOffset? ocpdate = null, RequestConditions requestConditions = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));
            Argument.AssertNotNull(job, nameof(job));

            using RequestContent content = job.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await UpdateJobAsync(jobId, content, timeOutInSeconds, ocpdate, requestConditions, context).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// [Protocol Method] Updates the properties of the specified Job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> The ID of the Job whose properties you want to update. </param>
        /// <param name="job"> The options to use for updating the Job. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpdate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="job"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="../Generated/Docs/BatchClient.xml" path="doc/members/member[@name='UpdateJob(string,RequestContent,int?,DateTimeOffset?,RequestConditions,RequestContext)']/*" />
        public virtual Response UpdateJob(string jobId, BatchJobUpdateContent job, int? timeOutInSeconds = null, DateTimeOffset? ocpdate = null, RequestConditions requestConditions = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));
            Argument.AssertNotNull(job, nameof(job));

            using RequestContent content = job.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = UpdateJob(jobId, content, timeOutInSeconds, ocpdate, requestConditions, context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] Updates the properties of the specified Job Schedule.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobScheduleId"> The ID of the Job Schedule to update. </param>
        /// <param name="jobSchedule"> The options to use for updating the Job Schedule. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpdate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobScheduleId"/> or <paramref name="jobSchedule"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobScheduleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="../Generated/Docs/BatchClient.xml" path="doc/members/member[@name='UpdateJobScheduleAsync(string,RequestContent,int?,DateTimeOffset?,RequestConditions,RequestContext)']/*" />
        public virtual async Task<Response> UpdateJobScheduleAsync(string jobScheduleId, BatchJobScheduleUpdateContent jobSchedule, int? timeOutInSeconds = null, DateTimeOffset? ocpdate = null, RequestConditions requestConditions = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(jobScheduleId, nameof(jobScheduleId));
            Argument.AssertNotNull(jobSchedule, nameof(jobSchedule));

            using RequestContent content = jobSchedule.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await UpdateJobScheduleAsync(jobScheduleId, content, timeOutInSeconds, ocpdate, requestConditions, context).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// [Protocol Method] Updates the properties of the specified Job Schedule.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobScheduleId"> The ID of the Job Schedule to update. </param>
        /// <param name="jobSchedule"> The options to use for updating the Job Schedule. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpdate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobScheduleId"/> or <paramref name="jobSchedule"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobScheduleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="../Generated/Docs/BatchClient.xml" path="doc/members/member[@name='UpdateJobSchedule(string,RequestContent,int?,DateTimeOffset?,RequestConditions,RequestContext)']/*" />
        public virtual Response UpdateJobSchedule(string jobScheduleId, BatchJobScheduleUpdateContent jobSchedule, int? timeOutInSeconds = null, DateTimeOffset? ocpdate = null, RequestConditions requestConditions = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(jobScheduleId, nameof(jobScheduleId));
            Argument.AssertNotNull(jobSchedule, nameof(jobSchedule));

            using RequestContent content = jobSchedule.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = UpdateJobSchedule(jobScheduleId, content, timeOutInSeconds, ocpdate, requestConditions, context);
            return response;
        }

        /// <summary> Utility method that can take in a large number of tasks to Creates to the specified Job. </summary>
        /// <param name="jobId"> The ID of the Job to which the Task is to be created. </param>
        /// <param name="tasksToAdd"> A collection of Tasks to be created. </param>
        /// <param name="createTasksOptions">The parallel options associated with this operation.  If this is null, the default is used.</param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="tasksToAdd"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks>
        /// The maximum lifetime of a Task from addition to completion is 180 days. If a
        /// Task has not completed within 180 days of being added it will be terminated by
        /// the Batch service and left in whatever state it was in at that time.
        /// </remarks>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<CreateTasksResult> CreateTasksAsync(string jobId, IEnumerable<BatchTaskCreateContent> tasksToAdd, CreateTasksOptions createTasksOptions = null,TimeSpan ? timeOutInSeconds = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));
            Argument.AssertNotNull(tasksToAdd, nameof(tasksToAdd));
            CreateTasksResult response = null;
            using var scope = ClientDiagnostics.CreateScope("BatchClient.CreateTasks");
            scope.Start();
            try
            {
                TasksWorkflowManager addTasksWorkflowManager = new TasksWorkflowManager(this, jobId, createTasksOptions, cancellationToken: cancellationToken);
                response = await addTasksWorkflowManager.AddTasksAsync(tasksToAdd,jobId, timeOutInSeconds).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
            return response;
        }

        /// <summary> Utility method that can take in a large number of tasks to Creates to the specified Job. </summary>
        /// <param name="jobId"> The ID of the Job to which the Task is to be created. </param>
        /// <param name="tasksToAdd"> A collection of Tasks to be created </param>
        /// <param name="createTasksOptions">The parallel options associated with this operation.  If this is null, the default is used.</param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="tasksToAdd"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks>
        /// The maximum lifetime of a Task from addition to completion is 180 days. If a
        /// Task has not completed within 180 days of being added it will be terminated by
        /// the Batch service and left in whatever state it was in at that time.
        /// </remarks>
        public virtual CreateTasksResult CreateTasks(string jobId, IEnumerable<BatchTaskCreateContent> tasksToAdd, CreateTasksOptions createTasksOptions = null, TimeSpan? timeOutInSeconds = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));
            Argument.AssertNotNull(tasksToAdd, nameof(tasksToAdd));

            CreateTasksResult response = null;

            using var scope = ClientDiagnostics.CreateScope("BatchClient.CreateTasks");
            scope.Start();
            try
            {
                TasksWorkflowManager addTasksWorkflowManager = new TasksWorkflowManager(this, jobId, createTasksOptions, cancellationToken: cancellationToken);
                response = addTasksWorkflowManager.AddTasks(tasksToAdd, jobId, timeOutInSeconds);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
            finally
            {
                scope.Dispose();
            }

            return response;
        }
        #pragma warning restore AZC0015
    }
}
