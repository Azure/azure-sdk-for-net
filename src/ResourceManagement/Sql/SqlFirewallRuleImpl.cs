// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.IndependentChild.Definition;
    using Models;
    using SqlFirewallRule.Definition;
    using SqlFirewallRule.Update;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for SqlFirewallRule and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxGaXJld2FsbFJ1bGVJbXBs
    internal partial class SqlFirewallRuleImpl :
        IndependentChildImpl<ISqlFirewallRule, ISqlServer, ServerFirewallRuleInner, SqlFirewallRuleImpl, IHasId, IUpdate, ISqlManager>,
        ISqlFirewallRule,
        IDefinition,
        IUpdate,
        IWithParentResource<ISqlFirewallRule, ISqlServer>
    {
        ///GENMHASH:A6DA29F5B33635B6B2AB7A6DA20A0B2B:FC20F8BEAA0D65FFE9DA4206313524DE
        internal SqlFirewallRuleImpl(string name, ServerFirewallRuleInner innerObject, ISqlManager manager)
            : base(name, innerObject, manager)
        {
        }

        ///GENMHASH:86CD1E259A3329513723B4E03EFABB98:15BC15CFDD8106B985088348087483E5
        public SqlFirewallRuleImpl WithIPAddressRange(string startIpAddress, string endIpAddress)
        {
            Inner.StartIpAddress = startIpAddress;
            Inner.EndIpAddress = endIpAddress;

            return this;
        }

        ///GENMHASH:61F5809AB3B985C61AC40B98B1FBC47E:04B212B505D5C86A62596EEEE457DD66
        public string SqlServerName()
        {
            return this.parentName;
        }

        ///GENMHASH:C4C0D4751CA4E1904C31CE6DF0B02AC3:B30E59DD4D927FB508DCE8588A7B6C5E
        public string Kind()
        {
            return Inner.Kind;
        }

        ///GENMHASH:B2EB74D988CD2A7EFC551E57BE9B48BB:077B87F3E32DB4F7DBE3AFD7C44190B4
        protected async override Task<ISqlFirewallRule> CreateChildResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var firewallRuleInner = await Manager.Inner.Servers.CreateOrUpdateFirewallRuleAsync(
                ResourceGroupName,
                SqlServerName(),
                Name,
                Inner,
                cancellationToken);
            SetInner(firewallRuleInner);

            return this;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:8B499834886805DF649E8FE559911199
        protected override async Task<ServerFirewallRuleInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.Servers.GetFirewallRuleAsync(ResourceGroupName, SqlServerName(), Name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:F447869988CA4FAC84328D668E8C3E63:FC2F4AB7336D8B5FBACF1012628B157F
        public SqlFirewallRuleImpl WithEndIPAddress(string endIpAddress)
        {
            Inner.EndIpAddress = endIpAddress;

            return this;
        }

        ///GENMHASH:D5B3C39B9575015B060C5915E28F7DED:E2EB90CF1BFD48AF581DD19E19A48783
        public string StartIPAddress()
        {
            return Inner.StartIpAddress;
        }

        ///GENMHASH:65E6085BB9054A86F6A84772E3F5A9EC:11CCB9FA7CDA7C4110B5B485953F2C3A
        public void Delete()
        {
            Extensions.Synchronize(() => Manager.Inner.Servers.DeleteFirewallRuleAsync(ResourceGroupName, SqlServerName(), Name));
        }

        ///GENMHASH:6ADF1ABD01F52EF2AB48EBDB916AC61B:0E617A4FA7C8B0429E44FA81A0CA93AE
        public string EndIPAddress()
        {
            return Inner.EndIpAddress;
        }

        ///GENMHASH:78ADACC8F10C5519A35307D4BCF30B70:19E90E783DF08C6EF5789BCD8F9F2F63
        public SqlFirewallRuleImpl WithStartIPAddress(string startIpAddress)
        {
            Inner.StartIpAddress = startIpAddress;

            return this;
        }

        ///GENMHASH:040FE6797829F09ECF75BDE559FBA5FC:0D4A3A3FE03B789EAEFA20F7BEA0BF8F
        public SqlFirewallRuleImpl WithIPAddress(string ipAddress)
        {
            this.WithStartIPAddress(ipAddress).WithEndIPAddress(ipAddress);

            return this;
        }

        /// <return>The resource ID string.</return>

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:B4BB65C5F3DFF22971E61FCC898DE88C
        public override string Id
        {
            get
            {
                if (Inner != null)
                {
                    return Inner.Id;
                }

                return null;
            }
        }

        ///GENMHASH:6A2970A94B2DD4A859B00B9B9D9691AD:D48F16C6B9830DCBDCBFBD281C142173
        public Region Region()
        {
            return ResourceManager.Fluent.Core.Region.Create(Inner.Location);
        }
    }
}
