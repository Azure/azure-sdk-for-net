using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Rest;
using Microsoft.Azure;

namespace Microsoft.Azure.Management.Storage.Models
{
    /// <summary>
    /// </summary>
    public partial class StorageAccountCreateResponse
    {
        /// <summary>
        /// Gets the storage account with the created properties populated.
        /// </summary>
        [JsonProperty(PropertyName = "StorageAccount")]
        public StorageAccount StorageAccount { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.StorageAccount != null)
            {
                this.StorageAccount.Validate();
            }
        }
    }
}
