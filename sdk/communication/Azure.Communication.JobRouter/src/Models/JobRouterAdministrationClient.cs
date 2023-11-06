// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Threading;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.JobRouter
{
    [CodeGenSuppress("JobRouterAdministrationClient", typeof(Uri))]
    [CodeGenSuppress("JobRouterAdministrationClient", typeof(Uri), typeof(JobRouterClientOptions))]
    [CodeGenSuppress("CreateGetExceptionPoliciesNextPageRequest", typeof(string), typeof(int?), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetClassificationPoliciesNextPageRequest", typeof(string), typeof(int?), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetQueuesNextPageRequest", typeof(string), typeof(int?), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetDistributionPoliciesNextPageRequest", typeof(string), typeof(int?), typeof(RequestContext))]
    public partial class JobRouterAdministrationClient
    {
        #region public constructors

        /// <summary> Initializes a new instance of <see cref="JobRouterAdministrationClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        public JobRouterAdministrationClient(string connectionString)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                new JobRouterClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="JobRouterAdministrationClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public JobRouterAdministrationClient(string connectionString, JobRouterClientOptions options)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                options ?? new JobRouterClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="JobRouterAdministrationClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="credential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public JobRouterAdministrationClient(Uri endpoint, AzureKeyCredential credential, JobRouterClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(credential, nameof(credential)),
                options ?? new JobRouterClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="JobRouterAdministrationClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="credential">The TokenCredential used to authenticate requests, such as DefaultAzureCredential.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public JobRouterAdministrationClient(Uri endpoint, TokenCredential credential, JobRouterClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(credential, nameof(credential)),
                options ?? new JobRouterClientOptions())
        {
        }

        #endregion public constructors

        #region internal constructors

        /// <summary> Initializes a new instance of JobRouterClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        internal JobRouterAdministrationClient(Uri endpoint) : this(endpoint, new JobRouterClientOptions())
        {
        }

        /// <summary> Initializes a new instance of JobRouterClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        internal JobRouterAdministrationClient(Uri endpoint, JobRouterClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new JobRouterClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        #endregion

        #region private constructors

        private JobRouterAdministrationClient(ConnectionString connectionString, JobRouterClientOptions options)
            : this(new Uri(connectionString.GetRequired("endpoint"), UriKind.Absolute), options.BuildHttpPipeline(connectionString), options)
        {
        }

        private JobRouterAdministrationClient(string endpoint, TokenCredential tokenCredential, JobRouterClientOptions options)
            : this(new Uri(endpoint, UriKind.Absolute), options.BuildHttpPipeline(tokenCredential), options)
        {
        }

        private JobRouterAdministrationClient(string endpoint, AzureKeyCredential keyCredential, JobRouterClientOptions options)
            : this(new Uri(endpoint, UriKind.Absolute), options.BuildHttpPipeline(keyCredential), options)
        {
        }

        /// <summary>Initializes a new instance of <see cref="JobRouterAdministrationClient"/> for mocking.</summary>
        protected JobRouterAdministrationClient()
        {
            ClientDiagnostics = null;
        }

        #endregion private constructors

        #region ClassificationPolicy

        /// <summary> Creates a classification policy. </summary>
        /// <param name="options"> (Optional) Options for creating classification policy. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7396. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<ClassificationPolicy>> CreateClassificationPolicyAsync(
            CreateClassificationPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(CreateClassificationPolicy)}");
            scope.Start();
            try
            {
                var request = new ClassificationPolicy()
                {
                    Name = options.Name,
                    FallbackQueueId = options.FallbackQueueId,
                    PrioritizationRule = options.PrioritizationRule,
                };

                request.QueueSelectorAttachments.AddRange(options.QueueSelectorAttachments);
                request.WorkerSelectorAttachments.AddRange(options.WorkerSelectorAttachments);

                var result = await UpsertClassificationPolicyAsync(
                        classificationPolicyId: options.ClassificationPolicyId,
                        content: request.ToRequestContent(),
                        requestConditions: options.RequestConditions ?? new RequestConditions(),
                        context: FromCancellationToken(cancellationToken))
                    .ConfigureAwait(false);

                return Response.FromValue(ClassificationPolicy.FromResponse(result), result);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates or updates a classification policy. </summary>
        /// <param name="options"> (Optional) Options for creating classification policy. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<ClassificationPolicy> CreateClassificationPolicy(
            CreateClassificationPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(CreateClassificationPolicy)}");
            scope.Start();
            try
            {
                var request = new ClassificationPolicy()
                {
                    Name = options.Name,
                    FallbackQueueId = options.FallbackQueueId,
                    PrioritizationRule = options.PrioritizationRule,
                };

                request.QueueSelectorAttachments.AddRange(options.QueueSelectorAttachments);
                request.WorkerSelectorAttachments.AddRange(options.WorkerSelectorAttachments);

                var result = UpsertClassificationPolicy(
                    classificationPolicyId: options.ClassificationPolicyId,
                    content: request.ToRequestContent(),
                    requestConditions: options.RequestConditions ?? new RequestConditions(),
                    context: FromCancellationToken(cancellationToken));

                return Response.FromValue(ClassificationPolicy.FromResponse(result), result);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Updates classification policy. </summary>
        /// <param name="classificationPolicy"> Classification policy to update. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7396. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<ClassificationPolicy>> UpdateClassificationPolicyAsync(
            ClassificationPolicy classificationPolicy, RequestConditions requestConditions = default,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateClassificationPolicy)}");
            scope.Start();
            try
            {
                var response = await UpsertClassificationPolicyAsync(
                        classificationPolicyId: classificationPolicy.Id,
                        content: classificationPolicy.ToRequestContent(),
                        requestConditions: requestConditions ?? new RequestConditions(),
                        context: FromCancellationToken(cancellationToken))
                    .ConfigureAwait(false);

                return Response.FromValue(ClassificationPolicy.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Updates classification policy. </summary>
        /// <param name="classificationPolicy"> Classification policy to update. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7396. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<ClassificationPolicy> UpdateClassificationPolicy(
            ClassificationPolicy classificationPolicy, RequestConditions requestConditions = default,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateClassificationPolicy)}");
            scope.Start();
            try
            {
                var response = UpsertClassificationPolicy(
                    classificationPolicyId: classificationPolicy.Id,
                    content: classificationPolicy.ToRequestContent(),
                    requestConditions: requestConditions ?? new RequestConditions(),
                    context: FromCancellationToken(cancellationToken));

                return Response.FromValue(ClassificationPolicy.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Updates a classification policy.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="classificationPolicyId"> Unique identifier of this policy. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="classificationPolicyId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="classificationPolicyId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> UpdateClassificationPolicyAsync(string classificationPolicyId, RequestContent content, RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(classificationPolicyId, nameof(classificationPolicyId));
            Argument.AssertNotNull(content, nameof(content));

            Argument.AssertNull(requestConditions?.IfNoneMatch, nameof(requestConditions), "Service does not support the If-None-Match header for this operation.");
            Argument.AssertNull(requestConditions?.IfModifiedSince, nameof(requestConditions), "Service does not support the If-Modified-Since header for this operation.");

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateClassificationPolicy)}");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUpsertClassificationPolicyRequest(classificationPolicyId, content, requestConditions, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Updates a classification policy.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="classificationPolicyId"> Unique identifier of this policy. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="classificationPolicyId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="classificationPolicyId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response UpdateClassificationPolicy(string classificationPolicyId, RequestContent content, RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(classificationPolicyId, nameof(classificationPolicyId));
            Argument.AssertNotNull(content, nameof(content));

            Argument.AssertNull(requestConditions?.IfNoneMatch, nameof(requestConditions), "Service does not support the If-None-Match header for this operation.");
            Argument.AssertNull(requestConditions?.IfModifiedSince, nameof(requestConditions), "Service does not support the If-Modified-Since header for this operation.");

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateClassificationPolicy)}");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUpsertClassificationPolicyRequest(classificationPolicyId, content, requestConditions, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion ClassificationPolicy

        #region DistributionPolicy

        /// <summary> Creates a distribution policy. </summary>
        /// <param name="options"> Additional options that can be used while creating distribution policy. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<DistributionPolicy>> CreateDistributionPolicyAsync(
            CreateDistributionPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(CreateDistributionPolicy)}");
            scope.Start();
            try
            {
                var request = new DistributionPolicy(options.OfferExpiresAfter, options.Mode)
                {
                    Name = options?.Name,
                };

                var response = await UpsertDistributionPolicyAsync(
                        distributionPolicyId: options.DistributionPolicyId,
                        content: request.ToRequestContent(),
                        requestConditions: options.RequestConditions ?? new RequestConditions(),
                        context: FromCancellationToken(cancellationToken))
                    .ConfigureAwait(false);

                return Response.FromValue(DistributionPolicy.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates a distribution policy. </summary>
        /// <param name="options"> Additional options that can be used while creating distribution policy. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<DistributionPolicy> CreateDistributionPolicy(
            CreateDistributionPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(CreateDistributionPolicy)}");
            scope.Start();
            try
            {
                var request = new DistributionPolicy(options.OfferExpiresAfter, options.Mode)
                {
                    Name = options?.Name,
                };

                var response = UpsertDistributionPolicy(
                    distributionPolicyId: options.DistributionPolicyId,
                    content: request.ToRequestContent(),
                    requestConditions: options.RequestConditions ?? new RequestConditions(),
                    context: FromCancellationToken(cancellationToken));

                return Response.FromValue(DistributionPolicy.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Updates a distribution policy. </summary>
        /// <param name="distributionPolicy"> The distribution policy to update. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<DistributionPolicy>> UpdateDistributionPolicyAsync(
            DistributionPolicy distributionPolicy, RequestConditions requestConditions = default,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateDistributionPolicy)}");
            scope.Start();
            try
            {
                var response = await UpsertDistributionPolicyAsync(
                        distributionPolicyId: distributionPolicy.Id,
                        content: distributionPolicy.ToRequestContent(),
                        requestConditions: requestConditions ?? new RequestConditions(),
                        context: FromCancellationToken(cancellationToken))
                    .ConfigureAwait(false);

                return Response.FromValue(DistributionPolicy.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Updates a distribution policy. </summary>
        /// <param name="distributionPolicy"> The distribution policy to update. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<DistributionPolicy> UpdateDistributionPolicy(
            DistributionPolicy distributionPolicy, RequestConditions requestConditions = default,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateDistributionPolicy)}");
            scope.Start();
            try
            {
                var response = UpsertDistributionPolicy(
                    distributionPolicyId: distributionPolicy.Id,
                    content: distributionPolicy.ToRequestContent(),
                    requestConditions: requestConditions ?? new RequestConditions(),
                    context: FromCancellationToken(cancellationToken));

                return Response.FromValue(DistributionPolicy.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Updates a distribution policy.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="distributionPolicyId"> The unique identifier of the policy. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="distributionPolicyId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="distributionPolicyId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> UpdateDistributionPolicyAsync(string distributionPolicyId, RequestContent content, RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(distributionPolicyId, nameof(distributionPolicyId));
            Argument.AssertNotNull(content, nameof(content));

            Argument.AssertNull(requestConditions?.IfNoneMatch, nameof(requestConditions), "Service does not support the If-None-Match header for this operation.");
            Argument.AssertNull(requestConditions?.IfModifiedSince, nameof(requestConditions), "Service does not support the If-Modified-Since header for this operation.");

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateDistributionPolicy)}");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUpsertDistributionPolicyRequest(distributionPolicyId, content, requestConditions, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Updates a distribution policy.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="distributionPolicyId"> The unique identifier of the policy. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="distributionPolicyId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="distributionPolicyId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response UpdateDistributionPolicy(string distributionPolicyId, RequestContent content, RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(distributionPolicyId, nameof(distributionPolicyId));
            Argument.AssertNotNull(content, nameof(content));

            Argument.AssertNull(requestConditions?.IfNoneMatch, nameof(requestConditions), "Service does not support the If-None-Match header for this operation.");
            Argument.AssertNull(requestConditions?.IfModifiedSince, nameof(requestConditions), "Service does not support the If-Modified-Since header for this operation.");

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateDistributionPolicy)}");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUpsertDistributionPolicyRequest(distributionPolicyId, content, requestConditions, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion DistributionPolicy

        #region ExceptionPolicy

        /// <summary> Creates a new exception policy. </summary>
        /// <param name="options"> (Optional) Options for creating an exception policy. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<ExceptionPolicy>> CreateExceptionPolicyAsync(
            CreateExceptionPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(CreateExceptionPolicy)}");
            scope.Start();
            try
            {
                var request = new ExceptionPolicy()
                {
                    Name = options.Name
                };

                request.ExceptionRules.AddRange(options.ExceptionRules);

                var response = await UpsertExceptionPolicyAsync(
                        exceptionPolicyId: options.ExceptionPolicyId,
                        content: request.ToRequestContent(),
                        requestConditions: options.RequestConditions ?? new RequestConditions(),
                        context: FromCancellationToken(cancellationToken))
                    .ConfigureAwait(false);

                return Response.FromValue(ExceptionPolicy.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates or updates a exception policy. </summary>
        /// <param name="options"> (Optional) Options for creating an exception policy. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<ExceptionPolicy> CreateExceptionPolicy(
            CreateExceptionPolicyOptions options = default,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(CreateExceptionPolicy)}");
            scope.Start();
            try
            {
                var request = new ExceptionPolicy()
                {
                    Name = options.Name
                };

                request.ExceptionRules.AddRange(options.ExceptionRules);

                var response = UpsertExceptionPolicy(
                    exceptionPolicyId: options.ExceptionPolicyId,
                    content: request.ToRequestContent(),
                    requestConditions: options.RequestConditions ?? new RequestConditions(),
                    context: FromCancellationToken(cancellationToken));

                return Response.FromValue(ExceptionPolicy.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates a new exception policy. </summary>
        /// <param name="exceptionPolicy"> Exception policy to update. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7396. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<ExceptionPolicy>> UpdateExceptionPolicyAsync(
            ExceptionPolicy exceptionPolicy, RequestConditions requestConditions = default,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateExceptionPolicy)}");
            scope.Start();
            try
            {
                var response = await UpsertExceptionPolicyAsync(
                        exceptionPolicyId: exceptionPolicy.Id,
                        content: exceptionPolicy.ToRequestContent(),
                        requestConditions: requestConditions ?? new RequestConditions(),
                        context: FromCancellationToken(cancellationToken))
                    .ConfigureAwait(false);

                return Response.FromValue(ExceptionPolicy.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates a new exception policy. </summary>
        /// <param name="exceptionPolicy"> Exception policy to update. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7396. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<ExceptionPolicy> UpdateExceptionPolicy(
            ExceptionPolicy exceptionPolicy, RequestConditions requestConditions = default,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateExceptionPolicy)}");
            scope.Start();
            try
            {
                var response = UpsertExceptionPolicy(
                    exceptionPolicyId: exceptionPolicy.Id,
                    content: exceptionPolicy.ToRequestContent(),
                    requestConditions: requestConditions ?? new RequestConditions(),
                    context: FromCancellationToken(cancellationToken));

                return Response.FromValue(ExceptionPolicy.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Updates a exception policy.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="exceptionPolicyId"> The Id of the exception policy. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exceptionPolicyId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="exceptionPolicyId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual async Task<Response> UpdateExceptionPolicyAsync(string exceptionPolicyId, RequestContent content, RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(exceptionPolicyId, nameof(exceptionPolicyId));
            Argument.AssertNotNull(content, nameof(content));

            Argument.AssertNull(requestConditions?.IfNoneMatch, nameof(requestConditions), "Service does not support the If-None-Match header for this operation.");
            Argument.AssertNull(requestConditions?.IfModifiedSince, nameof(requestConditions), "Service does not support the If-Modified-Since header for this operation.");

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateExceptionPolicy)}");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUpsertExceptionPolicyRequest(exceptionPolicyId, content, requestConditions, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Updates a exception policy.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="exceptionPolicyId"> The Id of the exception policy. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exceptionPolicyId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="exceptionPolicyId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual Response UpdateExceptionPolicy(string exceptionPolicyId, RequestContent content, RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(exceptionPolicyId, nameof(exceptionPolicyId));
            Argument.AssertNotNull(content, nameof(content));

            Argument.AssertNull(requestConditions?.IfNoneMatch, nameof(requestConditions), "Service does not support the If-None-Match header for this operation.");
            Argument.AssertNull(requestConditions?.IfModifiedSince, nameof(requestConditions), "Service does not support the If-Modified-Since header for this operation.");

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateExceptionPolicy)}");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUpsertExceptionPolicyRequest(exceptionPolicyId, content, requestConditions, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion ExceptionPolicy

        #region Queue

        /// <summary> Creates a queue. </summary>
        /// <param name="options"> Options for creating a job queue. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterQueue>> CreateQueueAsync(
            CreateQueueOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(CreateQueue)}");
            scope.Start();
            try
            {
                var request = new RouterQueue()
                {
                    DistributionPolicyId = options.DistributionPolicyId,
                    Name = options.Name,
                    ExceptionPolicyId = options.ExceptionPolicyId,
                };

                foreach (var label in options.Labels)
                {
                    request.Labels[label.Key] = label.Value;
                }

                var response = await UpsertQueueAsync(
                        queueId: options.QueueId,
                        content: request.ToRequestContent(),
                        requestConditions: options.RequestConditions ?? new RequestConditions(),
                        context: FromCancellationToken(cancellationToken))
                    .ConfigureAwait(false);

                return Response.FromValue(RouterQueue.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates a queue. </summary>
        /// <param name="options"> Options for creating a job queue. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<RouterQueue> CreateQueue(
            CreateQueueOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(CreateQueue)}");
            scope.Start();
            try
            {
                var request = new RouterQueue()
                {
                    DistributionPolicyId = options.DistributionPolicyId,
                    Name = options.Name,
                    ExceptionPolicyId = options.ExceptionPolicyId,
                };

                foreach (var label in options.Labels)
                {
                    request.Labels[label.Key] = label.Value;
                }

                var response = UpsertQueue(
                    queueId: options.QueueId,
                    content: request.ToRequestContent(),
                    requestConditions: options.RequestConditions ?? new RequestConditions(),
                    context: FromCancellationToken(cancellationToken));

                return Response.FromValue(RouterQueue.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Updates a queue. </summary>
        /// <param name="queue"> Queue to update. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7396. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queue"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterQueue>> UpdateQueueAsync(
            RouterQueue queue, RequestConditions requestConditions = default,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateQueue)}");
            scope.Start();
            try
            {
                var response = await UpsertQueueAsync(
                        queueId: queue.Id,
                        content: queue.ToRequestContent(),
                        requestConditions: requestConditions ?? new RequestConditions(),
                        context: FromCancellationToken(cancellationToken))
                    .ConfigureAwait(false);

                return Response.FromValue(RouterQueue.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Updates a queue. </summary>
        /// <param name="queue"> Queue to update. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7396. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queue"/> is null. </exception>/// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<RouterQueue> UpdateQueue(
            RouterQueue queue, RequestConditions requestConditions = default,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateQueue)}");
            scope.Start();
            try
            {
                var response = UpsertQueue(
                    queueId: queue.Id,
                    content: queue.ToRequestContent(),
                    requestConditions: requestConditions ?? new RequestConditions(),
                    context: FromCancellationToken(cancellationToken));

                return Response.FromValue(RouterQueue.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Updates a queue.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="queueId"> The Id of this queue. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queueId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="queueId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> UpdateQueueAsync(string queueId, RequestContent content, RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(queueId, nameof(queueId));
            Argument.AssertNotNull(content, nameof(content));

            Argument.AssertNull(requestConditions?.IfNoneMatch, nameof(requestConditions), "Service does not support the If-None-Match header for this operation.");
            Argument.AssertNull(requestConditions?.IfModifiedSince, nameof(requestConditions), "Service does not support the If-Modified-Since header for this operation.");

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateQueue)}");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUpsertQueueRequest(queueId, content, requestConditions, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Updates a queue.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="queueId"> The Id of this queue. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queueId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="queueId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual Response UpdateQueue(string queueId, RequestContent content, RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(queueId, nameof(queueId));
            Argument.AssertNotNull(content, nameof(content));

            Argument.AssertNull(requestConditions?.IfNoneMatch, nameof(requestConditions), "Service does not support the If-None-Match header for this operation.");
            Argument.AssertNull(requestConditions?.IfModifiedSince, nameof(requestConditions), "Service does not support the If-Modified-Since header for this operation.");

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateQueue)}");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUpsertQueueRequest(queueId, content, requestConditions, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion Queue

        /// <summary> Initializes a new instance of JobRouterAdministrationRestClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        internal JobRouterAdministrationClient(Uri endpoint, HttpPipeline pipeline, JobRouterClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new JobRouterClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = pipeline;
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

