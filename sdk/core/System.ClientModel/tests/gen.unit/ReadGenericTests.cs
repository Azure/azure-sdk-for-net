// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.ClientModel.Tests.ModelReaderWriterTests;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using NUnit.Framework;

namespace System.ClientModel.SourceGeneration.Tests.Unit
{
    public class ReadGenericTests
    {
        [Test]
        public void ReadGeneric_ListNotDuplicatedWhenT()
        {
            string source = $$"""
                using System.ClientModel.Primitives;
                using System.Collections.Generic;

                namespace TestProject
                {
                    public partial class LocalContext : ModelReaderWriterContext
                    {
                    }

                    public class JsonModel : IJsonModel<JsonModel>
                    {
                    }

                    public class Caller
                    {
                        public void Call()
                        {
                             ModelReaderWriter.Read<List<JsonModel>>(BinaryData.Empty, new LocalContext());
                             ModelReaderWriter.Read<List<List<JsonModel>>>(BinaryData.Empty, new LocalContext());
                        }
                    }
                }
                """;

            Compilation compilation = CompilationHelper.CreateCompilation(
                source,
                additionalReferences:
                [
                    MetadataReference.CreateFromFile(typeof(List<>).Assembly.Location),
                ]);

            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.AreEqual(0, result.Diagnostics.Length);

            Assert.AreEqual(3, result.ContextFile!.Types.Count);
            var dict = result.ContextFile.Types.ToDictionary(t => t.Type.Name, t => t);

            AssertJsonModel(dict);
            AssertListJsonModel(dict);
            AssertListListJsonModel(dict);
        }

        [Test]
        public void ReadGeneric_ListNotDuplicatedWhenMultiple()
        {
            string source = $$"""
                using System.ClientModel.Primitives;
                using System.Collections.Generic;

                namespace TestProject
                {
                    public partial class LocalContext : ModelReaderWriterContext
                    {
                    }

                    public class JsonModel : IJsonModel<JsonModel>
                    {
                    }

                    public class Caller
                    {
                        public void Call()
                        {
                             ModelReaderWriter.Read<List<JsonModel>>(BinaryData.Empty, new LocalContext());
                             ModelReaderWriter.Read<List<JsonModel>>(BinaryData.Empty, new LocalContext());
                        }
                    }
                }
                """;

            Compilation compilation = CompilationHelper.CreateCompilation(
                source,
                additionalReferences:
                [
                    MetadataReference.CreateFromFile(typeof(List<>).Assembly.Location),
                ]);

            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.AreEqual(0, result.Diagnostics.Length);

            Assert.AreEqual(2, result.ContextFile!.Types.Count);
            var dict = result.ContextFile.Types.ToDictionary(t => t.Type.Name, t => t);

            AssertJsonModel(dict);
            AssertListJsonModel(dict);
        }

        [Test]
        public void ReadGeneric_List()
        {
            string source = $$"""
                using System.ClientModel.Primitives;
                using System.Collections.Generic;

                namespace TestProject
                {
                    public partial class LocalContext : ModelReaderWriterContext
                    {
                    }

                    public class JsonModel : IJsonModel<JsonModel>
                    {
                    }

                    public class Caller
                    {
                        public void Call()
                        {
                             ModelReaderWriter.Read<List<JsonModel>>(BinaryData.Empty, new LocalContext());
                        }
                    }
                }
                """;

            Compilation compilation = CompilationHelper.CreateCompilation(
                source,
                additionalReferences:
                [
                    MetadataReference.CreateFromFile(typeof(List<>).Assembly.Location),
                ]);

            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.AreEqual(0, result.Diagnostics.Length);

            Assert.AreEqual(2, result.ContextFile!.Types.Count);
            var dict = result.ContextFile.Types.ToDictionary(t => t.Type.Name, t => t);

            AssertJsonModel(dict);
            AssertListJsonModel(dict);
        }

