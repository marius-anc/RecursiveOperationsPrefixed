using System;
using Xunit;

namespace RecursiveOperationsPrefixed.Tests
{
    public class ProgramTests
    {
        [Theory]
        [InlineData(new string[] { "1", "+" }, true)]
        [InlineData(new string[] { "1", "-" }, true)]
        [InlineData(new string[] { "1", "*" }, true)]
        [InlineData(new string[] { "1", "/" }, true)]
        [InlineData(new string[] { "1", "0" }, false)]
        public void ArrayContainsOPerationsReturnsTrueWhenOPerations(string[] input, bool result)
        {
            Assert.Equal(result, Program.ArrayContainsOperations(input));
        }

        [Fact]
        public void PrefixedRcursiveworkswithOneOperationGroup()
        {
            string[] operations = { "/", "*", "-", "+", "2", "3", "1", "2", "8" };
            Assert.Equal("1", Program.PrefixedRecursive(operations));
        }

        [Fact]
        public void PrefixedRcursiveworkswithMultipleOperationGroup()
        {
            string[] operations = { "/", "*", "-", "+", "2", "3", "1", "2", "+", "4", "4" };
            Assert.Equal("1", Program.PrefixedRecursive(operations));
        }

        [Fact]
        public void PrefixedRcursiveworkswithRealNumber()
        {
            string[] operations = { "/", "*", "-", "+", "2", "3", "1", "2", "+", "3,5", "4,5" };
            Assert.Equal("1", Program.PrefixedRecursive(operations));
        }
    }
}