#pragma warning disable CA1801 // Review unused parameters
        // Temporary work around before fix: https://github.com/Azure/autorest.csharp/issues/2323
        internal HttpMessage CreateGetExceptionPoliciesNextPageRequest(string nextLink, int? maxpagesize, RequestContext context)
#pragma warning restore CA1801 // Review unused parameters
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

#pragma warning disable CA1801 // Review unused parameters
        // Temporary work around before fix: https://github.com/Azure/autorest.csharp/issues/2323
        internal HttpMessage CreateGetClassificationPoliciesNextPageRequest(string nextLink, int? maxpagesize, RequestContext context)
#pragma warning restore CA1801 // Review unused parameters
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

#pragma warning disable CA1801 // Review unused parameters
        // Temporary work around before fix: https://github.com/Azure/autorest.csharp/issues/2323
        internal HttpMessage CreateGetQueuesNextPageRequest(string nextLink, int? maxpagesize, RequestContext context)
#pragma warning restore CA1801 // Review unused parameters
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

#pragma warning disable CA1801 // Review unused parameters
        // Temporary work around before fix: https://github.com/Azure/autorest.csharp/issues/2323
        internal HttpMessage CreateGetDistributionPoliciesNextPageRequest(string nextLink, int? maxpagesize, RequestContext context)
#pragma warning restore CA1801 // Review unused parameters
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }
    }
}
