// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator.Visitors
{
    /// <summary>
    /// For pageable types, we don't need the explicit operator for the model since protocol paging methods use BinaryData rather than
    /// Response for the protocol methods.
    /// </summary>
    internal class ExplicitOperatorRemovalVisitor : ScmLibraryVisitor
    {
        protected override void VisitLibrary(OutputLibrary outputLibrary)
        {
            // Precompute the client method return types and paging types
            var clientReturnTypes = new HashSet<CSharpType>();
            var pagingModelTypes = new HashSet<CSharpType>();
            foreach (var client in outputLibrary.TypeProviders.OfType<ClientProvider>())
            {
                foreach (var method in client.Methods)
                {
                    var returnType = method.Signature.ReturnType;
                    if (returnType?.IsGenericType != true)
                    {
                        continue;
                    }

                    // We only care about Response<T> and Pageable<T> types
                    var genericType = returnType.GetGenericTypeDefinition();
                    if (genericType?.Equals(typeof(Response<>)) == true)
                    {
                        clientReturnTypes.Add(returnType.Arguments[0]);
                    }
                    if (genericType?.Equals(typeof(Pageable<>)) == true)
                    {
                        pagingModelTypes.Add(returnType.Arguments[0]);
                    }
                }
            }
            foreach (var model in outputLibrary.TypeProviders.OfType<ModelProvider>())
            {
                // only consider the paging models
                if (!pagingModelTypes.Contains(model.Type))
                {
                    continue;
                }
                var serialization = model.SerializationProviders.FirstOrDefault();
                if (serialization == null)
                {
                    continue;
                }
                var explicitOperator = serialization.Methods
                    .FirstOrDefault(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Explicit) &&
                                         m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Operator));

                // if the only use of the explicit operator is in a paging service method, remove it
                if (explicitOperator != null)
                {
                    if (!clientReturnTypes.Contains(model.Type))
                    {
                        serialization.Update(methods: serialization.Methods.Where(m => m != explicitOperator).ToList());
                    }
                }
            }
        }
    }
}