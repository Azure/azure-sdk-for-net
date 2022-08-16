// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    internal static class Helpers
    {
        internal static EventDefinition GetEventDefintionFromPayload(string payload)
        {
            try
            {
                AuthEventJsonElement jPayload = new AuthEventJsonElement(payload);
                string comparable = string.Empty;
                if (jPayload.Properties.ContainsKey("type"))
                {
                    comparable = jPayload.GetPropertyValue("type");
                }

                foreach (EventDefinition eventDefinition in Enum.GetValues(typeof(EventDefinition)))
                {
                    AuthEventMetadataAttribute eventMetadata = eventDefinition.GetAttribute<AuthEventMetadataAttribute>();
                    if (eventMetadata.EventIdentifier.Equals(comparable, StringComparison.OrdinalIgnoreCase))
                    {
                        return eventDefinition;
                    }
                }

                throw new Exception(string.Format(CultureInfo.CurrentCulture, AuthEventResource.Ex_Comparable_Not_Found, comparable));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, AuthEventResource.Ex_Event_Missing, ex.Message));
            }
        }

        internal static ConcurrentDictionary<string, Type> _eventActions = new ConcurrentDictionary<string, Type>();
        internal static HttpResponseMessage HttpErrorResponse(Exception ex)
        {
            return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
            {
                Content = new StringContent(GetFailedRequestPayload(ex))
            };
        }

        internal static string GetFailedRequestPayload(Exception ex)
        {
            List<string> errors = new List<string>();
            if (ex != null)
            {
                errors.Add(ex.Message);
                ex = ex.InnerException;
                while (ex != null)
                {
                    if (ex is AggregateException agEx)
                    {
                        errors.AddRange(agEx.InnerExceptions.Select(m => m.Message).ToArray());
                    }
                    else
                    {
                        errors.Add(ex.Message);
                    }

                    ex = ex.InnerException;
                }
            }
            else
            {
                errors.Add(AuthEventResource.Ex_Gen_Failure);
            }

            return $"{{\"errors\":[\"{String.Join("\",\"", errors.Select(m => m))}\"]}}";
        }

        internal static HttpResponseMessage HttpUnauthorizedResponse()
        {
            return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
        }

        internal static HttpResponseMessage HttpJsonResponse(AuthEventJsonElement json)
        {
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(json.ToString(), Encoding.UTF8, "application/json")
            };
        }

        /// <summary>Determines whether the specified input is json.</summary>
        /// <param name="input">The input.</param>
        /// <returns>
        ///   <c>true</c> if the specified input is json; otherwise, <c>false</c>.</returns>
        internal static bool IsJson(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            input = input.Trim();
            return (input.StartsWith("{", StringComparison.OrdinalIgnoreCase) && input.EndsWith("}", StringComparison.OrdinalIgnoreCase))
                || (input.StartsWith("[", StringComparison.OrdinalIgnoreCase) && input.EndsWith("]", StringComparison.OrdinalIgnoreCase));
        }

        internal static AuthEventAction GetEventActionForActionType(string actionType)
        {
            if (_eventActions.IsEmpty)
            {
                Type eventType = typeof(AuthEventAction);
                var actions = Assembly.GetExecutingAssembly().GetTypes()
                    .Where(p => eventType.IsAssignableFrom(p) && !(p.IsInterface || p.IsAbstract));

                foreach (Type type in actions)
                {
                    AuthEventAction action = (AuthEventAction)Activator.CreateInstance(type);
                    _eventActions.TryAdd(action.ActionType, type);
                }
            }

            return actionType != null && _eventActions.ContainsKey(actionType)
                ? (AuthEventAction)Activator.CreateInstance(_eventActions[actionType])
                : throw new Exception(String.Format(CultureInfo.CurrentCulture, AuthEventResource.Ex_Action_Invalid, actionType, String.Join("', '", _eventActions.Select(x => x.Key))));
        }

        internal static void ValidateGraph(object graph)
        {
            var validationResults = new List<ValidationResult>();

            ValidateGraph(graph, validationResults);

            if (validationResults.Count > 0)
            {
                throw new AggregateException(AuthEventResource.Ex_Invalid_Payload, validationResults.Select(v => new Exception(v.ErrorMessage)));
            }
        }

        private static void ValidateGraph(object obj, List<ValidationResult> validationResults)
        {
            List<ValidationResult> objectValidations = new List<ValidationResult>();

            var props = obj.GetType().GetProperties().Where(p => p.GetCustomAttributes(false).FirstOrDefault(a => typeof(ValidationAttribute).IsAssignableFrom(a.GetType())) != null);

            foreach (var prop in props)
            {
                object inst = prop.GetValue(obj);

                Validator.TryValidateProperty(inst, new ValidationContext(obj) { MemberName = prop.Name }, objectValidations);

                if (inst != null)//Short curcuit the validation if the parent is null.
                {
                    ValidateGraph(inst, validationResults);
                }
            }

            validationResults.AddRange(objectValidations.Select(f => { f.ErrorMessage = $"{obj.GetType().Name}: {f.ErrorMessage}"; return f; }));
        }
    }
}
