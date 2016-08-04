using Roslinky.dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roslinky
{
    public partial class NewPlant : Form
    {
        private List<Category> categories;
        private MainWindow parent;
        private Plant plant;
        private bool edited = false;

        public NewPlant(MainWindow parent, Plant editedPlant)
        {
            init(parent);
            this.plant = editedPlant;
            textBoxName.Text = plant.name;
            textBoxDescription.Text = plant.notes;
            plant.types.ForEach(x => listBoxChoosen.Items.Add(x));
            edited = true;
        }

        public NewPlant(MainWindow parent)
        {
            this.plant = new Plant();
            this.plant.types = new List<string>();
            init(parent);
            buttonRemove.Enabled = false;
        }

        private void init(MainWindow parent)
        {
            InitializeComponent();
            this.categories = parent.getCategories();
            this.parent = parent;
            initCategories();
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxTypes.Items.Clear();
            foreach(var type in categories[comboBoxCategory.SelectedIndex].types)
            {
                listBoxTypes.Items.Add(type);
            }
            if (listBoxTypes.Items.Count > 0)
                listBoxTypes.SelectedIndex = 0;
        }

        private void buttonChoose_Click(object sender, EventArgs e)
        {
            listBoxChoosen.Items.Add(listBoxTypes.SelectedItem);
            plant.types.Add(categories[comboBoxCategory.SelectedIndex].types[listBoxTypes.SelectedIndex]);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            plant.types.RemoveAt(listBoxChoosen.SelectedIndex);
            listBoxChoosen.Items.RemoveAt(listBoxChoosen.SelectedIndex);
        }

        private void buttonImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                plant.photoPath = openFileDialog1.FileName;
            }

        }

        private void buttonUrl_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                plant.hyperlink = openFileDialog1.FileName;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (edited)
                parent.removePlant(plant);
            plant.name = textBoxName.Text;
            plant.notes = textBoxDescription.Text;
            parent.addNewPlant(plant);
            this.Close();
        }

        private void initCategories()
        {
            comboBoxCategory.Items.Clear();
            foreach (var category in categories)
            {
                comboBoxCategory.Items.Add(category.name);
            }
            if (categories.Count > 0)
                comboBoxCategory.SelectedIndex = 0;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            parent.removePlant(plant);
            this.Close();
        }

    }
}
