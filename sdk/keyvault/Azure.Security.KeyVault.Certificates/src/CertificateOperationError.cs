// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// An error encountered during the processing of a <see cref="CertificateOperation"/>.
    /// </summary>
    public class CertificateOperationError : IJsonDeserializable
    {
        private const string CodePropertyName = "code";
        private const string MessagePropertyName = "message";
        private const string InnerErrorPropertyName = "innererror";

        internal CertificateOperationError()
        {
        }

        /// <summary>
        /// Gets the error code of the specified error.
        /// </summary>
        public string Code { get; internal set; }

        /// <summary>
        /// Gets a message containing details of the encountered error.
        /// </summary>
        public string Message { get; internal set; }

        /// <summary>
        /// Gets an underlying error - if one exists - for the current error.
        /// </summary>
        public CertificateOperationError InnerError { get; internal set; }

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
                        InnerError = new CertificateOperationError();
                        ((IJsonDeserializable)InnerError).ReadProperties(prop.Value);
                        break;
                }
            }
        }
    }
}
