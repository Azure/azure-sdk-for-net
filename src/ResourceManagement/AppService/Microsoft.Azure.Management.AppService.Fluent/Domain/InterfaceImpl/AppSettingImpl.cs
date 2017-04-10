// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    internal partial class AppSettingImpl 
    {
        /// <summary>
        /// Gets if the setting sticks to the slot during a swap.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IAppSetting.Sticky
        {
            get
            {
                return this.Sticky();
            }
        }

        /// <summary>
        /// Gets the value of the setting.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IAppSetting.Value
        {
            get
            {
                return this.Value();
            }
        }

        /// <summary>
        /// Gets the key of the setting.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IAppSetting.Key
        {
            get
            {
                return this.Key();
            }
        }
    }
}