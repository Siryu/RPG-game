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
    public partial class newWeaponForm : Form
    {
        Weapon weapon = new Weapon();
        Dictionary<String, Weapon> weaponList = new Dictionary<String, Weapon>();
        string contentPath = Form1.cP.Text;

        public newWeaponForm()
        {
            InitializeComponent();
            loadDefaultBoxData();
            loadData();                       
        }

        private void loadDefaultBoxData()
        {
            typeComboBox.Items.Add("1H Sword");
            typeComboBox.Items.Add("2H Sword");
            typeComboBox.Items.Add("Dagger");
            typeComboBox.Items.Add("Staff");
            typeComboBox.Items.Add("1H Axe");
            typeComboBox.Items.Add("2H Axe");
            typeComboBox.Items.Add("Bow");
            typeComboBox.Items.Add("Harp");

            damageTypeComboBox.Items.Add("Physical");

            specialAbilityComboBox.Items.Add("");
            specialAbilityComboBox.Items.Add("Vs. Undead");
        }

        private void Clear()
        {
            imageFileTextBox.Text = null;
            weaponNameTextBox.Text = null;
            classesTextBox.Text = null;
            attackDamageTextBox.Text = null;
            accuracyTextBox.Text = null;
            parryTextBox.Text = null;
            typeComboBox.Text = null;
            strTextBox.Text = null;
            dexListBox.Text = null;
            agiTextBox.Text = null;
            staTextBox.Text = null;
            damageTypeComboBox.SelectedItem = null;
            specialAbilityComboBox.SelectedItem = null;
        }

        private void loadData()
        {
            XmlTextReader reader = new XmlTextReader(contentPath + "\\Weapons.item");
            reader.WhitespaceHandling = WhitespaceHandling.None;

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "Weapon")
                    {
                        weapon.name = reader["Name"];
                        weapon.type = reader["Type"];
                    }
                    if (reader.Name == "Equip")
                    {
                        reader.MoveToFirstAttribute();
                        string[] eachClass = reader.Value.Split(' ');
                        foreach(string s in eachClass)
                            if (!s.Contains(" "))
                            weapon.equipClass.Add(s);
                    }
                    if (reader.Name == "Image")
                        weapon.textureName = contentPath + "\\" + reader["Texture"];
                    if (reader.Name == "Attack")
                        weapon.attack = int.Parse(reader.ReadInnerXml());
                    if (reader.Name == "Acc")
                        weapon.acc = int.Parse(reader.ReadInnerXml());
                    if (reader.Name == "Parry")
                        weapon.parry = int.Parse(reader.ReadInnerXml());
                    if (reader.Name == "Str")
                        weapon.strbonus = int.Parse(reader.ReadInnerXml());
                    if (reader.Name == "Dex")
                        weapon.dexbonus = int.Parse(reader.ReadInnerXml());
                    if (reader.Name == "Agi")
                        weapon.agibonus = int.Parse(reader.ReadInnerXml());
                    if (reader.Name == "Sta")
                        weapon.stabonus = int.Parse(reader.ReadInnerXml());
                    if (reader.Name == "DamageType")
                        weapon.damageType = reader.ReadInnerXml();
                }


                else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "Weapon")
                {
                    weaponList.Add(weapon.name, weapon);
                    existingWeaponComboBox.Items.Add(weapon.name);
                    weapon = new Weapon();
                }
            }
            reader.Close();
        }

        private void existingWeaponComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (existingWeaponComboBox.SelectedItem != null)
            {
                Clear();
                string existingWeapon = existingWeaponComboBox.SelectedItem.ToString(); 
                classesTextBox.Text = "";
                imageFileTextBox.Text = weaponList[existingWeapon].textureName;
                weaponNameTextBox.Text = weaponList[existingWeapon].name;
                foreach (string c in weaponList[existingWeapon].equipClass)
                    classesTextBox.Text += c + " ";
                attackDamageTextBox.Text = weaponList[existingWeapon].attack.ToString();
                accuracyTextBox.Text = weaponList[existingWeapon].acc.ToString();
                parryTextBox.Text = weaponList[existingWeapon].parry.ToString();
                typeComboBox.Text = weaponList[existingWeapon].type;
                strTextBox.Text = weaponList[existingWeapon].strbonus.ToString();
                dexListBox.Text = weaponList[existingWeapon].dexbonus.ToString();
                agiTextBox.Text = weaponList[existingWeapon].agibonus.ToString();
                staTextBox.Text = weaponList[existingWeapon].stabonus.ToString();
                damageTypeComboBox.SelectedItem = weaponList[existingWeapon].damageType;
                specialAbilityComboBox.SelectedItem = weaponList[existingWeapon].specialAbility;
            }
        }

        private void imageFileTextBox_TextChanged(object sender, EventArgs e)
        {
            if (imageFileTextBox.Text.Length > contentPath.Length + 1)
                weaponPictureBox.Image = Image.FromFile(imageFileTextBox.Text.ToString());
            else
                weaponPictureBox.Image = null;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                imageFileTextBox.Text = openFileDialog1.FileName;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            existingWeaponComboBox.SelectedItem = null;
            Clear();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if ( attackDamageTextBox.Text.Length < 1 || accuracyTextBox.Text.Length < 1  ||
                parryTextBox.Text.Length < 1 || strTextBox.Text.Length < 1 ||
                dexListBox.Text.Length < 1 || agiTextBox.Text.Length < 1 ||
                staTextBox.Text.Length < 1 || imageFileTextBox.Text.Length < contentPath.Length + 1)
            {
                MessageBox.Show("Not All Fields Have Values");
                return;
            }

            weapon.name = weaponNameTextBox.Text;
            weapon.type = typeComboBox.Text;
            string[] eachClass = classesTextBox.Text.Split(' ');
            foreach (string c in eachClass)
                weapon.equipClass.Add(c);
            weapon.textureName = imageFileTextBox.Text;
            weapon.attack = int.Parse(attackDamageTextBox.Text);
            weapon.acc = int.Parse(accuracyTextBox.Text);
            weapon.parry = int.Parse(parryTextBox.Text);
            weapon.strbonus = int.Parse(strTextBox.Text);
            weapon.dexbonus = int.Parse(dexListBox.Text);
            weapon.agibonus = int.Parse(agiTextBox.Text);
            weapon.stabonus = int.Parse(staTextBox.Text);
            weapon.damageType = damageTypeComboBox.Text;
            weapon.specialAbility = specialAbilityComboBox.Text;

            if (existingWeaponComboBox.SelectedItem == null)
            {
                weaponList.Add(weapon.name, weapon);
                existingWeaponComboBox.Items.Add(weapon.name);
                existingWeaponComboBox.SelectedItem = weapon.name;
                weapon = new Weapon();
            }
            else
            {
                if (existingWeaponComboBox.Text != weapon.name)
                {
                    weaponList.Add(weapon.name, weapon);
                    weaponList.Remove(existingWeaponComboBox.Text);
                    existingWeaponComboBox.Items.Remove(existingWeaponComboBox.SelectedItem);
                    existingWeaponComboBox.Items.Add(weapon.name);
                    existingWeaponComboBox.SelectedItem = weapon.name;
                }

                else
                    weaponList[weapon.name] = weapon;

                weapon = new Weapon();
            }
            
            XmlDocument doc = new XmlDocument();

            XmlElement rootElement = doc.CreateElement("Weapons");
            doc.AppendChild(rootElement);

            Dictionary<int, Weapon> sortList = new Dictionary<int, Weapon>();
            foreach (Weapon weap in weaponList.Values)
            {
                int wpn = 1;
                foreach (Weapon wepn in weaponList.Values)
                {
                    if (weap == wepn)
                        continue;
                    if (weap.attack >= wepn.attack)
                        wpn++;
                }
                while (sortList.ContainsKey(wpn))
                    wpn--;
                sortList.Add(wpn, weap);
            }


            for (int wep = 1; wep <= sortList.Keys.Count; wep++)
            {
                Weapon wea = sortList[wep];
                {
                XmlElement weaponElement = doc.CreateElement("Weapon");
                rootElement.AppendChild(weaponElement);
                XmlAttribute wAttr = doc.CreateAttribute("Name");
                wAttr.Value = wea.name;
                XmlAttribute wAttr2 = doc.CreateAttribute("Type");
                wAttr2.Value = wea.type;
                weaponElement.Attributes.Append(wAttr);
                weaponElement.Attributes.Append(wAttr2);
                XmlElement equipElement = doc.CreateElement("Equip");
                weaponElement.AppendChild(equipElement);
                XmlAttribute eAttr = doc.CreateAttribute("Class");
                foreach (string eq in wea.equipClass)
                {
                    eAttr.Value += eq + " ";
                }
                equipElement.Attributes.Append(eAttr);
                XmlElement textureElement = doc.CreateElement("Image");
                weaponElement.AppendChild(textureElement);
                XmlAttribute tAttr = doc.CreateAttribute("Texture");
                tAttr.Value = wea.textureName.Replace(contentPath + "\\", "");
                textureElement.Attributes.Append(tAttr);
                XmlElement attackElement = doc.CreateElement("Attack");
                attackElement.InnerText = wea.attack.ToString();
                weaponElement.AppendChild(attackElement);

                XmlElement accElement = doc.CreateElement("Acc");
                accElement.InnerText = wea.acc.ToString();
                weaponElement.AppendChild(accElement);
                XmlElement parryElement = doc.CreateElement("Parry");
                parryElement.InnerText = wea.parry.ToString();
                weaponElement.AppendChild(parryElement);

                XmlElement attribbonusElement = doc.CreateElement("AttribBonus");
                weaponElement.AppendChild(attribbonusElement);
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

                XmlElement dType = doc.CreateElement("DamageType");
                dType.InnerText = wea.damageType;
                weaponElement.AppendChild(dType);
                XmlElement special = doc.CreateElement("Special");
                special.InnerText = wea.specialAbility;
                weaponElement.AppendChild(special);
                }
            }
            doc.Save(contentPath + "\\" + "Weapons.item");
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            weaponList.Remove(existingWeaponComboBox.Text);
            existingWeaponComboBox.Items.Remove(existingWeaponComboBox.SelectedItem);
            Clear();
        } 
    }
}
