// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis.Text;

namespace System.ClientModel.SourceGeneration;

internal sealed partial class ModelReaderWriterContextGenerator
{
    private sealed partial class Emitter
    {
        private const string s_modelReaderWriterContext = "global::System.ClientModel.Primitives.ModelReaderWriterContext";
        private const string s_modelReaderWriterTypeBuilder = "global::System.ClientModel.Primitives.ModelReaderWriterTypeBuilder";

        internal void Emit(ModelReaderWriterContextGenerationSpec contextGenerationSpec)
        {
            EmitContextClass(contextGenerationSpec);

            foreach (var modelInfo in contextGenerationSpec.TypeBuilders)
            {
                EmitTypeBuilder(modelInfo, contextGenerationSpec.Type);
            }
        }

        private void EmitContextClass(ModelReaderWriterContextGenerationSpec contextGenerationSpec)
        {
            var contextName = contextGenerationSpec.Type.Name;
            var namespaces = GetNameSpaces(contextGenerationSpec);

            var indent = 0;
            var builder = new StringBuilder();
            EmitHeader(indent, builder);

            foreach (var nameSpace in namespaces)
            {
                builder.AppendLine(indent, $"using {nameSpace};");
            }
            builder.AppendLine();

            builder.AppendLine(indent, $"namespace {contextGenerationSpec.Type.Namespace};");
            builder.AppendLine();

            builder.AppendLine(indent, $"{contextGenerationSpec.Modifier} partial class {contextName} : {s_modelReaderWriterContext}");
            builder.AppendLine(indent, "{");
            indent++;

            builder.Append(indent, "private readonly ");
            builder.AppendType(typeof(Dictionary<,>));
            builder.Append("<");
            builder.AppendType(typeof(Type));
            builder.Append(", ");
            builder.AppendType(typeof(Func<>));
            builder.Append("<");
            builder.AppendLine($"{s_modelReaderWriterTypeBuilder}>> _typeBuilderFactories = new();");

            builder.Append(indent, "private readonly ");
            builder.AppendType(typeof(Dictionary<,>));
            builder.Append("<");
            builder.AppendType(typeof(Type));
            builder.Append(", ");
            builder.AppendLine($"{s_modelReaderWriterTypeBuilder}> _typeBuilders = new();");
            builder.AppendLine();

            if (contextGenerationSpec.ReferencedContexts.Count > 0)
            {
                builder.Append(indent, "private static readonly ");
                builder.AppendType(typeof(Dictionary<,>));
                builder.Append("<");
                builder.AppendType(typeof(Type));
                builder.Append(", ");
                builder.Append(s_modelReaderWriterContext);
                builder.AppendLine("> s_referenceContexts = new()");
                builder.AppendLine(indent, "{");
                indent++;
                foreach (var referencedContext in contextGenerationSpec.ReferencedContexts)
                {
                    builder.AppendLine(indent, $"{{ typeof({referencedContext.FullyQualifiedName}), new {referencedContext.FullyQualifiedName}() }},");
                }
                indent--;
                builder.AppendLine(indent, "};");
                builder.AppendLine();
            }

            builder.AppendLine(indent, $"private static {contextName} _{contextName.ToCamelCase()};");
            builder.AppendLine(indent, "/// <summary> Gets the default instance </summary>");
            builder.AppendLine(indent, $"public static {contextName} Default => _{contextName.ToCamelCase()} ??= new();");
            builder.AppendLine();

            builder.AppendLine(indent, $"private {contextName}()");
            builder.AppendLine(indent, "{");
            indent++;
            foreach (var modelInfo in contextGenerationSpec.TypeBuilders)
            {
                builder.Append(indent, $"_typeBuilderFactories.Add(typeof({modelInfo.Type.FullyQualifiedName}), () => ");
                if (ShouldGenerateAsLocal(contextGenerationSpec, modelInfo))
                {
                    builder.AppendLine($" new global::{modelInfo.Type.GetInnerItemType().Namespace}.{modelInfo.Type.TypeCaseName}Builder());");
                }
                else
                {
                    builder.AppendLine($" s_referenceContexts[typeof({modelInfo.ContextType.FullyQualifiedName})].GetTypeBuilder(typeof({modelInfo.Type.FullyQualifiedName})));");
                }
            }
            builder.AppendLine();

            builder.AppendLine(indent, "AddAdditionalFactories(_typeBuilderFactories);");

            indent--;
            builder.AppendLine(indent, "}");
            builder.AppendLine();

            builder.AppendLine(indent, "/// <inheritdoc/>");
            builder.Append(indent, "protected override bool TryGetTypeBuilderCore(");
            builder.AppendType(typeof(Type));
            builder.AppendLine($" type, out {s_modelReaderWriterTypeBuilder} builder)");
            builder.AppendLine(indent, "{");
            indent++;
            builder.AppendLine(indent, "if (_typeBuilders.TryGetValue(type, out builder))");
            builder.AppendLine(indent, "{");
            indent++;
            builder.AppendLine(indent, "return true;");
            indent--;
            builder.AppendLine(indent, "}");
            builder.AppendLine();
            builder.AppendLine(indent, "if (_typeBuilderFactories.TryGetValue(type, out var factory))");
            builder.AppendLine(indent, "{");
            indent++;
            builder.AppendLine(indent, "builder = factory();");
            builder.AppendLine(indent, "_typeBuilders.Add(type, builder);");
            builder.AppendLine(indent, "return true;");
            indent--;
            builder.AppendLine(indent, "}");
            builder.AppendLine();
            if (contextGenerationSpec.ReferencedContexts.Count > 0)
            {
                builder.AppendLine(indent, "foreach(var kvp in s_referenceContexts)");
                builder.AppendLine(indent, "{");
                indent++;
                builder.AppendLine(indent, $"if (kvp.Value.TryGetTypeBuilder(type, out builder))");
                builder.AppendLine(indent, "{");
                indent++;
                builder.AppendLine(indent, $"_typeBuilders.Add(type, builder);");
                builder.AppendLine(indent, "return true;");
                indent--;
                builder.AppendLine(indent, "}");
                indent--;
                builder.AppendLine(indent, "}");
                builder.AppendLine();
            }
            else
            {
                builder.AppendLine(indent, $"builder = null;");
            }
            builder.AppendLine(indent, "return false;");
            indent--;
            builder.AppendLine(indent, "}");
            builder.AppendLine();

            builder.Append(indent, "partial void AddAdditionalFactories(");
            builder.AppendType(typeof(Dictionary<,>));
            builder.Append("<");
            builder.AppendType(typeof(Type));
            builder.Append(", ");
            builder.AppendType(typeof(Func<>));
            builder.Append("<");
            builder.Append(s_modelReaderWriterTypeBuilder);
            builder.AppendLine(">> factories);");

            indent--;
            builder.AppendLine(indent, "}");

            AddSource($"{contextName}.g.cs", SourceText.From(builder.ToString(), Encoding.UTF8));
        }

