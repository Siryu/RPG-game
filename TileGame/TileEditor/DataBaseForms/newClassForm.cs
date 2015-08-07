using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using TileEngine;

namespace TileEditor
{
    public partial class newClassForm : Form
    {
        string contentPath = Form1.cP.Text;

        PlayerClass playerClass = new PlayerClass();
        Dictionary<String, PlayerClass> playerClassList = new Dictionary<String, PlayerClass>();
        List<Skills> skills = new List<Skills>();
        List<Spells> spells = new List<Spells>();
        List<Weapon> weapons = new List<Weapon>();
        List<Armor> armors = new List<Armor>();

        public newClassForm()
        {
            InitializeComponent();
            loadCheckBoxes();
            loadData();
        }

        private void Clear()
        {
            classNameTextBox.Text = null;
            strTextBox.Text = null;
            dexTextBox.Text = null;
            agiTextBox.Text = null;
            staTextBox.Text = null;

            heavyCheckBox.Checked = false;
            mediumCheckBox.Checked = false;
            lightCheckBox.Checked = false;
            leatherCheckBox.Checked = false;
            clothCheckBox.Checked = false;

            swordCheckBox1.Checked = false;
            swordCheckBox2.Checked = false;
            daggerCheckBox.Checked = false;
            staffCheckBox.Checked = false;
            axeCheckBox1.Checked = false;
            axeCheckBox2.Checked = false;
            bowCheckBox.Checked = false;
            harpCheckBox.Checked = false;

            foreach (CheckBox chk in skillPanel.Controls)
                chk.Checked = false;
            foreach (CheckBox chk in spellPanel.Controls)
                chk.Checked = false;     
        }

        private void loadData()
        {
            XmlTextReader reader = new XmlTextReader(contentPath + "\\Classes.item");
            reader.WhitespaceHandling = WhitespaceHandling.None;

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "PlayerClass")
                        playerClass.name = reader["Name"];
                    if (reader.Name == "Armor")
                    {
                        reader.MoveToAttribute("type");
                        string[] eachArmor = reader.Value.Split(',');
                        foreach (string s in eachArmor)
                            playerClass.equippableArmors.Add(s);
                    }
                    if (reader.Name == "Weapon")
                    {
                        reader.MoveToAttribute("type");
                        string[] eachWeapon = reader.Value.Split(',');
                        foreach (string s in eachWeapon)
                            playerClass.equippableWeapons.Add(s);
                    }

                    if (reader.Name == "Str")
                        playerClass.str = int.Parse(reader.ReadInnerXml());
                    if (reader.Name == "Dex")
                        playerClass.dex = int.Parse(reader.ReadInnerXml());
                    if (reader.Name == "Agi")
                        playerClass.agi = int.Parse(reader.ReadInnerXml());
                    if (reader.Name == "Sta")
                        playerClass.sta = int.Parse(reader.ReadInnerXml());

                    if (reader.Name == "Skill")
                        playerClass.skills.Add(reader.ReadInnerXml());
                    if (reader.Name == "Spell")
                        playerClass.spells.Add(reader.ReadInnerXml());
                }


