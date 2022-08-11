// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.Schema
{
    internal class SchemaValidator
    {
        private readonly Validator _validator;
        private IEnumerable<Exception> _errors;
        public bool Valid { get; set; }
        public IEnumerable<Exception> Errors { get { return _errors; } set { _errors = value; } }

        public SchemaValidator(AuthEventJsonElement jsonSchema) : this(new BypassValidator(jsonSchema)) { }
        public SchemaValidator(Validator validator)
        {
            _validator = validator;
        }

        internal void Validate(AuthEventJsonElement eventJson)
        {
            Valid = _validator.Validate(eventJson, out _errors);
        }
    }
}
