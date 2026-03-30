// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System;

namespace Azure.Generator.Management.Providers
{
    /// <summary>
    /// A ModelProvider for resource data models whose base type is an inheritable system type
    /// (e.g., TrackedResource → TrackedResourceData, ProxyResource → ResourceData).
    ///
    /// The framework eagerly caches CSharpType (including BaseType) during model construction.
    /// The default ModelProvider.BuildBaseType() returns BaseModelProvider.Type, which for
    /// InheritableSystemObjectModelProvider produces a non-framework CSharpType.
    /// This subclass overrides BuildBaseType() to return the correct framework CSharpType,
    /// ensuring the generated class declaration uses the real system type.
    /// </summary>
    internal class ResourceDataModelProvider : ModelProvider
    {
        private readonly CSharpType _frameworkBaseType;

        // Thread-local to pass the framework base type to BuildBaseType() during base constructor.
        // BuildBaseType() can be called via virtual dispatch during base(inputModel) before
        // _frameworkBaseType is assigned. This static avoids the stale-field issue.
        [ThreadStatic]
        private static CSharpType? t_pendingBaseType;

        private ResourceDataModelProvider(InputModelType inputModel, CSharpType frameworkBaseType) : base(inputModel)
        {
            _frameworkBaseType = frameworkBaseType;
        }

        internal static ResourceDataModelProvider Create(InputModelType inputModel, CSharpType frameworkBaseType)
        {
            t_pendingBaseType = frameworkBaseType;
            try
            {
                return new ResourceDataModelProvider(inputModel, frameworkBaseType);
            }
            finally
            {
                t_pendingBaseType = null;
            }
        }

        protected override CSharpType? BuildBaseType() => _frameworkBaseType ?? t_pendingBaseType;
    }
}
