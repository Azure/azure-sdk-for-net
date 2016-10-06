/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.Resource.Fluent.Core.ChildResourceActions
{


    /// <summary>
    /// The final stage of the child object definition, as which it can be attached to the parent.
    /// @param <ParentT> the parent definition
    /// </summary>
    public interface IInUpdateAlt<ParentT> 
    {
        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        ParentT Attach ();

    }
    /// <summary>
    /// The final stage of the child object definition, as which it can be attached to the parent.
    /// @param <ParentT> the parent definition
    /// </summary>
    public interface IInDefinitionAlt<ParentT> 
    {
        /// <summary>
        /// Attaches the child definition to the parent resource definition.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        ParentT Attach ();

    }
    /// <summary>
    /// The final stage of the child object definition, at which it can be attached to the parent, using {@link Attachable#attach()}.
    /// 
    /// @param <ParentT> the parent definition {@link Attachable#attach()} returns to
    /// </summary>
    public interface IAttachable<ParentT> 
    {
        /// <summary>
        /// Attaches this child object's definition to its parent's definition.
        /// </summary>
        /// <returns>the next stage of the parent object's definition</returns>
        ParentT Attach ();

    }
}