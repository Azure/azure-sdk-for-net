// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs
{
    // Concrete implementation of IConverterManager
    internal class ConverterManager : IConverterManager
    {
        // Exact converters are between two Exact types. 
        // These are higher precedence than "open" converters. 
        private readonly List<Entry> _exactConverters = new List<Entry>();
        private readonly List<Entry> _openConverters = new List<Entry>();

        private IEnumerable<Entry> GetEntries()
        {
            // Exact converters have precedence
            return _exactConverters.Concat(_openConverters);
        }

        public static readonly IConverterManager Identity = new IdentityConverterManager();

        public ConverterManager()
        {
            this.AddExactConverter<byte[], string>(DefaultByteArrayToString);
            this.AddExactConverter<IEnumerable<JObject>, JArray>((enumerable) => JArray.FromObject(enumerable));            
        
            this.AddExactConverter<ApplyConversion<string, Stream>, object>(async (pair, cancellationToken) =>
          {
              var text = pair.Value;
              var stream = pair.Existing;

              // Specifically use the same semantics as binding to 'TextWriter'              
              using (var writer = new StreamWriter(stream))
              {
                  cancellationToken.ThrowIfCancellationRequested();
                  await writer.WriteAsync(text);
              }
              return null;
          });

            this.AddExactConverter<ApplyConversion<byte[], Stream>, object>(async (pair, cancellationToken) =>
            {
                var bytes = pair.Value;
                var stream = pair.Existing;

                await stream.WriteAsync(bytes, 0, bytes.Length);
                return null;
            });

            this.AddExactConverter<Stream, string>(async (stream, cancellationToken) =>
            {
                using (var sr = new StreamReader(stream))
                {
                    return await sr.ReadToEndAsync();
                }
            });
            this.AddExactConverter<Stream, byte[]>(async (stream, cancellatinToken) =>
            {
                using (MemoryStream outputStream = new MemoryStream())
                {
                    const int DefaultBufferSize = 4096;
                    await stream.CopyToAsync(outputStream, DefaultBufferSize);
                    byte[] value = outputStream.ToArray();
                    return value;
                }
            });

            this.AddExactConverter<Stream, TextReader>(stream =>
            {
                return new StreamReader(stream);
            });
            this.AddExactConverter<Stream, TextWriter>(stream =>
            {
                // Default is UTF8, not write a BOM, close stream when done. 
                return new StreamWriter(stream);
            });
        }

        // If somebody registered a converter from Src-->Dest, then both those types can be used to 
        // resolve assemblies. 
        // The attribute type always points to the extension's assembly. 
        // Whereas some of the Src,Dest types will point to the resource's "native sdk"
        internal void AddAssemblies(Action<Type> funcAddType)
        {
            foreach (var entry in GetEntries())
            {
                AddType(entry.Source, funcAddType);
                AddType(entry.Dest, funcAddType);
            }
        }

        private void AddType(OpenType type, Action<Type> funcAddType)
        {
            if (type is OpenType.ExactMatch x)
            {
                funcAddType(x.ExactType);
            }
        }

        static readonly FuncAsyncConverter IdentityConverter = (src, attr, ctx) => Task.FromResult<object>(src);

        private static string DefaultByteArrayToString(byte[] bytes)
        {
            // This does not remove the BOM. 
            string str = Encoding.UTF8.GetString(bytes);
            return str;
        }

        // Get list of possible destination types given a source. 
        public OpenType[] GetPossibleDestinationTypesFromSource(Type typeAttribute, Type typeSource)
        {
            List<OpenType> typeDestinations = new List<OpenType>();
            GetPossibleDestinationTypesFromSource(typeDestinations, typeAttribute, typeSource);
            return typeDestinations.ToArray();
        }


        private void GetPossibleDestinationTypesFromSource(List<OpenType> typeDestinations, Type typeAttribute, Type typeSource)
        {
            foreach (var entry in GetEntries())
            {
                if (entry.IsMatchAttribute(typeAttribute) && entry.Source.IsMatch(typeSource))
                {
                    if (entry.Attribute.IsAssignableFrom(typeAttribute))
                    {
                        typeDestinations.Add(entry.Dest);

                        // Counterpart to the GetComposition() calls in GetConverter.
                        if (entry.Dest is OpenType.ExactMatch exactType)
                        {
                            var intermediateType = exactType.ExactType;
                            if ((intermediateType == typeof(Stream)) ||
                                (intermediateType == typeof(JObject)) ||
                                (intermediateType == typeof(IEnumerable<JObject>) ))
                            {
                                GetPossibleDestinationTypesFromSource(typeDestinations, typeAttribute, intermediateType);
                            }
                        }
                    }
                }
            }
        }

        // Get list of possible source types given a destination. 
        public OpenType[] GetPossibleSourceTypesFromDestination(Type typeAttribute, Type typeDest)
        {
            var typeSources = new List<OpenType>();

            // ConverterManager always provides this
            typeSources.Add(new OpenType.AssignableToOpenType(typeDest));

            foreach (var entry in GetEntries())
            {
                if (entry.IsMatchAttribute(typeAttribute) && entry.Dest.IsMatch(typeDest))
                {
                    if (entry.Attribute.IsAssignableFrom(typeAttribute))
                    {
                        if (entry.Source is OpenType.ExactMatch et)
                        {
                            var type = et.ExactType;
                            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ApplyConversion<,>))
                            {
                                // ApplyConversion are a form of output converter. Shouldn't show as a source type.
                                continue;
                            }
                        }

                        typeSources.Add(entry.Source);
                    }
                }
            }
       
            return typeSources.ToArray();
        }

        // Add a 'global' converter for all Attributes.
        // Passing in the cancellationToken also helps C# overload resolution determine sync. vs. async
        public void AddExactConverter<TSource, TDestination>(Func<TSource, CancellationToken, Task<TDestination>> func)
        {
            FuncAsyncConverter converter = async (src, attr, context) => await func((TSource)src, CancellationToken.None);
            FuncConverterBuilder builder = (srcType, destType) => converter;
            this.AddConverter<TSource, TDestination, System.Attribute>(builder);
        }

        public void AddExactConverter<TSource, TDestination>(Func<TSource, TDestination> func)
        {
            FuncAsyncConverter converter = (src, attr, context) => Task.FromResult<object>(func((TSource)src));
            FuncConverterBuilder builder = (srcType, destType) => converter;
            this.AddConverter<TSource, TDestination, System.Attribute>(builder);
        }

        // Add a converter for a specific attribute, TAttribute. 
        public void AddExactConverter<TSource, TDestination, TAttribute>(Func<TSource, TAttribute, TDestination> func)
                        where TAttribute : Attribute
        {
            FuncAsyncConverter converter = (src, attr, context) => Task.FromResult<object>(func((TSource)src, (TAttribute) attr));
            FuncConverterBuilder builder = (srcType, destType) => converter;
            this.AddConverter<TSource, TDestination, TAttribute>(builder);
        }

        /// <summary>
        /// Add a builder function that returns a converter. This can use <see cref="Microsoft.Azure.WebJobs.Host.Bindings.OpenType"/>  to match against an 
        /// open set of types. The builder can then do one time static type checking and code gen caching before
        /// returning a converter function that is called on each invocation. 
        /// The types passed to that converter are gauranteed to have matched against the TSource and TDestination parameters. 
        /// </summary>
        /// <typeparam name="TSource">Source type. Can be a concrete type or a <see cref="OpenType"/></typeparam>
        /// <typeparam name="TDestination">Destination type. Can be a concrete type or a <see cref="OpenType"/></typeparam>
        /// <typeparam name="TAttribute">Attribute on the binding. 
        /// If this is <see cref="System.Attribute"/>, then it applies to any attribute. 
        /// Else it applies to the specific TAttribte.</typeparam>
        /// <param name="converterBuilder">A function that is invoked if-and-only-if there is a compatible type match for the 
        /// source and destination types. It then produce a converter function that can be called many times </param>
        public void AddConverter<TSource, TDestination, TAttribute>(
            FuncConverterBuilder converterBuilder)
            where TAttribute : Attribute
        {
            var openTypeSource = OpenType.FromType<TSource>();
            var openTypeDest = OpenType.FromType<TDestination>();
          
            AddOpenConverter<TAttribute>(openTypeSource, openTypeDest, converterBuilder);
        }

        // Exact types have precedence over open-types 
        // If source nad dest match exactly, then replace. 
        private void AddOpenConverter<TAttribute>(
            OpenType source,
            OpenType dest,
            FuncConverterBuilder converterBuilder)
          where TAttribute : Attribute
        {

            // Replace existing if the keys are exactly the same.
            foreach (var entry in GetEntries())
            {
                if (entry.Attribute == typeof(TAttribute) && 
                    entry.Source.Equals(source) &&
                    entry.Dest.Equals(dest))
                {
                    entry.Builder = converterBuilder;
                    return;
                }
            }

            {
                var entry = new Entry
                {
                    Source = source,
                    Dest = dest,
                    Attribute = typeof(TAttribute),
                    Builder = converterBuilder
                };

                // Exact types are a "better match" than open types, so give them precedence.
                // Precedence is handled by having 2 separate lists. 
                if (source is OpenType.ExactMatch && dest is OpenType.ExactMatch)
                {
                    this._exactConverters.Add(entry);
                }
                else
                {
                    this._openConverters.Add(entry);
                }
            }
        }

        private FuncConverterBuilder TryGetOpenConverter(Type typeSource, Type typeDest, Type typeAttribute, IEnumerable<Entry> converters = null)
        {
            if (converters == null)
            {
                converters = GetEntries();
            }
            
            foreach (var entry in converters)
            {
                if (entry.IsMatch(typeSource, typeDest, typeAttribute))
                {
                    return entry.Builder;
                }
            }
            return null;
        }

        private FuncAsyncConverter TryGetConverter<TAttribute>(Type typeSource, Type typeDest, IEnumerable<Entry> converters = null)
        {
            var builder = TryGetOpenConverter(typeSource, typeDest, typeof(TAttribute), converters);
            if (builder == null)
            {
                return null;
            }
            var converter = builder(typeSource, typeDest);
            return converter;
        }
                
        /// <summary>
        /// Get a converter from the source to the destination, scoped for the given attribute.
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="typeSource"></param>
        /// <param name="typeDest"></param>
        /// <returns></returns>
        /// <remarks>
        /// See <seealso cref="GetPossibleSourceTypesFromDestination(Type, Type)"/> and 
        /// <seealso cref="GetPossibleDestinationTypesFromSource(Type, Type)"/> . 
        /// These functions are the inverse of this function, used to produce diagnostic messages.
        /// </remarks>
        public FuncAsyncConverter GetConverter<TAttribute>(Type typeSource, Type typeDest)
            where TAttribute : Attribute
        {
            // Give precedence to exact matches.
            // This lets callers override any other rules (like JSON binding).
            // TSrc --> TDest
            var exactMatch = TryGetConverter<TAttribute>(typeSource, typeDest, this._exactConverters);
            if (exactMatch != null)
            {
                return exactMatch;
            }

            // Inheritence (also covers idempotency)
            if (typeDest.IsAssignableFrom(typeSource))
            {
                // Skip implicit conversions to object since that's everybody's base 
                // class and BindToInput<attr,Object> would catch everything. 
                // Users can still register an explicit T-->object converter if they want to 
                // support it. 
                if (typeDest != typeof(Object))
                {
                    return IdentityConverter;
                }
            }

            // General Open converter lookup.
            // If they registered an Object-->TDest converter, that will get picked up here
            // and give them broad control over creating a TDest from anything. 
            {
                var builder = TryGetOpenConverter(typeSource, typeDest, typeof(TAttribute));
                if (builder != null)
                {
                    var converter = builder(typeSource, typeDest);
                    return converter;
                }
            }

            // Helper to treat IEnumerabe<JObject> as a JArray. 
            // TSrc --> IEnum<JObject> --> JArray
            if (typeDest == typeof(JArray))
            {
                var converter = GetComposition<TAttribute, IEnumerable<JObject>>(typeSource, typeDest);
                if (converter != null)
                {
                    return converter;
                }           
            }

            // We already matched against (string --> Dest) in the general case
            // but now allow some well-defined intermediate conversions. 
            // If this is "wrong" for your type, then it should provide an exact match to override.
            // Byte[] --[builtin]--> String --> TDest
            if (typeSource == typeof(byte[]))
            {
                var converter = GetComposition<TAttribute, string>(typeSource, typeDest);
                if (converter != null)
                {
                    return converter;
                }
            }

            // General JSON Serialization rule. 
            // Can we convert from src to dest via a JObject serialization?
            // Common example is Poco --> Jobject --> QueueMessage
            {
                var converter = GetComposition<TAttribute, JObject>(typeSource, typeDest);
                if (converter != null)
                {
                    return converter;
                }
            }

            {
                // Common for blob and stream-based systems.
                var converter = GetComposition<TAttribute, Stream>(typeSource, typeDest);
                if (converter != null)
                {
                    return converter;
                }
            }

            return null;          
        }

        // Compose via a middle type. 
        // If we have (TSrc --> X) and (X --> TDest), then support (Tsrc-->TDest) via X
        private FuncAsyncConverter GetComposition<TAttribute, TMiddle>(Type typeSource, Type typeDest)
            where TAttribute : Attribute
        {
            var first = TryGetConverter<TAttribute>(typeSource, typeof(TMiddle));
            if (first != null)
            {
                var second = TryGetConverter<TAttribute>(typeof(TMiddle), typeDest);
                if (second != null)
                {
                    // TSrc --> Jobject --> TDest
                    return async (src, attr, context) =>
                    {
                        TMiddle jobj = (TMiddle)await first(src, attr, context);
                        object obj = await second(jobj, attr, context);
                        return obj;
                    };
                }
            }
            return null;
        }

        // The Converter manager maintains a list of all converters. This may refer to an open type or an exact match. 
        // Entry for that list to describe a converter. 
        private class Entry
        {
            // Filter for what this can convert from. 
            public OpenType Source { get; set; }

            // Filter for what this can convert to. 
            public OpenType Dest { get; set; }

            // Attribute that this can apply to. 
            // If this is System.Attribute (the base class), then it will match all attributes. 
            public Type Attribute { get; set; }

            // Converter builder to invoke when we have a match. 
            public FuncConverterBuilder Builder { get; set; }

            public bool IsMatchAttribute(Type typeAttribute)
            {
                if (this.Attribute != typeof(System.Attribute))
                {
                    if (this.Attribute != typeAttribute)
                    {
                        return false;
                    }
                }
                return true;
            }

            public override string ToString()
            {
                return string.Format("{0} --> {1} (for {2})", this.Source.GetDisplayName(), this.Dest.GetDisplayName(), this.Attribute.Name);
            }

            public bool IsMatch(Type source, Type dest, Type typeAttribute)
            {
                var ctx = new OpenTypeMatchContext();

                return this.IsMatchAttribute(typeAttribute) && this.Source.IsMatch(source, ctx) && this.Dest.IsMatch(dest, ctx);
            }            
        }

        // "Empty" converter manager that only allows identity conversions. 
        // This is useful for constrained rules that don't want to operate against exact types and skip 
        // arbitrary user conversions. 
        private class IdentityConverterManager : IConverterManager
        {
            public void AddConverter<TSource, TDestination, TAttribute>(FuncConverterBuilder converterBuilder) where TAttribute : Attribute
            {
                throw new NotSupportedException("Identity converter is read-only");
            }

            FuncAsyncConverter IConverterManager.GetConverter<TAttribute>(Type typeSource, Type typeDest)
            {
                if (typeSource != typeDest)
                {
                    return null;
                }
                return IdentityConverter;
            }
        }
    } // end class ConverterManager
}