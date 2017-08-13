// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Search.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Search.Fluent.Models;

    /// <summary>
    /// Describes an API key for a given Azure Search service that has permissions for query operations only.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlYXJjaC5pbXBsZW1lbnRhdGlvbi5RdWVyeUtleUltcGw=
    internal partial class QueryKeyImpl  :
        Wrapper<Models.QueryKeyInner>,
        IQueryKey
    {
        ///GENMHASH:4AFF869C9F6CB28A102CE915D8949E56:1D4DDF365F268ADBDFBA007915D77856
        internal QueryKeyImpl(QueryKeyInner innerObject) : base(innerObject)
        {
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:12AB60FD8699B563E971CC6124F76C4D
        public string Name()
        {
            return this.Inner.Name;
        }

        ///GENMHASH:3199B79470C9D13993D729B188E94A46:B035B99001C030C41A6416EA8D4A3B41
        public string Key()
        {
            return this.Inner.Key;
        }
    }
}