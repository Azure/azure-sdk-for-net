// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent
{
    internal partial class AppSettingImpl 
    {
        string Microsoft.Azure.Management.Appservice.Fluent.IAppSetting.Key
        {
            get
            {
                return this.Key();
            }
        }

        string Microsoft.Azure.Management.Appservice.Fluent.IAppSetting.Value
        {
            get
            {
                return this.Value();
            }
        }

        bool Microsoft.Azure.Management.Appservice.Fluent.IAppSetting.Sticky
        {
            get
            {
                return this.Sticky();
            }
        }
    }
}