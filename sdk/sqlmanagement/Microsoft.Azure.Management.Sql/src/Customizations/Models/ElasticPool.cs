// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Sql.Models
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;

    public partial class ElasticPool : TrackedResource
    {
        /// <summary>
        /// Gets or sets the edition of the elastic pool. Possible values include: 'Basic', 'Standard', 'Premium'
        /// </summary>
        [JsonIgnore]
        public string Edition
        {
            get
            {
                return Sku?.Tier;
            }
        }

        /// <summary>
        /// Gets the total shared DTU for the database elastic pool.
        /// </summary>
        [JsonIgnore]
        public int? Dtu
        {
            get
            {
                return Sku?.Capacity;
            }
        }

        /// <summary>
        /// Gets storage limit for the database elastic pool in MB.
        /// </summary>
        [JsonIgnore]
        public int? StorageMB
        {
            get
            {
                if (MaxSizeBytes == null)
                {
                    return null;
                }

                return (int)(MaxSizeBytes / 1024 / 1024);
            }
            set
            {
                MaxSizeBytes = value * 1024 * 1024;
            }
        }

        /// <summary>
        /// Gets or sets the minimum DTU all databases are guaranteed.
        /// </summary>
        [JsonIgnore]
        public int? DatabaseDtuMin
        {
            get
            {
                return (int?)PerDatabaseSettings?.MinCapacity;
            }
            set
            {
                if (PerDatabaseSettings == null)
                {
                    PerDatabaseSettings = new ElasticPoolPerDatabaseSettings();
                }

                PerDatabaseSettings.MinCapacity = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum DTU any one database can consume.
        /// </summary>
        [JsonIgnore]
        public int? DatabaseDtuMax
        {
            get
            {
                return (int?)PerDatabaseSettings?.MaxCapacity;
            }
            set
            {
                if (PerDatabaseSettings == null)
                {
                    PerDatabaseSettings = new ElasticPoolPerDatabaseSettings();
                }

                PerDatabaseSettings.MaxCapacity = value;
            }
        }
    }
}
