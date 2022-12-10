var inputs = File.ReadAllLines("example.txt")
    .Select(line => line.Split(' '))
    .SelectMany(tokens => 
        Enumerable.Range(0,Int32.Parse(tokens[1]))
        .Select(_ => tokens[0])
    );

foreach(var item in inputs) Console.WriteLine(item);
