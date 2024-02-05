// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System.Threading;
using System;
using Azure.Core;

namespace Azure.AI.DocumentIntelligence
{
    [CodeGenSuppress("GetOperationAsync", typeof(Guid), typeof(CancellationToken))]
    [CodeGenSuppress("GetOperation", typeof(Guid), typeof(CancellationToken))]
    [CodeGenSuppress("GetOperationAsync", typeof(Guid), typeof(RequestContext))]
    [CodeGenSuppress("GetOperation", typeof(Guid), typeof(RequestContext))]
    public partial class DocumentIntelligenceAdministrationClient
    {
        // CUSTOM CODE NOTE: the spec incorrectly defines the operationId parameter as a GUID
        // in the GetOperation APIs, but it should be a string. This makes it impossible to
        // use the API since IDs will never be a GUID. Because of this we're manually adding
        // overloads that take a string and forcing the generated ones to be suppressed. Ideally
        // we'll get the spec fixed and this piece of custom code will be removed.

        /// <summary> Gets operation info. </summary>
        /// <param name="operationId"> Operation ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Generated/Docs/DocumentIntelligenceAdministrationClient.xml" path="doc/members/member[@name='GetOperationAsync(Guid,CancellationToken)']/*" />
        public virtual async Task<Response<OperationDetails>> GetOperationAsync(string operationId, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetOperationAsync(operationId, context).ConfigureAwait(false);
            return Response.FromValue(OperationDetails.FromResponse(response), response);
        }

