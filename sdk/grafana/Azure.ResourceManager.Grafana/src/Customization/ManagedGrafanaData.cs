// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Grafana.Models;

namespace Azure.ResourceManager.Grafana
{
    public partial class ManagedGrafanaData
    {
        /// <summary> The Sku name of the grafana resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SkuName
        {
            get => Sku?.Name;
            set
            {
                if (Sku == null)
                {
                    Sku = new ManagedGrafanaSku(value);
                }
                else
                {
                    Sku.Name = value;
                }
            }
        }
    }
}
