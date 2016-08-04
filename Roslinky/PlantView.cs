using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Roslinky.dto;

namespace Roslinky
{
   

    public partial class PlantView : UserControl
    {
        private MainWindow parent;
        private Plant plant;
        private static int VIEW_HEIGHT = 120;

        public PlantView(int width, Plant plant, MainWindow parent)
        {
            this.plant = plant;
            this.parent = parent;

            InitializeComponent();
            this.Height = VIEW_HEIGHT;
            this.Width = width;

            var photo = new PictureBox();
            photo.Width = VIEW_HEIGHT;
            photo.Height = VIEW_HEIGHT;
            if (plant.photoPath == null)
                photo.Image = (Image)(Roslinky.Properties.Resources.no_photo);
            else
                photo.ImageLocation = plant.photoPath;
            photo.SizeMode = PictureBoxSizeMode.Zoom;
            photo.DoubleClick += this.PlantView_DoubleClick;
            this.Controls.Add(photo);

            var title = new Label();
            title.Text = plant.name;
            title.Font = new Font(title.Font.FontFamily, 15);
            title.Width = width - (VIEW_HEIGHT + 25);
            title.Location = new Point(VIEW_HEIGHT + 1, 0);
            title.DoubleClick += this.PlantView_DoubleClick;
            this.Controls.Add(title);

            var description = new Label();
            description.Text = plant.notes;
            description.Width = width - (VIEW_HEIGHT + 25);
            description.Location = new Point(VIEW_HEIGHT + 1, title.Height + 10);
            description.DoubleClick += this.PlantView_DoubleClick;
            this.Controls.Add(description);

            var types = new Label();
            types.Text = String.Join(", ", plant.types.ToArray());
            types.Width = width - (VIEW_HEIGHT + 25);
            types.Location = new Point(VIEW_HEIGHT + 1, description.Location.Y + description.Height + 2);
            types.DoubleClick += this.PlantView_DoubleClick;
            this.Controls.Add(types);
        }

        private void PlantView_DoubleClick(object sender, EventArgs e)
        {
           new PlantDetail(plant, parent).Show();
        }
    }
}
