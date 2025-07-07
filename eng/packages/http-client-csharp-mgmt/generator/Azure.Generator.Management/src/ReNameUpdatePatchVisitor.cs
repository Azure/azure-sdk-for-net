// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.Collections.Generic;

namespace Azure.Generator.Management
{
    internal class ReNameUpdatePatchVisitor : ScmLibraryVisitor
    {
        private readonly Dictionary<string, string> _nameCache = new Dictionary<string, string>();

        protected override ModelProvider? PreVisitModel(InputModelType model, ModelProvider? type)
        {
            if (type is not null && IsUpdatePatchModel(model))
            {
                // Find new name from cache first, if not hit calculate the new name
                if (!_nameCache.TryGetValue(type.Name, out var newName))
                {
                    var enclosingResourceName = FindEnclosingResourceName(model);
                    newName = $"{enclosingResourceName}Patch";
                    _nameCache[type.Name] = newName;
                }

                type.Update(name: newName);

                foreach (var serializationProvider in type.SerializationProviders)
                {
                    serializationProvider.Update(name: newName);
                }
            }

            return base.PreVisitModel(model, type);
        }

        protected override MethodProvider? VisitMethod(MethodProvider method)
        {
            var parameterUpdated = false;
            foreach (var parameter in method.Signature.Parameters)
            {
                // Check if the cache values contain the parameter type name
                if (_nameCache.ContainsValue(parameter.Type.Name))
                {
                    parameter.Update(name: "patch");
                    parameterUpdated = true;
                }
            }

            if (parameterUpdated)
            {
                method.Update(signature: method.Signature);
            }
            return base.VisitMethod(method);
        }

        protected static bool IsUpdatePatchModel(InputModelType model)
        {
            const string ResourceUpdateModelId = "Azure.ResourceManager.Foundations.ResourceUpdateModel";

            var currentModel = model;
            while (currentModel != null)
            {
                if (currentModel.CrossLanguageDefinitionId.Equals(ResourceUpdateModelId, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                currentModel = currentModel.BaseModel;
            }

            return false;
        }

        private static string FindEnclosingResourceName(InputModelType model)
        {
            var inputLibrary = ManagementClientGenerator.Instance.InputLibrary;
            foreach (var client in inputLibrary.InputNamespace.Clients)
            {
                foreach (var method in client.Methods)
                {
                    foreach (var parameter in method.Operation.Parameters)
                    {
                        if (parameter.Type is InputModelType && parameter.Type.Name == model.Name && method.Operation.HttpMethod == "PATCH")
                        {
                            if (method.Operation.ResourceName != null)
                            {
                                return method.Operation.ResourceName;
                            }
                        }
                    }
                }
            }

            throw new InvalidOperationException($"Could not find enclosing resource name for model '{model.Name}'");
        }
    }
}
