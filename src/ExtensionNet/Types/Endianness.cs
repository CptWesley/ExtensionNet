﻿using System.Diagnostics.CodeAnalysis;

namespace ExtensionNet.Types
{
    /// <summary>
    /// Enum to indicate endianness.
    /// </summary>
    [SuppressMessage("Naming", "CA1717:Only FlagsAttribute enums should have plural names", Justification = "It's not plural.")]
    public enum Endianness
    {
        /// <summary>
        /// Indicates little endian interpretation.
        /// </summary>
        LittleEndian,

        /// <summary>
        /// Indicates big endian interpretation.
        /// </summary>
        BigEndian,

        /// <summary>
        /// Indicates that the endianness of the current platform should be used.
        /// </summary>
        Current
    }
}
