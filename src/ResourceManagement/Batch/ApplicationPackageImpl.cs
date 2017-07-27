// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Batch.Fluent
{
    using Management.Batch.Fluent;
    using Management.Batch.Fluent.Models;
    using ResourceManager.Fluent.Core;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for BatchAccount Application Package and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmJhdGNoLmltcGxlbWVudGF0aW9uLkFwcGxpY2F0aW9uUGFja2FnZUltcGw=
    internal partial class ApplicationPackageImpl :
        ExternalChildResource<
            IApplicationPackage,
            ApplicationPackageInner,
            IApplication,
            ApplicationImpl>,
        IApplicationPackage
    {
        private IApplicationPackageOperations client;

        ///GENMHASH:5ABE0C6DFAB9C84B944D4C1A59824C2F:6759EA313F94C96A4A66A7653ACEA8F0
        internal ApplicationPackageImpl(string name, ApplicationImpl parent, ApplicationPackageInner inner, IApplicationPackageOperations client)
            : base(name, parent, inner)
        {
            this.client = client;
        }

        ///GENMHASH:C821FF91D77C2B3E93FA31DD47D5EA29:52876A7A5B8CFB81FC39CDD83E66AC9E
        internal static ApplicationPackageImpl NewApplicationPackage(string name, ApplicationImpl parent, IApplicationPackageOperations client)
        {
            return new ApplicationPackageImpl(name, parent, new ApplicationPackageInner(), client);
        }

        ///GENMHASH:AEE17FD09F624712647F5EBCEC141EA5:F31B0F3D0CD1A4C57DB28EB70C9E094A
        internal PackageState State()
        {
            return Inner.State.GetValueOrDefault();
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:B0C3E9401565240CA5340D3073CE3C9E
        public string Id
        {
            get
            {
                return Parent.Parent.Id + "/applications/" + Parent.Name() + "/versions/" + Name();
            }
        }

        ///GENMHASH:32A8B56FE180FA4429482D706189DEA2:AADCE604E8DD42B474E6BDC939BB469C
        public async override Task<IApplicationPackage> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var applicationPackageInner = await client.CreateAsync(
                Parent.Parent.ResourceGroupName, 
                Parent.Parent.Name, 
                Parent.Name(), 
                Name(), 
                cancellationToken);

            SetInner(applicationPackageInner);
            return this;
        }

        ///GENMHASH:F08598A17ADD014E223DFD77272641FF:AE1997EFB9BA750C329D12351BB02B24
        public override Task<IApplicationPackage> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException();
        }

        ///GENMHASH:65E6085BB9054A86F6A84772E3F5A9EC:B194B6D94E13B7450F78AF5DC15946BE
        public void Delete()
        {
            Extensions.Synchronize(() => DeleteAsync());
        }

        ///GENMHASH:0FEDA307DAD2022B36843E8905D26EAD:9B272804AD473CBF3C5DEE818D16023C
        public async override Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await client.DeleteAsync(Parent.Parent.ResourceGroupName, Parent.Parent.Name,Parent.Name(), Name(), cancellationToken);
        }

        ///GENMHASH:4F85B844C04DBCB78637929FBE0113B6:495A62BBEF55F48ED4E08DBDE110BCC1
        internal string Format()
        {
            return Inner.Format;
        }

        ///GENMHASH:3AC68A76C669ACBD4BFBB653989DBB7F:6E17D6654F954854856F432407B38E15
        internal string StorageUrl()
        {
            return Inner.StorageUrl;
        }

        ///GENMHASH:A37A4D26CB8661C343A05DEC21AA8C15:87DBB1B0678DABB47DDEF1E68A40D156
        internal DateTime StorageUrlExpiry()
        {
            return Inner.StorageUrlExpiry.GetValueOrDefault();
        }

        ///GENMHASH:B840DDDCCD8C0172198F731FA02751C8:E01853DE05AECF3A39A61335E3B0063A
        internal DateTime LastActivationTime()
        {
            return Inner.LastActivationTime.GetValueOrDefault();
        }

        IApplication IHasParent<IApplication>.Parent
        {
            get
            {
                return Parent;
            }
        }

        ///GENMHASH:CD5E69C00F6C1D6EBFC019860CB4AEA6:EF37815ABD90C720F1C27B3219616A48
        internal async Task ActivateAsync(string format, CancellationToken cancellationToken = default(CancellationToken))
        {
            await client.ActivateAsync(Parent.Parent.ResourceGroupName, Parent.Parent.Name, Parent.Name(), Name(), new ActivateApplicationPackageParametersInner
            {
                Format = format
            }, cancellationToken);
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:1A5A27E52191D0AB303947147157C578
        protected override async Task<ApplicationPackageInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await client.GetAsync(Parent.Parent.ResourceGroupName, Parent.Parent.Name, Parent.Name(), Name(), cancellationToken);
        }
    }
}
