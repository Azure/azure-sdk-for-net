// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Utilities
{
    internal static class InputExtensions
    {
        /// <summary>
        /// Union all the properties on myself and all the properties from my parents
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        internal static IEnumerable<InputModelProperty> GetAllProperties(this InputModelType inputModel)
        {
            return inputModel.GetAllBaseModels().SelectMany(parentInputModelType => parentInputModelType.Properties).Concat(inputModel.Properties);
        }
    }
}
