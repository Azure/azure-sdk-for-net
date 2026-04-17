// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.HDInsight.Models;

namespace Azure.ResourceManager.HDInsight
{
    public partial class HDInsightClusterResource
    {
        // Tag operations

        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<HDInsightClusterResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _hdInsightClusterClientDiagnostics.CreateScope("HDInsightClusterResource.AddTag");
            scope.Start();
            try
            {
                var current = (await GetAsync(cancellationToken).ConfigureAwait(false)).Value.Data;
                var patch = new HDInsightClusterPatch();
                foreach (var tag in current.Tags)
                {
                    patch.Tags[tag.Key] = tag.Value;
                }
                patch.Tags[key] = value;
                var result = await UpdateAsync(patch, cancellationToken).ConfigureAwait(false);
                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<HDInsightClusterResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _hdInsightClusterClientDiagnostics.CreateScope("HDInsightClusterResource.AddTag");
            scope.Start();
            try
            {
                var current = Get(cancellationToken).Value.Data;
                var patch = new HDInsightClusterPatch();
                foreach (var tag in current.Tags)
                {
                    patch.Tags[tag.Key] = tag.Value;
                }
                patch.Tags[key] = value;
                var result = Update(patch, cancellationToken);
                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<HDInsightClusterResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using DiagnosticScope scope = _hdInsightClusterClientDiagnostics.CreateScope("HDInsightClusterResource.SetTags");
            scope.Start();
            try
            {
                var patch = new HDInsightClusterPatch();
                foreach (var tag in tags)
                {
                    patch.Tags[tag.Key] = tag.Value;
                }
                var result = await UpdateAsync(patch, cancellationToken).ConfigureAwait(false);
                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<HDInsightClusterResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using DiagnosticScope scope = _hdInsightClusterClientDiagnostics.CreateScope("HDInsightClusterResource.SetTags");
            scope.Start();
            try
            {
                var patch = new HDInsightClusterPatch();
                foreach (var tag in tags)
                {
                    patch.Tags[tag.Key] = tag.Value;
                }
                var result = Update(patch, cancellationToken);
                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<HDInsightClusterResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using DiagnosticScope scope = _hdInsightClusterClientDiagnostics.CreateScope("HDInsightClusterResource.RemoveTag");
            scope.Start();
            try
            {
                var current = (await GetAsync(cancellationToken).ConfigureAwait(false)).Value.Data;
                var patch = new HDInsightClusterPatch();
                foreach (var tag in current.Tags)
                {
                    if (!string.Equals(tag.Key, key, StringComparison.OrdinalIgnoreCase))
                    {
                        patch.Tags[tag.Key] = tag.Value;
                    }
                }
                var result = await UpdateAsync(patch, cancellationToken).ConfigureAwait(false);
                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<HDInsightClusterResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using DiagnosticScope scope = _hdInsightClusterClientDiagnostics.CreateScope("HDInsightClusterResource.RemoveTag");
            scope.Start();
            try
            {
                var current = Get(cancellationToken).Value.Data;
                var patch = new HDInsightClusterPatch();
                foreach (var tag in current.Tags)
                {
                    if (!string.Equals(tag.Key, key, StringComparison.OrdinalIgnoreCase))
                    {
                        patch.Tags[tag.Key] = tag.Value;
                    }
                }
                var result = Update(patch, cancellationToken);
                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Extension operations

        /// <summary> Gets the extension properties for the specified HDInsight cluster extension. </summary>
        /// <param name="extensionName"> The name of the cluster extension. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="extensionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="extensionName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<HDInsightClusterExtensionStatus>> GetExtensionAsync(string extensionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(extensionName, nameof(extensionName));

            using DiagnosticScope scope = _extensionsClientDiagnostics.CreateScope("HDInsightClusterResource.GetExtension");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _extensionsRestClient.CreateGetExtensionRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, extensionName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(HDInsightClusterExtensionStatus.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the extension properties for the specified HDInsight cluster extension. </summary>
        /// <param name="extensionName"> The name of the cluster extension. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="extensionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="extensionName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<HDInsightClusterExtensionStatus> GetExtension(string extensionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(extensionName, nameof(extensionName));

            using DiagnosticScope scope = _extensionsClientDiagnostics.CreateScope("HDInsightClusterResource.GetExtension");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _extensionsRestClient.CreateGetExtensionRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, extensionName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(HDInsightClusterExtensionStatus.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates an HDInsight cluster extension. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="extensionName"> The name of the cluster extension. </param>
        /// <param name="content"> The cluster extensions create request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="extensionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="extensionName"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> CreateExtensionAsync(WaitUntil waitUntil, string extensionName, HDInsightClusterCreateExtensionContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(extensionName, nameof(extensionName));
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _extensionsClientDiagnostics.CreateScope("HDInsightClusterResource.CreateExtension");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _extensionsRestClient.CreateCreateExtensionRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, extensionName, HDInsightClusterCreateExtensionContent.ToRequestContent(content), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                HDInsightArmOperation operation = new HDInsightArmOperation(_extensionsClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates an HDInsight cluster extension. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="extensionName"> The name of the cluster extension. </param>
        /// <param name="content"> The cluster extensions create request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="extensionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="extensionName"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation CreateExtension(WaitUntil waitUntil, string extensionName, HDInsightClusterCreateExtensionContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(extensionName, nameof(extensionName));
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _extensionsClientDiagnostics.CreateScope("HDInsightClusterResource.CreateExtension");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _extensionsRestClient.CreateCreateExtensionRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, extensionName, HDInsightClusterCreateExtensionContent.ToRequestContent(content), context);
                Response response = Pipeline.ProcessMessage(message, context);
                HDInsightArmOperation operation = new HDInsightArmOperation(_extensionsClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletionResponse(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes the specified extension for HDInsight cluster. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="extensionName"> The name of the cluster extension. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="extensionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="extensionName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeleteExtensionAsync(WaitUntil waitUntil, string extensionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(extensionName, nameof(extensionName));

            using DiagnosticScope scope = _extensionsClientDiagnostics.CreateScope("HDInsightClusterResource.DeleteExtension");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _extensionsRestClient.CreateDeleteExtensionRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, extensionName, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                HDInsightArmOperation operation = new HDInsightArmOperation(_extensionsClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes the specified extension for HDInsight cluster. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="extensionName"> The name of the cluster extension. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="extensionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="extensionName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation DeleteExtension(WaitUntil waitUntil, string extensionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(extensionName, nameof(extensionName));

            using DiagnosticScope scope = _extensionsClientDiagnostics.CreateScope("HDInsightClusterResource.DeleteExtension");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _extensionsRestClient.CreateDeleteExtensionRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, extensionName, context);
                Response response = Pipeline.ProcessMessage(message, context);
                HDInsightArmOperation operation = new HDInsightArmOperation(_extensionsClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletionResponse(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the async operation status of the extension. </summary>
        /// <param name="extensionName"> The name of the cluster extension. </param>
        /// <param name="operationId"> The long running operation id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="extensionName"/> or <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="extensionName"/> or <paramref name="operationId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<HDInsightAsyncOperationResult>> GetExtensionAsyncOperationStatusAsync(string extensionName, string operationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(extensionName, nameof(extensionName));
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));

            using DiagnosticScope scope = _extensionsClientDiagnostics.CreateScope("HDInsightClusterResource.GetExtensionAsyncOperationStatus");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _extensionsRestClient.CreateGetExtensionAsyncOperationStatusRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, extensionName, operationId, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(HDInsightAsyncOperationResult.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the async operation status of the extension. </summary>
        /// <param name="extensionName"> The name of the cluster extension. </param>
        /// <param name="operationId"> The long running operation id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="extensionName"/> or <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="extensionName"/> or <paramref name="operationId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<HDInsightAsyncOperationResult> GetExtensionAsyncOperationStatus(string extensionName, string operationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(extensionName, nameof(extensionName));
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));

            using DiagnosticScope scope = _extensionsClientDiagnostics.CreateScope("HDInsightClusterResource.GetExtensionAsyncOperationStatus");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _extensionsRestClient.CreateGetExtensionAsyncOperationStatusRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, extensionName, operationId, context);
                Response result = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(HDInsightAsyncOperationResult.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Configuration operations

        /// <summary> Gets the specified cluster configuration. </summary>
        /// <param name="configurationName"> The name of the cluster configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="configurationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="configurationName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<IReadOnlyDictionary<string, string>>> GetConfigurationAsync(string configurationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(configurationName, nameof(configurationName));

            using DiagnosticScope scope = _configurationsClientDiagnostics.CreateScope("HDInsightClusterResource.GetConfiguration");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _configurationsRestClient.CreateGetConfigurationByNameRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, configurationName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                using JsonDocument document = JsonDocument.Parse(result.Content);
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                foreach (var property in document.RootElement.EnumerateObject())
                {
                    dictionary[property.Name] = property.Value.GetString();
                }
                return Response.FromValue((IReadOnlyDictionary<string, string>)dictionary, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the specified cluster configuration. </summary>
        /// <param name="configurationName"> The name of the cluster configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="configurationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="configurationName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<IReadOnlyDictionary<string, string>> GetConfiguration(string configurationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(configurationName, nameof(configurationName));

            using DiagnosticScope scope = _configurationsClientDiagnostics.CreateScope("HDInsightClusterResource.GetConfiguration");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _configurationsRestClient.CreateGetConfigurationByNameRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, configurationName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                using JsonDocument document = JsonDocument.Parse(result.Content);
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                foreach (var property in document.RootElement.EnumerateObject())
                {
                    dictionary[property.Name] = property.Value.GetString();
                }
                return Response.FromValue((IReadOnlyDictionary<string, string>)dictionary, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Configures the HTTP settings on the specified cluster. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="configurationName"> The name of the cluster configuration. </param>
        /// <param name="content"> The cluster configurations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="configurationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="configurationName"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> UpdateConfigurationAsync(WaitUntil waitUntil, string configurationName, IDictionary<string, string> content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(configurationName, nameof(configurationName));
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _configurationsClientDiagnostics.CreateScope("HDInsightClusterResource.UpdateConfiguration");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                using var memoryStream = new System.IO.MemoryStream();
                using (var writer = new Utf8JsonWriter(memoryStream))
                {
                    writer.WriteStartObject();
                    foreach (var kvp in content)
                    {
                        writer.WritePropertyName(kvp.Key);
                        writer.WriteStringValue(kvp.Value);
                    }
                    writer.WriteEndObject();
                }
                memoryStream.Position = 0;
                var requestContent = RequestContent.Create(memoryStream.ToArray());
                HttpMessage message = _configurationsRestClient.CreateUpdateConfigurationRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, configurationName, requestContent, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                HDInsightArmOperation operation = new HDInsightArmOperation(_configurationsClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Configures the HTTP settings on the specified cluster. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="configurationName"> The name of the cluster configuration. </param>
        /// <param name="content"> The cluster configurations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="configurationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="configurationName"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation UpdateConfiguration(WaitUntil waitUntil, string configurationName, IDictionary<string, string> content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(configurationName, nameof(configurationName));
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _configurationsClientDiagnostics.CreateScope("HDInsightClusterResource.UpdateConfiguration");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                using var memoryStream = new System.IO.MemoryStream();
                using (var writer = new Utf8JsonWriter(memoryStream))
                {
                    writer.WriteStartObject();
                    foreach (var kvp in content)
                    {
                        writer.WritePropertyName(kvp.Key);
                        writer.WriteStringValue(kvp.Value);
                    }
                    writer.WriteEndObject();
                }
                memoryStream.Position = 0;
                var requestContent = RequestContent.Create(memoryStream.ToArray());
                HttpMessage message = _configurationsRestClient.CreateUpdateConfigurationRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, configurationName, requestContent, context);
                Response response = Pipeline.ProcessMessage(message, context);
                HDInsightArmOperation operation = new HDInsightArmOperation(_configurationsClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletionResponse(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // VirtualMachine operations

        /// <summary> Restarts the specified HDInsight cluster hosts. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="hosts"> The list of hosts to restart. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="hosts"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> RestartVirtualMachineHostsAsync(WaitUntil waitUntil, IEnumerable<string> hosts, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(hosts, nameof(hosts));

            using DiagnosticScope scope = _virtualMachinesClientDiagnostics.CreateScope("HDInsightClusterResource.RestartVirtualMachineHosts");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                using var memoryStream = new System.IO.MemoryStream();
                using (var writer = new Utf8JsonWriter(memoryStream))
                {
                    writer.WriteStartArray();
                    foreach (var host in hosts)
                    {
                        writer.WriteStringValue(host);
                    }
                    writer.WriteEndArray();
                }
                memoryStream.Position = 0;
                var requestContent = RequestContent.Create(memoryStream.ToArray());
                HttpMessage message = _virtualMachinesRestClient.CreateRestartVirtualMachineHostsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, requestContent, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                HDInsightArmOperation operation = new HDInsightArmOperation(_virtualMachinesClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Restarts the specified HDInsight cluster hosts. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="hosts"> The list of hosts to restart. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="hosts"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation RestartVirtualMachineHosts(WaitUntil waitUntil, IEnumerable<string> hosts, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(hosts, nameof(hosts));

            using DiagnosticScope scope = _virtualMachinesClientDiagnostics.CreateScope("HDInsightClusterResource.RestartVirtualMachineHosts");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                using var memoryStream = new System.IO.MemoryStream();
                using (var writer = new Utf8JsonWriter(memoryStream))
                {
                    writer.WriteStartArray();
                    foreach (var host in hosts)
                    {
                        writer.WriteStringValue(host);
                    }
                    writer.WriteEndArray();
                }
                memoryStream.Position = 0;
                var requestContent = RequestContent.Create(memoryStream.ToArray());
                HttpMessage message = _virtualMachinesRestClient.CreateRestartVirtualMachineHostsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, requestContent, context);
                Response response = Pipeline.ProcessMessage(message, context);
                HDInsightArmOperation operation = new HDInsightArmOperation(_virtualMachinesClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletionResponse(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the async operation status for virtual machine restart. </summary>
        /// <param name="operationId"> The long running operation id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="operationId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<HDInsightAsyncOperationResult>> GetVirtualMachineAsyncOperationStatusAsync(string operationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));

            using DiagnosticScope scope = _virtualMachinesClientDiagnostics.CreateScope("HDInsightClusterResource.GetVirtualMachineAsyncOperationStatus");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _virtualMachinesRestClient.CreateGetVirtualMachineAsyncOperationStatusRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, operationId, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(HDInsightAsyncOperationResult.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the async operation status for virtual machine restart. </summary>
        /// <param name="operationId"> The long running operation id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="operationId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<HDInsightAsyncOperationResult> GetVirtualMachineAsyncOperationStatus(string operationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));

            using DiagnosticScope scope = _virtualMachinesClientDiagnostics.CreateScope("HDInsightClusterResource.GetVirtualMachineAsyncOperationStatus");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _virtualMachinesRestClient.CreateGetVirtualMachineAsyncOperationStatusRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, operationId, context);
                Response result = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(HDInsightAsyncOperationResult.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Cluster async operation status

        /// <summary> The the async operation status. </summary>
        /// <param name="operationId"> The long running operation id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="operationId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<HDInsightAsyncOperationResult>> GetAsyncOperationStatusAsync(string operationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));

            using DiagnosticScope scope = _hdInsightClusterClientDiagnostics.CreateScope("HDInsightClusterResource.GetAsyncOperationStatus");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _hdInsightClusterRestClient.CreateGetClusterAsyncOperationStatusRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, operationId, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(HDInsightAsyncOperationResult.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The the async operation status. </summary>
        /// <param name="operationId"> The long running operation id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="operationId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<HDInsightAsyncOperationResult> GetAsyncOperationStatus(string operationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));

            using DiagnosticScope scope = _hdInsightClusterClientDiagnostics.CreateScope("HDInsightClusterResource.GetAsyncOperationStatus");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _hdInsightClusterRestClient.CreateGetClusterAsyncOperationStatusRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, operationId, context);
                Response result = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(HDInsightAsyncOperationResult.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Script action operations

        /// <summary> Gets the script execution detail for the given script execution ID. </summary>
        /// <param name="scriptExecutionId"> The script execution Id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="scriptExecutionId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="scriptExecutionId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<RuntimeScriptActionDetail>> GetScriptActionExecutionDetailAsync(string scriptExecutionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(scriptExecutionId, nameof(scriptExecutionId));

            using DiagnosticScope scope = _scriptActionsClientDiagnostics.CreateScope("HDInsightClusterResource.GetScriptActionExecutionDetail");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _scriptActionsRestClient.CreateGetScriptActionExecutionDetailRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, scriptExecutionId, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                using JsonDocument document = JsonDocument.Parse(result.Content);
                var value = RuntimeScriptActionDetail.DeserializeRuntimeScriptActionDetail(document.RootElement, ModelSerializationExtensions.WireOptions);
                return Response.FromValue(value, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the script execution detail for the given script execution ID. </summary>
        /// <param name="scriptExecutionId"> The script execution Id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="scriptExecutionId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="scriptExecutionId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<RuntimeScriptActionDetail> GetScriptActionExecutionDetail(string scriptExecutionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(scriptExecutionId, nameof(scriptExecutionId));

            using DiagnosticScope scope = _scriptActionsClientDiagnostics.CreateScope("HDInsightClusterResource.GetScriptActionExecutionDetail");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _scriptActionsRestClient.CreateGetScriptActionExecutionDetailRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, scriptExecutionId, context);
                Response result = Pipeline.ProcessMessage(message, context);
                using JsonDocument document = JsonDocument.Parse(result.Content);
                var value = RuntimeScriptActionDetail.DeserializeRuntimeScriptActionDetail(document.RootElement, ModelSerializationExtensions.WireOptions);
                return Response.FromValue(value, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the async operation status of script execution operation. </summary>
        /// <param name="operationId"> The long running operation id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="operationId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<HDInsightAsyncOperationResult>> GetScriptActionExecutionAsyncOperationStatusAsync(string operationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));

            using DiagnosticScope scope = _scriptActionsClientDiagnostics.CreateScope("HDInsightClusterResource.GetScriptActionExecutionAsyncOperationStatus");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _scriptActionsRestClient.CreateGetScriptActionExecutionAsyncOperationStatusRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, operationId, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(HDInsightAsyncOperationResult.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the async operation status of script execution operation. </summary>
        /// <param name="operationId"> The long running operation id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="operationId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<HDInsightAsyncOperationResult> GetScriptActionExecutionAsyncOperationStatus(string operationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));

            using DiagnosticScope scope = _scriptActionsClientDiagnostics.CreateScope("HDInsightClusterResource.GetScriptActionExecutionAsyncOperationStatus");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _scriptActionsRestClient.CreateGetScriptActionExecutionAsyncOperationStatusRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, operationId, context);
                Response result = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(HDInsightAsyncOperationResult.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Overloads matching the API surface names (Create maps to CreateExtension)

        /// <summary> Creates an HDInsight cluster extension. This is a backward-compatible alias for CreateExtension. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="extensionName"> The name of the cluster extension. </param>
        /// <param name="content"> The cluster extensions create request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="extensionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="extensionName"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> CreateAsync(WaitUntil waitUntil, string extensionName, HDInsightClusterCreateExtensionContent content, CancellationToken cancellationToken = default)
        {
            return await CreateExtensionAsync(waitUntil, extensionName, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Creates an HDInsight cluster extension. This is a backward-compatible alias for CreateExtension. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="extensionName"> The name of the cluster extension. </param>
        /// <param name="content"> The cluster extensions create request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="extensionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="extensionName"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Create(WaitUntil waitUntil, string extensionName, HDInsightClusterCreateExtensionContent content, CancellationToken cancellationToken = default)
        {
            return CreateExtension(waitUntil, extensionName, content, cancellationToken);
        }
    }
}
