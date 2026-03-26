using ISTU_TEST_LR1;
using Xunit;

namespace ISTU_TEST_LR1.Tests;

public class EquivalenceClassTests
{
    [Fact]
    public void Equivalence_MinValue_IntMinValue()
    {
        int[] input = [int.MinValue];
        ArrayProcessResult result = ArrayProcessor.ProcessArray(input);

        Assert.False(result.HasEvenDigitOnlyNumber);
        Assert.Equal(-1, result.FirstIndex);
        Assert.Null(result.FirstValue);
        Assert.Equal((long)int.MinValue, result.Product);
        Assert.Equal(new long[] { int.MinValue }, result.ModifiedArray);
    }

    [Fact]
    public void Equivalence_NegativeRange_NumberBetweenMinAndZero()
    {
        int[] input = [-246];
        ArrayProcessResult result = ArrayProcessor.ProcessArray(input);

        Assert.True(result.HasEvenDigitOnlyNumber);
        Assert.Equal(0, result.FirstIndex);
        Assert.Equal(-246, result.FirstValue);
        Assert.Equal(-246, result.Product);
        Assert.Equal(new long[] { -246 }, result.ModifiedArray);
    }

    [Fact]
    public void Equivalence_Zero()
    {
        int[] input = [0];
        ArrayProcessResult result = ArrayProcessor.ProcessArray(input);

        Assert.True(result.HasEvenDigitOnlyNumber);
        Assert.Equal(0, result.FirstIndex);
        Assert.Equal(0, result.FirstValue);
        Assert.Equal(0, result.Product);
        Assert.Equal(new long[] { 0 }, result.ModifiedArray);
    }

    [Fact]
    public void Equivalence_PositiveRange_NumberBetweenZeroAndMax()
    {
        int[] input = [248];
        ArrayProcessResult result = ArrayProcessor.ProcessArray(input);

        Assert.True(result.HasEvenDigitOnlyNumber);
        Assert.Equal(0, result.FirstIndex);
        Assert.Equal(248, result.FirstValue);
        Assert.Equal(248, result.Product);
        Assert.Equal(new long[] { 248 }, result.ModifiedArray);
    }

    [Fact]
    public void Equivalence_MaxValue_IntMaxValue()
    {
        int[] input = [int.MaxValue];
        ArrayProcessResult result = ArrayProcessor.ProcessArray(input);

        Assert.False(result.HasEvenDigitOnlyNumber);
        Assert.Equal(-1, result.FirstIndex);
        Assert.Null(result.FirstValue);
        Assert.Equal((long)int.MaxValue, result.Product);
        Assert.Equal(new long[] { int.MaxValue }, result.ModifiedArray);
    }

    // Дополнительные комбинации

    [Fact]
    public void Equivalence_MixedValues_AllRangesTogether()
    {
        int[] input = [int.MinValue, -246, 0, 248, int.MaxValue];
        ArrayProcessResult result = ArrayProcessor.ProcessArray(input);

        Assert.True(result.HasEvenDigitOnlyNumber);
        Assert.Equal(1, result.FirstIndex);
        Assert.Equal(-246, result.FirstValue);
        Assert.Equal(0, result.Product); // из-за нуля
        Assert.Equal(new long[] { int.MinValue, 0, 0, 0, int.MaxValue }, result.ModifiedArray);
    }

    [Fact]
    public void Equivalence_NegativeNonMatching()
    {
        int[] input = [-135];
        ArrayProcessResult result = ArrayProcessor.ProcessArray(input);

        Assert.False(result.HasEvenDigitOnlyNumber);
        Assert.Equal(-1, result.FirstIndex);
        Assert.Null(result.FirstValue);
        Assert.Equal(-135, result.Product);
        Assert.Equal(new long[] { -135 }, result.ModifiedArray);
    }

    [Fact]
    public void Equivalence_PositiveNonMatching()
    {
        int[] input = [135];
        ArrayProcessResult result = ArrayProcessor.ProcessArray(input);

        Assert.False(result.HasEvenDigitOnlyNumber);
        Assert.Equal(-1, result.FirstIndex);
        Assert.Null(result.FirstValue);
        Assert.Equal(135, result.Product);
        Assert.Equal(new long[] { 135 }, result.ModifiedArray);
    }
}