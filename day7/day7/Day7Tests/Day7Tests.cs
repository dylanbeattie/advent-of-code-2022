
using Day7;
using Microsoft.VisualBasic;

namespace Day7Tests;

public class Day7Tests {
	[Fact]
	public void Tests_Work() {
		1.ShouldBe(1);
	}

	[Fact]
	public void Size_Of_Empty_Node_Is_Zero() {
		var fs = FileTree.Parse(new string[] { });
		fs.Size.ShouldBe(0);
	}

	[Fact]
	public void Size_Of_Single_File_Works() {
		var fs = FileTree.Parse("$ cd /|$ ls|123 foo.txt".Split('|'));
		fs.Size.ShouldBe(123);
	}

	[Fact]
	public void Size_Of_Two_Files_Works() {
		var fs = FileTree.Parse("$ cd /|$ ls|123 foo.txt|456 bar.txt".Split('|'));
		fs.Size.ShouldBe(123 + 456);
	}

	[Fact]
	public void Tree_With_One_Subdirectory_Works() {

		var fs = FileTree.Parse(@"$ cd /
$ ls 
dir a
123 foo.txt
$ cd a
$ ls
456 bar.txt".Split(Environment.NewLine));
		fs.Size.ShouldBe(123 + 456);
	}

	[Fact]
	public void Example_From_Web_Page_Works() {
		var example = File.ReadAllLines("example.txt");
		var fs = FileTree.Parse(example);
		fs.Size.ShouldBe(48381165);
	}

	[Fact]
	public void Example_From_Web_Page_Filters_Correctly() {
		var example = File.ReadAllLines("example.txt");
		var fs = FileTree.Parse(example);
		var result = fs.AllSizes.Where(s => s <= 100000).Sum();
		result.ShouldBe(95437);
	}

	[Fact]
	public void Example_From_Web_Page_Filters_Correctly_For_Real_Input() {
		var example = File.ReadAllLines("input.txt");
		var fs = FileTree.Parse(example);
		var result = fs.AllSizes.Where(s => s <= 100000).Sum();
		result.ShouldBe(1501149);
	}
}

