// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

#nullable disable

namespace Azure.ResourceManager.EnergyServices.Models
{
    /// <summary> Defines the partition add/ delete action properties. </summary>
    [CodeGenSuppress("Name")]
    public partial class DataPartitionAddOrRemoveContent
    {
        /// <summary> The list of Energy services resource&apos;s Data Partition Names. </summary>
        internal DataPartitionName Name { get; set; }
        /// <summary> Gets or sets the name. </summary>
        public string DataPartitionName
        {
            get => Name is null ? default(string) : Name.Name;
            set
            {
                if (Name is null)
                    Name = new DataPartitionName();
                Name.Name = value;
            }
        }
    }
}
