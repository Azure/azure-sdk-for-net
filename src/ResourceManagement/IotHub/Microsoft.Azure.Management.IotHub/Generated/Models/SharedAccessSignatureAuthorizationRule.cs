// MIT

namespace Microsoft.Azure.Management.IotHub.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The properties of an IoT hub shared access policy.
    /// </summary>
    public partial class SharedAccessSignatureAuthorizationRule
    {
        /// <summary>
        /// Initializes a new instance of the
        /// SharedAccessSignatureAuthorizationRule class.
        /// </summary>
        public SharedAccessSignatureAuthorizationRule() { }

        /// <summary>
        /// Initializes a new instance of the
        /// SharedAccessSignatureAuthorizationRule class.
        /// </summary>
        public SharedAccessSignatureAuthorizationRule(string keyName, AccessRights rights, string primaryKey = default(string), string secondaryKey = default(string))
        {
            KeyName = keyName;
            PrimaryKey = primaryKey;
            SecondaryKey = secondaryKey;
            Rights = rights;
        }

        /// <summary>
        /// The name of the shared access policy.
        /// </summary>
        [JsonProperty(PropertyName = "keyName")]
        public string KeyName { get; set; }

        /// <summary>
        /// The primary key.
        /// </summary>
        [JsonProperty(PropertyName = "primaryKey")]
        public string PrimaryKey { get; set; }

        /// <summary>
        /// The secondary key.
        /// </summary>
        [JsonProperty(PropertyName = "secondaryKey")]
        public string SecondaryKey { get; set; }

        /// <summary>
        /// The permissions assigned to the shared access policy. Possible
        /// values include: 'RegistryRead', 'RegistryWrite',
        /// 'ServiceConnect', 'DeviceConnect', 'RegistryRead, RegistryWrite',
        /// 'RegistryRead, ServiceConnect', 'RegistryRead, DeviceConnect',
        /// 'RegistryWrite, ServiceConnect', 'RegistryWrite, DeviceConnect',
        /// 'ServiceConnect, DeviceConnect', 'RegistryRead, RegistryWrite,
        /// ServiceConnect', 'RegistryRead, RegistryWrite, DeviceConnect',
        /// 'RegistryRead, ServiceConnect, DeviceConnect', 'RegistryWrite,
        /// ServiceConnect, DeviceConnect', 'RegistryRead, RegistryWrite,
        /// ServiceConnect, DeviceConnect'
        /// </summary>
        [JsonProperty(PropertyName = "rights")]
        public AccessRights Rights { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (KeyName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "KeyName");
            }
        }
    }
}
