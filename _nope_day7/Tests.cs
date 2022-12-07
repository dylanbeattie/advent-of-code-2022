public class Tests {
    [Fact]
    public void Tests_Work() {
        1.ShouldBe(1);
    }

    [Fact]
    public void Size_Of_Empty_Node_Is_Zero() {
        var fs = FileTree.Parse(new string[]{});
        fs.Size.ShouldBe(0);
    }
}
