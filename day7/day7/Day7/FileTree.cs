namespace Day7;

public class FileTree {
	public static PathNode Parse(string[] lines) {
		var root = new PathNode();
		var currentDirectory = root;
		foreach (var line in lines) {
			var tokens = line.Split(' ');
			switch (tokens[0]) {
				case "$":
					switch (tokens[1]) {
						case "cd":
							currentDirectory = tokens[2] switch {
								"/" => currentDirectory,
								".." => currentDirectory.Parent,
								_ => currentDirectory.Cd(tokens[2])
							};
							break;
						case "ls":
							break;
					}

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
			if (!this.Directories.ContainsKey(name)) this.AddDirectory(name);
			return this.Directories[name];
		}

		public IEnumerable<int> AllSizes {
			get {
				yield return this.Size;
				foreach (var size in this.Directories.Values.SelectMany(directory => directory.AllSizes)) {
					yield return size;
				}
			}
		}

		public PathNode Parent { get; set; } = null!;
		public int Size => Files.Sum(file => file.Value) + Directories.Sum(dir => dir.Value.Size);
		public void AddFile(int size, string name) => Files.Add(name, size);

		public void AddDirectory(string name) =>
			this.Directories.Add(name, new PathNode { Parent = this });

		public Dictionary<string, PathNode> Directories { get; set; } = new();
		public Dictionary<string, int> Files { get; set; } = new();
	}
}
