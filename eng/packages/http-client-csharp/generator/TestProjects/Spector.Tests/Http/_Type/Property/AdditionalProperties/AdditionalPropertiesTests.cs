// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using _Type.Property.AdditionalProperties;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http._Type.Property.AdditionalProperties
{
    internal class AdditionalPropertiesTests : SpectorTestBase
    {
        [SpectorTest]
        public Task ExtendsFloatGet() => Test(async (host) =>
        {
            var client = new AdditionalPropertiesClient(host, null);
            var response = await client.GetExtendsFloatClient().GetAsync();
            var value = response.Value;
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(43.125f, value.Id);
            CollectionAssert.AreEquivalent(new Dictionary<string, float>
            {
                ["prop"] = 43.125f,
            }, value.AdditionalProperties);
        });

        [SpectorTest]
        public Task ExtendsFloatPut() => Test(async (host) =>
        {
            var value = new ExtendsFloatAdditionalProperties(43.125f)
            {
                AdditionalProperties =
                {
                    ["prop"] = 43.125f
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsFloatClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task IsFloatGet() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetIsFloatClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            var value = response.Value;
            Assert.AreEqual(43.125f, value.Id);
            CollectionAssert.AreEquivalent(new Dictionary<string, float>
            {
                ["prop"] = 43.125f,
            }, value.AdditionalProperties);
        });

        [SpectorTest]
        public Task IsFloatPut() => Test(async (host) =>
        {
            var value = new IsFloatAdditionalProperties(43.125f)
            {
                AdditionalProperties =
                {
                    ["prop"] = 43.125f
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetIsFloatClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ExtendsModelGet() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsModelClient().GetAsync();
            var value = response.Value;
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, value.AdditionalProperties.Count);
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop"));
            var model = ModelReaderWriter.Read<ModelForRecord>(value.AdditionalProperties["prop"]);
            Assert.AreEqual("ok", model!.State);
        });

        [SpectorTest]
        public Task ExtendsModelPut() => Test(async (host) =>
        {
            var value = new ExtendsModelAdditionalProperties(new ModelForRecord("ok"))
            {
                AdditionalProperties =
                {
                    ["prop"] = ModelReaderWriter.Write(new ModelForRecord("ok"))
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsModelClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task IsModelGet() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetIsModelClient().GetAsync();
            var value = response.Value;
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, value.AdditionalProperties.Count);
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop"));
            var model = ModelReaderWriter.Read<ModelForRecord>(value.AdditionalProperties["prop"]);
            Assert.AreEqual("ok", model!.State);
        });

        [SpectorTest]
        public Task IsModelPut() => Test(async (host) =>
        {
            var value = new IsModelAdditionalProperties(new ModelForRecord("ok"))
            {
                AdditionalProperties =
                {
                    ["prop"] = ModelReaderWriter.Write(new ModelForRecord("ok"))
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetIsModelClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ExtendsModelArrayGet() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsModelArrayClient().GetAsync();
            var value = response.Value;
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, value.AdditionalProperties.Count);
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop"));
            var prop = value.AdditionalProperties["prop"].Select(item => ModelReaderWriter.Read<ModelForRecord>(item)).ToList();
            Assert.AreEqual(2, prop.Count);
            Assert.AreEqual("ok", prop[0]!.State);
            Assert.AreEqual("ok", prop[1]!.State);
        });

        [SpectorTest]
        public Task ExtendsModelArrayPut() => Test(async (host) =>
        {
            var value = new ExtendsModelArrayAdditionalProperties([new ModelForRecord("ok"), new ModelForRecord("ok")])
            {
                AdditionalProperties =
                {
                    ["prop"] =
                    [
                        ModelReaderWriter.Write(new ModelForRecord("ok")),
                        ModelReaderWriter.Write(new ModelForRecord("ok"))
                    ]
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsModelArrayClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task IsModelArrayGet() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetIsModelArrayClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);

            var value = response.Value;
            Assert.AreEqual(1, value.AdditionalProperties.Count);
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop"));

            var prop = value.AdditionalProperties["prop"].Select(item => ModelReaderWriter.Read<ModelForRecord>(item)).ToList();
            Assert.AreEqual(2, prop.Count);
            Assert.AreEqual("ok", prop[0]!.State);
            Assert.AreEqual("ok", prop[1]!.State);
        });

        [SpectorTest]
        public Task IsModelArrayPut() => Test(async (host) =>
        {
            var value = new IsModelArrayAdditionalProperties(new[] { new ModelForRecord("ok"), new ModelForRecord("ok") })
            {
                AdditionalProperties =
                {
                    ["prop"] = new[]
                    {
                        ModelReaderWriter.Write(new ModelForRecord("ok")),
                        ModelReaderWriter.Write(new ModelForRecord("ok"))
                    }
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetIsModelArrayClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ExtendsStringGet() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsStringClient().GetAsync();
            var value = response.Value;
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("ExtendsStringAdditionalProperties", value.Name);
            CollectionAssert.AreEquivalent(new Dictionary<string, string>
            {
                ["prop"] = "abc"
            }, value.AdditionalProperties);
        });

        [SpectorTest]
        public Task ExtendsStringPut() => Test(async (host) =>
        {
            var value = new ExtendsStringAdditionalProperties("ExtendsStringAdditionalProperties")
            {
                AdditionalProperties =
                {
                    ["prop"] = "abc"
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsStringClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task IsStringGet() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetIsStringClient().GetAsync();
            var value = response.Value;
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("IsStringAdditionalProperties", value.Name);
            CollectionAssert.AreEquivalent(new Dictionary<string, string>
            {
                ["prop"] = "abc"
            }, value.AdditionalProperties);
        });

        [SpectorTest]
        public Task IsStringPut() => Test(async (host) =>
        {
            var value = new IsStringAdditionalProperties("IsStringAdditionalProperties")
            {
                AdditionalProperties =
                {
                    ["prop"] = "abc"
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetIsStringClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ExtendsUnknownGet() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsUnknownClient().GetAsync();
            var value = response.Value;
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("ExtendsUnknownAdditionalProperties", value.Name);
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop1"));
            Assert.AreEqual(32, value.AdditionalProperties["prop1"].ToObjectFromJson<int>());
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop2"));
            Assert.AreEqual(true, value.AdditionalProperties["prop2"].ToObjectFromJson<bool>());
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop3"));
            Assert.AreEqual("abc", value.AdditionalProperties["prop3"].ToObjectFromJson<string>());
        });

        [SpectorTest]
        public Task ExtendsUnknownPut() => Test(async (host) =>
        {
            var value = new ExtendsUnknownAdditionalProperties("ExtendsUnknownAdditionalProperties")
            {
                AdditionalProperties =
                {
                    ["prop1"] = BinaryData.FromObjectAsJson(32),
                    ["prop2"] = BinaryData.FromObjectAsJson(true),
                    ["prop3"] = BinaryData.FromObjectAsJson("abc")
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsUnknownClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ExtendsUnknownDerivedGet() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsUnknownDerivedClient().GetAsync();
            var value = response.Value;
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("ExtendsUnknownAdditionalProperties", value.Name);
            Assert.AreEqual(314, value.Index);
            Assert.AreEqual(2.71875f, value.Age);
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop1"));
            Assert.AreEqual(32, value.AdditionalProperties["prop1"].ToObjectFromJson<int>());
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop2"));
            Assert.AreEqual(true, value.AdditionalProperties["prop2"].ToObjectFromJson<bool>());
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop3"));
            Assert.AreEqual("abc", value.AdditionalProperties["prop3"].ToObjectFromJson<string>());
        });

        [SpectorTest]
        public Task ExtendsUnknownDerivedPut() => Test(async (host) =>
        {
            var value = new ExtendsUnknownAdditionalPropertiesDerived("ExtendsUnknownAdditionalProperties", 314)
            {
                Age = 2.71875f,
                AdditionalProperties =
                {
                    ["prop1"] = BinaryData.FromObjectAsJson(32),
                    ["prop2"] = BinaryData.FromObjectAsJson(true),
                    ["prop3"] = BinaryData.FromObjectAsJson("abc")
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsUnknownDerivedClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ExtendsUnknownDiscriminatedGet() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsUnknownDiscriminatedClient().GetAsync();
            var value = response.Value;
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("Derived", value.Name);
            var kindProperty = value.GetType().GetProperty("Kind", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.AreEqual("derived", kindProperty?.GetValue(value));
            var derived = value as ExtendsUnknownAdditionalPropertiesDiscriminatedDerived;
            Assert.IsNotNull(derived);
            Assert.AreEqual(314, derived!.Index);
            Assert.AreEqual(2.71875f, derived.Age);
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop1"));
            Assert.AreEqual(32, value.AdditionalProperties["prop1"].ToObjectFromJson<int>());
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop2"));
            Assert.AreEqual(true, value.AdditionalProperties["prop2"].ToObjectFromJson<bool>());
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop3"));
            Assert.AreEqual("abc", value.AdditionalProperties["prop3"].ToObjectFromJson<string>());
        });

        [SpectorTest]
        public Task ExtendsUnknownDiscriminatedPut() => Test(async (host) =>
        {
            var value = new ExtendsUnknownAdditionalPropertiesDiscriminatedDerived("Derived", 314)
            {
                Age = 2.71875f,
                AdditionalProperties =
                {
                    ["prop1"] = BinaryData.FromObjectAsJson(32),
                    ["prop2"] = BinaryData.FromObjectAsJson(true),
                    ["prop3"] = BinaryData.FromObjectAsJson("abc")
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsUnknownDiscriminatedClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task IsUnknownGet() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetIsUnknownClient().GetAsync();
            var value = response.Value;
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("IsUnknownAdditionalProperties", value.Name);
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop1"));
            Assert.AreEqual(32, value.AdditionalProperties["prop1"].ToObjectFromJson<int>());
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop2"));
            Assert.AreEqual(true, value.AdditionalProperties["prop2"].ToObjectFromJson<bool>());
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop3"));
            Assert.AreEqual("abc", value.AdditionalProperties["prop3"].ToObjectFromJson<string>());
        });

        [SpectorTest]
        public Task IsUnknownPut() => Test(async (host) =>
        {
            var value = new IsUnknownAdditionalProperties("IsUnknownAdditionalProperties")
            {
                AdditionalProperties =
                {
                    ["prop1"] = BinaryData.FromObjectAsJson(32),
                    ["prop2"] = BinaryData.FromObjectAsJson(true),
                    ["prop3"] = BinaryData.FromObjectAsJson("abc")
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetIsUnknownClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task IsUnknownDerivedGet() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetIsUnknownDerivedClient().GetAsync();
            var value = response.Value;
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("IsUnknownAdditionalProperties", value.Name);
            Assert.AreEqual(314, value.Index);
            Assert.AreEqual(2.71875f, value.Age);
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop1"));
            Assert.AreEqual(32, value.AdditionalProperties["prop1"].ToObjectFromJson<int>());
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop2"));
            Assert.AreEqual(true, value.AdditionalProperties["prop2"].ToObjectFromJson<bool>());
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop3"));
            Assert.AreEqual("abc", value.AdditionalProperties["prop3"].ToObjectFromJson<string>());
        });

        [SpectorTest]
        public Task IsUnknownDerivedPut() => Test(async (host) =>
        {
            var value = new IsUnknownAdditionalPropertiesDerived("IsUnknownAdditionalProperties", 314)
            {
                Age = 2.71875f,
                AdditionalProperties =
                {
                    ["prop1"] = BinaryData.FromObjectAsJson(32),
                    ["prop2"] = BinaryData.FromObjectAsJson(true),
                    ["prop3"] = BinaryData.FromObjectAsJson("abc")
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetIsUnknownDerivedClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task IsUnknownDiscriminatedGet() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetIsUnknownDiscriminatedClient().GetAsync();
            var value = response.Value;
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("Derived", value.Name);
            var kindProperty = value.GetType().GetProperty("Kind", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.AreEqual("derived", kindProperty?.GetValue(value));
            var derived = value as IsUnknownAdditionalPropertiesDiscriminatedDerived;
            Assert.IsNotNull(derived);
            Assert.AreEqual(314, derived!.Index);
            Assert.AreEqual(2.71875f, derived.Age);
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop1"));
            Assert.AreEqual(32, value.AdditionalProperties["prop1"].ToObjectFromJson<int>());
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop2"));
            Assert.AreEqual(true, value.AdditionalProperties["prop2"].ToObjectFromJson<bool>());
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop3"));
            Assert.AreEqual("abc", value.AdditionalProperties["prop3"].ToObjectFromJson<string>());
        });

        [SpectorTest]
        public Task IsUnknownDiscriminatedPut() => Test(async (host) =>
        {
            var value = new IsUnknownAdditionalPropertiesDiscriminatedDerived("Derived", 314)
            {
                Age = 2.71875f,
                AdditionalProperties =
                {
                    ["prop1"] = BinaryData.FromObjectAsJson(32),
                    ["prop2"] = BinaryData.FromObjectAsJson(true),
                    ["prop3"] = BinaryData.FromObjectAsJson("abc")
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetIsUnknownDiscriminatedClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ExtendsDifferentSpreadFloatGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsDifferentSpreadFloatClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("abc", response.Value.Name);
            Assert.AreEqual(43.125f, response.Value.DerivedProp);
            Assert.AreEqual(1, response.Value.AdditionalProperties.Count);
            Assert.AreEqual(43.125f, response.Value.AdditionalProperties["prop"]);
        });

        [SpectorTest]
        public Task ExtendsDifferentSpreadFloatPut() => Test(async host =>
        {
            var value = new DifferentSpreadFloatDerived("abc", 43.125f)
            {
                AdditionalProperties =
                {
                    ["prop"] = 43.125f
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsDifferentSpreadFloatClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ExtendsDifferentSpreadModelGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsDifferentSpreadModelClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("abc", response.Value.KnownProp);
            Assert.IsNotNull(response.Value.DerivedProp);
            Assert.AreEqual("ok", response.Value.DerivedProp.State);
            Assert.AreEqual(1, response.Value.AdditionalProperties.Count);
            var prop = ModelReaderWriter.Read<ModelForRecord>(response.Value.AdditionalProperties["prop"]);
            Assert.AreEqual("ok", prop!.State);
        });

        [SpectorTest]
        public Task ExtendsDifferentSpreadModelPut() => Test(async host =>
        {
            var value = new DifferentSpreadModelDerived("abc", new ModelForRecord("ok"))
            {
                AdditionalProperties =
                {
                    ["prop"] = ModelReaderWriter.Write(new ModelForRecord("ok"))
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsDifferentSpreadModelClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ExtendsDifferentSpreadModelArrayGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsDifferentSpreadModelArrayClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("abc", response.Value.KnownProp);
            Assert.AreEqual(2, response.Value.DerivedProp.Count);
            Assert.AreEqual("ok", response.Value.DerivedProp[0].State);
            Assert.AreEqual("ok", response.Value.DerivedProp[1].State);
            Assert.AreEqual(1, response.Value.AdditionalProperties.Count);
            var list = response.Value.AdditionalProperties["prop"];
            Assert.AreEqual(2, list.Count);
            var prop1 = ModelReaderWriter.Read<ModelForRecord>(list[0]);
            Assert.AreEqual("ok", prop1!.State);
            var prop2 = ModelReaderWriter.Read<ModelForRecord>(list[1]);
            Assert.AreEqual("ok", prop2!.State);
        });

        [SpectorTest]
        public Task ExtendsDifferentSpreadModelArrayPut() => Test(async host =>
        {
            var value = new DifferentSpreadModelArrayDerived("abc", new[] { new ModelForRecord("ok"), new ModelForRecord("ok") })
            {
                AdditionalProperties =
                {
                    ["prop"] = new[] { ModelReaderWriter.Write(new ModelForRecord("ok")), ModelReaderWriter.Write(new ModelForRecord("ok")) }
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsDifferentSpreadModelArrayClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ExtendsDifferentSpreadStringGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsDifferentSpreadStringClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(43.125f, response.Value.Id);
            Assert.AreEqual("abc", response.Value.DerivedProp);
            Assert.AreEqual(1, response.Value.AdditionalProperties.Count);
            Assert.AreEqual("abc", response.Value.AdditionalProperties["prop"]);
        });

        [SpectorTest]
        public Task ExtendsDifferentSpreadStringPut() => Test(async host =>
        {
            var value = new DifferentSpreadStringDerived(43.125f, "abc")
            {
                AdditionalProperties =
                {
                    ["prop"] = "abc"
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsDifferentSpreadStringClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task MultipleSpreadGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetMultipleSpreadClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsTrue(response.Value.Flag);
            Assert.AreEqual(1, response.Value.AdditionalProperties.Count);
            Assert.AreEqual(1, response.Value.AdditionalSingleProperties.Count);
            Assert.AreEqual("abc", response.Value.AdditionalProperties["prop1"]);
            Assert.AreEqual(43.125f, response.Value.AdditionalSingleProperties["prop2"]);
        });

        [SpectorTest]
        public Task MultipleSpreadPut() => Test(async host =>
        {
            var value = new MultipleSpreadRecord(true)
            {
                AdditionalProperties =
                {
                    ["prop1"] = "abc"
                },
                AdditionalSingleProperties =
                {
                    ["prop2"] = 43.125f
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetMultipleSpreadClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task SpreadDifferentFloatGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadDifferentFloatClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("abc", response.Value.Name);
            Assert.AreEqual(1, response.Value.AdditionalProperties.Count);
            Assert.AreEqual(43.125f, response.Value.AdditionalProperties["prop"]);
        });

        [SpectorTest]
        public Task SpreadDifferentFloatPut() => Test(async host =>
        {
            var value = new DifferentSpreadFloatRecord("abc")
            {
                AdditionalProperties =
                {
                    ["prop"] = 43.125f
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadDifferentFloatClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task SpreadDifferentModelGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadDifferentModelClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("abc", response.Value.KnownProp);
            Assert.AreEqual(1, response.Value.AdditionalProperties.Count);
            var model = ModelReaderWriter.Read<ModelForRecord>(response.Value.AdditionalProperties["prop"]);
            Assert.AreEqual("ok", model!.State);
        });

        [SpectorTest]
        public Task SpreadDifferentModelPut() => Test(async host =>
        {
            var value = new DifferentSpreadModelRecord("abc")
            {
                AdditionalProperties =
                {
                    ["prop"] = ModelReaderWriter.Write(new ModelForRecord("ok"))
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadDifferentModelClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task SpreadDifferentModelArrayGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadDifferentModelArrayClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("abc", response.Value.KnownProp);
            Assert.AreEqual(1, response.Value.AdditionalProperties.Count);
            var list = response.Value.AdditionalProperties["prop"];
            Assert.AreEqual(2, list.Count);
            var first = ModelReaderWriter.Read<ModelForRecord>(list[0]);
            var second = ModelReaderWriter.Read<ModelForRecord>(list[1]);
            Assert.AreEqual("ok", first!.State);
            Assert.AreEqual("ok", second!.State);
        });

        [SpectorTest]
        public Task SpreadDifferentModelArrayPut() => Test(async host =>
        {
            var value = new DifferentSpreadModelArrayRecord("abc")
            {
                AdditionalProperties =
                {
                    ["prop"] = new[]
                    {
                        ModelReaderWriter.Write(new ModelForRecord("ok")),
                        ModelReaderWriter.Write(new ModelForRecord("ok"))
                    }
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadDifferentModelArrayClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task SpreadDifferentStringGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadDifferentStringClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(43.125f, response.Value.Id);
            Assert.AreEqual(1, response.Value.AdditionalProperties.Count);
            Assert.AreEqual("abc", response.Value.AdditionalProperties["prop"]);
        });

        [SpectorTest]
        public Task SpreadDifferentStringPut() => Test(async host =>
        {
            var value = new DifferentSpreadStringRecord(43.125f)
            {
                AdditionalProperties =
                {
                    ["prop"] = "abc"
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadDifferentStringClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task SpreadFloatGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadFloatClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(43.125f, response.Value.Id);
            Assert.AreEqual(1, response.Value.AdditionalProperties.Count);
            Assert.AreEqual(43.125f, response.Value.AdditionalProperties["prop"]);
        });

        [SpectorTest]
        public Task SpreadFloatPut() => Test(async host =>
        {
            var value = new SpreadFloatRecord(43.125f)
            {
                AdditionalProperties =
                {
                    ["prop"] = 43.125f
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadFloatClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task SpreadModelGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadModelClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("ok", response.Value.KnownProp.State);
            Assert.AreEqual(1, response.Value.AdditionalProperties.Count);
            var model = ModelReaderWriter.Read<ModelForRecord>(response.Value.AdditionalProperties["prop"]);
            Assert.AreEqual("ok", model!.State);
        });

        [SpectorTest]
        public Task SpreadModelPut() => Test(async host =>
        {
            var value = new SpreadModelRecord(new ModelForRecord("ok"))
            {
                AdditionalProperties =
                {
                    ["prop"] = ModelReaderWriter.Write(new ModelForRecord("ok"))
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadModelClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task SpreadModelArrayGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadModelArrayClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(2, response.Value.KnownProp.Count);
            Assert.AreEqual("ok", response.Value.KnownProp[0].State);
            Assert.AreEqual("ok", response.Value.KnownProp[1].State);
            Assert.AreEqual(1, response.Value.AdditionalProperties.Count);
            var list = response.Value.AdditionalProperties["prop"];
            Assert.AreEqual(2, list.Count);
            var first = ModelReaderWriter.Read<ModelForRecord>(list[0]);
            var second = ModelReaderWriter.Read<ModelForRecord>(list[1]);
            Assert.AreEqual("ok", first!.State);
            Assert.AreEqual("ok", second!.State);
        });

        [SpectorTest]
        public Task SpreadModelArrayPut() => Test(async host =>
        {
            var value = new SpreadModelArrayRecord(new[] { new ModelForRecord("ok"), new ModelForRecord("ok") })
            {
                AdditionalProperties =
                {
                    ["prop"] = new[]
                    {
                        ModelReaderWriter.Write(new ModelForRecord("ok")),
                        ModelReaderWriter.Write(new ModelForRecord("ok"))
                    }
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadModelArrayClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task SpreadRecordNonDiscriminatedUnionGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadRecordNonDiscriminatedUnionClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("abc", response.Value.Name);
            Assert.AreEqual(2, response.Value.AdditionalProperties.Count);
            var prop1 = ModelReaderWriter.Read<WidgetData0>(response.Value.AdditionalProperties["prop1"]);
            Assert.AreEqual("abc", prop1!.FooProp);
            var prop2 = ModelReaderWriter.Read<WidgetData1>(response.Value.AdditionalProperties["prop2"]);
            Assert.AreEqual(new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero), prop2!.Start);
            Assert.AreEqual(new DateTimeOffset(2021, 1, 2, 0, 0, 0, TimeSpan.Zero), prop2.End);
        });

        [SpectorTest]
        public Task SpreadRecordNonDiscriminatedUnionPut() => Test(async host =>
        {
            var value = new SpreadRecordForNonDiscriminatedUnion("abc")
            {
                AdditionalProperties =
                {
                    ["prop1"] = ModelReaderWriter.Write(new WidgetData0("abc")),
                    ["prop2"] = ModelReaderWriter.Write(new WidgetData1(new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero))
                    {
                        End = new DateTimeOffset(2021, 1, 2, 0, 0, 0, TimeSpan.Zero)
                    })
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadRecordNonDiscriminatedUnionClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task SpreadRecordNonDiscriminatedUnion2Get() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadRecordNonDiscriminatedUnion2Client().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("abc", response.Value.Name);
            Assert.AreEqual(2, response.Value.AdditionalProperties.Count);
            var prop1 = ModelReaderWriter.Read<WidgetData2>(response.Value.AdditionalProperties["prop1"]);
            Assert.AreEqual("2021-01-01T00:00:00Z", prop1!.Start);
            var prop2 = ModelReaderWriter.Read<WidgetData1>(response.Value.AdditionalProperties["prop2"]);
            Assert.AreEqual(new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero), prop2!.Start);
            Assert.AreEqual(new DateTimeOffset(2021, 1, 2, 0, 0, 0, TimeSpan.Zero), prop2.End);
        });

        [SpectorTest]
        public Task SpreadRecordNonDiscriminatedUnion2Put() => Test(async host =>
        {
            var value = new SpreadRecordForNonDiscriminatedUnion2("abc")
            {
                AdditionalProperties =
                {
                    ["prop1"] = ModelReaderWriter.Write(new WidgetData2("2021-01-01T00:00:00Z")),
                    ["prop2"] = ModelReaderWriter.Write(new WidgetData1(new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero))
                    {
                        End = new DateTimeOffset(2021, 1, 2, 0, 0, 0, TimeSpan.Zero)
                    })
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadRecordNonDiscriminatedUnion2Client().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task SpreadRecordUnionGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadRecordUnionClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsTrue(response.Value.Flag);
            Assert.AreEqual(1, response.Value.AdditionalProperties.Count);
            Assert.AreEqual(1, response.Value.AdditionalSingleProperties.Count);
            Assert.AreEqual("abc", response.Value.AdditionalProperties["prop1"]);
            Assert.AreEqual(43.125f, response.Value.AdditionalSingleProperties["prop2"]);
        });

        [SpectorTest]
        public Task SpreadRecordUnionPut() => Test(async host =>
        {
            var value = new SpreadRecordForUnion(true)
            {
                AdditionalProperties =
                {
                    ["prop1"] = "abc",
                },
                AdditionalSingleProperties =
                {
                    ["prop2"] = 43.125f
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadRecordUnionClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task SpreadStringGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadStringClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("SpreadSpringRecord", response.Value.Name);
            Assert.AreEqual(1, response.Value.AdditionalProperties.Count);
            Assert.AreEqual("abc", response.Value.AdditionalProperties["prop"]);
        });

        [SpectorTest]
        public Task SpreadStringPut() => Test(async host =>
        {
            var value = new SpreadStringRecord("SpreadSpringRecord")
            {
                AdditionalProperties =
                {
                    ["prop"] = "abc"
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadStringClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

    }
}
