// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Analytics.Synapse.AccessControl
{
    /// <summary> Check access request details. </summary>
    public partial class CheckPrincipalAccessRequest
    {
        /// <summary> Initializes a new instance of CheckPrincipalAccessRequest. </summary>
        /// <param name="subject"> Subject details. </param>
        /// <param name="actions"> List of actions. </param>
        /// <param name="scope"> Scope at which the check access is done. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subject"/>, <paramref name="actions"/>, or <paramref name="scope"/> is null. </exception>
        public CheckPrincipalAccessRequest(SubjectInfo subject, IEnumerable<RequiredAction> actions, string scope)
        {
            if (subject == null)
            {
                throw new ArgumentNullException(nameof(subject));
            }
            if (actions == null)
            {
                throw new ArgumentNullException(nameof(actions));
            }
            if (scope == null)
            {
                throw new ArgumentNullException(nameof(scope));
            }

            Subject = subject;
            Actions = actions.ToList();
            Scope = scope;
        }

        /// <summary> Subject details. </summary>
        public SubjectInfo Subject { get; }
        /// <summary> List of actions. </summary>
        public IList<RequiredAction> Actions { get; }
        /// <summary> Scope at which the check access is done. </summary>
        public string Scope { get; }

        public static implicit operator RequestContent(CheckPrincipalAccessRequest accessRequest)
        {
            return RequestContent.Create(new
            {
                subject = accessRequest.Subject,
                actions = accessRequest.Actions,
                scope = accessRequest.Scope
            });
        }
    }
}