        private static void EmitHeader(int indent, StringBuilder builder)
        {
            builder.AppendLine("// <auto-generated/>");
            builder.AppendLine();

            builder.AppendLine(indent, "#nullable disable");
            builder.AppendLine();
        }

        private static bool ShouldGenerateAsLocal(ModelReaderWriterContextGenerationSpec contextGenerationSpec, TypeBuilderSpec modelInfo)
        {
            return modelInfo.Kind == TypeBuilderKind.Array ||
                modelInfo.Kind == TypeBuilderKind.MultiDimensionalArray ||
                contextGenerationSpec.Type.Equals(modelInfo.ContextType);
        }

        private void EmitTypeBuilder(TypeBuilderSpec modelInfo, TypeRef context)
        {
            if (modelInfo.Kind == TypeBuilderKind.IPersistableModel && !context.IsSameAssembly(modelInfo.Type))
            {
                return;
            }

            var indent = 0;
            var builder = new StringBuilder();
            EmitHeader(indent, builder);
            var innerItemType = modelInfo.Type.GetInnerItemType();
            var namespaces = GetNamespaces(modelInfo);
            namespaces.Remove(innerItemType.Namespace);

            foreach (var nameSpace in namespaces)
            {
                builder.AppendLine(indent, $"using {nameSpace};");
            }
            builder.AppendLine();

            builder.AppendLine(indent, $"namespace {innerItemType.Namespace};");
            builder.AppendLine();

            builder.AppendLine(indent, $"internal class {modelInfo.Type.TypeCaseName}Builder : ModelReaderWriterTypeBuilder");
            builder.AppendLine(indent, "{");
            indent++;

            switch (modelInfo.Kind)
            {
                case TypeBuilderKind.IPersistableModel:
                    EmitPersistableModelBuilder(indent, builder, modelInfo, context);
                    break;
                case TypeBuilderKind.IList:
                    EmitListBuilder(indent, builder, modelInfo);
                    break;
                case TypeBuilderKind.IDictionary:
                    EmitDictionaryBuilder(indent, builder, modelInfo);
                    break;
                case TypeBuilderKind.Array:
                    EmitArrayBuilder(indent, builder, modelInfo);
                    break;
                case TypeBuilderKind.MultiDimensionalArray:
                    EmitMultiDimensionalArrayBuilder(indent, builder, modelInfo);
                    break;
                case TypeBuilderKind.ReadOnlyMemory:
                    EmitReadOnlyMemoryBuilder(indent, builder, modelInfo);
                    break;
                default:
                    break;
            }

            indent--;
            builder.AppendLine(indent, "}");

            AddSource($"{innerItemType.Namespace.Replace('.', '_')}_{modelInfo.Type.TypeCaseName}Builder.g.cs", SourceText.From(builder.ToString(), Encoding.UTF8));
        }

