using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TileEngine;

namespace TileEditor
{
    public partial class newConsumableForm : Form
    {
        Consumable consumable = new Consumable();
        Dictionary<String, Consumable> consumableList = new Dictionary<String, Consumable>();
        string contentPath = Form1.cP.Text;

        public newConsumableForm()
        {
            InitializeComponent();
            loadDefaultBoxData();
            loadData();           
        }

        private void loadDefaultBoxData()
        {
            reviveComboBox.Items.Add("No");
            reviveComboBox.Items.Add("Yes");
            reviveComboBox.Text = "No";
        }

        private void Clear()
        {
            imageFileTextBox.Text = null;
            nameTextBox.Text = null;
            HPTextBox.Text = null;
            MPTextBox.Text = null;
            HPRegenTextBox.Text = null;
            MPRegenTextBox.Text = null; 
            reviveComboBox.Text = null;
            lifeTextBox.Text = null;
        }

        private void loadData()
        {
            XmlTextReader reader = new XmlTextReader(contentPath + "\\Consumables.item");
            reader.WhitespaceHandling = WhitespaceHandling.None;

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "Consumable")
                        consumable.name = reader["Name"];
                    if (reader.Name == "Image")
                        consumable.textureName = contentPath + "\\" + reader["Texture"];
                    if (reader.Name == "HP")
                        consumable.HP = int.Parse(reader["Value"]);
                    if (reader.Name == "MP")
                        consumable.MP = int.Parse(reader["Value"]);
                    if (reader.Name == "RegenHP")
                        consumable.regenHP = int.Parse(reader["Value"]);
                    if (reader.Name == "RegenMP")
                        consumable.regenMP = int.Parse(reader["Value"]);
                    if (reader.Name == "Resurrect")
                        consumable.Resurrect = reader["Value"];
                    if (reader.Name == "Life")
                        consumable.life = int.Parse(reader["Value"]);
                }


