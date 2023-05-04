// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using Azure.Core.TestFramework;
using NUnit.Framework;
using static System.Net.Mime.MediaTypeNames;

namespace Azure.AI.ContentSafety.Tests.Samples
{
    public partial class ContentSafetySamples : SamplesBase<ContentSafetyClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void ManageBlocklist()
        {
            #region Snippet:CreateContentSafetyClient

            string endpoint = TestEnvironment.Endpoint;
            string key = TestEnvironment.Key;

            ContentSafetyClient client = new ContentSafetyClient(new Uri(endpoint), new AzureKeyCredential(key));

            #endregion

            #region Snippet:ListBlocklists

            var blocklists = client.GetTextBlocklists();
            Console.WriteLine("\nMy blocklists:");
            foreach (var blocklist in blocklists)
            {
                Console.WriteLine(String.Format("BlocklistName: {0}, Description: {1}", blocklist.BlocklistName, blocklist.Description));
            }
            #endregion

            #region Snippet:CreateNewBlocklist

            var blocklistName = "TestBlocklist";
            var blocklistDescription = "Test blocklist management";

            client.CreateOrUpdateTextBlocklist(blocklistName, blocklistDescription);

            #endregion

            #region Snippet:GetBlocklist

            var newBlocklist = client.GetTextBlocklist(blocklistName);
            if (newBlocklist != null && newBlocklist.Value != null)
            {
                Console.WriteLine("\nBlocklist created:");
                Console.WriteLine(String.Format("BlocklistName: {0}, Description: {1}", newBlocklist.Value.BlocklistName, newBlocklist.Value.Description));
            }

            #endregion

            #region Snippet:AddBlockItems

            string blockItemText1 = "k*ll";
            string blockItemText2 = "h*te";

            var blockItems = new TextBlockItemInfo[] { new TextBlockItemInfo(blockItemText1), new TextBlockItemInfo(blockItemText2) };
            var addedBlockItems = client.AddBlockItems(blocklistName, new AddBlockItemsOptions(blockItems));

            if (addedBlockItems != null && addedBlockItems.Value != null)
            {
                Console.WriteLine("\nBlockItems added:");
                foreach (var addedBlockItem in addedBlockItems.Value.Value)
                {
                    {
                        Console.WriteLine(String.Format("BlockItemId: {0}, Text: {1}, Description: {2}", addedBlockItem.BlockItemId, addedBlockItem.Text, addedBlockItem.Description));
                    }
                }
            }

                #endregion

            #region Snippet:RemoveBlockItems

            var removeBlockItemId = addedBlockItems.Value.Value[1].BlockItemId;
            var removeBlockItemIds = new List<string> { removeBlockItemId };
            var removeResult = client.RemoveBlockItems(blocklistName, new RemoveBlockItemsOptions(removeBlockItemIds));

            if (removeResult != null && removeResult.Status == 204)
            {
                Console.WriteLine(String.Format("\nBlockItem {0} removed.", removeBlockItemId));
            }

            #endregion

            #region Snippet: ListBlockItems

            var remainingBlockItems = client.GetTextBlocklistItems(blocklistName);
            Console.WriteLine("\nList BlockItems:");
            foreach (var blocklistItem in remainingBlockItems)
            {
                Console.WriteLine(String.Format("BlockItemId: {0}, Text: {1}, Description: {2}", blocklistItem.BlockItemId, blocklistItem.Text, blocklistItem.Description));
            }

            #endregion

            #region Snippet:AnalyzeTextWithBlocklist
            Thread.Sleep(30000);
            var request = new AnalyzeTextOptions("I h*te you and I want to k*ll you");
            request.BlocklistNames.Add(blocklistName);
            request.BreakByBlocklists = true;
            Response<AnalyzeTextResult> response;
            try
            {
                response = client.AnalyzeText(request);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(String.Format("Analyze text failed: {0}", ex.Message));
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Analyze text error: {0}", ex.Message));
                throw;
            }

            if (response.Value.BlocklistsMatchResults != null)
            {
                Console.WriteLine("\nMatched Blocklist:");
                foreach (var matchResult in response.Value.BlocklistsMatchResults)
                {
                    Console.WriteLine(String.Format("BlocklistName: {0}, BlockItemId: {1}, BlockItemText: {2}, Offset: {3}, Length: {4}", matchResult.BlocklistName, matchResult.BlockItemId, matchResult.BlockItemText, matchResult.Offset, matchResult.Length));
                }
            }

            #endregion

            #region Snippet:DeleteBlocklist

            var deleteResult = client.DeleteTextBlocklist(blocklistName);
            if (deleteResult != null && deleteResult.Status == 204)
            {
                Console.WriteLine("\n Delete blocklist succeded.");
            }

            #endregion
        }
    }
}
