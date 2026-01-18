using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace Soenneker.Extensions.Arrays.Strings;

/// <summary>
/// A collection of helpful string array extension methods
/// </summary>
public static class StringArrayExtension
{
    /// <summary>
    /// Determines whether any element in the specified array contains the given substring, using the specified string
    /// comparison option.
    /// </summary>
    /// <remarks>If the array is empty, or if all elements are null, the method returns false. The search uses
    /// the specified StringComparison option for each element.</remarks>
    /// <param name="arr">The array of strings to search. Elements may be null.</param>
    /// <param name="part">The substring to seek within each array element. Cannot be null.</param>
    /// <param name="comparison">One of the enumeration values that specifies the rules for the search, such as case sensitivity and culture.</param>
    /// <returns>true if at least one non-null element in the array contains the specified substring; otherwise, false.</returns>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAPart(string[] arr, string part, StringComparison comparison)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            string? current = arr[i];

            if (current is not null && current.IndexOf(part, comparison) >= 0)
                return true;
        }

        return false;
    }
}
