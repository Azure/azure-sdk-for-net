using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Compute
{
    public partial class VirtualMachineScaleSetImpl
    {
        VirtualMachineScaleSetExtensionImpl DefineNewExtension(string name)
        {
            throw new NotImplementedException();
        }


        // TODO: DELETE
        string IIndexable.Key
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        IVirtualMachineScaleSet ICreatable<IVirtualMachineScaleSet>.Create()
        {
            throw new NotImplementedException();
        }

        Task<IVirtualMachineScaleSet> ICreatable<IVirtualMachineScaleSet>.CreateAsync(CancellationToken cancellationToken, bool multiThreaded)
        {
            throw new NotImplementedException();
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate
            Microsoft.Azure.Management.V2.Resource.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate>.WithTag(string key, string value)
        {
            throw new NotImplementedException();
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate
            Microsoft.Azure.Management.V2.Resource.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate>.WithTags(IDictionary<string, string> tags)
        {
            throw new NotImplementedException();
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithGroup
            Microsoft.Azure.Management.V2.Resource.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithGroup>.WithRegion(Resource.Core.Region region)
        {
            throw new NotImplementedException();
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithGroup
            Microsoft.Azure.Management.V2.Resource.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithGroup>.WithRegion(string regionName)
        {
            throw new NotImplementedException();
        }

        IVirtualMachineScaleSet IAppliable<IVirtualMachineScaleSet>.Apply()
        {
            throw new NotImplementedException();
        }

        Task<IVirtualMachineScaleSet> IAppliable<IVirtualMachineScaleSet>.ApplyAsync(CancellationToken cancellationToken, bool multiThreaded)
        {
            throw new NotImplementedException();
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable Resource.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable>.WithoutTag(string key)
        {
            throw new NotImplementedException();
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable
            Resource.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable>.WithTag(string key, string value)
        {
            throw new NotImplementedException();
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable
            Resource.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable>.WithTags(IDictionary<string, string> tags)
        {
            throw new NotImplementedException();
        }

        string IResource.Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        VirtualMachineScaleSetInner IWrapper<VirtualMachineScaleSetInner>.Inner
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        string IResource.Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        Region IResource.Region
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        string IResource.RegionName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        string IGroupableResource.ResourceGroupName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        IDictionary<string, string> IResource.Tags
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        string IResource.Type
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        VirtualMachineScaleSet.Update.IWithPrimaryLoadBalancer IUpdatable<VirtualMachineScaleSet.Update.IWithPrimaryLoadBalancer>.Update()
        {
            throw new NotImplementedException();
        }
    }
}
