// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;
using Microsoft.Generator.CSharp.Input;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Providers;
using Microsoft.Generator.CSharp.Statements;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace Azure.Generator.Providers
{
    internal class SystemObjectProvider : TypeProvider
    {
        private readonly Type _type;
        private const string InitializationCtorAttributeName = "InitializationConstructorAttribute";
        private const string SerializationCtorAttributeName = "SerializationConstructorAttribute";

        public SystemObjectProvider(Type type) : base()
        {
            _type = type;
        }

        protected override string BuildName() => _type.Name;

        protected override string BuildRelativeFilePath() => throw new InvalidOperationException("This type should not be writing in generation");

        protected override ConstructorProvider[] BuildConstructors()
        {
            // TODO: get initialization constructor and serialization constructor
            var initializationCtor = GetCtor(_type, InitializationCtorAttributeName);
            var seiralizationCtor = GetCtor(_type, SerializationCtorAttributeName);

            return [BuildConstructor(initializationCtor), BuildConstructor(seiralizationCtor)];
        }

        private ConstructorProvider BuildConstructor(ConstructorInfo ctor)
        {
            var parameters = new List<ParameterProvider>();
            foreach (var param in ctor.GetParameters())
            {
                var parameter = new ParameterProvider(param.Name!, $"The {param.Name}", param.ParameterType);
                parameters.Add(parameter);
            }

            // we should only add initializers when there is a corresponding parameter
            List<ParameterProvider> arguments = new List<ParameterProvider>();
            foreach (var property in Properties)
            {
                var parameter = parameters.FirstOrDefault(p => p.Name == property.Name.ToVariableName());
                if (parameter is not null)
                {
                    arguments.Add(parameter);
                }
            }

            var modifiers = ctor.IsFamily ? MethodSignatureModifiers.Protected : MethodSignatureModifiers.Public;
            var signature = new ConstructorSignature(Type, null, modifiers, parameters, Initializer: new ConstructorInitializer(false, arguments));

            return new ConstructorProvider(signature, MethodBodyStatement.Empty, this);
        }

        private static ConstructorInfo GetCtor(Type type, string attributeType)
        {
            if (TryGetCtor(type, attributeType, out var ctor))
                return ctor;

            throw new InvalidOperationException($"{attributeType} ctor was not found for {type.Name}");
        }

        private static bool TryGetCtor(Type type, string attributeType, [MaybeNullWhen(false)] out ConstructorInfo result)
        {
            foreach (var ctor in type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.CreateInstance))
            {
                if (ctor.GetCustomAttributes().FirstOrDefault(a => a.GetType().Name == attributeType) != null)
                {
                    result = ctor;
                    return true;
                }
            }

            result = null;
            return false;

        }
    }
}
