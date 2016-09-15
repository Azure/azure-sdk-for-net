/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update
{

    /// <summary>
    /// The final stage of the child object definition, as which it can be attached to the parent.
    /// @param <ParentT> the parent definition
    /// </summary>
    public interface IInUpdate<ParentT> 
    {
        ParentT Attach ();

    }
}