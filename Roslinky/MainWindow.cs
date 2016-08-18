using Newtonsoft.Json;
using Roslinky.dto;
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

namespace Roslinky
{
    public partial class MainWindow : Form
    {
        private static String DATABASE_LOCATION = "data/db.txt";
        private DataWrapper database;
        private List<String> checkedTypes = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(DATABASE_LOCATION))
            {
                StreamReader sr = new StreamReader(DATABASE_LOCATION);
                database = JsonConvert.DeserializeObject<DataWrapper>(sr.ReadToEnd());
                sr.Close();
                initializeCategories();
                refreshPlants();
            }
            if (database == null)
            {
                database = new DataWrapper();
                database.plants = new List<Plant>();
                database.categories = new List<Category>();
            }
        }

        public void setNewCategories(List<Category> categories)
        {
            database.categories = categories;
            initializeCategories();
        }

        public void addNewPlant(Plant plant)
        {
            database.plants.Add(plant);
            refreshPlants();
        }

        internal void removePlant(Plant plant)
        {
            database.plants.Remove(plant);
            refreshPlants();
        }

        private void refreshPlants()
        {
            itemsPanel.Controls.Clear();
            int position = 10;
            database.plants
                .Where(plant => plant.types.Intersect(checkedTypes).Count() == checkedTypes.Count())
                .OrderBy(plant => plant.name)
                .ToList()
                .ForEach(plant =>
            {
                var plantView = new PlantView(itemsPanel.Width, plant, this);
                plantView.Location = new Point(0, position);
                position += plantView.Height + 10;
                itemsPanel.Controls.Add(plantView);

            });

           
        }

        public void initializeCategories()
        {
            groupPanel.Controls.Clear();
            checkedTypes.Clear();
            int position = 10;
            foreach (var cat in database.categories)
            {
                var group = new GroupControl(cat.name, cat.types, this);
                group.Location = new Point(0, position);
                position += group.Height + 10;
                groupPanel.Controls.Add(group);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
	            File.WriteAllText(saveFileDialog1.FileName,  JsonConvert.SerializeObject(database));       
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                database = JsonConvert.DeserializeObject<DataWrapper>(sr.ReadToEnd());
                sr.Close();
                initializeCategories();
                refreshPlants();
            }
        }

        private void buttonManage_Click(object sender, EventArgs e)
        {
            var window = new CategoryManager(this);
            window.Show();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var window = new NewPlant(this);
            window.Show();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!System.IO.Directory.Exists("data"))
            {
                System.IO.Directory.CreateDirectory("data");
            }

            var file = new StreamWriter(DATABASE_LOCATION);
            var serializedBase = JsonConvert.SerializeObject(database);
            file.Write(serializedBase);
            file.Close();
        }

        public List<Category> getCategories()
        {
            return database.categories;
        }


        internal void checkedType(string type, bool isChecked)
        {
            if (isChecked)
                checkedTypes.Add(type);
            else
                checkedTypes.Remove(type);

            this.refreshPlants();
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            this.refreshPlants();
        }
    }
}
