// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Primitives;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System.Collections.Generic;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Visitors
{
    /// <summary>
    /// This visitor will visit all properties in model types and add WirePathAttribute to all its properties with wire path info.
    /// </summary>
    internal class WirePathVisitor : ScmLibraryVisitor
    {
        private CSharpType WirePathAttributeType => ManagementClientGenerator.Instance.OutputLibrary.WirePathAttributeDefinition.Type;

        protected override PropertyProvider? VisitProperty(PropertyProvider property)
        {
            if (property.EnclosingType is not ModelProvider || // we only add wire path in models
                property.WireInfo is null) // we skip those properties without a wire info
            {
                return base.VisitProperty(property);
            }

            // add WirePathAttribute
            // first get out its previous attributes
            var attributes = property.Attributes;
            // get the wire path
            var wirePath = GetWirePath(property);
            // add WirePathAttribute to the list
            var wirePathAttribute = new AttributeStatement(WirePathAttributeType,
                [
                    Literal(wirePath),
                ]);
            property.Update(attributes: [.. attributes, wirePathAttribute]);

            return base.VisitProperty(property);
        }

        private static string GetWirePath(PropertyProvider property)
        {
            // if the property is not flattened, return its serialized name
            if (property is not FlattenedPropertyProvider flattenedProperty)
            {
                return property.WireInfo!.SerializedName;
            }

            // if the property is flattened, we need to recursively get the wire path from its flattened from property until we get a normal property
            var wirePathSegments = new Stack<string>();
            wirePathSegments.Push(property.WireInfo!.SerializedName);
            var currentProperty = property;
            while (currentProperty is FlattenedPropertyProvider currentFlattenedProperty)
            {
                var parentProperty = currentFlattenedProperty.PropertyFlattenedFrom;
                wirePathSegments.Push(parentProperty.WireInfo!.SerializedName);
                currentProperty = parentProperty;
            }

            return string.Join('.', wirePathSegments);
        }
    }
}
