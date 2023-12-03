// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Triggers;
using static Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.EmptyResponse;
using AuthenticationEventMetadata = Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.AuthenticationEventMetadata;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>Main trigger binding class where we handle the incoming HTTP request message.</summary>
    /// <seealso cref="ITriggerBinding" />
    internal class AuthenticationEventBinding : ITriggerBinding
    {
        internal const string InstanceIdBindingPropertyName = "instanceId";
        private const string DataBindingPropertyName = "data";

        private readonly AuthenticationEventsTriggerAttribute _authEventTriggerAttr;
        private readonly AuthenticationEventConfigProvider _configuration;
        private readonly ParameterInfo _parameterInfo;
        private readonly IReadOnlyDictionary<string, Type> _contract;
        /// <summary>Gets the type of the trigger value.</summary>
        /// <value>The type of the trigger value.</value>
        public Type TriggerValueType => typeof(HttpRequestMessage);

        /// <summary>Gets the binding data contract.</summary>
        /// <value>The binding data contract.</value>
        public IReadOnlyDictionary<string, Type> BindingDataContract => _contract;

        /// <summary>Initializes a new instance of the <see cref="AuthenticationEventBinding" /> class.</summary>
        /// <param name="authEventTriggerAttr">The authentication event trigger attribute.</param>
        /// <param name="configProvider">The configuration provider.</param>
        /// <param name="parameterInfo">Initial parameter details.</param>
        internal AuthenticationEventBinding(AuthenticationEventsTriggerAttribute authEventTriggerAttr, AuthenticationEventConfigProvider configProvider, ParameterInfo parameterInfo)
        {
            _authEventTriggerAttr = authEventTriggerAttr;
            _configuration = configProvider;
            _parameterInfo = parameterInfo;
            _contract = GetBindingDataContract(parameterInfo);
        }

        /// <summary>Gets the binding data contract.</summary>
        /// <param name="parameterInfo">The parameter information.</param>
        /// <returns>A contract with the return type and Instance Id in the dictionary.</returns>
        private static IReadOnlyDictionary<string, Type> GetBindingDataContract(ParameterInfo parameterInfo)
        {
            var contract = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase)
                {
                    // This binding supports return values of any type
                    { "$return", typeof(object).MakeByRefType() },
                    { InstanceIdBindingPropertyName, typeof(string) },
                };

            // allow binding to the parameter name
            contract[parameterInfo.Name] = parameterInfo.ParameterType;

            // allow binding directly to the JSON representation of the data.
            contract[DataBindingPropertyName] = typeof(string);

            return contract;
        }

        /// <summary>Binds the asynchronous.</summary>
        /// <param name="value">The value.</param>
        /// <param name="context">The context.</param>
        /// <returns>The Trigger data containing the event related request object.</returns>
        /// <exception cref="NotSupportedException">An HttpRequestMessage is required.</exception>
        /// <exception cref="UnauthorizedAccessException">If the token is invalid.</exception>
        /// <exception cref="InvalidDataException">blah</exception>
        /// <seealso cref="ITriggerData" />
        public async Task<ITriggerData> BindAsync(object value, ValueBindingContext context)
        {
            var request = (HttpRequestMessage)value;
            AuthenticationEventResponseHandler eventResponseHandler =
                (AuthenticationEventResponseHandler)request.Properties[AuthenticationEventResponseHandler.EventResponseProperty];
            try
            {
                if (request == null)
                {
                    throw new NotSupportedException(AuthenticationEventResource.Ex_Invalid_Inbound);
                }

                Dictionary<string, string> Claims = await GetClaimsAndValidateRequest(request).ConfigureAwait(false);
                string payload = await request.Content.ReadAsStringAsync().ConfigureAwait(false);
                AuthenticationEventMetadata eventMetadata = GetEventAndValidateSchema(payload);

                eventResponseHandler.Request = GetRequestForEvent(request, payload, eventMetadata, Claims);

                return new TriggerData(
                    new AuthenticationEventValueBinder(
                        eventResponseHandler.Request,
                        _authEventTriggerAttr),
                        GetBindingData(
                            context,
                            value,
                            eventResponseHandler))
                {
                    ReturnValueProvider = eventResponseHandler
                };
            }
            catch (Exception ex)
            {
                return GetFaultyRequest(context, value, request, eventResponseHandler, ex);
            }
        }

        #region Request Handlers
        /// <summary>Gets the faulty request.</summary>
        /// <param name="context">Current binding context</param>
        /// <param name="value">Incoming value.</param>
        /// <param name="request">The incoming HTTP request message.</param>
        /// <param name="eventResponseHandler">The event response handler.</param>
        /// <param name="ex">The exception that caused the fault.</param>
        /// <returns>A TriggerData Object with the failed event request based on the event. With the related request status set.</returns>
        /// <seealso cref="TriggerData" />
        /// <seealso cref="AuthenticationEventResponseHandler" />
        private TriggerData GetFaultyRequest(
            ValueBindingContext context,
            object value,
            HttpRequestMessage request,
            AuthenticationEventResponseHandler eventResponseHandler,
            Exception ex)
        {
            eventResponseHandler.Request = _parameterInfo.ParameterType == typeof(string) ? new EmptyRequest(request) : AuthenticationEventMetadata.CreateEventRequest(request, _parameterInfo.ParameterType, null);
            eventResponseHandler.Request.StatusMessage = ex.Message;

            eventResponseHandler.Request.RequestStatus = ex switch
            {
                UnauthorizedAccessException => RequestStatusType.TokenInvalid,
                ValidationException => RequestStatusType.ValidationError,
                AuthenticationEventTriggerRequestValidationException => RequestStatusType.ValidationError,
                _ => RequestStatusType.Failed,
            };

            if (eventResponseHandler.Response != null)
            {
                if (ex is UnauthorizedAccessException)
                {
                    eventResponseHandler.Response.StatusCode = System.Net.HttpStatusCode.Unauthorized;
                }
                else
                {
                    eventResponseHandler.Response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    eventResponseHandler.Response.ReasonPhrase = ex.Message;
                }
            }

            return new TriggerData(new AuthenticationEventValueBinder(eventResponseHandler.Request, _authEventTriggerAttr), GetBindingData(context, value, eventResponseHandler))
            {
                ReturnValueProvider = eventResponseHandler
            };
        }
        /// <summary>Gets the request for the event.</summary>
        /// <param name="request">The HTTP request message.</param>
        /// <param name="payload">The incoming payload.</param>
        /// <param name="eventMetadata">The event metadata.</param>
        /// <param name="tokenClaims">The token claims.</param>
        /// <returns>The related EventRequest based on the event requested.<br /></returns>
        /// <seealso cref="AuthenticationEventMetadata" />
        /// <seealso cref="AuthenticationEventRequestBase" />
        private AuthenticationEventRequestBase GetRequestForEvent(HttpRequestMessage request, string payload, AuthenticationEventMetadata eventMetadata, Dictionary<string, string> tokenClaims)
            => GetRequestForEvent(request, payload, eventMetadata, tokenClaims, null);

        /// <summary>Gets the request for event.
        /// And sets the status message and state based on the exception.</summary>
        /// <param name="request">The HTTP request message.</param>
        /// <param name="payload">The body of the request (Json).</param>
        /// <param name="eventMetaData">The event metadata.</param>
        /// <param name="tokenClaims">The token claims.</param>
        /// <param name="ex">An exception if any occurred along the way.</param>
        /// <returns>The related EventRequest based on the event requested.</returns>
        /// <exception cref="Exception">An exception is thrown if the IRequestEvent could not be determined from the incoming HTTP request message.</exception>
        /// <seealso cref="AuthenticationEventMetadata" />
        /// <seealso cref="AuthenticationEventRequestBase" />
        private AuthenticationEventRequestBase GetRequestForEvent(HttpRequestMessage request, string payload, AuthenticationEventMetadata eventMetaData, Dictionary<string, string> tokenClaims, Exception ex)
        {
            AuthenticationEventRequestBase requestEvent = eventMetaData?.CreateEventRequestValidate(request, payload, tokenClaims);
            if (requestEvent == null)
            {
                throw new Exception(AuthenticationEventResource.Ex_Invalid_Event);
            }
            else if (requestEvent.GetType() != _parameterInfo.ParameterType && ex == null && _parameterInfo.ParameterType != typeof(string))
            {
                throw new Exception(string.Format(CultureInfo.CurrentCulture, AuthenticationEventResource.Ex_Parm_Mismatch, requestEvent.GetType(), _parameterInfo.ParameterType));
            }

            requestEvent.StatusMessage = ex == null ? AuthenticationEventResource.Status_Good : ex.Message;
            requestEvent.RequestStatus = ex == null ? RequestStatusType.Successful : ex is UnauthorizedAccessException ? RequestStatusType.TokenInvalid : RequestStatusType.Failed;

            return requestEvent;
        }

        private Dictionary<string, object> GetBindingData(ValueBindingContext context, object value, AuthenticationEventResponseHandler eventResponseHandler)
        {
            return new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
            {
                [InstanceIdBindingPropertyName] = context.FunctionContext.FunctionInstanceId,
                [_parameterInfo.Name] = value.ToString(),
                [DataBindingPropertyName] = eventResponseHandler.Request?.ToString()
            };
        }
        #endregion

        #region Validators
        private async Task<Dictionary<string, string>> GetClaimsAndValidateRequest(HttpRequestMessage requestMessage)
        {
            ConfigurationManager configurationManager = new ConfigurationManager(_authEventTriggerAttr);
            if (ConfigurationManager.BypassValidation)
            {
                return null;
            }

            TokenValidator validator = ConfigurationManager.EZAuthEnabled && requestMessage.Headers.Matches(ConfigurationManager.HEADER_EZAUTH_ICP, ConfigurationManager.HEADER_EZAUTH_ICP_VERIFY) ?
                (TokenValidator)new TokenValidatorEZAuth() :
                new TokenValidatorInternal();

            (bool valid, Dictionary<string, string> claims) = await validator.GetClaimsAndValidate(requestMessage, configurationManager).ConfigureAwait(false);
            if (valid)
            {
                return claims;
            }
            else
            {
                throw new UnauthorizedAccessException();
            }
        }

        /// <summary>Gets the event and validates the income Json against schema provided on the Event Metadata Attribute.</summary>
        /// <param name="body">The body of the incoming request.</param>
        /// <returns>The Event Metadata object.</returns>
        /// <exception cref="AggregateException">Aggregates all the schema validation exceptions.</exception>
        /// <exception cref="Exception">IF the event cannot be determined or if the object model event differs from the requested event on the incoming payload.</exception>
        internal static AuthenticationEventMetadata GetEventAndValidateSchema(string body)
        {
            try
            {
                Helpers.ValidateJson(body);
            }
            catch (JsonException ex)
            {
                throw new AuthenticationEventTriggerRequestValidationException($"{AuthenticationEventResource.Ex_Invalid_JsonPayload}: {ex.Message}", ex.InnerException);
            }

            return AuthenticationEventMetadataLoader.GetEventMetadata(body);
        }
        #endregion

        /// <summary>Creates the listener asynchronous.</summary>
        /// <param name="context">The context.</param>
        /// <returns>An IListener.</returns>
        /// <exception cref="ArgumentNullException">context.</exception>
        public Task<IListener> CreateListenerAsync(ListenerFactoryContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(AuthenticationEventResource.Ex_Context_Null);
            }

            var function = context.Descriptor.ShortName.Split('.').Last();
            _configuration.Listeners.Add(function, new AuthenticationEventListener(context.Executor, _authEventTriggerAttr));
            //_configuration.LogInformation($"Added function listener: {function}");
            _configuration.DisplayAzureFunctionInfoToConsole(function);

            return Task.FromResult<IListener>(new NullListener());
        }

        /// <summary>Converts to parameter-descriptor.</summary>
        /// <returns>The parameter description for the trigger and binding.</returns>
        public ParameterDescriptor ToParameterDescriptor()
        {
            return new TriggerParameterDescriptor()
            {
                Name = "Authentication Event Trigger",
                DisplayHints = new ParameterDisplayHints()
                {
                    Prompt = "Host",
                    Description = "Authentication Event Trigger"
                }
            };
        }

        #region listener
        /// <summary>This is a null listener that does nothing. But is requested for the WebJobs Framework, our isolated hosting is handled by the configuration.</summary>
        private class NullListener : IListener
        {
            /// <summary>Cancels this instance.</summary>
            public void Cancel()
            {
            }

            /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
            public void Dispose()
            {
            }

            /// <summary>Starts the asynchronous listener.</summary>
            /// <param name="cancellationToken">The cancellation token.</param>
            /// <returns>A task that is flagged as completed.</returns>
            public Task StartAsync(CancellationToken cancellationToken)
            {
                return Task.CompletedTask;
            }

            /// <summary>Stops the asynchronous listener.</summary>
            /// <param name="cancellationToken">The cancellation token.</param>
            /// <returns>A task that is flagged as completed.</returns>
            public Task StopAsync(CancellationToken cancellationToken)
            {
                return Task.CompletedTask;
            }
        }
        #endregion
    }
}
