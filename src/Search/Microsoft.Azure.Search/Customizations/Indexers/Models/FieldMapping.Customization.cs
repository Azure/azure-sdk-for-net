// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    public partial class FieldMapping
    {
        /// <summary>
        /// Initializes a new instance of the FieldMapping class.
        /// </summary>
        /// <param name="sourceFieldName">The name of the field in the data source.</param>
        /// <param name="mappingFunction">A function to apply to each source field value before indexing.</param>
        public FieldMapping(string sourceFieldName, FieldMappingFunction mappingFunction) : this(sourceFieldName, sourceFieldName, mappingFunction)
        {
            // Other constructor does all initialization.
        }
    }
}
