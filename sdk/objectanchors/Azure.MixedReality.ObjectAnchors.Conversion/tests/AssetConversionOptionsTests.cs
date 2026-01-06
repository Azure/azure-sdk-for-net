// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.MixedReality.ObjectAnchors.Conversion.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class AssetConversionOptionsTests : ClientTestBase
    {
        private static string anyWorkingUriString = "https://sampleazurestorageurl.com";

        public AssetConversionOptionsTests(bool isAsync) : base(isAsync)
        {
        }

        public static IEnumerable<object[]> IsNormalizedTestData =>
            new List<object[]>
            {
                new object[] { new Vector3(), false },
                new object[] { new Vector3(1), false },
                new object[] { new Vector3(1, 0, 0), true },
                new object[] { new Vector3(0.7071068f, 0.7071068f, 0), true },
                new object[] { new Vector3(0.5773503f, 0.5773503f, 0.5773503f), true },
            };

        public static IEnumerable<object[]> NullArgumentsFailTestData =>
            new List<object[]>
            {
                new object[] { new Vector3(1, 0, 0), new Uri(anyWorkingUriString), true },
                new object[] { default(Vector3), new Uri(anyWorkingUriString), false },
                new object[] { new Vector3(1, 0, 0), default(Uri), false }
            };

        [Test]
        [TestCaseSource(nameof(IsNormalizedTestData))]
        public void NormalizedVectorRequired(Vector3 v, bool expectedSuccess)
        {
            bool caught = false;
            try
            {
                new AssetConversionOptions(new Uri(anyWorkingUriString), AssetFileType.Ply, v, AssetLengthUnit.Meters);
            }
            catch (ArgumentException)
            {
                caught = true;
            }

            Assert.That(expectedSuccess, Is.Not.EqualTo(caught));
        }

        [Test]
        [TestCaseSource(nameof(NullArgumentsFailTestData))]
        public void NullArgumentsFail(Vector3 v, Uri u, bool expectedSuccess)
        {
            bool caught = false;
            try
            {
                new AssetConversionOptions(u, AssetFileType.Ply, v, AssetLengthUnit.Meters);
            }
            catch (ArgumentException)
            {
                caught = true;
            }

            Assert.That(expectedSuccess, Is.Not.EqualTo(caught));
        }

        [Test]
        public void Vector3StoresValuesCorrectly()
        {
            float x = 0.2672612f;
            float y = 0.5345224f;
            float z = 0.8017837f;
            var config = ObjectAnchorsConversionModelFactory.AssetConversionConfiguration(default, default, new Vector3(x, y, z), default, default, default, 1, false, default, default);
            Assert.Multiple(() =>
            {
                Assert.That(config.Gravity.X, Is.EqualTo(x));
                Assert.That(config.Gravity.Y, Is.EqualTo(y));
                Assert.That(config.Gravity.Z, Is.EqualTo(z));
            });
        }

        [Test]
        public void Vector4StoresValuesCorrectly()
        {
            var gravity = new Vector3(1, 0, 0);
            float x = 1;
            float y = 2;
            float z = 3;
            float w = 4;
            var config = ObjectAnchorsConversionModelFactory.AssetConversionConfiguration(default, default, gravity, default, default, default, 1, false, new Vector4(x, y, z, w), default);
            Assert.Multiple(() =>
            {
                Assert.That(config.SupportingPlane.Value.X, Is.EqualTo(x));
                Assert.That(config.SupportingPlane.Value.Y, Is.EqualTo(y));
                Assert.That(config.SupportingPlane.Value.Z, Is.EqualTo(z));
                Assert.That(config.SupportingPlane.Value.W, Is.EqualTo(w));
            });
        }

        [Test]
        public void QuaternionStoresValuesCorrectly()
        {
            var gravity = new Vector3(1, 0, 0);
            float x = 1;
            float y = 2;
            float z = 3;
            float w = 4;
            var config = ObjectAnchorsConversionModelFactory.AssetConversionConfiguration(default, default, gravity, default, default, new Quaternion(x, y, z, w), 1, false, default, default);
            Assert.Multiple(() =>
            {
                Assert.That(config.PrincipalAxis.Value.X, Is.EqualTo(x));
                Assert.That(config.PrincipalAxis.Value.Y, Is.EqualTo(y));
                Assert.That(config.PrincipalAxis.Value.Z, Is.EqualTo(z));
                Assert.That(config.PrincipalAxis.Value.W, Is.EqualTo(w));
            });
        }
    }
}
