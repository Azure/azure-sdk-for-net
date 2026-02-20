// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubContextBinding : BindingBase<WebPubSubContextAttribute>
    {
        private const string HttpRequestName = "$request";
        private readonly Type _userType;
        private readonly WebPubSubServiceAccessOptions _options;
        private readonly WebPubSubServiceAccessFactory _accessFactory;

        public WebPubSubContextBinding(
            BindingProviderContext context,
            IConfiguration configuration,
            INameResolver nameResolver,
            WebPubSubServiceAccessOptions options,
            WebPubSubServiceAccessFactory accessFactory) : base(context, configuration, nameResolver)
        {
            _userType = context.Parameter.ParameterType;
            _options = options;
            _accessFactory = accessFactory;
        }

        protected async override Task<IValueProvider> BuildAsync(WebPubSubContextAttribute attrResolved, IReadOnlyDictionary<string, object> bindingData)
        {
            if (bindingData == null)
            {
                throw new ArgumentNullException(nameof(bindingData));
            }
            bindingData.TryGetValue(HttpRequestName, out var httpRequest);
            var request = httpRequest as HttpRequest;

            var httpContext = request?.HttpContext;

            if (httpContext == null)
            {
                return new WebPubSubContextValueProvider(new WebPubSubContext($"HttpContext is null.", WebPubSubErrorCode.UserError), _userType);
            }

            try
            {
                WebPubSubServiceAccess[]? accesses = null;
                if (attrResolved?.Connections != null)
                {
                    var resolved = new List<WebPubSubServiceAccess>(attrResolved.Connections.Length);
                    foreach (var sectionName in attrResolved.Connections)
                    {
                        if (!_accessFactory.TryCreateFromSectionName(sectionName, out var access) || access == null)
                        {
                            throw new InvalidOperationException($"Unable to resolve Web PubSub connection from configuration section '{sectionName}'.");
                        }
                        resolved.Add(access);
                    }
                    accesses = [.. resolved];
                }

                accesses ??= _options.WebPubSubAccess != null ? [_options.WebPubSubAccess] : null;
                var validator = new RequestValidator(accesses);
                var serviceRequest = await request.ReadWebPubSubRequestAsync(validator).ConfigureAwait(false);

                switch (serviceRequest)
                {
                    case PreflightRequest validationRequest:
                        {
                            var response = new HttpResponseMessage();
                            if (validationRequest.IsValid)
                            {
                                response.Headers.Add(Constants.Headers.WebHookAllowedOrigin, Constants.AllowedAllOrigins);
                            }
                            else
                            {
                                response.StatusCode = HttpStatusCode.BadRequest;
                            }
                            var abuseRequest = new WebPubSubContext(validationRequest, response);
                            return new WebPubSubContextValueProvider(abuseRequest, _userType);
                        }
                    case ConnectEventRequest:
                    case UserEventRequest:
                    case ConnectedEventRequest:
                    case DisconnectedEventRequest:
                    default:
                        return new WebPubSubContextValueProvider(new WebPubSubContext(serviceRequest), _userType);
                }
            }
            catch (UnauthorizedAccessException unauthorized)
            {
                return new WebPubSubContextValueProvider(new WebPubSubContext(unauthorized.Message, WebPubSubErrorCode.Unauthorized), _userType);
            }
            catch (Exception ex)
            {
                return new WebPubSubContextValueProvider(new WebPubSubContext(ex.Message, WebPubSubErrorCode.UserError), _userType);
            }
        }
    }
}