        private static void AssertJsonModel(Dictionary<string, TypeGenerationSpec> dict)
        {
            Assert.IsTrue(dict.ContainsKey("JsonModel"));
            var jsonModel = dict["JsonModel"];
            Assert.AreEqual("JsonModel", jsonModel.Type.Name);
            Assert.AreEqual("TestProject", jsonModel.Type.Namespace);
        }

        [Test]
        public void ReadGeneric_ListOfList()
        {
            string source = $$"""
                using System.ClientModel.Primitives;
                using System.Collections.Generic;

                namespace TestProject
                {
                    public partial class LocalContext : ModelReaderWriterContext
                    {
                    }

                    public class JsonModel : IJsonModel<JsonModel>
                    {
                    }

                    public class Caller
                    {
                        public void Call()
                        {
                             ModelReaderWriter.Read<List<List<JsonModel>>>(BinaryData.Empty, new LocalContext());
                        }
                    }
                }
                """;

            Compilation compilation = CompilationHelper.CreateCompilation(
                source,
                additionalReferences:
                [
                    MetadataReference.CreateFromFile(typeof(List<>).Assembly.Location),
                ]);

            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.AreEqual(0, result.Diagnostics.Length);

            Assert.AreEqual(3, result.ContextFile!.Types.Count);
            var dict = result.ContextFile.Types.ToDictionary(t => t.Type.Name, t => t);

            AssertJsonModel(dict);
            AssertListJsonModel(dict);
            AssertListListJsonModel(dict);
        }

        [Test]
        public void ReadGeneric_ListOfList_And_List()
        {
            string source = $$"""
                using System.ClientModel.Primitives;
                using System.Collections.Generic;

                namespace TestProject
                {
                    public partial class LocalContext : ModelReaderWriterContext
                    {
                    }

                    public class JsonModel : IJsonModel<JsonModel>
                    {
                    }

                    public class Caller
                    {
                        public void Call()
                        {
                             ModelReaderWriter.Read<List<JsonModel>>(BinaryData.Empty, new LocalContext());
                             ModelReaderWriter.Read<List<List<JsonModel>>>(BinaryData.Empty, new LocalContext());
                        }
                    }
                }
                """;

            Compilation compilation = CompilationHelper.CreateCompilation(
                source,
                additionalReferences:
                [
                    MetadataReference.CreateFromFile(typeof(List<>).Assembly.Location),
                ]);

            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.AreEqual(0, result.Diagnostics.Length);

            Assert.AreEqual(3, result.ContextFile!.Types.Count);
            var dict = result.ContextFile.Types.ToDictionary(t => t.Type.Name, t => t);

            AssertJsonModel(dict);
            AssertListJsonModel(dict);
            AssertListListJsonModel(dict);
        }

        private void AssertListListJsonModel(Dictionary<string, TypeGenerationSpec> dict)
        {
            Assert.IsTrue(dict.ContainsKey("List<List<JsonModel>>"));
            var listListJsonModel = dict["List<List<JsonModel>>"];
            Assert.AreEqual("List<List<JsonModel>>", listListJsonModel.Type.Name);
            Assert.AreEqual("System.Collections.Generic", listListJsonModel.Type.Namespace);
            Assert.AreEqual(1, listListJsonModel.Type.GenericArguments.Count);
            Assert.AreEqual(ModelInfoKind.IEnumerable, listListJsonModel.Kind);

            var genericArgument = listListJsonModel.Type.GenericArguments[0];
            Assert.AreEqual("List<JsonModel>", genericArgument.Name);
            Assert.AreEqual("System.Collections.Generic", genericArgument.Namespace);
            Assert.AreEqual(1, genericArgument.GenericArguments.Count);

            var innerGenericArgument = genericArgument.GenericArguments[0];
            Assert.AreEqual("JsonModel", innerGenericArgument.Name);
            Assert.AreEqual("TestProject", innerGenericArgument.Namespace);
            Assert.AreEqual(0, innerGenericArgument.GenericArguments.Count);
        }

