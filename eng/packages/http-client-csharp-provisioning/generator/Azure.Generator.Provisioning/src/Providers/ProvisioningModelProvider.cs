// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Provisioning.Providers
{
    /// <summary>
    /// Generates a ProvisionableConstruct subclass from a management ModelProvider.
    /// Reads the final snapshot of a mgmt model (after all visitors) and produces
    /// the provisioning-style output with BicepValue&lt;T&gt; properties.
    /// </summary>
    internal class ProvisioningModelProvider : TypeProvider
    {
        private readonly ModelProvider _mgmtModel;
        private Dictionary<string, CSharpType>? _typeMap;

        public ProvisioningModelProvider(ModelProvider mgmtModel)
        {
            _mgmtModel = mgmtModel;
        }

        /// <summary>
        /// Sets the type map for resolving model cross-references.
        /// Must be called before any Build* methods are invoked (i.e., before Type is accessed).
        /// </summary>
        internal void SetTypeMap(Dictionary<string, CSharpType> typeMap)
        {
            _typeMap = typeMap;
        }

        protected override string BuildName() => _mgmtModel.Name;

        protected override string BuildNamespace()
        {
            // Flat namespace: Azure.Provisioning.{Service} (no .Models sub-namespace)
            return ManagementClientGenerator.Instance.TypeFactory.PrimaryNamespace;
        }

        protected override string BuildRelativeFilePath()
            => Path.Combine("src", "Generated", "Models", $"{Name}.cs");

        protected override TypeSignatureModifiers BuildDeclarationModifiers()
            => TypeSignatureModifiers.Public | TypeSignatureModifiers.Partial | TypeSignatureModifiers.Class;

        protected override CSharpType[] BuildImplements()
            => [typeof(ProvisionableConstruct)];

        protected override FieldProvider[] BuildFields()
        {
            var fields = new List<FieldProvider>();
            foreach (var prop in _mgmtModel.Properties)
            {
                var bicepType = GetBicepFieldType(ResolveType(prop.Type));
                fields.Add(new FieldProvider(
                    FieldModifiers.Private,
                    bicepType.WithNullable(true),
                    GetFieldName(prop.Name),
                    this));
            }
            return fields.ToArray();
        }

        protected override PropertyProvider[] BuildProperties()
        {
            var properties = new List<PropertyProvider>();
            for (int i = 0; i < _mgmtModel.Properties.Count; i++)
            {
                var prop = _mgmtModel.Properties[i];
                var resolvedType = ResolveType(prop.Type);
                var bicepType = GetBicepPropertyType(resolvedType);
                var isReadOnly = prop.WireInfo?.IsReadOnly ?? false;
                var field = Fields[i];

                var getter = new MethodBodyStatement[]
                {
                    This.Invoke("Initialize").Terminate(),
                    Return(field)
                };

                MethodPropertyBody body;
                if (isReadOnly)
                {
                    body = new MethodPropertyBody(getter);
                }
                else if (IsModelType(resolvedType))
                {
                    var setter = new MethodBodyStatement[]
                    {
                        This.Invoke("Initialize").Terminate(),
                        This.Invoke("AssignOrReplace", new KeywordExpression("ref", field), Value).Terminate()
                    };
                    body = new MethodPropertyBody(getter, setter);
                }
                else
                {
                    var setter = new MethodBodyStatement[]
                    {
                        This.Invoke("Initialize").Terminate(),
                        field.AsValueExpression.Invoke("Assign", Value).Terminate()
                    };
                    body = new MethodPropertyBody(getter, setter);
                }

                properties.Add(new PropertyProvider(
                    prop.Description,
                    MethodSignatureModifiers.Public,
                    bicepType,
                    prop.Name,
                    body,
                    this));
            }
            return properties.ToArray();
        }

        protected override ConstructorProvider[] BuildConstructors()
        {
            var sig = new ConstructorSignature(
                Type,
                $"Creates a new {Name}.",
                MethodSignatureModifiers.Public,
                Array.Empty<ParameterProvider>());

            return [new ConstructorProvider(sig, MethodBodyStatement.Empty, this)];
        }

        protected override MethodProvider[] BuildMethods()
        {
            var statements = new List<MethodBodyStatement>();
            statements.Add(Base.Invoke("DefineProvisionableProperties").Terminate());

            for (int i = 0; i < _mgmtModel.Properties.Count; i++)
            {
                var prop = _mgmtModel.Properties[i];
                var resolvedType = ResolveType(prop.Type);
                var serializedName = prop.WireInfo?.SerializedName ?? prop.Name;
                var bicepPath = new[] { serializedName };
                var field = Fields[i];

                var isOutput = prop.WireInfo?.IsReadOnly ?? false;
                var isRequired = prop.WireInfo?.IsRequired ?? false;

                if (IsModelType(resolvedType))
                {
                    statements.Add(field.Assign(
                        This.Invoke(
                            "DefineModelProperty",
                            BuildDefinePropertyArgs(prop.Name, bicepPath, isOutput, isRequired),
                            [resolvedType],
                            false)
                    ).Terminate());
                }
                else if (IsDictionaryType(resolvedType))
                {
                    var elementType = GetDictionaryValueType(resolvedType);
                    statements.Add(field.Assign(
                        This.Invoke(
                            "DefineDictionaryProperty",
                            BuildDefinePropertyArgs(prop.Name, bicepPath, isOutput, isRequired),
                            [elementType],
                            false)
                    ).Terminate());
                }
                else if (IsListType(resolvedType))
                {
                    var elementType = GetListElementType(resolvedType);
                    statements.Add(field.Assign(
                        This.Invoke(
                            "DefineListProperty",
                            BuildDefinePropertyArgs(prop.Name, bicepPath, isOutput, isRequired),
                            [elementType],
                            false)
                    ).Terminate());
                }
                else
                {
                    var valueType = UnwrapNullable(resolvedType);
                    statements.Add(field.Assign(
                        This.Invoke(
                            "DefineProperty",
                            BuildDefinePropertyArgs(prop.Name, bicepPath, isOutput, isRequired),
                            [valueType],
                            false)
                    ).Terminate());
                }
            }

            var method = new MethodProvider(
                new MethodSignature(
                    "DefineProvisionableProperties",
                    $"Define all the provisionable properties for {Name}.",
                    MethodSignatureModifiers.Protected | MethodSignatureModifiers.Override,
                    null,
                    null,
                    Array.Empty<ParameterProvider>()),
                statements,
                this);

            return [method];
        }

        protected override TypeProvider[] BuildSerializationProviders()
            => Array.Empty<TypeProvider>();

        // ── Type resolution ──────────────────────────────────────────

        /// <summary>
        /// Resolves a mgmt CSharpType to the corresponding provisioning type.
        /// For non-framework types (models and enums), looks up the type map.
        /// For enum types not in the map, falls back to string.
        /// For generic types (List, Dictionary), recursively resolves type arguments.
        /// </summary>
        private CSharpType ResolveType(CSharpType type)
        {
            if (!type.IsFrameworkType && _typeMap != null)
            {
                if (_typeMap.TryGetValue(type.Name, out var provisioningType))
                    return provisioningType;
            }

            // Enum types not in the type map → use string
            if (!type.IsFrameworkType && type.IsEnum)
                return typeof(string);

            // For generic types, resolve type arguments recursively
            if (type.IsGenericType && type.Arguments.Count > 0)
            {
                var resolvedArgs = type.Arguments.Select(ResolveType).ToArray();
                bool changed = false;
                for (int i = 0; i < resolvedArgs.Length; i++)
                {
                    if (!ReferenceEquals(resolvedArgs[i], type.Arguments[i]))
                    {
                        changed = true;
                        break;
                    }
                }
                if (changed)
                {
                    return new CSharpType(type.FrameworkType.GetGenericTypeDefinition(), type.IsNullable, resolvedArgs);
                }
            }

            return type;
        }

        // ── Helpers ──────────────────────────────────────────────────

        private static string GetFieldName(string propertyName)
            => $"_{char.ToLowerInvariant(propertyName[0])}{propertyName.Substring(1)}";

        private static ValueExpression[] BuildDefinePropertyArgs(
            string propertyName, string[] bicepPath, bool isOutput, bool isRequired)
        {
            var args = new List<ValueExpression>
            {
                Literal(propertyName),
                New.Array(typeof(string), bicepPath.Select(Literal).ToArray())
            };
            if (isOutput || isRequired)
            {
                args.Add(Literal(isOutput));
                args.Add(Literal(isRequired));
            }
            return args.ToArray();
        }

        private static CSharpType GetBicepPropertyType(CSharpType type)
        {
            if (IsModelType(type))
                return type;
            if (IsDictionaryType(type))
                return new CSharpType(typeof(BicepDictionary<>), GetDictionaryValueType(type));
            if (IsListType(type))
                return new CSharpType(typeof(BicepList<>), GetListElementType(type));
            return new CSharpType(typeof(BicepValue<>), UnwrapNullable(type));
        }

        private static CSharpType GetBicepFieldType(CSharpType type)
            => GetBicepPropertyType(type);

        private static CSharpType UnwrapNullable(CSharpType type)
            => type.IsNullable ? type.WithNullable(false) : type;

        private static bool IsModelType(CSharpType type)
            => type.IsFrameworkType == false && !type.IsEnum;

        private static bool IsDictionaryType(CSharpType type)
        {
            if (!type.IsFrameworkType) return false;
            var frameworkType = type.FrameworkType;
            return frameworkType.IsGenericType &&
                   (frameworkType.GetGenericTypeDefinition() == typeof(IDictionary<,>) ||
                    frameworkType.GetGenericTypeDefinition() == typeof(Dictionary<,>));
        }

        private static bool IsListType(CSharpType type)
        {
            if (!type.IsFrameworkType) return false;
            var frameworkType = type.FrameworkType;
            return frameworkType.IsGenericType &&
                   (frameworkType.GetGenericTypeDefinition() == typeof(IList<>) ||
                    frameworkType.GetGenericTypeDefinition() == typeof(List<>) ||
                    frameworkType.GetGenericTypeDefinition() == typeof(IReadOnlyList<>));
        }

        private static CSharpType GetDictionaryValueType(CSharpType type)
            => type.Arguments.Count > 1 ? type.Arguments[1] : typeof(string);

        private static CSharpType GetListElementType(CSharpType type)
            => type.Arguments.Count > 0 ? type.Arguments[0] : typeof(object);
    }
}
