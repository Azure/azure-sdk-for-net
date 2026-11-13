// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.Generator.Management.Providers
{
    /// <summary>
    /// Represents a management convenience method together with generated types referenced only by its body.
    /// MTG builds a provider reference map before code emission to determine which generated providers to retain.
    /// Management method bodies can reference collection results, pageable wrappers, LRO wrappers, and operation
    /// sources that do not appear in their signatures. Enclosing management providers aggregate this metadata
    /// through <see cref="GetBodyDependencyTypes"/> so the reference map includes those required helpers.
    /// </summary>
    internal sealed class ManagementMethodProvider : ScmMethodProvider
    {
        /// <summary>
        /// Gets the generated types referenced only by this method's implementation.
        /// </summary>
        public IReadOnlyList<CSharpType> BodyDependencyTypes { get; }

        public ManagementMethodProvider(
            MethodSignature signature,
            MethodBodyStatement bodyStatements,
            TypeProvider enclosingType,
            ScmMethodKind methodKind,
            TypeProvider? collectionDefinition = null,
            InputServiceMethod? serviceMethod = null,
            IReadOnlyList<CSharpType>? additionalBodyDependencyTypes = null)
            : base(
                signature,
                bodyStatements,
                enclosingType,
                methodKind,
                collectionDefinition: collectionDefinition,
                serviceMethod: serviceMethod)
        {
            var dependencies = new List<CSharpType>();
            if (collectionDefinition is not null)
            {
                dependencies.Add(collectionDefinition.Type);
            }

            AddPageableWrapperDependency(dependencies, signature.ReturnType);
            if (additionalBodyDependencyTypes is not null)
            {
                dependencies.AddRange(additionalBodyDependencyTypes);
            }

            BodyDependencyTypes = dependencies.Distinct().ToArray();
        }

        public static IReadOnlyList<CSharpType> GetBodyDependencyTypes(IEnumerable<MethodProvider> methods)
            // Methods with body-only generated dependencies must use ManagementMethodProvider.
            // Plain MethodProvider instances are intentionally ignored because they currently have none.
            => methods
                .OfType<ManagementMethodProvider>()
                .SelectMany(method => method.BodyDependencyTypes)
                .Distinct()
                .ToArray();

        private static void AddPageableWrapperDependency(List<CSharpType> dependencies, CSharpType? returnType)
        {
            var unwrappedReturnType = UnwrapTask(returnType);
            if (unwrappedReturnType is null ||
                (!unwrappedReturnType.Equals(typeof(Pageable<>)) && !unwrappedReturnType.Equals(typeof(AsyncPageable<>))) ||
                unwrappedReturnType.Arguments.Count == 0)
            {
                return;
            }

            var itemType = unwrappedReturnType.Arguments[0];
            // Method construction is lazy and occurs after OutputLibrary initializes its resource providers.
            var outputLibrary = ManagementClientGenerator.Instance.OutputLibrary;
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
