// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs.Host.Bindings;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs
{
    // Core converter. 
    // The converter may be async. For example,  Stream --> String converter may need to read the contents. 
    public delegate Task<object> FuncAsyncConverter(object src, Attribute attribute, ValueBindingContext context);

    // A strongly typed version of FuncAsyncConverter
    public delegate Task<TDestination> FuncAsyncConverter<TSource, TDestination>(TSource src, Attribute attribute, ValueBindingContext context);
        
    // Build a converter given specific types.
    // This is used by the converter manager, which is responsible to match the incoming types and only invoke
    // this delegate if it was registered to handle these types.
    // This is primarily reflection operations to create a specialized converter instance, 
    // but it does not actually do the conversions. Therefore, this is not async and should not need to do any IO. 
    public delegate FuncAsyncConverter FuncConverterBuilder(Type typeSource, Type typeDest);
}