// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Xml;
using System.Xml.Linq;
using Azure.Core.Tests.ModelSerializationTests.Models;

namespace Azure.Core.Perf.Serializations
{
    public class ModelXmlModel : XmlBenchmark<ModelXml>
    {
        protected override string XmlFileName => "ModelXml.xml";

        protected override ModelXml CastFromResponse()
        {
            return (ModelXml)_response;
        }

        protected override RequestContent CastToRequestContent()
        {
            return _model;
        }

        protected override ModelXml Deserialize(XElement xmlElement)
        {
            return ModelXml.DeserializeModelXml(xmlElement, _options);
        }

        protected override void Serialize(XmlWriter writer)
        {
            _model.Serialize(writer, null);
        }
    }
}
