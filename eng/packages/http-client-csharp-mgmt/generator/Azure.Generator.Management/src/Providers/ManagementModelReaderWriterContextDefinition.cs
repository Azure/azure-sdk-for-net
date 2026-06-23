// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Management.Providers
{
    internal class ManagementModelReaderWriterContextDefinition : ModelReaderWriterContextDefinition
    {
        protected override IReadOnlyList<MethodBodyStatement> BuildAttributes()
        {
            var attributes = base.BuildAttributes();
            if (attributes.OfType<AttributeStatement>().Any(IsSystemDataBuildableAttribute))
            {
                return attributes;
            }

            // The shared context collector only discovers framework types by walking generated type
            // provider shapes. ARM custom resource data still deserializes SystemData through the
            // generated context, so management generators must keep this framework model registered.
            return [
                .. attributes,
                new AttributeStatement(
                    new CSharpType(typeof(ModelReaderWriterBuildableAttribute)),
                    [Snippet.TypeOf(typeof(SystemData))])
            ];
        }

        private static bool IsSystemDataBuildableAttribute(AttributeStatement attribute)
            => attribute.Type.FrameworkType == typeof(ModelReaderWriterBuildableAttribute)
                && attribute.Arguments is [TypeOfExpression { Type: { IsFrameworkType: true } buildableTypeExpression }]
                && buildableTypeExpression.FrameworkType == typeof(SystemData);
    }
}
