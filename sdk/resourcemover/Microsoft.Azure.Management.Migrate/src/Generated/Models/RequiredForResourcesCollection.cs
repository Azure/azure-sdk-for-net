// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Migrate.ResourceMover.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Required for resources collection.
    /// </summary>
    public partial class RequiredForResourcesCollection
    {
        /// <summary>
        /// Initializes a new instance of the RequiredForResourcesCollection
        /// class.
        /// </summary>
        public RequiredForResourcesCollection()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the RequiredForResourcesCollection
        /// class.
        /// </summary>
        /// <param name="sourceIds">Gets or sets the list of source Ids for
        /// which the input resource is required.</param>
        public RequiredForResourcesCollection(IList<string> sourceIds = default(IList<string>))
        {
            SourceIds = sourceIds;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the list of source Ids for which the input resource is
        /// required.
        /// </summary>
        [JsonProperty(PropertyName = "sourceIds")]
        public IList<string> SourceIds { get; set; }

    }
}
