// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.ServiceBus
{
    public partial class ServiceBusCorrelationFilter
    {
        private BicepDictionary<string> _stringApplicationProperties;
        private BicepDictionary<object> _applicationProperties;

        // The service now describes application properties as strings.
        // Keep the strongly typed API under a distinct name so the shipped object dictionary can coexist.
        /// <summary> Gets or sets the string-valued application properties. </summary>
        [CodeGenMember("ApplicationProperties")]
        public BicepDictionary<string> StringApplicationProperties
        {
            get
            {
                Initialize();
                return _stringApplicationProperties;
            }
            set
            {
                Initialize();
                _stringApplicationProperties.Assign(value);
            }
        }

        // Preserve the old object-valued dictionary for callers compiled against Azure.Provisioning.ServiceBus 1.1.0.
        /// <summary> Gets or sets the application properties using the previous object-valued model shape. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use StringApplicationProperties instead.")]
        public BicepDictionary<object> ApplicationProperties
        {
            get
            {
                Initialize();
                return _applicationProperties;
            }
            set
            {
                Initialize();
                _applicationProperties.Assign(value);
            }
        }

        // Define both properties on the same wire path because they represent old and new views of the same service field.
        partial void DefineAdditionalProperties()
        {
            _stringApplicationProperties = DefineDictionaryProperty<string>(nameof(StringApplicationProperties), new string[] { "properties" });
#pragma warning disable CS0618 // ApplicationProperties is intentionally preserved for obsolete compatibility APIs.
            _applicationProperties = DefineDictionaryProperty<object>(nameof(ApplicationProperties), new string[] { "properties" });
#pragma warning restore CS0618
        }
    }
}
