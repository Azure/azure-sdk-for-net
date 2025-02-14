// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System.IO;

namespace Azure.Generator.Providers
{
    // TODO: replace this with visitor
    internal class ResourceDataProvider : ModelProvider
    {
        public ResourceDataProvider(InputModelType inputModel) : base(inputModel)
        {
        }

        protected override string BuildName() => $"{base.BuildName()}Data";

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", $"{Name}.cs");
    }
}
