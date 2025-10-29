// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.AI.DocumentIntelligence
{
    public partial class DocumentIntelligenceAdministrationClient
    {
        // CUSTOM CODE NOTE: we're overwriting methods AuthorizeClassifierCopy, AuthorizeModelCopy,
        // BuildClassifier, BuildDocumentModel, and ComposeModel for the sole reason of renaming
        // 'request' parameters to 'options'.

        /// <summary>
        /// Generates authorization to copy a document classifier to this location with
        /// specified classifierId and optional description.
        /// </summary>
        /// <param name="options"> Authorize copy request options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Response<ClassifierCopyAuthorization>> AuthorizeClassifierCopyAsync(AuthorizeClassifierCopyOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using RequestContent content = options;
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await AuthorizeClassifierCopyAsync(content, context).ConfigureAwait(false);
            return Response.FromValue(ClassifierCopyAuthorization.FromResponse(response), response);
        }

        /// <summary>
        /// Generates authorization to copy a document classifier to this location with
        /// specified classifierId and optional description.
        /// </summary>
        /// <param name="options"> Authorize copy request options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Response<ClassifierCopyAuthorization> AuthorizeClassifierCopy(AuthorizeClassifierCopyOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using RequestContent content = options;
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = AuthorizeClassifierCopy(content, context);
            return Response.FromValue((ClassifierCopyAuthorization)response, response);
        }

        /// <summary>
        /// Generates authorization to copy a document model to this location with
        /// specified modelId and optional description.
        /// </summary>
        /// <param name="options"> Authorize copy request options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Response<ModelCopyAuthorization>> AuthorizeModelCopyAsync(AuthorizeModelCopyOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using RequestContent content = options;
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await AuthorizeModelCopyAsync(content, context).ConfigureAwait(false);
            return Response.FromValue(ModelCopyAuthorization.FromResponse(response), response);
        }

        /// <summary>
        /// Generates authorization to copy a document model to this location with
        /// specified modelId and optional description.
        /// </summary>
        /// <param name="options"> Authorize copy request options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Response<ModelCopyAuthorization> AuthorizeModelCopy(AuthorizeModelCopyOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using RequestContent content = options;
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = AuthorizeModelCopy(content, context);
            return Response.FromValue((ModelCopyAuthorization)response, response);
        }

        /// <summary> Builds a custom document classifier. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="options"> Build request options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Operation<DocumentClassifierDetails>> BuildClassifierAsync(WaitUntil waitUntil, BuildClassifierOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using RequestContent content = options;
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> result = await BuildClassifierAsync(waitUntil, content, context).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(result, response => (DocumentClassifierDetails)response, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.BuildClassifier");
        }

        /// <summary> Builds a custom document classifier. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="options"> Build request options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Operation<DocumentClassifierDetails> BuildClassifier(WaitUntil waitUntil, BuildClassifierOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using RequestContent content = options;
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> result = BuildClassifier(waitUntil, content, context);
            return ProtocolOperationHelpers.Convert(result, response => (DocumentClassifierDetails)response, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.BuildClassifier");
        }

        /// <summary> Builds a custom document analysis model. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="options"> Build request options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Operation<DocumentModelDetails>> BuildDocumentModelAsync(WaitUntil waitUntil, BuildDocumentModelOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using RequestContent content = options;
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> result = await BuildDocumentModelAsync(waitUntil, content, context).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(result, response => (DocumentModelDetails)response, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.BuildDocumentModel");
        }

        /// <summary> Builds a custom document analysis model. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="options"> Build request options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Operation<DocumentModelDetails> BuildDocumentModel(WaitUntil waitUntil, BuildDocumentModelOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using RequestContent content = options;
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> result = BuildDocumentModel(waitUntil, content, context);
            return ProtocolOperationHelpers.Convert(result, response => (DocumentModelDetails)response, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.BuildDocumentModel");
        }

        /// <summary> Creates a new document model from document types of existing document models. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="options"> Compose request options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Operation<DocumentModelDetails>> ComposeModelAsync(WaitUntil waitUntil, ComposeModelOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using RequestContent content = options;
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> result = await ComposeModelAsync(waitUntil, content, context).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(result, response => (DocumentModelDetails)response, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.ComposeModel");
        }

        /// <summary> Creates a new document model from document types of existing document models. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="options"> Compose request options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Operation<DocumentModelDetails> ComposeModel(WaitUntil waitUntil, ComposeModelOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using RequestContent content = options;
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> result = ComposeModel(waitUntil, content, context);
            return ProtocolOperationHelpers.Convert(result, response => (DocumentModelDetails)response, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.ComposeModel");
        }

        // CUSTOM CODE NOTE: we're overwriting methods CopyClassifierTo and CopyModelTo for the
        // sole reason of renaming 'request' parameters to 'authorization'.

        /// <summary> Copies document classifier to the target resource, region, and classifierId. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="classifierId"> Unique document classifier name. </param>
        /// <param name="authorization"> Copy to request authorization. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="classifierId"/> or <paramref name="authorization"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="classifierId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Operation<DocumentClassifierDetails>> CopyClassifierToAsync(WaitUntil waitUntil, string classifierId, ClassifierCopyAuthorization authorization, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(classifierId, nameof(classifierId));
            Argument.AssertNotNull(authorization, nameof(authorization));

            using RequestContent content = authorization;
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> result = await CopyClassifierToAsync(waitUntil, classifierId, content, context).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(result, response => (DocumentClassifierDetails)response, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.CopyClassifierTo");
        }

        /// <summary> Copies document classifier to the target resource, region, and classifierId. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="classifierId"> Unique document classifier name. </param>
        /// <param name="authorization"> Copy to request authorization. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="classifierId"/> or <paramref name="authorization"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="classifierId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Operation<DocumentClassifierDetails> CopyClassifierTo(WaitUntil waitUntil, string classifierId, ClassifierCopyAuthorization authorization, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(classifierId, nameof(classifierId));
            Argument.AssertNotNull(authorization, nameof(authorization));

            using RequestContent content = authorization;
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> result = CopyClassifierTo(waitUntil, classifierId, content, context);
            return ProtocolOperationHelpers.Convert(result, response => (DocumentClassifierDetails)response, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.CopyClassifierTo");
        }

        /// <summary> Copies document model to the target resource, region, and modelId. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="authorization"> Copy to request authorization. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="authorization"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Operation<DocumentModelDetails>> CopyModelToAsync(WaitUntil waitUntil, string modelId, ModelCopyAuthorization authorization, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(authorization, nameof(authorization));

            using RequestContent content = authorization;
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> result = await CopyModelToAsync(waitUntil, modelId, content, context).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(result, response => (DocumentModelDetails)response , ClientDiagnostics, "DocumentIntelligenceAdministrationClient.CopyModelTo");
        }

        /// <summary> Copies document model to the target resource, region, and modelId. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="authorization"> Copy to request authorization. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="authorization"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Operation<DocumentModelDetails> CopyModelTo(WaitUntil waitUntil, string modelId, ModelCopyAuthorization authorization, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(authorization, nameof(authorization));

            using RequestContent content = authorization;
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> result = CopyModelTo(waitUntil, modelId, content, context);
            return ProtocolOperationHelpers.Convert(result, response => (DocumentModelDetails)response, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.CopyModelTo");
        }

        // CUSTOM CODE NOTE: we're overwriting the behavior of the BuildDocumentModel, ComposeModel,
        // CopyModelTo, BuildClassifier, and CopyClassifierTo APIs to return an instance of OperationWithId.
        // This is a workaround since Operation.Id is not supported by our generator yet (it throws a
        // NotSupportedException), but this ID is needed for the GetOperation API.

        /// <summary>
        /// [Protocol Method] Builds a custom document analysis model.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="BuildDocumentModelAsync(WaitUntil,BuildDocumentModelOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual async Task<Operation<BinaryData>> BuildDocumentModelAsync(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceAdministrationClient.BuildDocumentModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateBuildDocumentModelRequest(content, context);
                var internalOperation = await ProtocolOperationHelpers.ProcessMessageAsync(Pipeline, message, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.BuildDocumentModel", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
                return new OperationWithId(internalOperation);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Builds a custom document analysis model.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="BuildDocumentModel(WaitUntil,BuildDocumentModelOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual Operation<BinaryData> BuildDocumentModel(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceAdministrationClient.BuildDocumentModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateBuildDocumentModelRequest(content, context);
                var internalOperation = ProtocolOperationHelpers.ProcessMessage(Pipeline, message, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.BuildDocumentModel", OperationFinalStateVia.OperationLocation, context, waitUntil);
                return new OperationWithId(internalOperation);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Creates a new document model from document types of existing document models.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ComposeModelAsync(WaitUntil,ComposeModelOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual async Task<Operation<BinaryData>> ComposeModelAsync(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceAdministrationClient.ComposeModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateComposeModelRequest(content, context);
                var internalOperation = await ProtocolOperationHelpers.ProcessMessageAsync(Pipeline, message, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.ComposeModel", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
                return new OperationWithId(internalOperation);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Creates a new document model from document types of existing document models.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ComposeModel(WaitUntil,ComposeModelOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual Operation<BinaryData> ComposeModel(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceAdministrationClient.ComposeModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateComposeModelRequest(content, context);
                var internalOperation = ProtocolOperationHelpers.ProcessMessage(Pipeline, message, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.ComposeModel", OperationFinalStateVia.OperationLocation, context, waitUntil);
                return new OperationWithId(internalOperation);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Copies document model to the target resource, region, and modelId.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CopyModelToAsync(WaitUntil,string,ModelCopyAuthorization,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual async Task<Operation<BinaryData>> CopyModelToAsync(WaitUntil waitUntil, string modelId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceAdministrationClient.CopyModelTo");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCopyModelToRequest(modelId, content, context);
                var internalOperation = await ProtocolOperationHelpers.ProcessMessageAsync(Pipeline, message, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.CopyModelTo", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
                return new OperationWithId(internalOperation);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Copies document model to the target resource, region, and modelId.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CopyModelTo(WaitUntil,string,ModelCopyAuthorization,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual Operation<BinaryData> CopyModelTo(WaitUntil waitUntil, string modelId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceAdministrationClient.CopyModelTo");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCopyModelToRequest(modelId, content, context);
                var internalOperation = ProtocolOperationHelpers.ProcessMessage(Pipeline, message, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.CopyModelTo", OperationFinalStateVia.OperationLocation, context, waitUntil);
                return new OperationWithId(internalOperation);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Builds a custom document classifier.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="BuildClassifierAsync(WaitUntil,BuildClassifierOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual async Task<Operation<BinaryData>> BuildClassifierAsync(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceAdministrationClient.BuildClassifier");
            scope.Start();
            try
            {
                using HttpMessage message = CreateBuildClassifierRequest(content, context);
                var internalOperation = await ProtocolOperationHelpers.ProcessMessageAsync(Pipeline, message, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.BuildClassifier", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
                return new OperationWithId(internalOperation);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Builds a custom document classifier.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="BuildClassifier(WaitUntil,BuildClassifierOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual Operation<BinaryData> BuildClassifier(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceAdministrationClient.BuildClassifier");
            scope.Start();
            try
            {
                using HttpMessage message = CreateBuildClassifierRequest(content, context);
                var internalOperation = ProtocolOperationHelpers.ProcessMessage(Pipeline, message, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.BuildClassifier", OperationFinalStateVia.OperationLocation, context, waitUntil);
                return new OperationWithId(internalOperation);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Copies document classifier to the target resource, region, and classifierId.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CopyClassifierToAsync(WaitUntil,string,ClassifierCopyAuthorization,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="classifierId"> Unique document classifier name. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="classifierId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="classifierId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual async Task<Operation<BinaryData>> CopyClassifierToAsync(WaitUntil waitUntil, string classifierId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(classifierId, nameof(classifierId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceAdministrationClient.CopyClassifierTo");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCopyClassifierToRequest(classifierId, content, context);
                var internalOperation = await ProtocolOperationHelpers.ProcessMessageAsync(Pipeline, message, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.CopyClassifierTo", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
                return new OperationWithId(internalOperation);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Copies document classifier to the target resource, region, and classifierId.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CopyClassifierTo(WaitUntil,string,ClassifierCopyAuthorization,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="classifierId"> Unique document classifier name. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="classifierId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="classifierId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual Operation<BinaryData> CopyClassifierTo(WaitUntil waitUntil, string classifierId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(classifierId, nameof(classifierId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceAdministrationClient.CopyClassifierTo");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCopyClassifierToRequest(classifierId, content, context);
                var internalOperation = ProtocolOperationHelpers.ProcessMessage(Pipeline, message, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.CopyClassifierTo", OperationFinalStateVia.OperationLocation, context, waitUntil);
                return new OperationWithId(internalOperation);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
