// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Tests.ModelReaderWriterTests.Models;
using NUnit.Framework;

namespace System.Net.ClientModel.Tests.ModelReaderWriterTests
{
    internal class VerifyModels
    {
        public static void CheckAnimals(Animal x, Animal y, ModelReaderWriterOptions options)
        {
            VerifyProperties(x, y, options);
        }

        private static void VerifyProperties(Animal x, Animal y, ModelReaderWriterOptions options)
        {
            if (options.Format == ModelReaderWriterFormat.Json)
                Assert.That(x.LatinName, Is.EqualTo(y.LatinName));
            Assert.That(x.Name, Is.EqualTo(y.Name));
            Assert.That(x.Weight, Is.EqualTo(y.Weight));

            if (options.Format == ModelReaderWriterFormat.Json)
            {
                var additionalPropertiesX = ModelTests<Animal>.GetRawData(x);
                var additionalPropertiesY = ModelTests<Animal>.GetRawData(y);

                Assert.AreEqual(additionalPropertiesX.Count, additionalPropertiesY.Count);

                foreach (var additionalProperty in additionalPropertiesX)
                {
                    Assert.IsTrue(additionalPropertiesY.ContainsKey(additionalProperty.Key));
                    Assert.AreEqual(additionalProperty.Value.ToString(), additionalPropertiesY[additionalProperty.Key].ToString());
                }
                foreach (var additionalProperty in additionalPropertiesY)
                {
                    Assert.IsTrue(additionalPropertiesX.ContainsKey(additionalProperty.Key));
                    Assert.AreEqual(additionalProperty.Value.ToString(), additionalPropertiesX[additionalProperty.Key].ToString());
                }
            }
        }

        public static void CheckCats(CatReadOnlyProperty x, CatReadOnlyProperty y, ModelReaderWriterOptions options)
        {
            VerifyProperties(x, y, options);
            Assert.That(x.HasWhiskers, Is.EqualTo(y.HasWhiskers));
        }

        public static void CheckDogs(DogListProperty x, DogListProperty y, ModelReaderWriterOptions options)
        {
            VerifyProperties(x, y, options);
            Assert.That(x.FoodConsumed, Is.EqualTo(y.FoodConsumed));
        }

        public static string NormalizeNewLines(string value)
        {
            return value
                .Replace("\r\n", "\n")
                .Replace("\n", Environment.NewLine);
        }
    }
}
