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
    public partial class PlantDetail : Form
    {

        private MainWindow parent;
        private Plant plant;

        public PlantDetail(Plant plant, MainWindow parent)
        {
            this.plant = plant;
            this.parent = parent;
            InitializeComponent();

            if (plant.photoPath == null)
                pictureBox.Image = (Image)(Roslinky.Properties.Resources.no_photo);
            else
                pictureBox.ImageLocation = plant.photoPath;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            labelTitle.Text = plant.name;
            textBoxNotes.Text = plant.notes;
            textBoxTypes.Text = String.Join(", ", plant.types.ToArray());
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (plant.hyperlink != null)
            {
                System.Diagnostics.Process.Start(plant.hyperlink);
            }
            else
            {
                MessageBox.Show("Nie skojarzono pliku!");
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            new NewPlant(parent, plant).Show();
            this.Close();
        }

    }
}
