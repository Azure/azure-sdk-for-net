// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Azure.Generator.Management.Providers
{
    internal static class ManagementProviderBodyDependencyHelper
    {
        private static readonly ConditionalWeakTable<MethodProvider, BodyDependencyTypes> _bodyDependencyTypes = new();

        private sealed class BodyDependencyTypes
        {
            required public IReadOnlyList<CSharpType> Values { get; init; }
        }

        public static void RegisterBodyDependencyTypes(MethodProvider method, IReadOnlyList<CSharpType> bodyDependencyTypes)
        {
            if (bodyDependencyTypes.Count == 0)
            {
                return;
            }

            _bodyDependencyTypes.Remove(method);
            _bodyDependencyTypes.Add(method, new BodyDependencyTypes { Values = bodyDependencyTypes });
        }

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
                if (_bodyDependencyTypes.TryGetValue(method, out var bodyDependencyTypes))
                {
                    dependencies.AddRange(bodyDependencyTypes.Values);
                }
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
