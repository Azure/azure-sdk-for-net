// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;

namespace Azure.Generator.Management.Utilities
{
    /// <summary>
    /// Reads evidence of parameter values reaching the returned object in a GA baseline implementation.
    /// This never executes baseline code. Unsupported IL, unavailable implementations, and preview
    /// baselines are unknown, not evidence that a compatibility parameter can safely be discarded.
    /// </summary>
    internal static class HistoricalFactoryUsage
    {
        internal static string? SelectedVersion(string outputDirectory, string packageName)
        {
            try
            {
                var path = Path.Combine(outputDirectory, "src", packageName + ".csproj");
                if (!File.Exists(path)) return null;
                var versions = XDocument.Load(path).Descendants()
                    .Where(element => element.Name.LocalName == "ApiCompatVersion").ToArray();
                return versions.Length == 1 ? versions[0].Value.Trim() : null;
            }
            catch (Exception exception) when (exception is IOException or UnauthorizedAccessException or System.Xml.XmlException)
            {
                return null;
            }
        }

        internal static IReadOnlyDictionary<string, IReadOnlySet<string>> Read(
            Compilation? contract, CSharpType factoryType, string? selectedVersion, string packageName)
        {
            var result = new Dictionary<string, IReadOnlySet<string>>(StringComparer.Ordinal);
            var symbol = contract?.GetTypeByMetadataName(TypeName(factoryType));
            if (contract is null || symbol is null || symbol.ContainingAssembly.Identity.Name != packageName
                || !IsSelectedStableAssembly(symbol.ContainingAssembly, selectedVersion))
            {
                return result;
            }

            try
            {
                // Production baselines are metadata references. Source contracts are also supported
                // so the same analysis can be exercised by focused tests without loading executable code.
                var implementation = OpenImplementation(contract, symbol.ContainingAssembly);
                using var stream = implementation.Stream;
                if (stream is null)
                {
                    return result;
                }
                using var pe = new PEReader(stream);
                var reader = pe.GetMetadataReader();
                if (implementation.ModuleVersionId is { } expected
                    && reader.GetGuid(reader.GetModuleDefinition().Mvid) != expected)
                {
                    return result;
                }
                var signatures = new SignatureNames();
                foreach (var handle in reader.TypeDefinitions)
                {
                    if (signatures.GetTypeFromDefinition(reader, handle, 0) != TypeName(factoryType))
                    {
                        continue;
                    }
                    foreach (var methodHandle in reader.GetTypeDefinition(handle).GetMethods())
                    {
                        var method = reader.GetMethodDefinition(methodHandle);
                        var signature = method.DecodeSignature(signatures, (object?)null);
                        if (signature.Header.IsInstance || signature.GenericParameterCount != 0)
                        {
                            continue;
                        }
                        var arguments = signature.ParameterTypes.Select((_, index) => Value.Parameter(index)).ToArray();
                        var budget = 10000;
                        if (!TryEvaluate(pe, reader, methodHandle, arguments, 0, ref budget, out var returned))
                        {
                            continue;
                        }
                        var used = new HashSet<int>();
                        returned.Collect(used, []);
                        var names = method.GetParameters().Select(reader.GetParameter)
                            .Where(p => p.SequenceNumber > 0 && used.Contains(p.SequenceNumber - 1))
                            .Select(p => reader.GetString(p.Name)).ToHashSet(StringComparer.Ordinal);
                        result[Key(reader.GetString(method.Name), signature.ParameterTypes)] = names;
                    }
                    break;
                }
            }
            catch (Exception exception) when (exception is IOException or BadImageFormatException or UnauthorizedAccessException)
            {
                // Missing or unreadable evidence must not turn the old broad checks back on.
            }
            return result;
        }

        internal static string Key(MethodSignature signature)
            => Key(signature.Name, signature.Parameters.Select(p => TypeKey(p.Type)));

        private static string Key(string name, IEnumerable<string> parameters)
            => name + "(" + string.Join(",", parameters) + ")";

        private static string TypeName(CSharpType type) => type.Namespace + "." + type.ClrMetadataName;

