// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace ProxyLayerParser
{
    /// <summary>
    /// Metadata for creating a BatchRequest object.
    /// </summary>
    public struct BatchRequestTypeGenerationInfo
    {
        /// <summary>
        /// The operation type, for example if the operation method was PoolOperations.AddWithHttpMessagesAsync, this would be "Add".
        /// </summary>
        public string OperationType { get; }

        /// <summary>
        /// The parameter type, or null if there is no parameter. PoolOperations.AddWithHttpMessagesAsync has a parameter of type PoolAddParameter.
        /// </summary>
        public string ParameterType { get; }

        /// <summary>
        /// The options type. Every operation has an options type. For example, PoolOperations.AddWithHttpMessagesAsync has an options type of PoolAddOptions.
        /// </summary>
        public string OptionsType { get; }

        /// <summary>
        /// The return type. Every operation has a return type. For example, PoolOperations.AddWithHttpMessagesAsync has a return type of PoolAddHeaders.
        /// </summary>
        public string ReturnType { get; }

        public BatchRequestTypeGenerationInfo(string operationType, string parameterType, string optionsType, string returnType)
        {
            this.OperationType = operationType;
            this.ParameterType = parameterType;
            this.OptionsType = optionsType;
            this.ReturnType = returnType;
        }
    }
}
