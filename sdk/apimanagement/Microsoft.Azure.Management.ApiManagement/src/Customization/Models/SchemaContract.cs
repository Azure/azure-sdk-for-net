// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.ApiManagement.Models
{
    using System;
    using Newtonsoft.Json.Linq;

    public partial class SchemaContract
    {
        /// <summary>
        /// Gets the Wsdl Schema from the Document JObject
        /// </summary>
        public string WsdlSchema
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(this.ContentType) &&
                    this.ContentType.Equals("application/vnd.ms-azure-apim.xsd+xml", StringComparison.OrdinalIgnoreCase))
                {

                    return this.Value;
                }
                return null;
            }
        }
    }
}
