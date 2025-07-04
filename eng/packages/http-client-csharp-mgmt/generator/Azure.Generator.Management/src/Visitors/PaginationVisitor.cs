// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using System;
using System.Linq;

namespace Azure.Generator.Management.Visitors
{
    internal class PaginationVisitor : ScmLibraryVisitor
    {
        protected override TypeProvider? VisitType(TypeProvider type)
        {
            if (type is not null && type.Name.AsSpan().Contains("CollectionResult".AsSpan(), StringComparison.Ordinal))
            {
                var asPagesMethod = type.Methods.Single(m => m.Signature.Name.Equals("AsPages"));
                var bodyStatements = asPagesMethod.BodyStatements!.AsStatement();
                foreach (var statement in bodyStatements)
                {
                }
            }
            return type;
        }
    }
}
