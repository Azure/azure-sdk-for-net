// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using Azure.Compute.Batch.Tests.Infrastructure;
using Azure.Core;
using Azure.Identity;
using Azure.Core.TestFramework;
using NUnit.Framework;
using static System.Net.WebRequestMethods;
using Azure.ResourceManager;
using Azure.ResourceManager.Batch;

namespace Azure.Compute.Batch.Tests.Snippets
{
    /// <summary>
    ///   Class is used as code base for Sample1_CreatePool_Job_Task
    /// </summary>
    ///
    public class Sample1_CreatePool_Job_Task
    {
        /// <summary>
        ///   Code to create a Batch client contained snippet.
        /// </summary>
        ///
        public void  CreateBatchClient()
        {
            #region Snippet:Batch_Sample01_CreateBatchClient

            var credential = new DefaultAzureCredential();
            BatchClient _batchClient = new BatchClient(
            new Uri("https://examplebatchaccount.eastus.batch.azure.com"), credential);
            #endregion
        }

        /// <summary>
        ///   Code to create a Batch mgmt client contained snippet.
        /// </summary>
        ///
        public async void CreateBatchArmClient()
        {
            #region Snippet:Batch_Sample01_CreateBatchMgmtClient

            var credential = new DefaultAzureCredential();
            ArmClient _armClient = new ArmClient(credential);
            #endregion

            #region Snippet:Batch_Sample01_GetBatchMgmtAccount
            var batchAccountIdentifier = ResourceIdentifier.Parse("your-batch-account-resource-id");
            BatchAccountResource batchAccount = await _armClient.GetBatchAccountResource(batchAccountIdentifier).GetAsync();
            #endregion
        }
    }
}