        private static string TypeKey(CSharpType type)
        {
            if (type.IsArray)
            {
                return TypeKey(type.ElementType) + (type.FrameworkType.IsSZArray
                    ? "[]" : "[" + (type.FrameworkType.GetArrayRank() == 1 ? "*" : new string(',', type.FrameworkType.GetArrayRank() - 1)) + "]");
            }
            var key = TypeName(type) + (type.Arguments.Count == 0 ? "" : "[" + string.Join(",", type.Arguments.Select(TypeKey)) + "]");
            return type.IsValueType && type.IsNullable ? "System.Nullable`1[" + key + "]" : key;
        }

        private static bool IsSelectedStableAssembly(IAssemblySymbol assembly, string? selectedVersion)
        {
            var version = assembly.GetAttributes().FirstOrDefault(a =>
                a.AttributeClass?.ToDisplayString() == "System.Reflection.AssemblyInformationalVersionAttribute")
                ?.ConstructorArguments.FirstOrDefault().Value as string;
            return selectedVersion is not null && !selectedVersion.Contains('-')
                && Version.TryParse(selectedVersion, out var selected)
                && version is not null && !version.Contains('-')
                && Version.TryParse(version.Split('+')[0], out var actual) && selected == actual;
        }

        private static (Stream? Stream, Guid? ModuleVersionId) OpenImplementation(Compilation contract, IAssemblySymbol assembly)
        {
            if (SymbolEqualityComparer.Default.Equals(contract.Assembly, assembly))
            {
                var stream = new MemoryStream();
                if (!contract.Emit(stream).Success)
                {
                    stream.Dispose();
                    return (null, null);
                }
                stream.Position = 0;
                return (stream, null);
            }
            foreach (var reference in contract.References.OfType<PortableExecutableReference>())
            {
                if (reference.FilePath is { } path
                    && SymbolEqualityComparer.Default.Equals(contract.GetAssemblyOrModuleSymbol(reference), assembly))
                {
                    if (reference.GetMetadata() is not AssemblyMetadata metadata || metadata.GetModules().Length != 1)
                    {
                        return (null, null);
                    }
                    // Pin the bytes for this read, and compare against Roslyn's original metadata
                    // snapshot. A replaced file must not supply evidence for a different contract.
                    return (new MemoryStream(File.ReadAllBytes(path), writable: false), metadata.GetModules()[0].GetModuleVersionId());
                }
            }
            return (null, null);
        }

