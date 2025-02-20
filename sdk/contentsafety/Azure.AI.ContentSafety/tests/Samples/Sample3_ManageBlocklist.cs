// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentSafety.Tests.Samples
{
    public partial class ContentSafetySamples : SamplesBase<ContentSafetyClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void ManageBlocklist()
        {
            string endpoint = TestEnvironment.Endpoint;
            string key = TestEnvironment.Key;

            ContentSafetyClient contentSafetyClient = new ContentSafetyClient(new Uri(endpoint), new AzureKeyCredential(key));
            BlocklistClient blocklistClient = new BlocklistClient(new Uri(endpoint), new AzureKeyCredential(key));

            #region Snippet:Azure_AI_ContentSafety_CreateNewBlocklist

            var blocklistName = "TestBlocklist";
            var blocklistDescription = "Test blocklist management";

            var data = new
            {
                description = blocklistDescription,
            };

            var createResponse = blocklistClient.CreateOrUpdateTextBlocklist(blocklistName, RequestContent.Create(data));
            if (createResponse.Status == 201)
            {
                Console.WriteLine("\nBlocklist {0} created.", blocklistName);
            }
            else if (createResponse.Status == 200)
            {
                Console.WriteLine("\nBlocklist {0} updated.", blocklistName);
            }

            #endregion Snippet:Azure_AI_ContentSafety_CreateNewBlocklist

            #region Snippet:Azure_AI_ContentSafety_AddBlockItems

            string blockItemText1 = "k*ll";
            string blockItemText2 = "h*te";

            var blockItems = new TextBlocklistItem[] { new TextBlocklistItem(blockItemText1), new TextBlocklistItem(blockItemText2) };
            var addedBlockItems = blocklistClient.AddOrUpdateBlocklistItems(blocklistName, new AddOrUpdateTextBlocklistItemsOptions(blockItems));

            if (addedBlockItems != null && addedBlockItems.Value != null)
            {
                Console.WriteLine("\nBlockItems added:");
                foreach (var addedBlockItem in addedBlockItems.Value.BlocklistItems)
                {
                    Console.WriteLine("BlockItemId: {0}, Text: {1}, Description: {2}", addedBlockItem.BlocklistItemId, addedBlockItem.Text, addedBlockItem.Description);
                }
            }

            #endregion Snippet:Azure_AI_ContentSafety_AddBlockItems

            #region Snippet:Azure_AI_ContentSafety_AnalyzeTextWithBlocklist

            // After you edit your blocklist, it usually takes effect in 5 minutes, please wait some time before analyzing with blocklist after editing.
            var request = new AnalyzeTextOptions("I h*te you and I want to k*ll you");
            request.BlocklistNames.Add(blocklistName);
            request.HaltOnBlocklistHit = true;

            Response<AnalyzeTextResult> response;
            try
            {
                response = contentSafetyClient.AnalyzeText(request);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine("Analyze text failed.\nStatus code: {0}, Error code: {1}, Error message: {2}", ex.Status, ex.ErrorCode, ex.Message);
                throw;
            }

            if (response.Value.BlocklistsMatch != null)
            {
                Console.WriteLine("\nBlocklist match result:");
                foreach (var matchResult in response.Value.BlocklistsMatch)
                {
                    Console.WriteLine("BlocklistName: {0}, BlocklistItemId: {1}, BlocklistText: {2}, ", matchResult.BlocklistName, matchResult.BlocklistItemId, matchResult.BlocklistItemText);
                }
            }

            #endregion Snippet:Azure_AI_ContentSafety_AnalyzeTextWithBlocklist

            #region Snippet:Azure_AI_ContentSafety_ListBlocklists

            var blocklists = blocklistClient.GetTextBlocklists();
            Console.WriteLine("\nList blocklists:");
            foreach (var blocklist in blocklists)
            {
                Console.WriteLine("BlocklistName: {0}, Description: {1}", blocklist.Name, blocklist.Description);
            }

            #endregion Snippet:Azure_AI_ContentSafety_ListBlocklists

            #region Snippet:Azure_AI_ContentSafety_GetBlocklist

            var getBlocklist = blocklistClient.GetTextBlocklist(blocklistName);
            if (getBlocklist != null && getBlocklist.Value != null)
            {
                Console.WriteLine("\nGet blocklist:");
                Console.WriteLine("BlocklistName: {0}, Description: {1}", getBlocklist.Value.Name, getBlocklist.Value.Description);
            }

            #endregion Snippet:Azure_AI_ContentSafety_GetBlocklist

            #region Snippet:Azure_AI_ContentSafety_ListBlockItems

            var allBlockitems = blocklistClient.GetTextBlocklistItems(blocklistName);
            Console.WriteLine("\nList BlockItems:");
            foreach (var blocklistItem in allBlockitems)
            {
                Console.WriteLine("BlocklistItemId: {0}, Text: {1}, Description: {2}", blocklistItem.BlocklistItemId, blocklistItem.Text, blocklistItem.Description);
            }

            #endregion Snippet:Azure_AI_ContentSafety_ListBlockItems

            #region Snippet:Azure_AI_ContentSafety_GetBlockItem

            var getBlockItemId = addedBlockItems.Value.BlocklistItems[0].BlocklistItemId;
            var getBlockItem = blocklistClient.GetTextBlocklistItem(blocklistName, getBlockItemId);
            Console.WriteLine("\nGet BlockItem:");
            Console.WriteLine("BlockItemId: {0}, Text: {1}, Description: {2}", getBlockItem.Value.BlocklistItemId, getBlockItem.Value.Text, getBlockItem.Value.Description);

            #endregion Snippet:Azure_AI_ContentSafety_GetBlockItem

            #region Snippet:Azure_AI_ContentSafety_RemoveBlockItems

            var removeBlockItemId = addedBlockItems.Value.BlocklistItems[0].BlocklistItemId;
            var removeBlockItemIds = new List<string> { removeBlockItemId };
            var removeResult = blocklistClient.RemoveBlocklistItems(blocklistName, new RemoveTextBlocklistItemsOptions(removeBlockItemIds));

            if (removeResult != null && removeResult.Status == 204)
            {
                Console.WriteLine("\nBlockItem removed: {0}.", removeBlockItemId);
            }

            #endregion Snippet:Azure_AI_ContentSafety_RemoveBlockItems

            #region Snippet:Azure_AI_ContentSafety_DeleteBlocklist

            var deleteResult = blocklistClient.DeleteTextBlocklist(blocklistName);
            if (deleteResult != null && deleteResult.Status == 204)
            {
                Console.WriteLine("\nDeleted blocklist.");
            }

            #endregion Snippet:Azure_AI_ContentSafety_DeleteBlocklist
        }
    }
}
