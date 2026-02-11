// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.AI.Language.Conversations.Authoring
{
    public partial class ConversationAuthoringDeployment
    {
        /// <summary> Creates a new deployment or replaces an existing one. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="details"> The new deployment info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="details"/> is null. </exception>
        public virtual async Task<Operation> DeployProjectAsync(
            WaitUntil waitUntil,
            ConversationAuthoringCreateDeploymentDetails details,
            CancellationToken cancellationToken = default)
            {
                Argument.AssertNotNull(details, nameof(details));

                using RequestContent content = CreateDeployProjectContent(details);
                RequestContext context = cancellationToken.ToRequestContext();

                return await DeployProjectAsync(waitUntil, content, context).ConfigureAwait(false);
            }

        /// <summary> Creates a new deployment or replaces an existing one. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="details"> The new deployment info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="details"/> is null. </exception>
        public virtual Operation DeployProject(WaitUntil waitUntil, ConversationAuthoringCreateDeploymentDetails details, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(details, nameof(details));

            using RequestContent content = CreateDeployProjectContent(details);
            RequestContext context = cancellationToken.ToRequestContext();
            return DeployProject(waitUntil, content, context);
        }

        private RequestContent CreateDeployProjectContent(ConversationAuthoringCreateDeploymentDetails details)
        {
            // GA 2025-11-01: serialize azureResourceIds as string[]
            if (string.Equals(_apiVersion, "2025-11-01", StringComparison.OrdinalIgnoreCase))
            {
                IList<string> ids = details.AzureResourceIdsStrings ?? GetResourceIdsFromObjects(details.AzureResourceIds);

                var buffer = new ArrayBufferWriter<byte>();
                using (var writer = new Utf8JsonWriter(buffer))
                {
                    writer.WriteStartObject();

                    writer.WriteString("trainedModelLabel", details.TrainedModelLabel);

                    writer.WritePropertyName("azureResourceIds");
                    writer.WriteStartArray();
                    foreach (var id in ids)
                    {
                        writer.WriteStringValue(id);
                    }
                    writer.WriteEndArray();

                    writer.WriteEndObject();
                }

                BinaryData data = new BinaryData(buffer.WrittenMemory);
                return RequestContent.Create(data);
            }

            // Preview 2025-11-15 (and future versions): use generated object shape
            return details;
        }
        private static IList<string> GetResourceIdsFromObjects(
            IList<ConversationAuthoringAssignDeploymentResourcesDetails> resources)
        {
            if (resources is null || resources.Count == 0)
            {
                return Array.Empty<string>();
            }

            var ids = new List<string>(resources.Count);
            foreach (var r in resources)
            {
                if (!string.IsNullOrEmpty(r?.ResourceId))
                {
                    ids.Add(r.ResourceId);
                }
            }

            return ids;
        }
    }
}