        private static void AssertListJsonModel(Dictionary<string, TypeGenerationSpec> dict)
        {
            Assert.IsTrue(dict.ContainsKey("List<JsonModel>"));
            var listJsonModel = dict["List<JsonModel>"];
            Assert.AreEqual("List<JsonModel>", listJsonModel.Type.Name);
            Assert.AreEqual("System.Collections.Generic", listJsonModel.Type.Namespace);
            Assert.AreEqual(1, listJsonModel.Type.GenericArguments.Count);
            Assert.AreEqual(ModelInfoKind.IEnumerable, listJsonModel.Kind);

            var genericArgument = listJsonModel.Type.GenericArguments[0];
            Assert.AreEqual("JsonModel", genericArgument.Name);
            Assert.AreEqual("TestProject", genericArgument.Namespace);
            Assert.AreEqual(0, genericArgument.GenericArguments.Count);
        }

        [Test]
        public void ReadGeneric_Array()
        {
            string source = $$"""
                using System.ClientModel.Primitives;

                namespace TestProject
                {
                    public partial class LocalContext : ModelReaderWriterContext
                    {
                    }

                    public class JsonModel : IJsonModel<JsonModel>
                    {
                    }

                    public class Caller
                    {
                        public void Call()
                        {
                             ModelReaderWriter.Read<JsonModel[]>(BinaryData.Empty, new LocalContext());
                        }
                    }
                }
                """;

            Compilation compilation = CompilationHelper.CreateCompilation(source);

            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.AreEqual(0, result.Diagnostics.Length);

            Assert.AreEqual(2, result.ContextFile!.Types.Count);
            var dict = result.ContextFile.Types.ToDictionary(t => t.Type.Name, t => t);

            AssertJsonModel(dict);
            AssertArrayJsonModel(dict);
        }

        [Test]
        public void ReadGeneric_ReadOnlyMemory()
        {
            string source = $$"""
                using System;
                using System.ClientModel.Primitives;

                namespace TestProject
                {
                    public partial class LocalContext : ModelReaderWriterContext
                    {
                    }

                    public class JsonModel : IJsonModel<JsonModel>
                    {
                    }

                    public class Caller
                    {
                        public void Call()
                        {
                             ModelReaderWriter.Read<ReadOnlyMemory<JsonModel>>(BinaryData.Empty, new LocalContext());
                        }
                    }
                }
                """;

            Compilation compilation = CompilationHelper.CreateCompilation(source);

            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.AreEqual(0, result.Diagnostics.Length);

            Assert.AreEqual(2, result.ContextFile!.Types.Count);
            var dict = result.ContextFile.Types.ToDictionary(t => t.Type.Name, t => t);

            AssertJsonModel(dict);
            AssertReadOnlyMemoryJsonModel(dict);
        }

        private void AssertReadOnlyMemoryJsonModel(Dictionary<string, TypeGenerationSpec> dict)
        {
            Assert.IsTrue(dict.ContainsKey("ReadOnlyMemory<JsonModel>"));
            var arrayJsonModel = dict["ReadOnlyMemory<JsonModel>"];
            Assert.AreEqual("ReadOnlyMemory<JsonModel>", arrayJsonModel.Type.Name);
            Assert.AreEqual("System", arrayJsonModel.Type.Namespace);
            Assert.AreEqual(1, arrayJsonModel.Type.GenericArguments.Count);
            Assert.AreEqual(ModelInfoKind.ReadOnlyMemory, arrayJsonModel.Kind);

            var genericArgument = arrayJsonModel.Type.GenericArguments[0];
            Assert.AreEqual("JsonModel", genericArgument.Name);
            Assert.AreEqual("TestProject", genericArgument.Namespace);
            Assert.AreEqual(0, genericArgument.GenericArguments.Count);
        }

