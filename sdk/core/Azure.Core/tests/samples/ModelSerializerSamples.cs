// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core.Experimental.Tests;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using Azure.Core.Tests.ModelSerializationTests;
using NUnit.Framework;
using Newtonsoft.Json;

namespace Azure.Core.Tests.samples
{
    internal class ModelSerializerSamples
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void NewtonSoftDeserialize()
        {
            #region Snippet:NewtonSoft_Deserialize
            //modelSerializer example
            SerializableOptions options = new SerializableOptions();
            options.Serializer = new NewtonsoftJsonObjectSerializer();

            string json = @"[{""LatinName"":""Animalia"",""Weight"":1.1,""Name"":""Doggo"",""IsHungry"":false,""FoodConsumed"":[""kibble"",""egg"",""peanut butter""],""NumberOfLegs"":4}]";
            DogListProperty dog = ModelSerializer.Deserialize<DogListProperty>(json, options);
            #endregion
        }
    }
}
