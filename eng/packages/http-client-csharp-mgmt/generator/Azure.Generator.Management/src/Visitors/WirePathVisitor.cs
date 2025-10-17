// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
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
            // we only visit properties in model types with wire info
            if (property.EnclosingType is not ModelProvider || property.WireInfo is null)
            {
                return base.VisitProperty(property);
            }

            // TODO -- see if this is a flattened property?
            // add WirePathAttribute
            // first get out its previous attributes
            var attributes = property.Attributes;
            var wirePathAttribute = new AttributeStatement(WirePathAttributeType,
                [
                    Literal(property.WireInfo.SerializedName),
                ]);
            property.Update(attributes: [.. attributes, wirePathAttribute]);

            return base.VisitProperty(property);
        }
    }
}
