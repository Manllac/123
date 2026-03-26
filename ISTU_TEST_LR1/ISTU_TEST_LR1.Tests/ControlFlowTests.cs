using ISTU_TEST_LR1;
using Xunit;

namespace ISTU_TEST_LR1.Tests;

public class ControlFlowTests
{
    [Fact]
    public void ControlFlow_ProcessArray_NullArray_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => ArrayProcessor.ProcessArray(null!));
    }

    [Fact]
    public void ControlFlow_ProcessArray_EmptyArray_ReturnsDefaultResult()
    {
        int[] input = [];
        ArrayProcessResult result = ArrayProcessor.ProcessArray(input);

        Assert.False(result.HasEvenDigitOnlyNumber);
        Assert.Equal(-1, result.FirstIndex);
        Assert.Null(result.FirstValue);
        Assert.Equal(1, result.Product);
        Assert.Empty(result.ModifiedArray);
    }

    [Fact]
    public void ControlFlow_ProcessArray_NoMatchingElements_ReturnsOriginalArray()
    {
        int[] input = [13, 57, 91];
        ArrayProcessResult result = ArrayProcessor.ProcessArray(input);

        Assert.False(result.HasEvenDigitOnlyNumber);
        Assert.Equal(-1, result.FirstIndex);
        Assert.Null(result.FirstValue);
        Assert.Equal(67431, result.Product);
        Assert.Equal(new long[] { 13, 57, 91 }, result.ModifiedArray);
    }

    [Fact]
    public void ControlFlow_ProcessArray_OneMatchingElement_ReplacesMatchingElement()
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
    public void ControlFlow_ProcessArray_MultipleMatchingElements_ReplacesAllMatchingElements()
    {
        int[] input = [24, 13, 80, 57];
        ArrayProcessResult result = ArrayProcessor.ProcessArray(input);

        Assert.True(result.HasEvenDigitOnlyNumber);
        Assert.Equal(0, result.FirstIndex);
        Assert.Equal(24, result.FirstValue);
        Assert.Equal(1422720, result.Product);
        Assert.Equal(new long[] { 1422720, 13, 1422720, 57 }, result.ModifiedArray);
    }

    [Fact]
    public void ControlFlow_ProcessArray_ContainsZero_ProductBecomesZero_AndZeroIsMatching()
    {
        int[] input = [13, 0, 57];
        ArrayProcessResult result = ArrayProcessor.ProcessArray(input);

        Assert.True(result.HasEvenDigitOnlyNumber);
        Assert.Equal(1, result.FirstIndex);
        Assert.Equal(0, result.FirstValue);
        Assert.Equal(0, result.Product);
        Assert.Equal(new long[] { 13, 0, 57 }, result.ModifiedArray);
    }

    [Fact]
    public void ControlFlow_ProcessArray_NegativeMatchingElement_ReplacesItUsingProduct()
    {
        int[] input = [-248, 3];
        ArrayProcessResult result = ArrayProcessor.ProcessArray(input);

        Assert.True(result.HasEvenDigitOnlyNumber);
        Assert.Equal(0, result.FirstIndex);
        Assert.Equal(-248, result.FirstValue);
        Assert.Equal(-744, result.Product);
        Assert.Equal(new long[] { -744, 3 }, result.ModifiedArray);
    }

    [Fact]
    public void ControlFlow_ProcessArray_NegativeNonMatchingElement_RemainsUnchanged()
    {
        int[] input = [-135, 2];
        ArrayProcessResult result = ArrayProcessor.ProcessArray(input);

        Assert.True(result.HasEvenDigitOnlyNumber);
        Assert.Equal(1, result.FirstIndex);
        Assert.Equal(2, result.FirstValue);
        Assert.Equal(-270, result.Product);
        Assert.Equal(new long[] { -135, -270 }, result.ModifiedArray);
    }
}