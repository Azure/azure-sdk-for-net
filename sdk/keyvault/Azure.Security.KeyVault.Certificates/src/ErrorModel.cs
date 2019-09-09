// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    public class Error : IJsonDeserializable
    {
        private const string CodePropertyName = "code";
        private const string MessagePropertyName = "message";
        private const string InnerErrorPropertyName = "innererror";

        public string Code { get; private set; }

        public string Message { get; private set; }

        public Error InnerError { get; private set; }

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case CodePropertyName:
                        Code = prop.Value.GetString();
                        break;

                    case MessagePropertyName:
                        Message = prop.Value.GetString();
                        break;
                    case InnerErrorPropertyName:
                        InnerError = new Error();
                        ((IJsonDeserializable)InnerError).ReadProperties(prop.Value);
                        break;
                }
            }
        }
    }
}
