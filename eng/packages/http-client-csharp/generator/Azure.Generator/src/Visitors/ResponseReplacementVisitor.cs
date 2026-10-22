// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Visitors
{
    internal class ResponseReplacementVisitor : ScmLibraryVisitor
    {
        protected override ScmMethodProvider? VisitMethod(ScmMethodProvider method)
        {
            if (method.Kind != ScmMethodKind.Convenience
                || method.ServiceMethod is not InputBasicServiceMethod { IsOverride: true } serviceMethod
                || method.BodyStatements is null
                || serviceMethod.Response.Type is not (null or InputPrimitiveType { Kind: InputPrimitiveTypeKind.Bytes }))
            {
                return method;
            }

            bool replaceWithBytes = serviceMethod.Response.Type is not null;
            CSharpType responseType = replaceWithBytes
                ? new CSharpType(typeof(Response<>), typeof(BinaryData))
                : typeof(Response);
            var returnType = method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Async)
                ? new CSharpType(typeof(Task<>), responseType)
                : responseType;
            if (returnType.Equals(method.Signature.ReturnType))
            {
                return method;
            }

            var statements = method.BodyStatements.ToList();
            for (int i = 0; i < statements.Count; i++)
            {
                if (statements[i] is ExpressionStatement
                    {
                        Expression: AssignmentExpression
                        {
                            Variable: DeclarationExpression { Variable: var result }
                        }
                    }
                    && result.Type.Equals(typeof(Response)))
                {
                    // Keep request preparation and the protocol call, but do not deserialize the service model.
                    var body = statements.Take(i + 1).ToList();
                    body.Add(Return(replaceWithBytes
                        ? Static(typeof(Response)).Invoke(nameof(Response.FromValue), [result.Property(nameof(Response.Content)), result])
                        : result));
                    method.Signature.Update(returnType: returnType);
                    method.Update(signature: method.Signature, bodyStatements: body);
                    return method;
                }
            }

            throw new InvalidOperationException(
                $"Cannot replace the response of '{method.Signature.Name}': the protocol response declaration was not found.");
        }
    }
}
