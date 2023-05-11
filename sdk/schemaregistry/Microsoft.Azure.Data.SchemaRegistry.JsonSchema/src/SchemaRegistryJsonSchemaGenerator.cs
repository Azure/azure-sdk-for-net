// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Data.SchemaRegistry.JsonSchema
{
    /// <summary>
    /// TODO.
    /// </summary>
    public abstract class SchemaRegistryJsonSchemaGenerator
    {
        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataType"></param>
        /// <param name="schemaDefinition"></param>
        /// <returns></returns>
        public virtual async ValueTask<bool> IsValidToSchema(Object data, Type dataType, string schemaDefinition)
        {
            await Task.Yield();
            return true;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public abstract string GenerateSchemaFromObject(Object data, Type dataType);
    }
}
