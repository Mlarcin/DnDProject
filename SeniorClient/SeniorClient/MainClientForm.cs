using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace SeniorClient
{
    public partial class MainClientForm : Form
    {
        Character myCharacter;

        SpellBook clientSpell = new SpellBook(true);
        SpellBook clientCantrip = new SpellBook(false);

        private Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        byte[] recieveBuffer = new byte[1024];

        /**/
        /*
        

        NAME

            MainClientForm::MainClientForm - Constructor for MainClientForm


        SYNOPSIS

            public MainClientForm(Character theChar)

            Character theChar -> Character passed in from previous form, used to initialize myCharacter
                
        DESCRIPTION

            Constructor for MainClientForm
            -Call InitializeComponent
            -Set myCharacter to theChar
            -Call updateForm
            -Set CheckForIllegalCrossThreadCalls to false

        RETURNS

            NA, constructor

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public MainClientForm(Character theChar)
        {
            InitializeComponent();
            myCharacter = theChar;
            updateForm();
            CheckForIllegalCrossThreadCalls = false;
        }

        /**/
        /*
        

        NAME

            MainClientForm::updateForm - Function used to update all labels, textboxes, combo boxes and other values displayed on the MainClientForm


        SYNOPSIS

            public void updateForm()

                
        DESCRIPTION

            Update all parts of the MainClientForm
            -Set the charName, charClass, CharRace, LevelText, ACText and HealthText to the corresponding stats from myCharacter
            -Set the StrengthScore, DexterityScore, ConstitutionText, WisdomText, IntelligenceText, and CharismaText to myCharacters stats and include their actual modifiers
            -Set xpText and goldText to the corresponding myCharacter values
            -If myCharacter.CanUseAbility
            --Enable abilityButton
            --If myCharacter.Abilities has anything in it
            ---Enable AbilitySelectionBox and populate with all abilities if its empty
            --Otherwise disable abilitySelectionBox
            -Clear out anything in the weaponBox, and then populate it with all weapon names in myItems, setting its SelectedIndex to 0
            -Clear out anything in the cantripBox, then repopulate it with all names from myCharacter.CantripList, setting SelectedIndex to 0
            -For 9 repititions
            --Create a list of strings containing spellnames known by myCharacter of a given level 1 through 9
            --If the list is empty, disable both the LevelxSelection and LevelxButton elements
            --Otherwise, empty the LevelxSelection and repopulate it with the proper list of spellNames, and enable the combobox and button assicoated with the spell level
            -

        RETURNS

            NA, void function, but sets many values and enables functionality on many parts of form

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public void updateForm()
        {
            //starting basic with name, race and class
            charName.Text = myCharacter.getName();
            charClass.Text = myCharacter.getClass();
            CharRace.Text = myCharacter.getRace();
            LevelText.Text = myCharacter.Level.ToString();
            ACText.Text = myCharacter.ArmorClass.ToString();
            HealthText.Text = myCharacter.CurrentHP.ToString() + "/" + myCharacter.MaxHP.ToString();
            //stat blocks
            StrengthScore.Text = myCharacter.Strength.ToString() + "(+" + ((myCharacter.Strength / 2) - 5).ToString() + ")";
            DexterityScore.Text = myCharacter.Dexterity.ToString() + "(+" + ((myCharacter.Dexterity / 2) - 5).ToString() + ")";
            ConstitutionText.Text = myCharacter.Constitution.ToString() + "(+" + ((myCharacter.Constitution / 2) - 5).ToString() + ")";
            WisdomText.Text = myCharacter.Wisdom.ToString() + "(+" + ((myCharacter.Wisdom / 2) - 5).ToString() + ")";
            IntelligenceText.Text = myCharacter.Intelligence.ToString() + "(+" + ((myCharacter.Intelligence / 2) - 5).ToString() + ")";
            CharismaText.Text = myCharacter.Charisma.ToString() + "(+" + ((myCharacter.Charisma / 2) - 5).ToString() + ")";
            //Experience Points
            xpText.Text = myCharacter.ExperiencePoints.ToString() + "/" + myCharacter.CurrentLevelCap.ToString();
            //Gold
            goldText.Text = myCharacter.Gold.ToString();
            //ability box
            if (myCharacter.CanUseAbility())
            {
                AbilityButton.Enabled = true;
                if (myCharacter.Abilities.Count() == 0)
                {
                    AbilitySelectionBox.Enabled = false;
                }
                else
                {
                    AbilitySelectionBox.Enabled = true;
                    if (AbilitySelectionBox.Items.Count == 0)
                    {
                        AbilitySelectionBox.Items.AddRange(myCharacter.Abilities.ToArray());
                    }
                    AbilitySelectionBox.SelectedIndex = 0;
                }
            }
            else
            {
                AbilityButton.Enabled = false;
                AbilitySelectionBox.Enabled = false;
            }
            //weapon box
            for (int i = WeaponComboBox.Items.Count - 1; i >= 0; i--)
            {
                WeaponComboBox.Items.RemoveAt(i);
            }

            List<string> itemNames = new List<string>();
            for (int i = 0; i < myCharacter.MyItems.Count(); i++)
            {
                if (myCharacter.MyItems[i].Damage > 0)
                {
                    itemNames.Add(myCharacter.MyItems[i].Name);
                }
            }
            WeaponComboBox.Items.AddRange(itemNames.ToArray());
            WeaponComboBox.SelectedIndex = 0;
            ///Spell comboboxes
            ///Cantrips
            for (int i = CantripBox.Items.Count - 1; i >= 0; i--)
            {
                CantripBox.Items.RemoveAt(i);
            }
            List<string> cantripNames = new List<string>();
            for (int i = 0; i < myCharacter.CurrentNumberOfCantrips; i++)
            {
                cantripNames.Add(myCharacter.CantripList[i].Name);
            }
            if (cantripNames.Count() >= 2)
            {
                CantripBox.Items.AddRange(cantripNames.ToArray());
                CantripBox.SelectedIndex = 0;
            }
            else
            {
                CantripBox.Enabled = false;
                CastCanBtn.Enabled = false;
            }

            ///Spells
            for (int j = 1; j <= 9; j++)
            {
                List<string> spellNames = new List<string>();
                for (int i = 0; i < myCharacter.SpellListAt(j - 1).Count(); i++)
                {
                    spellNames.Add(myCharacter.SpellListAt(j - 1)[i].Name);
                }
                switch (j)
                {
                    case 1:
                        //add current and max spell slots
                        if (spellNames.Count() == 0 || myCharacter.CurrentSlots[j - 1] == 0)
                        {
                            Level1Box.Enabled = false;
                            Cast1Btn.Enabled = false;
                        }
                        else
                        {
                            Level1Box.Enabled = true;
                            Cast1Btn.Enabled = true;
                            for (int k = Level1Box.Items.Count - 1; k >= 0; k--)
                            {
                                Level1Box.Items.RemoveAt(k);
                            }
                            Level1Box.Items.AddRange(spellNames.ToArray());
                            Level1Box.SelectedIndex = 0;
                        }
                        Level1Label.Text = "Level 1: " + myCharacter.CurrentSlots[j - 1].ToString();
                        

                        break;
                    case 2:
                        if (spellNames.Count() == 0 || myCharacter.CurrentSlots[j - 1] == 0)
                        {
                            Level2Box.Enabled = false;
                            Cast2Btn.Enabled = false;
                        }
                        else
                        {
                            Level2Box.Enabled = true;
                            Cast2Btn.Enabled = true;
                            for (int k = Level2Box.Items.Count - 1; k >= 0; k--)
                            {
                                Level2Box.Items.RemoveAt(k);
                            }
                            Level2Box.Items.AddRange(spellNames.ToArray());
                            Level2Box.SelectedIndex = 0;
                        }
                        Level2Label.Text = "Level 2 " + myCharacter.CurrentSlots[j - 1].ToString();

                        break;
                    case 3:
                        if (spellNames.Count() == 0 || myCharacter.CurrentSlots[j - 1] == 0)
                        {
                            Level3Box.Enabled = false;
                            Cast3Btn.Enabled = false;
                        }
                        else
                        {
                            Level3Box.Enabled = true;
                            Cast3Btn.Enabled = true;
                            for (int k = Level3Box.Items.Count - 1; k >= 0; k--)
                            {
                                Level3Box.Items.RemoveAt(k);
                            }
                            Level3Box.Items.AddRange(spellNames.ToArray());
                            Level3Box.SelectedIndex = 0;
                        }
                        Level3Label.Text = "Level 3: " + myCharacter.CurrentSlots[j - 1].ToString();

                        break;
                    case 4:
                        if (spellNames.Count() == 0 || myCharacter.CurrentSlots[j - 1] == 0)
                        {
                            Level4Box.Enabled = false;
                            Cast4Btn.Enabled = false;
                        }
                        else
                        {
                            Level4Box.Enabled = true;
                            Cast4Btn.Enabled = true;
                            for (int k = Level4Box.Items.Count - 1; k >= 0; k--)
                            {
                                Level4Box.Items.RemoveAt(k);
                            }
                            Level4Box.Items.AddRange(spellNames.ToArray());
                            Level4Box.SelectedIndex = 0;
                        }
                        Level4Label.Text = "Level 4: " + myCharacter.CurrentSlots[j - 1].ToString();

                        break;
                    case 5:
                        if (spellNames.Count() == 0 || myCharacter.CurrentSlots[j - 1] == 0)
                        {
                            Level5Box.Enabled = false;
                            Cast5Btn.Enabled = false;
                        }
                        else
                        {
                            Level5Box.Enabled = true;
                            Cast5Btn.Enabled = true;
                            for (int k = Level5Box.Items.Count - 1; k >= 0; k--)
                            {
                                Level5Box.Items.RemoveAt(k);
                            }
                            Level5Box.Items.AddRange(spellNames.ToArray());
                            Level5Box.SelectedIndex = 0;
                        }
                        Level5Label.Text = "Level 5: " + myCharacter.CurrentSlots[j - 1].ToString();

                        break;
                    case 6:
                        if (spellNames.Count() == 0 || myCharacter.CurrentSlots[j - 1] == 0)
                        {
                            Level6Box.Enabled = false;
                            Cast6Btn.Enabled = false;
                        }
                        else
                        {
                            Level6Box.Enabled = true;
                            Cast6Btn.Enabled = true;
                            for (int k = Level6Box.Items.Count - 1; k >= 0; k--)
                            {
                                Level6Box.Items.RemoveAt(k);
                            }
                            Level6Box.Items.AddRange(spellNames.ToArray());
                            Level7Box.SelectedIndex = 0;
                        }
                        Level6Label.Text = "Level 6: " + myCharacter.CurrentSlots[j - 1].ToString();

                        break;
                    case 7:
                        if (spellNames.Count() == 0 || myCharacter.CurrentSlots[j - 1] == 0)
                        {
                            Level7Box.Enabled = false;
                            Cast7Btn.Enabled = false;
                        }
                        else
                        {
                            Level7Box.Enabled = true;
                            Cast7Btn.Enabled = true;
                            for (int k = Level7Box.Items.Count - 1; k >= 0; k--)
                            {
                                Level7Box.Items.RemoveAt(k);
                            }
                            Level7Box.Items.AddRange(spellNames.ToArray());
                            Level7Box.SelectedIndex = 0;
                        }
                        Level7Label.Text = "Level 7: " + myCharacter.CurrentSlots[j - 1].ToString();

                        break;
                    case 8:
                        if (spellNames.Count() == 0 || myCharacter.CurrentSlots[j - 1] == 0)
                        {
                            Level8Box.Enabled = false;
                            Cast8Btn.Enabled = false;
                        }
                        else
                        {
                            Level8Box.Enabled = true;
                            Cast8Btn.Enabled = true;
                            for (int k = Level8Box.Items.Count - 1; k >= 0; k--)
                            {
                                Level8Box.Items.RemoveAt(k);
                            }
                            Level8Box.Items.AddRange(spellNames.ToArray());
                            Level8Box.SelectedIndex = 0;
                        }
                        Level8Label.Text = "Level 8: " + myCharacter.CurrentSlots[j - 1].ToString();

                        break;
                    case 9:
                        if (spellNames.Count() == 0 || myCharacter.CurrentSlots[j - 1] == 0)
                        {
                            Level9Box.Enabled = false;
                            Cast9Btn.Enabled = false;
                        }
                        else
                        {
                            Level9Box.Enabled = true;
                            Cast9Btn.Enabled = true;
                            for (int k = Level9Box.Items.Count - 1; k >= 0; k--)
                            {
                                Level9Box.Items.RemoveAt(k);
                            }
                            Level9Box.Items.AddRange(spellNames.ToArray());
                            Level9Box.SelectedIndex = 0;
                        }
                        Level9Label.Text = "Level 9: " + myCharacter.CurrentSlots[j - 1].ToString();

                        break;
                    default:
                        break;
                }
            }


            ChatDisplayBox.AppendText(Environment.NewLine);



        }

        /**/
        /*
        

        NAME

            MainClientForm::AthleticsLabel_Click - Handler function for AthleticsLabel click event


        SYNOPSIS

            private void AthleticsLabel_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for th Athletics Label being clicked
            -If requestMade returns true
            --If the athleticsLabel text is red
            ---Call strengthRolling, passing in Athletics
            ---Set the ForeColor back to black
            --Otherwise, display error message saying another roll has been requested
            -Otherwise, call strengthRolling, passing in Athletics

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void AthleticsLabel_Click(object sender, EventArgs e)
        {
            if (requestMade())
            {
                if (AthleticsLabel.ForeColor == Color.Red)
                {
                    strengthRolling("Athletics");
                    AthleticsLabel.ForeColor = Color.Black;
                }
                else { MessageBox.Show("You currently have other rolls that have been requested."); }
            }
            else
            {
                strengthRolling("Athletics");
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::StrengthSavingLabel_Click - Handler function for StrengthSavingLabel click event


        SYNOPSIS

            private void StrengthSavingLabel_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for th Strength Savng Throw Label being clicked
            -If requestMade returns true
            --If the StrengthSavingLabel text is red
            ---Call strengthRolling, passing in Strength Saving Throw
            ---Set the ForeColor back to black
            --Otherwise, display error message saying another roll has been requested
            -Otherwise, call strengthRolling, passing in Strength Saving Throw

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        private void StrengthSavingLabel_Click(object sender, EventArgs e)
        {
            if (requestMade())
            {
                if (StrengthSavingLabel.ForeColor == Color.Red)
                {
                    strengthRolling("Strength Saving Throw");
                    StrengthSavingLabel.ForeColor = Color.Black;
                }
                else { MessageBox.Show("You currently have other rolls that have been requested."); }
            }
            else
            {
                strengthRolling("Strength Saving Throw");
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::AcrobaticsLabel_Click - Handler function for AcrobaticsLabel click event


        SYNOPSIS

            private void AcrobaticsLabel_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for th AcrobaticsLabel being clicked
            -If requestMade returns true
            --If the AcrobaticsLabel text is red
            ---Call dexterityRolling, passing in Acrobatics
            ---Set the ForeColor back to black
            --Otherwise, display error message saying another roll has been requested
            -Otherwise, call dexterityRolling, passing in Acrobatics

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void AcrobaticsLabel_Click(object sender, EventArgs e)
        {
            if (requestMade())
            {
                if (AcrobaticsLabel.ForeColor == Color.Red)
                {
                    dexterityRolling("Acrobatics");
                    AcrobaticsLabel.ForeColor = Color.Black;
                }
                else { MessageBox.Show("You currently have other rolls that have been requested."); }

            }
            else
            {
                dexterityRolling("Acrobatics");
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::SleightOfHandLabel_Click - Handler function for SleightOfHandLabel click event


        SYNOPSIS

            private void SleightOfHandLabel_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for SleightOfHandLabel being clicked
            -If requestMade returns true
            --If the SleightOfHandLabel text is red
            ---Call dexterityRolling, passing in Sleight Of Hand
            ---Set the ForeColor back to black
            --Otherwise, display error message saying another roll has been requested
            -Otherwise, call dexterityRolling, passing in Sleight Of Hand

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void SleightOfHandLabel_Click(object sender, EventArgs e)
        {
            if (requestMade())
            {
                if (SleightOfHandLabel.ForeColor == Color.Red)
                {
                    dexterityRolling("Sleight of Hand");
                    SleightOfHandLabel.ForeColor = Color.Black;
                }
                else { MessageBox.Show("You currently have other rolls that have been requested."); }

            }
            else
            {
                dexterityRolling("Sleight of Hand");
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::StealthLabel_Click - Handler function for StealthLabel click event


        SYNOPSIS

            private void StealthLabel_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for StealthLabel being clicked
            -If requestMade returns true
            --If the StealthLabel text is red
            ---Call dexterityRolling, passing in Stealth
            ---Set the ForeColor back to black
            --Otherwise, display error message saying another roll has been requested
            -Otherwise, call dexterityRolling, passing in Stealth

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void StealthLabel_Click(object sender, EventArgs e)
        {
            if (requestMade())
            {
                if (StealthLabel.ForeColor == Color.Red)
                {
                    dexterityRolling("Stealth");
                    StealthLabel.ForeColor = Color.Black;
                }
                else { MessageBox.Show("You currently have other rolls that have been requested."); }

            }
            else
            {
                dexterityRolling("Stealth");
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::DexSavingLabel_Click - Handler function for DexSavingLabel click event


        SYNOPSIS

            private void DexSavingLabel_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for DexSavingLabel being clicked
            -If requestMade returns true
            --If the DexSavingLabel text is red
            ---Call dexterityRolling, passing in Dexterity Saving Throw
            ---Set the ForeColor back to black
            --Otherwise, display error message saying another roll has been requested
            -Otherwise, call dexterityRolling, passing in Dexterity Saving Throw

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void DexSavingLabel_Click(object sender, EventArgs e)
        {
            if (requestMade())
            {
                if (DexSavingLabel.ForeColor == Color.Red)
                {
                    dexterityRolling("Dexterity Saving Throw");
                    DexSavingLabel.ForeColor = Color.Black;
                }
                else { MessageBox.Show("You currently have other rolls that have been requested."); }
            }
            else
            {
                dexterityRolling("Dexterity Saving Throw");
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::ConSavingLabel_Click - Handler function for ConSavingLabel click event


        SYNOPSIS

            private void ConSavingLabel_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for ConSavingLabel being clicked
            -If requestMade returns true
            --If the ConSavingLabel text is red
            ---Call constitutionRolling, passing in Constitution Saving Throw
            ---Set the ForeColor back to black
            --Otherwise, display error message saying another roll has been requested
            -Otherwise, call constitutionRolling, passing in Constitution Saving Throw

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void ConSavingLabel_Click(object sender, EventArgs e)
        {
            if (requestMade())
            {
                if (ConSavingLabel.ForeColor == Color.Red)
                {
                    constitutionRolling("Constitution Saving Throw");
                    ConSavingLabel.ForeColor = Color.Black;
                }
                else { MessageBox.Show("You currently have other rolls that have been requested."); }

            }
            else
            {
                constitutionRolling("Constitution Saving Throw");
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::ArcanaLabel_Click - Handler function for ArcanaLabel click event


        SYNOPSIS

            private void ArcanaLabel_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for ArcanaLabel being clicked
            -If requestMade returns true
            --If the ArcanaLabal text is red
            ---Call intelligenceRolling, passing in Arcana
            ---Set the ForeColor back to black
            --Otherwise, display error message saying another roll has been requested
            -Otherwise, call intelligenceRolling, passing in Arcana

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void ArcanaLabel_Click(object sender, EventArgs e)
        {
            if (requestMade())
            {
                if (ArcanaLabel.ForeColor == Color.Red)
                {
                    intelligenceRolling("Arcana");
                    ArcanaLabel.ForeColor = Color.Black;
                }
                else { MessageBox.Show("You currently have other rolls that have been requested."); }

            }
            else
            {
                intelligenceRolling("Arcana");
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::HistoryLabel_Click - Handler function for ArcanaLabel click event


        SYNOPSIS

            private void HistoryLabel_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for HistoryLabel being clicked
            -If requestMade returns true
            --If the HistoryLabel text is red
            ---Call intelligenceRolling, passing in History
            ---Set the ForeColor back to black
            --Otherwise, display error message saying another roll has been requested
            -Otherwise, call intelligenceRolling, passing in History

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void HistoryLabel_Click(object sender, EventArgs e)
        {
            if (requestMade())
            {
                if (HistoryLabel.ForeColor == Color.Red)
                {
                    intelligenceRolling("History");
                    HistoryLabel.ForeColor = Color.Black;
                }
                else { MessageBox.Show("You currently have other rolls that have been requested."); }

            }
            else
            {
                intelligenceRolling("History");
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::NatureLabel_Click - Handler function for NatureLabel click event


        SYNOPSIS

            private void NatureLabel_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for NatureLabel being clicked
            -If requestMade returns true
            --If the NatureLabel text is red
            ---Call intelligenceRolling, passing in Nature
            ---Set the ForeColor back to black
            --Otherwise, display error message saying another roll has been requested
            -Otherwise, call intelligenceRolling, passing in Nature

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void NatureLabel_Click(object sender, EventArgs e)
        {
            if (requestMade())
            {
                if (NatureLabel.ForeColor == Color.Red)
                {
                    intelligenceRolling("Nature");
                    NatureLabel.ForeColor = Color.Black;
                }
                else { MessageBox.Show("You currently have other rolls that have been requested."); }
            }
            else
            {
                intelligenceRolling("Nature");
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::ReligionLabel_Click - Handler function for ReligionLabel click event


        SYNOPSIS

            private void ReligionLabel_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for ReligionLabel being clicked
            -If requestMade returns true
            --If the ReligionLabel text is red
            ---Call intelligenceRolling, passing in Religion
            ---Set the ForeColor back to black
            --Otherwise, display error message saying another roll has been requested
            -Otherwise, call intelligenceRolling, passing in Religion

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void ReligionLabel_Click(object sender, EventArgs e)
        {
            if (requestMade())
            {
                if (ReligionLabel.ForeColor == Color.Red)
                {
                    intelligenceRolling("Religion");
                    ReligionLabel.ForeColor = Color.Black;
                }
                else { MessageBox.Show("You currently have other rolls that have been requested."); }

            }
            else
            {
                intelligenceRolling("Religion");
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::IntSaveLabel_Click - Handler function for IntSavingLabel click event


        SYNOPSIS

            private void IntSaveLabel_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for IntSavingLabel being clicked
            -If requestMade returns true
            --If the IntSavingLabel text is red
            ---Call intelligenceRolling, passing in Intelligence Saving Throw
            ---Set the ForeColor back to black
            --Otherwise, display error message saying another roll has been requested
            -Otherwise, call intelligenceRolling, passing in Intelligence Saving Throw

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void IntSaveLabel_Click(object sender, EventArgs e)
        {
            if (requestMade())
            {
                if (IntSaveLabel.ForeColor == Color.Red)
                {
                    intelligenceRolling("Intelligence Saving Throw");
                    IntSaveLabel.ForeColor = Color.Black;
                }
                else { MessageBox.Show("You currently have other rolls that have been requested."); }
            }
            else
            {
                intelligenceRolling("Intelligence Saving Throw");
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::AnimalHandlingLabel_Click - Handler function for AnimalHanldingLabel click event


        SYNOPSIS

            private void AnimalHandlingLabel_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for AnimalHandlingLabel being clicked
            -If requestMade returns true
            --If the AnimalHanldingLabel text is red
            ---Call wisdomRolling, passing in Animal Handling
            ---Set the ForeColor back to black
            --Otherwise, display error message saying another roll has been requested
            -Otherwise, call wisdomRolling, passing in Animal Handling

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void AnimalHandlingLabel_Click(object sender, EventArgs e)
        {
            if (requestMade())
            {
                if (AnimalHandlingLabel.ForeColor == Color.Red)
                {
                    wisdomRolling("Animal Handling");
                    AnimalHandlingLabel.ForeColor = Color.Black;
                }
                else { MessageBox.Show("You currently have other rolls that have been requested."); }

            }
            else
            {
                wisdomRolling("Animal Handling");
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::InsightLabel_Click - Handler function for InsightLabel click event


        SYNOPSIS

            private void InsightLabel_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for InsightLabel being clicked
            -If requestMade returns true
            --If the InsightLabel text is red
            ---Call wisdomRolling, passing in Insight
            ---Set the ForeColor back to black
            --Otherwise, display error message saying another roll has been requested
            -Otherwise, call wisdomRolling, passing in Insight

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void InsightLabel_Click(object sender, EventArgs e)
        {
            if (requestMade())
            {
                if (InsightLabel.ForeColor == Color.Red)
                {
                    wisdomRolling("Insight");
                    InsightLabel.ForeColor = Color.Black;
                }
                else { MessageBox.Show("You currently have other rolls that have been requested."); }

            }
            else
            {
                wisdomRolling("Insight");
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::MedicineLabel_Click - Handler function for MedicineLabel click event


        SYNOPSIS

            private void MedicineLabel_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for MedicineLabel being clicked
            -If requestMade returns true
            --If the MedicineLabel text is red
            ---Call wisdomRolling, passing in Medicine
            ---Set the ForeColor back to black
            --Otherwise, display error message saying another roll has been requested
            -Otherwise, call wisdomRolling, passing in Medicine

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void MedicineLabel_Click(object sender, EventArgs e)
        {
            if (requestMade())
            {
                if (MedicineLabel.ForeColor == Color.Red)
                {
                    wisdomRolling("Medicine");
                    MedicineLabel.ForeColor = Color.Black;
                }
                else { MessageBox.Show("You currently have other rolls that have been requested."); }

            }
            else
            {
                wisdomRolling("Medicine");
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::PerceptionLabel_Click - Handler function for PerceptionLabel click event


        SYNOPSIS

            private void PerceptionLabel_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for PerceptionLabel being clicked
            -If requestMade returns true
            --If the PerceptionLabel text is red
            ---Call wisdomRolling, passing in Perception
            ---Set the ForeColor back to black
            --Otherwise, display error message saying another roll has been requested
            -Otherwise, call wisdomRolling, passing in Perception

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void PerceptionLabel_Click(object sender, EventArgs e)
        {
            if (requestMade())
            {
                if (PerceptionLabel.ForeColor == Color.Red)
                {
                    wisdomRolling("Perception");
                    PerceptionLabel.ForeColor = Color.Black;
                }
                else { MessageBox.Show("You currently have other rolls that have been requested."); }
            }
            else
            {
                wisdomRolling("Perception");
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::SurvivalLabel_Click - Handler function for SurvivalLabel click event


        SYNOPSIS

            private void SurvivalLabel_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for SurvivalLabel being clicked
            -If requestMade returns true
            --If the SurvivalLabel text is red
            ---Call wisdomRolling, passing in Survival
            ---Set the ForeColor back to black
            --Otherwise, display error message saying another roll has been requested
            -Otherwise, call wisdomRolling, passing in Survival

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void SurvivalLabel_Click(object sender, EventArgs e)
        {
            if (requestMade())
            {
                if (SurvivalLabel.ForeColor == Color.Red)
                {
                    wisdomRolling("Survival");
                    SurvivalLabel.ForeColor = Color.Black;
                }
                else { MessageBox.Show("You currently have other rolls that have been requested."); }

            }
            else
            {
                wisdomRolling("Survival");
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::WisdomSaveLabel_Click - Handler function for WisdomSaveLabel click event


        SYNOPSIS

            private void WisdomSaveLabel_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for WisdomSaveLabel being clicked
            -If requestMade returns true
            --If the WisdomSaveLabel text is red
            ---Call wisdomRolling, passing in Wisdom Saving Throw
            ---Set the ForeColor back to black
            --Otherwise, display error message saying another roll has been requested
            -Otherwise, call wisdomRolling, passing in Wisdom Saving Throw

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void WisdomSaveLabel_Click(object sender, EventArgs e)
        {
            if (requestMade())
            {
                if (WisdomSaveLabel.ForeColor == Color.Red)
                {
                    wisdomRolling("Wisdom Saving Throw");
                    WisdomSaveLabel.ForeColor = Color.Black;
                }
                else { MessageBox.Show("You currently have other rolls that have been requested."); }

            }
            else
            {
                wisdomRolling("Wisdom Saving Throw");
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::DeceptionLabel_Click - Handler function for DeceptionLabel click event


        SYNOPSIS

            private void DeceptionLabel_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for DeceptionLabel being clicked
            -If requestMade returns true
            --If the DeceptionLabel text is red
            ---Call charismaRolling, passing in Deception
            ---Set the ForeColor back to black
            --Otherwise, display error message saying another roll has been requested
            -Otherwise, call charismaRolling, passing in Deception

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void DeceptionLabel_Click(object sender, EventArgs e)
        {
            if (requestMade())
            {
                if (DeceptionLabel.ForeColor == Color.Red)
                {
                    charismaRolling("Deception");
                    DeceptionLabel.ForeColor = Color.Black;
                }
                else { MessageBox.Show("You currently have other rolls that have been requested."); }

            }
            else
            {
                charismaRolling("Decepction");
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::IntimidationLabel_Click - Handler function for IntimidationLabel click event


        SYNOPSIS

            private void IntimidationLabel_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for IntimidationLabel being clicked
            -If requestMade returns true
            --If the IntimidationLabel text is red
            ---Call charismaRolling, passing in Intimidation
            ---Set the ForeColor back to black
            --Otherwise, display error message saying another roll has been requested
            -Otherwise, call charismaRolling, passing in Intimidation

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void IntimidationLabel_Click(object sender, EventArgs e)
        {
            if (requestMade())
            {
                if (IntimidationLabel.ForeColor == Color.Red)
                {
                    charismaRolling("Intimidation");
                    IntimidationLabel.ForeColor = Color.Black;
                }
                else { MessageBox.Show("You currently have other rolls that have been requested."); }

            }
            else
            {
                charismaRolling("Intimidation");
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::PerformanceLabel_Click - Handler function for PerformanceLabel click event


        SYNOPSIS

            private void PerformanceLabel_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for PerformanceLabel being clicked
            -If requestMade returns true
            --If the PerformanceLabel text is red
            ---Call charismaRolling, passing in Performance
            ---Set the ForeColor back to black
            --Otherwise, display error message saying another roll has been requested
            -Otherwise, call charismaRolling, passing in Performance

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void PerformanceLabel_Click(object sender, EventArgs e)
        {
            if (requestMade())
            {
                if (PerformanceLabel.ForeColor == Color.Red)
                {
                    charismaRolling("Performance");
                    PerformanceLabel.ForeColor = Color.Black;
                }
                else { MessageBox.Show("You currently have other rolls that have been requested."); }
            }
            else
            {
                charismaRolling("Performance");
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::PersuasionLabel_Click - Handler function for PersuasionLabel click event


        SYNOPSIS

            private void PersuasionLabel_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for PersuasionLabel being clicked
            -If requestMade returns true
            --If the PersuasionLabel text is red
            ---Call charismaRolling, passing in Persuasion
            ---Set the ForeColor back to black
            --Otherwise, display error message saying another roll has been requested
            -Otherwise, call charismaRolling, passing in Persuasion

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void PersuasionLabel_Click(object sender, EventArgs e)
        {
            if (requestMade())
            {
                if (PersuasionLabel.ForeColor == Color.Red)
                {
                    charismaRolling("Persuasion");
                    PersuasionLabel.ForeColor = Color.Black;
                }
                else { MessageBox.Show("You currently have other rolls that have been requested."); }
            }
            else
            {
                charismaRolling("Persuasion");
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::CharismaSavingThrow_Click - Handler function for CharismaSavingThrow click event


        SYNOPSIS

            private void CharismaSavingThrow_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for CharismaSavingThrow being clicked
            -If requestMade returns true
            --If the CharismaSavingThrow text is red
            ---Call charismaRolling, passing in Charisma Saving Throw
            ---Set the ForeColor back to black
            --Otherwise, display error message saying another roll has been requested
            -Otherwise, call charismaRolling, passing in Charisma Saving Throw

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void CharismaSavingThrow_Click(object sender, EventArgs e)
        {
            if (requestMade())
            {
                if (CharismaSavingThrow.ForeColor == Color.Red)
                {
                    charismaRolling("Charisma Saving Throw");
                    CharismaSavingThrow.ForeColor = Color.Black;
                }
                else { MessageBox.Show("You currently have other rolls that have been requested."); }
            }
            else
            {
                charismaRolling("Charisma Saving Throw");
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::CantripBox_SelectedValueChanged - Handler function for CantripBox SelectedValueChanged event


        SYNOPSIS

            private void CantripBox_SelectedValueChanged(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for CantripBox SelectedValueChanged event
            -Initialize string cantripName to the CantripBox.Text
            -Change the MagicDescriptionBox Text to be the description of the Cantrip whos name matches cantripName

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void CantripBox_SelectedValueChanged(object sender, EventArgs e)
        {
            string cantripName = CantripBox.Text;
            MagicDescriptionBox.Text = cantripName + Environment.NewLine + clientCantrip.TheSpells.Find(x => x.Name == cantripName).Effect;
        }

        /**/
        /*
        

        NAME

            MainClientForm::Level1Box_SelectedValueChanged - Handler function for Level1Box SelectedValueChanged event


        SYNOPSIS

            private void Level1Box_SelectedValueChanged(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for Level1Box SelectedValueChanged event
            -Initialize string spellName to the Level1Box.Text
            -Change the MagicDescriptionBox Text to be the description of the Spell whos name matches cantripName

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void Level1Box_SelectedValueChanged(object sender, EventArgs e)
        {
            string spellName = Level1Box.Text;
            MagicDescriptionBox.Text = spellName + Environment.NewLine + clientSpell.TheSpells.Find(x => x.Name == spellName).Effect;
        }

        /**/
        /*
        

        NAME

            MainClientForm::Level2Box_SelectedValueChanged - Handler function for Level2Box SelectedValueChanged event


        SYNOPSIS

            private void Level2Box_SelectedValueChanged(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for Level2Box SelectedValueChanged event
            -Initialize string spellName to the Level2Box.Text
            -Change the MagicDescriptionBox Text to be the description of the Spell whos name matches cantripName

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void Level2Box_SelectedValueChanged(object sender, EventArgs e)
        {
            string spellName = Level2Box.Text;
            MagicDescriptionBox.Text = spellName + Environment.NewLine + clientSpell.TheSpells.Find(x => x.Name == spellName).Effect;
        }

        /**/
        /*
        

        NAME

            MainClientForm::Level3Box_SelectedValueChanged - Handler function for Level3Box SelectedValueChanged event


        SYNOPSIS

            private void Level3Box_SelectedValueChanged(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for Level3Box SelectedValueChanged event
            -Initialize string spellName to the Level2Box.Text
            -Change the MagicDescriptionBox Text to be the description of the Spell whos name matches cantripName

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void Level3Box_SelectedValueChanged(object sender, EventArgs e)
        {
            string spellName = Level3Box.Text;
            MagicDescriptionBox.Text = spellName + Environment.NewLine + clientSpell.TheSpells.Find(x => x.Name == spellName).Effect;
        }

        /**/
        /*
        

        NAME

            MainClientForm::Level4Box_SelectedValueChanged - Handler function for Level4Box SelectedValueChanged event


        SYNOPSIS

            private void Level4Box_SelectedValueChanged(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for Level4Box SelectedValueChanged event
            -Initialize string spellName to the Level4Box.Text
            -Change the MagicDescriptionBox Text to be the description of the Spell whos name matches cantripName

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void Level4Box_SelectedValueChanged(object sender, EventArgs e)
        {
            string spellName = Level4Box.Text;
            MagicDescriptionBox.Text = spellName + Environment.NewLine + clientSpell.TheSpells.Find(x => x.Name == spellName).Effect;
        }

        /**/
        /*
        

        NAME

            MainClientForm::Level5Box_SelectedValueChanged - Handler function for Level5Box SelectedValueChanged event


        SYNOPSIS

            private void Level5Box_SelectedValueChanged(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for Level5Box SelectedValueChanged event
            -Initialize string spellName to the Level5Box.Text
            -Change the MagicDescriptionBox Text to be the description of the Spell whos name matches cantripName

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void Level5Box_SelectedValueChanged(object sender, EventArgs e)
        {
            string spellName = Level5Box.Text;
            MagicDescriptionBox.Text = spellName + Environment.NewLine + clientSpell.TheSpells.Find(x => x.Name == spellName).Effect;
        }

        /**/
        /*
        

        NAME

            MainClientForm::Level6Box_SelectedValueChanged - Handler function for Level6Box SelectedValueChanged event


        SYNOPSIS

            private void Level6Box_SelectedValueChanged(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for Level6Box SelectedValueChanged event
            -Initialize string spellName to the Level6Box.Text
            -Change the MagicDescriptionBox Text to be the description of the Spell whos name matches cantripName

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void Level6Box_SelectedValueChanged(object sender, EventArgs e)
        {
            string spellName = Level6Box.Text;
            MagicDescriptionBox.Text = spellName + Environment.NewLine + clientSpell.TheSpells.Find(x => x.Name == spellName).Effect;
        }

        /**/
        /*
        

        NAME

            MainClientForm::Level7Box_SelectedValueChanged - Handler function for Level7Box SelectedValueChanged event


        SYNOPSIS

            private void Level7Box_SelectedValueChanged(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for Level7Box SelectedValueChanged event
            -Initialize string spellName to the Level7Box.Text
            -Change the MagicDescriptionBox Text to be the description of the Spell whos name matches cantripName

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void Level7Box_SelectedValueChanged(object sender, EventArgs e)
        {
            string spellName = Level7Box.Text;
            MagicDescriptionBox.Text = spellName + Environment.NewLine + clientSpell.TheSpells.Find(x => x.Name == spellName).Effect;
        }

        /**/
        /*
        

        NAME

            MainClientForm::Level8Box_SelectedValueChanged - Handler function for Level8Box SelectedValueChanged event


        SYNOPSIS

            private void Level8Box_SelectedValueChanged(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for Level8Box SelectedValueChanged event
            -Initialize string spellName to the Level8Box.Text
            -Change the MagicDescriptionBox Text to be the description of the Spell whos name matches cantripName

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void Level8Box_SelectedValueChanged(object sender, EventArgs e)
        {
            string spellName = Level8Box.Text;
            MagicDescriptionBox.Text = spellName + Environment.NewLine + clientSpell.TheSpells.Find(x => x.Name == spellName).Effect;
        }

        /**/
        /*
        

        NAME

            MainClientForm::Level9Box_SelectedValueChanged - Handler function for Level9Box SelectedValueChanged event


        SYNOPSIS

            private void Level9Box_SelectedValueChanged(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for Level9Box SelectedValueChanged event
            -Initialize string spellName to the Level9Box.Text
            -Change the MagicDescriptionBox Text to be the description of the Spell whos name matches cantripName

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void Level9Box_SelectedValueChanged(object sender, EventArgs e)
        {
            string spellName = Level9Box.Text;
            MagicDescriptionBox.Text = spellName + Environment.NewLine + clientSpell.TheSpells.Find(x => x.Name == spellName).Effect;
        }

        /**/
        /*
        

        NAME

            MainClientForm::SendChatBtn_Click - Handler function for SendChatBtn click event


        SYNOPSIS

            private void SendChatBtn_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for SendChatBtn click event
            -Initialize string chatresult to ChatWriteBox.Text
            -If clientSocket is Connected
            --If chatresult contains @, give error
            --Otherwise, send a byte array named buffer, composed of the ASCII encoding of chatresult
            -Otherwise just append chatresult to CharDisplayBox and clear ChatWriteBox.Text

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void SendChatBtn_Click(object sender, EventArgs e)
        {
            string chatresult = ChatWriteBox.Text;
            if (clientSocket.Connected)
            {
                if (chatresult.Contains("@"))
                {
                    MessageBox.Show("@ is a forbidden character please don't use it.");
                }
                else
                {
                    byte[] buffer = Encoding.ASCII.GetBytes(chatresult);
                    clientSocket.Send(buffer);
                }
            }
            else { ChatDisplayBox.AppendText(Environment.NewLine + chatresult); }
            ChatWriteBox.Text = "";
        }

        /**/
        /*
        

        NAME

            MainClientForm::AbilityButton_Click - Handler function for AbilityButton click event


        SYNOPSIS

            private void AbilityButton_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for AbilityButton click event
            -If AbilitySelectionBox is enabled
            --Set myCharacter.AbilityChoice to AbilitySelectionBox.Text
            -If clientSocket is connecter
            --Send a byte array named buffer, containing the ascii encoding of the result of calling myCharacter.classABility
            -Otherwise append the result of calling myCharacter.classAbility to ChatDisplayBox
            -Call updateForm

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void AbilityButton_Click(object sender, EventArgs e)
        {
            if (AbilitySelectionBox.Enabled == true)
            {
                myCharacter.AbilityChoice = AbilitySelectionBox.Text;
            }
            if (clientSocket.Connected)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(myCharacter.classAbility());
                clientSocket.Send(buffer);
            }
            else { ChatDisplayBox.AppendText(myCharacter.classAbility()); }
            updateForm();
        }

        /**/
        /*
        

        NAME

            MainClientForm::weaponAttackButton_Click - Handler function for weaponAttackButton click event


        SYNOPSIS

            private void weaponAttackButton_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for weaponAttackButton click event
            -If clientSocket is connecter
            --Create byte array buffer, setting it to the result of ASCII encoding the return of myCharacter.attackingWithItem, passing in WeaponComboBox.Text as the value for it
            -Otherwise, just append the result of myCharcter.attackWithItem, with WeaponComboBox.Text passed in

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void weaponAttackButton_Click(object sender, EventArgs e)
        {
            if (clientSocket.Connected)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(myCharacter.attackWithItem(WeaponComboBox.Text));
                clientSocket.Send(buffer);
            }
            else {
                ChatDisplayBox.AppendText(Environment.NewLine + myCharacter.attackWithItem(WeaponComboBox.Text));
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::CastCanBtn_Click - Handler function for CastCanBtn click event


        SYNOPSIS

            private void CastCanBtn(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for CastCanBtn click event
            -Initialize string result, setting it to the result of myCharacter.CastCantrip, passing in cantripBox.Text
            -If clientSocket is connected
            --Create byte array buffer, setting it to the ASCII encoding of result
            --Call clientSocket.Send, passing in buffer
            -Otherwise, Append to the ChatDisplayBox result

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void CastCanBtn_Click(object sender, EventArgs e)
        {
            string result= myCharacter.CastCantrip(CantripBox.Text);
            if (clientSocket.Connected)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(result);
                clientSocket.Send(buffer);
            }
            else
            {
                ChatDisplayBox.AppendText(Environment.NewLine + result);
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::Cast1Btn_Click - Handler function for Cast1Btn click event


        SYNOPSIS

            private void Cast1Btn_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for Cast1Btn click event
            -Initialize string result, setting it to the result of myCharacter.CastSpell, passing in Level1Box.Text and 0
            -If clientSocket is connected
            --Create byte array buffer, setting it to the ASCII encoding of result
            --Call clientSocket.Send, passing in buffer
            -Otherwise, Append to the ChatDisplayBox result
            -Call updateForm

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void Cast1Btn_Click(object sender, EventArgs e)
        {
            string result = myCharacter.CastSpell(Level1Box.Text, 0);
            if (clientSocket.Connected)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(result);
                clientSocket.Send(buffer);
            }
            else
            {
                ChatDisplayBox.AppendText(Environment.NewLine + result);
            }
            updateForm();
        }

        /**/
        /*
        

        NAME

            MainClientForm::Cast2Btn_Click - Handler function for Cast2Btn click event


        SYNOPSIS

            private void Cast2Btn_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for Cast2Btn click event
            -Initialize string result, setting it to the result of myCharacter.CastSpell, passing in Level2Box.Text and 1
            -If clientSocket is connected
            --Create byte array buffer, setting it to the ASCII encoding of result
            --Call clientSocket.Send, passing in buffer
            -Otherwise, Append to the ChatDisplayBox result
            -Call updateForm

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void Cast2Btn_Click(object sender, EventArgs e)
        {
            string result = myCharacter.CastSpell(Level2Box.Text, 1);
            if (clientSocket.Connected)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(result);
                clientSocket.Send(buffer);
            }
            else
            {
                ChatDisplayBox.AppendText(Environment.NewLine + result);
            }
            updateForm();
        }

        /**/
        /*
        

        NAME

            MainClientForm::Cast3Btn_Click - Handler function for Cast3Btn click event


        SYNOPSIS

            private void Cast3Btn_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for Cast3Btn click event
            -Initialize string result, setting it to the result of myCharacter.CastSpell, passing in Level3Box.Text and 2
            -If clientSocket is connected
            --Create byte array buffer, setting it to the ASCII encoding of result
            --Call clientSocket.Send, passing in buffer
            -Otherwise, Append to the ChatDisplayBox result
            -Call updateForm

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void Cast3Btn_Click(object sender, EventArgs e)
        {
            string result= myCharacter.CastSpell(Level3Box.Text, 2);
            if (clientSocket.Connected)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(result);
                clientSocket.Send(buffer);
            }
            else
            {
                ChatDisplayBox.AppendText(Environment.NewLine + result);
            }
            updateForm();
        }

        /**/
        /*
        

        NAME

            MainClientForm::Cast4Btn_Click - Handler function for Cast4Btn click event


        SYNOPSIS

            private void Cast4Btn_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for Cast4Btn click event
            -Initialize string result, setting it to the result of myCharacter.CastSpell, passing in Level4Box.Text and 3
            -If clientSocket is connected
            --Create byte array buffer, setting it to the ASCII encoding of result
            --Call clientSocket.Send, passing in buffer
            -Otherwise, Append to the ChatDisplayBox result
            -Call updateForm

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void Cast4Btn_Click(object sender, EventArgs e)
        {
            string result = myCharacter.CastSpell(Level4Box.Text, 3);
            if (clientSocket.Connected)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(result);
                clientSocket.Send(buffer);
            }
            else
            {
                ChatDisplayBox.AppendText(Environment.NewLine + result);
            }
            updateForm();
        }

        /**/
        /*
        

        NAME

            MainClientForm::Cast5Btn_Click - Handler function for Cast5Btn click event


        SYNOPSIS

            private void Cast5Btn_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for Cast5Btn click event
            -Initialize string result, setting it to the result of myCharacter.CastSpell, passing in Level5Box.Text and 4
            -If clientSocket is connected
            --Create byte array buffer, setting it to the ASCII encoding of result
            --Call clientSocket.Send, passing in buffer
            -Otherwise, Append to the ChatDisplayBox result
            -Call updateForm

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void Cast5Btn_Click(object sender, EventArgs e)
        {
            string result= myCharacter.CastSpell(Level5Box.Text, 4);
            if (clientSocket.Connected)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(result);
                clientSocket.Send(buffer);
            }
            else
            {
                ChatDisplayBox.AppendText(Environment.NewLine + result);
            }
            updateForm();
        }

        /**/
        /*
        

        NAME

            MainClientForm::Cast6Btn_Click - Handler function for Cast6Btn click event


        SYNOPSIS

            private void Cast6Btn_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for Cast6Btn click event
            -Initialize string result, setting it to the result of myCharacter.CastSpell, passing in Level6Box.Text and 5
            -If clientSocket is connected
            --Create byte array buffer, setting it to the ASCII encoding of result
            --Call clientSocket.Send, passing in buffer
            -Otherwise, Append to the ChatDisplayBox result
            -Call updateForm

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void Cast6Btn_Click(object sender, EventArgs e)
        {
            string result= myCharacter.CastSpell(Level6Box.Text, 5);
            if (clientSocket.Connected)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(result);
                clientSocket.Send(buffer);
            }
            else
            {
                ChatDisplayBox.AppendText(Environment.NewLine + result);
            }
            updateForm();
        }

        /**/
        /*
        

        NAME

            MainClientForm::Cast7Btn_Click - Handler function for Cast3Btn click event


        SYNOPSIS

            private void Cast7Btn_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for Cast7Btn click event
            -Initialize string result, setting it to the result of myCharacter.CastSpell, passing in Level7Box.Text and 6
            -If clientSocket is connected
            --Create byte array buffer, setting it to the ASCII encoding of result
            --Call clientSocket.Send, passing in buffer
            -Otherwise, Append to the ChatDisplayBox result
            -Call updateForm

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void Cast7Btn_Click(object sender, EventArgs e)
        {
            string result= myCharacter.CastSpell(Level7Box.Text, 6);
            if (clientSocket.Connected)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(result);
                clientSocket.Send(buffer);
            }
            else
            {
                ChatDisplayBox.AppendText(Environment.NewLine + result);
            }
            updateForm();
        }

        /**/
        /*
        

        NAME

            MainClientForm::Cast8Btn_Click - Handler function for Cast8Btn click event


        SYNOPSIS

            private void Cast8Btn_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for Cast8Btn click event
            -Initialize string result, setting it to the result of myCharacter.CastSpell, passing in Level8Box.Text and 7
            -If clientSocket is connected
            --Create byte array buffer, setting it to the ASCII encoding of result
            --Call clientSocket.Send, passing in buffer
            -Otherwise, Append to the ChatDisplayBox result
            -Call updateForm

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void Cast8Btn_Click(object sender, EventArgs e)
        {
            string result= myCharacter.CastSpell(Level8Box.Text, 7);
            if (clientSocket.Connected)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(result);
                clientSocket.Send(buffer);
            }
            else
            {
                ChatDisplayBox.AppendText(Environment.NewLine + result);
            }
            updateForm();
        }

        /**/
        /*
        

        NAME

            MainClientForm::Cast9Btn_Click - Handler function for Cast9Btn click event


        SYNOPSIS

            private void Cast9Btn_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for Cast9Btn click event
            -Initialize string result, setting it to the result of myCharacter.CastSpell, passing in Level9Box.Text and 8
            -If clientSocket is connected
            --Create byte array buffer, setting it to the ASCII encoding of result
            --Call clientSocket.Send, passing in buffer
            -Otherwise, Append to the ChatDisplayBox result
            -Call updateForm

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void Cast9Btn_Click(object sender, EventArgs e)
        {
            string result=  myCharacter.CastSpell(Level9Box.Text, 8);
            if (clientSocket.Connected)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(result);
                clientSocket.Send(buffer);
            }
            else
            {
                ChatDisplayBox.AppendText(Environment.NewLine + result);
            }
            updateForm();
        }

        /**/
        /*
        

        NAME

            MainClientForm::simpleRollButton_Click - Handler function for simpleRollButton click event


        SYNOPSIS

            private void simpleRollButton_Click(object sender, EventArgs e)


                
        DESCRIPTION

            Event handler for simpleRollButton click event
            -If both simpleRollDiceBox.Text and simpleRollSideBox.Text are ints
            --Create a string explaining the result of the roll
            --If clientSocket is connected
            ---Create a byte array named buffer, setting it to the result of ASCII encoding the string of the roll result
            ---Call clientSocket.Send, passing buffer into it
            --Otherwise, Append the result of the roll string to chatDisplayBox
            -Otherwise, show error message

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void simpleRollButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(simpleRollDiceBox.Text, out int result) && int.TryParse(simpleRollSideBox.Text, out int secondResult))
            {
                string result2 =charName.Text + " rolls " + simpleRollDiceBox.Text + "D" + simpleRollSideBox.Text + " and got a " + myCharacter.MyDie.RollSeveral(result, secondResult).ToString();
                if (clientSocket.Connected)
                {
                    byte[] buffer = Encoding.ASCII.GetBytes(result2);
                    clientSocket.Send(buffer);
                }
                else
                {
                    ChatDisplayBox.AppendText(Environment.NewLine + result2);
                }
            }
            else
            {
                MessageBox.Show("Only enter numbers in those boxes.");
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::strengthRolling - Function used to handle the results of strength based rolls on the form


        SYNOPSIS

            private void strengthRolling(string value)

            string value -> String used to check for proficiency

                
        DESCRIPTION

            Function used to roll strength based rolls
            -Create 2 int values, rollResult and secondRoll, setting them to myChar.rollStr(20)
            -Create int result
            -If myCharacter.checkProf(value) returns true
            --Add myCharacter.Proficiency to rollResult and secondRoll
            -If AdvantageButton or DisadvantageButton are checked
            --If Advantge is checked, set result to the higher of rollResult and secondRoll
            --Otherwise, set result to the lower of rollResult and secondRoll
            -Otherwise, set result to rollResult
            -Create string sending, explaining what the result of the roll is
            -If clientSocket is connecter
            --Create byte array named buffer, setting it to the ASCII Encoding of sending
            --Call clientSocket.Send(buffer)
            -Otherwise, append sending to the chatDisplayBox
            

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public void strengthRolling(string value)
        {
            int rollResult = myCharacter.rollStr(20);
            int secondRoll = myCharacter.rollStr(20);
            int result;
            if (myCharacter.checkProf(value))
            {
                rollResult += myCharacter.Proficiency;
                secondRoll += myCharacter.Proficiency;
            }
            if (AdvantageButton.Checked == true || DisadvantageButton.Checked == true)
            {
                if (AdvantageButton.Checked) { result = Math.Max(rollResult, secondRoll); }
                else { result = Math.Min(rollResult, secondRoll); }
            }
            else { result = rollResult; }
            string sending= charName.Text + " rolled a " + result.ToString() + " on their " + value + " check.";
            if (clientSocket.Connected)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(sending);
                clientSocket.Send(buffer);
            }
            else
            {
                ChatDisplayBox.AppendText(Environment.NewLine + sending);
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::strengthRolling - Function used to handle the results of strength based rolls on the form


        SYNOPSIS

            private void dexterityRolling(string value)

            string value -> String used to check for proficiency

                
        DESCRIPTION

            Function used to roll dexterity based rolls
            -Create 2 int values, rollResult and secondRoll, setting them to myChar.rollDex(20)
            -Create int result
            -If myCharacter.checkProf(value) returns true
            --Add myCharacter.Proficiency to rollResult and secondRoll
            -If AdvantageButton or DisadvantageButton are checked
            --If Advantge is checked, set result to the higher of rollResult and secondRoll
            --Otherwise, set result to the lower of rollResult and secondRoll
            -Otherwise, set result to rollResult
            -Create string sending, explaining what the result of the roll is
            -If clientSocket is connecter
            --Create byte array named buffer, setting it to the ASCII Encoding of sending
            --Call clientSocket.Send(buffer)
            -Otherwise, append sending to the chatDisplayBox
            

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public void dexterityRolling(string value)
        {
            int rollResult = myCharacter.rollDex(20);
            int secondRoll = myCharacter.rollDex(20);
            int result;
            if (myCharacter.checkProf(value))
            {
                rollResult += myCharacter.Proficiency;
                secondRoll += myCharacter.Proficiency;
            }
            if (AdvantageButton.Checked == true || DisadvantageButton.Checked == true)
            {
                if (AdvantageButton.Checked) { result = Math.Max(rollResult, secondRoll); }
                else { result = Math.Min(rollResult, secondRoll); }
            }
            else { result = rollResult; }
            string sending= charName.Text + " rolled a " + result.ToString() + " on their " + value + " check.";
            if (clientSocket.Connected)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(sending);
                clientSocket.Send(buffer);
            }
            else
            {
                ChatDisplayBox.AppendText(Environment.NewLine + sending);
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::strengthRolling - Function used to handle the results of strength based rolls on the form


        SYNOPSIS

            private void constitutionRolling(string value)

            string value -> String used to check for proficiency

                
        DESCRIPTION

            Function used to roll constitution based rolls
            -Create 2 int values, rollResult and secondRoll, setting them to myChar.rollCon(20)
            -Create int result
            -If myCharacter.checkProf(value) returns true
            --Add myCharacter.Proficiency to rollResult and secondRoll
            -If AdvantageButton or DisadvantageButton are checked
            --If Advantge is checked, set result to the higher of rollResult and secondRoll
            --Otherwise, set result to the lower of rollResult and secondRoll
            -Otherwise, set result to rollResult
            -Create string sending, explaining what the result of the roll is
            -If clientSocket is connecter
            --Create byte array named buffer, setting it to the ASCII Encoding of sending
            --Call clientSocket.Send(buffer)
            -Otherwise, append sending to the chatDisplayBox
            

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public void constitutionRolling(string value)
        {
            int rollResult = myCharacter.rollCon(20);
            int secondRoll = myCharacter.rollCon(20);
            int result;
            if (myCharacter.checkProf(value))
            {
                rollResult += myCharacter.Proficiency;
                secondRoll += myCharacter.Proficiency;
            }
            if (AdvantageButton.Checked == true || DisadvantageButton.Checked == true)
            {
                if (AdvantageButton.Checked) { result = Math.Max(rollResult, secondRoll); }
                else { result = Math.Min(rollResult, secondRoll); }
            }
            else { result = rollResult; }
            string sending= charName.Text + " rolled a " + result.ToString() + " on their " + value + " check.";
            if (clientSocket.Connected)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(sending);
                clientSocket.Send(buffer);
            }
            else
            {
                ChatDisplayBox.AppendText(Environment.NewLine + sending);
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::strengthRolling - Function used to handle the results of strength based rolls on the form


        SYNOPSIS

            private void intelligenceRolling(string value)

            string value -> String used to check for proficiency

                
        DESCRIPTION

            Function used to roll intelligence based rolls
            -Create 2 int values, rollResult and secondRoll, setting them to myChar.rollInt(20)
            -Create int result
            -If myCharacter.checkProf(value) returns true
            --Add myCharacter.Proficiency to rollResult and secondRoll
            -If AdvantageButton or DisadvantageButton are checked
            --If Advantge is checked, set result to the higher of rollResult and secondRoll
            --Otherwise, set result to the lower of rollResult and secondRoll
            -Otherwise, set result to rollResult
            -Create string sending, explaining what the result of the roll is
            -If clientSocket is connecter
            --Create byte array named buffer, setting it to the ASCII Encoding of sending
            --Call clientSocket.Send(buffer)
            -Otherwise, append sending to the chatDisplayBox
            

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public void intelligenceRolling(string value)
        {
            int rollResult = myCharacter.rollInt(20);
            int secondRoll = myCharacter.rollInt(20);
            int result;
            if (myCharacter.checkProf(value))
            {
                rollResult += myCharacter.Proficiency;
                secondRoll += myCharacter.Proficiency;
            }
            if (AdvantageButton.Checked == true || DisadvantageButton.Checked == true)
            {
                if (AdvantageButton.Checked) { result = Math.Max(rollResult, secondRoll); }
                else { result = Math.Min(rollResult, secondRoll); }
            }
            else { result = rollResult; }
            string sending= charName.Text + " rolled a " + result.ToString() + " on their " + value + " check.";
            if (clientSocket.Connected)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(sending);
                clientSocket.Send(buffer);
            }
            else
            {
                ChatDisplayBox.AppendText(Environment.NewLine + sending);
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::strengthRolling - Function used to handle the results of strength based rolls on the form


        SYNOPSIS

            private void wisdomRolling(string value)

            string value -> String used to check for proficiency

                
        DESCRIPTION

            Function used to roll wisdom based rolls
            -Create 2 int values, rollResult and secondRoll, setting them to myChar.rollWis(20)
            -Create int result
            -If myCharacter.checkProf(value) returns true
            --Add myCharacter.Proficiency to rollResult and secondRoll
            -If AdvantageButton or DisadvantageButton are checked
            --If Advantge is checked, set result to the higher of rollResult and secondRoll
            --Otherwise, set result to the lower of rollResult and secondRoll
            -Otherwise, set result to rollResult
            -Create string sending, explaining what the result of the roll is
            -If clientSocket is connecter
            --Create byte array named buffer, setting it to the ASCII Encoding of sending
            --Call clientSocket.Send(buffer)
            -Otherwise, append sending to the chatDisplayBox
            

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public void wisdomRolling(string value)
        {
            int rollResult = myCharacter.rollWis(20);
            int secondRoll = myCharacter.rollWis(20);
            int result;
            if (myCharacter.checkProf(value))
            {
                rollResult += myCharacter.Proficiency;
                secondRoll += myCharacter.Proficiency;
            }
            if (AdvantageButton.Checked == true || DisadvantageButton.Checked == true)
            {
                if (AdvantageButton.Checked) { result = Math.Max(rollResult, secondRoll); }
                else { result = Math.Min(rollResult, secondRoll); }
            }
            else { result = rollResult; }
            string sending= charName.Text + " rolled a " + result.ToString() + " on their " + value + " check.";
            if (clientSocket.Connected)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(sending);
                clientSocket.Send(buffer);
            }
            else
            {
                ChatDisplayBox.AppendText(Environment.NewLine + sending);
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::strengthRolling - Function used to handle the results of strength based rolls on the form


        SYNOPSIS

            private void charismaRolling(string value)

            string value -> String used to check for proficiency

                
        DESCRIPTION

            Function used to roll charisma based rolls
            -Create 2 int values, rollResult and secondRoll, setting them to myChar.rollCha(20)
            -Create int result
            -If myCharacter.checkProf(value) returns true
            --Add myCharacter.Proficiency to rollResult and secondRoll
            -If AdvantageButton or DisadvantageButton are checked
            --If Advantge is checked, set result to the higher of rollResult and secondRoll
            --Otherwise, set result to the lower of rollResult and secondRoll
            -Otherwise, set result to rollResult
            -Create string sending, explaining what the result of the roll is
            -If clientSocket is connecter
            --Create byte array named buffer, setting it to the ASCII Encoding of sending
            --Call clientSocket.Send(buffer)
            -Otherwise, append sending to the chatDisplayBox
            

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public void charismaRolling(string value)
        {
            int rollResult = myCharacter.rollCha(20);
            int secondRoll = myCharacter.rollCha(20);
            int result;
            if (myCharacter.checkProf(value))
            {
                rollResult += myCharacter.Proficiency;
                secondRoll += myCharacter.Proficiency;
            }
            if (AdvantageButton.Checked || DisadvantageButton.Checked)
            {
                if (AdvantageButton.Checked) { result = Math.Max(rollResult, secondRoll); }
                else { result = Math.Min(rollResult, secondRoll); }
            }
            else { result = rollResult; }
            string sending= charName.Text + " rolled a " + result.ToString() + " on their " + value + " check.";
            if (clientSocket.Connected)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(sending);
                clientSocket.Send(buffer);
            }
            else
            {
                ChatDisplayBox.AppendText(Environment.NewLine + sending);
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::LongRestBtn_Click - Handler function to handle the LongRestBtn click event


        SYNOPSIS

            private void LongRestBtn_Click(object sender, EventArgs e)

            
                
        DESCRIPTION

            Function to handle the form displaying the information of a character taking a long rest
            -Call myCharacter.longRest
            -Create string called sending, populating it explaining the character has taken a rest
            -If clientSocket.Connecter
            --Create byte buffer, set it to sending being ASCII encoded, and send buffer through the clientSocket
            -Otherwise, append sending to ChatDisplayBox
            -Call updateForm
            

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void LongRestBtn_Click(object sender, EventArgs e)
        {
            myCharacter.longRest();
            string sending= myCharacter.getName() + " takes a long rest.";
            if (clientSocket.Connected)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(sending);
                clientSocket.Send(buffer);
            }
            else
            {
                ChatDisplayBox.AppendText(Environment.NewLine + sending);
            }
            updateForm();
        }

        /**/
        /*
        

        NAME

            MainClientForm::ShortRestBtn_Click - Handler function to handle the ShortRestBtn click event


        SYNOPSIS

            private void ShortRestBtn_Click(object sender, EventArgs e)

            
                
        DESCRIPTION

            Function to handle the form displaying the information of a character taking a short rest
            -Call myCharacter.shortRest
            -Create string called sending, populating it explaining the character has taken a rest
            -If clientSocket.Connecter
            --Create byte buffer, set it to sending being ASCII encoded, and send buffer through the clientSocket
            -Otherwise, append sending to ChatDisplayBox
            -Call updateForm
            

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void ShortRestBtn_Click(object sender, EventArgs e)
        {
            myCharacter.shortRest();
            string sending= myCharacter.getName() + " takes a short rest.";
            if (clientSocket.Connected)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(sending);
                clientSocket.Send(buffer);
            }
            else
            {
                ChatDisplayBox.AppendText(Environment.NewLine + sending);
            }
            updateForm();
        }

        /**/
        /*
        

        NAME

            MainClientForm::RecieveData - Function used to handle the recieving of data from the server


        SYNOPSIS

            private void RecieveData(IAsyncResult ar)

            IAsyncResult ar -> Asynchronous result sent back to previous function

            
                
        DESCRIPTION

            Function used to handle the data recieved from the server
            -Create MyMessage called aquiredMessage
            -Create item test
            -Try
            --Create Socket named socket and set it to the Socket of ar
            --Create in recieved, setting to socket.EndReceive(ar)
            --Create byte array dataBuffer, of size recieved
            --Copy recieveBuffer to dataBuffer
            --Set latestRecieved.Text to the ASCII encoding of dataBuffer
            --Try
            ---Set aquiredMessage to the Json Deseralization into a MyMessage of latestRecieved.Text
            ---If aquiredMessage.Topic is Damage
            ----myCharacter's CurrentHP is decreased by aquiredMessage.Value
            ---Else if aquiredMessage.Topic is Healing
            ----Call myCharacter.heal, passing in aquiredMessage.Value
            ---Else if aquiredMessage.Topic is Experience Points
            ----Call myCharacter.GainXP, passing in aquiredMessage.Value
            ---Else if aquiredMessage.Topic is Gold
            ----Increase myCharacter.Gold by aquiredMessage.Value
            ---Else if aquiredMessage.Topic is Check
            ----Call forceCheck, passing in aquiredMessage.Save
            --Catch
            ---Set test to the Json deserialization into an item of latestRecieved.Text
            ---Add test to myCharacter.MyItems
            --Call updateForm
            --Call clientSocket.BeginRecieve
            -Catch
            --Close the clientSocket connection
            --Append the error message to the chatDisplayBox
            

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void ReceiveData(IAsyncResult ar)
        {
            MyMessage aquiredMessage = new MyMessage();
            item test = new item();
            try
            {
                Socket socket = (Socket)ar.AsyncState;
                int recieved = socket.EndReceive(ar);
                byte[] dataBuffer = new byte[recieved];
                Array.Copy(recieveBuffer, dataBuffer, recieved);
                latestRecieved.Text = (Encoding.ASCII.GetString(dataBuffer));
                try
                {
                    aquiredMessage = JsonConvert.DeserializeObject<MyMessage>(latestRecieved.Text);
                    if (aquiredMessage.Topic == "Damage")
                    {
                        myCharacter.CurrentHP -= aquiredMessage.Value;
                    }
                    else if (aquiredMessage.Topic == "Healing")
                    {
                        myCharacter.heal(aquiredMessage.Value);
                    }
                    else if (aquiredMessage.Topic == "Experience Points")
                    {
                        myCharacter.GainXP(aquiredMessage.Value);
                    }
                    else if (aquiredMessage.Topic == "Gold")
                    {
                        myCharacter.Gold += aquiredMessage.Value;
                    }
                    else if (aquiredMessage.Topic == "Check")
                    {
                        forceCheck(aquiredMessage.Save);
                    }
                    ChatDisplayBox.AppendText(aquiredMessage.textMessage);
                }
                catch(Exception)
                {
                    test = JsonConvert.DeserializeObject<item>(latestRecieved.Text);
                    myCharacter.MyItems.Add(test);
                }
                updateForm();
                clientSocket.BeginReceive(recieveBuffer, 0, recieveBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveData), clientSocket);
            }
            catch (Exception theExc)
            {
                clientSocket.Close();
                ChatDisplayBox.AppendText(Environment.NewLine + theExc.Message);
            }
        }

        /**/
        /*
        

        NAME

            MainClientForm::ConnectClient - Function used to connect the client to the server


        SYNOPSIS

            private void ConnectClient()

            
                
        DESCRIPTION

            Function used to connect client to server
            -Try
            --clientSocket.Connect, passing in IPAddress.Loopback, and 8080
            --Set latestRecieved.Text to "Connected"
            -Catch socketExceptions
            --Set latestRecieved.Text to the socketException
            
            

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void ConnectClient()
        {
            try
            {
                clientSocket.Connect(IPAddress.Loopback, 8080);
                latestRecieved.Text = "Connected";
            }
            catch (SocketException exc)
            {
                latestRecieved.Text = exc.Message;
            }

        }

        /**/
        /*
        

        NAME

            MainClientForm::ConnectButton_Click - Function used to handle the ConnectButton click event


        SYNOPSIS

            private void ConnectButton_Click()

            
                
        DESCRIPTION

            Function handle the click event of the ConnectButton
            -Try
            --Call ConnectClient
            --Call clientSocket.BeginReceive
            --Create a byte array named firstBuffer, setting it to the ASCII encoding of @ and charName.Text
            --Call clientSocket.Send, passing in firstBuffer
            --Set ConnectButton.Enabled and ConnectButton.Visible to false
            -Catch exceptions
            --Append the message of the caught exception to ChatDisplayBox

            
            
            

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                ConnectClient();
                clientSocket.BeginReceive(recieveBuffer, 0, recieveBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveData), clientSocket);
                byte[] firstBuffer = Encoding.ASCII.GetBytes("@" + charName.Text);
                clientSocket.Send(firstBuffer);
                ConnectButton.Enabled = false;
                ConnectButton.Visible = false;
            }
            catch (Exception theExc)
            {
                ChatDisplayBox.AppendText(Environment.NewLine + theExc.Message);
            }
            
        }

        /**/
        /*
        

        NAME

            MainClientForm::forceCheck - Function used to change the form when a check request is recieved from the server


        SYNOPSIS

            private void forceCheck(string type)

            string type -> String value used to determine which check is being requested from the player

            
                
        DESCRIPTION

            Function used to change the form when a check is requested from server
            -Change the correct label based on the type passed in at call time from black text to red text

        RETURNS

            NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void forceCheck(string type)
        {
            if (type == "Athletics") { AthleticsLabel.ForeColor = Color.Red; }
            else if (type == "Strength Saving Throw") { StrengthSavingLabel.ForeColor = Color.Red; }
            else if (type == "Acrobatics") { AcrobaticsLabel.ForeColor = Color.Red; }
            else if (type == "Sleight of Hand") { SleightOfHandLabel.ForeColor = Color.Red; }
            else if (type == "Stealth") { StealthLabel.ForeColor = Color.Red; }
            else if (type == "Dexterity Saving Throw") { DexSavingLabel.ForeColor = Color.Red; }
            else if (type == "Constitution Saving Throw") { ConSavingLabel.ForeColor = Color.Red; }
            else if (type == "Arcana") { ArcanaLabel.ForeColor = Color.Red; }
            else if (type == "History") { HistoryLabel.ForeColor = Color.Red; }
            else if (type == "Nature") { NatureLabel.ForeColor = Color.Red; }
            else if (type == "Religion") { ReligionLabel.ForeColor = Color.Red; }
            else if (type == "Intelligence Saving Throw") { IntSaveLabel.ForeColor = Color.Red; }
            else if (type == "Animal Handling") { AnimalHandlingLabel.ForeColor = Color.Red; }
            else if (type == "Insight") { InsightLabel.ForeColor = Color.Red; }
            else if (type == "Medicine") { MedicineLabel.ForeColor = Color.Red; }
            else if (type == "Perception") { PerceptionLabel.ForeColor = Color.Red; }
            else if (type == "Survival") { SurvivalLabel.ForeColor = Color.Red; }
            else if (type == "Wisdom Saving Throw") { WisdomSaveLabel.ForeColor = Color.Red; }
            else if (type == "Deception") { DeceptionLabel.ForeColor = Color.Red; }
            else if (type == "Intimidation") { IntimidationLabel.ForeColor = Color.Red; }
            else if (type == "Performance") { PerformanceLabel.ForeColor = Color.Red; }
            else if (type == "Persusasion") { PersuasionLabel.ForeColor = Color.Red; }
            else { CharismaSavingThrow.ForeColor = Color.Red; }


        }

        /**/
        /*
        

        NAME

            MainClientForm::requestMade - Function used to return bool determining if a check has been requested


        SYNOPSIS

            private bool requestMade()

            
                
        DESCRIPTION

            Function used to check if a request has been made of the player
            -If any ability label is red
            --Return true
            -Otherwise return false

        RETURNS

            Returns bool value determining if a check has been requested of the player

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private bool requestMade()
        {
            if (AthleticsLabel.ForeColor == Color.Red || StrengthSavingLabel.ForeColor == Color.Red || AcrobaticsLabel.ForeColor == Color.Red || SleightOfHandLabel.ForeColor == Color.Red || StealthLabel.ForeColor == Color.Red || DexSavingLabel.ForeColor == Color.Red || ConSavingLabel.ForeColor == Color.Red || ArcanaLabel.ForeColor == Color.Red || HistoryLabel.ForeColor == Color.Red || NatureLabel.ForeColor == Color.Red || ReligionLabel.ForeColor == Color.Red || IntSaveLabel.ForeColor == Color.Red || AnimalHandlingLabel.ForeColor == Color.Red || InsightLabel.ForeColor == Color.Red || MedicineLabel.ForeColor == Color.Red || PerceptionLabel.ForeColor == Color.Red || SurvivalLabel.ForeColor == Color.Red || WisdomSaveLabel.ForeColor == Color.Red || DeceptionLabel.ForeColor == Color.Red || IntimidationLabel.ForeColor == Color.Red || PerformanceLabel.ForeColor == Color.Red || PersuasionLabel.ForeColor == Color.Red || CharismaSavingThrow.ForeColor == Color.Red)
            {
                return true;
            }
            else { return false; }
        }

        
    }
}
