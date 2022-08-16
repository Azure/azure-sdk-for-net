// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework
{
    internal class ActionConverterFactoryOfT : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsGenericType ? typeof(AuthEventAction).IsAssignableFrom(typeToConvert.GenericTypeArguments[0]) : false;
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type actionType = typeToConvert.GenericTypeArguments[0];
            JsonConverter converter = (JsonConverter)Activator.CreateInstance(
                typeof(ActionConverter<>).MakeGenericType(new Type[] { actionType }));
            return converter;
        }

        internal class ActionConverter<T> : JsonConverter<List<T>> where T : AuthEventAction
        {
            public override List<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                List<T> result = new List<T>();
                AuthEventJsonElement actions = new AuthEventJsonElement(ref reader);
                foreach (AuthEventJsonElement action in actions.Elements)
                {
                    T eventAction = (T)Helpers.GetEventActionForActionType(GetActionValue(action));
                    if (eventAction != null)
                    {
                        eventAction.FromJson(action);
                        result.Add(eventAction);
                    }
                }

                return result.Count == 0 ? throw new Exception(AuthEventResource.Ex_No_Action) : result;
            }

            public override void Write(Utf8JsonWriter writer, List<T> value, JsonSerializerOptions options)
            {
                JsonSerializer.Serialize(writer, value);
            }

            private static string GetActionValue(AuthEventJsonElement jAction)
            {
                if (jAction.Properties.ContainsKey("actionType"))
                {
                    return jAction.GetPropertyValue("actionType");
                }
                else if (jAction.Properties.ContainsKey("type"))
                {
                    return jAction.GetPropertyValue("type");
                }

                return null;
            }
        }
    }
}
