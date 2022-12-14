namespace Day7;

public class FileTree {
	public static PathNode Parse(string[] lines) {
		var root = new PathNode();
		var currentDirectory = root;
		foreach (var line in lines) {
			var tokens = line.Split(' ');
			switch (tokens[0]) {
				case "$":
					if (tokens[1] == "cd") currentDirectory = tokens[2] switch {
						"/" => currentDirectory,
						".." => currentDirectory.Parent,
						_ => currentDirectory.Cd(tokens[2])
					};
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

	public class PathNode {
		public PathNode Cd(string name) {
			if (!Directories.ContainsKey(name)) AddDirectory(name);
			return Directories[name];
		}

		public IEnumerable<int> AllSizes {
			get {
				yield return Size;
				foreach (var size in Directories.Values.SelectMany(directory => directory.AllSizes)) {
					yield return size;
				}
			}
		}
		public PathNode Parent { get; set; } = null!;
		public int Size => Files.Sum(file => file.Value) + Directories.Sum(dir => dir.Value.Size);
		public void AddFile(int size, string name) => Files.Add(name, size);
		public void AddDirectory(string name) => Directories.Add(name, new PathNode { Parent = this });
		public Dictionary<string, PathNode> Directories { get; set; } = new();
		public Dictionary<string, int> Files { get; set; } = new();
	}
}
