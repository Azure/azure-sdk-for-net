// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;

namespace Azure.Generator.Visitors
{
    internal class LroMethodProviderCollection : ScmMethodProviderCollection
    {
        private readonly InputLongRunningServiceMethod _lroServiceMethod;
        private const string PipelinePropertyName = "Pipeline";

        public LroMethodProviderCollection(InputServiceMethod serviceMethod, TypeProvider enclosingType) : base(serviceMethod, enclosingType)
        {
            _lroServiceMethod = (InputLongRunningServiceMethod)serviceMethod;
        }

        protected override IReadOnlyList<ScmMethodProvider> BuildMethods()
        {
            var methods = base.BuildMethods();
            foreach (var method in methods)
            {
                if (_lroServiceMethod.Response.Type != null)
                {
                    var returnType = method.IsProtocolMethod
                        ? typeof(BinaryData)
                        : AzureClientGenerator.Instance.TypeFactory.CreateCSharpType(_lroServiceMethod.Response.Type)!;

                    var isAsync = method.Signature.ReturnType!.GetGenericTypeDefinition().Equals(typeof(Task<>));

                    // Update the method signature
                    var parameters = new List<ParameterProvider>(method.Signature.Parameters);
                    parameters.Insert(0, new ParameterProvider(
                        name: "waitUntil",
                        type: typeof(WaitUntil),
                        description: FormattableStringFactory.Create(
                                    "<see cref=\"WaitUntil.Completed\"/> if the method should wait to return until the long-running operation " +
                                     "has completed on the service; <see cref=\"WaitUntil.Started\"/> if it should return after starting the operation. " +
                                     "For more information on long-running operations, please see " +
                                     "<see href=\"https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md\"> " +
                                     "Azure.Core Long-Running Operation samples</see>.")));
                    method.Signature.Update(
                        parameters: parameters,
                        returnType: isAsync
                            ? new CSharpType(typeof(Task<>),
                                new CSharpType(typeof(Operation<>), returnType))
                            : new CSharpType(typeof(Operation<>), returnType));

                    // Needed to update the XML docs
                    method.Update(signature: method.Signature);

                    // Update the return statement
                    var statements = method.BodyStatements!.Flatten();
                    if (statements.First() is TryCatchFinallyStatement tryCatchFinally)
                    {
                        // replace the final statement of the try block
                        var returnStatement = tryCatchFinally.Try.Flatten().Last();
                        if (returnStatement is ExpressionStatement { Expression: KeywordExpression { Keyword: "return" } returnExpression })
                        {
                            PropertyProvider pipeline = method.EnclosingType.CanonicalView.Properties
                                .First(p => p.Name == PipelinePropertyName || p.OriginalName?.Equals(PipelinePropertyName) == true);
                            if (returnExpression.Expression is InvokeMethodExpression invokeMethodExpression)
                            {
                                // invokeMethodExpression.InstanceReference = Snippet.Static(typeof(ProtocolOperationHelpers));
                                // invokeMethodExpression.MethodName = $"ProcessMessage{(isAsync ? "Async" : string.Empty)}";
                                // invokeMethodExpression.Arguments = [pipeline]
                            }
                        }
                    }
                }
                else
                {
                    // no return type
                }
            }

            return methods;
        }
    }
}