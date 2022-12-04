using Shouldly;
using Xunit;

namespace day3test;

public class UnitTest1 {
	[Fact]    
	public void FindCommonElement_Works_With_Single_Input() {
        var c = Program.FindCommonElement(new[] { " " });
        c.ShouldBe(' ');        
	}

    [Theory]
    [InlineData(new[] { "a", "a" }, 'a')]
    [InlineData(new[] { "aa", "ab" }, 'a')]
    [InlineData(new[] { "aa", "ab", "ac" }, 'a')]
    [InlineData(new[] { "aa", "ab", "ac", "ad" }, 'a')]
    [InlineData(new[] { "AX", "BX", "CX", "DX" }, 'X')]
    public void FindCommonElement_Works(string[] inputs, char output) {
        Program.FindCommonElement(inputs).ShouldBe(output);
    }

    // [Theory]
    // [InlineData(new[] { "a", "b" })]
    // [InlineData(new[] { "" })]
    // public void FindCommonElement_Explodes_Appropriately(string[] inputs) {
    //     Should.Throw(() => Program.FindCommonElement(inputs));
    // }
}