        private static HashSet<string> GetNamespaces(TypeBuilderSpec modelInfo)
        {
            HashSet<string> namespaces =
            [
                "System",
                "System.ClientModel.Primitives",
            ];
            switch (modelInfo.Kind)
            {
                case TypeBuilderKind.ReadOnlyMemory:
                    namespaces.Add("System.Collections");
                    namespaces.Add("System.Collections.Generic");
                    break;
                case TypeBuilderKind.Array:
                    namespaces.Add("System.Collections.Generic");
                    break;
                case TypeBuilderKind.IDictionary:
                    namespaces.Add("System.Collections.Generic");
                    break;
                case TypeBuilderKind.MultiDimensionalArray:
                    namespaces.Add("System.Collections.Generic");
                    break;
            }
            HashSet<TypeRef> visited = [];
            AddNamespaces(namespaces, modelInfo.Type, visited);
            if (modelInfo.PersistableModelProxy is not null)
            {
                AddNamespaces(namespaces, modelInfo.PersistableModelProxy, visited);
            }
            return namespaces;
        }

        private static void EmitReadOnlyMemoryBuilder(
            int indent,
            StringBuilder builder,
            TypeBuilderSpec modelInfo)
        {
            var elementType = modelInfo.Type.ItemType!;
            builder.AppendLine(indent, $"protected override Type BuilderType => typeof(List<{elementType.Name}>);");
            builder.AppendLine();

            builder.AppendLine(indent, $"protected override Type ItemType => typeof({elementType.Name});");
            builder.AppendLine();

            builder.AppendLine(indent, $"protected override object CreateInstance() => new List<{elementType.Name}>();");
            builder.AppendLine();

            builder.AppendLine(indent, "protected override void AddItem(object collection, object item)");
            indent++;
            builder.AppendLine(indent, $"=> ((List<{elementType.Name}>)collection).Add(({elementType.Name})item);");
            indent--;
            builder.AppendLine();

            builder.AppendLine(indent, "protected override object ToCollection(object builder)");
            indent++;
            builder.AppendLine(indent, $"=> new {modelInfo.Type.Name}([.. (List<{elementType.Name}>)builder]);");
            indent--;
            builder.AppendLine();

            builder.AppendLine(indent, "protected override IEnumerable GetItems(object obj)");
            builder.AppendLine(indent, "{");
            indent++;
            builder.AppendLine(indent, $"if (obj is {modelInfo.Type.Name} rom)");
            builder.AppendLine(indent, "{");
            indent++;
            builder.AppendLine(indent, "for (int i = 0; i < rom.Length; i++)");
            builder.AppendLine(indent, "{");
            indent++;
            builder.AppendLine(indent, "yield return rom.Span[i];");
            indent--;
            builder.AppendLine(indent, "}");
            indent--;
            builder.AppendLine(indent, "}");
            builder.AppendLine(indent, "yield break;");
            indent--;
            builder.AppendLine(indent, "}");
        }

