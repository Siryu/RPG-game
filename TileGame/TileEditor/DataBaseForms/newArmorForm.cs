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
    public partial class newArmorForm : Form
    {
        Armor armor = new Armor();
        Dictionary<String, Armor> armorList = new Dictionary<String, Armor>();
        string contentPath = Form1.cP.Text;

        public newArmorForm()
        {
            InitializeComponent();
            loadDefaultBoxData();
            loadData();                       
        }

        private void loadDefaultBoxData()
        {
            typeComboBox.Items.Add("Helm");
            typeComboBox.Items.Add("Chest");
            typeComboBox.Items.Add("Legs");
            typeComboBox.Items.Add("Hands");
            typeComboBox.Items.Add("Feet");
            typeComboBox.Items.Add("Cape");

            defenseTypeComboBox.Items.Add("Physical");

            specialAbilityComboBox.Items.Add("");
        }

        private void Clear()
        {
            imageFileTextBox.Text = null;
            armorNameTextBox.Text = null;
            heavyCheckBox.Checked = false;
            mediumCheckBox.Checked = false;
            lightCheckBox.Checked = false;
            leatherCheckBox.Checked = false;
            clothCheckBox.Checked = false;
            defenseTextBox.Text = null;
            typeComboBox.Text = null;
            strTextBox.Text = null;
            dexListBox.Text = null;
            agiTextBox.Text = null;
            staTextBox.Text = null;
            defenseTypeComboBox.SelectedItem = null;
            specialAbilityComboBox.SelectedItem = null;
        }

        private void loadData()
        {
            XmlTextReader reader = new XmlTextReader(contentPath + "\\Armors.item");
            reader.WhitespaceHandling = WhitespaceHandling.None;

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "Armor")
                    {
                        armor.name = reader["Name"];
                        armor.type = reader["Type"];
                    }
                    if (reader.Name == "Equip")
                    {
                        reader.MoveToFirstAttribute();
                        string[] eachClass = reader.Value.Split(' ');
                        foreach(string s in eachClass)
                            if (!s.Contains(" "))
                                armor.equipClass.Add(s);
                    }
                    if (reader.Name == "Image")
                        armor.textureName = contentPath + "\\" + reader["Texture"];
                    if (reader.Name == "Def")
                        armor.def = int.Parse(reader.ReadInnerXml());
                    if (reader.Name == "Str")
                        armor.strbonus = int.Parse(reader.ReadInnerXml());
                    if (reader.Name == "Dex")
                        armor.dexbonus = int.Parse(reader.ReadInnerXml());
                    if (reader.Name == "Agi")
                        armor.agibonus = int.Parse(reader.ReadInnerXml());
                    if (reader.Name == "Sta")
                        armor.stabonus = int.Parse(reader.ReadInnerXml());
                    if (reader.Name == "DefenseType")
                        armor.defenseType = reader.ReadInnerXml();
                }


                else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "Armor")
                {
                    armorList.Add(armor.name, armor);
                    existingArmorComboBox.Items.Add(armor.name);
                    armor = new Armor();
                }
            }
            reader.Close();
        }

        private void existingArmorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (existingArmorComboBox.SelectedItem != null)
            {
                Clear();
                string existingArmor = existingArmorComboBox.SelectedItem.ToString();
                imageFileTextBox.Text = armorList[existingArmor].textureName;
                armorNameTextBox.Text = armorList[existingArmor].name;
                defenseTextBox.Text = armorList[existingArmor].def.ToString();
                typeComboBox.Text = armorList[existingArmor].type;
                strTextBox.Text = armorList[existingArmor].strbonus.ToString();
                dexListBox.Text = armorList[existingArmor].dexbonus.ToString();
                agiTextBox.Text = armorList[existingArmor].agibonus.ToString();
                staTextBox.Text = armorList[existingArmor].stabonus.ToString();
                defenseTypeComboBox.SelectedItem = armorList[existingArmor].defenseType;
                specialAbilityComboBox.SelectedItem = armorList[existingArmor].specialAbility;
                if (armorList[existingArmor].equipClass.Contains("Heavy"))
                    heavyCheckBox.Checked = true;
                if (armorList[existingArmor].equipClass.Contains("Medium"))
                    mediumCheckBox.Checked = true;
                if (armorList[existingArmor].equipClass.Contains("Light"))
                    lightCheckBox.Checked = true;
                if (armorList[existingArmor].equipClass.Contains("Leather"))
                    leatherCheckBox.Checked = true;
                if (armorList[existingArmor].equipClass.Contains("Cloth"))
                    clothCheckBox.Checked = true;
            }
        }

        private void imageFileTextBox_TextChanged(object sender, EventArgs e)
        {
            if (imageFileTextBox.Text.Length > contentPath.Length + 1)
                armorPictureBox.Image = Image.FromFile(imageFileTextBox.Text.ToString());
            else
                armorPictureBox.Image = null;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                imageFileTextBox.Text = openFileDialog1.FileName;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            existingArmorComboBox.SelectedItem = null;
            Clear();
        }
        
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (defenseTextBox.Text.Length < 1 || strTextBox.Text.Length < 1 ||
                    dexListBox.Text.Length < 1 || agiTextBox.Text.Length < 1 || staTextBox.Text.Length < 1 ||
                    imageFileTextBox.Text.Length < contentPath.Length + 1)
            {
                MessageBox.Show("Not All Fields Have Values");
                return;
            }

            armor.name = armorNameTextBox.Text;
            armor.type = typeComboBox.Text;
            if (heavyCheckBox.Checked)
                armor.equipClass.Add("Heavy");
            if (mediumCheckBox.Checked)
                armor.equipClass.Add("Medium");
            if (lightCheckBox.Checked)
                armor.equipClass.Add("Light");
            if (leatherCheckBox.Checked)
                armor.equipClass.Add("Leather");
            if (clothCheckBox.Checked)
                armor.equipClass.Add("Cloth");         
            armor.textureName = imageFileTextBox.Text;
            armor.def = int.Parse(defenseTextBox.Text);
            armor.strbonus = int.Parse(strTextBox.Text);
            armor.dexbonus = int.Parse(dexListBox.Text);
            armor.agibonus = int.Parse(agiTextBox.Text);
            armor.stabonus = int.Parse(staTextBox.Text);
            armor.defenseType = defenseTypeComboBox.Text;
            armor.specialAbility = specialAbilityComboBox.Text;

            if (existingArmorComboBox.SelectedItem == null)
            {
                armorList.Add(armor.name, armor);
                existingArmorComboBox.Items.Add(armor.name);
                existingArmorComboBox.SelectedItem = armor.name;
                armor = new Armor();
            }
            else
            {
                if (existingArmorComboBox.Text != armor.name)
                {
                    armorList.Add(armor.name, armor);
                    armorList.Remove(existingArmorComboBox.Text);
                    existingArmorComboBox.Items.Remove(existingArmorComboBox.SelectedItem);
                    existingArmorComboBox.Items.Add(armor.name);
                    existingArmorComboBox.SelectedItem = armor.name;
                }

                else
                    armorList[armor.name] = armor;

                armor = new Armor();
            }

            XmlDocument doc = new XmlDocument();

            XmlElement rootElement = doc.CreateElement("Armors");
            doc.AppendChild(rootElement);

            Dictionary<int, Armor> sortList = new Dictionary<int, Armor>();
            foreach (Armor weap in armorList.Values)
            {
                int wpn = 1;
                foreach (Armor wepn in armorList.Values)
                {
                    if (weap == wepn)
                        continue;
                    if (weap.def >= wepn.def)
                        wpn++;
                }
                while (sortList.ContainsKey(wpn))
                    wpn--;
                sortList.Add(wpn, weap);
            }


            for (int wep = 1; wep <= sortList.Keys.Count; wep++)
            {
                Armor wea = sortList[wep];
                {
                    XmlElement armorElement = doc.CreateElement("Armor");
                    rootElement.AppendChild(armorElement);
                    XmlAttribute wAttr = doc.CreateAttribute("Name");
                    wAttr.Value = wea.name;
                    XmlAttribute wAttr2 = doc.CreateAttribute("Type");
                    wAttr2.Value = wea.type;
                    armorElement.Attributes.Append(wAttr);
                    armorElement.Attributes.Append(wAttr2);
                    XmlElement equipElement = doc.CreateElement("Equip");
                    armorElement.AppendChild(equipElement);
                    XmlAttribute eAttr = doc.CreateAttribute("Class");
                    foreach (string eq in wea.equipClass)
                    {
                        eAttr.Value += eq + " ";
                    }
                    equipElement.Attributes.Append(eAttr);
                    XmlElement textureElement = doc.CreateElement("Image");
                    armorElement.AppendChild(textureElement);
                    XmlAttribute tAttr = doc.CreateAttribute("Texture");
                    tAttr.Value = wea.textureName.Replace(contentPath + "\\", "");
                    textureElement.Attributes.Append(tAttr);
                    XmlElement defElement = doc.CreateElement("Def");
                    defElement.InnerText = wea.def.ToString();
                    armorElement.AppendChild(defElement);

                    XmlElement attribbonusElement = doc.CreateElement("AttribBonus");
                    armorElement.AppendChild(attribbonusElement);
                    XmlElement strElement = doc.CreateElement("Str");
                    strElement.InnerText = wea.strbonus.ToString();
                    attribbonusElement.AppendChild(strElement);
                    XmlElement dexElement = doc.CreateElement("Dex");
                    dexElement.InnerText = wea.dexbonus.ToString();
                    attribbonusElement.AppendChild(dexElement);
                    XmlElement agiElement = doc.CreateElement("Agi");
                    agiElement.InnerText = wea.agibonus.ToString();
                    attribbonusElement.AppendChild(agiElement);
                    XmlElement staElement = doc.CreateElement("Sta");
                    staElement.InnerText = wea.stabonus.ToString();
                    attribbonusElement.AppendChild(staElement);

                    XmlElement dType = doc.CreateElement("DefenseType");
                    dType.InnerText = wea.defenseType;
                    armorElement.AppendChild(dType);
                    XmlElement special = doc.CreateElement("Special");
                    special.InnerText = wea.specialAbility;
                    armorElement.AppendChild(special);
                }
            }
            doc.Save(contentPath + "\\" + "Armors.item");
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            armorList.Remove(existingArmorComboBox.Text);
            existingArmorComboBox.Items.Remove(existingArmorComboBox.SelectedItem);
            Clear();
        }
    }
}
