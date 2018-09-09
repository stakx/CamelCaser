using Xunit;

namespace CamelCaser
{
    public class NameTests
    {
        [Fact]
        public void Empty_string_is_returned_unchanged()
        {
            Assert.Equal("", "".ToLowerCamelCase());
        }

        [Theory]
        [InlineData("i")]
        [InlineData("x")]
        [InlineData("id")]
        [InlineData("someIdentifier")]
        public void Name_that_starts_with_lower_case_is_returned_unchanged(string name)
        {
            Assert.Equal(name, name.ToLowerCamelCase());
        }
    }
}
