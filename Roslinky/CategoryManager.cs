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
    public partial class CategoryManager : Form
    {
        private List<Category> categories;
        private MainWindow parent;

        public CategoryManager(MainWindow parent)
        {
            InitializeComponent();
            this.categories = parent.getCategories();
            this.parent = parent;
            refreshCat();
        }

        private void buttonAddCat_Click(object sender, EventArgs e)
        {
            var cat = new Category();
            cat.name = textBoxCategory.Text;
            cat.types = new List<string>();
            categories.Add(cat);
            comboBoxCategory.Items.Add(cat.name);
            comboBoxCategory.SelectedIndex = comboBoxCategory.Items.Count - 1;
        }

        private void buttonAnihilation_Click(object sender, EventArgs e)
        {
            categories.RemoveAt(comboBoxCategory.SelectedIndex);
            refreshCat();
        }

        private void buttonType_Click(object sender, EventArgs e)
        {
            categories[comboBoxCategory.SelectedIndex].types.Add(textBoxType.Text);
            comboBoxType.Items.Add(textBoxType.Text);
            comboBoxType.SelectedIndex = comboBoxType.Items.Count - 1;
        }

        private void buttonDeleteType_Click(object sender, EventArgs e)
        {
            categories[comboBoxCategory.SelectedIndex].types.RemoveAt(comboBoxType.SelectedIndex);
            refreshType();
        }

        private void CategoryManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.setNewCategories(categories);
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshType();
        }


        private void refreshType()
        {
            comboBoxType.Items.Clear();
            var currCat = categories[comboBoxCategory.SelectedIndex];
            foreach (var type in currCat.types)
            {
                comboBoxType.Items.Add(type);
            }
            if (currCat.types.Count > 0)
                comboBoxType.SelectedIndex = 0;
        }

        private void refreshCat()
        {
            comboBoxCategory.Items.Clear();
            foreach (var category in categories)
            {
                comboBoxCategory.Items.Add(category.name);
            }
            if (categories.Count > 0)
                comboBoxCategory.SelectedIndex = 0;
        }
    }
}
