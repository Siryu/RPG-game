using System;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TileEditor
{
    public partial class newTreasureChestForm : Form
    {
        string contentPath = Form1.cP.Text;

        public string boxItem;
        public int quantity;
        public bool OKPressed = false;
        public string isItem;
        
        List<string> weapons = new List<string>();
        List<string> armors = new List<string>();
        List<string> consumables = new List<string>();

        public newTreasureChestForm()
        {
            InitializeComponent();
            loadDefaultBoxData();
            LoadData();
        }

        private void loadDefaultBoxData()
        {
            WeaponComboBox.Items.Add("");
            ArmorComboBox.Items.Add("");
            consumableComboBox.Items.Add("");
        }

        private void LoadData()
        {
            XmlTextReader reader = new XmlTextReader(contentPath + "\\Weapons.item");
            reader.WhitespaceHandling = WhitespaceHandling.None;

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "Weapon")
                        weapons.Add(reader["Name"]);
                }
            }
            reader.Close();

            reader = new XmlTextReader(contentPath + "\\Armors.item");
            reader.WhitespaceHandling = WhitespaceHandling.None;

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "Armor")
                        armors.Add(reader["Name"]);
                }
            }
            reader.Close();

            reader = new XmlTextReader(contentPath + "\\Consumables.item");
            reader.WhitespaceHandling = WhitespaceHandling.None;

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "Consumable")
                        consumables.Add(reader["Name"]);
                }
            }
            reader.Close();

            foreach (string w in weapons)
                WeaponComboBox.Items.Add(w);
            foreach (string a in armors)
                ArmorComboBox.Items.Add(a);
            foreach (string c in consumables)
                consumableComboBox.Items.Add(c);
        }

        private void WeaponComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (WeaponComboBox.Text.Length > 1)
            {
                boxItem = WeaponComboBox.Text;

                ArmorComboBox.SelectedItem = "";
                consumableComboBox.SelectedItem = "";
                goldTextBox.Text = "";
            }
            if (WeaponComboBox.Text != "")
                WeaponComboBox.Text = boxItem;
        }

        private void ArmorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ArmorComboBox.Text.Length > 1)
            {
                boxItem = ArmorComboBox.Text;

                WeaponComboBox.SelectedItem = "";
                consumableComboBox.SelectedItem = "";
                goldTextBox.Text = "";
            }
            if (ArmorComboBox.Text != "")
                ArmorComboBox.Text = boxItem;
        }
        
        private void consumableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (consumableComboBox.Text.Length > 1)
            {
                boxItem = consumableComboBox.Text;

                WeaponComboBox.SelectedItem = "";
                ArmorComboBox.SelectedItem = "";
                goldTextBox.Text = "";
            }
            if (consumableComboBox.Text != "")
                consumableComboBox.Text = boxItem;

            if (consumableComboBox.Text == "")
                consumableQuantityTextBox.Text = "";
            else
                consumableQuantityTextBox.Text = "1";
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            OKPressed = false;
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (WeaponComboBox.Text.Length > 1)
                isItem = "Weapon";
            else if (ArmorComboBox.Text.Length > 1)
                isItem = "Armor";
            else if (consumableComboBox.Text.Length > 1)
            {
                isItem = "Consumable";
                quantity = int.Parse(consumableQuantityTextBox.Text);
            }
            else if (goldTextBox.Text.Length > 0)
            {
                isItem = "Gold";
                quantity = int.Parse(goldTextBox.Text);
            }
            else
            {
                MessageBox.Show("Did Not Select an Item");
                return;
            }

            OKPressed = true;
            Close();
        }
    }
}