                else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "Consumable")
                {
                    consumableList.Add(consumable.name, consumable);
                    existingConsumableComboBox.Items.Add(consumable.name);
                    consumable = new Consumable();
                }
            }
            reader.Close();
        }



        private void newButton_Click(object sender, EventArgs e)
        {
            existingConsumableComboBox.SelectedItem = null;
            Clear();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (HPTextBox.Text.Length < 1 || MPTextBox.Text.Length < 1 ||
            HPRegenTextBox.Text.Length < 1 || MPRegenTextBox.Text.Length < 1 || lifeTextBox.Text.Length < 1 ||
            imageFileTextBox.Text.Length < contentPath.Length + 1)
            {
                MessageBox.Show("Not All Fields Have Values");
                return;
            }

            consumable.name = nameTextBox.Text;
            consumable.textureName = imageFileTextBox.Text;
            consumable.HP = int.Parse(HPTextBox.Text);
            consumable.MP = int.Parse(MPTextBox.Text);
            consumable.regenHP = int.Parse(HPRegenTextBox.Text);
            consumable.regenMP = int.Parse(MPRegenTextBox.Text);
            consumable.Resurrect = reviveComboBox.Text;
            consumable.life = int.Parse(lifeTextBox.Text);

            if (existingConsumableComboBox.SelectedItem == null)
            {
                consumableList.Add(consumable.name, consumable);
                existingConsumableComboBox.Items.Add(consumable.name);
                existingConsumableComboBox.SelectedItem = consumable.name;
                consumable = new Consumable();
            }
            else
            {
                if (existingConsumableComboBox.Text != consumable.name)
                {
                    consumableList.Add(consumable.name, consumable);
                    consumableList.Remove(existingConsumableComboBox.Text);
                    existingConsumableComboBox.Items.Remove(existingConsumableComboBox.SelectedItem);
                    existingConsumableComboBox.Items.Add(consumable.name);
                    existingConsumableComboBox.SelectedItem = consumable.name;
                }

                else
                    consumableList[consumable.name] = consumable;

                consumable = new Consumable();
            }

            XmlDocument doc = new XmlDocument();

            XmlElement rootElement = doc.CreateElement("Consumables");
            doc.AppendChild(rootElement);

            foreach (Consumable con in consumableList.Values)
            {
                XmlElement consumableElement = doc.CreateElement("Consumable");
                rootElement.AppendChild(consumableElement);
                XmlAttribute wAttr = doc.CreateAttribute("Name");
                wAttr.Value = con.name;
                consumableElement.Attributes.Append(wAttr);
                XmlElement textureElement = doc.CreateElement("Image");
                consumableElement.AppendChild(textureElement);
                XmlAttribute tAttr = doc.CreateAttribute("Texture");
                tAttr.Value = con.textureName.Replace(contentPath + "\\", "");
                textureElement.Attributes.Append(tAttr);
                XmlElement HPElement = doc.CreateElement("HP");
                consumableElement.AppendChild(HPElement);
                XmlAttribute HPAttr = doc.CreateAttribute("Value");
                HPAttr.Value = con.HP.ToString();
                HPElement.Attributes.Append(HPAttr);
                XmlElement MPElement = doc.CreateElement("MP");
                consumableElement.AppendChild(MPElement);
                XmlAttribute MPAttr = doc.CreateAttribute("Value");
                MPAttr.Value = con.MP.ToString();
                MPElement.Attributes.Append(MPAttr);
                XmlElement RegenHPElement = doc.CreateElement("RegenHP");
                consumableElement.AppendChild(RegenHPElement);
                XmlAttribute RegenHPAttr = doc.CreateAttribute("Value");
                RegenHPAttr.Value = con.regenHP.ToString();
                RegenHPElement.Attributes.Append(RegenHPAttr);
                XmlElement RegenMPElement = doc.CreateElement("RegenMP");
                consumableElement.AppendChild(RegenMPElement);
                XmlAttribute RegenMPAttr = doc.CreateAttribute("Value");
                RegenMPAttr.Value = con.regenMP.ToString();
                RegenMPElement.Attributes.Append(RegenMPAttr);
                XmlElement ResurrectElement = doc.CreateElement("Resurrect");
                consumableElement.AppendChild(ResurrectElement);
                XmlAttribute ResAttr = doc.CreateAttribute("Value");
                ResAttr.Value = con.Resurrect;
                ResurrectElement.Attributes.Append(ResAttr);
                XmlElement lifeElement = doc.CreateElement("Life");
                consumableElement.AppendChild(lifeElement);
                XmlAttribute lifeAttr = doc.CreateAttribute("Value");
                lifeAttr.Value = con.life.ToString();
                lifeElement.Attributes.Append(lifeAttr);              
            }            
            doc.Save(contentPath + "\\" + "Consumables.item");
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            consumableList.Remove(existingConsumableComboBox.Text);
            existingConsumableComboBox.Items.Remove(existingConsumableComboBox.SelectedItem);
            Clear();
        }

        private void imageFileTextBox_TextChanged(object sender, EventArgs e)
        {
            if (imageFileTextBox.Text.Length > contentPath.Length + 1)
                consumablePictureBox.Image = Image.FromFile(imageFileTextBox.Text.ToString());
            else
                consumablePictureBox.Image = null;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                imageFileTextBox.Text = openFileDialog1.FileName;
        }

        private void existingConsumableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (existingConsumableComboBox.SelectedItem != null)
            {
                Clear();
                string existingConsumable = existingConsumableComboBox.SelectedItem.ToString();
                imageFileTextBox.Text = consumableList[existingConsumable].textureName;
                nameTextBox.Text = consumableList[existingConsumable].name;
                HPTextBox.Text = consumableList[existingConsumable].HP.ToString();
                MPTextBox.Text = consumableList[existingConsumable].MP.ToString();
                HPRegenTextBox.Text = consumableList[existingConsumable].regenHP.ToString();
                MPRegenTextBox.Text = consumableList[existingConsumable].regenMP.ToString();
                reviveComboBox.Text = consumableList[existingConsumable].Resurrect;
                lifeTextBox.Text = consumableList[existingConsumable].life.ToString();
            }
        }
    }
}