                else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "PlayerClass")
                {
                    playerClassList.Add(playerClass.name, playerClass);
                    existingClassComboBox.Items.Add(playerClass.name);
                    playerClass = new PlayerClass();
                }
            }
            reader.Close();
        }

        private void loadCheckBoxes()
        {
            int topPosition = 0;
            Skills sk = new Skills();
            Spells sp = new Spells();
            Weapon wea = new Weapon();
            Armor arm = new Armor();

            XmlTextReader reader = new XmlTextReader(contentPath + "\\skills.item");
            reader.WhitespaceHandling = WhitespaceHandling.None;

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "Skill")
                    {
                        sk.name = reader["name"];
                        skills.Add(sk);
                        sk = new Skills();
                    }
                }
            }
            reader.Close();
            reader = new XmlTextReader(contentPath + "\\Spells.item");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "Spell")
                    {
                        sp.name = reader["name"];
                        spells.Add(sp);
                        sp = new Spells();
                    }
                }
            }
            reader.Close();

            this.SuspendLayout();

            foreach (Skills skill in skills)
            {
                CheckBox checkbox = new CheckBox();
                checkbox.Top = topPosition;
                checkbox.Left = 0;
                checkbox.Text = skill.name;
                checkbox.Name = skill.name;
                topPosition += 23;

                skillPanel.Controls.Add(checkbox);
            }

            topPosition = 0;
            foreach (Spells spell in spells)
            {
                CheckBox checkbox = new CheckBox();
                checkbox.Top = topPosition;
                checkbox.Left = 0;
                checkbox.Text = spell.name;
                checkbox.Name = spell.name;
                topPosition += 23;

                spellPanel.Controls.Add(checkbox);
            }

            this.ResumeLayout();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            existingClassComboBox.SelectedItem = null;
            Clear();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            playerClassList.Remove(existingClassComboBox.Text);
            existingClassComboBox.Items.Remove(existingClassComboBox.SelectedItem);
            Clear();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (classNameTextBox.Text.Length < 1 || strTextBox.Text.Length < 1 ||
                dexTextBox.Text.Length < 1 || agiTextBox.Text.Length < 1 ||
                staTextBox.Text.Length < 1)
            {
                MessageBox.Show("Not All Fields Have Values");
                return;
            }

            playerClass.name = classNameTextBox.Text;

            if (heavyCheckBox.Checked)
                playerClass.equippableArmors.Add("Heavy");
            if (mediumCheckBox.Checked)
                playerClass.equippableArmors.Add("Medium");
            if (lightCheckBox.Checked)
                playerClass.equippableArmors.Add("Light");
            if (leatherCheckBox.Checked)
                playerClass.equippableArmors.Add("Leather");
            if (clothCheckBox.Checked)
                playerClass.equippableArmors.Add("Cloth");

            if (swordCheckBox1.Checked)
                playerClass.equippableWeapons.Add("1H Sword");
            if (swordCheckBox2.Checked)
                playerClass.equippableWeapons.Add("2H Sword");
            if (daggerCheckBox.Checked)
                playerClass.equippableWeapons.Add("Dagger");
            if (staffCheckBox.Checked)
                playerClass.equippableWeapons.Add("Staff");
            if (axeCheckBox1.Checked)
                playerClass.equippableWeapons.Add("1H Axe");
            if (axeCheckBox2.Checked)
                playerClass.equippableWeapons.Add("2H Axe");
            if (bowCheckBox.Checked)
                playerClass.equippableWeapons.Add("Bow");
            if (harpCheckBox.Checked)
                playerClass.equippableWeapons.Add("Harp");
            
            playerClass.str = int.Parse(strTextBox.Text);
            playerClass.dex = int.Parse(dexTextBox.Text);
            playerClass.agi = int.Parse(agiTextBox.Text);
            playerClass.sta = int.Parse(staTextBox.Text);

            foreach (CheckBox chk in skillPanel.Controls)
            {
                if (chk.Checked)
                    playerClass.skills.Add(chk.Name);
            }

            foreach (CheckBox chk in spellPanel.Controls)
            {
                if (chk.Checked)
                        playerClass.spells.Add(chk.Name);
            }

            if (existingClassComboBox.SelectedItem == null)
            {
                playerClassList.Add(playerClass.name, playerClass);
                existingClassComboBox.Items.Add(playerClass.name);
                existingClassComboBox.SelectedItem = playerClass.name;
            }
            else
            {
                if (existingClassComboBox.Text != playerClass.name)
                {
                    playerClassList.Add(playerClass.name, playerClass);
                    playerClassList.Remove(existingClassComboBox.Text);
                    existingClassComboBox.Items.Remove(existingClassComboBox.SelectedItem);
                    existingClassComboBox.Items.Add(playerClass.name);
                    existingClassComboBox.SelectedItem = playerClass.name;
                }

                else
                    playerClassList[playerClass.name] = playerClass;
            }

            playerClass = new PlayerClass();

            XmlDocument doc = new XmlDocument();

            XmlElement rootElement = doc.CreateElement("PlayerClasses");
            doc.AppendChild(rootElement);

            foreach (PlayerClass pc in playerClassList.Values)
            {
                XmlElement playerClassElement = doc.CreateElement("PlayerClass");
                rootElement.AppendChild(playerClassElement);
                XmlAttribute pcAttr = doc.CreateAttribute("Name");
                pcAttr.Value = pc.name;
                playerClassElement.Attributes.Append(pcAttr);
                XmlElement armorElement = doc.CreateElement("Armor");
                playerClassElement.AppendChild(armorElement);
                XmlAttribute atAttr = doc.CreateAttribute("type");
                foreach (string ar in pc.equippableArmors)
                {
                    atAttr.Value += ar + ",";
                }
                armorElement.Attributes.Append(atAttr);
                XmlElement weaponElement = doc.CreateElement("Weapon");
                playerClassElement.AppendChild(weaponElement);
                XmlAttribute wtAttr = doc.CreateAttribute("type");
                foreach (string we in pc.equippableWeapons)
                {
                    wtAttr.Value += we + ",";
                }
                weaponElement.Attributes.Append(wtAttr);

                XmlElement attribElement = doc.CreateElement("Attributes");
                playerClassElement.AppendChild(attribElement);
                XmlElement strElement = doc.CreateElement("Str");
                strElement.InnerText = pc.str.ToString();
                attribElement.AppendChild(strElement);
                XmlElement dexElement = doc.CreateElement("Dex");
                dexElement.InnerText = pc.dex.ToString();
                attribElement.AppendChild(dexElement);
                XmlElement agiElement = doc.CreateElement("Agi");
                agiElement.InnerText = pc.agi.ToString();
                attribElement.AppendChild(agiElement);
                XmlElement staElement = doc.CreateElement("Sta");
                staElement.InnerText = pc.sta.ToString();
                attribElement.AppendChild(staElement);

                XmlElement skillsElement = doc.CreateElement("Skills");
                playerClassElement.AppendChild(skillsElement);
                foreach (string skill in pc.skills)
                {
                    XmlElement skillElement = doc.CreateElement("Skill");
                    skillElement.InnerText = skill;
                    skillsElement.AppendChild(skillElement);
                }
                XmlElement magicElement = doc.CreateElement("Magic");
                playerClassElement.AppendChild(magicElement);
                foreach (string spell in pc.spells)
                {
                    XmlElement spellElement = doc.CreateElement("Spell");
                    spellElement.InnerText = spell;
                    magicElement.AppendChild(spellElement);
                }

            }
            doc.Save(contentPath + "\\" + "Classes.item");
        }

        private void existingClassComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (existingClassComboBox.SelectedItem != null)
            {
                Clear();
                classNameTextBox.Text = playerClassList[existingClassComboBox.Text].name;

                strTextBox.Text = playerClassList[existingClassComboBox.Text].str.ToString();
                dexTextBox.Text = playerClassList[existingClassComboBox.Text].dex.ToString();
                agiTextBox.Text = playerClassList[existingClassComboBox.Text].agi.ToString();
                staTextBox.Text = playerClassList[existingClassComboBox.Text].sta.ToString();

                if (playerClassList[existingClassComboBox.Text].equippableArmors.Contains("Heavy"))
                    heavyCheckBox.Checked = true;
                if (playerClassList[existingClassComboBox.Text].equippableArmors.Contains("Medium"))
                    mediumCheckBox.Checked = true;
                if (playerClassList[existingClassComboBox.Text].equippableArmors.Contains("Light"))
                    lightCheckBox.Checked = true;
                if (playerClassList[existingClassComboBox.Text].equippableArmors.Contains("Leather"))
                    leatherCheckBox.Checked = true;
                if (playerClassList[existingClassComboBox.Text].equippableArmors.Contains("Cloth"))
                    clothCheckBox.Checked = true;

                if (playerClassList[existingClassComboBox.Text].equippableWeapons.Contains("1H Sword"))
                    swordCheckBox1.Checked = true;
                if (playerClassList[existingClassComboBox.Text].equippableWeapons.Contains("2H Sword"))
                    swordCheckBox2.Checked = true;
                if (playerClassList[existingClassComboBox.Text].equippableWeapons.Contains("Dagger"))
                    daggerCheckBox.Checked = true;
                if (playerClassList[existingClassComboBox.Text].equippableWeapons.Contains("Staff"))
                    staffCheckBox.Checked = true;
                if (playerClassList[existingClassComboBox.Text].equippableWeapons.Contains("1H Axe"))
                    axeCheckBox1.Checked = true;
                if (playerClassList[existingClassComboBox.Text].equippableWeapons.Contains("2H Axe"))
                    axeCheckBox2.Checked = true;
                if (playerClassList[existingClassComboBox.Text].equippableWeapons.Contains("Bow"))
                    bowCheckBox.Checked = true;
                if (playerClassList[existingClassComboBox.Text].equippableWeapons.Contains("Harp"))
                    harpCheckBox.Checked = true;

                if (skillPanel.Controls.Count > 0)
                {
                    foreach (CheckBox chk in skillPanel.Controls)
                    {
                        if (playerClassList[existingClassComboBox.Text].skills.Count > 0)
                        {
                            foreach (string skill in playerClassList[existingClassComboBox.Text].skills)
                            {
                                if (chk.Name == skill)
                                    chk.Checked = true;                              
                            }
                        }
                    }
                }

                if (spellPanel.Controls.Count > 0)
                {
                    foreach (CheckBox chk in spellPanel.Controls)
                    {
                        if (playerClassList[existingClassComboBox.Text].spells.Count > 0)
                        {
                            foreach (string spell in playerClassList[existingClassComboBox.Text].spells)
                            {
                                if (chk.Name == spell)
                                    chk.Checked = true;
                            }
                        }                      
                    }
                }            
            }
        }
    }
}
