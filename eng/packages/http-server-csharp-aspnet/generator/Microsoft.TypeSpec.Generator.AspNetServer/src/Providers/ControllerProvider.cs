// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Microsoft.TypeSpec.Generator.AspNetServer.Providers
{
    /// <summary>
    /// Emits an abstract ASP.NET Core controller base for a single
    /// <see cref="InputClient"/>. Service authors derive from the generated
    /// class to provide the actual implementation of each operation.
    /// </summary>
    internal sealed class ControllerProvider : TypeProvider
    {
        private readonly InputClient _input;

        public ControllerProvider(InputClient input)
        {
            _input = input;
        }

        protected override string BuildName() => $"{_input.Name}ControllerBase";

        protected override string BuildNamespace() =>
            $"{CodeModelGenerator.Instance.TypeFactory.PrimaryNamespace}.Controllers";

        protected override string BuildRelativeFilePath() =>
            Path.Combine("src", "Generated", "Controllers", $"{Name}.cs");

        protected override TypeSignatureModifiers BuildDeclarationModifiers() =>
            TypeSignatureModifiers.Public | TypeSignatureModifiers.Partial | TypeSignatureModifiers.Abstract | TypeSignatureModifiers.Class;

        protected override CSharpType[] BuildImplements() => [typeof(ControllerBase)];

        protected override IReadOnlyList<AttributeStatement> BuildAttributes() =>
            [new AttributeStatement(typeof(ApiControllerAttribute))];

        protected override XmlDocProvider BuildXmlDocs()
        {
            var doc = !string.IsNullOrEmpty(_input.Doc) ? _input.Doc : _input.Summary;
            return string.IsNullOrEmpty(doc)
                ? new XmlDocProvider(null, [], [], null, null)
                : new XmlDocProvider(new XmlDocSummaryStatement([$"{doc}"]), [], [], null, null);
        }

        protected override MethodProvider[] BuildMethods()
        {
            var methods = new List<MethodProvider>(_input.Methods.Count);
            foreach (var method in _input.Methods)
            {
                methods.Add(BuildOperationMethod(method));
            }
            return methods.ToArray();
        }

        private MethodProvider BuildOperationMethod(InputServiceMethod method)
        {
            var op = method.Operation;
            var typeFactory = CodeModelGenerator.Instance.TypeFactory;

            var returnType = BuildReturnType(method, typeFactory);
            var parameters = BuildParameters(method, typeFactory);
            var attributes = new[] { BuildHttpVerbAttribute(op) };

            var doc = !string.IsNullOrEmpty(method.Documentation) ? method.Documentation : method.Summary;
            var xmlDocs = string.IsNullOrEmpty(doc)
                ? new XmlDocProvider(null, [], [], null, null)
                : new XmlDocProvider(new XmlDocSummaryStatement([$"{doc}"]), [], [], null, null);

            var signature = new MethodSignature(
                Name: $"{NameUtilities.ToPascalCase(method.Name)}Async",
                Description: null!,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Abstract,
                ReturnType: returnType,
                ReturnDescription: null!,
                Parameters: parameters,
                Attributes: attributes);

            return new MethodProvider(signature, this, xmlDocs);
        }

        private static CSharpType BuildReturnType(InputServiceMethod method, TypeFactory typeFactory)
        {
            var responseType = method.Response?.Type;
            if (responseType is null)
            {
                return new CSharpType(typeof(Task<>), typeof(IActionResult));
            }
            var inner = typeFactory.CreateCSharpType(responseType) ?? new CSharpType(typeof(object));
            var actionResult = new CSharpType(typeof(ActionResult<>), inner);
            return new CSharpType(typeof(Task<>), actionResult);
        }

        private static AttributeStatement BuildHttpVerbAttribute(InputOperation op)
        {
            var attrType = op.HttpMethod.ToUpperInvariant() switch
            {
                "GET" => typeof(HttpGetAttribute),
                "PUT" => typeof(HttpPutAttribute),
                "POST" => typeof(HttpPostAttribute),
                "DELETE" => typeof(HttpDeleteAttribute),
                "PATCH" => typeof(HttpPatchAttribute),
                "HEAD" => typeof(HttpHeadAttribute),
                "OPTIONS" => typeof(HttpOptionsAttribute),
                _ => typeof(HttpGetAttribute),
            };
            var route = (op.Path ?? string.Empty).TrimStart('/');
            return new AttributeStatement(attrType, Literal(route));
        }

        private static IReadOnlyList<ParameterProvider> BuildParameters(InputServiceMethod method, TypeFactory typeFactory)
        {
            var parameters = new List<ParameterProvider>();
            var seen = new HashSet<string>();

            foreach (var p in method.Operation.Parameters)
            {
                if (p.IsApiVersion)
                {
                    continue;
                }

                var bindingAttr = BuildBindingAttribute(p);
                if (bindingAttr is null)
                {
                    continue;
                }

                var type = typeFactory.CreateCSharpType(p.Type);
                if (type is null)
                {
                    continue;
                }
                if (!p.IsRequired)
                {
                    type = type.WithNullable(true);
                }

                var name = SafeIdentifier(p.Name);
                if (!seen.Add(name))
                {
                    continue;
                }

                parameters.Add(new ParameterProvider(
                    name: name,
                    description: $"",
                    type: type,
                    attributes: [bindingAttr]));
            }

            parameters.Add(new ParameterProvider(
                name: "cancellationToken",
                description: $"A token to cancel the asynchronous operation.",
                type: typeof(CancellationToken),
                defaultValue: Default));

            return parameters;
        }

        private static AttributeStatement? BuildBindingAttribute(InputParameter p)
        {
            // accept/content-type are handled by ASP.NET content negotiation, not as method args.
            if (p is InputHeaderParameter && IsContentNegotiationHeader(p.SerializedName ?? p.Name))
            {
                return null;
            }

            var serializedName = p.SerializedName ?? p.Name;
            return p switch
            {
                InputPathParameter => new AttributeStatement(
                    typeof(FromRouteAttribute),
                    [],
                    [new(nameof(FromRouteAttribute.Name), Literal(serializedName))]),
                InputQueryParameter => new AttributeStatement(
                    typeof(FromQueryAttribute),
                    [],
                    [new(nameof(FromQueryAttribute.Name), Literal(serializedName))]),
                InputHeaderParameter => new AttributeStatement(
                    typeof(FromHeaderAttribute),
                    [],
                    [new(nameof(FromHeaderAttribute.Name), Literal(serializedName))]),
                InputBodyParameter => new AttributeStatement(typeof(FromBodyAttribute)),
                _ => null,
            };
        }

        private static bool IsContentNegotiationHeader(string name)
        {
            return string.Equals(name, "accept", StringComparison.OrdinalIgnoreCase)
                || string.Equals(name, "content-type", StringComparison.OrdinalIgnoreCase)
                || string.Equals(name, "contenttype", StringComparison.OrdinalIgnoreCase);
        }

        private static readonly HashSet<string> CSharpKeywords = new()
        {
            "abstract","as","base","bool","break","byte","case","catch","char","checked","class","const",
            "continue","decimal","default","delegate","do","double","else","enum","event","explicit",
            "extern","false","finally","fixed","float","for","foreach","goto","if","implicit","in","int",
            "interface","internal","is","lock","long","namespace","new","null","object","operator","out",
            "override","params","private","protected","public","readonly","ref","return","sbyte","sealed",
            "short","sizeof","stackalloc","static","string","struct","switch","this","throw","true","try",
            "typeof","uint","ulong","unchecked","unsafe","ushort","using","virtual","void","volatile","while",
        };

        private static string SafeIdentifier(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return "_arg";
            }
            return CSharpKeywords.Contains(name) ? "@" + name : name;
        }
    }
}
