// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Providers;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Management.Visitors
{
    internal class ModelFactoryVisitor : ScmLibraryVisitor
    {
        private HashSet<CSharpType>? _modelTypes;
        private HashSet<CSharpType>? _modelFactoryModelTypes;
        private Dictionary<CSharpType, ModelProvider>? _modelProvidersByType;

        protected override TypeProvider? VisitType(TypeProvider type)
        {
            if (type is ModelFactoryProvider modelFactory)
            {
                PreserveReadOnlyDictionaryPropertiesFromLastContract(modelFactory);

                var updatedMethods = new List<MethodProvider>();
                foreach (var method in modelFactory.Methods)
                {
                    var returnType = method.Signature.ReturnType;
                    if (returnType is not null && KnownManagementTypes.IsKnownManagementType(returnType))
                    {
                        continue;
                    }

                    if (returnType is not null
                        && IsModelType(returnType)
                        && !IsModelFactoryModelType(returnType))
                    {
                        updatedMethods.Add(method);
                    }
                    else if (returnType is not null && IsModelFactoryModelType(returnType))
                    {
                        // Fix ArgumentNullException XML documentation for parameters that are nullable
                        // Model factory methods should allow all parameters to be null for mocking purposes
                        FixArgumentNullExceptionXmlDoc(method);

                        // Update parameter names for specific properties
                        UpdateParameterNames(method);

                        updatedMethods.Add(method);
                    }
                }
                AddMissingLastContractModelMethods(modelFactory, updatedMethods);
                modelFactory.Update(methods: updatedMethods);
                return modelFactory;
            }
            return base.VisitType(type);
        }

        private void PreserveReadOnlyDictionaryPropertiesFromLastContract(ModelFactoryProvider modelFactory)
        {
            var previousMethods = modelFactory.LastContractView?.Methods;
            if (previousMethods is null || previousMethods.Count == 0)
            {
                return;
            }

            foreach (var previousMethod in previousMethods)
            {
                if (previousMethod.Signature.ReturnType is not { } returnType
                    || ManagementClientGenerator.Instance.OutputLibrary.ResourceProviders.FirstOrDefault(resource =>
                        resource.ResourceData.Type.WithNullable(false).AreNamesEqual(returnType.WithNullable(false)))?.ResourceData is not ResourceDataModelProvider model)
                {
                    continue;
                }

                foreach (var parameter in previousMethod.Signature.Parameters)
                {
                    if (!IsReadOnlyDictionary(parameter.Type))
                    {
                        continue;
                    }

                    var matchingProperty = model.Properties.FirstOrDefault(property =>
                        IsDictionary(property.Type)
                        && string.Equals(property.Name, parameter.Name, StringComparison.OrdinalIgnoreCase));
                    matchingProperty?.Update(type: new CSharpType(typeof(IReadOnlyDictionary<,>), matchingProperty.Type.Arguments));
                }
            }
        }

        private void AddMissingLastContractModelMethods(ModelFactoryProvider modelFactory, List<MethodProvider> updatedMethods)
        {
            var previousMethods = modelFactory.LastContractView?.Methods;
            if (previousMethods is null || previousMethods.Count == 0)
            {
                return;
            }

            var customMethods = modelFactory.CustomCodeView?.Methods ?? [];
            foreach (var previousMethod in previousMethods)
            {
                var returnType = previousMethod.Signature.ReturnType;
                if (returnType is null
                    || KnownManagementTypes.IsKnownManagementType(returnType)
                    || updatedMethods.Any(method => HasSameCSharpSignature(method.Signature, previousMethod.Signature))
                    || customMethods.Any(method => HasSameCSharpSignature(method.Signature, previousMethod.Signature))
                    || !ModelFactoryBackwardCompatHelper.TryCreateBackwardCompatMethod(previousMethod, modelFactory, out var restoredMethod))
                {
                    continue;
                }

                updatedMethods.Add(restoredMethod);
            }
        }

        private bool IsModelType(CSharpType type) => ContainsModelType(ModelTypes, type.WithNullable(false));

        private bool IsModelFactoryModelType(CSharpType type) => ContainsModelType(ModelFactoryModelTypes, type.WithNullable(false));

        private static bool ContainsModelType(HashSet<CSharpType> modelTypes, CSharpType type)
            => modelTypes.Contains(type) || modelTypes.Any(modelType => modelType.AreNamesEqual(type));

        private HashSet<CSharpType> ModelTypes
        {
            get
            {
                BuildModelTypes();
                return _modelTypes!;
            }
        }

        private HashSet<CSharpType> ModelFactoryModelTypes
        {
            get
            {
                BuildModelTypes();
                return _modelFactoryModelTypes!;
            }
        }

        private Dictionary<CSharpType, ModelProvider> ModelProvidersByType
        {
            get
            {
                BuildModelTypes();
                return _modelProvidersByType!;
            }
        }

        private void BuildModelTypes()
        {
            if (_modelTypes is not null && _modelFactoryModelTypes is not null && _modelProvidersByType is not null)
            {
                return;
            }

            var modelTypes = new HashSet<CSharpType>();
            var modelFactoryModelTypes = new HashSet<CSharpType>();
            var modelProvidersByType = new Dictionary<CSharpType, ModelProvider>();

            foreach (var inputModel in ManagementClientGenerator.Instance.InputLibrary.InputNamespace.Models)
            {
                var model = ManagementClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
                if (model is null)
                {
                    continue;
                }

                AddModelProvider(model, modelTypes, modelFactoryModelTypes, modelProvidersByType);
            }

            foreach (var model in ManagementClientGenerator.Instance.OutputLibrary.TypeProviders.OfType<ModelProvider>())
            {
                AddModelProvider(model, modelTypes, modelFactoryModelTypes, modelProvidersByType);
            }

            _modelTypes = modelTypes;
            _modelFactoryModelTypes = modelFactoryModelTypes;
            _modelProvidersByType = modelProvidersByType;
        }

        private static void AddModelProvider(
            ModelProvider model,
            HashSet<CSharpType> modelTypes,
            HashSet<CSharpType> modelFactoryModelTypes,
            Dictionary<CSharpType, ModelProvider> modelProvidersByType)
        {
            var type = model.Type.WithNullable(false);
            modelTypes.Add(type);
            modelProvidersByType[type] = model;
            if (IsModelFactoryModel(model))
            {
                modelFactoryModelTypes.Add(type);
            }
        }

        private static bool IsReadOnlyDictionary(CSharpType type)
            => IsDictionary(type, typeof(IReadOnlyDictionary<,>));

        private static bool IsDictionary(CSharpType type)
            => type.IsDictionary || IsDictionary(type, typeof(IDictionary<,>)) || IsDictionary(type, typeof(IReadOnlyDictionary<,>));

        private static bool IsDictionary(CSharpType type, Type dictionaryTypeDefinition)
        {
            if (type is not { IsFrameworkType: true, FrameworkType: not null })
            {
                return false;
            }

            var frameworkType = type.FrameworkType;
            if (frameworkType.IsGenericType && !frameworkType.IsGenericTypeDefinition)
            {
                frameworkType = frameworkType.GetGenericTypeDefinition();
            }

            return frameworkType == dictionaryTypeDefinition;
        }

        private static bool IsModelFactoryModel(ModelProvider model)
        {
            // A model is a model factory model if it is public and it has at least one public property without a setter.
            return model.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public) && EnumerateAllPublicProperties(model).Any(prop => !prop.Body.HasSetter);

            IEnumerable<PropertyProvider> EnumerateAllPublicProperties(ModelProvider current)
            {
                var currentModel = current;
                foreach (var property in currentModel.Properties)
                {
                    if (property.Modifiers.HasFlag(MethodSignatureModifiers.Public))
                    {
                        yield return property;
                    }
                }

                while (currentModel.BaseModelProvider is not null)
                {
                    currentModel = currentModel.BaseModelProvider;
                    foreach (var property in currentModel.Properties)
                    {
                        if (property.Modifiers.HasFlag(MethodSignatureModifiers.Public))
                        {
                            yield return property;
                        }
                    }
                }
            }
        }

        private static bool HasSameCSharpSignature(MethodSignature first, MethodSignature second)
        {
            return first.Name == second.Name
                && first.Parameters.Count == second.Parameters.Count
                && first.Parameters.Zip(second.Parameters).All(pair => pair.First.Type.AreNamesEqual(pair.Second.Type));
        }

        private void FixArgumentNullExceptionXmlDoc(MethodProvider method)
        {
            // Model factory methods are for mocking and should not have ArgumentNullException validation
            // The method implementation uses ternary operators to handle null values gracefully
            // Remove any ArgumentNullException documentation by clearing the exceptions list
            if (method.XmlDocs != null)
            {
                // Clear exceptions to remove ArgumentNullException documentation
                method.XmlDocs.Update(exceptions: Array.Empty<XmlDocExceptionStatement>());
            }
        }

        private void UpdateParameterNames(MethodProvider method)
        {
            if (PreservePreviousParameterNames(method))
            {
                // Update the method signature to refresh documentation after parameter renames.
                method.Update(signature: method.Signature);
            }
        }

        private static bool PreservePreviousParameterNames(MethodProvider method)
        {
            var previousMethods = method.EnclosingType.LastContractView?.Methods;
            if (previousMethods is null || previousMethods.Count == 0)
            {
                return false;
            }

            var previousMethod = previousMethods.FirstOrDefault(previous => MethodSignature.MethodSignatureComparer.Equals(method.Signature, previous.Signature));
            if (previousMethod is null)
            {
                return false;
            }

            var currentParameters = method.Signature.Parameters;
            var previousParameters = previousMethod.Signature.Parameters;
            if (currentParameters.Count != previousParameters.Count)
            {
                return false;
            }

            var updated = false;
            var currentParameterNames = currentParameters.Select(parameter => parameter.Name).ToHashSet(StringComparer.Ordinal);
            for (int i = 0; i < currentParameters.Count; i++)
            {
                var previousName = previousParameters[i].Name;
                var currentParameter = currentParameters[i];
                if (string.IsNullOrEmpty(previousName) || currentParameter.Name == previousName)
                {
                    continue;
                }

                if (currentParameterNames.Contains(previousName))
                {
                    continue;
                }

                currentParameterNames.Remove(currentParameter.Name);
                currentParameter.Update(name: previousName);
                currentParameterNames.Add(previousName);
                updated = true;
            }

            return updated;
        }
    }
}
