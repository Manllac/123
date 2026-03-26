using ISTU_TEST_LR1;
using Xunit;

namespace ISTU_TEST_LR1.Tests;

public class ConditionTests
{
    [Fact]
    public void Condition_IsEvenDigitOnlyNumber_Zero_ReturnsTrue()
    {
        Assert.True(ArrayProcessor.IsEvenDigitOnlyNumber(0));
    }

    [Fact]
    public void Condition_IsEvenDigitOnlyNumber_PositiveEvenDigitsOnly_ReturnsTrue()
    {
        Assert.True(ArrayProcessor.IsEvenDigitOnlyNumber(248680));
    }

    [Fact]
    public void Condition_IsEvenDigitOnlyNumber_PositiveContainsOddDigit_ReturnsFalse()
    {
        Assert.False(ArrayProcessor.IsEvenDigitOnlyNumber(248681));
    }

    [Fact]
    public void Condition_IsEvenDigitOnlyNumber_NegativeEvenDigitsOnly_ReturnsTrue()
    {
        Assert.True(ArrayProcessor.IsEvenDigitOnlyNumber(-248680));
    }

    [Fact]
    public void Condition_IsEvenDigitOnlyNumber_NegativeContainsOddDigit_ReturnsFalse()
    {
        Assert.False(ArrayProcessor.IsEvenDigitOnlyNumber(-248681));
    }

    [Fact]
    public void Condition_IsEvenDigitOnlyNumber_SingleEvenDigit_ReturnsTrue()
    {
        Assert.True(ArrayProcessor.IsEvenDigitOnlyNumber(8));
    }

    [Fact]
    public void Condition_IsEvenDigitOnlyNumber_SingleOddDigit_ReturnsFalse()
    {
        Assert.False(ArrayProcessor.IsEvenDigitOnlyNumber(7));
    }

    [Fact]
    public void Condition_IsEvenDigitOnlyNumber_IntMinValue_ReturnsFalse()
    {
        Assert.False(ArrayProcessor.IsEvenDigitOnlyNumber(int.MinValue));
    }

    [Fact]
    public void Condition_ProcessArray_FirstMatchingStoredOnlyOnce()
    {
        int[] input = [24, 80, 42];
        ArrayProcessResult result = ArrayProcessor.ProcessArray(input);

        Assert.True(result.HasEvenDigitOnlyNumber);
        Assert.Equal(0, result.FirstIndex);
        Assert.Equal(24, result.FirstValue);
        Assert.Equal(80640, result.Product);
        Assert.Equal(new long[] { 80640, 80640, 80640 }, result.ModifiedArray);
    }

    [Fact]
    public void Condition_ProcessArray_ArrayWithOneOddAndOneEvenDigitNumber_ReplacesOnlyMatching()
    {
        int[] input = [28, 29];
        ArrayProcessResult result = ArrayProcessor.ProcessArray(input);

        Assert.True(result.HasEvenDigitOnlyNumber);
        Assert.Equal(0, result.FirstIndex);
        Assert.Equal(28, result.FirstValue);
        Assert.Equal(812, result.Product);
        Assert.Equal(new long[] { 812, 29 }, result.ModifiedArray);
    }
}