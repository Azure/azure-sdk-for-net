// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace System.ClientModel.TypeSpec;

/// <summary>
/// Writes TypeSpec code for a service.
/// </summary>
public static class TypeSpecWriter
{
    /// <summary>
    /// Writes TypeSpec code for a service.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="output"></param>
    public static void WriteServer<T>(Stream output) => WriteServer(output, typeof(T));

    /// <summary>
    /// Writes TypeSpec code for a service.
    /// </summary>
    /// <param name="output"></param>
    /// <param name="service"></param>
    public static void WriteServer(Stream output, Type service)
    {
        string name = service.Name;
        if (name.StartsWith("I")) name = name.Substring(1);

        StreamWriter writer = new(output);
        writer.WriteLine("import \"@typespec/http\";");
        writer.WriteLine("import \"@typespec/rest\";");
        writer.WriteLine("import \"@azure-tools/typespec-client-generator-core\";");
        writer.WriteLine();

        writer.WriteLine("@service({");
        writer.WriteLine($"  title: \"{name}\",");
        writer.WriteLine("})");
        writer.WriteLine();

        writer.WriteLine($"namespace {service.Namespace ?? name};");
        writer.WriteLine();
        writer.WriteLine("using TypeSpec.Http;");
        writer.WriteLine("using TypeSpec.Rest;");
        writer.WriteLine("using Azure.ClientGenerator.Core;");
        writer.WriteLine();
        writer.WriteLine($"@client interface {name}Client {{");

        HashSet<Type> models = [];
        foreach (MethodInfo method in service.GetMethods())
        {
            writer.Write("  ");
            WriteOperation(writer, method, models);
        }
        writer.WriteLine("}");
        writer.WriteLine();
        writer.Flush();

        foreach (Type model in models)
        {
            WriteModel(output, model);
        }

        writer.Flush();
    }

    internal static void WriteModel(Stream output, Type model)
    {
        StreamWriter writer = new(output);

        if (model.IsEnum)
        {
            WriteEnumModel(writer, model);
        }
        else
        {
            WriteClassModel(writer, model);
        }
        writer.WriteLine();
        writer.Flush();
    }
    internal static void WriteModel<T>(Stream output)
    {
        Type model = typeof(T);
        WriteModel(output, model);
    }

    private static void WriteClassModel(StreamWriter writer, Type model)
    {
        writer.WriteLine($"model {model.Name} {{");

        foreach (PropertyInfo property in model.GetProperties())
        {
            WriteClassModelProperty(writer, property);
        }
        writer.WriteLine("}");
    }

    private static void WriteClassModelProperty(StreamWriter writer, PropertyInfo property)
    {
        writer.WriteLine($"  {property.Name.ToCamel()}: {property.PropertyType.ToTspType()};");
    }

    private static void WriteEnumModel(StreamWriter writer, Type model)
    {
        writer.WriteLine($"enum {model.Name} {{");

        foreach (string property in Enum.GetNames(model))
        {
            writer.WriteLine($"  {property.ToCamel()}: \"{property.ToCamel()}\",");
        }
        writer.WriteLine("}");
    }

    private static void WriteOperation(StreamWriter writer, MethodInfo method, HashSet<Type> models)
    {
        string httpVerb = ReadHttpVerb(method);

        var methodName = method.Name;
        if (methodName.EndsWith("Async")) methodName = methodName.Substring(0, methodName.Length - "Async".Length);
        writer.Write($"{httpVerb} @route(\"{ToCamel(methodName)}\") {methodName}(");

        bool first = true;
        foreach (ParameterInfo parameter in method.GetParameters())
        {
            Type parameterType = parameter.ParameterType;

            if (parameterType.FullName!.Equals("Microsoft.AspNetCore.Http.HttpRequest", StringComparison.Ordinal))
            {
                parameterType = typeof(byte[]);
            }

            if (parameterType.IsModel())
                models.Add(parameterType);

            string location = ReadParameterLocation(parameter);
            if (first)
                first = false;
            else
                writer.Write(", ");

            if (location == "@body")
            {
                if (parameterType == typeof(byte[]))
                    writer.Write("@header contentType: \"application/octet-stream\", ");
                writer.Write($"@body {parameter.Name}: {parameterType.ToTspType()}");
            }
            else
                writer.Write($"{location} {parameter.Name}: {parameterType.ToTspType()}");
        }
        writer.WriteLine(") : {");
        writer.WriteLine($"    @statusCode statusCode: 200;");

        Type returnType = method.ReturnType;
        if (returnType == typeof(Task)) returnType = typeof(void);
        else if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(Task<>))
            returnType = returnType.GetGenericArguments()[0];

        writer.WriteLine($"    @body response : {returnType.ToTspType()};");
        writer.WriteLine("  };");
        if (returnType.IsModel())
            models.Add(returnType);
    }

    private static string ReadParameterLocation(ParameterInfo parameter)
    {
        foreach (CustomAttributeData attribute in parameter.GetCustomAttributesData())
        {
            if (attribute.AttributeType.Name == "FromQueryAttribute")
                return "@query";
            if (attribute.AttributeType.Name == "FromHeaderAttribute")
                return "@header";
            if (attribute.AttributeType.Name == "FromRouteAttribute")
                return "@path";
            if (attribute.AttributeType.Name == "FromBodyAttribute")
                return "@body";
        }
        return "@body";
    }
    private static string ReadHttpVerb(MethodInfo method)
    {
        string httpVerb = "@get";

        foreach (CustomAttributeData attribute in method.CustomAttributes)
        {
            if (attribute.AttributeType.Name == "HttpGetAttribute")
                httpVerb = "@get";
            else if (attribute.AttributeType.Name == "HttpPostAttribute")
                httpVerb = "@post";
            else if (attribute.AttributeType.Name == "HttpPutAttribute")
                httpVerb = "@put";
            else if (attribute.AttributeType.Name == "HttpDeleteAttribute")
                httpVerb = "@delete";
            else if (attribute.AttributeType.Name == "HttpPatchAttribute")
                httpVerb = "@patch";
            else if (attribute.AttributeType.Name == "HttpHeadAttribute")
                httpVerb = "@head";
        }

        return httpVerb;
    }

    private static bool IsModel(this Type type)
    {
        return type.IsClass && !type.IsPrimitive &&
               type != typeof(string) &&
               type != typeof(byte[]);
    }

    private static string ToCamel(this string text)
    {
        return $"{char.ToLower(text[0])}{text.Substring(1)}";
    }
    private static string ToTspType(this Type type)
    {
        if (type == typeof(byte[]))
            return "bytes";
        if (type.IsArray)
        {
            Type elementType = type.GetElementType()!;
            return $"{elementType.ToTspType()}[]";
        }
        if (type == typeof(void))
            return "void";
        if (type == typeof(string))
            return "string";
        if (type == typeof(bool))
            return "boolean";
        if (type == typeof(Uri))
            return "url";

        if (type == typeof(sbyte))
            return "int8";
        if (type == typeof(short))
            return "int16";
        if (type == typeof(int))
            return "int32";
        if (type == typeof(long))
            return "int64";

        if (type == typeof(byte))
            return "uint8";
        if (type == typeof(ushort))
            return "uint16";
        if (type == typeof(uint))
            return "uint32";
        if (type == typeof(ulong))
            return "uint64";

        if (type == typeof(float))
            return "float32";
        if (type == typeof(double))
            return "float64";

        // TODO: return "safeint" if long is attributed with [SafeInt]
        // arrays

        if (type.IsClass)
            return type.Name; // model
        throw new InvalidOperationException($"unsupported type {type.Name}");
    }
}
