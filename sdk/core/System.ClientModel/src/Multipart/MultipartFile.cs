// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives
{
    public class MultipartFile
    {
        public string ContentType { get; } = "application/octet-stream";
        public string? FileName { get; }
        public BinaryData? Content { get; }
        public string? FilePath { get; }

        public MultipartFile(BinaryData content)
        {
            Content = content;
        }
        public MultipartFile(string filePath)
        {
            FilePath = filePath;
        }
        public MultipartFile(BinaryData content, string contentType) : this(content)
        {
            ContentType = contentType;
        }
        public MultipartFile(string filePath, string contentType) : this(filePath)
        {
            ContentType = contentType;
        }
        public MultipartFile(BinaryData content, string contentType, string fileName) : this(content, contentType)
        {
            FileName = fileName;
        }
        public MultipartFile(string filePath, string contentType, string fileName) : this(filePath, contentType)
        {
            FileName = fileName;
        }
    }
}
