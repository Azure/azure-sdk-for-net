// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    /// <summary>
    /// An immutable client-side representation of an app setting on a web app.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uQXBwU2V0dGluZ0ltcGw=
    internal partial class AppSettingImpl : IAppSetting
    {
        private string key;
        private string value;
        private bool sticky;

        ///GENMHASH:683EC8CC1E0263C925A3D81103936F1D:735925B0656EA32EBE39A6B447AE1D3E
        public bool Sticky()
        {
            return sticky;
        }

        ///GENMHASH:8FC695E310CD67A6D0F079F4B72B41AB:8FC2BAC2F59BF805AD75CD7AC09683A6
        internal AppSettingImpl(string key, string value, bool sticky)
        {
            this.key = key;
            this.value = value;
            this.sticky = sticky;
        }

        ///GENMHASH:C1D104519E98AFA1614D0BFD517E6100:8EA6A92C3208FBD2C20D676F7D102DC1
        public string Value()
        {
            return value;
        }

        ///GENMHASH:3199B79470C9D13993D729B188E94A46:2A8C65FBD7D488598137990EE6E16B30
        public string Key()
        {
            return key;
        }
    }
}