// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
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
    /// Generates a ProvisionableConstruct subclass from an InputModelType.
    /// Uses TypeFactory.CreateCSharpType() for all type resolution, which returns
    /// BicepValue&lt;T&gt; / BicepList&lt;T&gt; / BicepDictionary&lt;T&gt; types directly.
    /// </summary>
    internal class ProvisioningModelProvider : ModelProvider
    {
        private readonly InputModelType _inputModel;

        public ProvisioningModelProvider(InputModelType inputModel) : base(inputModel)
        {
            _inputModel = inputModel;
        }

        protected override string BuildName() => _inputModel.Name;

        protected override string BuildNamespace()
        {
            // Flat namespace: Azure.Provisioning.{Service} (no .Models sub-namespace)
            return ManagementClientGenerator.Instance.TypeFactory.PrimaryNamespace;
        }

        protected override string BuildRelativeFilePath()
            => Path.Combine("src", "Generated", "Models", $"{Name}.cs");

        protected override TypeSignatureModifiers BuildDeclarationModifiers()
            => TypeSignatureModifiers.Public | TypeSignatureModifiers.Partial | TypeSignatureModifiers.Class;

        protected override CSharpType? BuildBaseType()
            => new CSharpType(typeof(ProvisionableConstruct));

        protected override FieldProvider[] BuildFields()
        {
            var fields = new List<FieldProvider>();
            foreach (var prop in _inputModel.Properties)
            {
                if (ShouldSkipProperty(prop))
                    continue;

                var bicepType = GetPropertyType(prop);
                fields.Add(new FieldProvider(
                    FieldModifiers.Private,
                    bicepType,
                    GetFieldName(prop.Name),
                    this));
            }
            return fields.ToArray();
        }

        protected override PropertyProvider[] BuildProperties()
        {
            var properties = new List<PropertyProvider>();
            var fieldIndex = 0;
            foreach (var prop in _inputModel.Properties)
            {
                if (ShouldSkipProperty(prop))
                    continue;

                var bicepType = GetPropertyType(prop);
                var isReadOnly = prop.IsReadOnly;
                var field = Fields[fieldIndex++];

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
                else if (IsModelType(bicepType))
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
                    null,
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

            var fieldIndex = 0;
            foreach (var prop in _inputModel.Properties)
            {
                if (ShouldSkipProperty(prop))
                    continue;

                var bicepType = GetPropertyType(prop);
                var serializedName = prop.SerializedName ?? prop.Name;
                var bicepPath = new[] { serializedName };
                var field = Fields[fieldIndex++];

                var isOutput = prop.IsReadOnly;
                var isRequired = prop.IsRequired;

                string methodName;
                CSharpType[] typeArgs;

                if (IsModelType(bicepType))
                {
                    methodName = "DefineModelProperty";
                    typeArgs = [bicepType];
                }
                else if (IsBicepListType(bicepType))
                {
                    methodName = "DefineListProperty";
                    typeArgs = [GetGenericArgument(bicepType)];
                }
                else if (IsBicepDictionaryType(bicepType))
                {
                    methodName = "DefineDictionaryProperty";
                    typeArgs = [GetGenericArgument(bicepType)];
                }
                else
                {
                    methodName = "DefineProperty";
                    typeArgs = [GetGenericArgument(bicepType)];
                }

                statements.Add(field.Assign(
                    This.Invoke(
                        methodName,
                        BuildDefinePropertyArgs(prop.Name, bicepPath, isOutput, isRequired),
                        typeArgs,
                        false)
                ).Terminate());
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

        // ── Type resolution helpers ──────────────────────────────────

        private CSharpType GetPropertyType(InputModelProperty prop)
        {
            return CodeModelGenerator.Instance.TypeFactory.CreateCSharpType(prop.Type)
                ?? new CSharpType(typeof(BicepValue<>), typeof(object));
        }

        private static bool IsModelType(CSharpType type)
            => !type.IsFrameworkType;

        private static bool IsBicepListType(CSharpType type)
            => type.IsFrameworkType && type.FrameworkType.IsGenericType
               && type.FrameworkType.GetGenericTypeDefinition() == typeof(BicepList<>);

        private static bool IsBicepDictionaryType(CSharpType type)
            => type.IsFrameworkType && type.FrameworkType.IsGenericType
               && type.FrameworkType.GetGenericTypeDefinition() == typeof(BicepDictionary<>);

        private static CSharpType GetGenericArgument(CSharpType type)
            => type.Arguments.Count > 0 ? type.Arguments[0] : typeof(object);

        private static bool ShouldSkipProperty(InputModelProperty prop)
            => prop.IsDiscriminator;

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
    }
}
