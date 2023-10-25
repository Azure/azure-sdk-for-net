// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("ExceptionPolicy")]
    [CodeGenSuppress("ExceptionPolicy")]
    public partial class ExceptionPolicy : IUtf8JsonSerializable
    {
        /// <summary> Initializes a new instance of ExceptionPolicy. </summary>
        internal ExceptionPolicy()
        {
            _exceptionRules = new ChangeTrackingDictionary<string, ExceptionRule>();
        }

        [CodeGenMember("ExceptionRules")]
        internal IDictionary<string, ExceptionRule> _exceptionRules
        {
            get
            {
                return ExceptionRules != null && ExceptionRules.Count != 0
                    ? ExceptionRules?.ToDictionary(x => x.Key, x => x.Value)
                    : new ChangeTrackingDictionary<string, ExceptionRule>();
            }
            set
            {
                if (value != null && value.Any())
                {
                    ExceptionRules.Append(value);
                }
            }
        }

        /// <summary> (Optional) A dictionary collection of exception rules on the exception policy. Key is the Id of each exception rule. </summary>
        public IDictionary<string, ExceptionRule> ExceptionRules { get; } = new Dictionary<string, ExceptionRule>();

        /// <summary> (Optional) The name of the exception policy. </summary>
        public string Name { get; internal set; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsCollectionDefined(_exceptionRules))
            {
                writer.WritePropertyName("exceptionRules"u8);
                writer.WriteStartObject();
                foreach (var item in _exceptionRules)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteObjectValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
