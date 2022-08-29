using System;

#pragma warning disable CA1062

namespace LookingForArrayElementsRecursion
{
    public static class FloatCounter
    {
        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (rangeStart is null)
            {
                throw new ArgumentNullException(nameof(rangeStart));
            }

            if (rangeEnd is null)
            {
                throw new ArgumentNullException(nameof(rangeEnd));
            }

            if (rangeEnd.Length != rangeStart.Length)
            {
                throw new ArgumentException("different size");
            }

            float Sum(float[] arr)
            {
                if (arr is null)
                {
                    throw new ArgumentNullException(nameof(arr));
                }

                float sum = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    sum += arr[i];
                }

                return sum;
            }

            if (Sum(rangeStart) > Sum(rangeEnd))
            {
                throw new ArgumentException("Range start value is greater than the range end value.");
            }

            if (arrayToSearch.Length == 0 || rangeStart.Length == 0 || rangeEnd.Length == 0)
            {
                return 0;
            }

            return LookFloats(arrayToSearch, rangeStart, rangeEnd, 0, 0, arrayToSearch.Length);
        }

        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd, int startIndex, int count)
        {
            float Sum(float[] arr)
            {
                if (arr is null)
                {
                    throw new ArgumentNullException(nameof(arr));
                }

                float sum = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    sum += arr[i];
                }

                return sum;
            }

            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (rangeStart is null)
            {
                throw new ArgumentNullException(nameof(rangeStart));
            }

            if (rangeEnd is null)
            {
                throw new ArgumentNullException(nameof(rangeStart));
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException("Range starts and range ends contain different number of elements.");
            }

            if (Sum(rangeStart) > Sum(rangeEnd))
            {
                throw new ArgumentException("Range start value is greater than the range end value.");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (startIndex + count > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException($"{startIndex}");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (count == 0 || rangeStart.Length == 0 || arrayToSearch.Length == 0 || rangeEnd.Length == 0)
            {
                return 0;
            }

            return LookFloats(arrayToSearch, rangeStart, rangeEnd, startIndex, 0, count + startIndex);
        }

        public static int LookFloats(float[] arrayToSearch, float[] rangestart, float[] rangeEnd, int i, int j, int length, int count = 0)
        {
            if (arrayToSearch[i] >= rangestart[j] && arrayToSearch[i] <= rangeEnd[j])
            {
                count++;
            }

            if (j < rangestart.Length - 1)
            {
                return LookFloats(arrayToSearch, rangestart, rangeEnd, i, j + 1, length, count);
            }

            if (i == length - 1 && j == rangestart.Length - 1)
            {
                return count;
            }

            return LookFloats(arrayToSearch, rangestart, rangeEnd, i + 1, 0, length, count);
        }
    }
}
