// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// An error encountered during the processing of a <see cref="CertificateOperation"/>
    /// </summary>
    public class Error : IJsonDeserializable
    {
        private const string CodePropertyName = "code";
        private const string MessagePropertyName = "message";
        private const string InnerErrorPropertyName = "innererror";

        /// <summary>
        /// The error code of the specified error
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// A message containing details of the encountered error
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// An underlying error, if exists, for the current error
        /// </summary>
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
