// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator.Management.Visitors;

internal class TypeFilterVisitor : ScmLibraryVisitor
{
    /// <inheritdoc/>
    protected override TypeProvider? VisitType(TypeProvider type)
    {
        // This visitor is used to filter types, so we return null to remove the type from the output.
        if (type is not null && type.Name.EndsWith("ClientBuilderExtensions"))
        {
            return null;
        }
        return type;
    }
}
