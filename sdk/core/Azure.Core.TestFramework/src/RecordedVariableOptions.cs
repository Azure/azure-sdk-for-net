// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.TestFramework
{
    public class RecordedVariableOptions
    {
        private readonly Dictionary<string, string> _secretConnectionStringParameters = new Dictionary<string, string>();
        private string _sanitizedValue;

        public RecordedVariableOptions HasSecretConnectionStringParameter(string name, SanitizedValue sanitizedValue = default)
        {
            _secretConnectionStringParameters[name] = GetStringValue(sanitizedValue);
            return this;
        }

        public RecordedVariableOptions HasSecretConnectionStringParameter(string name, string sanitizedValue)
        {
            _secretConnectionStringParameters[name] = sanitizedValue;
            return this;
        }

        public RecordedVariableOptions IsSecret(SanitizedValue sanitizedValue = default)
        {
            _sanitizedValue = GetStringValue(sanitizedValue);
            return this;
        }

        public RecordedVariableOptions IsSecret(string sanitizedValue)
        {
            _sanitizedValue = sanitizedValue;
            return this;
        }

        private string GetStringValue(SanitizedValue sanitizedValue)
        {
            return sanitizedValue switch
            {
                SanitizedValue.Base64 => "Kg==",
                _ => RecordedTestSanitizer.SanitizeValue,
            };
        }

        public string Apply(string value)
        {
            if (_secretConnectionStringParameters.Any())
            {
                var parsed = ConnectionString.Parse(value, allowEmptyValues: true);

                foreach (var connectionStringParameter in _secretConnectionStringParameters)
                {
                    parsed.Replace(connectionStringParameter.Key, connectionStringParameter.Value);
                }

                value = parsed.ToString();
            }

            if (_sanitizedValue != null)
            {
                value = _sanitizedValue;
            }

            return value;
        }
    }
}