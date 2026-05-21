// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System;

namespace Azure.Generator.Management.Providers
{
    internal class ResourceDataModelProvider : ModelProvider
    {
        private static readonly CSharpType _armResourceType = typeof(ArmResource);
        private readonly InputModelType _model;

        public ResourceDataModelProvider(InputModelType model) : base(model)
        {
            _model = model;
        }

        protected override string BuildName()
        {
            var name = base.BuildName();
            return name.EndsWith("Data", StringComparison.Ordinal) ? name : $"{name}Data";
        }

        protected override CSharpType? BuildBaseType()
        {
            var baseType = base.BuildBaseType();
            if (baseType is null || !baseType.AreNamesEqual(_armResourceType))
            {
                return baseType;
            }

            return _model.BaseModel is null
                ? null
                : ManagementClientGenerator.Instance.TypeFactory.CreateCSharpType(_model.BaseModel);
        }
    }
}
