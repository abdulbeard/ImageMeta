using System;
using System.Collections.Generic;
using System.Text;

namespace ImageMeta
{
    public enum PropertyType
    {
        /// <summary>
        /// Specifies that Value is an array of bytes
        /// </summary>
        Bytes = 1,
        /// <summary>
        /// Specifies that Value is a null-terminated ASCII string. If you set the type data member to ASCII type, you should set the Len 
        /// property to the length of the string including the null terminator. For example, the string "Hello" would have a length of 6
        /// </summary>
        Ascii = 2,
        /// <summary>
        /// Specifies that Value is an array of unsigned short (16-bit) integers
        /// </summary>
        UShortArray = 3,
        /// <summary>
        /// Specifies that Value is an array of unsigned long (32-bit) integers
        /// </summary>
        ULongArray = 4,
        /// <summary>
        /// Specifies that Value data member is an array of pairs of unsigned long integers. Each pair represents a fraction; 
        /// the first integer is the numerator and the second integer is the denominator
        /// </summary>
        ULongFractionArray = 5,
        /// <summary>
        /// Specifies that Value is an array of bytes that can hold values of any data type
        /// </summary>
        Any = 6,
        /// <summary>
        /// Specifies that Value is an array of signed long (32-bit) integers
        /// </summary>
        LongArray = 7,
        /// <summary>
        /// Specifies that Value is an array of pairs of signed long integers. 
        /// Each pair represents a fraction; the first integer is the numerator and the second integer is the denominator
        /// </summary>
        LongFractionArray = 10
    }
}
