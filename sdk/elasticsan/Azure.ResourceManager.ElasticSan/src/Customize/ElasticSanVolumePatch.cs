// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ElasticSan.Models
{
    public partial class ElasticSanVolumePatch
    {
        /// <summary>
        /// Gets or sets the resource ID of the resource managing the volume.
        /// </summary>
        /// <remarks>
        /// This property is retained for backward compatibility. Use <see cref="ManagedBy"/>
        /// instead, including when only one resource manages the volume.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier ManagedByResourceId
        {
            get => ManagedBy.Count == 1 && ManagedBy[0].ResourceIds.Count == 1
                ? ManagedBy[0].ResourceIds[0]
                : null;

            set
            {
                ManagedBy.Clear();

                if (value != null)
                {
                    ManagedBy.Add(new ElasticSanManagedByInfo
                    {
                        ResourceIds = { value }
                    });
                }
            }
        }
    }
}
