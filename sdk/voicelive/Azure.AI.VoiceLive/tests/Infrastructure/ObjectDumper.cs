// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

#pragma warning disable SA1402 // Mark members as static

namespace Azure.AI.VoiceLive.Tests.Infrastructure
{
    public class ObjectDumper
    {
        private readonly HashSet<object> _visitedObjects;
        private readonly StringBuilder _output;
        private const int MaxDepth = 10;

        public ObjectDumper()
        {
            _visitedObjects = new HashSet<object>(ReferenceEqualityComparer.Instance);
            _output = new StringBuilder();
        }

        public string Dump(object obj, string objectName = "Root")
        {
            _visitedObjects.Clear();
            _output.Clear();

            DumpObject(obj, objectName, 0);
            return _output.ToString();
        }

        private void DumpObject(object? obj, string name, int depth)
        {
            var indent = new string(' ', depth * 2);

            if (obj == null)
            {
                _output.AppendLine($"{indent}{name}: null");
                return;
            }

            if (depth > MaxDepth)
            {
                _output.AppendLine($"{indent}{name}: [Max depth reached]");
                return;
            }

            var objType = obj.GetType();
            var declaredType = GetDeclaredType(obj);

            // Handle primitive types and strings
            if (IsPrimitiveType(objType))
            {
                _output.AppendLine($"{indent}{name}: {obj} (Type: {objType.Name})");
                return;
            }

            // Check for circular references
            if (!objType.IsValueType && _visitedObjects.Contains(obj))
            {
                _output.AppendLine($"{indent}{name}: [Circular Reference - {objType.Name}]");
                return;
            }

            if (!objType.IsValueType)
            {
                _visitedObjects.Add(obj);
            }

            // Handle collections
            if (obj is IEnumerable enumerable && !(obj is string))
            {
                DumpCollection(enumerable, name, objType, depth);
                return;
            }

            // Handle regular objects
            _output.AppendLine($"{indent}{name}: {objType.Name} {GetInheritanceInfo(objType)}");

            var properties = objType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                    .Where(p => p.CanRead && p.GetIndexParameters().Length == 0)
                                    .OrderBy(p => p.Name);

            foreach (var property in properties)
            {
                try
                {
                    var value = property.GetValue(obj);
                    var propertyInfo = GetPropertyTypeInfo(property, value);

                    _output.AppendLine($"{indent}  Property: {property.Name} {propertyInfo}");
                    DumpObject(value, $"{property.Name}", depth + 2);
                }
                catch (Exception ex)
                {
                    _output.AppendLine($"{indent}  Property: {property.Name} - Error: {ex.Message}");
                }
            }

            if (!objType.IsValueType)
            {
                _visitedObjects.Remove(obj);
            }
        }

        private void DumpCollection(IEnumerable enumerable, string name, Type collectionType, int depth)
        {
            var indent = new string(' ', depth * 2);
            var elementType = GetCollectionElementType(collectionType);

            _output.AppendLine($"{indent}{name}: {collectionType.Name}<{elementType?.Name ?? "object"}> {GetInheritanceInfo(collectionType)}");

            var index = 0;
            foreach (var item in enumerable)
            {
                if (index > 100) // Prevent extremely large collections from overwhelming output
                {
                    _output.AppendLine($"{indent}  [... and more items]");
                    break;
                }

                var actualType = item?.GetType();
                var typeInfo = actualType != null ? $" (Actual: {actualType.Name})" : "";
                if (null != item)
                {
                    DumpObject(item, $"[{index}]{typeInfo}", depth + 1);
                }
                index++;
            }

            if (index == 0)
            {
                _output.AppendLine($"{indent}  [Empty Collection]");
            }
        }

        private string? GetPropertyTypeInfo(PropertyInfo property, object? value)
        {
            var declaredType = property.PropertyType;
            var actualType = value?.GetType();

            var info = $"(Declared: {declaredType.Name}";

            if (actualType != null && actualType != declaredType)
            {
                info += $", Actual: {actualType.Name}";
            }

            info += ")";
            return info;
        }

        private string GetInheritanceInfo(Type type)
        {
            var parts = new List<string>();

            if (type.BaseType != null && type.BaseType != typeof(object))
            {
                parts.Add($"Base: {type.BaseType.Name}");
            }

            var interfaces = type.GetInterfaces().Where(i => i.IsPublic).Take(3);
            if (interfaces.Any())
            {
                parts.Add($"Implements: {string.Join(", ", interfaces.Select(i => i.Name))}");
            }

            return parts.Any() ? $"({string.Join(", ", parts)})" : "";
        }

        private Type? GetCollectionElementType(Type collectionType)
        {
            if (collectionType.IsArray)
            {
                return collectionType.GetElementType();
            }

            if (collectionType.IsGenericType)
            {
                var genericArgs = collectionType.GetGenericArguments();
                if (genericArgs.Length > 0)
                {
                    return genericArgs[0]; // For most collections, the first generic argument is the element type
                }
            }

            // Check if it implements IEnumerable<T>
            var enumerableInterface = collectionType.GetInterfaces()
                .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>));

            return enumerableInterface?.GetGenericArguments().FirstOrDefault();
        }

        private Type? GetDeclaredType(object obj)
        {
            // This is a simplified version - in practice, you might want to pass the declared type
            // from the calling context (e.g., from PropertyInfo.PropertyType)
            return obj?.GetType();
        }

        private bool IsPrimitiveType(Type type)
        {
            return type.IsPrimitive ||
                   type == typeof(string) ||
                   type == typeof(decimal) ||
                   type == typeof(DateTime) ||
                   type == typeof(DateTimeOffset) ||
                   type == typeof(TimeSpan) ||
                   type == typeof(Guid) ||
                   (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) &&
                    IsPrimitiveType(type.GetGenericArguments()[0]));
        }
    }

    // Helper class for reference equality comparison
    public class ReferenceEqualityComparer : IEqualityComparer<object>
    {
        public static readonly ReferenceEqualityComparer Instance = new ReferenceEqualityComparer();

        public new bool Equals(object? x, object? y)
        {
            return ReferenceEquals(x, y);
        }

        public int GetHashCode(object obj)
        {
            return RuntimeHelpers.GetHashCode(obj);
        }
    }

    // Extension method for easier usage
    public static class ObjectDumperExtensions
    {
        public static string DumpToString(this object obj, string? name = null)
        {
            var dumper = new ObjectDumper();
            return dumper.Dump(obj, name ?? obj?.GetType().Name ?? "null");
        }
    }

    // Example usage and test classes
    public class BaseClass
    {
        public string? Name { get; set; }
        public int Id { get; set; }
    }

    public class DerivedClass : BaseClass
    {
        public string? Description { get; set; }
        public List<ChildClass> Children { get; set; } = new List<ChildClass>();
    }

    public class ChildClass
    {
        public string? Title { get; set; }
        public BaseClass? Parent { get; set; }
    }

    // Example usage:
    /*
    var obj = new DerivedClass
    {
        Name = "Test Object",
        Id = 123,
        Description = "A test derived class",
        Children = new List<ChildClass>
        {
            new ChildClass { Title = "Child 1" },
            new ChildClass { Title = "Child 2" }
        }
    };

    // Simple usage
    Console.WriteLine(obj.DumpToString());

    // Or with custom dumper
    var dumper = new ObjectDumper();
    Console.WriteLine(dumper.Dump(obj, "MyObject"));
    */
}
