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
            get => Id is null ? default : Id.SourceField;
            set
            {
                if (Id is null)
                {
                    Id = new JsonField();
                }

                Id.SourceField = value;
            }
        }

        [WirePath("properties.topic.sourceField")]
        public string TopicSourceField
        {
            get => Topic is null ? default : Topic.SourceField;
            set
            {
                if (Topic is null)
                {
                    Topic = new JsonField();
                }

                Topic.SourceField = value;
            }
        }

        [WirePath("properties.eventTime.sourceField")]
        public string EventTimeSourceField
        {
            get => EventTime is null ? default : EventTime.SourceField;
            set
            {
                if (EventTime is null)
                {
                    EventTime = new JsonField();
                }

                EventTime.SourceField = value;
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
