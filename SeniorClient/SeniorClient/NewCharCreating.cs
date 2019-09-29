using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeniorClient
{
    public partial class NewCharCreating : Form
    {

        /**/
        /*
        

        NAME

                NewCharCreating::NewCharCreating- Default constrctor for NewCharCreating form

        SYNOPSIS

               public NewCharCreating


        DESCRIPTION
        
                Constructor for the NewCharCreating form
                -Calls InitializeComponent()

        RETURNS

                NA, constructor

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public NewCharCreating()
        {
            InitializeComponent();
            
        }

        private Character playerCharacter = new Character();

        /**/
        /*
        

        NAME

                NewCharCreating::FirstChoiceButton_Click- Event handler for the FirstChoiceButton click event

        SYNOPSIS

               private void FirstChoiceButton_Click(object sender, EventArgs e)


        DESCRIPTION
        
                Event handler for the click event for FirstChoiceButtonn
                -If all three character boxes are not empty
                --If classBox reads Barbarian
                ---Create a barbaian.
                ---Set playerCharacer to the barbarian
                --Else if classBox reads Bard
                ---Create a bard
                ---Set playerCharacter to the bard
                --Else if classBox reads Cleric
                ---Create a cleric
                ---Set playerCharacter to Cleric
                --Else if classBox reads Druid
                ---Create druid
                ---Set playerCharacter to Druid
                --Else if classBox reads Fighter
                ---Create a fighter
                ---Set playerCharacter to the fighter
                --Else if classBox reads Monk
                ---Create new monk
                ---Set playerCharacter to the monk
                --Else if classBox reads Paladin
                ---Create new paladin
                ---Set playerCharacter to the paladin
                --Else if classBox reads Ranger
                ---Create new Ranger
                ---Set playerCharacter to the ranger
                --Else if classBox reads Rogue
                ---Create new Rogue
                ---Set playercharacter to the rogue
                --Else if classBox reads Sorcerer
                ---Create new Sorcerer
                ---Set palyerCharacter to the sorcerer
                --Else if classbox reads Warlock
                ---Create new Warlock
                ---Set playerCharacter to the warlock
                --Else if classBox reads Wizard
                ---Create new Wizard
                ---Set playerCharacter to the Wizard
                -Call playerCharacter.setClass and pass in classBox's text
                -Call playerCharacter.setRace and pass in raceBox's text
                -Call playerCharacter.setName and pass in nameBox's text
                -Create StatAssignForm nextForm, passing in playerCharacter to it
                -Hide this form
                -Call nextForm.ShowDialog
                -Close this form
            

        RETURNS

                NA, constructor

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void FirstChoiceButton_Click(object sender, EventArgs e)
        {
            if (raceBox.Text != "" && classBox.Text != "" && nameBox.Text!="")
            {
                if (classBox.Text == "Barbarian")
                {
                    Barbarian newChar = new Barbarian();
                    playerCharacter = newChar;
                }
                else if (classBox.Text == "Bard")
                {
                    Bard newChar = new Bard();
                    playerCharacter = newChar;
                }
                else if (classBox.Text == "Cleric")
                {
                    Cleric newChar = new Cleric();
                    playerCharacter = newChar;
                }
                else if (classBox.Text == "Druid")
                {
                    Druid newChar = new Druid();
                    playerCharacter = newChar;
                }
                
                else if (classBox.Text == "Fighter")
                {
                    Fighter newChar = new Fighter();
                    playerCharacter = newChar;
                }
                else if (classBox.Text == "Monk")
                {
                    Monk newChar = new Monk();
                    playerCharacter = newChar;
                }

                else if (classBox.Text == "Paladin")
                {
                    Paladin newChar = new Paladin();
                    playerCharacter = newChar;
                }

                else if (classBox.Text == "Ranger")
                {
                    Ranger newChar = new Ranger();
                    playerCharacter = newChar;
                }
                else if (classBox.Text == "Rogue")
                {
                    Rogue newChar = new Rogue();
                    playerCharacter = newChar;
                }

                else if (classBox.Text == "Sorcerer")
                {
                    Sorcerer newChar = new Sorcerer();
                    playerCharacter = newChar;
                }
                else if (classBox.Text == "Warlock")
                {
                    Warlock newChar = new Warlock();

                    playerCharacter = newChar;
                }
                else if (classBox.Text == "Wizard")
                {
                    Wizard newChar = new Wizard();
                    playerCharacter = newChar;
                }
                 
                playerCharacter.setClass(classBox.Text);
                playerCharacter.setName(nameBox.Text);
                playerCharacter.setRace(raceBox.Text);
                StatAssignForm nextForm = new StatAssignForm(playerCharacter);
                Hide();
                nextForm.ShowDialog();
                Close();
            }
        }
    }
}
