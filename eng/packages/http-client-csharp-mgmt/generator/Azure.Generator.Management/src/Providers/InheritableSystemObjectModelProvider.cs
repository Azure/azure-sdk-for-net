// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Azure.Generator.Management.Providers
{
    internal sealed class InheritableSystemObjectModelProvider : SystemObjectModelProvider
    {
        public InheritableSystemObjectModelProvider(CSharpType systemType, InputModelType inputModel)
            : base(systemType, inputModel)
        {
            InheritedProperties = systemType.IsFrameworkType
                ? [.. systemType.FrameworkType.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Select(property => new InheritedSystemObjectProperty(property.Name, GetWirePath(property)))]
                : [];
        }

        internal IReadOnlyList<InheritedSystemObjectProperty> InheritedProperties { get; }

        private static string? GetWirePath(PropertyInfo property)
            => property.GetCustomAttributes(inherit: true)
                .FirstOrDefault(attribute => attribute.GetType().Name == "WirePathAttribute")
                ?.ToString();
    }

    internal sealed record InheritedSystemObjectProperty(string Name, string? WirePath);
}
