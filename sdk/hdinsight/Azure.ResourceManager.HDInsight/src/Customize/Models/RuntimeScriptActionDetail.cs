// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.HDInsight.Models
{
    // The TypeSpec-generated RuntimeScriptActionDetail only has an internal constructor.
    // The old AutoRest-generated version exposed a public constructor with (name, uri, roles) parameters.
    // This custom partial class re-adds the public constructor for backward compatibility (ApiCompat).
    public partial class RuntimeScriptActionDetail
    {
        /// <summary> Initializes a new instance of <see cref="RuntimeScriptActionDetail"/>. </summary>
        /// <param name="name"> The name of the script action. </param>
        /// <param name="uri"> The URI to the script. </param>
        /// <param name="roles"> The list of roles where script will be executed. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="uri"/> or <paramref name="roles"/> is null. </exception>
        public RuntimeScriptActionDetail(string name, Uri uri, IEnumerable<string> roles) : base(name, uri, roles)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(uri, nameof(uri));
            Argument.AssertNotNull(roles, nameof(roles));

            ExecutionSummary = new ChangeTrackingList<ScriptActionExecutionSummary>();
        }
    }
}
