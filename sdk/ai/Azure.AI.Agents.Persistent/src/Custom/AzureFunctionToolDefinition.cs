// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.Agents.Persistent
{
    [CodeGenSuppress("AzureFunctionToolDefinition", typeof(InternalAzureFunctionDefinition))]
    public partial class AzureFunctionToolDefinition
    {
        /// <inheritdoc cref="InternalFunctionDefinition.Name"/>
        public string Name => InternalAzureFunction.Function.Name;

        /// <inheritdoc cref="InternalFunctionDefinition.Description"/>
        public string Description => InternalAzureFunction.Function.Description;

        /// <inheritdoc cref="InternalFunctionDefinition.Parameters"/>
        public BinaryData Parameters => InternalAzureFunction.Function.Parameters;

        /// <summary> The definition of the function that the function tool should call. </summary>
        internal InternalAzureFunctionDefinition InternalAzureFunction { get; set; }

        /// <summary>
        /// Initializes a new instance of AzureFunctionDefinition.
        /// </summary>
        /// <param name="name"> The name of the Azure function to be called. </param>
        /// <param name="description"> A description of what the Azure function does, used by the model to choose when and how to call the function. </param>
        /// <param name="inputBinding">Input storage queue.</param>
        /// <param name="outputBinding">Output storage queue.</param>
        /// <param name="parameters"> The parameters the Azure functions accepts, described as a JSON Schema object. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="description"/> or <paramref name="parameters"/> is null. </exception>
        public AzureFunctionToolDefinition(string name, string description, AzureFunctionBinding inputBinding, AzureFunctionBinding outputBinding, BinaryData parameters)
            : this(type: "azure_function", serializedAdditionalRawData: null, new InternalAzureFunctionDefinition(new InternalFunctionDefinition(name, description, parameters, serializedAdditionalRawData: null), inputBinding: inputBinding, outputBinding: outputBinding))
        {
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
            => (obj is AzureFunctionToolDefinition toolDefinition && Name == toolDefinition.Name);

        /// <inheritdoc/>
        public override int GetHashCode() => InternalAzureFunction.GetHashCode();
    }
}
