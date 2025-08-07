// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;

namespace OpenAI.TestFramework.Utils;

/// <summary>
/// Helpers to make accessing the many internal or private members of the Azure test framework more streamlined
/// </summary>
public static class NonPublic
{
    /// <summary>
    /// Creates an accessor for an internal, protected, or private property.
    /// </summary>
    /// <typeparam name="TObj">The type of the class that defines this property.</typeparam>
    /// <typeparam name="TProp">The type of the property.</typeparam>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>The property accessor.</returns>
    /// <exception cref="ArgumentException">If a property with that name and type could not be found.</exception>
    public static Accessor<TObj, TProp> FromProperty<TObj, TProp>(string propertyName) where TObj : class
    {
        PropertyInfo? prop = typeof(TObj).GetProperty(
            propertyName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

        if (prop == null)
        {
            throw new ArgumentException($"'{propertyName}' property could not be found in '{typeof(TObj).FullName}'");
        }
        else if (prop.PropertyType != typeof(TProp))
        {
            throw new ArgumentException($"'{propertyName}' property is not of type '{typeof(TProp).FullName}'");
        }

        Func<TObj?, TProp>? getter = null;
        Action<TObj?, TProp>? setter = null;

        MethodInfo? method = prop.GetGetMethod(true);
        if (method != null)
        {
            getter = (Func<TObj?, TProp>)method.CreateDelegate(typeof(Func<TObj?, TProp>));
        }

        method = prop.GetSetMethod(true);
        if (method != null)
        {
            setter = (Action<TObj?, TProp>)method.CreateDelegate(typeof(Action<TObj?, TProp>));
        }

        return new Accessor<TObj, TProp>(getter, setter);
    }

    /// <summary>
    /// Creates an accessory for an internal, protected, or private field.
    /// </summary>
    /// <typeparam name="TObj">The type of the class that defines this field.</typeparam>
    /// <typeparam name="TField">The type of the field.</typeparam>
    /// <param name="fieldName">The name of the field.</param>
    /// <returns>The filed accessor.</returns>
    /// <exception cref="ArgumentException">If a field with that name and type could not be found.</exception>
    public static Accessor<TObj, TField> FromField<TObj, TField>(string fieldName) where TObj : class
    {
        FieldInfo? field = typeof(TObj).GetField(
            fieldName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

        if (field == null)
        {
            throw new ArgumentException($"'{fieldName}' field could not be found in '{typeof(TObj).FullName}'");
        }
        else if (field.FieldType != typeof(TField))
        {
            throw new ArgumentException($"'{fieldName}' field is not of type '{typeof(TField).FullName}'");
        }

        Func<TObj?, TField> getter = (instance) => (TField)field.GetValue(instance)!;
        Action<TObj?, TField>? setter = (instance, val) => field.SetValue(instance, val);

        return new Accessor<TObj, TField>(getter, setter);
    }

    /// <summary>
    /// Creates a delegate from an internal, protected, or private parameterless method.
    /// </summary>
    /// <typeparam name="TObj">The type of the class that defines this method.</typeparam>
    /// <typeparam name="TRet">The return type of the method.</typeparam>
    /// <param name="methodName">The name of the method.</param>
    /// <returns>The function delegate that can be used to access the method.</returns>
    /// <exception cref="ArgumentException">If no method could be found with the specified name and signature.</exception>
    public static Func<TObj, TRet> FromMethod<TObj, TRet>(string methodName) where TObj : class
    {
        MethodInfo? method = GetMethod<TObj, TRet>(methodName, []);
        return (Func<TObj, TRet>)method.CreateDelegate(typeof(Func<TObj, TRet>));
    }

    /// <summary>
    /// Creates a delegate from an internal, protected, or private parameterless method.
    /// </summary>
    /// <typeparam name="TObj">The type of the class that defines this method.</typeparam>
    /// <typeparam name="TArg">The type of the first method argument.</typeparam>
    /// <typeparam name="TRet">The return type of the method.</typeparam>
    /// <param name="methodName">The name of the method.</param>
    /// <returns>The function delegate that can be used to access the method.</returns>
    /// <exception cref="ArgumentException">If no method could be found with the specified name and signature.</exception>
    public static Func<TObj, TArg, TRet> FromMethod<TObj, TArg, TRet>(string methodName) where TObj : class
    {
        MethodInfo method = GetMethod<TObj, TRet>(methodName, [typeof(TArg)]);
        return (Func<TObj, TArg, TRet>)method.CreateDelegate(typeof(Func<TObj, TArg, TRet>));
    }

    private static MethodInfo GetMethod<TObj, TRet>(string methodName, Type[] argTypes)
    {
        MethodInfo? method = typeof(TObj).GetMethod(
            methodName,
            BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance,
            null,
            argTypes,
            null)!;

        if (method == null)
        {
            throw new ArgumentException($"'{methodName}' method could not be found in '{typeof(TObj).FullName}'");
        }
        else if (!typeof(TRet).IsAssignableFrom(method.ReturnType))
        {
            throw new ArgumentException($"'{methodName}' method does not return '{typeof(TRet).FullName}'");
        }

        return method;
    }

    /// <summary>
    /// The accessor struct that makes accessing internal, protected, or private properties/fields easier.
    /// </summary>
    /// <typeparam name="TObj">The type of the class that defines this field.</typeparam>
    /// <typeparam name="TValue">Tye type of the property/field.</typeparam>
    public readonly struct Accessor<TObj, TValue> where TObj : class
    {
        private readonly Func<TObj?, TValue> _getter;
        private readonly Action<TObj?, TValue> _setter;

        public Accessor(Func<TObj?, TValue>? getter, Action<TObj?, TValue>? setter)
        {
            HasGet = getter != null;
            _getter = getter ?? (_ => throw new InvalidOperationException("Get is not supported"));
            HasSet = setter != null;
            _setter = setter ?? ((_, __) => throw new InvalidOperationException("Set is not supported"));
        }

        /// <summary>
        /// True if we can read the value of the property/field.
        /// </summary>
        public bool HasGet { get; }

        /// <summary>
        /// True if we can set the value of the property/field.
        /// </summary>
        public bool HasSet { get; }

        /// <summary>
        /// Gets the value of the property/field.
        /// </summary>
        /// <param name="instance">The instance to get the value from. Can be null for static properties/fields.</param>
        /// <returns>The value of the property/field.</returns>
        public TValue Get(TObj? instance) => _getter(instance);

        /// <summary>
        /// Sets the value of the property/field.
        /// </summary>
        /// <param name="instance">The instance to set the value on. Can be null for static properties/fields.</param>
        /// <param name="value">The value to set.</param>
        public void Set(TObj? instance, TValue value) => _setter(instance, value);
    }
}
