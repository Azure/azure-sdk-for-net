// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Primitives;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Azure.Generator.Management
{
    internal class NameVisitor : ScmLibraryVisitor
    {
        private const string ResourceTypeName = "ResourceType";

        protected override ModelProvider? PreVisitModel(InputModelType model, ModelProvider? type)
        {
            if (type is not null && TryTransformUrlToUri(model.Name, out var newName))
            {
                type.Update(name: newName);
            }

            // rename "Type" property to "ResourceType" in Azure.ResourceManager.CommonTypes.Resource
            bool typePropertyRenamed = false;
            if (model.CrossLanguageDefinitionId.Equals(KnownManagementTypes.ArmResource))
            {
                foreach (var property in model.Properties)
                {
                    if (!typePropertyRenamed && property.Type is InputPrimitiveType primitiveType && KnownManagementTypes.TryGetPrimitiveType(primitiveType.CrossLanguageDefinitionId, out var knownType)
                        && knownType.Equals(typeof(ResourceType)) && property is InputModelProperty typeProperty)
                    {
                        typePropertyRenamed = true;
                        typeProperty.Update(name: ResourceTypeName, isRequired: true);
                    }
                    if (property is InputModelProperty modelProperty && TryTransformUrlToUri(property.Name, out var newPropertyName))
                    {
                        modelProperty.Update(name: newPropertyName);
                    }
                }
            }
            else
            {
                foreach (var property in model.Properties)
                {
                    if (property is InputModelProperty modelProperty && TryTransformUrlToUri(property.Name, out var newPropertyName))
                    {
                        modelProperty.Update(name: newPropertyName);
                    }
                }
            }
            return base.PreVisitModel(model, type);
        }

        private bool TryTransformUrlToUri(string name, [MaybeNullWhen(false)] out string newName)
        {
            const char i = 'i';
            const string UrlSuffix = "Url";
            newName = null;
            if (name.Length < UrlSuffix.Length)
            {
                return false;
            }

            var span = name.AsSpan();
            // check if this ends with `Url`
            if (span.EndsWith(UrlSuffix.AsSpan(), StringComparison.Ordinal))
            {
                Span<char> newSpan = span.ToArray();
                newSpan[^1] = i;

                newName = new string(newSpan);
                return true;
            }

            return false;
        }
    }
}