        private static void EmitMultiDimensionalArrayBuilder(
            int indent,
            StringBuilder builder,
            TypeBuilderSpec modelInfo)
        {
            var elementType = modelInfo.Type.ItemType!;
            builder.Append(indent, "protected override Type BuilderType => typeof(");
            builder.AppendVariableList(modelInfo.Type.ArrayRank, elementType.Name);
            builder.AppendLine(");");
            builder.AppendLine();

            builder.Append(indent, "protected override Type ItemType => typeof(");
            builder.AppendVariableList(modelInfo.Type.ArrayRank - 1, elementType.Name);
            builder.AppendLine(");");
            builder.AppendLine();

            builder.Append(indent, "protected override object CreateInstance() => new ");
            builder.AppendVariableList(modelInfo.Type.ArrayRank, elementType.Name);
            builder.AppendLine("();");
            builder.AppendLine();

            builder.AppendLine(indent, "protected override void AddItem(object collection, object item)");
            indent++;
            builder.Append(indent, "=> ((");
            builder.AppendVariableList(modelInfo.Type.ArrayRank, elementType.Name);
            builder.Append(")collection).Add((");
            builder.AppendVariableList(modelInfo.Type.ArrayRank - 1, elementType.Name);
            builder.AppendLine(")item);");
            indent--;
            builder.AppendLine();

            builder.AppendLine(indent, "protected override object ToCollection(object builder)");
            builder.AppendLine(indent, "{");
            indent++;
            builder.Append(indent, "var instance = (");
            builder.AppendVariableList(modelInfo.Type.ArrayRank, elementType.Name);
            builder.AppendLine(")builder;");
            builder.AppendLine(indent, "int rowCount = instance.Count;");
            builder.AppendLine(indent, "int colCount = instance[0].Count;");
            builder.AppendLine(indent, $"{modelInfo.Type.Name} multiArray = new {elementType.Name}[rowCount, colCount];");
            builder.AppendLine();
            builder.AppendLine(indent, "for (int i = 0; i < rowCount; i++)");
            builder.AppendLine(indent, "{");
            indent++;
            builder.AppendLine(indent, "for (int j = 0; j < colCount; j++)");
            builder.AppendLine(indent, "{");
            indent++;
            builder.AppendLine(indent, "multiArray[i, j] = instance[i][j];");
            indent--;
            builder.AppendLine(indent, "}");
            indent--;
            builder.AppendLine(indent, "}");
            builder.AppendLine(indent, "return multiArray;");
            indent--;
            builder.AppendLine(indent, "}");
        }

        private static void EmitArrayBuilder(
            int indent,
            StringBuilder builder,
            TypeBuilderSpec modelInfo)
        {
            var elementType = modelInfo.Type.ItemType!;
            builder.AppendLine(indent, $"protected override Type BuilderType => typeof(List<{elementType.Name}>);");
            builder.AppendLine();

            builder.AppendLine(indent, $"protected override Type ItemType => typeof({elementType.Name});");
            builder.AppendLine();

            builder.AppendLine(indent, $"protected override object CreateInstance() => new List<{elementType.Name}>();");
            builder.AppendLine();

            builder.AppendLine(indent, "protected override void AddItem(object collection, object item)");
            indent++;
            builder.AppendLine(indent, $"=> ((List<{elementType.Name}>)collection).Add(({elementType.Name})item);");
            indent--;
            builder.AppendLine();

            builder.AppendLine(indent, "protected override object ToCollection(object builder)");
            indent++;
            builder.AppendLine(indent, $"=> ((List<{elementType.Name}>)builder).ToArray();");
            indent--;
        }

