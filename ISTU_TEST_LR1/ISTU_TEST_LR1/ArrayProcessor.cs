namespace ISTU_TEST_LR1;

public static class ArrayProcessor
{
    public static ArrayProcessResult ProcessArray(int[] array)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        long product = 1;

        foreach (int value in array)
        {
            product *= value;
        }

        long[] modifiedArray = new long[array.Length];
        bool hasEvenDigitOnlyNumber = false;
        int firstIndex = -1;
        int? firstValue = null;

        for (int i = 0; i < array.Length; i++)
        {
            int currentValue = array[i];

            if (IsEvenDigitOnlyNumber(currentValue))
            {
                if (!hasEvenDigitOnlyNumber)
                {
                    hasEvenDigitOnlyNumber = true;
                    firstIndex = i;
                    firstValue = currentValue;
                }

                modifiedArray[i] = product;
            }
            else
            {
                modifiedArray[i] = currentValue;
            }
        }

        return new ArrayProcessResult
        {
            HasEvenDigitOnlyNumber = hasEvenDigitOnlyNumber,
            FirstIndex = firstIndex,
            FirstValue = firstValue,
            Product = product,
            ModifiedArray = modifiedArray
        };
    }

    public static bool IsEvenDigitOnlyNumber(int number)
    {
        if (number == 0)
        {
            return true;
        }

        long value = Math.Abs((long)number);

        while (value > 0)
        {
            long digit = value % 10;

            if (digit % 2 != 0)
            {
                return false;
            }

            value /= 10;
        }

        return true;
    }
}