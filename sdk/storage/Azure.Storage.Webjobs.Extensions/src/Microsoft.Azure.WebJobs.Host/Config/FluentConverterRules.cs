// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using System.Threading;

namespace Microsoft.Azure.WebJobs.Host.Config
{
    /// <summary>
    /// Expose fluent APIs for adding converters.  This can apply to either:    
    ///  1. globally for all attributes - in which case it's called from <see cref="ExtensionConfigContext"/> and TAttribute is System.Attribute.
    ///  2. a specific attribute - in which case it's called from <see cref="FluentBindingRule{TAttribute}"/> 
    /// </summary>
    /// <typeparam name="TAttribute">The attribute type this applies to. Literally <see cref="Attribute"/> if it applies to all attributes.</typeparam>
    /// <typeparam name="TThis">For fluent API, the type to return</typeparam>
    [Obsolete("Not ready for public consumption.")]
    public abstract class FluentConverterRules<TAttribute, TThis> where TAttribute : Attribute
    {
        // Access the converter manager that we're adding rules to. 
        internal abstract ConverterManager ConverterManager { get; }

        /// <summary>
        /// Add basic converter
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public TThis AddConverter<TSource, TDestination>(Func<TSource, TDestination> func)
        {
            VerifyNotOpenTypes<TSource, TDestination>();

            // The converter is implicitly for this TAttribute even though it doesn't need an attribute parameter. 
            var pm = PatternMatcher.New(func);
            this.AddConverterBuilder<TSource, TDestination>(pm);

            return (TThis)(object)this;
        }

        /// <summary>
        /// Add converter that uses the control attribute. 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public TThis AddConverter<TSource, TDestination>(Func<TSource, TAttribute, TDestination> func)
        {
            VerifyNotOpenTypes<TSource, TDestination>();

            var pm = PatternMatcher.New(func);
            this.AddConverterBuilder<TSource, TDestination>(pm);

            return (TThis)(object)this;
        }

        /// <summary>
        /// Add converter that uses the control attribute. 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public TThis AddConverter<TSource, TDestination>(Func<TSource, CancellationToken, Task<TDestination>> func)
        {
            VerifyNotOpenTypes<TSource, TDestination>();

            var pm = PatternMatcher.New(func);
            this.AddConverterBuilder<TSource, TDestination>(pm);

            return (TThis)(object)this;
        }

        /// <summary>
        /// Add converter that uses the control attribute. 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public TThis AddConverter<TSource, TDestination>(FuncAsyncConverter<TSource, TDestination> func)
        {
            VerifyNotOpenTypes<TSource, TDestination>();

            var pm = PatternMatcher.New(func);
            this.AddConverterBuilder<TSource, TDestination>(pm);

            return (TThis)(object)this;
        }

        /// <summary>
        /// Add a converter that that uses open types. 
        /// Src type must handle object since it could be unknown.
        /// But it's converting to a well-known destination type. 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public TThis AddOpenConverter<TSource, TDestination>(FuncAsyncConverter func)
        {
            var pm = PatternMatcher.New(func);
            this.AddConverterBuilder<TSource, TDestination>(pm);

            return (TThis)(object)this;
        }

        /// <summary>
        /// Add a converter for the given Source to Destination conversion.
        /// The typeConverter type is instantiated with the type arguments and constructorArgs is passed. 
        /// </summary>
        /// <typeparam name="TSource">Source type.</typeparam>
        /// <typeparam name="TDestination">Destination type.</typeparam>
        /// <param name="typeConverter">A type with conversion methods. This can be generic and will get instantiated with the 
        /// appropriate type parameters. </param>
        /// <param name="constructorArgs">Constructor Arguments to pass to the constructor when instantiated. This can pass configuration and state.</param>
        public TThis AddOpenConverter<TSource, TDestination>(            
            Type typeConverter,
            params object[] constructorArgs)
        {
            var patternMatcher = PatternMatcher.New(typeConverter, constructorArgs);
            return AddConverterBuilder<TSource, TDestination>(patternMatcher);
        }

        /// <summary>
        /// Add a converter for the given Source to Destination conversion.
        /// </summary>
        /// <typeparam name="TSource">Source type.</typeparam>
        /// <typeparam name="TDestination">Destination type.</typeparam>
        /// <param name="converterInstance">Instance of an object with convert methods on it.</param>
        public TThis AddConverter<TSource, TDestination>(
          IConverter<TSource, TDestination> converterInstance)
        {
            VerifyNotOpenTypes<TSource, TDestination>();

            var patternMatcher = PatternMatcher.New(converterInstance);
            return AddConverterBuilder<TSource, TDestination>(patternMatcher);
        }

        /// <summary>
        /// Add a converter for the given Source to Destination conversion.
        /// </summary>
        /// <typeparam name="TSource">Source type.</typeparam>
        /// <typeparam name="TDestination">Destination type.</typeparam>
        /// <param name="converterInstance">Instance of an object with convert methods on it.</param>
        public TThis AddConverter<TSource, TDestination>(
          IAsyncConverter<TSource, TDestination> converterInstance)
        {
            VerifyNotOpenTypes<TSource, TDestination>();

            var patternMatcher = PatternMatcher.New(converterInstance);
            return AddConverterBuilder<TSource, TDestination>(patternMatcher);
        }

        private TThis AddConverterBuilder<TSource, TDestination>(          
          PatternMatcher patternMatcher)
        {
            var builder = patternMatcher.GetBuilder();
            this.ConverterManager.AddConverter<TSource, TDestination, TAttribute>(builder);
                
            return (TThis)(object)this;
        }

        // Helper for enforcing  that a delegate can only handle concrete types, not open types.
        static void VerifyNotOpenTypes<T1, T2>()
        {
            if (OpenType.IsOpenType<T1>() || OpenType.IsOpenType<T2>())
            {
                throw new InvalidOperationException($"Use AddOpenConverter to add a converter for open types.");
            }
            if (typeof(T1) == typeof(T2))
            {
                throw new InvalidOperationException($"Converter source and desitnation types must be different (${typeof(T1).Name}).");
            }
        }
    }
}
