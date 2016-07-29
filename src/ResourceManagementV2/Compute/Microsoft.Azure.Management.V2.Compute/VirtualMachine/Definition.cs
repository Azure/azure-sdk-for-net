using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition
{
    public interface IDefinition
    {}

    public interface IBlank : Resource.Core.Resource.Definition.IDefinitionWithRegion<IWithGroup>
    { }

    public interface IWithGroup : Resource.Core.GroupableResource.Definition.IWithGroup<IWithCreate>
    { }

    public interface IWithCreate
    {}
}
