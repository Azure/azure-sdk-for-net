// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.Schema
{
    internal abstract class Validator
    {
        internal AuthEventJsonElement _schema;

        internal abstract bool Validate(AuthEventJsonElement eventJson, out IEnumerable<Exception> errors);

        internal Validator(AuthEventJsonElement schemaJson)
        {
            _schema = schemaJson;
        }
    }
}
