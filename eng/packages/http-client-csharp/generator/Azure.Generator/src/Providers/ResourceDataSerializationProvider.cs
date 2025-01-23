// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Input;
using Microsoft.Generator.CSharp.Providers;
using System.IO;

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
