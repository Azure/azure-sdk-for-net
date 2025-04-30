// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Primitives;

[RequiresUnreferencedCode("This method uses reflection use the overload that takes a ModelReaderWriterContext to be AOT compatible.")]
internal class ReflectionModelBuilder : ModelReaderWriterTypeBuilder
{
    private Type _type;

    protected override Type BuilderType => _type;

    public ReflectionModelBuilder(Type type)
    {
        _type = type;
    }

    protected override object CreateInstance() => GetInstance(_type);

    private static IPersistableModel<object> GetInstance(Type returnType)
    {
        var model = GetObjectInstance(returnType) as IPersistableModel<object>;
        if (model is null)
        {
            throw new InvalidOperationException($"{returnType.ToFriendlyName()} does not implement {nameof(IPersistableModel<object>)}");
        }
        return model;
    }

    private static object GetObjectInstance(Type returnType)
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
