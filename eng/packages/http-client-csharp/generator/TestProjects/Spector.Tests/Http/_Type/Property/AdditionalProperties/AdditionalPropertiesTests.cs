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
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(value.Id, Is.EqualTo(43.125f));
            });
            Assert.That(value.AdditionalProperties, Is.EquivalentTo(new Dictionary<string, float>
            {
                ["prop"] = 43.125f,
            }));
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task IsFloatGet() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetIsFloatClient().GetAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            var value = response.Value;
            Assert.That(value.Id, Is.EqualTo(43.125f));
            Assert.That(value.AdditionalProperties, Is.EquivalentTo(new Dictionary<string, float>
            {
                ["prop"] = 43.125f,
            }));
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ExtendsModelGet() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsModelClient().GetAsync();
            var value = response.Value;
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(value.AdditionalProperties.Count, Is.EqualTo(1));
            });
            Assert.That(value.AdditionalProperties.ContainsKey("prop"), Is.True);
            var model = ModelReaderWriter.Read<ModelForRecord>(value.AdditionalProperties["prop"]);
            Assert.That(model!.State, Is.EqualTo("ok"));
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task IsModelGet() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetIsModelClient().GetAsync();
            var value = response.Value;
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(value.AdditionalProperties.Count, Is.EqualTo(1));
            });
            Assert.That(value.AdditionalProperties.ContainsKey("prop"), Is.True);
            var model = ModelReaderWriter.Read<ModelForRecord>(value.AdditionalProperties["prop"]);
            Assert.That(model!.State, Is.EqualTo("ok"));
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ExtendsModelArrayGet() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsModelArrayClient().GetAsync();
            var value = response.Value;
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(value.AdditionalProperties.Count, Is.EqualTo(1));
            });
            Assert.That(value.AdditionalProperties.ContainsKey("prop"), Is.True);
            var prop = value.AdditionalProperties["prop"].Select(item => ModelReaderWriter.Read<ModelForRecord>(item)).ToList();
            Assert.That(prop.Count, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(prop[0]!.State, Is.EqualTo("ok"));
                Assert.That(prop[1]!.State, Is.EqualTo("ok"));
            });
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task IsModelArrayGet() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetIsModelArrayClient().GetAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));

            var value = response.Value;
            Assert.That(value.AdditionalProperties.Count, Is.EqualTo(1));
            Assert.That(value.AdditionalProperties.ContainsKey("prop"), Is.True);

            var prop = value.AdditionalProperties["prop"].Select(item => ModelReaderWriter.Read<ModelForRecord>(item)).ToList();
            Assert.That(prop.Count, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(prop[0]!.State, Is.EqualTo("ok"));
                Assert.That(prop[1]!.State, Is.EqualTo("ok"));
            });
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ExtendsStringGet() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsStringClient().GetAsync();
            var value = response.Value;
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(value.Name, Is.EqualTo("ExtendsStringAdditionalProperties"));
            });
            Assert.That(value.AdditionalProperties, Is.EquivalentTo(new Dictionary<string, string>
            {
                ["prop"] = "abc"
            }));
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task IsStringGet() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetIsStringClient().GetAsync();
            var value = response.Value;
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(value.Name, Is.EqualTo("IsStringAdditionalProperties"));
            });
            Assert.That(value.AdditionalProperties, Is.EquivalentTo(new Dictionary<string, string>
            {
                ["prop"] = "abc"
            }));
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ExtendsUnknownGet() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsUnknownClient().GetAsync();
            var value = response.Value;
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(value.Name, Is.EqualTo("ExtendsUnknownAdditionalProperties"));
                Assert.That(value.AdditionalProperties.ContainsKey("prop1"), Is.True);
                Assert.That(value.AdditionalProperties["prop1"].ToObjectFromJson<int>(), Is.EqualTo(32));
                Assert.That(value.AdditionalProperties.ContainsKey("prop2"), Is.True);
                Assert.That(value.AdditionalProperties["prop2"].ToObjectFromJson<bool>(), Is.EqualTo(true));
                Assert.That(value.AdditionalProperties.ContainsKey("prop3"), Is.True);
                Assert.That(value.AdditionalProperties["prop3"].ToObjectFromJson<string>(), Is.EqualTo("abc"));
            });
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ExtendsUnknownDerivedGet() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsUnknownDerivedClient().GetAsync();
            var value = response.Value;
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(value.Name, Is.EqualTo("ExtendsUnknownAdditionalProperties"));
                Assert.That(value.Index, Is.EqualTo(314));
                Assert.That(value.Age, Is.EqualTo(2.71875f));
                Assert.That(value.AdditionalProperties.ContainsKey("prop1"), Is.True);
                Assert.That(value.AdditionalProperties["prop1"].ToObjectFromJson<int>(), Is.EqualTo(32));
                Assert.That(value.AdditionalProperties.ContainsKey("prop2"), Is.True);
                Assert.That(value.AdditionalProperties["prop2"].ToObjectFromJson<bool>(), Is.EqualTo(true));
                Assert.That(value.AdditionalProperties.ContainsKey("prop3"), Is.True);
                Assert.That(value.AdditionalProperties["prop3"].ToObjectFromJson<string>(), Is.EqualTo("abc"));
            });
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ExtendsUnknownDiscriminatedGet() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsUnknownDiscriminatedClient().GetAsync();
            var value = response.Value;
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(value.Name, Is.EqualTo("Derived"));
            });
            var kindProperty = value.GetType().GetProperty("Kind", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.That(kindProperty?.GetValue(value), Is.EqualTo("derived"));
            var derived = value as ExtendsUnknownAdditionalPropertiesDiscriminatedDerived;
            Assert.That(derived, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(derived!.Index, Is.EqualTo(314));
                Assert.That(derived.Age, Is.EqualTo(2.71875f));
                Assert.That(value.AdditionalProperties.ContainsKey("prop1"), Is.True);
                Assert.That(value.AdditionalProperties["prop1"].ToObjectFromJson<int>(), Is.EqualTo(32));
                Assert.That(value.AdditionalProperties.ContainsKey("prop2"), Is.True);
                Assert.That(value.AdditionalProperties["prop2"].ToObjectFromJson<bool>(), Is.EqualTo(true));
                Assert.That(value.AdditionalProperties.ContainsKey("prop3"), Is.True);
                Assert.That(value.AdditionalProperties["prop3"].ToObjectFromJson<string>(), Is.EqualTo("abc"));
            });
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task IsUnknownGet() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetIsUnknownClient().GetAsync();
            var value = response.Value;
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(value.Name, Is.EqualTo("IsUnknownAdditionalProperties"));
                Assert.That(value.AdditionalProperties.ContainsKey("prop1"), Is.True);
                Assert.That(value.AdditionalProperties["prop1"].ToObjectFromJson<int>(), Is.EqualTo(32));
                Assert.That(value.AdditionalProperties.ContainsKey("prop2"), Is.True);
                Assert.That(value.AdditionalProperties["prop2"].ToObjectFromJson<bool>(), Is.EqualTo(true));
                Assert.That(value.AdditionalProperties.ContainsKey("prop3"), Is.True);
                Assert.That(value.AdditionalProperties["prop3"].ToObjectFromJson<string>(), Is.EqualTo("abc"));
            });
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task IsUnknownDerivedGet() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetIsUnknownDerivedClient().GetAsync();
            var value = response.Value;
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(value.Name, Is.EqualTo("IsUnknownAdditionalProperties"));
                Assert.That(value.Index, Is.EqualTo(314));
                Assert.That(value.Age, Is.EqualTo(2.71875f));
                Assert.That(value.AdditionalProperties.ContainsKey("prop1"), Is.True);
                Assert.That(value.AdditionalProperties["prop1"].ToObjectFromJson<int>(), Is.EqualTo(32));
                Assert.That(value.AdditionalProperties.ContainsKey("prop2"), Is.True);
                Assert.That(value.AdditionalProperties["prop2"].ToObjectFromJson<bool>(), Is.EqualTo(true));
                Assert.That(value.AdditionalProperties.ContainsKey("prop3"), Is.True);
                Assert.That(value.AdditionalProperties["prop3"].ToObjectFromJson<string>(), Is.EqualTo("abc"));
            });
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task IsUnknownDiscriminatedGet() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetIsUnknownDiscriminatedClient().GetAsync();
            var value = response.Value;
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(value.Name, Is.EqualTo("Derived"));
            });
            var kindProperty = value.GetType().GetProperty("Kind", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.That(kindProperty?.GetValue(value), Is.EqualTo("derived"));
            var derived = value as IsUnknownAdditionalPropertiesDiscriminatedDerived;
            Assert.That(derived, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(derived!.Index, Is.EqualTo(314));
                Assert.That(derived.Age, Is.EqualTo(2.71875f));
                Assert.That(value.AdditionalProperties.ContainsKey("prop1"), Is.True);
                Assert.That(value.AdditionalProperties["prop1"].ToObjectFromJson<int>(), Is.EqualTo(32));
                Assert.That(value.AdditionalProperties.ContainsKey("prop2"), Is.True);
                Assert.That(value.AdditionalProperties["prop2"].ToObjectFromJson<bool>(), Is.EqualTo(true));
                Assert.That(value.AdditionalProperties.ContainsKey("prop3"), Is.True);
                Assert.That(value.AdditionalProperties["prop3"].ToObjectFromJson<string>(), Is.EqualTo("abc"));
            });
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ExtendsDifferentSpreadFloatGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsDifferentSpreadFloatClient().GetAsync();
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Name, Is.EqualTo("abc"));
                Assert.That(response.Value.DerivedProp, Is.EqualTo(43.125f));
                Assert.That(response.Value.AdditionalProperties.Count, Is.EqualTo(1));
            });
            Assert.That(response.Value.AdditionalProperties["prop"], Is.EqualTo(43.125f));
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ExtendsDifferentSpreadModelGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsDifferentSpreadModelClient().GetAsync();
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.KnownProp, Is.EqualTo("abc"));
                Assert.That(response.Value.DerivedProp, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(response.Value.DerivedProp.State, Is.EqualTo("ok"));
                Assert.That(response.Value.AdditionalProperties.Count, Is.EqualTo(1));
            });
            var prop = ModelReaderWriter.Read<ModelForRecord>(response.Value.AdditionalProperties["prop"]);
            Assert.That(prop!.State, Is.EqualTo("ok"));
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ExtendsDifferentSpreadModelArrayGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsDifferentSpreadModelArrayClient().GetAsync();
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.KnownProp, Is.EqualTo("abc"));
                Assert.That(response.Value.DerivedProp.Count, Is.EqualTo(2));
            });
            Assert.Multiple(() =>
            {
                Assert.That(response.Value.DerivedProp[0].State, Is.EqualTo("ok"));
                Assert.That(response.Value.DerivedProp[1].State, Is.EqualTo("ok"));
                Assert.That(response.Value.AdditionalProperties.Count, Is.EqualTo(1));
            });
            var list = response.Value.AdditionalProperties["prop"];
            Assert.That(list.Count, Is.EqualTo(2));
            var prop1 = ModelReaderWriter.Read<ModelForRecord>(list[0]);
            Assert.That(prop1!.State, Is.EqualTo("ok"));
            var prop2 = ModelReaderWriter.Read<ModelForRecord>(list[1]);
            Assert.That(prop2!.State, Is.EqualTo("ok"));
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ExtendsDifferentSpreadStringGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsDifferentSpreadStringClient().GetAsync();
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Id, Is.EqualTo(43.125f));
                Assert.That(response.Value.DerivedProp, Is.EqualTo("abc"));
                Assert.That(response.Value.AdditionalProperties.Count, Is.EqualTo(1));
            });
            Assert.That(response.Value.AdditionalProperties["prop"], Is.EqualTo("abc"));
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task MultipleSpreadGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetMultipleSpreadClient().GetAsync();
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Flag, Is.True);
                Assert.That(response.Value.AdditionalProperties.Count, Is.EqualTo(1));
                Assert.That(response.Value.AdditionalSingleProperties.Count, Is.EqualTo(1));
            });
            Assert.That(response.Value.AdditionalProperties["prop1"], Is.EqualTo("abc"));
            Assert.That(response.Value.AdditionalSingleProperties["prop2"], Is.EqualTo(43.125f));
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task SpreadDifferentFloatGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadDifferentFloatClient().GetAsync();
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Name, Is.EqualTo("abc"));
                Assert.That(response.Value.AdditionalProperties.Count, Is.EqualTo(1));
            });
            Assert.That(response.Value.AdditionalProperties["prop"], Is.EqualTo(43.125f));
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task SpreadDifferentModelGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadDifferentModelClient().GetAsync();
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.KnownProp, Is.EqualTo("abc"));
                Assert.That(response.Value.AdditionalProperties.Count, Is.EqualTo(1));
            });
            var model = ModelReaderWriter.Read<ModelForRecord>(response.Value.AdditionalProperties["prop"]);
            Assert.That(model!.State, Is.EqualTo("ok"));
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task SpreadDifferentModelArrayGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadDifferentModelArrayClient().GetAsync();
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.KnownProp, Is.EqualTo("abc"));
                Assert.That(response.Value.AdditionalProperties.Count, Is.EqualTo(1));
            });
            var list = response.Value.AdditionalProperties["prop"];
            Assert.That(list.Count, Is.EqualTo(2));
            var first = ModelReaderWriter.Read<ModelForRecord>(list[0]);
            var second = ModelReaderWriter.Read<ModelForRecord>(list[1]);
            Assert.Multiple(() =>
            {
                Assert.That(first!.State, Is.EqualTo("ok"));
                Assert.That(second!.State, Is.EqualTo("ok"));
            });
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task SpreadDifferentStringGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadDifferentStringClient().GetAsync();
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Id, Is.EqualTo(43.125f));
                Assert.That(response.Value.AdditionalProperties.Count, Is.EqualTo(1));
            });
            Assert.That(response.Value.AdditionalProperties["prop"], Is.EqualTo("abc"));
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task SpreadFloatGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadFloatClient().GetAsync();
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Id, Is.EqualTo(43.125f));
                Assert.That(response.Value.AdditionalProperties.Count, Is.EqualTo(1));
            });
            Assert.That(response.Value.AdditionalProperties["prop"], Is.EqualTo(43.125f));
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task SpreadModelGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadModelClient().GetAsync();
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.KnownProp.State, Is.EqualTo("ok"));
                Assert.That(response.Value.AdditionalProperties.Count, Is.EqualTo(1));
            });
            var model = ModelReaderWriter.Read<ModelForRecord>(response.Value.AdditionalProperties["prop"]);
            Assert.That(model!.State, Is.EqualTo("ok"));
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task SpreadModelArrayGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadModelArrayClient().GetAsync();
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.KnownProp.Count, Is.EqualTo(2));
            });
            Assert.Multiple(() =>
            {
                Assert.That(response.Value.KnownProp[0].State, Is.EqualTo("ok"));
                Assert.That(response.Value.KnownProp[1].State, Is.EqualTo("ok"));
                Assert.That(response.Value.AdditionalProperties.Count, Is.EqualTo(1));
            });
            var list = response.Value.AdditionalProperties["prop"];
            Assert.That(list.Count, Is.EqualTo(2));
            var first = ModelReaderWriter.Read<ModelForRecord>(list[0]);
            var second = ModelReaderWriter.Read<ModelForRecord>(list[1]);
            Assert.Multiple(() =>
            {
                Assert.That(first!.State, Is.EqualTo("ok"));
                Assert.That(second!.State, Is.EqualTo("ok"));
            });
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task SpreadRecordNonDiscriminatedUnionGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadRecordNonDiscriminatedUnionClient().GetAsync();
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Name, Is.EqualTo("abc"));
                Assert.That(response.Value.AdditionalProperties.Count, Is.EqualTo(2));
            });
            var prop1 = ModelReaderWriter.Read<WidgetData0>(response.Value.AdditionalProperties["prop1"]);
            Assert.That(prop1!.FooProp, Is.EqualTo("abc"));
            var prop2 = ModelReaderWriter.Read<WidgetData1>(response.Value.AdditionalProperties["prop2"]);
            Assert.Multiple(() =>
            {
                Assert.That(prop2!.Start, Is.EqualTo(new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero)));
                Assert.That(prop2.End, Is.EqualTo(new DateTimeOffset(2021, 1, 2, 0, 0, 0, TimeSpan.Zero)));
            });
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task SpreadRecordNonDiscriminatedUnion2Get() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadRecordNonDiscriminatedUnion2Client().GetAsync();
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Name, Is.EqualTo("abc"));
                Assert.That(response.Value.AdditionalProperties.Count, Is.EqualTo(2));
            });
            var prop1 = ModelReaderWriter.Read<WidgetData2>(response.Value.AdditionalProperties["prop1"]);
            Assert.That(prop1!.Start, Is.EqualTo("2021-01-01T00:00:00Z"));
            var prop2 = ModelReaderWriter.Read<WidgetData1>(response.Value.AdditionalProperties["prop2"]);
            Assert.Multiple(() =>
            {
                Assert.That(prop2!.Start, Is.EqualTo(new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero)));
                Assert.That(prop2.End, Is.EqualTo(new DateTimeOffset(2021, 1, 2, 0, 0, 0, TimeSpan.Zero)));
            });
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task SpreadRecordUnionGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadRecordUnionClient().GetAsync();
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Flag, Is.True);
                Assert.That(response.Value.AdditionalProperties.Count, Is.EqualTo(1));
                Assert.That(response.Value.AdditionalSingleProperties.Count, Is.EqualTo(1));
            });
            Assert.That(response.Value.AdditionalProperties["prop1"], Is.EqualTo("abc"));
            Assert.That(response.Value.AdditionalSingleProperties["prop2"], Is.EqualTo(43.125f));
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task SpreadStringGet() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadStringClient().GetAsync();
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Name, Is.EqualTo("SpreadSpringRecord"));
                Assert.That(response.Value.AdditionalProperties.Count, Is.EqualTo(1));
            });
            Assert.That(response.Value.AdditionalProperties["prop"], Is.EqualTo("abc"));
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

    }
}
