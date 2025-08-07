// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Primitives;

internal class ReflectionModelBuilder : ModelReaderWriterTypeBuilder
{
    private Type _type;

    protected override Type BuilderType => _type;

    public ReflectionModelBuilder(Type type)
    {
        _type = type;
    }

    //This will be replaced with RequiresUnreferencedCode when this issue is fixed https://github.com/Azure/azure-sdk-for-net/issues/48294
    [UnconditionalSuppressMessage("Trimming", "IL2077",
      Justification = "We will only call this when we went through ModelReaderWriter.Read which has DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors).")]
    protected override object CreateInstance() => GetInstance(_type);

    private static IPersistableModel<object> GetInstance(
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type returnType)
    {
        //arrays will cause Activator.CreateInstance to throw MissingMethodException which is not
        //consistent behavior with all other collection error messages so we do this extra check
        if (returnType.IsArray)
        {
            throw new InvalidOperationException($"{returnType.ToFriendlyName()} does not implement {nameof(IPersistableModel<object>)}");
        }
        //same thing with immutable and readonly collections
        if (returnType.IsGenericType)
        {
            if (returnType.Namespace?.Equals("System.Collections.Immutable") == true)
            {
                throw new InvalidOperationException($"{returnType.ToFriendlyName()} does not implement {nameof(IPersistableModel<object>)}");
            }

            var genericType = returnType.GetGenericTypeDefinition();

            if (genericType.Equals(typeof(ReadOnlyCollection<>)) || genericType.Equals(typeof(ReadOnlyDictionary<,>)))
            {
                throw new InvalidOperationException($"{returnType.ToFriendlyName()} does not implement {nameof(IPersistableModel<object>)}");
            }
        }

        var model = GetObjectInstance(returnType) as IPersistableModel<object>;
        if (model is null)
        {
            throw new InvalidOperationException($"{returnType.ToFriendlyName()} does not implement {nameof(IPersistableModel<object>)}");
        }
        return model;
    }

    private static object GetObjectInstance([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type returnType)
    {
        PersistableModelProxyAttribute? attribute = Attribute.GetCustomAttribute(returnType, typeof(PersistableModelProxyAttribute), false) as PersistableModelProxyAttribute;
        Type typeToActivate = attribute is null ? returnType : attribute.ProxyType;

        if (returnType.IsAbstract && attribute is null)
        {
            throw new InvalidOperationException($"{returnType.ToFriendlyName()} must be decorated with {nameof(PersistableModelProxyAttribute)} to be used with {nameof(ModelReaderWriter)}");
        }

        var obj = Activator.CreateInstance(typeToActivate, true);
        if (obj is null)
        {
            //we should never get here, but just in case
            throw new InvalidOperationException($"Unable to create instance of {typeToActivate.ToFriendlyName()}.");
        }

        return obj;
    }
}
