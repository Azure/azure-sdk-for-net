// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System.IO;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;

namespace Azure.Generator.Providers
{
    internal class ResourceDataSerializationProvider : MrwSerializationTypeDefinition
    {
        public ResourceDataSerializationProvider(InputModelType inputModel, ModelProvider modelProvider) : base(inputModel, modelProvider)
        {
        }

        protected override string BuildName() => $"{base.BuildName()}Data";

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", $"{Name}.Serialization.cs");
    }
}
