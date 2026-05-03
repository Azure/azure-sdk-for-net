// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;

namespace Microsoft.TypeSpec.Generator.AspNetServer.Providers
{
    /// <summary>
    /// Emits a plain-old C# POCO for a TypeSpec model. ASP.NET Core's built-in
    /// System.Text.Json serializer handles (de)serialization at runtime; we add
    /// <see cref="JsonPropertyNameAttribute"/> on each property to preserve the
    /// wire-format name and accommodate ASP.NET's default web-style naming policy.
    /// </summary>
    internal sealed class ServerModelProvider : ModelProvider
    {
        private readonly InputModelType _input;

        public ServerModelProvider(InputModelType input) : base(input)
        {
            _input = input;
        }

        protected override string BuildName() => _input.Name;

        protected override string BuildNamespace() =>
            $"{CodeModelGenerator.Instance.TypeFactory.PrimaryNamespace}.Models";

        protected override string BuildRelativeFilePath() =>
            Path.Combine("src", "Generated", "Models", $"{Name}.cs");

        protected override TypeSignatureModifiers BuildDeclarationModifiers() =>
            TypeSignatureModifiers.Public | TypeSignatureModifiers.Partial | TypeSignatureModifiers.Class;

        protected override XmlDocProvider BuildXmlDocs()
        {
            var doc = !string.IsNullOrEmpty(_input.Doc) ? _input.Doc : _input.Summary;
            if (string.IsNullOrEmpty(doc))
            {
                return new XmlDocProvider(null, [], [], null, null);
            }
            return new XmlDocProvider(
                new XmlDocSummaryStatement([$"{doc}"]),
                [],
                [],
                null,
                null);
        }

        protected override PropertyProvider[] BuildProperties()
        {
            var seen = new HashSet<string>();
            // Skip properties already declared on the base model.
            CollectInheritedPropertyNames(_input.BaseModel, seen);

            var props = new List<PropertyProvider>(_input.Properties.Count);
            foreach (var prop in _input.Properties)
            {
                if (prop.IsDiscriminator || string.IsNullOrEmpty(prop.Name))
                {
                    continue;
                }

                if (!seen.Add(prop.Name))
                {
                    continue;
                }

                var csharpType = CodeModelGenerator.Instance.TypeFactory.CreateCSharpType(prop.Type) ?? typeof(object);
                if (!prop.IsRequired)
                {
                    csharpType = csharpType.WithNullable(true);
                }

                var propName = NameUtilities.ToPascalCase(prop.Name);
                var description = !string.IsNullOrEmpty(prop.Doc) ? prop.Doc : prop.Summary ?? string.Empty;

                var attributes = new List<AttributeStatement>
                {
                    new AttributeStatement(
                        typeof(JsonPropertyNameAttribute),
                        [Snippets.Snippet.Literal(prop.SerializedName ?? prop.Name)])
                };

                var providerProp = new PropertyProvider(
                    description: $"{description}",
                    modifiers: MethodSignatureModifiers.Public,
                    type: csharpType,
                    name: propName,
                    body: new AutoPropertyBody(HasSetter: !prop.IsReadOnly),
                    enclosingType: this,
                    attributes: attributes);

                props.Add(providerProp);
            }

            return props.ToArray();
        }

        protected override ConstructorProvider[] BuildConstructors() => [];

        protected override FieldProvider[] BuildFields() => [];

        protected override MethodProvider[] BuildMethods() => [];

        // The default ModelProvider attaches IJsonModel/IPersistableModel serialization;
        // we don't want that on the server side.
        protected override TypeProvider[] BuildSerializationProviders() => [];

        private static void CollectInheritedPropertyNames(InputModelType? model, HashSet<string> set)
        {
            while (model is not null)
            {
                foreach (var p in model.Properties)
                {
                    if (!string.IsNullOrEmpty(p.Name))
                    {
                        set.Add(p.Name);
                    }
                }
                model = model.BaseModel;
            }
        }
    }
}
