// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.IO;

namespace Azure.Generator.Management.Providers
{
    internal class ResourceDataModelProvider : ModelProvider
    {
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

        protected override string BuildNamespace()
            => ManagementClientGenerator.Instance.TypeFactory.PrimaryNamespace;

        protected override string BuildRelativeFilePath()
            => Path.Combine("src", "Generated", $"{Name}.cs");
    }
}