        // A deliberately bounded, straight-line evaluator. Only stores into the returned object
        // (including constructor/setter calls in this module) establish preservation. A load,
        // null guard, or parameter name alone does not. Conditional branches and external helper
        // calls are unknown; they must not justify omitting a compatibility overload.
        private static bool TryEvaluate(PEReader pe, MetadataReader reader, MethodDefinitionHandle handle,
            IReadOnlyList<Value> arguments, int depth, ref int budget, out Value returned)
        {
            returned = new Value();
            var method = reader.GetMethodDefinition(handle);
            if (depth > 8 || method.RelativeVirtualAddress == 0)
            {
                return false;
            }
            var body = pe.GetMethodBody(method.RelativeVirtualAddress);
            if (body.ExceptionRegions.Length != 0)
            {
                return false;
            }
            var il = body.GetILReader();
            var stack = new Stack<Value>();
            var locals = new Dictionary<int, Value>();
            try
            {
                while (il.RemainingBytes > 0 && --budget > 0)
                {
                    var code = (ILOpCode)il.ReadByte();
                    if (code == (ILOpCode)0xfe)
                    {
                        code = (ILOpCode)(0xfe00 | il.ReadByte());
                    }
                    switch (code)
                    {
                        case ILOpCode.Nop: break;
                        case >= ILOpCode.Ldarg_0 and <= ILOpCode.Ldarg_3:
                            stack.Push(arguments[(int)code - (int)ILOpCode.Ldarg_0]); break;
                        case ILOpCode.Ldarg_s: stack.Push(arguments[il.ReadByte()]); break;
                        case ILOpCode.Ldarg: stack.Push(arguments[il.ReadUInt16()]); break;
                        case >= ILOpCode.Ldloc_0 and <= ILOpCode.Ldloc_3:
                            stack.Push(locals[(int)code - (int)ILOpCode.Ldloc_0]); break;
                        case ILOpCode.Ldloc_s: stack.Push(locals[il.ReadByte()]); break;
                        case ILOpCode.Ldloc: stack.Push(locals[il.ReadUInt16()]); break;
                        case >= ILOpCode.Stloc_0 and <= ILOpCode.Stloc_3:
                            locals[(int)code - (int)ILOpCode.Stloc_0] = stack.Pop(); break;
                        case ILOpCode.Stloc_s: locals[il.ReadByte()] = stack.Pop(); break;
                        case ILOpCode.Stloc: locals[il.ReadUInt16()] = stack.Pop(); break;
                        case ILOpCode.Ldnull: stack.Push(new Value { IsNull = true }); break;
                        case >= ILOpCode.Ldc_i4_m1 and <= ILOpCode.Ldc_i4_8:
                            stack.Push(new Value()); break;
                        case ILOpCode.Ldc_i4_s: il.ReadByte(); stack.Push(new Value()); break;
                        case ILOpCode.Ldc_i4:
                        case ILOpCode.Ldc_r4:
                        case ILOpCode.Ldstr:
                            il.ReadInt32(); stack.Push(new Value()); break;
                        case ILOpCode.Ldc_i8:
                        case ILOpCode.Ldc_r8:
                            il.ReadInt64(); stack.Push(new Value()); break;
                        case ILOpCode.Dup: stack.Push(stack.Peek()); break;
                        case ILOpCode.Pop: stack.Pop(); break;
                        case ILOpCode.Br_s:
                        case ILOpCode.Br:
                            var offset = code == ILOpCode.Br_s ? il.ReadSByte() : il.ReadInt32();
                            if (offset < 0 || offset >= il.RemainingBytes) return false;
                            il.Offset += offset;
                            break;
                        case ILOpCode.Ldfld:
                        case ILOpCode.Stfld:
                            var field = il.ReadInt32();
                            if (MetadataTokens.EntityHandle(field).Kind != HandleKind.FieldDefinition) return false;
                            var declaringType = reader.GetFieldDefinition((FieldDefinitionHandle)MetadataTokens.EntityHandle(field)).GetDeclaringType();
                            if ((reader.GetTypeDefinition(declaringType).Attributes & System.Reflection.TypeAttributes.LayoutMask)
                                == System.Reflection.TypeAttributes.ExplicitLayout) return false;
                            if (code == ILOpCode.Stfld)
                            {
                                var value = stack.Pop();
                                var target = stack.Pop();
                                if (target.IsNull) return false;
                                target.Fields[field] = value;
                            }
                            else
                            {
                                var target = stack.Pop();
                                if (target.IsNull) return false;
                                stack.Push(target.Fields.TryGetValue(field, out var value) ? value : new Value());
                            }
                            break;
                        case ILOpCode.Call:
                        case ILOpCode.Callvirt:
                        case ILOpCode.Newobj:
                            var callee = MetadataTokens.EntityHandle(il.ReadInt32());
                            if (callee.Kind == HandleKind.MemberReference)
                            {
                                var member = reader.GetMemberReference((MemberReferenceHandle)callee);
                                // The parameterless System.Object constructor cannot consume a factory input.
                                if (code != ILOpCode.Call || reader.GetString(member.Name) != ".ctor"
                                    || member.Parent.Kind != HandleKind.TypeReference
                                    || new SignatureNames().GetTypeFromReference(reader, (TypeReferenceHandle)member.Parent, 0) != "System.Object"
                                    || member.DecodeMethodSignature(new SignatureNames(), (object?)null).ParameterTypes.Length != 0)
                                {
                                    return false;
                                }
                                if (stack.Pop().IsNull) return false;
                                break;
                            }
                            if (callee.Kind != HandleKind.MethodDefinition) return false;
                            var calleeHandle = (MethodDefinitionHandle)callee;
                            var calleeDefinition = reader.GetMethodDefinition(calleeHandle);
                            if (code == ILOpCode.Callvirt
                                && (calleeDefinition.Attributes & System.Reflection.MethodAttributes.Virtual) != 0
                                && (calleeDefinition.Attributes & System.Reflection.MethodAttributes.Final) == 0) return false;
                            var signature = calleeDefinition.DecodeSignature(new SignatureNames(), (object?)null);
                            var callArguments = new Value[signature.ParameterTypes.Length + (signature.Header.IsInstance ? 1 : 0)];
                            for (var index = callArguments.Length - 1; index >= (signature.Header.IsInstance ? 1 : 0); index--)
                            {
                                callArguments[index] = stack.Pop();
                            }
                            var instance = code == ILOpCode.Newobj ? new Value() : null;
                            if (signature.Header.IsInstance)
                            {
                                callArguments[0] = instance ?? stack.Pop();
                                if (code == ILOpCode.Callvirt && callArguments[0].IsNull) return false;
                            }
                            if (!TryEvaluate(pe, reader, calleeHandle, callArguments, depth + 1, ref budget, out var callResult)) return false;
                            if (instance is not null) stack.Push(instance);
                            else if (signature.ReturnType != "System.Void") stack.Push(callResult);
                            break;
                        case ILOpCode.Ret:
                            var returnsVoid = method.DecodeSignature(new SignatureNames(), (object?)null).ReturnType == "System.Void";
                            if (stack.Count != (returnsVoid ? 0 : 1) || il.RemainingBytes != 0) return false;
                            returned = returnsVoid ? new Value() : stack.Pop();
                            return true;
                        default: return false;
                    }
                }
            }
            catch (Exception exception) when (exception is InvalidOperationException or IndexOutOfRangeException or KeyNotFoundException or ArgumentOutOfRangeException)
            {
                return false;
            }
            return false;
        }