        private void AssertArrayJsonModel(Dictionary<string, TypeGenerationSpec> dict)
        {
            Assert.IsTrue(dict.ContainsKey("JsonModel[]"));
            var arrayJsonModel = dict["JsonModel[]"];
            Assert.AreEqual("JsonModel[]", arrayJsonModel.Type.Name);
            Assert.AreEqual("TestProject", arrayJsonModel.Type.Namespace);
            Assert.AreEqual(1, arrayJsonModel.Type.GenericArguments.Count);
            Assert.AreEqual(ModelInfoKind.Array, arrayJsonModel.Kind);

            var genericArgument = arrayJsonModel.Type.GenericArguments[0];
            Assert.AreEqual("JsonModel", genericArgument.Name);
            Assert.AreEqual("TestProject", genericArgument.Namespace);
            Assert.AreEqual(0, genericArgument.GenericArguments.Count);
        }

        [Test]
        public void ReadGeneric_JaggedArray()
        {
            string source = $$"""
                using System.ClientModel.Primitives;

                namespace TestProject
                {
                    public partial class LocalContext : ModelReaderWriterContext
                    {
                    }

                    public class JsonModel : IJsonModel<JsonModel>
                    {
                    }

                    public class Caller
                    {
                        public void Call()
                        {
                             ModelReaderWriter.Read<JsonModel[][]>(BinaryData.Empty, new LocalContext());
                        }
                    }
                }
                """;

            Compilation compilation = CompilationHelper.CreateCompilation(source);

            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.AreEqual(0, result.Diagnostics.Length);

            Assert.AreEqual(3, result.ContextFile!.Types.Count);
            var dict = result.ContextFile.Types.ToDictionary(t => t.Type.Name, t => t);

            AssertJsonModel(dict);
            AssertArrayJsonModel(dict);
            AssertJaggedArrayJsonModel(dict);
        }

        [Test]
        public void ReadGeneric_MultiDimensionalArray()
        {
            string source = $$"""
                using System.ClientModel.Primitives;

                namespace TestProject
                {
                    public partial class LocalContext : ModelReaderWriterContext
                    {
                    }

                    public class JsonModel : IJsonModel<JsonModel>
                    {
                    }

                    public class Caller
                    {
                        public void Call()
                        {
                             ModelReaderWriter.Read<JsonModel[,]>(BinaryData.Empty, new LocalContext());
                        }
                    }
                }
                """;

            Compilation compilation = CompilationHelper.CreateCompilation(source);

            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.AreEqual(0, result.Diagnostics.Length);

            Assert.AreEqual(2, result.ContextFile!.Types.Count);
            var dict = result.ContextFile.Types.ToDictionary(t => t.Type.Name, t => t);

            AssertJsonModel(dict);
            AssertMultiDimensionalArrayJsonModel(dict);
        }

        private void AssertMultiDimensionalArrayJsonModel(Dictionary<string, TypeGenerationSpec> dict)
        {
            Assert.IsTrue(dict.ContainsKey("JsonModel[,]"));
            var arrayJsonModel = dict["JsonModel[,]"];
            Assert.AreEqual("JsonModel[,]", arrayJsonModel.Type.Name);
            Assert.AreEqual("TestProject", arrayJsonModel.Type.Namespace);
            Assert.AreEqual(1, arrayJsonModel.Type.GenericArguments.Count);
            Assert.AreEqual(ModelInfoKind.MultiDimensionalArray, arrayJsonModel.Kind);

            var genericArgument = arrayJsonModel.Type.GenericArguments[0];
            Assert.AreEqual("JsonModel", genericArgument.Name);
            Assert.AreEqual("TestProject", genericArgument.Namespace);
            Assert.AreEqual(0, genericArgument.GenericArguments.Count);
        }

