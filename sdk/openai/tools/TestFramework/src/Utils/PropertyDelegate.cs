// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework.Utils;

/// <summary>
/// Represents a delegate for getting and setting property values.
/// </summary>
/// <typeparam name="TVal">The type of the property value.</typeparam>
public struct PropertyDelegate<TVal>
{
    private Func<TVal>? _getter;
    private Action<TVal>? _setter;

    /// <summary>
    /// Initializes a new instance of the <see cref="PropertyDelegate{TVal}"/> struct.
    /// </summary>
    /// <param name="getter">The delegate used to get the property value.</param>
    /// <param name="setter">The delegate used to set the property value.</param>
    public PropertyDelegate(Func<TVal> getter, Action<TVal> setter)
    {
        _getter = getter ?? throw new ArgumentNullException(nameof(getter));
        _setter = setter ?? throw new ArgumentNullException(nameof(setter));
    }

    /// <summary>
    /// Gets the value of the property.
    /// </summary>
    /// <returns>The value of the property.</returns>
    public TVal GetValue()
    {
        if (_getter != null)
            return _getter();
        else
            throw new InvalidOperationException("No getter was set");
    }

    /// <summary>
    /// Sets the value of the property.
    /// </summary>
    /// <param name="val">The value to set.</param>
    public void SetValue(TVal val)
    {
        if (_setter != null)
            _setter(val);
        else
            throw new InvalidOperationException("No setter was set");
    }
}
