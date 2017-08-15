// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Search.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Search.Fluent.Models;

    /// <summary>
    /// Response containing the primary and secondary admin API keys for a given Azure Search service.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlYXJjaC5pbXBsZW1lbnRhdGlvbi5BZG1pbktleXNJbXBs
    internal partial class AdminKeysImpl  :
        Wrapper<Models.AdminKeyResultInner>,
        IAdminKeys
    {
        ///GENMHASH:052932D87146B729CFA163215691D8ED:C74FC4D6E498F9E2004ADD70A6234833
        public string SecondaryKey()
        {
            return this.Inner.SecondaryKey;
        }

        ///GENMHASH:C08411FE38E7175FDAEA4BFB98A59684:1D4DDF365F268ADBDFBA007915D77856
        internal AdminKeysImpl(AdminKeyResultInner innerObject) : base(innerObject)
        {
        }

        ///GENMHASH:0B1F8FBCA0C4DFB5EA228CACB374C6C2:33E9AB1CE55380EB0803102474306E91
        public string PrimaryKey()
        {
            return this.Inner.PrimaryKey;
        }
    }
}