using CommandLine;

namespace ascii_art_cli.Tests;

public class CommandLineParserTests
{
    [Fact]
    public void ParseTest_NoFlags()
    {
        // Arrange
        var expected = new Params();
        // Act
        var actual = CommandLineParser.Parse(Array.Empty<string>());
        // Assert
        actual.FilePath.Should().Be(expected.FilePath);
        actual.Contrast.Should().Be(expected.Contrast);
    }
}