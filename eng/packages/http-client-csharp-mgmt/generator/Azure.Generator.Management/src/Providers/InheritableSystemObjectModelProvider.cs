// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System;

namespace Azure.Generator.Management.Providers
{
    // TODO: Replace with SystemObjectModelProvider from MTG once it fully supports
    // inheritable system object models. This class and InheritableSystemObjectModelVisitor
    // should be cleaned up together.
    internal class InheritableSystemObjectModelProvider : ModelProvider
    {
        internal readonly Type _type;
        private readonly CSharpType? _frameworkBaseType;

        // WORKAROUND: Static field to pass the framework base type to BuildBaseType() during
        // base constructor execution. In C#, virtual methods called from a base constructor
        // dispatch to the derived override, but instance fields are not yet assigned at that
        // point. Since BuildBaseType() is called (and cached) during base(inputModel),
        // _frameworkBaseType is still null. We use this static to bridge the gap.
        // This is safe because SDK generation is single-threaded, and CreateDerived() scopes
        // the value tightly with try/finally.
        // TODO: Remove this workaround when InheritableSystemObjectModelProvider is refactored
        // or replaced by SystemObjectModelProvider from MTG.
        private static CSharpType? s_pendingBaseType;

        /// <summary>
        /// True when this provider represents the system base type itself (e.g., TrackedResourceData).
        /// False when it represents a derived model whose base type is a system type.
        /// </summary>
        internal bool IsSystemBase { get; }

        private InheritableSystemObjectModelProvider(Type type, InputModelType inputModel, bool isSystemBase, CSharpType? frameworkBaseType = null) : base(inputModel)
        {
            _type = type;
            _frameworkBaseType = frameworkBaseType;
            IsSystemBase = isSystemBase;
            if (isSystemBase)
            {
                CrossLanguageDefinitionId = inputModel.CrossLanguageDefinitionId;
            }
        }

        /// <summary>
        /// Creates a provider representing the system base type itself (e.g., TrackedResource → TrackedResourceData).
        /// </summary>
        internal static InheritableSystemObjectModelProvider CreateSystemBase(Type type, InputModelType inputModel)
            => new(type, inputModel, isSystemBase: true);

        /// <summary>
        /// Creates a provider for a model that extends an inheritable system type.
        /// Overrides BuildBaseType() to return the correct framework CSharpType.
        /// </summary>
        internal static InheritableSystemObjectModelProvider CreateDerived(InputModelType inputModel, CSharpType frameworkBaseType)
        {
            s_pendingBaseType = frameworkBaseType;
            try
            {
                return new InheritableSystemObjectModelProvider(
                    frameworkBaseType.FrameworkType, inputModel, isSystemBase: false, frameworkBaseType);
            }
            finally
            {
                s_pendingBaseType = null;
            }
        }

        internal string? CrossLanguageDefinitionId { get; }

        protected override string BuildName() => IsSystemBase ? (_type?.Name ?? string.Empty) : base.BuildName();

        protected override string BuildRelativeFilePath()
            => IsSystemBase
                ? throw new InvalidOperationException("This type should not be writing in generation")
                : base.BuildRelativeFilePath();

        // _type may be null when called from base constructor before field assignment.
        // The visitor's UpdateNamespace corrects this to _type.Namespace after construction.
        protected override string BuildNamespace() => IsSystemBase ? (_type?.Namespace ?? string.Empty) : base.BuildNamespace();

        protected override CSharpType? BuildBaseType()
            => IsSystemBase ? base.BuildBaseType() : (_frameworkBaseType ?? s_pendingBaseType);
    }
}
