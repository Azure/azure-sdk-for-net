// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Projects;
using Azure.Projects.Web.Tsp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.Projects.Web.Tsp;

/// <summary>
/// ASp.NET Core extension methods for mapping a service implementation to a set of HTTP endpoints.
/// </summary>
public static class TspExtensions
{
    /// <summary>
    /// Maps a service implementation to a set of HTTP endpoints.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="routeBuilder"></param>
    /// <param name="serviceImplementation"></param>
    private static void Map<T>(this IEndpointRouteBuilder routeBuilder, T serviceImplementation) where T : class
    {
        Type serviceImplementationType = typeof(T);
        Type serviceDescriptor = GetServiceDescriptor(serviceImplementationType);
        MethodInfo[] serviceOperations = serviceDescriptor.GetMethods();
        foreach (MethodInfo serviceOperation in serviceOperations)
        {
            RequestDelegate handler = CreateRequestDelegate(serviceImplementation, serviceOperation);
            string name = serviceOperation.Name;
            if (name.EndsWith("Async"))
                name = name.Substring(0, name.Length - "Async".Length);
            routeBuilder.Map($"/{name}", handler);
        }
    }

    private static Type GetServiceDescriptor(Type serviceImplementation)
    {
        Type[] interfaces = serviceImplementation.GetInterfaces();
        if (interfaces.Length != 1)
            throw new InvalidOperationException($"Service {serviceImplementation} must implement exactly one interface");
        Type interfaceType = interfaces[0];
        return interfaceType;
    }

    private static RequestDelegate CreateRequestDelegate<T>(T service, MethodInfo implementationMethod) where T : class
    {
        return async (context) => {
            HttpRequest request = context.Request;

            Type serviceType = service.GetType();
            Type interfaceType = GetServiceDescriptor(serviceType);
            MethodInfo? interfaceMethod = interfaceType.GetMethod(implementationMethod.Name, BindingFlags.Public | BindingFlags.Instance);

            ParameterInfo[] parameters = interfaceMethod!.GetParameters();
            object[] implementationArguments = new object[parameters.Length];

            foreach (ParameterInfo parameter in parameters)
            {
                implementationArguments[0] = await CreateArgumentAsync(parameter, request).ConfigureAwait(false);
            }

            // deal with async APIs
            object? implementationReturnValue = implementationMethod.Invoke(service, implementationArguments);
            if (implementationReturnValue != default)
            {
                Task? task = implementationReturnValue as Task;
                if (task != default)
                {
                    await task.ConfigureAwait(false);
                    implementationReturnValue = task.GetType().GetProperty("Result")!.GetValue(task);
                }
                else
                { // TODO: we need to deal with ValueTask too
                    implementationReturnValue = default;
                }
            }
            else
            {
                Debug.Assert(implementationArguments.Length == 0);
            }

            HttpResponse response = context.Response;
            response.StatusCode = 200;
            if (implementationReturnValue != default)
            {
                BinaryData responseBody = Serialize(implementationReturnValue);
                response.ContentLength = responseBody.ToMemory().Length;
                response.ContentType = "application/json";
                await response.Body.WriteAsync(responseBody.ToArray()).ConfigureAwait(false);
            }
        };
    }

    private static async ValueTask<object> CreateArgumentAsync(ParameterInfo parameter, HttpRequest request)
    {
        Type parameterType = parameter.ParameterType;

        if (parameterType == typeof(HttpRequest))
        {
            return request;
        }

        if (parameterType == typeof(Stream))
        {
            return request.Body;
        }

        if (parameterType == typeof(byte[]))
        {
            BinaryData bd = await BinaryData.FromStreamAsync(request.Body).ConfigureAwait(false);
            return bd.ToArray();
        }
        if (parameterType == typeof(BinaryData))
        {
            string? contentType = request.ContentType;
            BinaryData bd = await BinaryData.FromStreamAsync(request.Body, contentType).ConfigureAwait(false);
            return bd;
        }
        if (parameterType == typeof(string))
        {
            return await new StreamReader(request.Body).ReadToEndAsync().ConfigureAwait(false);
        }

        FromQueryAttribute? fqa = parameter.GetCustomAttribute<FromQueryAttribute>();
        if (fqa != default)
        {
            string? queryValue = request.Query[parameter.Name!];
            return Convert.ChangeType(queryValue!, parameterType);
        }

        FromHeaderAttribute? fha = parameter.GetCustomAttribute<FromHeaderAttribute>();
        if (fha != default)
        {
            var headerName = fha.Name ?? parameter.Name;
            string? headerValue = request.Headers[headerName!];
            return Convert.ChangeType(headerValue!, parameterType);
        }

        object deserialized = DeserializeModel(parameterType, request.Body);
        return deserialized;
    }

    // TODO: this is a hack. We should use MRW
    private static object DeserializeModel(Type modelType, Stream stream)
    {
        MethodInfo? fromJson = modelType.GetMethod("FromJson", BindingFlags.Static);
        if (fromJson == default)
            throw new InvalidOperationException($"{modelType} does not provide FromJson static method");
        object? deserialized = fromJson.Invoke(null, [stream]);
        if (deserialized == default)
            throw new InvalidOperationException($"Failed to deserialize {modelType}");
        return deserialized;
    }

    private static BinaryData Serialize(object implementationReturnValue)
    {
        Type type = implementationReturnValue.GetType();
        if (type.IsGenericType)
        {
            if (type.GetGenericTypeDefinition() == typeof(ValueTask<>))
            {
            }
            if (type.GetGenericTypeDefinition() == typeof(Task<>))
            {
            }
        }

        BinaryData bd = BinaryData.FromObjectAsJson(implementationReturnValue);
        return bd;
    }
}
