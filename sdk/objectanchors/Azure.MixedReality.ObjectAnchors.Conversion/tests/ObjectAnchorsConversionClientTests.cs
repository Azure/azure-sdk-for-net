// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.MixedReality.ObjectAnchors.Conversion.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class ObjectAnchorsConversionClientTests : ClientTestBase
    {
        private static string anyWorkingUriString = "https://sampleazurestorageurl.com";

        public ObjectAnchorsConversionClientTests(bool isAsync) : base(isAsync)
        {
        }

        public static IEnumerable<object[]> BadClientArgumentsTestData =>
            new List<object[]>
            {
                new object[] {
                    new Guid("43d00847-9b3d-4be4-8bcc-c6a8a3f2e45a"), "eastus2.azure.com",
                    new AccessToken("dummykey", new DateTimeOffset(new DateTime(3000,1,1))),
                    true
                },
                new object[] {
                    new Guid("43d00847-9b3d-4be4-8bcc-c6a8a3f2e45a"), null,
                    new AccessToken("dummykey", new DateTimeOffset(new DateTime(3000,1,1))),
                    false
                }
            };

        public static IEnumerable<object[]> BadFileTypeTestData =>
            new List<object[]>
            {
                new object[]
                {
                    AssetFileType.Obj,
                    true
                },
                new object[]
                {
                    new AssetFileType(".exe"),
                    false
                },
            };

        [Test]
        [TestCaseSource(nameof(BadClientArgumentsTestData))]
        public void BadClientArguments(Guid accountId, string accountDomain, AccessToken credential, bool shouldSucceed)
        {
            bool excepted = false;
            try
            {
                ObjectAnchorsConversionClient client = new ObjectAnchorsConversionClient(accountId, accountDomain, credential);
            }
            catch (ArgumentException)
            {
                excepted = true;
            }

            Assert.AreNotEqual(shouldSucceed, excepted);
        }

        [Test]
        [TestCaseSource(nameof(BadFileTypeTestData))]
        public async Task BadFileType(AssetFileType ft, bool passes)
        {
            bool exceptedWithUnsupportedFileType = !passes;
            try
            {
                ObjectAnchorsConversionClient client = new ObjectAnchorsConversionClient(Guid.NewGuid(), "eastus2.azure.com", new AccessToken("dummykey", new DateTimeOffset(new DateTime(3000, 1, 1))));
                await client.StartAssetConversionAsync(new AssetConversionOptions(new Uri(anyWorkingUriString), new AssetFileType(".exe"), new AssetConversionConfiguration(new System.Numerics.Vector3(0, 0, 1), 1)));
            }
            catch (AssetFileTypeNotSupportedException)
            {
                exceptedWithUnsupportedFileType = true;
            }
            catch (Exception)
            {
                // This is fine
            }

            Assert.True(exceptedWithUnsupportedFileType);
        }
    }
}
