// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.LoadTesting.Models
{
    /// <summary> The type used for update operations of the LoadTestResource. </summary>
    public partial class LoadTestingResourcePatch
    {
        /// <summary> Resource tags. </summary>
        public IDictionary<string, string> Tags { get; set; }

        /// <summary> Description of the resource. </summary>
        public string Description
        {
            get
            {
                return Properties is null ? default : Properties.Description;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new LoadTestResourceUpdateProperties();
                }
                Properties.Description = value;
            }
        }

        /// <summary> CMK Encryption property. </summary>
        public LoadTestingCmkEncryptionProperties Encryption
        {
            get
            {
                return Properties is null ? default : Properties.Encryption;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new LoadTestResourceUpdateProperties();
                }
                Properties.Encryption = value;
            }
        }
    }
}
