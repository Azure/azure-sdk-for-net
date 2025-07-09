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
            var pipelineOptions = new HttpPipelineOptions(options)
            {
                PerRetryPolicies = { new BatchNamedKeyCredentialPolicy(credential) },
                ResponseClassifier = new ResponseClassifier(),
                RequestFailedDetailsParser = new BatchErrorDetailsParser()
            };
            _pipeline = HttpPipelineBuilder.Build(pipelineOptions);

            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary> Initializes a new instance of BatchClient. </summary>
        /// <param name="endpoint"> Batch account endpoint (for example: https://batchaccount.eastus2.batch.azure.com). </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public BatchClient(Uri endpoint, TokenCredential credential, BatchClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new BatchClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;

            var pipelineOptions = new HttpPipelineOptions(options)
            {
                PerRetryPolicies = { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) },
                ResponseClassifier = new ResponseClassifier(),
                RequestFailedDetailsParser = new BatchErrorDetailsParser()
            };
            _pipeline = HttpPipelineBuilder.Build(pipelineOptions);

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
        public virtual async Task<Response<bool>> PoolExistsAsync(string poolId, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpdate = null, RequestConditions requestConditions = null, RequestContext context = null)
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
        public virtual Response<bool> PoolExists(string poolId, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpdate = null, RequestConditions requestConditions = null, RequestContext context = null)
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
        public virtual async Task<Response<bool>> JobScheduleExistsAsync(string jobScheduleId, TimeSpan? timeOut = null, DateTimeOffset? ocpDate = null, RequestConditions requestConditions = null, RequestContext context = null)
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
        public virtual Response<bool> JobScheduleExists(string jobScheduleId, TimeSpan? timeOut = null, DateTimeOffset? ocpDate = null, RequestConditions requestConditions = null, RequestContext context = null)
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
        public virtual async Task<Response<BatchFileProperties>> GetTaskFilePropertiesAsync(string jobId, string taskId, string filePath, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpdate = null, CancellationToken cancellationToken = default)
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
        public virtual Response<BatchFileProperties> GetTaskFileProperties(string jobId, string taskId, string filePath, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpdate = null, CancellationToken cancellationToken = default)
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
        public virtual async Task<Response<BatchFileProperties>> GetNodeFilePropertiesAsync(string poolId, string nodeId, string filePath, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpdate = null, CancellationToken cancellationToken = default)
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
        public virtual Response<BatchFileProperties> GetNodeFileProperties(string poolId, string nodeId, string filePath, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpdate = null, CancellationToken cancellationToken = default)
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
        public virtual async Task<Response> UpdatePoolAsync(string poolId, BatchPoolUpdateOptions pool, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpdate = null, RequestConditions requestConditions = null, CancellationToken cancellationToken = default)
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
        public virtual Response UpdatePool(string poolId, BatchPoolUpdateOptions pool, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpdate = null, RequestConditions requestConditions = null, CancellationToken cancellationToken = default)
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
        public virtual async Task<Response> UpdateJobAsync(string jobId, BatchJobUpdateOptions job, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpdate = null, RequestConditions requestConditions = null, CancellationToken cancellationToken = default)
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
        public virtual Response UpdateJob(string jobId, BatchJobUpdateOptions job, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpdate = null, RequestConditions requestConditions = null, CancellationToken cancellationToken = default)
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
        public virtual async Task<Response> UpdateJobScheduleAsync(string jobScheduleId, BatchJobScheduleUpdateOptions jobSchedule, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpdate = null, RequestConditions requestConditions = null, CancellationToken cancellationToken = default)
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
        public virtual Response UpdateJobSchedule(string jobScheduleId, BatchJobScheduleUpdateOptions jobSchedule, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpdate = null, RequestConditions requestConditions = null, CancellationToken cancellationToken = default)
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
        public virtual async Task<CreateTasksResult> CreateTasksAsync(string jobId, IEnumerable<BatchTaskCreateOptions> tasksToAdd, CreateTasksOptions createTasksOptions = null,TimeSpan ? timeOutInSeconds = null, CancellationToken cancellationToken = default)
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
        public virtual CreateTasksResult CreateTasks(string jobId, IEnumerable<BatchTaskCreateOptions> tasksToAdd, CreateTasksOptions createTasksOptions = null, TimeSpan? timeOutInSeconds = null, CancellationToken cancellationToken = default)
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

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Deletes a Job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> The ID of the Job to delete. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="force"> If true, the server will delete the Job even if the corresponding nodes have not fully processed the deletion. The default value is false. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The DeleteJobOperation object to allow for polling of operation status. </returns>
        /// <include file="../Generated/Docs/BatchClient.xml" path="doc/members/member[@name='DeleteJobAsync(string,TimeSpan?,DateTimeOffset?,bool?,RequestConditions,RequestContext)']/*" />
        public virtual async Task<DeleteJobOperation> DeleteJobAsync(string jobId, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, bool? force = null, RequestConditions requestConditions = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.DeleteJob");
            scope.Start();
            try
            {   Response response = await DeleteJobInternalAsync(jobId, timeOutInSeconds, ocpDate, force, requestConditions, context).ConfigureAwait(false);
                return new DeleteJobOperation(this, jobId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Deletes a Job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> The ID of the Job to delete. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="force"> If true, the server will delete the Job even if the corresponding nodes have not fully processed the deletion. The default value is false. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The DeleteJobOperation object to allow for polling of operation status. </returns>
        /// <include file="../Generated/Docs/BatchClient.xml" path="doc/members/member[@name='DeleteJob(string,TimeSpan?,DateTimeOffset?,bool?,RequestConditions,RequestContext)']/*" />
        public virtual DeleteJobOperation DeleteJob(string jobId, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, bool? force = null, RequestConditions requestConditions = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.DeleteJob");
            scope.Start();
            try
            {
                Response response = DeleteJobInternal(jobId, timeOutInSeconds, ocpDate, force, requestConditions, context);
                return new DeleteJobOperation(this, jobId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Deletes a Certificate from the specified Account.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="thumbprintAlgorithm"> The algorithm used to derive the thumbprint parameter. This must be sha1. </param>
        /// <param name="thumbprint"> The thumbprint of the Certificate to be deleted. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="thumbprintAlgorithm"/> or <paramref name="thumbprint"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="thumbprintAlgorithm"/> or <paramref name="thumbprint"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The DeleteCertificateOperation object to allow for polling of operation status. </returns>
        public virtual async Task<DeleteCertificateOperation> DeleteCertificateAsync(string thumbprintAlgorithm, string thumbprint, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.DeleteCertificate");
            scope.Start();
            try
            {
                Response response = await DeleteCertificateInternalAsync(thumbprintAlgorithm, thumbprint, timeOutInSeconds, ocpDate, context).ConfigureAwait(false);
                return new DeleteCertificateOperation(this, thumbprintAlgorithm, thumbprint, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Deletes a Certificate from the specified Account.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="thumbprintAlgorithm"> The algorithm used to derive the thumbprint parameter. This must be sha1. </param>
        /// <param name="thumbprint"> The thumbprint of the Certificate to be deleted. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="thumbprintAlgorithm"/> or <paramref name="thumbprint"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="thumbprintAlgorithm"/> or <paramref name="thumbprint"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The DeleteCertificateOperation object to allow for polling of operation status. </returns>
        public virtual DeleteCertificateOperation DeleteCertificate(string thumbprintAlgorithm, string thumbprint, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.DeleteCertificate");
            scope.Start();
            try
            {
                Response response = DeleteCertificateInternal(thumbprintAlgorithm, thumbprint, timeOutInSeconds, ocpDate, context);
                return new DeleteCertificateOperation(this, thumbprintAlgorithm, thumbprint, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Deletes a Job Schedule from the specified Account.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobScheduleId"> The ID of the Job Schedule to delete. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="force"> If true, the server will delete the JobSchedule even if the corresponding nodes have not fully processed the deletion. The default value is false. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobScheduleId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobScheduleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The DeleteJobScheduleOperation object to allow for polling of operation status. </returns>
        public virtual async Task<DeleteJobScheduleOperation> DeleteJobScheduleAsync(string jobScheduleId, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, bool? force = null, RequestConditions requestConditions = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.DeleteJobSchedule");
            scope.Start();
            try
            {   Response response = await DeleteJobScheduleInternalAsync(jobScheduleId, timeOutInSeconds, ocpDate, force, requestConditions, context).ConfigureAwait(false);
                return new DeleteJobScheduleOperation(this, jobScheduleId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Deletes a Job Schedule from the specified Account.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobScheduleId"> The ID of the Job Schedule to delete. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="force"> If true, the server will delete the JobSchedule even if the corresponding nodes have not fully processed the deletion. The default value is false. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobScheduleId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobScheduleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The DeleteJobScheduleOperation object to allow for polling of operation status. </returns>
        public virtual DeleteJobScheduleOperation DeleteJobSchedule(string jobScheduleId, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, bool? force = null, RequestConditions requestConditions = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.DeleteJobSchedule");
            scope.Start();
            try
            {   Response response = DeleteJobScheduleInternal(jobScheduleId, timeOutInSeconds, ocpDate, force, requestConditions, context);
                return new DeleteJobScheduleOperation(this, jobScheduleId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Deletes a Pool from the specified Account.
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
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="poolId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="poolId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The DeletePoolOperation object to allow for polling of operation status. </returns>
        public virtual async Task<DeletePoolOperation> DeletePoolAsync(string poolId, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, RequestConditions requestConditions = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.DeletePool");
            scope.Start();
            try
            {   Response response = await DeletePoolInternalAsync(poolId, timeOutInSeconds, ocpDate, requestConditions, context).ConfigureAwait(false);
                return new DeletePoolOperation(this, poolId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Deletes a Pool from the specified Account.
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
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="poolId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="poolId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The DeletePoolOperation object to allow for polling of operation status. </returns>
        public virtual DeletePoolOperation DeletePool(string poolId, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, RequestConditions requestConditions = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.DeletePool");
            scope.Start();
            try
            {   Response response = DeletePoolInternal(poolId, timeOutInSeconds, ocpDate, requestConditions, context);
                return new DeletePoolOperation(this, poolId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Terminates the specified Job, marking it as completed. </summary>
        /// <param name="jobId"> The ID of the Job to terminate. </param>
        /// <param name="parameters"> The options to use for terminating the Job. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="force"> If true, the server will terminate the Job even if the corresponding nodes have not fully processed the termination. The default value is false. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks>
        /// When a Terminate Job request is received, the Batch service sets the Job to the
        /// terminating state. The Batch service then terminates any running Tasks
        /// associated with the Job and runs any required Job release Tasks. Then the Job
        /// moves into the completed state. If there are any Tasks in the Job in the active
        /// state, they will remain in the active state. Once a Job is terminated, new
        /// Tasks cannot be added and any remaining active Tasks will not be scheduled.
        /// </remarks>
        /// <returns> The TerminateJobOperation object to allow for polling of operation status. </returns>
        public virtual async Task<TerminateJobOperation> TerminateJobAsync(string jobId, BatchJobTerminateOptions parameters = null, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, bool? force = null, RequestConditions requestConditions = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.TerminateJob");
            scope.Start();
            try
            {   Response response = await TerminateJobInternalAsync(jobId, parameters, timeOutInSeconds, ocpDate, force, requestConditions, cancellationToken).ConfigureAwait(false);
                return new TerminateJobOperation(this, jobId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Terminates the specified Job, marking it as completed. </summary>
        /// <param name="jobId"> The ID of the Job to terminate. </param>
        /// <param name="parameters"> The options to use for terminating the Job. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="force"> If true, the server will terminate the Job even if the corresponding nodes have not fully processed the termination. The default value is false. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks>
        /// When a Terminate Job request is received, the Batch service sets the Job to the
        /// terminating state. The Batch service then terminates any running Tasks
        /// associated with the Job and runs any required Job release Tasks. Then the Job
        /// moves into the completed state. If there are any Tasks in the Job in the active
        /// state, they will remain in the active state. Once a Job is terminated, new
        /// Tasks cannot be added and any remaining active Tasks will not be scheduled.
        /// </remarks>
        /// <returns> The TerminateJobOperation object to allow for polling of operation status. </returns>
        public virtual TerminateJobOperation TerminateJob(string jobId, BatchJobTerminateOptions parameters = null, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, bool? force = null, RequestConditions requestConditions = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.TerminateJob");
            scope.Start();
            try
            {   Response response = TerminateJobInternal(jobId, parameters, timeOutInSeconds, ocpDate, force, requestConditions, cancellationToken);
                return new TerminateJobOperation(this, jobId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Terminates a Job Schedule.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobScheduleId"> The ID of the Job Schedule to terminates. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="force"> If true, the server will terminate the JobSchedule even if the corresponding nodes have not fully processed the termination. The default value is false. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobScheduleId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobScheduleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The TerminateJobScheduleOperation object to allow for polling of operation status. </returns>
        public virtual async Task<TerminateJobScheduleOperation> TerminateJobScheduleAsync(string jobScheduleId, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, bool? force = null, RequestConditions requestConditions = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.TerminateJobSchedule");
            scope.Start();
            try
            {   Response response = await TerminateJobScheduleInternalAsync(jobScheduleId, timeOutInSeconds, ocpDate, force, requestConditions, context).ConfigureAwait(false);
                return new TerminateJobScheduleOperation(this, jobScheduleId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Terminates a Job Schedule.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobScheduleId"> The ID of the Job Schedule to terminates. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="force"> If true, the server will terminate the JobSchedule even if the corresponding nodes have not fully processed the termination. The default value is false. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobScheduleId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobScheduleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The TerminateJobScheduleOperation object to allow for polling of operation status. </returns>
        public virtual TerminateJobScheduleOperation TerminateJobSchedule(string jobScheduleId, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, bool? force = null, RequestConditions requestConditions = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.TerminateJobSchedule");
            scope.Start();
            try
            {   Response response = TerminateJobScheduleInternal(jobScheduleId, timeOutInSeconds, ocpDate, force, requestConditions, context);
                return new TerminateJobScheduleOperation(this, jobScheduleId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Disables the specified Job, preventing new Tasks from running. </summary>
        /// <param name="jobId"> The ID of the Job to disable. </param>
        /// <param name="disableOptions"> The options to use for disabling the Job. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="disableOptions"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks>
        /// The Batch Service immediately moves the Job to the disabling state. Batch then
        /// uses the disableTasks parameter to determine what to do with the currently
        /// running Tasks of the Job. The Job remains in the disabling state until the
        /// disable operation is completed and all Tasks have been dealt with according to
        /// the disableTasks option; the Job then moves to the disabled state. No new Tasks
        /// are started under the Job until it moves back to active state. If you try to
        /// disable a Job that is in any state other than active, disabling, or disabled,
        /// the request fails with status code 409.
        /// </remarks>
        /// <returns> The DisableJobOperation object to allow for polling of operation status. </returns>
        public virtual async Task<DisableJobOperation> DisableJobAsync(string jobId, BatchJobDisableOptions disableOptions, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, RequestConditions requestConditions = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.DisableJob");
            scope.Start();
            try
            {   Response response = await DisableJobInternalAsync(jobId, disableOptions, timeOutInSeconds, ocpDate, requestConditions, cancellationToken).ConfigureAwait(false);
                return new DisableJobOperation(this, jobId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Disables the specified Job, preventing new Tasks from running. </summary>
        /// <param name="jobId"> The ID of the Job to disable. </param>
        /// <param name="disableOptions"> The options to use for disabling the Job. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="disableOptions"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks>
        /// The Batch Service immediately moves the Job to the disabling state. Batch then
        /// uses the disableTasks parameter to determine what to do with the currently
        /// running Tasks of the Job. The Job remains in the disabling state until the
        /// disable operation is completed and all Tasks have been dealt with according to
        /// the disableTasks option; the Job then moves to the disabled state. No new Tasks
        /// are started under the Job until it moves back to active state. If you try to
        /// disable a Job that is in any state other than active, disabling, or disabled,
        /// the request fails with status code 409.
        /// </remarks>
        /// <returns> The DisableJobOperation object to allow for polling of operation status. </returns>
        public virtual DisableJobOperation DisableJob(string jobId, BatchJobDisableOptions disableOptions, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, RequestConditions requestConditions = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.DisableJob");
            scope.Start();
            try
            {   Response response = DisableJobInternal(jobId, disableOptions, timeOutInSeconds, ocpDate, requestConditions, cancellationToken);
                return new DisableJobOperation(this, jobId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Enables the specified Job, allowing new Tasks to run.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> The ID of the Job to enable. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The EnableJobOperation object to allow for polling of operation status. </returns>
        public virtual async Task<EnableJobOperation> EnableJobAsync(string jobId, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, RequestConditions requestConditions = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.EnableJob");
            scope.Start();
            try
            {
                Response response = await EnableJobInternalAsync(jobId, timeOutInSeconds, ocpDate, requestConditions).ConfigureAwait(false);
                return new EnableJobOperation(this, jobId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Enables the specified Job, allowing new Tasks to run.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> The ID of the Job to enable. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The EnableJobOperation object to allow for polling of operation status. </returns>
        public virtual EnableJobOperation EnableJob(string jobId, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, RequestConditions requestConditions = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.EnableJob");
            scope.Start();
            try
            {   Response response = EnableJobInternal(jobId, timeOutInSeconds, ocpDate, requestConditions);
                                return new EnableJobOperation(this, jobId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deallocates the specified Compute Node. </summary>
        /// <param name="poolId"> The ID of the Pool that contains the Compute Node. </param>
        /// <param name="nodeId"> The ID of the Compute Node that you want to restart. </param>
        /// <param name="parameters"> The options to use for deallocating the Compute Node. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="poolId"/> or <paramref name="nodeId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="poolId"/> or <paramref name="nodeId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks> You can deallocate a Compute Node only if it is in an idle or running state. </remarks>
        /// <returns> The DeallocateNodeOperation object to allow for polling of operation status. </returns>
        public virtual async Task<DeallocateNodeOperation> DeallocateNodeAsync(string poolId, string nodeId, BatchNodeDeallocateOptions parameters = null, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.DeallocateNode");
            scope.Start();
            try
            {
                Response response = await DeallocateNodeInternalAsync(poolId, nodeId, parameters, timeOutInSeconds, ocpDate, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new DeallocateNodeOperation(this, poolId: poolId, nodeId: nodeId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deallocates the specified Compute Node. </summary>
        /// <param name="poolId"> The ID of the Pool that contains the Compute Node. </param>
        /// <param name="nodeId"> The ID of the Compute Node that you want to restart. </param>
        /// <param name="parameters"> The options to use for deallocating the Compute Node. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="poolId"/> or <paramref name="nodeId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="poolId"/> or <paramref name="nodeId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks> You can deallocate a Compute Node only if it is in an idle or running state. </remarks>
        /// <returns> The DeallocateNodeOperation object to allow for polling of operation status. </returns>
        public virtual DeallocateNodeOperation DeallocateNode(string poolId, string nodeId, BatchNodeDeallocateOptions parameters = null, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.DeallocateNode");
            scope.Start();
            try
            {
                Response response = DeallocateNodeInternal(poolId, nodeId, parameters, timeOutInSeconds, ocpDate, cancellationToken: cancellationToken);
                return new DeallocateNodeOperation(this, poolId: poolId, nodeId: nodeId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Starts the specified Compute Node.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="poolId"> The ID of the Pool that contains the Compute Node. </param>
        /// <param name="nodeId"> The ID of the Compute Node that you want to restart. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="poolId"/> or <paramref name="nodeId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="poolId"/> or <paramref name="nodeId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The StartNodeOperation object to allow for polling of operation status. </returns>
        public virtual async Task<StartNodeOperation> StartNodeAsync(string poolId, string nodeId, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.StartNode");
            scope.Start();
            try
            {
                Response response = await StartNodeInternalAsync(poolId, nodeId, timeOutInSeconds, ocpDate, context: context).ConfigureAwait(false);
                return new StartNodeOperation(this, poolId: poolId, nodeId: nodeId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Starts the specified Compute Node.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="poolId"> The ID of the Pool that contains the Compute Node. </param>
        /// <param name="nodeId"> The ID of the Compute Node that you want to restart. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="poolId"/> or <paramref name="nodeId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="poolId"/> or <paramref name="nodeId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The StartNodeOperation object to allow for polling of operation status. </returns>
        public virtual StartNodeOperation StartNode(string poolId, string nodeId, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.StartNode");
            scope.Start();
            try
            {
                Response response = StartNodeInternal(poolId, nodeId, timeOutInSeconds, ocpDate, context: context);
                return new StartNodeOperation(this, poolId: poolId, nodeId: nodeId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Restarts the specified Compute Node. </summary>
        /// <param name="poolId"> The ID of the Pool that contains the Compute Node. </param>
        /// <param name="nodeId"> The ID of the Compute Node that you want to restart. </param>
        /// <param name="parameters"> The options to use for rebooting the Compute Node. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="poolId"/> or <paramref name="nodeId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="poolId"/> or <paramref name="nodeId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks> You can restart a Compute Node only if it is in an idle or running state. </remarks>
        /// <returns> The RebootNodeOperation object to allow for polling of operation status. </returns>
        public virtual async Task<RebootNodeOperation> RebootNodeAsync(string poolId, string nodeId, BatchNodeRebootOptions parameters = null, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.RebootNode");
            scope.Start();
            try
            {
                Response response = await RebootNodeInternalAsync(poolId, nodeId, parameters, timeOutInSeconds, ocpDate, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new RebootNodeOperation(this, poolId: poolId, nodeId: nodeId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Restarts the specified Compute Node. </summary>
        /// <param name="poolId"> The ID of the Pool that contains the Compute Node. </param>
        /// <param name="nodeId"> The ID of the Compute Node that you want to restart. </param>
        /// <param name="parameters"> The options to use for rebooting the Compute Node. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="poolId"/> or <paramref name="nodeId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="poolId"/> or <paramref name="nodeId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks> You can restart a Compute Node only if it is in an idle or running state. </remarks>
        /// <returns> The RebootNodeOperation object to allow for polling of operation status. </returns>
        public virtual RebootNodeOperation RebootNode(string poolId, string nodeId, BatchNodeRebootOptions parameters = null, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.RebootNode");
            scope.Start();
            try
            {
                Response response = RebootNodeInternal(poolId, nodeId, parameters, timeOutInSeconds, ocpDate, cancellationToken: cancellationToken);
                return new RebootNodeOperation(this, poolId: poolId, nodeId: nodeId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Reinstalls the operating system on the specified Compute Node. </summary>
        /// <param name="poolId"> The ID of the Pool that contains the Compute Node. </param>
        /// <param name="nodeId"> The ID of the Compute Node that you want to restart. </param>
        /// <param name="parameters"> The options to use for reimaging the Compute Node. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="poolId"/> or <paramref name="nodeId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="poolId"/> or <paramref name="nodeId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks>
        /// You can reinstall the operating system on a Compute Node only if it is in an
        /// idle or running state. This API can be invoked only on Pools created with the
        /// cloud service configuration property.
        /// </remarks>
        /// <returns> The ReimageNodeOperation object to allow for polling of operation status. </returns>
        public virtual async Task<ReimageNodeOperation> ReimageNodeAsync(string poolId, string nodeId, BatchNodeReimageOptions parameters = null, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.ReimageNode");
            scope.Start();
            try
            {
                Response response = await ReimageNodeInternalAsync(poolId: poolId, nodeId:  nodeId, parameters, timeOutInSeconds, ocpDate, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new ReimageNodeOperation(this, poolId: poolId, nodeId: nodeId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Reinstalls the operating system on the specified Compute Node. </summary>
        /// <param name="poolId"> The ID of the Pool that contains the Compute Node. </param>
        /// <param name="nodeId"> The ID of the Compute Node that you want to restart. </param>
        /// <param name="parameters"> The options to use for reimaging the Compute Node. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="poolId"/> or <paramref name="nodeId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="poolId"/> or <paramref name="nodeId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks>
        /// You can reinstall the operating system on a Compute Node only if it is in an
        /// idle or running state. This API can be invoked only on Pools created with the
        /// cloud service configuration property.
        /// </remarks>
        /// <returns> The ReimageNodeOperation object to allow for polling of operation status. </returns>
        public virtual ReimageNodeOperation ReimageNode(string poolId, string nodeId, BatchNodeReimageOptions parameters = null, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.ReimageNode");
            scope.Start();
            try
            {
                Response response = ReimageNodeInternal(poolId, nodeId, parameters, timeOutInSeconds, ocpDate, cancellationToken: cancellationToken);
                return new ReimageNodeOperation(this, poolId: poolId, nodeId: nodeId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Changes the number of Compute Nodes that are assigned to a Pool. </summary>
        /// <param name="poolId"> The ID of the Pool to get. </param>
        /// <param name="resizeOptions"> The options to use for resizing the pool. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="poolId"/> or <paramref name="resizeOptions"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="poolId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks>
        /// You can only resize a Pool when its allocation state is steady. If the Pool is
        /// already resizing, the request fails with status code 409. When you resize a
        /// Pool, the Pool's allocation state changes from steady to resizing. You cannot
        /// resize Pools which are configured for automatic scaling. If you try to do this,
        /// the Batch service returns an error 409. If you resize a Pool downwards, the
        /// Batch service chooses which Compute Nodes to remove. To remove specific Compute
        /// Nodes, use the Pool remove Compute Nodes API instead.
        /// <returns> The ResizePoolOperation object to allow for polling of operation status. </returns>
        /// </remarks>
        public virtual async Task<ResizePoolOperation> ResizePoolAsync(string poolId, BatchPoolResizeOptions resizeOptions, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, RequestConditions requestConditions = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.ResizePool");
            scope.Start();
            try
            {
                Response response = await ResizePoolInternalAsync(poolId, resizeOptions, timeOutInSeconds, ocpDate, requestConditions, cancellationToken).ConfigureAwait(false);
                return new ResizePoolOperation(this, resizeId: poolId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Changes the number of Compute Nodes that are assigned to a Pool. </summary>
        /// <param name="poolId"> The ID of the Pool to get. </param>
        /// <param name="resizeOptions"> The options to use for resizing the pool. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="poolId"/> or <paramref name="resizeOptions"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="poolId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks>
        /// You can only resize a Pool when its allocation state is steady. If the Pool is
        /// already resizing, the request fails with status code 409. When you resize a
        /// Pool, the Pool's allocation state changes from steady to resizing. You cannot
        /// resize Pools which are configured for automatic scaling. If you try to do this,
        /// the Batch service returns an error 409. If you resize a Pool downwards, the
        /// Batch service chooses which Compute Nodes to remove. To remove specific Compute
        /// Nodes, use the Pool remove Compute Nodes API instead.
        /// <returns> The ResizePoolOperation object to allow for polling of operation status. </returns>
        /// </remarks>
        public virtual ResizePoolOperation ResizePool(string poolId, BatchPoolResizeOptions resizeOptions, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, RequestConditions requestConditions = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.ResizePool");
            scope.Start();
            try
            {
                Response response = ResizePoolInternal(poolId, resizeOptions, timeOutInSeconds, ocpDate, requestConditions, cancellationToken);
                return new ResizePoolOperation(this, resizeId: poolId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Stops an ongoing resize operation on the Pool.
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
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="poolId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="poolId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The StopPoolResizeOperation object to allow for polling of operation status. </returns>
        public virtual async Task<StopPoolResizeOperation> StopPoolResizeAsync(string poolId, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, RequestConditions requestConditions = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.StopPoolResize");
            scope.Start();
            try
            {
                Response response = await StopPoolResizeInternalAsync(poolId, timeOutInSeconds, ocpDate, requestConditions).ConfigureAwait(false);
                return new StopPoolResizeOperation(this, resizeId: poolId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Stops an ongoing resize operation on the Pool.
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
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="poolId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="poolId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The StopPoolResizeOperation object to allow for polling of operation status. </returns>
        public virtual StopPoolResizeOperation StopPoolResize(string poolId, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, RequestConditions requestConditions = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.StopPoolResize");
            scope.Start();
            try
            {
                Response response = StopPoolResizeInternal(poolId, timeOutInSeconds, ocpDate, requestConditions);
                return new StopPoolResizeOperation(this, resizeId: poolId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes Compute Nodes from the specified Pool. </summary>
        /// <param name="poolId"> The ID of the Pool to get. </param>
        /// <param name="removeOptions"> The options to use for removing the node. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="poolId"/> or <paramref name="removeOptions"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="poolId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks>
        /// This operation can only run when the allocation state of the Pool is steady.
        /// When this operation runs, the allocation state changes from steady to resizing.
        /// Each request may remove up to 100 nodes.
        /// </remarks>
        /// <returns> The RemoveNodesOperation object to allow for polling of operation status. </returns>
        public virtual async Task<RemoveNodesOperation> RemoveNodesAsync(string poolId, BatchNodeRemoveOptions removeOptions, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, RequestConditions requestConditions = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.RemoveNodes");
            scope.Start();
            try
            {
                Response response = await RemoveNodesInternalAsync(poolId, removeOptions, timeOutInSeconds, ocpDate, requestConditions).ConfigureAwait(false);
                return new RemoveNodesOperation(this, poolId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes Compute Nodes from the specified Pool. </summary>
        /// <param name="poolId"> The ID of the Pool to get. </param>
        /// <param name="removeOptions"> The options to use for removing the node. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="ocpDate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="poolId"/> or <paramref name="removeOptions"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="poolId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks>
        /// This operation can only run when the allocation state of the Pool is steady.
        /// When this operation runs, the allocation state changes from steady to resizing.
        /// Each request may remove up to 100 nodes.
        /// </remarks>
        /// <returns> The RemoveNodesOperation object to allow for polling of operation status. </returns>
        public virtual RemoveNodesOperation RemoveNodes(string poolId, BatchNodeRemoveOptions removeOptions, TimeSpan? timeOutInSeconds = null, DateTimeOffset? ocpDate = null, RequestConditions requestConditions = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("BatchClient.RemoveNodes");
            scope.Start();
            try
            {
                Response response = RemoveNodesInternal(poolId, removeOptions, timeOutInSeconds, ocpDate, requestConditions);
                return new RemoveNodesOperation(this, poolId, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