        private void AssertJaggedArrayJsonModel(Dictionary<string, TypeGenerationSpec> dict)
        {
            Assert.IsTrue(dict.ContainsKey("JsonModel[][]"));
            var arrayJsonModel = dict["JsonModel[][]"];
            Assert.AreEqual("JsonModel[][]", arrayJsonModel.Type.Name);
            Assert.AreEqual("TestProject", arrayJsonModel.Type.Namespace);
            Assert.AreEqual(1, arrayJsonModel.Type.GenericArguments.Count);
            Assert.AreEqual(ModelInfoKind.Array, arrayJsonModel.Kind);

            var genericArgument = arrayJsonModel.Type.GenericArguments[0];
            Assert.AreEqual("JsonModel[]", genericArgument.Name);
            Assert.AreEqual("TestProject", genericArgument.Namespace);
            Assert.AreEqual(1, genericArgument.GenericArguments.Count);

            var genericArgument2 = genericArgument.GenericArguments[0];
            Assert.AreEqual("JsonModel", genericArgument2.Name);
            Assert.AreEqual("TestProject", genericArgument2.Namespace);
            Assert.AreEqual(0, genericArgument2.GenericArguments.Count);
        }

        [Test]
        public void ReadGeneric_List_ImplicitContext()
        {
            string source = $$"""
                using System.ClientModel.Primitives;
                using System.Collections.Generic;

                namespace TestProject
                {
                    public class JsonModel : IJsonModel<JsonModel>
                    {
                    }

                    public class Caller
                    {
                        public void Call()
                        {
                             ModelReaderWriter.Read<List<JsonModel>>(BinaryData.Empty, new LocalContext());
                        }
                    }
                }
                """;

            Compilation compilation = CompilationHelper.CreateCompilation(
                source,
                additionalReferences:
                [
                    MetadataReference.CreateFromFile(typeof(List<>).Assembly.Location),
                ]);

            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.AreEqual(0, result.Diagnostics.Length);

            Assert.AreEqual(2, result.ContextFile!.Types.Count);
            var dict = result.ContextFile.Types.ToDictionary(t => t.Type.Name, t => t);

            Assert.IsTrue(dict.ContainsKey("JsonModel"));
            var jsonModel = dict["JsonModel"];
            Assert.AreEqual("JsonModel", jsonModel.Type.Name);
            Assert.AreEqual("TestProject", jsonModel.Type.Namespace);

            Assert.IsTrue(dict.ContainsKey("List<JsonModel>"));
            var listJsonModel = dict["List<JsonModel>"];
            Assert.AreEqual("List<JsonModel>", listJsonModel.Type.Name);
            Assert.AreEqual("System.Collections.Generic", listJsonModel.Type.Namespace);
            Assert.AreEqual(1, listJsonModel.Type.GenericArguments.Count);
            Assert.AreEqual(ModelInfoKind.IEnumerable, listJsonModel.Kind);

            var genericArgument = listJsonModel.Type.GenericArguments[0];
            Assert.AreEqual("JsonModel", genericArgument.Name);
            Assert.AreEqual("TestProject", genericArgument.Namespace);
            Assert.AreEqual(0, genericArgument.GenericArguments.Count);
        }

        [Test]
        public void ReadGeneric_List_FromDependency()
        {
            string source = $$"""
                using System.ClientModel.Primitives;
                using System.Collections.Generic;
                using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;

                namespace TestProject
                {
                    public partial class LocalContext : ModelReaderWriterContext
                    {
                    }

                    public class Caller
                    {
                        public void Call()
                        {
                             ModelReaderWriter.Read<List<AvailabilitySetData>>(data);
                        }
                    }
                }
                """;

            Compilation compilation = CompilationHelper.CreateCompilation(
                source,
                additionalReferences:
                [
                    MetadataReference.CreateFromFile(typeof(TestClientModelReaderWriterContext).Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(AvailabilitySetData).Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(List<>).Assembly.Location),
                ]);

            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.AreEqual(0, result.Diagnostics.Length);

            Assert.AreEqual(2, result.ContextFile!.Types.Count);
            var dict = result.ContextFile.Types.ToDictionary(t => t.Type.Name, t => t);

            AssertListAvailabilitySetData(dict);
            AssertAvailabilitySetData(dict);
        }

