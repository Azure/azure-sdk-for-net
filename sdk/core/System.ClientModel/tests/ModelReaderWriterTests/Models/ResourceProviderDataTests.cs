// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client;
using System.ClientModel.Tests.Client.Models.ResourceManager.Resources;
using System.IO;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    internal class ResourceProviderDataTests : ModelJsonTests<ResourceProviderData>
    {
        protected override string JsonPayload => WirePayload;

        protected override string WirePayload => File.ReadAllText(TestData.GetLocation("ResourceProviderData/ResourceProviderData-Collapsed.json")).TrimEnd();

        protected override ModelReaderWriterContext Context => new TestClientModelReaderWriterContext();

        protected override void CompareModels(ResourceProviderData model, ResourceProviderData model2, string format)
        {
            Assert.That(model2.Id, Is.EqualTo(model.Id));
            Assert.That(model2.Namespace, Is.EqualTo(model.Namespace));
            Assert.That(model2.RegistrationState, Is.EqualTo(model.RegistrationState));
            Assert.That(model2.RegistrationPolicy, Is.EqualTo(model.RegistrationPolicy));
            Assert.That(model2.ProviderAuthorizationConsentState, Is.EqualTo(model.ProviderAuthorizationConsentState));
            Assert.That(model2.ResourceTypes.Count, Is.EqualTo(model.ResourceTypes.Count));
        }

        protected override string GetExpectedResult(string format) => WirePayload;

        protected override void VerifyModel(ResourceProviderData model, string format)
        {
            Assert.That(model, Is.Not.Null);
            Assert.That(model.Id, Is.Not.Null);
        }

        [Test]
        public void ValideStjIntegration()
        {
            var stjOptions = new JsonSerializerOptions
            {
                Converters = { new JsonModelConverter() }
            };

            var modelFromStj = JsonSerializer.Deserialize<ResourceProviderData>(WirePayload, stjOptions);
            var modelFromMrw = ModelReaderWriter.Read<ResourceProviderData>(BinaryData.FromString(WirePayload));

            Assert.That(modelFromStj, Is.Not.Null);
            Assert.That(modelFromMrw, Is.Not.Null);

            CompareModels(modelFromStj!, modelFromMrw!, "J");
            var stjResult = JsonSerializer.Serialize(modelFromStj, stjOptions);
            Assert.That(stjResult, Is.EqualTo(WirePayload));
        }

        [Test]
        public void ValidatePrettyPrintWithStj()
        {
            var stjOptions = new JsonSerializerOptions
            {
                Converters = { new JsonModelConverter() },
                WriteIndented = true,
            };

            var modelFromStj = JsonSerializer.Deserialize<ResourceProviderData>(WirePayload, stjOptions);
            var stjResult = JsonSerializer.Serialize(modelFromStj, stjOptions);
            Assert.That(NormalizeLF(stjResult), Is.EqualTo(File.ReadAllText(TestData.GetLocation("ResourceProviderData/ResourceProviderData-TwoSpaces.json")).TrimEnd()));
        }

        [Test]
        public void ValidateCapitalizationIsIgnored()
        {
#if NET8_0_OR_GREATER
            var stjOptions = new JsonSerializerOptions
            {
                Converters = { new JsonModelConverter() },
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.KebabCaseUpper,
            };

            var modelFromStj = JsonSerializer.Deserialize<ResourceProviderData>(WirePayload, stjOptions);
            var stjResult = JsonSerializer.Serialize(modelFromStj, stjOptions);
            Assert.That(NormalizeLF(stjResult), Is.EqualTo(File.ReadAllText(TestData.GetLocation("ResourceProviderData/ResourceProviderData-TwoSpaces.json")).TrimEnd()));
#endif
        }

        private static string NormalizeLF(string s)
            => s.Replace("\r\n", "\n");
    }
}
