// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
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

            foreach (var property in model.Properties)
            {
                if (property is InputModelProperty modelProperty && TryTransformUrlToUri(property.Name, out var newPropertyName))
                {
                    modelProperty.Update(name: newPropertyName);
                }

                // rename "Type" property to "ResourceType" in input models so that the docs will be generated correctly
                if (property.Name.Equals("Type", StringComparison.OrdinalIgnoreCase) && property is InputModelProperty typeProperty)
                {
                    typeProperty.Update(name: ResourceTypeName);
                }
            }
            return base.PreVisitModel(model, type);
        }

        protected override TypeProvider? VisitType(TypeProvider type)
        {
            if (type is ModelProvider model)
            {
                foreach (var property in model.Properties)
                {
                    if (property.Name.Equals(ResourceTypeName, StringComparison.OrdinalIgnoreCase))
                    {
                        property.Update(type: typeof(ResourceType));
                    }
                }

                foreach (var constructor in model.Constructors)
                {
                    foreach (var param in constructor.Signature.Parameters)
                    {
                        if (param.Name.Equals(ResourceTypeName, StringComparison.OrdinalIgnoreCase))
                        {
                            param.Update(type: typeof(ResourceType));
                        }
                    }
                }
            }
            return base.VisitType(type);
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
