// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.Schema
{
    //This class purely serves as a placeholder, if json schema validation is required, inherit the Validator class and implement the json schema validation code.
    internal class BypassValidator : Validator
    {
        public BypassValidator(AuthEventJsonElement schemaJson) : base(schemaJson)
        {
        }

        internal override bool Validate(AuthEventJsonElement eventJson, out IEnumerable<Exception> errors)
        {
            errors = new List<Exception>();
            return true;
        }
    }
}