        private static void EmitDictionaryBuilder(
            int indent,
            StringBuilder builder,
            TypeBuilderSpec modelInfo)
        {
            var elementType = modelInfo.Type.ItemType!;
            builder.AppendLine(indent, $"protected override Type BuilderType => typeof(Dictionary<string, {elementType.Name}>);");
            builder.AppendLine();

            builder.AppendLine(indent, $"protected override Type ItemType => typeof({elementType.Name});");
            builder.AppendLine();

            builder.AppendLine(indent, $"protected override object CreateInstance() => new Dictionary<string, {elementType.Name}>();");
            builder.AppendLine();

            builder.AppendLine(indent, "protected override void AddKeyValuePair(object collection, string key, object item)");
            indent++;
            builder.AppendLine(indent, $"=> ((Dictionary<string, {elementType.Name}>)collection).Add(key, ({elementType.Name})item);");
            indent--;
        }

        private static void EmitListBuilder(
            int indent,
            StringBuilder builder,
            TypeBuilderSpec modelInfo)
        {
            var elementType = modelInfo.Type.ItemType!;

            builder.AppendLine(indent, $"protected override Type BuilderType => typeof({modelInfo.Type.Name});");
            builder.AppendLine();

            builder.AppendLine(indent, $"protected override Type ItemType => typeof({elementType.Name});");
            builder.AppendLine();

            builder.AppendLine(indent, $"protected override object CreateInstance() => new {modelInfo.Type.Name}();");
            builder.AppendLine();

            builder.AppendLine(indent, "protected override void AddItem(object collection, object item)");
            indent++;
            builder.AppendLine(indent, $"=> (({modelInfo.Type.Name})collection).Add(({elementType.Name})item);");
            indent--;
        }

        private static void EmitPersistableModelBuilder(
            int indent,
            StringBuilder builder,
            TypeBuilderSpec modelInfo,
            TypeRef context)
        {
            builder.AppendLine(indent, $"protected override Type BuilderType => typeof({modelInfo.Type.Name});");
            builder.AppendLine();

            if (modelInfo.PersistableModelProxy is not null)
            {
                builder.AppendLine(indent, $"protected override object CreateInstance() => new {modelInfo.PersistableModelProxy.Name}();");
            }
            else
            {
                builder.AppendLine(indent, $"protected override object CreateInstance() => new {modelInfo.Type.Name}();");
            }
        }

        private HashSet<string> GetNameSpaces(ModelReaderWriterContextGenerationSpec contextGenerationSpec)
        {
            HashSet<string> namespaces =
            [
                "System",
                "System.ClientModel.Primitives",
                "System.Collections",
                "System.Collections.Generic",
            ];

            HashSet<TypeRef> visited = [];

            foreach (var referencedContext in contextGenerationSpec.ReferencedContexts)
            {
                AddNamespaces(namespaces, referencedContext, visited);
            }

            foreach (var type in contextGenerationSpec.TypeBuilders)
            {
                AddNamespaces(namespaces, type.Type, visited);
            }
            return namespaces;
        }

        private static void AddNamespaces(HashSet<string> namespaces, TypeRef type, HashSet<TypeRef> visited)
        {
            if (!visited.Add(type))
            {
                return;
            }

            namespaces.Add(type.Namespace);
            if (type.ItemType is not null)
            {
                AddNamespaces(namespaces, type.ItemType, visited);
            }
        }

        private partial void AddSource(string hintName, SourceText sourceText);
    }
}
