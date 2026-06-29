// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.EventGrid.Models;

namespace Azure.ResourceManager.EventGrid
{
    // Tag add/remove/set helpers: the new mgmt generator only emits the standard ARM tag operations when the
    // resource's Update (PATCH) returns the resource body. This resource's PATCH is modeled as returning no
    // content (Update -> non-generic ArmOperation), so the generator skips the tag helpers and deliberately
    // does not fall back to PUT. They are hand-authored here to preserve main's GA tag surface. GA's Update is
    // likewise a non-generic ArmOperation, so the no-content modeling cannot be changed in TypeSpec without
    // breaking the Update return-type parity.
    public partial class PartnerRegistrationResource
    {
        /// <summary> Adds a tag to the resource. </summary>
        [ForwardsClientCalls]
        public virtual async Task<Response<PartnerRegistrationResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            PartnerRegistrationData current = (await GetAsync(cancellationToken).ConfigureAwait(false)).Value.Data;
            PartnerRegistrationPatch patch = CreatePatchWithTags(current.Tags);
            patch.Tags[key] = value;
            await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return await GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Adds a tag to the resource. </summary>
        [ForwardsClientCalls]
        public virtual Response<PartnerRegistrationResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            PartnerRegistrationData current = Get(cancellationToken).Value.Data;
            PartnerRegistrationPatch patch = CreatePatchWithTags(current.Tags);
            patch.Tags[key] = value;
            Update(WaitUntil.Completed, patch, cancellationToken);
            return Get(cancellationToken);
        }

        /// <summary> Removes a tag from the resource. </summary>
        [ForwardsClientCalls]
        public virtual async Task<Response<PartnerRegistrationResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            PartnerRegistrationData current = (await GetAsync(cancellationToken).ConfigureAwait(false)).Value.Data;
            PartnerRegistrationPatch patch = CreatePatchWithTags(current.Tags);
            patch.Tags.Remove(key);
            await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return await GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Removes a tag from the resource. </summary>
        [ForwardsClientCalls]
        public virtual Response<PartnerRegistrationResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            PartnerRegistrationData current = Get(cancellationToken).Value.Data;
            PartnerRegistrationPatch patch = CreatePatchWithTags(current.Tags);
            patch.Tags.Remove(key);
            Update(WaitUntil.Completed, patch, cancellationToken);
            return Get(cancellationToken);
        }

        /// <summary> Replaces the resource tags. </summary>
        [ForwardsClientCalls]
        public virtual async Task<Response<PartnerRegistrationResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));
            PartnerRegistrationPatch patch = CreatePatchWithTags(tags);
            await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return await GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Replaces the resource tags. </summary>
        [ForwardsClientCalls]
        public virtual Response<PartnerRegistrationResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));
            PartnerRegistrationPatch patch = CreatePatchWithTags(tags);
            Update(WaitUntil.Completed, patch, cancellationToken);
            return Get(cancellationToken);
        }

        private static PartnerRegistrationPatch CreatePatchWithTags(IDictionary<string, string> tags)
        {
            PartnerRegistrationPatch patch = new PartnerRegistrationPatch();
            if (tags is null)
            {
                return patch;
            }

            foreach (KeyValuePair<string, string> tag in tags)
            {
                patch.Tags[tag.Key] = tag.Value;
            }

            return patch;
        }
    }
}
