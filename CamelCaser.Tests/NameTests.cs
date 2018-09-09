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

        [Theory]
        [InlineData("I")]
        [InlineData("X")]
        public void Name_with_single_upper_case_is_lower_cased(string name)
        {
            Assert.Equal(name.ToLowerInvariant(), name.ToLowerCamelCase());
        }

        [Theory]
        [InlineData("Id", "id")]
        [InlineData("SomeIdentifier", "someIdentifier")]
        public void Name_that_starts_with_upper_case_then_lower_case_has_first_character_lower_cased(string name, string expected)
        {
            Assert.Equal(expected, name.ToLowerCamelCase());
        }

        [Theory]
        [InlineData("I", "i")]
        [InlineData("X", "x")]
        [InlineData("ID", "id")]
        [InlineData("COM", "com")]
        [InlineData("IDE", "ide")]
        public void Name_with_only_upper_case_has_all_lower_cased(string name, string expected)
        {
            Assert.Equal(expected, name.ToLowerCamelCase());
        }
    }
}
