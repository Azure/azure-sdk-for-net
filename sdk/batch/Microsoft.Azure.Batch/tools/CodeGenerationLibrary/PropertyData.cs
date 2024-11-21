// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace CodeGenerationLibrary
{
    using System.Linq;

    //TODO: It might be clearer to refactor this class into two classes, one that is JUST the serialization entity,
    //TODO: and the other which provides all of the extension methods/helpers (and possibly gives a better user experience)
    public class PropertyData
    {
        /// <summary>
        /// Gets or sets the type of the property.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the name of the property in the object model.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the camel name of the property.
        /// </summary>
        public string CamelName => StringUtilities.ToCamelCase(this.Name);

        /// <summary>
        /// Gets the name of the property to use in the property container.
        /// </summary>
        public string PropertyContainerPropertyName => this.Name + "Property";

        /// <summary>
        /// Gets or sets the summary comment for the property.
        /// </summary>
        public string SummaryComment { get; set; }

        /// <summary>
        /// Gets the full summary comment for use on the property itself (includes a "gets or sets" in front of the property
        /// is settable, or a "gets" if the property is not settable.
        /// </summary>
        public string FullSummaryComment
        {
            get
            {
                string prefix = "Gets ";
                if (this.HasPublicSetter)
                {
                    prefix += "or sets ";
                }

                string result = prefix + StringUtilities.ToCamelCase(this.SummaryComment);
                return result;
            }
        }

        /// <summary>
        /// Gets or sets the remarks comment for the property.
        /// </summary>
        public string RemarksComment { get; set; }

        /// <summary>
        /// Gets or sets the access allowed when the property is bound.
        /// </summary>
        public BindingAccess BoundAccess { get; set; }

        /// <summary>
        /// Gets or sets the access allowed when the property is unbound.
        /// </summary>
        public BindingAccess UnboundAccess { get; set; }

        /// <summary>
        /// Gets a value indicating if this property is writable.
        /// </summary>
        public bool IsWritable => this.BoundAccess.HasFlag(BindingAccess.Write) ||
                                  this.UnboundAccess.HasFlag(BindingAccess.Write);

        /// <summary>
        /// Gets a value indicating if this property can be serialized to the server.
        /// </summary>
        public bool CanSerializeToServer => this.IsWritable && !this.IsClientOnly;

        /// <summary>
        /// Gets a value indicating if this property has a public setter.
        /// </summary>
        public bool HasPublicSetter => this.IsWritable && !this.HideSetter;

        /// <summary>
        /// Sets whether the setter should be hidden (private).
        /// </summary>
        public bool HideSetter { private get; set; }

        /// <summary>
        /// Gets or sets if the property should live outside of the default property container.
        /// </summary>
        /// <remarks>
        /// Properties which have this specified persist statically across Refresh().
        /// </remarks>
        //TODO: This should implicitly set IsClientOnly?
        public bool IsOutsidePropertyContainer { get; set; }

        /// <summary>
        /// Gets or sets if the property should just be defined, and not assigned to in the generated constructors.
        /// </summary>
        /// <remarks>
        /// This is useful for example for properties such as BaseBehaviors, which we would like to autogenerate but
        /// which are assigned to in a special fashion.
        /// </remarks>
        public bool SkipPropertyAssignment { get; set; }

        /// <summary>
        /// Gets or sets the name of the conversion method which turns an object model object into a protocol object.
        /// </summary>
        /// <remarks>
        /// By default this is null, which means use the default conversion method name.
        /// </remarks>
        public string ObjectModelToProtocolMethod { get; set; }

        /// <summary>
        /// Gets if this has a custom conversion method for converting object model types to protocol types.
        /// </summary>
        public bool HasObjectModelToProtocolMethod => !string.IsNullOrEmpty(this.ObjectModelToProtocolMethod);

        /// <summary>
        /// Gets or sets the name of the conversion method which turns a protocol object into an object model object.
        /// </summary>
        /// <remarks>
        /// By default this is null, which means use the default conversion method name.
        /// </remarks>
        public string ProtocolToObjectModelMethod { get; set; }

        /// <summary>
        /// Gets if this has a custom conversion method for converting protocol types to object model types.
        /// </summary>
        public bool HasProtocolToObjectModelMethod => !string.IsNullOrEmpty(this.ProtocolToObjectModelMethod);

        /// <summary>
        /// Gets or sets an additional property statement to be included at the end of all constructors.
        /// </summary>
        public string AdditionalPropertyInitializationStatement { get; set; }

        /// <summary>
        /// Gets or sets the constructor argument type.
        /// </summary>
        public ConstructorArgumentType ConstructorArgumentType { get; set; }

        /// <summary>
        /// Gets or sets of this property is client only. A client only property cannot be serialized to or from the server.
        /// </summary>
        public bool IsClientOnly { get; set; }

        /// <summary>
        /// Gets if the type is a collection.
        /// </summary>
        //TODO: Kinda hacky
        public bool IsTypeCollection => this.Type.Contains("IList") ||
                                        this.Type.Contains("IEnumerable") ||
                                        this.Type.Contains("List") ||
                                        this.Type.Contains("Dictionary") ||
                                        this.Type.Contains("IDictionary") ||
                                        this.Type.Contains("IReadOnlyList");

        /// <summary>
        /// Gets if the type is a collection.
        /// </summary>
        //TODO: Kinda hacky
        public bool IsDictionary =>     this.Type.Contains("Dictionary") ||
                                        this.Type.Contains("IDictionary");

        /// <summary>
        /// Gets the generic type parameter of this property.
        /// </summary>
        /// <value>The generic type parameter.</value>
        public string GenericTypeParameter
        {
            get
            {
                int startIndex = this.Type.IndexOf("<") + 1;
                return this.Type.Substring(
                    startIndex,
                    this.Type.LastIndexOf(">") - startIndex);
            }
        }

        /// <summary>
        /// Gets if this properties type is nullable.
        /// </summary>
        public bool IsTypeNullable => this.Type != null && this.Type.Last() == '?'; //TODO: Kinda hacky

        public string GetCollectionSetterString()
        {
            string result = "ConcurrentChangeTrackedModifiableList<" + this.GenericTypeParameter + ">.TransformEnumerableToConcurrentModifiableList(value)";

            if (!CodeGenerationUtilities.IsTypeComplex(GenericTypeParameter))
            {
                result = $"ConcurrentChangeTrackedList<{this.GenericTypeParameter}>.TransformEnumerableToConcurrentList(value)";
            }

            //TODO: For now this handles the FileStaging which is the only client only property
            //TODO: Need a better way to determine if a type is an enum
            if (this.IsClientOnly || this.GenericTypeParameter.StartsWith("Common"))
            {
                result = "ConcurrentChangeTrackedList<" + this.GenericTypeParameter + ">.TransformEnumerableToConcurrentList(value)";
            }

            return result;
        }
    }
}
