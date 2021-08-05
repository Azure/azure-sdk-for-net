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
            await GetModel(client);
            await GetModelProperties(client);
            await ResetModel(client);
        }

        private async Task GetModel(PersonalizerAdministrationClient client)
        {
            await client.GetPersonalizerModelAsync();
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