        private sealed class Value
        {
            private int? _parameter;
            internal bool IsNull { get; init; }
            internal Dictionary<int, Value> Fields { get; } = [];
            internal static Value Parameter(int index) => new() { _parameter = index };
            internal void Collect(HashSet<int> used, HashSet<Value> visited)
            {
                if (!visited.Add(this)) return;
                if (_parameter is { } index) used.Add(index);
                foreach (var field in Fields.Values) field.Collect(used, visited);
            }
        }

        private sealed class SignatureNames : ISignatureTypeProvider<string, object?>
        {
            public string GetArrayType(string elementType, ArrayShape shape) => elementType + "[" + (shape.Rank == 1 ? "*" : new string(',', shape.Rank - 1)) + "]";
            public string GetByReferenceType(string elementType) => elementType + "&";
            public string GetFunctionPointerType(MethodSignature<string> signature) => "<function-pointer>";
            public string GetGenericInstantiation(string genericType, System.Collections.Immutable.ImmutableArray<string> typeArguments)
                => genericType + "[" + string.Join(",", typeArguments) + "]";
            public string GetGenericMethodParameter(object? genericContext, int index) => "!!" + index;
            public string GetGenericTypeParameter(object? genericContext, int index) => "!" + index;
            public string GetModifiedType(string modifier, string unmodifiedType, bool isRequired) => unmodifiedType;
            public string GetPinnedType(string elementType) => elementType;
            public string GetPointerType(string elementType) => elementType + "*";
            public string GetPrimitiveType(PrimitiveTypeCode typeCode) => "System." + typeCode;
            public string GetSZArrayType(string elementType) => elementType + "[]";
            public string GetTypeFromDefinition(MetadataReader reader, TypeDefinitionHandle handle, byte rawTypeKind)
            {
                var type = reader.GetTypeDefinition(handle);
                return type.IsNested
                    ? GetTypeFromDefinition(reader, type.GetDeclaringType(), rawTypeKind) + "+" + reader.GetString(type.Name)
                    : Qualify(reader, type.Namespace, type.Name);
            }
            public string GetTypeFromReference(MetadataReader reader, TypeReferenceHandle handle, byte rawTypeKind)
            {
                var type = reader.GetTypeReference(handle);
                return type.ResolutionScope.Kind == HandleKind.TypeReference
                    ? GetTypeFromReference(reader, (TypeReferenceHandle)type.ResolutionScope, rawTypeKind) + "+" + reader.GetString(type.Name)
                    : Qualify(reader, type.Namespace, type.Name);
            }
            public string GetTypeFromSpecification(MetadataReader reader, object? genericContext, TypeSpecificationHandle handle, byte rawTypeKind)
                => reader.GetTypeSpecification(handle).DecodeSignature(this, genericContext);
            private static string Qualify(MetadataReader reader, StringHandle ns, StringHandle name)
                => (reader.GetString(ns) is { Length: > 0 } value ? value + "." : "") + reader.GetString(name);
        }
    }
}
