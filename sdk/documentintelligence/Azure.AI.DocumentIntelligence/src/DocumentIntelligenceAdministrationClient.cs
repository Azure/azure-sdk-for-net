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
        // CUSTOM CODE NOTE: we're overwriting the behavior of the BuildDocumentModel, ComposeModel,
        // CopyModelTo, BuildClassifier, and CopyClassifierTo APIs to return an instance of TrainingOperation.
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
                using HttpMessage message = CreateBuildDocumentModelRequest(content, context);
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
                using HttpMessage message = CreateBuildDocumentModelRequest(content, context);
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
        /// <include file="Generated/Docs/DocumentIntelligenceAdministrationClient.xml" path="doc/members/member[@name='CopyClassifierToAsync(WaitUntil,string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Operation<BinaryData>> CopyClassifierToAsync(WaitUntil waitUntil, string classifierId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(classifierId, nameof(classifierId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceAdministrationClient.CopyClassifierTo");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCopyClassifierToRequest(classifierId, content, context);
                var internalOperation = await ProtocolOperationHelpers.ProcessMessageAsync(_pipeline, message, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.CopyClassifierTo", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
                return new TrainingOperation(internalOperation);
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
        /// <include file="Generated/Docs/DocumentIntelligenceAdministrationClient.xml" path="doc/members/member[@name='CopyClassifierTo(WaitUntil,string,RequestContent,RequestContext)']/*" />
        public virtual Operation<BinaryData> CopyClassifierTo(WaitUntil waitUntil, string classifierId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(classifierId, nameof(classifierId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceAdministrationClient.CopyClassifierTo");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCopyClassifierToRequest(classifierId, content, context);
                var internalOperation = ProtocolOperationHelpers.ProcessMessage(_pipeline, message, ClientDiagnostics, "DocumentIntelligenceAdministrationClient.CopyClassifierTo", OperationFinalStateVia.OperationLocation, context, waitUntil);
                return new TrainingOperation(internalOperation);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
