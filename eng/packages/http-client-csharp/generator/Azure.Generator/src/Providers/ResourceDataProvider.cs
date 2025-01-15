// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Generator.CSharp.Input;
using Microsoft.Generator.CSharp.Providers;
using System.IO;

namespace Azure.Generator.Providers
{
    internal class ResourceDataProvider : ModelProvider
    {
        private readonly InputModelType _inputModel;

        public ResourceDataProvider(InputModelType inputModel) : base(inputModel)
        {
            _inputModel = inputModel;
        }

        protected override string BuildName() => $"{base.BuildName()}Data";

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", $"{Name}.cs");
    }
}
