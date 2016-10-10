// 
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using SampleKeyVaultClientWebRole.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Threading.Tasks;
using SampleKeyVaultConfigurationManager;

namespace SampleKeyVaultClientWebRole.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index(Message newMessage)
        { 
            ModelState.Remove("NewMessage.MessageText");
            var model = new MessageBoardModel();
            ModelTrace = model.Trace;
            ModelTrace.Add("");

            try
            {
                await PrintServiceConfigurationSettingsAsync().ConfigureAwait(false);

                StorageTableAccessor storageTable;
               
                // 1. Get the storage secret from Key Vault
                var storageAccountKey = await GetStorageAccountKeyAsync().ConfigureAwait(false);

                // 2. Use the secret to connect to storage
                storageTable = await GetStorageTableAsync(storageAccountKey).ConfigureAwait(false);

                if (storageTable != null)
                {
                    // 3. Store the data in the storage if new message is available
                    StoreUserDataInStorage(storageTable, newMessage);

                    // 4. Load data from the storage
                    model.RecentMessages = GetMessagesFromStorage(storageTable);

                    ModelTrace[0] = "Everything is working great :). Scroll down for details!\n";
                }
            }
            catch(Exception e)
            {
                ModelTrace[0] = "Hmm...something went wrong :(. Scroll down for details!\n";
                ModelTrace.Add("\n\nError details:\n" + e.ToString());
                if(e.InnerException != null)
                {
                    ModelTrace.Add("\n\nError details:\n" + e.InnerException.ToString());
                }
            }
            return View(model);
        }

        /// <summary>
        /// Gets all the service configurations and make sure all is set
        /// </summary>
        private async Task PrintServiceConfigurationSettingsAsync()
        {
            ModelTrace.Add("Configuration:");
            ModelTrace.Add("\tStorage account name:                              " + await ConfigurationManager.GetSettingAsync(Constants.StorageAccountNameSetting).ConfigureAwait(false));
            ModelTrace.Add("\tSecret cache duration:                             " + await ConfigurationManager.GetSettingAsync(Constants.KeyVaultSecretCacheDefaultTimeSpan).ConfigureAwait(false));
            ModelTrace.Add("\tKey Vault client ID:                               " + await ConfigurationManager.GetSettingAsync(Constants.KeyVaultAuthClientIdSetting).ConfigureAwait(false));
            ModelTrace.Add("\tKey Vault authentication certificate:              " + await ConfigurationManager.GetSettingAsync(Constants.KeyVaultAuthCertThumbprintSetting).ConfigureAwait(false) + "\n\n");

            if (   string.IsNullOrWhiteSpace(await ConfigurationManager.GetSettingAsync(Constants.StorageAccountNameSetting).ConfigureAwait(false)) 
                || string.IsNullOrWhiteSpace(await ConfigurationManager.GetSettingAsync(Constants.StorageAccountKeySecretUrlSetting).ConfigureAwait(false))
                || string.IsNullOrWhiteSpace(await ConfigurationManager.GetSettingAsync(Constants.KeyVaultAuthClientIdSetting).ConfigureAwait(false))
                || string.IsNullOrWhiteSpace(await ConfigurationManager.GetSettingAsync(Constants.KeyVaultAuthCertThumbprintSetting).ConfigureAwait(false))
                || string.IsNullOrWhiteSpace(await ConfigurationManager.GetSettingAsync(Constants.KeyVaultSecretCacheDefaultTimeSpan).ConfigureAwait(false)))
            {
                throw new Exception("Service configuration settings cannot be loaded or is not properly set.");
            }
        }

        /// <summary>
        /// Gets the storage account key from key vault secret URL
        /// </summary>
        /// <returns></returns>
        private async Task<string> GetStorageAccountKeyAsync()
        {
            ModelTrace.Add("Processing: Calling Key Vault Service to get storage account key");
            try
            {
                // Get secret from configuration manager 
                var storageAccountKey = await ConfigurationManager.GetSettingAsync(
                    Constants.StorageAccountKeySecretUrlSetting).ConfigureAwait(false);

                ModelTrace.Add("\tSuccess!\n");
                return storageAccountKey;
            }
            catch (Exception ex)
            {
                ModelTrace.Add(string.Format("\tOperation failed to retrieve secret {0} with error: {1}", 
                    ConfigurationManager.GetSettingAsync(Constants.StorageAccountKeySecretUrlSetting).ConfigureAwait(false), ex.Message));
                ModelTrace.Add("\tDid you get the right client ID?");
                ModelTrace.Add("\tDid you get the correct secret URI?");
                ModelTrace.Add("\tDid your Operator actually add the storage account key to Key Vault?");
                throw;
            }
        }

        private async Task<StorageTableAccessor> GetStorageTableAsync(string storageAccountKey)
        {
            ModelTrace.Add("Processing: Connecting to Azure Storage using the storage account key");
            try
            {
                var storageAccountName = await ConfigurationManager.GetSettingAsync(Constants.StorageAccountNameSetting).ConfigureAwait(false);
                var storageCred = new StorageCredentials(storageAccountName, storageAccountKey);
                var storageAccount = new CloudStorageAccount(storageCred, false);
                var storageTableAccessor = new StorageTableAccessor(storageAccount);
                ModelTrace.Add("\tSuccess!\n");
                return storageTableAccessor;
            }
            catch (Exception ex)
            {
                ModelTrace.Add(string.Format("\tCould not connect to Azure Storage. Error: {0}", ex.Message));
                ModelTrace.Add("\tDid you get the right secret URI?");
                ModelTrace.Add("\tDid your Operator add the right secret to Key Vault?");
                ModelTrace.Add("\tDid your Operator change the storage account key after saving it in Key Vault?");
                throw;
            }
        }

        private void StoreUserDataInStorage(StorageTableAccessor storageTable, Message newMessage)
        {
            if (newMessage != null && !string.IsNullOrWhiteSpace(newMessage.UserName) && !string.IsNullOrWhiteSpace(newMessage.MessageText))
            {
                ModelTrace.Add("Processing: Save a new message to the storage table");
                storageTable.AddEntry(newMessage);
                ModelTrace.Add("\tSuccess!\n");
            }
        }

        private List<Message> GetMessagesFromStorage(StorageTableAccessor storageTable)
        {
            ModelTrace.Add("Processing: Retrieving recent messages from the storage table");
            var recentMessages = new List<Message>(storageTable.GetRecentEntries());
            ModelTrace.Add("\tSuccess!\n");

            return recentMessages;
        }
        
        private List<string> ModelTrace { get; set; }
    }
}