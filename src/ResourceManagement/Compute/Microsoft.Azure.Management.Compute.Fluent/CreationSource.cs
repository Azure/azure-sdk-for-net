// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    using Models;
    using Resource.Fluent.Core;

    /// <summary>
    /// The source from which managed disk or snapshot is created.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuQ3JlYXRpb25Tb3VyY2U=
    public class CreationSource
    {
        private CreationData creationData;

        /// <return>Id of the source.</return>
        ///GENMHASH:FAA258E99B7A390A4FC752A39F975D80:C5D8F0C29DEA64685F60FDB5D15F464B
        public string SourceId()
        {
            if (this.Type == CreationSourceType.FromOSDiskImage
                || this.Type == CreationSourceType.FromDataDiskImage)
            {
                return this.creationData.ImageReference.Id;
            }
            if (this.Type == CreationSourceType.ImportedFromVHD)
            {
                return this.creationData.SourceUri;
            }
            if (this.Type == CreationSourceType.CopiedFromDisk)
            {
                string sourceResourceId = this.creationData.SourceResourceId;
                if (sourceResourceId == null)
                {
                    sourceResourceId = this.creationData.SourceUri;
                }
                return sourceResourceId;
            }
            if (this.Type == CreationSourceType.CopiedFromSnapshot)
            {
                string sourceResourceId = this.creationData.SourceUri;
                if (sourceResourceId == null)
                {
                    sourceResourceId = this.creationData.SourceUri;
                }
                return sourceResourceId;
            }
            return null;
        }

        /// <return>
        /// The lun value of the data disk image if this disk or snapshot is created from
        /// a data disk image, -1 otherwise.
        /// </return>
        ///GENMHASH:7E29A6B55CE1723F616CA5F17CAACBD7:E2B0FF727DA820A1D2FF2A3C881C07FB
        public int SourceDataDiskImageLun()
        {
            if (this.Type == CreationSourceType.FromDataDiskImage)
            {
                return this.creationData.ImageReference.Lun.Value;
            }
            return -1;
        }

        /// <summary>
        /// Creates DiskSource.
        /// </summary>
        /// <param name="creationData">The creation data of managed disk or snapshot.</param>
        ///GENMHASH:038C3804D05F0A6D835C1EE21A643370:6DE306112F12EB5372C1BF530CCE3449
        public CreationSource(CreationData creationData)
        {
            this.creationData = creationData;
        }

        /// <return>Type of the source from which disk or snapshot is created.</return>
        ///GENMHASH:8442F1C1132907DE46B62B277F4EE9B7:5ED458B25DE206F7B8596E5F1D11395E
        public CreationSourceType Type
        {
            get
            {
                DiskCreateOption createOption = this.creationData.CreateOption;
                if (createOption == DiskCreateOption.FromImage)
                {
                    ImageDiskReference imageReference = this.creationData.ImageReference;
                    if (imageReference.Lun == null)
                    {
                        return CreationSourceType.FromOSDiskImage;
                    }
                    return CreationSourceType.FromDataDiskImage;
                }
                if (createOption == DiskCreateOption.Import)
                {
                    return CreationSourceType.ImportedFromVHD;
                }
                if (createOption == DiskCreateOption.Copy)
                {
                    string sourceResourceId = this.creationData.SourceResourceId;
                    if (sourceResourceId != null)
                    {
                        string resourceType = ResourceUtils.ResourceTypeFromResourceId(sourceResourceId);
                        if (resourceType.Equals("disks", System.StringComparison.OrdinalIgnoreCase))
                        {
                            return CreationSourceType.CopiedFromDisk;
                        }
                        if (resourceType.Equals("snapshots", System.StringComparison.OrdinalIgnoreCase))
                        {
                            return CreationSourceType.CopiedFromSnapshot;
                        }
                    }
                    if (this.creationData.SourceUri != null)
                    {
                        sourceResourceId = this.creationData.SourceUri;
                        string resourceType = ResourceUtils.ResourceTypeFromResourceId(sourceResourceId);
                        if (resourceType.Equals("disks", System.StringComparison.OrdinalIgnoreCase))
                        {
                            return CreationSourceType.CopiedFromDisk;
                        }
                        if (resourceType.Equals("snapshots", System.StringComparison.OrdinalIgnoreCase))
                        {
                            return CreationSourceType.CopiedFromSnapshot;
                        }
                    }
                }
                if (createOption == DiskCreateOption.Empty)
                {
                    return CreationSourceType.Empty;
                }
                return CreationSourceType.Unknown;
            }
        }
    }
}
