// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Primitives;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using System.IO;

namespace Azure.Generator.Management.Providers
{
    /// <summary>
    /// ModelProvider used for non-resource management-plane models.
    /// </summary>
    internal class ManagementModelProvider : ScmModelProvider
    {
        private readonly InputModelType _inputModel;
        internal bool IsOperationStatusPayload { get; }
        internal bool HasPersistenceOnlyExtensions => OperationStatusErrorModel.HasPersistenceOnlyExtensions(_inputModel);

        public ManagementModelProvider(InputModelType inputModel)
            : base(inputModel)
        {
            _inputModel = inputModel;
            IsOperationStatusPayload = OperationStatusErrorModel.IsStatusPayloadModel(inputModel);
        }

        protected override string BuildName()
            => OperationStatusErrorModel.NeedsGeneratedName(_inputModel)
                && ManagementClientGenerator.Instance.InputLibrary.OperationStatusOutputNames.TryGetValue(_inputModel, out var name)
                ? name : base.BuildName();

        internal string NormalizeRequestModelName(string name) => NormalizeTypeNameForNewContract(name);

        // Non-resource management-plane models are emitted under .Models. Build their
        // Type there up front so references cached before namespace visitors run do not
        // keep a stale root namespace.
        protected override string BuildNamespace()
            => $"{ManagementClientGenerator.Instance.TypeFactory.PrimaryNamespace}.Models";

        protected override string BuildRelativeFilePath()
            => Path.Combine("src", "Generated", "Models", $"{Type.Name}.cs");
    }
}
