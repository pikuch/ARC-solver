using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ARC_solver
{
    public partial class MainWindow : Window
    {
        const string dataDirectoryPath = "../../../data/";
        List<Problem> trainingProblems = new List<Problem>();
        List<Problem> evaluationProblems = new List<Problem>();

        public MainWindow()
        {
            InitializeComponent();
            LoadProblems();
            Solver solver = new Solver();
        }

        private void LoadProblems()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            foreach (string filename in Directory.GetFiles(dataDirectoryPath + "training"))
            {
                trainingProblems.Add(new Problem(filename));
            }
            foreach (string filename in Directory.GetFiles(dataDirectoryPath + "evaluation"))
            {
                evaluationProblems.Add(new Problem(filename));
            }

            trainingTaskList.ItemsSource = trainingProblems;
            evaluationTaskList.ItemsSource = evaluationProblems;
            sw.Stop();

            MessageBox.Show($"{trainingProblems.Count} training tasks and\n{evaluationProblems.Count} evaluation tasks\nloaded in {sw.ElapsedMilliseconds / 1000.0}s",
                            "timer info");
        }
    }
}
