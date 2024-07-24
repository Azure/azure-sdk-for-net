using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI.TestFramework.Utils;

public static class Helpers
{
    public struct HasParameterlessConstructorConstraint<T> where T : new()
    {}

    public static Func<T> CreateWithParameterlessConstructor<T>(HasParameterlessConstructorConstraint<T> constraint = default)
        where T : new()
        => () => new();

    public static Func<T> CreateWithParameterlessConstructor<T>()
        => throw new InvalidOperationException("The type specified does not have a parameterless constructor");
}
