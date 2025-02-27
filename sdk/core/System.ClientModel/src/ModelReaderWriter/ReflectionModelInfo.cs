// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Primitives;

internal class ReflectionModelInfo : ModelInfo
{
    private Type _type;

    public ReflectionModelInfo(Type type)
    {
        _type = type;
    }

    //This will be replaced with RequiresUnreferencedCode when this issue is fixed https://github.com/Azure/azure-sdk-for-net/issues/48294
    [UnconditionalSuppressMessage("Trimming", "IL2067",
      Justification = "We will only call this when we went through ModelReaderWriter.Read which has DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors).")]
    public override object CreateObject()
    {
        return GetInstance(_type);
    }

    private static IPersistableModel<object> GetInstance([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type returnType)
    {
        var model = GetObjectInstance(returnType) as IPersistableModel<object>;
        if (model is null)
        {
            throw new InvalidOperationException($"{returnType.Name} does not implement {nameof(IPersistableModel<object>)}");
        }
        return model;
    }

    private static object GetObjectInstance([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type returnType)
    {
        PersistableModelProxyAttribute? attribute = Attribute.GetCustomAttribute(returnType, typeof(PersistableModelProxyAttribute), false) as PersistableModelProxyAttribute;
        Type typeToActivate = attribute is null ? returnType : attribute.ProxyType;

        if (returnType.IsAbstract && attribute is null)
        {
            throw new InvalidOperationException($"{returnType.Name} must be decorated with {nameof(PersistableModelProxyAttribute)} to be used with {nameof(ModelReaderWriter)}");
        }

        var obj = Activator.CreateInstance(typeToActivate, true);
        if (obj is null)
        {
            //we should never get here, but just in case
            throw new InvalidOperationException($"Unable to create instance of {typeToActivate.Name}.");
        }

        return obj;
    }
}
