// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Storage;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageAccountSharedKeyAccessProperties
    {
        /// <summary> Indicates whether shared key access is enabled for Blob service. </summary>
        [CodeGenMember("BlobEnabled")]
        [WirePath("blob.enabled")]
        public bool? IsBlobEnabled
        {
            get
            {
                return Blob is null ? default : Blob.Enabled;
            }
            set
            {
                if (Blob is null)
                {
                    Blob = new ServiceSharedKeyAccessProperties();
                }
                Blob.Enabled = value;
            }
        }

        /// <summary> Indicates whether shared key access is enabled for File service. </summary>
        [CodeGenMember("FileEnabled")]
        [WirePath("file.enabled")]
        public bool? IsFileEnabled
        {
            get
            {
                return File is null ? default : File.Enabled;
            }
            set
            {
                if (File is null)
                {
                    File = new ServiceSharedKeyAccessProperties();
                }
                File.Enabled = value;
            }
        }

        /// <summary> Indicates whether shared key access is enabled for Queue service. </summary>
        [CodeGenMember("QueueEnabled")]
        [WirePath("queue.enabled")]
        public bool? IsQueueEnabled
        {
            get
            {
                return Queue is null ? default : Queue.Enabled;
            }
            set
            {
                if (Queue is null)
                {
                    Queue = new ServiceSharedKeyAccessProperties();
                }
                Queue.Enabled = value;
            }
        }

        /// <summary> Indicates whether shared key access is enabled for Table service. </summary>
        [CodeGenMember("TableEnabled")]
        [WirePath("table.enabled")]
        public bool? IsTableEnabled
        {
            get
            {
                return Table is null ? default : Table.Enabled;
            }
            set
            {
                if (Table is null)
                {
                    Table = new ServiceSharedKeyAccessProperties();
                }
                Table.Enabled = value;
            }
        }
    }
}
