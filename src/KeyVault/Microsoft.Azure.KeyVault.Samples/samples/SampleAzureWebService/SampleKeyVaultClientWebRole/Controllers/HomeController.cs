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

using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using SampleKeyVaultClientWebRole.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace SampleKeyVaultClientWebRole.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index(Message newMessage)
        {
            ModelState.Remove("NewMessage.MessageText");
            var model = new MessageBoardModel();
            try
            {
                model.Trace.Add("");

                //////////////////////////////
                //Trace out the config settings
                //////////////////////////////
                model.Trace.Add("Configuration:");
                model.Trace.Add("\tStorage account name:                              " + CloudConfigurationManager.GetSetting(Constants.StorageAccountNameSetting));
                model.Trace.Add("\tStorage account key (URL to the Key Vault secret): " + CloudConfigurationManager.GetSetting(Constants.StorageAccountKeySecretUrlSetting));
                model.Trace.Add("\tKey Vault client ID:                               " + CloudConfigurationManager.GetSetting(Constants.KeyVaultAuthClientIdSetting));
                model.Trace.Add("\tKey Vault authentication certificate:              " + CloudConfigurationManager.GetSetting(Constants.KeyVaultAuthCertThumbprintSetting) + "\n\n");

                //////////////////////////////
                //Load the auth cert
                //////////////////////////////
                model.Trace.Add("Processing: Finding Key Vault authentication certificate");
                var cert = CertificateHelper.FindCertificateByThumbprint(CloudConfigurationManager.GetSetting(Constants.KeyVaultAuthCertThumbprintSetting));
                if (cert == null)
                {
                    model.Trace.Add("\tCould not find the certificate in the Local Machine's Personal certificate store.");
                    model.Trace.Add("\tTo import a certificate: right-click on the certificate, click Install Certificate, set Store Location to 'Local Machine', set Certificate store to 'Personal', and click finish.");
                    model.Trace.Add("\tDid you get the right thumbprint from your Operator? A certificate thumbprint can be found in the 'Details' tab of a certificate and should be added to the service configuration.");
                    model.Trace.Add("\tDid your Operator upload the certificate to the Azure portal for this service?");
                    return View(model);
                }
                model.Trace.Add("\tSuccess!\n");

                //////////////////////////////
                //Get the secret from Key Vault
                //////////////////////////////
                model.Trace.Add("Processing: Calling Key Vault Service to get storage account key");
                string storageAccountKey = "";
                try
                {
                    storageAccountKey = await KeyVaultAccessor.GetSecret(CloudConfigurationManager.GetSetting(Constants.StorageAccountKeySecretUrlSetting));
                }
                catch
                {
                    model.Trace.Add("\tCould not get the secret from Key Vault.");
                    model.Trace.Add("\tDid you get the right client ID?");
                    model.Trace.Add("\tDid you get the correct secret URI?");
                    model.Trace.Add("\tDid your Operator actually add the storage account key to Key Vault?");
                    throw;
                }
                model.Trace.Add("\tSuccess!\n");

                //////////////////////////////
                //Use the secret to connect to storage
                //////////////////////////////
                model.Trace.Add("Processing: Connecting to Azure Storage using the storage account key");
                StorageTableAccessor storageTable;
                try
                {
                    var storageCred = new StorageCredentials(CloudConfigurationManager.GetSetting(Constants.StorageAccountNameSetting), storageAccountKey);
                    var storageAccount = new CloudStorageAccount(storageCred, false);
                    storageTable = new StorageTableAccessor(storageAccount);
                }
                catch
                {
                    model.Trace.Add("\tCould not connect to Azure Storage.");
                    model.Trace.Add("\tDid you get the right secret URI?");
                    model.Trace.Add("\tDid your Operator add the right secret to Key Vault?");
                    model.Trace.Add("\tDid your Operator change the storage account key after saving it in Key Vault?");
                    throw;
                }
                model.Trace.Add("\tSuccess!\n");

                //////////////////////////////
                //Do something useful with storage
                //////////////////////////////
                if (newMessage != null && !string.IsNullOrWhiteSpace(newMessage.UserName) && !string.IsNullOrWhiteSpace(newMessage.MessageText))
                {
                    model.Trace.Add("Processing: Save a new message to the storage table");
                    storageTable.AddEntry(newMessage);
                    model.Trace.Add("\tSuccess!\n");
                }

                model.Trace.Add("Processing: Retrieving recent messages from the storage table");
                model.RecentMessages = new List<Message>(storageTable.GetRecentEntries());
                model.Trace.Add("\tSuccess!\n");

                model.Trace[0] = "Everything is working great :). Scroll down for details!\n";
            }
            catch(Exception e)
            {
                model.Trace[0] = "Hmm...something went wrong :(. Scroll down for details!\n";
                model.Trace.Add("\n\nError details:\n" + e.ToString());
            }
            return View(model);
        }
    }
}