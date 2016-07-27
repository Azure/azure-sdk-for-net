﻿namespace Azure.Batch.Unit.Tests.TestUtilities
{
    using System;
    using System.Reflection;

    public static class ReflectionHelpers
    {
        public static object InvokeMethodWithDefaultArguments(MethodInfo method, object objectInstance, Func<ParameterInfo, object> objectCreationFunc = null)
        {
            //Build a parameter array
            ParameterInfo[] parameters = method.GetParameters();
            object[] parameterObjects = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                ParameterInfo parameter = parameters[i];
                object parameterObject;
                if (objectCreationFunc != null)
                {
                    parameterObject = objectCreationFunc(parameter);
                }
                else
                {
                    if (parameter.ParameterType.IsValueType)
                    {
                        parameterObject = Activator.CreateInstance(parameter.ParameterType);
                    }
                    //Default to null if there is no special handling required
                    else
                    {
                        parameterObject = null;
                    }
                }

                parameterObjects[i] = parameterObject;
            }

            return method.Invoke(objectInstance, parameterObjects);
        }
    }
}
