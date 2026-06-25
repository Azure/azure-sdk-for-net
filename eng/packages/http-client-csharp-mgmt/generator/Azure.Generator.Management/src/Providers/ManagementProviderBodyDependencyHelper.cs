// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.Generator.Management.Providers
{
    internal static class ManagementProviderBodyDependencyHelper
    {
        public static IReadOnlyList<CSharpType> GetBodyDependencyTypes(IEnumerable<MethodProvider> methods)
        {
            var dependencies = new List<CSharpType>();
            var outputLibrary = ManagementClientGenerator.Instance.OutputLibrary;

            foreach (var method in methods)
            {
                if (method is ScmMethodProvider { CollectionDefinition: { } collectionDefinition })
                {
                    dependencies.Add(collectionDefinition.Type);
                }

                AddPageableWrapperDependency(dependencies, method.Signature.ReturnType, outputLibrary);
                AddOperationSourceDependency(dependencies, method.Signature.ReturnType, outputLibrary);
            }

            return dependencies.Distinct().ToArray();
        }

        private static void AddPageableWrapperDependency(List<CSharpType> dependencies, CSharpType? returnType, ManagementOutputLibrary outputLibrary)
        {
            var unwrappedReturnType = UnwrapTask(returnType);
            if (unwrappedReturnType == null ||
                (!unwrappedReturnType.Equals(typeof(Pageable<>)) && !unwrappedReturnType.Equals(typeof(AsyncPageable<>))) ||
                unwrappedReturnType.Arguments.Count == 0)
            {
                return;
            }

            var itemType = unwrappedReturnType.Arguments[0];
            if (!outputLibrary.ResourceProviders.Any(resource => resource.Type.Equals(itemType)))
            {
                return;
            }

            dependencies.Add(unwrappedReturnType.Equals(typeof(AsyncPageable<>))
                ? outputLibrary.AsyncPageableWrapper.Type
                : outputLibrary.PageableWrapper.Type);
        }

        private static void AddOperationSourceDependency(List<CSharpType> dependencies, CSharpType? returnType, ManagementOutputLibrary outputLibrary)
        {
            var unwrappedReturnType = UnwrapTask(returnType);
            if (unwrappedReturnType == null ||
                !unwrappedReturnType.Equals(typeof(ArmOperation<>)) ||
                unwrappedReturnType.Arguments.Count == 0)
            {
                return;
            }

            var resultType = unwrappedReturnType.Arguments[0];
            var resourceProvider = outputLibrary.ResourceProviders.FirstOrDefault(resource => resource.Type.Equals(resultType));
            if (resourceProvider != null)
            {
                dependencies.Add(outputLibrary.GetOperationSource(resourceProvider).Type);
                return;
            }

            if (outputLibrary.OperationSourceDict.TryGetValue(resultType, out var operationSource))
            {
                dependencies.Add(operationSource.Type);
            }
        }

        private static CSharpType? UnwrapTask(CSharpType? type)
        {
            if (type?.Equals(typeof(Task<>)) == true && type.Arguments.Count > 0)
            {
                return type.Arguments[0];
            }

            return type;
        }
    }
}
