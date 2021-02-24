﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.IO;

namespace Azure.MixedReality.ObjectAnchors.Conversion
{
    /// <summary>
    /// An extensible enum representing the filetype of the asset
    /// </summary>
    public readonly struct AssetFileType : IEquatable<AssetFileType>
    {
        private readonly string _value;
        internal const string FbxValue = ".fbx";
        internal const string GlbValue = ".glb";
        internal const string GltfValue = ".gltf";
        internal const string ObjValue = ".obj";
        internal const string PlyValue = ".ply";

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetFileType"/> struct.
        /// </summary>
        /// <param name="value">The asset file type</param>
        public AssetFileType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Returns an AssetFileType derived from the extension of a provided file name
        /// </summary>
        /// <param name="assetFilePath">The asset file name</param>
        /// <returns>The AssetFileType derived from the extension of a provided file name</returns>
        public static AssetFileType FromFilePath(string assetFilePath)
        {
            return new AssetFileType(Path.GetExtension(assetFilePath));
        }

        /// <summary>
        /// Fbx
        /// </summary>
        public static AssetFileType Fbx { get; } = new AssetFileType(FbxValue);

        /// <summary>
        /// Glb
        /// </summary>
        public static AssetFileType Glb { get; } = new AssetFileType(GlbValue);

        /// <summary>
        /// Gltf
        /// </summary>
        public static AssetFileType Gltf { get; } = new AssetFileType(GltfValue);

        /// <summary>
        /// Obj
        /// </summary>
        public static AssetFileType Obj { get; } = new AssetFileType(ObjValue);

        /// <summary>
        /// Ply
        /// </summary>
        public static AssetFileType Ply { get; } = new AssetFileType(PlyValue);

        /// <summary>
        /// Determines if two <see cref="AssetFileType"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="AssetFileType"/> to compare.</param>
        /// <param name="right">The second <see cref="AssetFileType"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(AssetFileType left, AssetFileType right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="AssetFileType"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="AssetFileType"/> to compare.</param>
        /// <param name="right">The second <see cref="AssetFileType"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(AssetFileType left, AssetFileType right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public bool Equals(AssetFileType other)
        {
            return this._value == other._value;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return obj is AssetFileType && Equals((AssetFileType)obj);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