        private static void AssertListAvailabilitySetData(Dictionary<string, TypeGenerationSpec> dict)
        {
            Assert.IsTrue(dict.ContainsKey("List<AvailabilitySetData>"));
            var type = dict["List<AvailabilitySetData>"];
            Assert.AreEqual("List<AvailabilitySetData>", type.Type.Name);
            Assert.AreEqual("System.Collections.Generic", type.Type.Namespace);
            Assert.AreEqual(1, type.Type.GenericArguments.Count);
            Assert.AreEqual(ModelInfoKind.IEnumerable, type.Kind);

            var genericArgument = type.Type.GenericArguments[0];
            Assert.AreEqual("AvailabilitySetData", genericArgument.Name);
            Assert.AreEqual("System.ClientModel.Tests.Client.Models.ResourceManager.Compute", genericArgument.Namespace);
            Assert.AreEqual(0, genericArgument.GenericArguments.Count);
        }

        [Test]
        public void ReadGeneric_Dictionary()
        {
            string source = $$"""
                using System.ClientModel.Primitives;
                using System.Collections.Generic;
                using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;

                namespace TestProject
                {
                    public partial class LocalContext : ModelReaderWriterContext
                    {
                    }

                    public class Caller
                    {
                        public void Call()
                        {
                             ModelReaderWriter.Read<Dictionary<string, AvailabilitySetData>>(data);
                        }
                    }
                }
                """;

            Compilation compilation = CompilationHelper.CreateCompilation(
                source,
                additionalReferences:
                [
                    MetadataReference.CreateFromFile(typeof(TestClientModelReaderWriterContext).Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(AvailabilitySetData).Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(Dictionary<,>).Assembly.Location),
                ]);

            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.AreEqual(0, result.Diagnostics.Length);

            Assert.AreEqual(2, result.ContextFile!.Types.Count);
            var dict = result.ContextFile.Types.ToDictionary(t => t.Type.Name, t => t);

            AssertDictAvailabilitySetData(dict);
            AssertAvailabilitySetData(dict);
        }

        private void AssertAvailabilitySetData(Dictionary<string, TypeGenerationSpec> dict)
        {
            Assert.IsTrue(dict.ContainsKey(nameof(AvailabilitySetData)));
            var type = dict[nameof(AvailabilitySetData)];
            Assert.AreEqual("AvailabilitySetData", type.Type.Name);
            Assert.AreEqual("System.ClientModel.Tests.Client.Models.ResourceManager.Compute", type.Type.Namespace);
            Assert.AreEqual(0, type.Type.GenericArguments.Count);
        }

        private static void AssertDictAvailabilitySetData(Dictionary<string, TypeGenerationSpec> dict)
        {
            Assert.IsTrue(dict.ContainsKey("Dictionary<string, AvailabilitySetData>"));
            var firstType = dict["Dictionary<string, AvailabilitySetData>"];
            Assert.AreEqual("Dictionary<string, AvailabilitySetData>", firstType.Type.Name);
            Assert.AreEqual("System.Collections.Generic", firstType.Type.Namespace);
            Assert.AreEqual(2, firstType.Type.GenericArguments.Count);
            Assert.AreEqual(ModelInfoKind.IDictionary, firstType.Kind);

            var genericArgument = firstType.Type.GenericArguments[1];
            Assert.AreEqual("AvailabilitySetData", genericArgument.Name);
            Assert.AreEqual("System.ClientModel.Tests.Client.Models.ResourceManager.Compute", genericArgument.Namespace);
            Assert.AreEqual(0, genericArgument.GenericArguments.Count);
        }
    }
}
