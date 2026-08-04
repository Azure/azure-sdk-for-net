// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.CognitiveServices
{
    public partial class RaiBlocklistResource : ArmResource
    {
        /// <summary>
        /// Batch operation to delete blocklist items.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/raiBlocklists/{raiBlocklistName}/deleteRaiBlocklistItems</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RaiBlocklistItems_BatchDelete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="RaiBlocklistItemResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="raiBlocklistItemsNames"> List of RAI Blocklist Items Names. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="raiBlocklistItemsNames"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> BatchDeleteRaiBlocklistItemAsync(BinaryData raiBlocklistItemsNames, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(raiBlocklistItemsNames, nameof(raiBlocklistItemsNames));

            return await BatchDeleteRaiBlocklistItemAsync(ParseRaiBlocklistItemNames(raiBlocklistItemsNames), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Batch operation to delete blocklist items.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/raiBlocklists/{raiBlocklistName}/deleteRaiBlocklistItems</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RaiBlocklistItems_BatchDelete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="RaiBlocklistItemResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="raiBlocklistItemsNames"> List of RAI Blocklist Items Names. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="raiBlocklistItemsNames"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response BatchDeleteRaiBlocklistItem(BinaryData raiBlocklistItemsNames, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(raiBlocklistItemsNames, nameof(raiBlocklistItemsNames));

            return BatchDeleteRaiBlocklistItem(ParseRaiBlocklistItemNames(raiBlocklistItemsNames), cancellationToken);
        }

        private static IEnumerable<string> ParseRaiBlocklistItemNames(BinaryData raiBlocklistItemsNames)
        {
            using JsonDocument document = JsonDocument.Parse(raiBlocklistItemsNames);
            JsonElement root = document.RootElement;
            if (root.ValueKind != JsonValueKind.Array)
            {
                throw new FormatException("The payload must be a JSON array of strings.");
            }

            List<string> names = new List<string>();
            foreach (JsonElement item in root.EnumerateArray())
            {
                if (item.ValueKind == JsonValueKind.Null)
                {
                    names.Add(null);
                    continue;
                }

                if (item.ValueKind != JsonValueKind.String)
                {
                    throw new FormatException("Each blocklist item name in the payload must be a string or null.");
                }

                names.Add(item.GetString());
            }
            return names;
        }
    }
}
