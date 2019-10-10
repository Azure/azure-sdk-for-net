// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.AI.InkRecognizer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteTakerUWP
{
    // <OutputWriterImplementations>
    public class OutputWriter
    {
        // <PrintWords>
        public static string PrintWords(RecognitionRoot root)
        {
            var words = root.GetWords();
            return PrintRecoUnits(root, words);
        }
        // </PrintWords>

        // <PrintShapes>
        public static string PrintShapes(RecognitionRoot root)
        {
            var shapes = root.GetDrawings();
            return PrintRecoUnits(root, shapes);
        }
        // </PrintShapes>

        // <Print>
        public static string Print(RecognitionRoot root)
        {
            var output = new StringBuilder();
            output.Append(PrintWords(root));
            output.Append(PrintShapes(root));
            return output.ToString();
        }
        // </Print>

        // <PrintError>
        public static string PrintError(string errMsg)
        {
            return String.Format("ERROR: {0}", errMsg);
        }
        // </PrintError>

        // <PrintRecoUnits>
        private static string PrintRecoUnits(RecognitionRoot root, IEnumerable<InkRecognitionUnit> recoUnits)
        {
            var recognizedText = new StringBuilder();
            foreach (var recoUnit in recoUnits)
            {
                switch (recoUnit.Kind)
                {
                    case InkRecognitionUnitKind.InkWord:
                        var word = recoUnit as InkWord;
                        recognizedText.Append(word.RecognizedText).Append(" ");
                        break;

                    case InkRecognitionUnitKind.InkDrawing:
                        var shape = recoUnit as InkDrawing;
                        var shapeKind = String.Format("[{0}] ", shape.RecognizedShape);
                        recognizedText.Append(shapeKind);
                        break;

                    case InkRecognitionUnitKind.InkBullet:
                        var bullet = recoUnit as InkBullet;
                        recognizedText.Append(bullet.RecognizedText);
                        break;
                }
            }
            return recognizedText.ToString();
        }
        // </PrintRecoUnits>
    }
    // </OutputWriterImplementations>
}
