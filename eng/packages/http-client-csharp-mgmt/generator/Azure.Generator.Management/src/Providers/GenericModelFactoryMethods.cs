// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Visitors;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    /// <summary> Builds typed dispatch over the finalized, constructor-aware model factories. </summary>
    internal static class GenericModelFactoryMethods
    {
        private class Template<T> where T : class { }

        private sealed class PropertyBagProvider(string modelNamespace) : TypeProvider
        {
            protected override string BuildName() => "ModelFactoryPropertyBag";
            protected override string BuildNamespace() => modelNamespace;
            protected override string BuildRelativeFilePath() => "Internal/ModelFactoryPropertyBag.cs";
        }

        internal static void AddTo(ModelFactoryProvider factory)
        {
            if (factory.Methods.Any(m => m.Signature.Name == "CreateModel"))
            {
                return;
            }

            var helper = new PropertyBagProvider(factory.Type.Namespace).Type;
            var bagType = new CSharpType(typeof(IReadOnlyDictionary<,>), typeof(string), typeof(object));
            var modelType = new ParameterProvider("modelType", $"The model type.", typeof(Type));
            var properties = new ParameterProvider("properties", $"The property bag.", bagType);
            var current = new ParameterProvider("current", $"The template instance.", typeof(object));
            var body = new List<MethodBodyStatement>();
            AddMissingFactories(factory);
            var factories = factory.Methods.Where(m => m.Signature.ReturnType is not null
                && !ModelFactoryBackwardCompatHelper.IsBackwardCompatMethod(m)).ToArray();

            foreach (var method in factories.GroupBy(m => m.Signature.ReturnType!).Select(g => g.First()))
            {
                var type = method.Signature.ReturnType!;
                var model = ManagementClientGenerator.Instance.OutputLibrary.TypeProviders.OfType<ModelProvider>()
                    .FirstOrDefault(m => m.Type.AreNamesEqual(type));
                if (model is null || !model.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public))
                {
                    continue;
                }

                var allProperties = GetProperties(model).ToArray();
                var arguments = new List<ValueExpression>();
                var names = new List<ValueExpression>();
                foreach (var parameter in method.Signature.Parameters)
                {
                    var property = allProperties.FirstOrDefault(p => p.Name == parameter.Property?.Name)
                        ?? allProperties.FirstOrDefault(p => string.Equals(p.Name, parameter.Name, StringComparison.OrdinalIgnoreCase));
                    if (property is null)
                    {
                        // Historical overloads can accept a different reference type in the same position.
                        // Keep the default typed so dispatch selects the intended current factory.
                        arguments.Add(Default.CastTo(parameter.Type));
                        continue;
                    }

                    names.Add(Literal(property.Name));
                    var template = ((ValueExpression)current).CastTo(type);
                    var read = ReadProperty(template, property);
                    ValueExpression fallback = new TernaryConditionalExpression(current.Equal(Null), Default, read);
                    arguments.Add(Static(helper).Invoke("Get", [properties, Literal(property.Name), fallback,
                        new MemberExpression(null, "CreateModel")], [parameter.Type]));
                }

                var branch = new IfStatement(modelType.Equal(TypeOf(type)));
                branch.Add(Static(helper).Invoke("Validate", [properties, TypeOf(type), New.Array(typeof(string), names.ToArray())]).Terminate());
                branch.Add(Return(Static(factory.Type).Invoke(method.Signature, arguments)));
                body.Add(branch);
            }

            body.Add(Throw(New.Instance(typeof(ArgumentException), [Literal("The requested type is not a supported model."), Literal("modelType")])));
            var dispatch = new MethodProvider(new MethodSignature("CreateModel", $"Creates a model using generated typed dispatch.",
                MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static, typeof(object), null, [modelType, properties, current]), body, factory);

            var t = new CSharpType(typeof(Template<>).GetGenericArguments()[0]);
            var methods = new List<MethodProvider>(factory.Methods);
            foreach (var inputType in new CSharpType[] { typeof(object), bagType })
            {
                var input = new ParameterProvider("properties", $"An anonymous object or a dictionary keyed by case-sensitive C# property names.", inputType);
                var template = new ParameterProvider("current", $"An optional template. A new instance is returned; the template is never modified.", t, Default);
                var signature = new MethodSignature("Create",
                    $"Creates a model for mocking. Missing properties use defaults; service-required fields are not validated. Nested models and collection elements may be supplied as property bags. Unchanged reference values, including nested models and dictionaries, may be shared. Collection containers are copied only where required by model constructors. This is not a deep clone.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Static, t, $"A new model instance.", [input, template],
                    GenericArguments: [t], GenericParameterConstraints: [new WhereExpression(t, new KeywordExpression("class", null))]);
                methods.Add(new MethodProvider(signature, Return(Static(factory.Type).Invoke("CreateModel",
                    [TypeOf(t), Static(helper).Invoke("Read", input), template]).CastTo(t)), factory));
            }

            // Only signatures in a real previous contract remain public. New per-model methods
            // are implementation details, not an API surface that grows with each model.
            foreach (var method in factories)
            {
                if (factory.LastContractView?.Methods.Any(previous => ModelFactoryVisitor.HasSameCSharpSignature(previous.Signature, method.Signature)) != true)
                {
                    method.Signature.Update(modifiers: MethodSignatureModifiers.Private | MethodSignatureModifiers.Static);
                }
            }
            methods.Add(dispatch);
            factory.Update(methods: methods);
        }

        private static void AddMissingFactories(ModelFactoryProvider factory)
        {
            var methods = new List<MethodProvider>(factory.Methods);
            foreach (var model in ManagementClientGenerator.Instance.OutputLibrary.TypeProviders.OfType<ModelProvider>())
            {
                if (!model.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public)
                    || model.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Abstract)
                    || KnownManagementTypes.IsKnownManagementType(model.Type)
                    || methods.Any(m => m.Signature.ReturnType?.AreNamesEqual(model.Type) == true))
                {
                    continue;
                }
                var parameters = GetProperties(model).DistinctBy(p => p.Name).Select(property =>
                    new ParameterProvider(property.AsParameter.Name, property.Description ?? $"The property value.",
                        property.Type.InputType.WithNullable(true), Default, property: property)).ToArray();
                var signature = new MethodSignature(model.Name, model.Description,
                    MethodSignatureModifiers.Private | MethodSignatureModifiers.Static, model.Type, null, parameters);
                var method = new MethodProvider(signature,
                    Return(New.Instance(model.Type, model.FullConstructor.Signature.Parameters.Select(_ => Default).ToArray())), factory);
                ModelFactoryBackwardCompatHelper.FixModelFactoryConstructorCalls([method]);
                methods.Add(method);
            }
            factory.Update(methods: methods);
        }

        private static IEnumerable<PropertyProvider> GetProperties(ModelProvider model)
        {
            for (ModelProvider? current = model; current is not null; current = current.BaseModelProvider)
            {
                foreach (var property in current.Properties.Where(p => p.Modifiers.HasFlag(MethodSignatureModifiers.Public) && !p.IsRef))
                {
                    yield return property;
                }
            }
        }

        private static ValueExpression ReadProperty(ValueExpression instance, PropertyProvider property)
        {
            if (property is FlattenedPropertyProvider flattened)
            {
                // Read the underlying path rather than a lazy collection getter that might
                // initialize an absent wrapper on the caller's template.
                var wrapper = ReadProperty(instance, flattened.FlattenedProperty);
                return new TernaryConditionalExpression(wrapper.Equal(Null), Default, ReadProperty(wrapper, flattened.OriginalProperty));
            }
            return instance.Property(property.Name);
        }
    }
}