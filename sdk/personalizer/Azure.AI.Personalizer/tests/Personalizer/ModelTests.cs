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
        public async Task GetModel()
        {
            PersonalizerAdministrationClient client = GetPersonalizerAdministrationClient();
            Stream stream = await client.GetPersonalizerModelAsync();
            Assert.AreNotEqual(-1 , stream.ReadByte());
        }

        [Test]
        public async Task ResetModel()
        {
            PersonalizerAdministrationClient client = GetPersonalizerAdministrationClient();
            await client.ResetPersonalizerModelAsync();
        }

        [Test]
        public async Task GetModelProperties()
        {
            PersonalizerAdministrationClient client = GetPersonalizerAdministrationClient();
            PersonalizerModelProperties modelProperties = await client.GetPersonalizerModelPropertiesAsync();
            Assert.True(modelProperties.CreationTime != null);
            Assert.True(modelProperties.LastModifiedTime != null);
        }
    }
}