        /// <summary> Gets operation info. </summary>
        /// <param name="operationId"> Operation ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Generated/Docs/DocumentIntelligenceAdministrationClient.xml" path="doc/members/member[@name='GetOperation(Guid,CancellationToken)']/*" />
        public virtual Response<OperationDetails> GetOperation(string operationId, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetOperation(operationId, context);
            return Response.FromValue(OperationDetails.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Gets operation info.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetOperationAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="operationId"> Operation ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/DocumentIntelligenceAdministrationClient.xml" path="doc/members/member[@name='GetOperationAsync(Guid,RequestContext)']/*" />
        public virtual async Task<Response> GetOperationAsync(string operationId, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceAdministrationClient.GetOperation");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetOperationRequest(operationId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets operation info.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetOperation(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="operationId"> Operation ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/DocumentIntelligenceAdministrationClient.xml" path="doc/members/member[@name='GetOperation(Guid,RequestContext)']/*" />
        public virtual Response GetOperation(string operationId, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceAdministrationClient.GetOperation");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetOperationRequest(operationId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // CUSTOM CODE NODE: we're overwriting the behavior of the BuildDocumentModel, ComposeModel,
        // CopyModelTo, and BuildClassifier APIs to return an instance of TrainingOperation. This is
        // a workaround since Operation.Id is not supported by our generator yet (it throws a
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
        /// Please try the simpler <see cref="BuildDocumentModelAsync(WaitUntil,BuildDocumentModelContent,CancellationToken)"/> convenience overload with strongly typed models first.
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
        /// <include file="Generated/Docs/DocumentIntelligenceAdministrationClient.xml" path="doc/members/member[@name='BuildDocumentModelAsync(WaitUntil,RequestContent,RequestContext)']/*" />
        public virtual async Task<Operation<BinaryData>> BuildDocumentModelAsync(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceAdministrationClient.BuildDocumentModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateBuildDocumentModelContent(content, context);
                var internalOperation = await ProtocolOperationHelpers.ProcessMessageAsync(_pipeline, message, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.BuildDocumentModel", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
                return new TrainingOperation(internalOperation);
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
        /// Please try the simpler <see cref="BuildDocumentModel(WaitUntil,BuildDocumentModelContent,CancellationToken)"/> convenience overload with strongly typed models first.
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
        /// <include file="Generated/Docs/DocumentIntelligenceAdministrationClient.xml" path="doc/members/member[@name='BuildDocumentModel(WaitUntil,RequestContent,RequestContext)']/*" />
        public virtual Operation<BinaryData> BuildDocumentModel(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceAdministrationClient.BuildDocumentModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateBuildDocumentModelContent(content, context);
                var internalOperation = ProtocolOperationHelpers.ProcessMessage(_pipeline, message, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.BuildDocumentModel", OperationFinalStateVia.OperationLocation, context, waitUntil);
                return new TrainingOperation(internalOperation);
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
        /// Please try the simpler <see cref="ComposeModelAsync(WaitUntil,ComposeDocumentModelContent,CancellationToken)"/> convenience overload with strongly typed models first.
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
        /// <include file="Generated/Docs/DocumentIntelligenceAdministrationClient.xml" path="doc/members/member[@name='ComposeModelAsync(WaitUntil,RequestContent,RequestContext)']/*" />
        public virtual async Task<Operation<BinaryData>> ComposeModelAsync(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceAdministrationClient.ComposeModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateComposeModelRequest(content, context);
                var internalOperation = await ProtocolOperationHelpers.ProcessMessageAsync(_pipeline, message, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.ComposeModel", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
                return new TrainingOperation(internalOperation);
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
        /// Please try the simpler <see cref="ComposeModel(WaitUntil,ComposeDocumentModelContent,CancellationToken)"/> convenience overload with strongly typed models first.
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
        /// <include file="Generated/Docs/DocumentIntelligenceAdministrationClient.xml" path="doc/members/member[@name='ComposeModel(WaitUntil,RequestContent,RequestContext)']/*" />
        public virtual Operation<BinaryData> ComposeModel(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceAdministrationClient.ComposeModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateComposeModelRequest(content, context);
                var internalOperation = ProtocolOperationHelpers.ProcessMessage(_pipeline, message, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.ComposeModel", OperationFinalStateVia.OperationLocation, context, waitUntil);
                return new TrainingOperation(internalOperation);
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
        /// Please try the simpler <see cref="CopyModelToAsync(WaitUntil,string,CopyAuthorization,CancellationToken)"/> convenience overload with strongly typed models first.
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
        /// <include file="Generated/Docs/DocumentIntelligenceAdministrationClient.xml" path="doc/members/member[@name='CopyModelToAsync(WaitUntil,string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Operation<BinaryData>> CopyModelToAsync(WaitUntil waitUntil, string modelId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceAdministrationClient.CopyModelTo");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCopyModelToRequest(modelId, content, context);
                var internalOperation = await ProtocolOperationHelpers.ProcessMessageAsync(_pipeline, message, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.CopyModelTo", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
                return new TrainingOperation(internalOperation);
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
        /// Please try the simpler <see cref="CopyModelTo(WaitUntil,string,CopyAuthorization,CancellationToken)"/> convenience overload with strongly typed models first.
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
        /// <include file="Generated/Docs/DocumentIntelligenceAdministrationClient.xml" path="doc/members/member[@name='CopyModelTo(WaitUntil,string,RequestContent,RequestContext)']/*" />
        public virtual Operation<BinaryData> CopyModelTo(WaitUntil waitUntil, string modelId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceAdministrationClient.CopyModelTo");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCopyModelToRequest(modelId, content, context);
                var internalOperation = ProtocolOperationHelpers.ProcessMessage(_pipeline, message, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.CopyModelTo", OperationFinalStateVia.OperationLocation, context, waitUntil);
                return new TrainingOperation(internalOperation);
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
        /// Please try the simpler <see cref="BuildClassifierAsync(WaitUntil,BuildDocumentClassifierContent,CancellationToken)"/> convenience overload with strongly typed models first.
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
        /// <include file="Generated/Docs/DocumentIntelligenceAdministrationClient.xml" path="doc/members/member[@name='BuildClassifierAsync(WaitUntil,RequestContent,RequestContext)']/*" />
        public virtual async Task<Operation<BinaryData>> BuildClassifierAsync(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceAdministrationClient.BuildClassifier");
            scope.Start();
            try
            {
                using HttpMessage message = CreateBuildClassifierRequest(content, context);
                var internalOperation = await ProtocolOperationHelpers.ProcessMessageAsync(_pipeline, message, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.BuildClassifier", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
                return new TrainingOperation(internalOperation);
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
        /// Please try the simpler <see cref="BuildClassifier(WaitUntil,BuildDocumentClassifierContent,CancellationToken)"/> convenience overload with strongly typed models first.
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
        /// <include file="Generated/Docs/DocumentIntelligenceAdministrationClient.xml" path="doc/members/member[@name='BuildClassifier(WaitUntil,RequestContent,RequestContext)']/*" />
        public virtual Operation<BinaryData> BuildClassifier(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceAdministrationClient.BuildClassifier");
            scope.Start();
            try
            {
                using HttpMessage message = CreateBuildClassifierRequest(content, context);
                var internalOperation = ProtocolOperationHelpers.ProcessMessage(_pipeline, message, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.BuildClassifier", OperationFinalStateVia.OperationLocation, context, waitUntil);
                return new TrainingOperation(internalOperation);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // CUSTOM CODE NODE: generation of the BuildDocumentModel, ComposeModel, and CopyModelTo APIs
        // is crashing our emitter, so we had to temporarily comment them out of the spec and add
        // their methods manually. Once the issue is identified and addressed, we may be able to move
        // them back to the generated layer. Note that the "Create...Request" internal methods had to
        // be manually added as well.

        /// <summary> Builds a custom document analysis model. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="buildRequest"> Build request parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="buildRequest"/> is null. </exception>
        /// <include file="Generated/Docs/DocumentIntelligenceAdministrationClient.xml" path="doc/members/member[@name='BuildDocumentModelAsync(WaitUntil,BuildDocumentModelContent,CancellationToken)']/*" />
        public virtual async Task<Operation<DocumentModelDetails>> BuildDocumentModelAsync(WaitUntil waitUntil, BuildDocumentModelContent buildRequest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(buildRequest, nameof(buildRequest));

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = buildRequest.ToRequestContent();
            Operation<BinaryData> response = await BuildDocumentModelAsync(waitUntil, content, context).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(response, DocumentModelDetails.FromResponse, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.BuildDocumentModel");
        }

        /// <summary> Builds a custom document analysis model. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="buildRequest"> Build request parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="buildRequest"/> is null. </exception>
        /// <include file="Generated/Docs/DocumentIntelligenceAdministrationClient.xml" path="doc/members/member[@name='BuildDocumentModel(WaitUntil,BuildDocumentModelContent,CancellationToken)']/*" />
        public virtual Operation<DocumentModelDetails> BuildDocumentModel(WaitUntil waitUntil, BuildDocumentModelContent buildRequest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(buildRequest, nameof(buildRequest));

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = buildRequest.ToRequestContent();
            Operation<BinaryData> response = BuildDocumentModel(waitUntil, content, context);
            return ProtocolOperationHelpers.Convert(response, DocumentModelDetails.FromResponse, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.BuildDocumentModel");
        }

        /// <summary> Creates a new document model from document types of existing document models. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="composeRequest"> Compose request parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="composeRequest"/> is null. </exception>
        /// <include file="Generated/Docs/DocumentIntelligenceAdministrationClient.xml" path="doc/members/member[@name='ComposeModelAsync(WaitUntil,ComposeDocumentModelContent,CancellationToken)']/*" />
        public virtual async Task<Operation<DocumentModelDetails>> ComposeModelAsync(WaitUntil waitUntil, ComposeDocumentModelContent composeRequest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(composeRequest, nameof(composeRequest));

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = composeRequest.ToRequestContent();
            Operation<BinaryData> response = await ComposeModelAsync(waitUntil, content, context).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(response, DocumentModelDetails.FromResponse, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.ComposeModel");
        }

        /// <summary> Creates a new document model from document types of existing document models. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="composeRequest"> Compose request parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="composeRequest"/> is null. </exception>
        /// <include file="Generated/Docs/DocumentIntelligenceAdministrationClient.xml" path="doc/members/member[@name='ComposeModel(WaitUntil,ComposeDocumentModelContent,CancellationToken)']/*" />
        public virtual Operation<DocumentModelDetails> ComposeModel(WaitUntil waitUntil, ComposeDocumentModelContent composeRequest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(composeRequest, nameof(composeRequest));

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = composeRequest.ToRequestContent();
            Operation<BinaryData> response = ComposeModel(waitUntil, content, context);
            return ProtocolOperationHelpers.Convert(response, DocumentModelDetails.FromResponse, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.ComposeModel");
        }

        /// <summary> Copies document model to the target resource, region, and modelId. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="copyToRequest"> Copy to request parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="copyToRequest"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Generated/Docs/DocumentIntelligenceAdministrationClient.xml" path="doc/members/member[@name='CopyModelToAsync(WaitUntil,string,CopyAuthorization,CancellationToken)']/*" />
        public virtual async Task<Operation<DocumentModelDetails>> CopyModelToAsync(WaitUntil waitUntil, string modelId, CopyAuthorization copyToRequest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(copyToRequest, nameof(copyToRequest));

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = copyToRequest.ToRequestContent();
            Operation<BinaryData> response = await CopyModelToAsync(waitUntil, modelId, content, context).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(response, DocumentModelDetails.FromResponse, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.CopyModelTo");
        }

        /// <summary> Copies document model to the target resource, region, and modelId. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="copyToRequest"> Copy to request parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="copyToRequest"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Generated/Docs/DocumentIntelligenceAdministrationClient.xml" path="doc/members/member[@name='CopyModelTo(WaitUntil,string,CopyAuthorization,CancellationToken)']/*" />
        public virtual Operation<DocumentModelDetails> CopyModelTo(WaitUntil waitUntil, string modelId, CopyAuthorization copyToRequest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(copyToRequest, nameof(copyToRequest));

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = copyToRequest.ToRequestContent();
            Operation<BinaryData> response = CopyModelTo(waitUntil, modelId, content, context);
            return ProtocolOperationHelpers.Convert(response, DocumentModelDetails.FromResponse, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.CopyModelTo");
        }

        internal HttpMessage CreateGetOperationRequest(string operationId, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/documentintelligence", false);
            uri.AppendPath("/operations/", false);
            uri.AppendPath(operationId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateBuildDocumentModelContent(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier202);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/documentintelligence", false);
            uri.AppendPath("/documentModels:build", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateComposeModelRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier202);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/documentintelligence", false);
            uri.AppendPath("/documentModels:compose", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateCopyModelToRequest(string modelId, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier202);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/documentintelligence", false);
            uri.AppendPath("/documentModels/", false);
            uri.AppendPath(modelId, true);
            uri.AppendPath(":copyTo", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }
    }
}
