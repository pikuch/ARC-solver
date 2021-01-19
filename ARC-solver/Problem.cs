using System.IO;
using Newtonsoft.Json;

namespace ARC_solver
{
    internal class Problem
    {
        public string name { get; set; }
        public ProblemData data { get; set; }

        public Problem(string filename)
        {
            this.name = Path.GetFileNameWithoutExtension(filename);
            using (StreamReader r = new StreamReader(filename))
            {
                this.data = JsonConvert.DeserializeObject<ProblemData>(r.ReadToEnd());
            }
        }
    }
}