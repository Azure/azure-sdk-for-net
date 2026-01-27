// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.DataBox.Models
{
    public abstract partial class DataBoxValidationContent
    {
        /// <summary> Initializes a new instance of <see cref="DataBoxValidationContent"/>. </summary>
        /// <param name="individualRequestDetails"> List of request details contain validationType and its request as key and value respectively. </param>
        protected DataBoxValidationContent(IEnumerable<DataBoxValidationInputContent> individualRequestDetails)
        {
            IndividualRequestDetails = individualRequestDetails.ToList();
        }
    }
}
