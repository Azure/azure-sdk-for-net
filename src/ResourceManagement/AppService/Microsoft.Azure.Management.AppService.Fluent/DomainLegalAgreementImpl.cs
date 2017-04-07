// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Models;
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for Tenant.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uRG9tYWluTGVnYWxBZ3JlZW1lbnRJbXBs
    internal sealed partial class DomainLegalAgreementImpl :
        Wrapper<TldLegalAgreement>,
        IDomainLegalAgreement
    {

        ///GENMHASH:572D526CD350879469DD5291DB304490:6693A56144125388FB927D6F7E6E38C5
        public string Content()
        {
            return Inner.Content;
        }

        ///GENMHASH:F900704F909FD46E57C8DB05A9CC7F62:00F491456DE89CF8632B5502AA275262
        public string Title()
        {
            return Inner.Title;
        }

        ///GENMHASH:BECE963A57EABFCEDD1F16F10621E4B7:BEEF63965B869F3B5972C1D6DFCD1A03
        internal DomainLegalAgreementImpl(TldLegalAgreement innerModel)
            : base(innerModel)
        {
        }

        ///GENMHASH:35F1A910CEC8B2516638934A68DAC1FD:218BD212DC7AB883E85D851EB90B38E9
        public string AgreementKey()
        {
            return Inner.AgreementKey;
        }

        ///GENMHASH:219CF36E81A428B9F256A13662F581CF:48F28FD40D285626671B158D973807D1
        public string Url()
        {
            return Inner.Url;
        }
    }
}