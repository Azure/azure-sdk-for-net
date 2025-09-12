// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
#if SOURCE_GENERATOR
using System.ClientModel.SourceGeneration.Tests;
#else
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
#endif
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.BaseModels
{
    internal static class ModelInstances
    {
        internal static readonly ModelX s_modelX = CreateModelX();
        internal static readonly ModelY s_modelY = CreateModelY();
        internal static readonly BaseModel s_modelZ = CreateModelZ();

        internal static void CompareModelX(ModelX expected, ModelX actual, string format)
        {
            var expectedRawData = GetRawData(expected);
            var actualRawData = GetRawData(actual);

            Assert.AreEqual(expected.Name!, actual.Name!);
            Assert.AreEqual(expected.Kind!, actual.Kind!);
            Assert.AreEqual(expected.Fields, actual.Fields);
            Assert.AreEqual(expected.KeyValuePairs, actual.KeyValuePairs);
            if (format == "J")
            {
                Assert.AreEqual(expected.XProperty, actual.XProperty);
                Assert.AreEqual(expectedRawData.Count, actualRawData.Count);
                foreach (var key in expectedRawData.Keys)
                {
                    Assert.IsTrue(actualRawData.ContainsKey(key));
                    Assert.IsTrue(expectedRawData[key].ToMemory().Span.SequenceEqual(actualRawData[key].ToMemory().Span));
                }
            }
            else
            {
                Assert.AreEqual(0, actual.XProperty);
                Assert.AreEqual(0, actualRawData.Count);
            }
        }

        internal static void CompareModelY(ModelY expected, ModelY actual, string format)
        {
            var expectedRawData = GetRawData(expected);
            var actualRawData = GetRawData(actual);

            Assert.AreEqual(expected.Name!, actual.Name!);
            Assert.AreEqual(expected.Kind!, actual.Kind!);
            if (format == "J")
            {
                Assert.AreEqual(expected.YProperty!, actual.YProperty!);
                Assert.AreEqual(expectedRawData.Count, actualRawData.Count);
                foreach (var key in expectedRawData.Keys)
                {
                    Assert.IsTrue(actualRawData.ContainsKey(key));
                    Assert.IsTrue(expectedRawData[key].ToMemory().Span.SequenceEqual(actualRawData[key].ToMemory().Span));
                }
            }
            else
            {
                Assert.IsNull(actual.YProperty);
                Assert.AreEqual(0, actualRawData.Count);
            }
        }

        internal static void CompareModelZ(BaseModel expected, BaseModel actual, string format)
        {
            var expectedRawData = GetRawData(expected);
            var actualRawData = GetRawData(actual);

            Assert.AreEqual("UnknownBaseModel", actual.GetType().Name);

            Assert.AreEqual(expected.Name!, actual.Name!);
            Assert.AreEqual(expected.Kind!, actual.Kind!);
            if (format == "J")
            {
                Assert.AreEqual(expectedRawData.Count, actualRawData.Count);
                foreach (var key in expectedRawData.Keys)
                {
                    Assert.IsTrue(actualRawData.ContainsKey(key));
                    Assert.IsTrue(expectedRawData[key].ToMemory().Span.SequenceEqual(actualRawData[key].ToMemory().Span));
                }
            }
            else
            {
                Assert.AreEqual(0, actualRawData.Count);
            }
        }

        private static ModelX CreateModelX()
        {
            var x = new ModelX()
            {
                Name = "xModel",
                Fields = { "testField" },
                KeyValuePairs = { { "color", "red" } },
            };
            x.GetType()
                .GetField("<XProperty>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance)!
                .SetValue(x, 100);
            SetRawData(x, new Dictionary<string, BinaryData> { { "extraX", BinaryData.FromString("\"stuff\"") } });
            return x;
        }

        private static ModelY CreateModelY()
        {
            var y = new ModelY()
            {
                Name = "yModel",
            };
            y.GetType()
                .GetProperty("YProperty")!
                .SetValue(y, "200");
            SetRawData(y, new Dictionary<string, BinaryData> { { "extraY", BinaryData.FromString("\"stuff\"") } });
            return y;
        }

        private static BaseModel CreateModelZ()
        {
            var proxy = typeof(BaseModel).GetCustomAttribute<PersistableModelProxyAttribute>()!.ProxyType;
            var z = (BaseModel)Activator.CreateInstance(proxy)!;
            z.Name = "zModel";
            z.GetType()
                .GetProperty("Kind")!
                .SetValue(z, "Z");
            SetRawData(z, new Dictionary<string, BinaryData> { { "extraZ", BinaryData.FromString("\"stuff\"") } });
            return z;
        }

        private static void SetRawData(object obj, Dictionary<string, BinaryData> rawData)
        {
            obj.GetType().BaseType!
                .GetField("_serializedAdditionalRawData", BindingFlags.Instance | BindingFlags.NonPublic)!
                .SetValue(obj, rawData);
        }

        private static Dictionary<string, BinaryData> GetRawData(object obj)
        {
            return (Dictionary<string, BinaryData>)obj.GetType().BaseType!
                .GetField("_serializedAdditionalRawData", BindingFlags.Instance | BindingFlags.NonPublic)!
                .GetValue(obj)!;
        }
    }
}
