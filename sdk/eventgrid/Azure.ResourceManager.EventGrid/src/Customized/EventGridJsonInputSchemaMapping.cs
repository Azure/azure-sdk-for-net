// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable CS1591

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid.Models
{
    [CodeGenSuppress("IdSourceField")]
    [CodeGenSuppress("TopicSourceField")]
    [CodeGenSuppress("EventTimeSourceField")]
    public partial class EventGridJsonInputSchemaMapping
    {
        [WirePath("properties.id.sourceField")]
        public string IdSourceField
        {
            get => Properties is null ? default : Properties.IdSourceField;
            set
            {
                Properties ??= new JsonInputSchemaMappingProperties();
                Properties.IdSourceField = value;
            }
        }

        [WirePath("properties.topic.sourceField")]
        public string TopicSourceField
        {
            get => Properties is null ? default : Properties.TopicSourceField;
            set
            {
                Properties ??= new JsonInputSchemaMappingProperties();
                Properties.TopicSourceField = value;
            }
        }

        [WirePath("properties.eventTime.sourceField")]
        public string EventTimeSourceField
        {
            get => Properties is null ? default : Properties.EventTimeSourceField;
            set
            {
                Properties ??= new JsonInputSchemaMappingProperties();
                Properties.EventTimeSourceField = value;
            }
        }

        internal JsonField Id
        {
            get => Properties is null ? default : Properties.Id;
            set
            {
                EnsureProperties();
                Properties.Id = value;
            }
        }

        internal JsonField Topic
        {
            get => Properties is null ? default : Properties.Topic;
            set
            {
                EnsureProperties();
                Properties.Topic = value;
            }
        }

        internal JsonField EventTime
        {
            get => Properties is null ? default : Properties.EventTime;
            set
            {
                EnsureProperties();
                Properties.EventTime = value;
            }
        }

        private void EnsureProperties()
        {
            if (Properties is null)
            {
                Properties = new JsonInputSchemaMappingProperties();
            }
        }
    }
}
