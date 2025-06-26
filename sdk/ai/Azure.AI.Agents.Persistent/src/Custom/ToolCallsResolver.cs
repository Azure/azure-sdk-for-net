// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;

namespace Azure.AI.Agents.Persistent
{
    /// <summary>
    /// ToolCallsResolver is used to resolve tool calls in the streaming API.
    /// </summary>
    internal class ToolCallsResolver
    {
        private readonly Dictionary<string, Delegate> _toolDelegates = new();

        internal ToolCallsResolver(Dictionary<string, Delegate> toolDelegates)
        {
            _toolDelegates = toolDelegates;
        }

        /// <summary>
        /// Resolves the tool call by invoking the delegate associated with the function name.
        /// It casts the function arguments to the appropriate types based on the delegate's parameters.
        /// without knowing the answer.
        /// </summary>
        internal ToolOutput GetResolvedToolOutput(string functionName, string toolCallId, string functionArguments)
        {
            if (!_toolDelegates.TryGetValue(functionName, out var func))
            {
                string error = $"Function {functionName} not found.";
                throw new MissingMethodException(error);
            }

            var result = Resolve(func, functionArguments);
            return new ToolOutput(toolCallId, result == null ? "" : result.ToString());
        }

        /// <summary>
        /// Resolves the function call by invoking the delegate associated with the function name.
        /// </summary>
        /// <param name="function"></param>
        /// <param name="functionArguments"></param>
        /// <returns></returns>
        internal static object Resolve(Delegate function, string functionArguments)
        {
            JsonDocument argumentsJson = JsonDocument.Parse(functionArguments);
            MethodInfo method = function.Method;
            var args = new List<object>();
            foreach (ParameterInfo param in function.Method.GetParameters())
            {
                if (argumentsJson.RootElement.TryGetProperty(param.Name ?? "", out JsonElement element))
                {
                    object val = GetArgumentValue(param.Name, param.ParameterType, element);
                    args.Add(val);
                }
                else if (param.DefaultValue != null)
                {
                    args.Add(param.DefaultValue);
                }
                // check if the value is not in arguments, but the parameter is required, throw error
                else if (Nullable.GetUnderlyingType(param.ParameterType) == null)
                {
                    throw new ArgumentException($"Missing required argument {param.Name} for function {function.Method.Name}");
                }
            }
            return function.DynamicInvoke(args.ToArray());
        }

        private static object GetArgumentValue(string name, Type type, JsonElement element)
        {
            if (type == typeof(string))
            {
                return element.GetString();
            }
            else if (type == typeof(int))
            {
                if (element.TryGetInt32(out int val))
                    return val;
            }
            else if (type == typeof(ushort))
            {
                if (element.TryGetInt16(out short val))
                    return val;
            }
            else if (type == typeof(float))
            {
                if (element.TryGetSingle(out float val))
                    return val;
            }
            else if (type == typeof(uint))
            {
                if (element.TryGetUInt32(out uint val))
                    return val;
            }
            else if (type == typeof(decimal))
            {
                if (element.TryGetDecimal(out decimal val))
                    return val;
            }
            else if (type == typeof(double))
            {
                if (element.TryGetDouble(out double val))
                    return val;
            }
            else if (type == typeof(long))
            {
                if (element.TryGetInt64(out long val))
                    return val;
            }
            else if (type == typeof(bool))
            {
                if (TryParseBoolean(element, out bool? val))
                    return val;
            }
            // TODO: the following code has been testedwith Dictionary,
            // deserializable Address class with address and city fields
            // and Address[].   But need more testings.
            //else if (type == typeof(object))
            //{
            //    return element.GetRawText();
            //}
            //else if (IsDictionaryType(type))
            //{
            //    Type[] genericArguments = type.GetGenericArguments();
            //    Type dictionaryType = typeof(Dictionary<,>).MakeGenericType(typeof(string), genericArguments[1]);

            //    // Create an instance of the dictionary
            //    var dict = Activator.CreateInstance(dictionaryType);

            //    MethodInfo addMethod = dictionaryType.GetMethod("Add");

            //    foreach (var prop in element.EnumerateObject())
            //    {
            //        object val = GetArgumentValue(prop.Name, genericArguments[1], prop.Value);
            //        addMethod.Invoke(dict, [prop.Name, val]);
            //    }
            //    return dict;
            //}
            //else if (type.IsArray)
            //{
            //    Type elementType = type.GetElementType()!;
            //    Array array = Array.CreateInstance(elementType, element.GetArrayLength());
            //    int i = 0;
            //    foreach (var item in element.EnumerateArray())
            //    {
            //        object val = GetArgumentValue(name, elementType, item);
            //        array.SetValue(val, i++);
            //    }
            //    return array;
            //}
            //else if (TryDeserialize(element.GetRawText(), type, out object val))
            //{
            //    return val;
            //}
            throw new ArgumentException($"Received {element.GetRawText()}, but {name} in function implementation is {type}");
        }

        /// <summary>
        /// JsonElement doesn't offer TryGetBoolean but offers GetBoolean that can throw exception
        /// With that said, we need to create a custom TryGetBoolean method
        /// </summary>
        private static bool TryParseBoolean(JsonElement element, out bool? value)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.True:
                    value = true;
                    return true;
                case JsonValueKind.False:
                    value = false;
                    return true;
                default:
                    value = default;
                    return false;
            }
        }

        // Uncommon this to support deserializable class
        //private static bool TryDeserialize(string input, Type type, out object obj)
        //{
        //    try
        //    {
        //        obj = JsonSerializer.Deserialize(input, type, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        //        return true;
        //    }
        //    catch (JsonException)
        //    {
        //        obj = null;
        //        return false;
        //    }
        //}

        // Uncommon this to support dictionary
        //private static bool IsDictionaryType(Type type)
        //{
        //    // Check if the type is a generic type
        //    if (type.IsGenericType)
        //    {
        //        // Get the generic type definition
        //        Type genericTypeDefinition = type.GetGenericTypeDefinition();

        //        // Check if the generic type definition is Dictionary<,>
        //        if (genericTypeDefinition == typeof(Dictionary<,>))
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}
    }
}
