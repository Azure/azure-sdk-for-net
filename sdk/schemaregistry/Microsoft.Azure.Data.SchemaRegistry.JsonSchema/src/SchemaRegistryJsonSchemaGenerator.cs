// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Data.SchemaRegistry.JsonSchema
{
    /// <summary>
    /// TODO.
    /// </summary>
    public abstract class SchemaRegistryJsonSchemaGenerator
    {
        ///// <summary>
        ///// TODO.
        ///// </summary>
        ///// <param name="data"></param>
        ///// <param name="dataType"></param>
        ///// <param name="schemaDefinition"></param>
        ///// <param name="cancellationToken"></param>
        ///// <returns></returns>
        //public virtual async Task<bool> IsValidToSchemaAsync(Object data, Type dataType, string schemaDefinition, CancellationToken cancellationToken)
        //{
        //    await Task.Yield();
        //    return true;
        //}

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataType"></param>
        /// <param name="schemaDefinition"></param>
        /// <returns></returns>
        public virtual bool IsValidToSchema(Object data, Type dataType, string schemaDefinition)
        {
            return true;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public abstract string GenerateSchemaFromObject(Type dataType);
    }
}
