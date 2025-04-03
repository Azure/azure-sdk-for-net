// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis.Text;

namespace System.ClientModel.SourceGeneration;

internal sealed partial class ModelReaderWriterContextGenerator
{
    private sealed partial class Emitter
    {
        internal void Emit(ModelReaderWriterContextGenerationSpec contextGenerationSpec)
        {
            Dictionary<string, TypeRef> referenceContextLookup = contextGenerationSpec.ReferencedContexts.ToDictionary(x => x.Assembly, x => x);
            Dictionary<TypeRef, (string TypeCase, string CamelCase)> identifierLookup = contextGenerationSpec.ReferencedContexts.ToDictionary(
                x => x,
                x =>
                {
                    var id = x.Name.ToIdentifier(false);
                    return (id, id.ToCamelCase());
                });
            foreach (var modelInfo in contextGenerationSpec.TypeBuilders)
            {
                var id = modelInfo.Type.Name.ToIdentifier(false);
                identifierLookup.Add(modelInfo.Type, (id, id.ToCamelCase()));
            }

            string contextName = contextGenerationSpec.Type.Name;
            var namespaces = GetNameSpaces(contextGenerationSpec);

            int indent = 0;
            StringBuilder builder = new();
            builder.AppendLine(indent, "#nullable disable");
            builder.AppendLine();

            foreach (var nameSpace in namespaces)
            {
                builder.AppendLine(indent, $"using {nameSpace};");
            }
            builder.AppendLine();

            builder.AppendLine(indent, $"namespace {contextGenerationSpec.Type.Namespace};");
            builder.AppendLine();

            builder.AppendLine(indent, $"{contextGenerationSpec.Modifier} partial class {contextName} : ModelReaderWriterContext");
            builder.AppendLine(indent, "{");
            indent++;

            builder.AppendLine(indent, "private readonly Dictionary<Type, Func<ModelReaderWriterTypeBuilder>> _typeBuilderFactories = [];");
            builder.AppendLine();

            if (contextGenerationSpec.ReferencedContexts.Count > 0)
            {
                foreach (var referencedContext in contextGenerationSpec.ReferencedContexts)
                {
                    builder.AppendLine(indent, $"private static readonly {referencedContext.Name} s_{identifierLookup[referencedContext].CamelCase}Library = new();");
                }
                builder.AppendLine();
            }

            if (contextGenerationSpec.TypeBuilders.Count > 0)
            {
                foreach (var modelInfo in contextGenerationSpec.TypeBuilders)
                {
                    builder.Append(indent, "private ");
                    if (ShouldGenerateAsLocal(contextGenerationSpec, referenceContextLookup, modelInfo))
                    {
                        builder.Append($"{identifierLookup[modelInfo.Type].TypeCase}Builder ");
                    }
                    else
                    {
                        builder.Append("ModelReaderWriterTypeBuilder ");
                    }
                    builder.AppendLine($"_{identifierLookup[modelInfo.Type].CamelCase}Builder;");
                }
                builder.AppendLine();

                builder.AppendLine(indent, $"private static {contextName} _{contextName.ToCamelCase()};");
                builder.AppendLine(indent, $"public static {contextName} Default => _{contextName.ToCamelCase()} ??= new();");
                builder.AppendLine();

                builder.AppendLine(indent, $"private {contextName}()");
                builder.AppendLine(indent, "{");
                indent++;
                foreach (var modelInfo in contextGenerationSpec.TypeBuilders)
                {
                    builder.Append(indent, $"_typeBuilderFactories.Add(typeof({modelInfo!.Type.Name}), () => _{identifierLookup[modelInfo.Type].CamelCase}Builder ??=");
                    if (ShouldGenerateAsLocal(contextGenerationSpec, referenceContextLookup, modelInfo))
                    {
                        builder.AppendLine(" new());");
                    }
                    else
                    {
                        builder.AppendLine($" s_{identifierLookup[referenceContextLookup[modelInfo.Type.Assembly]].CamelCase}Library.GetTypeBuilder(typeof({modelInfo.Type.Name})));");
                    }
                }
                builder.AppendLine();

                builder.AppendLine(indent, "AddAdditionalFactories(_typeBuilderFactories);");

                indent--;
                builder.AppendLine(indent, "}");
                builder.AppendLine();
            }

            builder.AppendLine(indent, "protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)");
            builder.AppendLine(indent, "{");
            indent++;
            builder.AppendLine(indent, "if (_typeBuilderFactories.TryGetValue(type, out var factory))");
            builder.AppendLine(indent, "{");
            indent++;
            builder.AppendLine(indent, "builder = factory();");
            builder.AppendLine(indent, "return true;");
            indent--;
            builder.AppendLine(indent, "}");
            builder.AppendLine();
            if (contextGenerationSpec.ReferencedContexts.Count > 0)
            {
                for (int i = 0; i < contextGenerationSpec.ReferencedContexts.Count; i++)
                {
                    var referencedContext = contextGenerationSpec.ReferencedContexts[i];
                    builder.AppendLine(indent, $"if (s_{identifierLookup[referencedContext].CamelCase}Library.TryGetTypeBuilder(type, out builder))");
                    builder.AppendLine(indent, "{");
                    indent++;
                    builder.AppendLine(indent, "return true;");
                    indent--;
                    builder.AppendLine(indent, "}");
                }
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

            builder.AppendLine(indent, $"partial void AddAdditionalFactories(Dictionary<Type, Func<ModelReaderWriterTypeBuilder>> factories);");
            builder.AppendLine();

            foreach (var modelInfo in contextGenerationSpec.TypeBuilders)
            {
                EmitModelInfo(indent, builder, modelInfo, contextGenerationSpec.Type, referenceContextLookup, identifierLookup);
                builder.AppendLine();
            }
            builder.RemoveLastLine();

            indent--;
            builder.AppendLine(indent, "}");

            AddSource($"{contextName}.g.cs", SourceText.From(builder.ToString(), Encoding.UTF8));
        }

        private static bool ShouldGenerateAsLocal(ModelReaderWriterContextGenerationSpec contextGenerationSpec, Dictionary<string, TypeRef> referenceContextLookup, TypeBuilderSpec modelInfo)
        {
            return modelInfo.Kind == TypeBuilderKind.Array ||
                modelInfo.Kind == TypeBuilderKind.MultiDimensionalArray ||
                !referenceContextLookup.ContainsKey(modelInfo.Type.Assembly) ||
                IsSameAssembly(contextGenerationSpec.Type, modelInfo.Type);
        }

        private static void EmitModelInfo(
            int indent,
            StringBuilder builder,
            TypeBuilderSpec modelInfo,
            TypeRef context,
            Dictionary<string, TypeRef> referenceContextLookup,
            Dictionary<TypeRef, (string TypeCase, string CamelCase)> identifierLookup)
        {
            switch (modelInfo.Kind)
            {
                case TypeBuilderKind.IPersistableModel:
                    EmitPersistableModelInfo(indent, builder, modelInfo, context, identifierLookup);
                    break;
                case TypeBuilderKind.IList:
                    EmitEnumerableModelInfo(indent, builder, modelInfo, context, referenceContextLookup, identifierLookup);
                    break;
                case TypeBuilderKind.IDictionary:
                    EmitDictionaryModelInfo(indent, builder, modelInfo, context, referenceContextLookup, identifierLookup);
                    break;
                case TypeBuilderKind.Array:
                    EmitArrayModelInfo(indent, builder, modelInfo, context, referenceContextLookup, identifierLookup);
                    break;
                case TypeBuilderKind.MultiDimensionalArray:
                    EmitMultiDimensionalArrayModelInfo(indent, builder, modelInfo, context, referenceContextLookup, identifierLookup);
                    break;
                case TypeBuilderKind.ReadOnlyMemory:
                    EmitReadOnlyMemoryModelInfo(indent, builder, modelInfo, context, referenceContextLookup, identifierLookup);
                    break;
                default:
                    //give warning and skip
                    break;
            }
        }

        private static void EmitReadOnlyMemoryModelInfo(
            int indent,
            StringBuilder builder,
            TypeBuilderSpec modelInfo,
            TypeRef context,
            Dictionary<string, TypeRef> referenceContextLookup,
            Dictionary<TypeRef, (string TypeCase, string CamelCase)> identifierLookup)
        {
            var elementType = modelInfo.Type.GenericArguments[0];
            builder.AppendLine(indent, $"internal class {identifierLookup[modelInfo.Type].TypeCase}Builder : ModelReaderWriterTypeBuilder");
            builder.AppendLine(indent, "{");
            indent++;

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

            indent--;
            builder.AppendLine(indent, "}");
        }

        private static void EmitMultiDimensionalArrayModelInfo(
            int indent,
            StringBuilder builder,
            TypeBuilderSpec modelInfo,
            TypeRef context,
            Dictionary<string, TypeRef> referenceContextLookup,
            Dictionary<TypeRef, (string TypeCase, string CamelCase)> identifierLookup)
        {
            var elementType = modelInfo.Type.GenericArguments[0];
            builder.AppendLine(indent, $"internal class {identifierLookup[modelInfo.Type].TypeCase}Builder : ModelReaderWriterTypeBuilder");
            builder.AppendLine(indent, "{");
            indent++;

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

            indent--;
            builder.AppendLine(indent, "}");
        }

        private static void EmitArrayModelInfo(
            int indent,
            StringBuilder builder,
            TypeBuilderSpec modelInfo,
            TypeRef context,
            Dictionary<string, TypeRef> referenceContextLookup,
            Dictionary<TypeRef, (string TypeCase, string CamelCase)> identifierLookup)
        {
            var elementType = modelInfo.Type.GenericArguments[0];
            builder.AppendLine(indent, $"internal class {identifierLookup[modelInfo.Type].TypeCase}Builder : ModelReaderWriterTypeBuilder");
            builder.AppendLine(indent, "{");
            indent++;

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

            indent--;
            builder.AppendLine(indent, "}");
        }

        private static void EmitDictionaryModelInfo(
            int indent,
            StringBuilder builder,
            TypeBuilderSpec modelInfo,
            TypeRef context,
            Dictionary<string, TypeRef> referenceContextLookup,
            Dictionary<TypeRef, (string TypeCase, string CamelCase)> identifierLookup)
        {
            var elementType = modelInfo.Type.GenericArguments[1];
            builder.AppendLine(indent, $"internal class {identifierLookup[modelInfo.Type].TypeCase}Builder : ModelReaderWriterTypeBuilder");
            builder.AppendLine(indent, "{");
            indent++;

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

            indent--;
            builder.AppendLine(indent, "}");
        }

        private static bool IsSameAssembly(TypeRef context, TypeRef elementType)
        {
            if (context.Assembly.Equals(elementType.Assembly, StringComparison.Ordinal))
                return true;

            //If we made the context implicitly its assembly will be a simple name
            //TestAssembly
            //vs
            //TestAssembly, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
            if (!context.Assembly.AsSpan().Contains(", Version".AsSpan(), StringComparison.Ordinal))
                return elementType.Assembly.StartsWith(context.Assembly, StringComparison.Ordinal);

            return false;
        }

        private static void EmitEnumerableModelInfo(
            int indent,
            StringBuilder builder,
            TypeBuilderSpec modelInfo,
            TypeRef context,
            Dictionary<string, TypeRef> referenceContextLookup,
            Dictionary<TypeRef, (string TypeCase, string CamelCase)> identifierLookup)
        {
            var elementType = modelInfo.Type.GenericArguments[0];
            builder.AppendLine(indent, $"internal class {identifierLookup[modelInfo.Type].TypeCase}Builder : ModelReaderWriterTypeBuilder");
            builder.AppendLine(indent, "{");
            indent++;

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

            indent--;
            builder.AppendLine(indent, "}");
        }

        private static void EmitPersistableModelInfo(
            int indent,
            StringBuilder builder,
            TypeBuilderSpec modelInfo,
            TypeRef context,
            Dictionary<TypeRef, (string TypeCase, string CamelCase)> identifierLookup)
        {
            if (IsSameAssembly(context, modelInfo.Type))
            {
                builder.AppendLine(indent, $"internal class {identifierLookup[modelInfo.Type].TypeCase}Builder : ModelReaderWriterTypeBuilder");
                builder.AppendLine(indent, "{");
                indent++;

                builder.AppendLine(indent, $"protected override Type BuilderType => typeof({modelInfo.Type.Name});");
                builder.AppendLine();

                builder.AppendLine(indent, $"protected override object CreateInstance() => new {modelInfo.Type.Name}();");

                indent--;
                builder.AppendLine(indent, "}");
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
                "System.Diagnostics.CodeAnalysis"
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

        private void AddNamespaces(HashSet<string> namespaces, TypeRef referencedContext, HashSet<TypeRef> visited)
        {
            if (!visited.Add(referencedContext))
            {
                return;
            }

            namespaces.Add(referencedContext.Namespace);
            foreach (var genericArgument in referencedContext.GenericArguments)
            {
                AddNamespaces(namespaces, genericArgument, visited);
            }
        }

        private partial void AddSource(string hintName, SourceText sourceText);
    }
}
