
public class ProblemData
{
    public Train[] train { get; set; }
    public Test[] test { get; set; }
}

public class Train
{
    public int[,] input { get; set; }
    public int[,] output { get; set; }
}

public class Test
{
    public int[,] input { get; set; }
    public int[,] output { get; set; }
}
