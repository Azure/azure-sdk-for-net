// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A Class representing a TagResource along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="TagResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetTagResource method.
    /// Otherwise you can get one from its parent resource <see cref="ArmResource" /> using the GetTagResource method.
    /// </summary>
    public partial class TagResource : ArmResource
    {
        /// <summary>
        /// This operation allows replacing, merging or selectively deleting tags on the specified resource or subscription. The specified entity can have a maximum of 50 tags at the end of the operation. The &apos;replace&apos; option replaces the entire set of existing tags with a new set. The &apos;merge&apos; option allows adding tags with new names and updating the values of tags with existing names. The &apos;delete&apos; option allows selectively deleting tags based on given names or name/value pairs.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/tags/default</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Tags_UpdateAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The TagResourcePatch to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release.", false)]
        public virtual async Task<Response<TagResource>> UpdateAsync(TagResourcePatch patch, CancellationToken cancellationToken = default)
        {
            var operation = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(operation.Value, operation.GetRawResponse());
        }

        /// <summary>
        /// This operation allows replacing, merging or selectively deleting tags on the specified resource or subscription. The specified entity can have a maximum of 50 tags at the end of the operation. The &apos;replace&apos; option replaces the entire set of existing tags with a new set. The &apos;merge&apos; option allows adding tags with new names and updating the values of tags with existing names. The &apos;delete&apos; option allows selectively deleting tags based on given names or name/value pairs.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/tags/default</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Tags_UpdateAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The TagResourcePatch to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release.", false)]
        public virtual Response<TagResource> Update(TagResourcePatch patch, CancellationToken cancellationToken = default)
        {
            var operation = Update(WaitUntil.Completed, patch, cancellationToken);
            return Response.FromValue(operation.Value, operation.GetRawResponse());
        }
    }
}
