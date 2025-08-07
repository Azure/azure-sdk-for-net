// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using NUnit.Framework;

namespace System.ClientModel.SourceGeneration.Tests
{
    internal class ModelReaderWriterContextTests
    {
        [Test]
        public void JsonModelIsPresent()
        {
            var modelInfo = BasicContext.Default.GetTypeBuilder(typeof(JsonModel));
            Assert.IsNotNull(modelInfo);
            JsonModel? model = InvokeCreateObject(modelInfo) as JsonModel;
            Assert.IsNotNull(model);
            var ex = Assert.Throws<InvalidOperationException>(() => BasicContext.Default.GetTypeBuilder(typeof(string)));
            Assert.IsNotNull(ex);
            Assert.AreEqual("No ModelReaderWriterTypeBuilder found for String.  See 'https://aka.ms/no-modelreaderwritertypebuilder-found' for more info.", ex!.Message);
        }

        [Test]
        public void PersistableModelIsPresent()
        {
            var modelInfo = BasicContext.Default.GetTypeBuilder(typeof(PersistableModel));
            Assert.IsNotNull(modelInfo);
            PersistableModel? model = InvokeCreateObject(modelInfo) as PersistableModel;
            Assert.IsNotNull(model);
            var ex = Assert.Throws<InvalidOperationException>(() => BasicContext.Default.GetTypeBuilder(typeof(string)));
            Assert.IsNotNull(ex);
            Assert.AreEqual("No ModelReaderWriterTypeBuilder found for String.  See 'https://aka.ms/no-modelreaderwritertypebuilder-found' for more info.", ex!.Message);
        }

        [Test]
        public void ReadOnlyJsonModelIsPresent()
        {
            var modelInfo = BasicContext.Default.GetTypeBuilder(typeof(ReadOnlyMemory<JsonModel>));
            Assert.IsNotNull(modelInfo);
            List<JsonModel>? model = InvokeCreateInstance(modelInfo) as List<JsonModel>;
            Assert.IsNotNull(model);
        }

        private object? InvokeCreateObject(ModelReaderWriterTypeBuilder modelInfo)
        {
            var method = modelInfo.GetType().GetMethod("CreateObject", Reflection.BindingFlags.NonPublic | Reflection.BindingFlags.Instance);
            return method!.Invoke(modelInfo, null);
        }

        private object? InvokeCreateInstance(ModelReaderWriterTypeBuilder modelInfo)
        {
            var method = modelInfo.GetType().GetMethod("CreateInstance", Reflection.BindingFlags.NonPublic | Reflection.BindingFlags.Instance);
            return method!.Invoke(modelInfo, null);
        }
    }
}
