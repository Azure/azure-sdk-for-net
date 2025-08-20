// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Data.AppConfiguration
{
    /// <summary> A label used to group key-values. </summary>
    public partial class SettingLabel
    {
        /// <summary> Initializes a new instance of <see cref="SettingLabel"/>.</summary>
        /// <param name="name"> The name of the label. </param>
        internal SettingLabel(string name)
        {
            Name = name;
        }

        /// <summary> The name of the label. </summary>
        public string Name { get; }
    }
}
