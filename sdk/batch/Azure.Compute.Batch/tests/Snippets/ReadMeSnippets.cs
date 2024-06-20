// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Compute.Batch.Tests.Snippets
{
    public class ReadMeSnippets
    {
        public void AzureNameKeyCredentialSnippet()
        {
            #region Snippet:Batch_Readme_AzureNameKeyCredential
            var credential = new AzureNamedKeyCredential("examplebatchaccount", "BatchAccountKey");
            BatchClient client = new BatchClient(
                new Uri("https://examplebatchaccount.eastus.batch.azure.com"),
                credential);
            #endregion
        }
    }
}
