// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using Management.Fluent.ServiceBus.Models;
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for AuthorizationKeys.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uQXV0aG9yaXphdGlvbktleXNJbXBs
    internal partial class AuthorizationKeysImpl  :
        Wrapper<ResourceListKeysInner>,
        IAuthorizationKeys
    {

        ///GENMHASH:26C041807ADC77B9828AE5B58F33E20F:B0DF93AB45A1550B74A2BFD026E1B756
        internal AuthorizationKeysImpl(ResourceListKeysInner inner) : base(inner)
        {
        }

        ///GENMHASH:052932D87146B729CFA163215691D8ED:6763FB29FBF72D82539172AE0DC19C90
        public string SecondaryKey()
        {
            return this.Inner.SecondaryKey;
        }

        ///GENMHASH:5B3EAF146A0EF16F4DD5CAF70F7DCBAD:68DD6AAA48714349E267D9AD239788EA
        public string PrimaryConnectionString()
        {
            return this.Inner.PrimaryConnectionString;
        }

        ///GENMHASH:DCE6EC07685C092DDEE7E34CFD39FF68:49DBCAC1B850D980128C6B4975B6E314
        public string SecondaryConnectionString()
        {
            return this.Inner.SecondaryConnectionString;
        }

        ///GENMHASH:0B1F8FBCA0C4DFB5EA228CACB374C6C2:67683205AEC956D5A4DC45602BD4F143
        public string PrimaryKey()
        {
            return this.Inner.PrimaryKey;
        }
    }
}