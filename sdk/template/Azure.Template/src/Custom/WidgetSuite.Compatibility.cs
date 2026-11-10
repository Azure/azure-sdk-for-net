// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Template
{
    public partial class WidgetSuite
    {
        /// <summary> Initializes a new instance of <see cref="WidgetSuite"/>. </summary>
        /// <param name="manufacturerId"> The ID of the widget's manufacturer. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="manufacturerId"/> is null. </exception>
        public WidgetSuite(string manufacturerId) : this()
        {
            if (manufacturerId is null)
            {
                throw new ArgumentNullException(nameof(manufacturerId));
            }

            ManufacturerId = manufacturerId;
        }
    }
}
