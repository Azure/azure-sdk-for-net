using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Purview.DataMap.Samples
{
    public partial class Samples_TypeDefinition
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetTypeByNameAsync()
        {
            Uri endpoint = new Uri("<https://accountName.purview.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            DataMapClient dataMapClient = new DataMapClient(endpoint, credential);

            #region Snippet:DataMapGetTypeByNameAsync
            TypeDefinition client = dataMapClient.GetTypeDefinitionClient();
            var response = await client.GetByNameAsync("<name>", null);
            #endregion
        }
    }
}
