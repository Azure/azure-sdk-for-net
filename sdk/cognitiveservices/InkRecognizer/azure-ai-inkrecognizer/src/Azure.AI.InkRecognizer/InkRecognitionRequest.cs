// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.Json;

//namespace Azure.AI.InkRecognizer
namespace Azure.Data.InkRecognizer
{
    public class InkRecognitionRequest
    {
        private ApplicationKind _applicationType { get; set; }

        private string _language { get; set; }

        private InkPointUnit _inkPointUnit { get; set; }

        private float _unitMultiple { get; set; }

        private IEnumerable<InkStroke> _strokes { get; set; }

        internal InkRecognitionRequest(IEnumerable<InkStroke> strokes,
            ApplicationKind applicationType,
            string language,
            InkPointUnit inkPointUnit,
            float unitMultiple)
        {
            _strokes = strokes;
            _applicationType = applicationType;
            _language = language;
            _inkPointUnit = inkPointUnit;
            _unitMultiple = unitMultiple;
        }

        internal string ToJson()
        {
            MemoryStream jsonStream = new MemoryStream();
            var jsonWriter = new Utf8JsonWriter(jsonStream);

            jsonWriter.WriteStartObject();

            jsonWriter.WriteString("applicationType", _getApplicationTypeString());
            jsonWriter.WriteString("language", _language);
            jsonWriter.WriteString("unit", _getInkPointUnitString());
            jsonWriter.WriteNumber("unitMultiple", _unitMultiple);

            jsonWriter.WriteStartArray("strokes");
            foreach (var stroke in _strokes)
            {
                jsonWriter.WriteStartObject();
                jsonWriter.WriteNumber("id", stroke.Id);
                if (stroke.Kind != InkStrokeKind.Unknown)
                {
                    jsonWriter.WriteString("kind", GetStrokeKindString(stroke.Kind));
                }

                jsonWriter.WriteStartArray("points");
                foreach (var point in stroke.GetInkPoints())
                {
                    jsonWriter.WriteStartObject();
                    jsonWriter.WriteNumber("x", point.X);
                    jsonWriter.WriteNumber("y", point.Y);
                    jsonWriter.WriteEndObject();
                }
                jsonWriter.WriteEndArray();

                if (stroke.Language != null)
                {
                    jsonWriter.WriteString("language", stroke.Language);
                }
                jsonWriter.WriteEndObject();
            }
            jsonWriter.WriteEndArray();

            jsonWriter.WriteEndObject();
            jsonWriter.Flush();
            return Encoding.UTF8.GetString(jsonStream.ToArray());
        }

        private string _getInkPointUnitString()
        {
            switch (_inkPointUnit)
            {
                case InkPointUnit.Inch:
                    return "in";
                case InkPointUnit.Cm:
                    return "cm";
                case InkPointUnit.Mm:
                    return "mm";
                default:
                    throw new InvalidEnumArgumentException("Invalid value for InkPointUnit");
            }
        }

        private string _getApplicationTypeString()
        {
            switch (_applicationType)
            {
                case ApplicationKind.Writing:
                    return "writing";
                case ApplicationKind.Drawing:
                    return "drawing";
                case ApplicationKind.Mixed:
                    return "mixed";
                default:
                    throw new InvalidEnumArgumentException("Invalid value for ApplicationKind");
            }
        }

        private static string GetStrokeKindString(InkStrokeKind strokeKind)
        {
            switch (strokeKind)
            {
                case InkStrokeKind.InkWriting:
                    return "inkWriting";
                case InkStrokeKind.InkDrawing:
                    return "inkDrawing";
                default:
                    throw new InvalidEnumArgumentException("Invalid value for Stroke Kind");
            }
        }
    }
}
