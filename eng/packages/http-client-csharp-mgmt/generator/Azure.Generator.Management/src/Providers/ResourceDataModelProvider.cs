// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System;

namespace Azure.Generator.Management.Providers
{
    /// <summary>
    /// ModelProvider used for Azure resource data classes.
    /// </summary>
    /// <remarks>
    /// The only customization is <see cref="BuildName"/>: it appends the "Data" suffix at the very
    /// first Type construction, so that any <c>CustomCodeView</c> lookup uses the suffixed name
    /// rather than the resource client's name.
    /// <para>
    /// Without this override, a user's resource client partial (e.g. <c>partial class FooResource : ArmResource</c>)
    /// matches the input model name <c>FooResource</c>, causing <c>CustomCodeView.BaseType</c> to be
    /// captured into <c>CSharpType._baseType</c> when <c>Type</c> is first accessed. A later
    /// <c>type.Update(name: "FooResourceData")</c> cannot rewrite <c>_baseType</c> (it is
    /// <c>private readonly</c>), so the generated data class incorrectly extends <c>ArmResource</c>
    /// instead of the system-resolved <c>TrackedResourceData</c>.
    /// </para>
    /// </remarks>
    internal class ResourceDataModelProvider : ModelProvider
    {
        private readonly InputModelType _inputModel;

        public ResourceDataModelProvider(InputModelType inputModel)
            : base(inputModel)
        {
            _inputModel = inputModel;
        }

        protected override string BuildName()
        {
            var name = base.BuildName();
            return name.EndsWith("Data", StringComparison.Ordinal) ? name : $"{name}Data";
        }
    }
}
