// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Xml;
using System.Xml.Linq;
using Azure.Messaging.ServiceBus.Diagnostics;

namespace Azure.Messaging.ServiceBus.Management
{
    internal class XmlObjectConvertor
    {
        internal static object ParseValueObject(XElement element)
        {
            var serializedPrefix = element.GetPrefixOfNamespace(XNamespace.Get(ManagementClientConstants.SerializationNamespace));
            var type = element.Attribute(XName.Get("type", ManagementClientConstants.XmlSchemaInstanceNamespace)).Value;

            if (!string.IsNullOrEmpty(serializedPrefix))
            {
                if (type.Substring(serializedPrefix.Length + 1) == "duration")
                {
                    return XmlConvert.ToTimeSpan(element.Value);
                }
            }

            var prefix = element.GetPrefixOfNamespace(XNamespace.Get(ManagementClientConstants.XmlSchemaNamespace));
            if (string.IsNullOrWhiteSpace(prefix))
            {
                return element.Value;
            }

            switch (type.Substring(prefix.Length + 1))
            {
                case "string":
                    return element.Value;
                case "int":
                    return XmlConvert.ToInt32(element.Value);
                case "long":
                    return XmlConvert.ToInt64(element.Value);
                case "boolean":
                    return XmlConvert.ToBoolean(element.Value);
                case "double":
                    return XmlConvert.ToDouble(element.Value);
                case "dateTime":
                    return XmlConvert.ToDateTime(element.Value, XmlDateTimeSerializationMode.Utc);
                case "duration":
                    return XmlConvert.ToTimeSpan(element.Value);
                default:
                    ServiceBusEventSource.Log.ManagementSerializationException(
                            $"{nameof(XmlObjectConvertor)}_{nameof(ParseValueObject)}",
                            element.ToString());
                    return element.Value;
            }
        }

        internal static XElement SerializeObject(object value)
        {
            var prefix = "l28";
            string type = prefix + ':';
            if (value is string)
            {
                type += "string";
            }
            else if (value is int)
            {
                type += "int";
            }
            else if (value is long)
            {
                type += "long";
            }
            else if (value is bool)
            {
                type += "boolean";
            }
            else if (value is double)
            {
                type += "double";
            }
            else if (value is DateTime)
            {
                type += "dateTime";
            }
            else if (value is TimeSpan)
            {
                type += "duration";
            }
            else
            {
                var unknownType = value.GetType().Name;
                ServiceBusEventSource.Log.ManagementSerializationException(
                            $"{nameof(XmlObjectConvertor)}_{nameof(SerializeObject)}",
                            unknownType);

                throw new ServiceBusException(false, "Object is not of supported type: " + unknownType + ". " +
                    "Only following types are supported through HTTP: string,int,long,bool,double,DateTime");
            }

            var element = new XElement(XName.Get("Value", ManagementClientConstants.ServiceBusNamespace),
                new XAttribute(XName.Get("type", ManagementClientConstants.XmlSchemaInstanceNamespace), type),
                new XAttribute(XNamespace.Xmlns + prefix, ManagementClientConstants.XmlSchemaNamespace),
                value);

            return element;
        }
    }
}
