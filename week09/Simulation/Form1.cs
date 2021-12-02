using Simulation.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation
{
    public partial class Form1 : Form
    {
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();
        List<int> NumberOfWoman = new List<int>();
        List<int> NumberOfMan = new List<int>();
        Random rng = new Random(1234);
        public Form1()
        {
            InitializeComponent();  
        }

        private void Simulation(int maxYear)
        {
            for (int year = 2005; year <= maxYear; year++)
            {
                for (int i = 0; i < Population.Count; i++)
                {
                    SimStep(year, Population[i]);
                }
                int nmbrOfMales = (from x in Population
                                   where x.Gender == Gender.Male && x.IsAlive
                                   select x).Count();
                int nmbrOfFemales = (from x in Population
                                     where x.Gender == Gender.Female && x.IsAlive
                                     select x).Count();
                Console.WriteLine(
                    string.Format("Év:{0} Fiúk:{1} Lányok:{2}", year, nmbrOfMales, nmbrOfFemales));
                NumberOfWoman.Add(nmbrOfFemales);
                NumberOfMan.Add(nmbrOfMales);
                
            }
            DisplayResults(maxYear);
        }
        void DisplayResults(int maxYear)
        {
            for (int year = 2005; year <= maxYear; year++)
            {
                richTextBox1.Text += "Szimulációs év: " + year + "\n\t Fiúk: " + NumberOfMan[year - 2005] + "\n\t Lányok: " + NumberOfWoman[year - 2005] + "\n";
            }
        }
        List<Person> ReadPopulation(string file)
        {
            List<Person> people = new List<Person>();
            using (StreamReader sr = new StreamReader(file))
            {
                
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(';');
                    Person p = new Person { BirthYear = int.Parse(line[0]), Gender = (Gender)Enum.Parse(typeof(Gender), line[1]), NmbrOfChildren = int.Parse(line[2]) };
                    people.Add(p);
                }
            }
            return people;
        }
        List<BirthProbability> ReadBirthProbabilities(string file)
        {
            List<BirthProbability> birthProbabilities = new List<BirthProbability>();
            using (StreamReader sr = new StreamReader(file))
            {

                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(';');
                    BirthProbability p = new BirthProbability { Age=int.Parse(line[0]), NmbrOfChildren=int.Parse(line[1]), BProbability=double.Parse(line[2]) };
                    birthProbabilities.Add(p);
                }
            }
            return birthProbabilities;
        }
        List<DeathProbability> ReadDeathProbabilities(string file)
        {
            List<DeathProbability> deathProbabilities = new List<DeathProbability>();
            using (StreamReader sr = new StreamReader(file))
            {

                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(';');
                    DeathProbability p = new DeathProbability { Gender = (Gender)Enum.Parse(typeof(Gender), line[0]), Age=int.Parse(line[1]), DProbability=double.Parse(line[2]) };
                    deathProbabilities.Add(p);
                }
            }
            return deathProbabilities;
        }
        void SimStep(int year, Person person)
        {
            if (!person.IsAlive) return;
            var age = year - person.BirthYear;
            double pDeath = (from x in DeathProbabilities
                             where x.Gender == person.Gender && x.Age == age
                             select x.DProbability).FirstOrDefault();
            if (rng.NextDouble() <= pDeath) person.IsAlive = false;
            if (person.IsAlive && person.Gender == Gender.Female)
            {
                double pBirth = (from x in BirthProbabilities
                                 where x.Age == age
                                 select x.BProbability).FirstOrDefault();
                if (rng.NextDouble() <= pBirth)
                {
                    Person újszülött = new Person { BirthYear = year, NmbrOfChildren = 0 , Gender = (Gender)(rng.Next(1, 3)) };
                    Population.Add(újszülött);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NumberOfMan.Clear();
            NumberOfWoman.Clear();
            Population.Clear();
            BirthProbabilities.Clear();
            DeathProbabilities.Clear();
            richTextBox1.Text = "";
            if (!File.Exists(textBox1.Text))
            {
                MessageBox.Show("Nem talalhato a file.");
                return;
            }
            Population = ReadPopulation(textBox1.Text);
            BirthProbabilities = ReadBirthProbabilities(@"C:\Temp\születés.csv");
            DeathProbabilities = ReadDeathProbabilities(@"C:\Temp\halál.csv");
            Simulation(int.Parse(numericUpDown1.Value.ToString()));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Temp";
            if (ofd.ShowDialog() != DialogResult.OK) return;
            textBox1.Text = ofd.FileName;
        }
    }
}
