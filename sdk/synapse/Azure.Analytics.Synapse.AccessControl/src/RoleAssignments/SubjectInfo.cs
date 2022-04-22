// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Analytics.Synapse.AccessControl
{
    /// <summary> Subject details. </summary>
    public partial class SubjectInfo
    {
        /// <summary> Initializes a new instance of SubjectInfo. </summary>
        /// <param name="principalId"> Principal Id. </param>
        public SubjectInfo(Guid principalId)
        {
            PrincipalId = principalId;
            GroupIds = new ChangeTrackingList<Guid>();
        }

        /// <summary> Principal Id. </summary>
        public Guid PrincipalId { get; }
        /// <summary> List of group Ids that the principalId is part of. </summary>
        public IList<Guid> GroupIds { get; }
    }
}
