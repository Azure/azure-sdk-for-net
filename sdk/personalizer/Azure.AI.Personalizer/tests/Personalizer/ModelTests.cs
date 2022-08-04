// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.Personalizer.Tests
{
    public class ModelTests : PersonalizerTestBase
    {
        public ModelTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task ModelTest()
        {
            PersonalizerAdministrationClient client = GetAdministrationClient(isSingleSlot: true);
            await ExportModel(false, client);
            await ExportModel(true, client);
            await GetModelProperties(client);
            await ResetModel(client);
        }

        [Test]
        public async Task ExportImportModelTest()
        {
            PersonalizerAdministrationClient client = GetAdministrationClient(isSingleSlot: true);
            Response<Stream> response = await ExportModel(true, client);
            await ImportSignedModel(response.Value, client);
        }

        private async Task<Response<Stream>> ExportModel(bool isSigned, PersonalizerAdministrationClient client)
        {
            return await client.ExportPersonalizerModelAsync(isSigned);
        }

        private async Task<Response> ImportSignedModel(Stream modelBody, PersonalizerAdministrationClient client)
        {
            return await client.ImportPersonalizerSignedModelAsync(modelBody);
        }

        private async Task ResetModel(PersonalizerAdministrationClient client)
        {
            await client.ResetPersonalizerModelAsync();
        }

        private async Task GetModelProperties(PersonalizerAdministrationClient client)
        {
            PersonalizerModelProperties modelProperties = await client.GetPersonalizerModelPropertiesAsync();
            Assert.True(modelProperties.CreationTime != null);
            Assert.True(modelProperties.LastModifiedTime != null);
        }
    }
}
