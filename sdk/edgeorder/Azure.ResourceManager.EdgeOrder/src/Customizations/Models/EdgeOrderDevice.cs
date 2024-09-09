using Azure.ResourceManager.EdgeOrder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.ResourceManager.EdgeOrder.Customizations.Models
{
    /// <summary>
    /// Edge Order Devices
    /// </summary>
    public  class EdgeOrderDevice
    {
        /// <summary>
        /// Order item Id
        /// </summary>
        public string OrderItemId { get; set; }

        /// <summary>
        /// Device Serial Number
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Manufacturer
        /// </summary>
         public string Manufacturer     { get; set; }

        /// <summary>
        /// Model Name
        /// </summary>
       public string ModelName    { get; set; }

        /// <summary>
        /// Device Configuration
        /// </summary>
        public DeviceConfiguration DeviceConfiguration { get; set; }
    }
}
