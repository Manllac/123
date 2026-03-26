using ISTU_TEST_LR1;
using Xunit;

namespace ISTU_TEST_LR1.Tests;

public class KeyElementPositionTests
{
    [Fact]
    public void KeyElement_FirstPosition_FirstIndexIsZero()
    {
        int[] input = [24, 13, 57];
        ArrayProcessResult result = ArrayProcessor.ProcessArray(input);

        Assert.True(result.HasEvenDigitOnlyNumber);
        Assert.Equal(0, result.FirstIndex);
        Assert.Equal(24, result.FirstValue);
        Assert.Equal(17784, result.Product);
        Assert.Equal(new long[] { 17784, 13, 57 }, result.ModifiedArray);
    }

    [Fact]
    public void KeyElement_MiddlePosition_FirstIndexIsMiddle()
    {
        int[] input = [13, 24, 57];
        ArrayProcessResult result = ArrayProcessor.ProcessArray(input);

        Assert.True(result.HasEvenDigitOnlyNumber);
        Assert.Equal(1, result.FirstIndex);
        Assert.Equal(24, result.FirstValue);
        Assert.Equal(17784, result.Product);
        Assert.Equal(new long[] { 13, 17784, 57 }, result.ModifiedArray);
    }

    [Fact]
    public void KeyElement_LastPosition_FirstIndexIsLast()
    {
        int[] input = [13, 57, 24];
        ArrayProcessResult result = ArrayProcessor.ProcessArray(input);

        Assert.True(result.HasEvenDigitOnlyNumber);
        Assert.Equal(2, result.FirstIndex);
        Assert.Equal(24, result.FirstValue);
        Assert.Equal(17784, result.Product);
        Assert.Equal(new long[] { 13, 57, 17784 }, result.ModifiedArray);
    }

    [Fact]
    public void KeyElement_NoMatchingElements_ReturnsFalseAndOriginalArray()
    {
        int[] input = [13, 57, 91];
        ArrayProcessResult result = ArrayProcessor.ProcessArray(input);

        Assert.False(result.HasEvenDigitOnlyNumber);
        Assert.Equal(-1, result.FirstIndex);
        Assert.Null(result.FirstValue);
        Assert.Equal(67431, result.Product);
        Assert.Equal(new long[] { 13, 57, 91 }, result.ModifiedArray);
    }
}