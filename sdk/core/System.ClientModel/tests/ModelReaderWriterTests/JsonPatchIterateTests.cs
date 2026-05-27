// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.ClientModel.Tests.Client.Models.ResourceManager.Resources;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    internal class JsonPatchIterateTests
    {
        /// <summary>
        /// Helper: collects all items from EnumerateArray and returns them as a list of strings.
        /// </summary>
        private static List<string> Collect(JsonPatch jp, ReadOnlySpan<byte> path)
        {
            var items = new List<string>();
            foreach (ReadOnlyMemory<byte> item in jp.EnumerateArray(path))
            {
                items.Add(Encoding.UTF8.GetString(item.ToArray()));
            }
            return items;
        }

        /// <summary>
        /// Helper: joins items from EnumerateArray into a JSON array string to compare with GetJson.
        /// </summary>
        private static string JoinAsArray(JsonPatch jp, ReadOnlySpan<byte> path)
        {
            var items = Collect(jp, path);
            return "[" + string.Join(",", items) + "]";
        }

        #region Category A: Seed bytes only

        [Test]
        public void Seed_Primitives()
        {
            JsonPatch jp = new("{\"arr\":[1,2,3]}"u8.ToArray());

            var items = Collect(jp, "$.arr"u8);
            Assert.AreEqual(3, items.Count);
            Assert.AreEqual("1", items[0]);
            Assert.AreEqual("2", items[1]);
            Assert.AreEqual("3", items[2]);
        }

        [Test]
        public void Seed_Objects()
        {
            JsonPatch jp = new("{\"arr\":[{\"a\":1},{\"a\":2}]}"u8.ToArray());

            var items = Collect(jp, "$.arr"u8);
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("{\"a\":1}", items[0]);
            Assert.AreEqual("{\"a\":2}", items[1]);
        }

        [Test]
        public void Seed_2DArray()
        {
            JsonPatch jp = new("{\"arr\":[[1,2],[3,4]]}"u8.ToArray());

            var items = Collect(jp, "$.arr"u8);
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("[1,2]", items[0]);
            Assert.AreEqual("[3,4]", items[1]);
        }

        [Test]
        public void Seed_MixedTypes()
        {
            JsonPatch jp = new("{\"arr\":[1,\"hello\",null,{\"x\":1},true]}"u8.ToArray());

            var items = Collect(jp, "$.arr"u8);
            Assert.AreEqual(5, items.Count);
            Assert.AreEqual("1", items[0]);
            Assert.AreEqual("\"hello\"", items[1]);
            Assert.AreEqual("null", items[2]);
            Assert.AreEqual("{\"x\":1}", items[3]);
            Assert.AreEqual("true", items[4]);
        }

        [Test]
        public void Seed_EmptyArray()
        {
            JsonPatch jp = new("{\"arr\":[]}"u8.ToArray());

            var items = Collect(jp, "$.arr"u8);
            Assert.AreEqual(0, items.Count);
        }

        [Test]
        public void Seed_NestedPath()
        {
            JsonPatch jp = new("{\"foo\":{\"bar\":[1,2,3]}}"u8.ToArray());

            var items = Collect(jp, "$.foo.bar"u8);
            Assert.AreEqual(3, items.Count);
            Assert.AreEqual("1", items[0]);
            Assert.AreEqual("2", items[1]);
            Assert.AreEqual("3", items[2]);
        }

        [Test]
        public void Seed_3DArray_IterateEachLevel()
        {
            JsonPatch jp = new("{\"m\":[[[1,2],[3,4]],[[5,6]]]}"u8.ToArray());

            // Iterate outermost: yields 2 2D arrays
            var outer = Collect(jp, "$.m"u8);
            Assert.AreEqual(2, outer.Count);
            Assert.AreEqual("[[1,2],[3,4]]", outer[0]);
            Assert.AreEqual("[[5,6]]", outer[1]);

            // Iterate second level: yields 2 1D arrays
            var mid = Collect(jp, "$.m[0]"u8);
            Assert.AreEqual(2, mid.Count);
            Assert.AreEqual("[1,2]", mid[0]);
            Assert.AreEqual("[3,4]", mid[1]);

            // Iterate innermost: yields primitives
            var inner = Collect(jp, "$.m[0][0]"u8);
            Assert.AreEqual(2, inner.Count);
            Assert.AreEqual("1", inner[0]);
            Assert.AreEqual("2", inner[1]);
        }

        [Test]
        public void Seed_ObjectsWithNestedArrays()
        {
            JsonPatch jp = new("{\"arr\":[{\"tags\":[\"a\",\"b\"],\"id\":1},{\"tags\":[\"c\"],\"id\":2}]}"u8.ToArray());

            var items = Collect(jp, "$.arr"u8);
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("{\"tags\":[\"a\",\"b\"],\"id\":1}", items[0]);
            Assert.AreEqual("{\"tags\":[\"c\"],\"id\":2}", items[1]);
        }

        #endregion

        #region Category B: Properties only (no seed)

        [Test]
        public void Properties_SetEntireArray()
        {
            JsonPatch jp = new();
            jp.Set("$.arr"u8, "[1,2,3]"u8);

            var items = Collect(jp, "$.arr"u8);
            Assert.AreEqual(3, items.Count);
            Assert.AreEqual("1", items[0]);
            Assert.AreEqual("2", items[1]);
            Assert.AreEqual("3", items[2]);
        }

        [Test]
        public void Properties_AppendOnly()
        {
            JsonPatch jp = new();
            jp.Append("$.arr"u8, 10);
            jp.Append("$.arr"u8, 20);
            jp.Append("$.arr"u8, 30);

            var items = Collect(jp, "$.arr"u8);
            Assert.AreEqual(3, items.Count);
            Assert.AreEqual("10", items[0]);
            Assert.AreEqual("20", items[1]);
            Assert.AreEqual("30", items[2]);
        }

        [Test]
        public void Properties_SetIndividualIndexes()
        {
            // Set individual indexes on a properties-only patch via Set("$"u8, ...) since
            // Set("$[N]"u8, ...) stores at $[N] not at root $
            JsonPatch jp = new();
            jp.Set("$"u8, "[\"first\",\"second\"]"u8);

            var items = Collect(jp, "$"u8);
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("\"first\"", items[0]);
            Assert.AreEqual("\"second\"", items[1]);
        }

        [Test]
        public void Properties_AppendThenRemove()
        {
            JsonPatch jp = new();
            jp.Append("$.arr"u8, 1);
            jp.Append("$.arr"u8, 2);
            jp.Append("$.arr"u8, 3);
            jp.Remove("$.arr[1]"u8);

            var items = Collect(jp, "$.arr"u8);
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("1", items[0]);
            Assert.AreEqual("3", items[1]);
        }

        [Test]
        public void Properties_OutOfOrderIndexSets()
        {
            JsonPatch jp = new();
            jp.Set("$.arr[1]"u8, "\"second\""u8);
            jp.Set("$.arr[0]"u8, "\"first\""u8);

            var items = Collect(jp, "$.arr"u8);
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("\"first\"", items[0]);
            Assert.AreEqual("\"second\"", items[1]);
        }

        [Test]
        public void Properties_AppendObjectsAsJson()
        {
            JsonPatch jp = new();
            jp.Append("$.arr"u8, "{\"a\":1}"u8);
            jp.Append("$.arr"u8, "{\"b\":2}"u8);

            var items = Collect(jp, "$.arr"u8);
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("{\"a\":1}", items[0]);
            Assert.AreEqual("{\"b\":2}", items[1]);
        }

        #endregion

        #region Category C: Seed + Properties (ordering)

        [Test]
        public void SeedAndProperties_Append()
        {
            JsonPatch jp = new("{\"arr\":[1,2,3]}"u8.ToArray());
            jp.Append("$.arr"u8, 4);

            var items = Collect(jp, "$.arr"u8);
            Assert.AreEqual(4, items.Count);
            Assert.AreEqual("1", items[0]);
            Assert.AreEqual("2", items[1]);
            Assert.AreEqual("3", items[2]);
            Assert.AreEqual("4", items[3]);
        }

        [Test]
        public void SeedAndProperties_RemoveMiddle()
        {
            JsonPatch jp = new("{\"arr\":[1,2,3]}"u8.ToArray());
            jp.Remove("$.arr[1]"u8);

            var items = Collect(jp, "$.arr"u8);
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("1", items[0]);
            Assert.AreEqual("3", items[1]);
        }

        [Test]
        public void SeedAndProperties_RemoveFirst()
        {
            JsonPatch jp = new("{\"arr\":[1,2,3]}"u8.ToArray());
            jp.Remove("$.arr[0]"u8);

            var items = Collect(jp, "$.arr"u8);
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("2", items[0]);
            Assert.AreEqual("3", items[1]);
        }

        [Test]
        public void SeedAndProperties_RemoveLast()
        {
            JsonPatch jp = new("{\"arr\":[1,2,3]}"u8.ToArray());
            jp.Remove("$.arr[2]"u8);

            var items = Collect(jp, "$.arr"u8);
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("1", items[0]);
            Assert.AreEqual("2", items[1]);
        }

        [Test]
        public void SeedAndProperties_ReplaceElement()
        {
            JsonPatch jp = new("{\"arr\":[1,2,3]}"u8.ToArray());
            jp.Set("$.arr[1]"u8, 99);

            var items = Collect(jp, "$.arr"u8);
            Assert.AreEqual(3, items.Count);
            Assert.AreEqual("1", items[0]);
            Assert.AreEqual("99", items[1]);
            Assert.AreEqual("3", items[2]);
        }

        [Test]
        public void SeedAndProperties_RemoveAndAppend()
        {
            JsonPatch jp = new("{\"arr\":[1,2,3]}"u8.ToArray());
            jp.Remove("$.arr[1]"u8);
            jp.Append("$.arr"u8, 4);

            var items = Collect(jp, "$.arr"u8);
            Assert.AreEqual(3, items.Count);
            Assert.AreEqual("1", items[0]);
            Assert.AreEqual("3", items[1]);
            Assert.AreEqual("4", items[2]);
        }

        [Test]
        public void SeedAndProperties_AppendMultiple()
        {
            JsonPatch jp = new("{\"arr\":[1,2]}"u8.ToArray());
            jp.Append("$.arr"u8, 3);
            jp.Append("$.arr"u8, 4);
            jp.Append("$.arr"u8, 5);

            var items = Collect(jp, "$.arr"u8);
            Assert.AreEqual(5, items.Count);
            Assert.AreEqual("1", items[0]);
            Assert.AreEqual("2", items[1]);
            Assert.AreEqual("3", items[2]);
            Assert.AreEqual("4", items[3]);
            Assert.AreEqual("5", items[4]);
        }

        [Test]
        public void SeedAndProperties_RemoveAll()
        {
            // Removing multiple array items by index has sequential application semantics
            // (same as WriteTo serialization). After first remove, subsequent indices shift.
            // To remove all items, use Remove on the array path itself.
            JsonPatch jp = new("{\"arr\":[1,2,3],\"x\":1}"u8.ToArray());
            jp.Remove("$.arr"u8);

            Assert.Throws<KeyNotFoundException>(() =>
            {
                foreach (var _ in jp.EnumerateArray("$.arr"u8)) { }
            });
        }

        [Test]
        public void SeedAndProperties_LargeArrayAppend()
        {
            JsonPatch jp = new("{\"arr\":[1,2,3,4,5,6,7,8,9,10,11]}"u8.ToArray());
            jp.Append("$.arr"u8, 12);
            jp.Append("$.arr"u8, 13);

            var items = Collect(jp, "$.arr"u8);
            Assert.AreEqual(13, items.Count);
            for (int i = 0; i < 13; i++)
            {
                Assert.AreEqual((i + 1).ToString(), items[i]);
            }
        }

        [Test]
        public void SeedAndProperties_SiblingRemovalDoesNotAffect()
        {
            JsonPatch jp = new("{\"arr\":[1,2,3],\"x\":1}"u8.ToArray());
            jp.Remove("$.x"u8);
            jp.Append("$.arr"u8, 4);

            var items = Collect(jp, "$.arr"u8);
            Assert.AreEqual(4, items.Count);
            Assert.AreEqual("1", items[0]);
            Assert.AreEqual("2", items[1]);
            Assert.AreEqual("3", items[2]);
            Assert.AreEqual("4", items[3]);
        }

        #endregion

        #region Category D: Multi-dimensional / deeply nested

        [Test]
        public void MultiDim_2D_IterateOuter()
        {
            JsonPatch jp = new("[[1,2],[3,4],[5,6]]"u8.ToArray());

            var items = Collect(jp, "$"u8);
            Assert.AreEqual(3, items.Count);
            Assert.AreEqual("[1,2]", items[0]);
            Assert.AreEqual("[3,4]", items[1]);
            Assert.AreEqual("[5,6]", items[2]);
        }

        [Test]
        public void MultiDim_2D_IterateInner()
        {
            JsonPatch jp = new("{\"m\":[[1,2],[3,4]]}"u8.ToArray());

            var items = Collect(jp, "$.m[1]"u8);
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("3", items[0]);
            Assert.AreEqual("4", items[1]);
        }

        [Test]
        public void MultiDim_3D_IterateEachLevel()
        {
            JsonPatch jp = new("[[[1,2],[3,4]],[[5,6]]]"u8.ToArray());

            // Top level: 2 items
            var top = Collect(jp, "$"u8);
            Assert.AreEqual(2, top.Count);
            Assert.AreEqual("[[1,2],[3,4]]", top[0]);
            Assert.AreEqual("[[5,6]]", top[1]);

            // Second level of first item: 2 items
            var mid = Collect(jp, "$[0]"u8);
            Assert.AreEqual(2, mid.Count);
            Assert.AreEqual("[1,2]", mid[0]);
            Assert.AreEqual("[3,4]", mid[1]);

            // Innermost of first>first: 2 items
            var inner = Collect(jp, "$[0][0]"u8);
            Assert.AreEqual(2, inner.Count);
            Assert.AreEqual("1", inner[0]);
            Assert.AreEqual("2", inner[1]);
        }

        [Test]
        public void MultiDim_2D_AppendToInner()
        {
            JsonPatch jp = new("{\"m\":[[1,2],[3,4]]}"u8.ToArray());
            jp.Append("$.m[0]"u8, 5);

            var items = Collect(jp, "$.m[0]"u8);
            Assert.AreEqual(3, items.Count);
            Assert.AreEqual("1", items[0]);
            Assert.AreEqual("2", items[1]);
            Assert.AreEqual("5", items[2]);
        }

        [Test]
        public void MultiDim_2D_AppendToOuter()
        {
            JsonPatch jp = new("{\"m\":[[1,2],[3,4]]}"u8.ToArray());
            jp.Append("$.m"u8, "[5,6]"u8);

            var items = Collect(jp, "$.m"u8);
            Assert.AreEqual(3, items.Count);
            Assert.AreEqual("[1,2]", items[0]);
            Assert.AreEqual("[3,4]", items[1]);
            Assert.AreEqual("[5,6]", items[2]);
        }

        [Test]
        public void MultiDim_ObjectsWithDeeplyNestedArrays()
        {
            JsonPatch jp = new("{\"items\":[{\"z\":{\"a\":[[{\"b\":\"v1\"},{\"b\":\"v2\"}],[{\"b\":\"v3\"}]]}}]}"u8.ToArray());

            // iterate $.items yields 1 object
            var items = Collect(jp, "$.items"u8);
            Assert.AreEqual(1, items.Count);
            Assert.AreEqual("{\"z\":{\"a\":[[{\"b\":\"v1\"},{\"b\":\"v2\"}],[{\"b\":\"v3\"}]]}}", items[0]);

            // iterate $.items[0].z.a yields 2 arrays
            var inner = Collect(jp, "$.items[0].z.a"u8);
            Assert.AreEqual(2, inner.Count);
            Assert.AreEqual("[{\"b\":\"v1\"},{\"b\":\"v2\"}]", inner[0]);
            Assert.AreEqual("[{\"b\":\"v3\"}]", inner[1]);

            // iterate $.items[0].z.a[0] yields 2 objects
            var innermost = Collect(jp, "$.items[0].z.a[0]"u8);
            Assert.AreEqual(2, innermost.Count);
            Assert.AreEqual("{\"b\":\"v1\"}", innermost[0]);
            Assert.AreEqual("{\"b\":\"v2\"}", innermost[1]);
        }

        [Test]
        public void MultiDim_DeepAlternatingArrayProperty()
        {
            JsonPatch jp = new("{\"a\":{\"b\":[{\"c\":{\"d\":[10,20,30]}}]}}"u8.ToArray());

            // iterate $.a.b yields 1 object
            var items = Collect(jp, "$.a.b"u8);
            Assert.AreEqual(1, items.Count);
            Assert.AreEqual("{\"c\":{\"d\":[10,20,30]}}", items[0]);

            // iterate $.a.b[0].c.d yields 3 primitives
            var inner = Collect(jp, "$.a.b[0].c.d"u8);
            Assert.AreEqual(3, inner.Count);
            Assert.AreEqual("10", inner[0]);
            Assert.AreEqual("20", inner[1]);
            Assert.AreEqual("30", inner[2]);
        }

        [Test]
        public void MultiDim_2D_RemoveInnerElement()
        {
            JsonPatch jp = new("[[1,2,3],[4,5,6]]"u8.ToArray());
            jp.Remove("$[0][1]"u8);

            // iterate $[0] should yield [1,3] (2 removed)
            var inner = Collect(jp, "$[0]"u8);
            Assert.AreEqual(2, inner.Count);
            Assert.AreEqual("1", inner[0]);
            Assert.AreEqual("3", inner[1]);

            // iterate $ should still yield 2 inner arrays
            var outer = Collect(jp, "$"u8);
            Assert.AreEqual(2, outer.Count);
        }

        #endregion

        #region Category E: Propagator-backed (V1 model — old PropagateGet)

        private static AvailabilitySetData GetInitialModel()
        {
            string jsonPayload = File.ReadAllText(
                TestData.GetLocation("AvailabilitySetData/AvailabilitySetDataWireFormat.json")).TrimEnd();
            var model = ModelReaderWriter.Read<AvailabilitySetData>(BinaryData.FromString(jsonPayload));
            Assert.IsNotNull(model);
            return model!;
        }

        private static AvailabilitySetData GetRoundTripModel(BinaryData data)
        {
            var model = ModelReaderWriter.Read<AvailabilitySetData>(data);
            Assert.IsNotNull(model);
            return model!;
        }

        [Test]
        public void Propagator_ClrOnlyOnEmptyArray()
        {
            // Add VMs via CLR, round-trip, then iterate the array.
            // After round-trip, virtualMachines exist in seed bytes.
            var model = GetInitialModel();
            model.VirtualMachines.Add(new WritableSubResource() { Id = "vm1" });
            model.VirtualMachines.Add(new WritableSubResource() { Id = "vm2" });

            var data = ModelReaderWriter.Write(model);
            var model2 = GetRoundTripModel(data);

            var items = Collect(model2.Patch, "$.properties.virtualMachines"u8);
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("{\"id\":\"vm1\"}", items[0]);
            Assert.AreEqual("{\"id\":\"vm2\"}", items[1]);
        }

        [Test]
        public void Propagator_PatchAppendOnEmptyArray()
        {
            // Initial model: no virtualMachines in seed. Append via patch only.
            var model = GetInitialModel();
            model.Patch.Append("$.properties.virtualMachines"u8, "{\"id\":\"patchVm\"}"u8);

            var items = Collect(model.Patch, "$.properties.virtualMachines"u8);
            Assert.AreEqual(1, items.Count);
            Assert.AreEqual("{\"id\":\"patchVm\"}", items[0]);
        }

        [Test]
        public void Propagator_ClrPlusAppend()
        {
            // Add VM via CLR, round-trip, then append more via patch.
            var model = GetInitialModel();
            model.VirtualMachines.Add(new WritableSubResource() { Id = "existing1" });

            var data = ModelReaderWriter.Write(model);
            var model2 = GetRoundTripModel(data);

            // Append via patch on top of CLR-originated seed
            model2.Patch.Append("$.properties.virtualMachines"u8, "{\"id\":\"appended1\"}"u8);

            var items = Collect(model2.Patch, "$.properties.virtualMachines"u8);
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("{\"id\":\"existing1\"}", items[0]);
            Assert.AreEqual("{\"id\":\"appended1\"}", items[1]);
        }

        [Test]
        public void Propagator_ClrRemoveThenRoundTrip()
        {
            // CLR model with 3 VMs. Remove middle via patch, serialize, round-trip.
            // After round-trip, the seed has the correct state with the remove applied.
            var model = GetInitialModel();
            model.VirtualMachines.Add(new WritableSubResource() { Id = "vm1" });
            model.VirtualMachines.Add(new WritableSubResource() { Id = "vm2" });
            model.VirtualMachines.Add(new WritableSubResource() { Id = "vm3" });

            model.Patch.Remove("$.properties.virtualMachines[1]"u8);

            // Serialize and round-trip to get the final state
            var data = ModelReaderWriter.Write(model);
            var model2 = GetRoundTripModel(data);

            // After round-trip, seed reflects the remove
            var items = Collect(model2.Patch, "$.properties.virtualMachines"u8);
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("{\"id\":\"vm1\"}", items[0]);
            Assert.AreEqual("{\"id\":\"vm3\"}", items[1]);
        }

        [Test]
        public void Propagator_ClrAppendAndRemoveThenRoundTrip()
        {
            // Add 2 VMs via CLR, remove first, append new, serialize, round-trip.
            var model = GetInitialModel();
            model.VirtualMachines.Add(new WritableSubResource() { Id = "vm1" });
            model.VirtualMachines.Add(new WritableSubResource() { Id = "vm2" });

            model.Patch.Remove("$.properties.virtualMachines[0]"u8);
            model.Patch.Append("$.properties.virtualMachines"u8, "{\"id\":\"vm3\"}"u8);

            var data = ModelReaderWriter.Write(model);
            var model2 = GetRoundTripModel(data);

            // After round-trip, seed has the final state
            var items = Collect(model2.Patch, "$.properties.virtualMachines"u8);
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("{\"id\":\"vm2\"}", items[0]);
            Assert.AreEqual("{\"id\":\"vm3\"}", items[1]);
        }

        [Test]
        public void Propagator_ConsistentWithGetJson()
        {
            // Verify EnumerateArray items joined match GetJson for the model array
            var model = GetInitialModel();
            model.VirtualMachines.Add(new WritableSubResource() { Id = "vm1" });

            var data = ModelReaderWriter.Write(model);
            var model2 = GetRoundTripModel(data);

            model2.Patch.Append("$.properties.virtualMachines"u8, "{\"id\":\"vm2\"}"u8);

            var items = Collect(model2.Patch, "$.properties.virtualMachines"u8);
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("{\"id\":\"vm1\"}", items[0]);
            Assert.AreEqual("{\"id\":\"vm2\"}", items[1]);

            string fromEnumerate = JoinAsArray(model2.Patch, "$.properties.virtualMachines"u8);
            string fromGetJson = model2.Patch.GetJson("$.properties.virtualMachines"u8).ToString();
            Assert.AreEqual(fromGetJson, fromEnumerate);
        }

        [Test]
        public void Propagator_PatchOnlyAppendAndRemove_NoRoundTrip_EmptyStart()
        {
            // Empty model: append two items via patch, remove first — no CLR, no round-trip.
            var model = GetInitialModel();
            model.Patch.Append("$.properties.virtualMachines"u8, "{\"id\":\"a\"}"u8);
            model.Patch.Append("$.properties.virtualMachines"u8, "{\"id\":\"b\"}"u8);

            // Remove first appended item
            model.Patch.Remove("$.properties.virtualMachines[0]"u8);

            var items = Collect(model.Patch, "$.properties.virtualMachines"u8);
            Assert.AreEqual(1, items.Count);
            Assert.AreEqual("{\"id\":\"b\"}", items[0]);
        }

        #endregion

        #region Category E2: Propagator-backed (V2 model — enhanced PropagateGet)

        private static AvailabilitySetDataV2 GetInitialModelV2()
        {
            string jsonPayload = File.ReadAllText(
                TestData.GetLocation("AvailabilitySetData/AvailabilitySetDataWireFormat.json")).TrimEnd();
            var model = ModelReaderWriter.Read<AvailabilitySetDataV2>(BinaryData.FromString(jsonPayload));
            Assert.IsNotNull(model);
            return model!;
        }

        private static AvailabilitySetDataV2 GetRoundTripModelV2(BinaryData data)
        {
            var model = ModelReaderWriter.Read<AvailabilitySetDataV2>(data);
            Assert.IsNotNull(model);
            return model!;
        }

        // Round-trip tests: V2 should behave identically to V1 after round-trip

        [Test]
        public void PropagatorV2_ClrOnlyOnEmptyArray()
        {
            var model = GetInitialModelV2();
            model.VirtualMachines.Add(new WritableSubResource() { Id = "vm1" });
            model.VirtualMachines.Add(new WritableSubResource() { Id = "vm2" });

            var data = ModelReaderWriter.Write(model);
            var model2 = GetRoundTripModelV2(data);

            var items = Collect(model2.Patch, "$.properties.virtualMachines"u8);
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("{\"id\":\"vm1\"}", items[0]);
            Assert.AreEqual("{\"id\":\"vm2\"}", items[1]);
        }

        [Test]
        public void PropagatorV2_PatchAppendOnEmptyArray()
        {
            var model = GetInitialModelV2();
            model.Patch.Append("$.properties.virtualMachines"u8, "{\"id\":\"patchVm\"}"u8);

            var items = Collect(model.Patch, "$.properties.virtualMachines"u8);
            Assert.AreEqual(1, items.Count);
            Assert.AreEqual("{\"id\":\"patchVm\"}", items[0]);
        }

        [Test]
        public void PropagatorV2_ClrPlusAppend()
        {
            var model = GetInitialModelV2();
            model.VirtualMachines.Add(new WritableSubResource() { Id = "existing1" });

            var data = ModelReaderWriter.Write(model);
            var model2 = GetRoundTripModelV2(data);

            model2.Patch.Append("$.properties.virtualMachines"u8, "{\"id\":\"appended1\"}"u8);

            var items = Collect(model2.Patch, "$.properties.virtualMachines"u8);
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("{\"id\":\"existing1\"}", items[0]);
            Assert.AreEqual("{\"id\":\"appended1\"}", items[1]);
        }

        [Test]
        public void PropagatorV2_ClrRemoveThenRoundTrip()
        {
            var model = GetInitialModelV2();
            model.VirtualMachines.Add(new WritableSubResource() { Id = "vm1" });
            model.VirtualMachines.Add(new WritableSubResource() { Id = "vm2" });
            model.VirtualMachines.Add(new WritableSubResource() { Id = "vm3" });

            model.Patch.Remove("$.properties.virtualMachines[1]"u8);

            var data = ModelReaderWriter.Write(model);
            var model2 = GetRoundTripModelV2(data);

            var items = Collect(model2.Patch, "$.properties.virtualMachines"u8);
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("{\"id\":\"vm1\"}", items[0]);
            Assert.AreEqual("{\"id\":\"vm3\"}", items[1]);
        }

        [Test]
        public void PropagatorV2_ClrAppendAndRemoveThenRoundTrip()
        {
            var model = GetInitialModelV2();
            model.VirtualMachines.Add(new WritableSubResource() { Id = "vm1" });
            model.VirtualMachines.Add(new WritableSubResource() { Id = "vm2" });

            model.Patch.Remove("$.properties.virtualMachines[0]"u8);
            model.Patch.Append("$.properties.virtualMachines"u8, "{\"id\":\"vm3\"}"u8);

            var data = ModelReaderWriter.Write(model);
            var model2 = GetRoundTripModelV2(data);

            var items = Collect(model2.Patch, "$.properties.virtualMachines"u8);
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("{\"id\":\"vm2\"}", items[0]);
            Assert.AreEqual("{\"id\":\"vm3\"}", items[1]);
        }

        [Test]
        public void PropagatorV2_ConsistentWithGetJson()
        {
            // Round-trip model, then append via patch.
            // GetJson and EnumerateArray should agree since TryGetEncodedValueInternal
            // now merges propagator results with patch appends.
            var model = GetInitialModelV2();
            model.VirtualMachines.Add(new WritableSubResource() { Id = "vm1" });

            var data = ModelReaderWriter.Write(model);
            var model2 = GetRoundTripModelV2(data);

            model2.Patch.Append("$.properties.virtualMachines"u8, "{\"id\":\"vm2\"}"u8);

            var items = Collect(model2.Patch, "$.properties.virtualMachines"u8);
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("{\"id\":\"vm1\"}", items[0]);
            Assert.AreEqual("{\"id\":\"vm2\"}", items[1]);

            string fromEnumerate = JoinAsArray(model2.Patch, "$.properties.virtualMachines"u8);
            string fromGetJson = model2.Patch.GetJson("$.properties.virtualMachines"u8).ToString();
            Assert.AreEqual(fromGetJson, fromEnumerate);
        }

        [Test]
        public void PropagatorV2_PatchOnlyAppendAndRemove_NoRoundTrip_EmptyStart()
        {
            var model = GetInitialModelV2();
            model.Patch.Append("$.properties.virtualMachines"u8, "{\"id\":\"a\"}"u8);
            model.Patch.Append("$.properties.virtualMachines"u8, "{\"id\":\"b\"}"u8);
            model.Patch.Remove("$.properties.virtualMachines[0]"u8);

            var items = Collect(model.Patch, "$.properties.virtualMachines"u8);
            Assert.AreEqual(1, items.Count);
            Assert.AreEqual("{\"id\":\"b\"}", items[0]);
        }

        // No-round-trip tests: V2 enhanced PropagateGet makes CLR items visible

        [Test]
        public void PropagatorV2_ClrAddAndPatchAppend_NoRoundTrip_EmptyStart()
        {
            // Empty model: add via CLR and append via patch without round-trip.
            // V2 enhanced PropagateGet serializes CLR items + merges patch appends.
            var model = GetInitialModelV2();
            model.VirtualMachines.Add(new WritableSubResource() { Id = "clrVm" });
            model.Patch.Append("$.properties.virtualMachines"u8, "{\"id\":\"patchVm\"}"u8);

            var items = Collect(model.Patch, "$.properties.virtualMachines"u8);
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("{\"id\":\"clrVm\"}", items[0]);
            Assert.AreEqual("{\"id\":\"patchVm\"}", items[1]);
        }

        [Test]
        public void PropagatorV2_ClrAddAndPatchAppend_NoRoundTrip_PreExisting()
        {
            // Round-trip to get seed, then add more via CLR and patch without a second round-trip.
            var model = GetInitialModelV2();
            model.VirtualMachines.Add(new WritableSubResource() { Id = "seed1" });

            var data = ModelReaderWriter.Write(model);
            var model2 = GetRoundTripModelV2(data);

            model2.VirtualMachines.Add(new WritableSubResource() { Id = "clrAdded" });
            model2.Patch.Append("$.properties.virtualMachines"u8, "{\"id\":\"patchAdded\"}"u8);

            var items = Collect(model2.Patch, "$.properties.virtualMachines"u8);
            Assert.AreEqual(3, items.Count);
            Assert.AreEqual("{\"id\":\"seed1\"}", items[0]);
            Assert.AreEqual("{\"id\":\"clrAdded\"}", items[1]);
            Assert.AreEqual("{\"id\":\"patchAdded\"}", items[2]);
        }

        [Test]
        public void PropagatorV2_ClrAddAndPatchRemove_NoRoundTrip()
        {
            // Add VMs via CLR, then remove one via patch — no round-trip.
            var model = GetInitialModelV2();
            model.VirtualMachines.Add(new WritableSubResource() { Id = "vm1" });
            model.VirtualMachines.Add(new WritableSubResource() { Id = "vm2" });
            model.VirtualMachines.Add(new WritableSubResource() { Id = "vm3" });

            model.Patch.Remove("$.properties.virtualMachines[1]"u8);

            var items = Collect(model.Patch, "$.properties.virtualMachines"u8);
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("{\"id\":\"vm1\"}", items[0]);
            Assert.AreEqual("{\"id\":\"vm3\"}", items[1]);
        }

        [Test]
        public void PropagatorV2_ClrAddRemoveAndAppend_NoRoundTrip()
        {
            // Add VMs via CLR, remove one, append another — all without round-trip.
            var model = GetInitialModelV2();
            model.VirtualMachines.Add(new WritableSubResource() { Id = "vm1" });
            model.VirtualMachines.Add(new WritableSubResource() { Id = "vm2" });

            model.Patch.Remove("$.properties.virtualMachines[0]"u8);
            model.Patch.Append("$.properties.virtualMachines"u8, "{\"id\":\"vm3\"}"u8);

            var items = Collect(model.Patch, "$.properties.virtualMachines"u8);
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("{\"id\":\"vm2\"}", items[0]);
            Assert.AreEqual("{\"id\":\"vm3\"}", items[1]);
        }

        [Test]
        public void PropagatorV2_VerifyPropagatorIsSet()
        {
            // Verify V2 model's propagator behavior
            string jsonPayload = File.ReadAllText(
                TestData.GetLocation("AvailabilitySetData/AvailabilitySetDataWireFormat.json")).TrimEnd();
            AvailabilitySetDataV2 model;
            using (var doc = System.Text.Json.JsonDocument.Parse(jsonPayload))
            {
                model = AvailabilitySetDataV2.DeserializeAvailabilitySetDataV2(
                    doc.RootElement,
                    new ModelReaderWriterOptions("W"),
                    BinaryData.FromString(jsonPayload));
            }

            // Test that propagator SET works for an indexed path
            model.VirtualMachines.Add(new WritableSubResource() { Id = "vm1" });
            model.Patch.Remove("$.properties.virtualMachines[0]"u8);
            Assert.IsTrue(model.VirtualMachines[0].Patch.IsRemoved("$"u8),
                "PropagatorSet should have routed the remove to the child model");

            // Test TryGetJson for a seed path (no propagator needed)
            bool hasPlatform = model.Patch.TryGetJson("$.properties.platformUpdateDomainCount"u8, out ReadOnlyMemory<byte> platformVal);
            Assert.IsTrue(hasPlatform, "TryGetJson should find $.properties.platformUpdateDomainCount from seed");
            Assert.AreEqual("5", Encoding.UTF8.GetString(platformVal.ToArray()));

            // Test TryGetJson through propagator GET (sku sub-path)
            bool hasSku = model.Patch.TryGetJson("$.sku.name"u8, out ReadOnlyMemory<byte> skuVal);
            Assert.IsTrue(hasSku, "TryGetJson should find $.sku.name via propagator or seed");
        }

        [Test]
        public void PropagatorV2_ClrOnlyNoRoundTrip()
        {
            // Add VMs via CLR only, no round-trip — V2's enhanced PropagateGet
            // serializes the CLR collection so EnumerateArray can iterate it.
            var model = GetInitialModelV2();
            model.VirtualMachines.Add(new WritableSubResource() { Id = "vm1" });
            model.VirtualMachines.Add(new WritableSubResource() { Id = "vm2" });

            var items = Collect(model.Patch, "$.properties.virtualMachines"u8);
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("{\"id\":\"vm1\"}", items[0]);
            Assert.AreEqual("{\"id\":\"vm2\"}", items[1]);
        }

        [Test]
        public void PropagatorV2_NoRoundTrip_ConsistentWithSerialization()
        {
            // Verify that EnumerateArray without round-trip produces the same result
            // as serializing the model and reading the array from the serialized output.
            var model = GetInitialModelV2();
            model.VirtualMachines.Add(new WritableSubResource() { Id = "vm1" });
            model.VirtualMachines.Add(new WritableSubResource() { Id = "vm2" });
            model.Patch.Append("$.properties.virtualMachines"u8, "{\"id\":\"vm3\"}"u8);

            // Get via EnumerateArray
            string fromEnumerate = JoinAsArray(model.Patch, "$.properties.virtualMachines"u8);

            // Get via serialization + deserialization
            var data = ModelReaderWriter.Write(model);
            var model2 = GetRoundTripModelV2(data);
            string fromRoundTrip = JoinAsArray(model2.Patch, "$.properties.virtualMachines"u8);

            Assert.AreEqual(fromRoundTrip, fromEnumerate);
        }

        #endregion

        #region Category F: Error cases

        [Test]
        public void Error_EmptyPatch()
        {
            JsonPatch jp = new();
            Assert.Throws<KeyNotFoundException>(() =>
            {
                foreach (var _ in jp.EnumerateArray("$.arr"u8)) { }
            });
        }

        [Test]
        public void Error_ObjectAtPath()
        {
            JsonPatch jp = new("{\"obj\":{\"a\":1}}"u8.ToArray());
            Assert.Throws<InvalidOperationException>(() =>
            {
                foreach (var _ in jp.EnumerateArray("$.obj"u8)) { }
            });
        }

        [Test]
        public void Error_PrimitiveAtPath()
        {
            JsonPatch jp = new("{\"x\":42}"u8.ToArray());
            Assert.Throws<InvalidOperationException>(() =>
            {
                foreach (var _ in jp.EnumerateArray("$.x"u8)) { }
            });
        }

        [Test]
        public void Error_NullAtPath()
        {
            JsonPatch jp = new("{\"x\":null}"u8.ToArray());
            Assert.Throws<InvalidOperationException>(() =>
            {
                foreach (var _ in jp.EnumerateArray("$.x"u8)) { }
            });
        }

        [Test]
        public void Error_PathNotFound()
        {
            JsonPatch jp = new("{\"x\":1}"u8.ToArray());
            Assert.Throws<KeyNotFoundException>(() =>
            {
                foreach (var _ in jp.EnumerateArray("$.nonexistent"u8)) { }
            });
        }

        [Test]
        public void Error_RemovedRootThrows()
        {
            JsonPatch jp = new("[1,2,3]"u8.ToArray());
            jp.Remove("$"u8);
            Assert.Throws<KeyNotFoundException>(() =>
            {
                foreach (var _ in jp.EnumerateArray("$"u8)) { }
            });
        }

        [Test]
        public void Error_RemovedNestedArrayThrows()
        {
            JsonPatch jp = new("{\"arr\":[1,2,3]}"u8.ToArray());
            jp.Remove("$.arr"u8);
            Assert.Throws<KeyNotFoundException>(() =>
            {
                foreach (var _ in jp.EnumerateArray("$.arr"u8)) { }
            });
        }

        [Test]
        public void Error_RootObjectNotArray()
        {
            JsonPatch jp = new("{\"a\":1}"u8.ToArray());
            Assert.Throws<InvalidOperationException>(() =>
            {
                foreach (var _ in jp.EnumerateArray("$"u8)) { }
            });
        }

        [Test]
        public void Error_RootPrimitiveNotArray()
        {
            JsonPatch jp = new("42"u8.ToArray());
            Assert.Throws<InvalidOperationException>(() =>
            {
                foreach (var _ in jp.EnumerateArray("$"u8)) { }
            });
        }

        #endregion

        #region Category G: Structural edge cases + consistency

        [Test]
        public void Structural_RootArray()
        {
            JsonPatch jp = new("[1,2,3]"u8.ToArray());

            var items = Collect(jp, "$"u8);
            Assert.AreEqual(3, items.Count);
            Assert.AreEqual("1", items[0]);
            Assert.AreEqual("2", items[1]);
            Assert.AreEqual("3", items[2]);
        }

        [Test]
        public void Structural_NestedObjectReplacement()
        {
            JsonPatch jp = new("{\"arr\":[{\"x\":1},{\"x\":2}]}"u8.ToArray());
            jp.Set("$.arr[0].x"u8, 99);

            var items = Collect(jp, "$.arr"u8);
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("{\"x\":99}", items[0]);
            Assert.AreEqual("{\"x\":2}", items[1]);
        }

        [Test]
        public void Structural_ConsistencyWithGetJson()
        {
            // Test several scenarios and verify EnumerateArray matches GetJson
            // Note: For seed-only and properties-only, GetJson and EnumerateArray should agree.
            // For seed+properties with removes/replaces, EnumerateArray is more accurate
            // (matches serialization output), while GetJson may return stale seed data.

            // Seed only
            JsonPatch jp1 = new("{\"arr\":[1,2,3]}"u8.ToArray());
            Assert.AreEqual(jp1.GetJson("$.arr"u8).ToString(), JoinAsArray(jp1, "$.arr"u8));

            // Seed + append
            JsonPatch jp2 = new("{\"arr\":[1,2]}"u8.ToArray());
            jp2.Append("$.arr"u8, 3);
            Assert.AreEqual(jp2.GetJson("$.arr"u8).ToString(), JoinAsArray(jp2, "$.arr"u8));

            // Properties only (append)
            JsonPatch jp4 = new();
            jp4.Append("$.arr"u8, 10);
            jp4.Append("$.arr"u8, 20);
            Assert.AreEqual(jp4.GetJson("$.arr"u8).ToString(), JoinAsArray(jp4, "$.arr"u8));
        }

        #endregion
    }
}
