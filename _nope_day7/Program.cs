var lines = File.ReadAllLines("example.txt");

public class FileTree {

	public static PathNode Parse(string[] lines) {
		var root = new PathNode();
		var currentDirectory = root;
		foreach (var line in lines) {
			var tokens = line.Split(' ');
			switch (tokens[0]) {
				case "$":
					break;
				case "dir":
					break;
				default:
					var size = Int32.Parse(tokens[0]);
					var name = tokens[1];
					currentDirectory.AddFile(size, name);
					break;

			}
		}
		return root;
	}

	public class FileNode {
		public string Name { get; set; } = String.Empty;
		public int Size { get; set; }
	}

	public class PathNode {

        public int Size => 0;
		public void AddFile(int size, string name) {
			this.Files.Add(new FileNode { Name = name, Size = size });
		}
		string Name { get; set; } = String.Empty;
		public List<PathNode> Directories { get; set; } = new();
		public List<FileNode> Files { get; set; } = new();
	}
}