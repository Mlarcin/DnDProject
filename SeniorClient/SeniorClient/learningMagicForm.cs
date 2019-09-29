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
    public partial class learningMagicForm : Form
    {
        SpellBook theBook;
        int queueLevel;
        string queueClass;
        string selectedSpell;
        List<string> spellNames = new List<string>();
        List<Spell> spellList = new List<Spell>();

        /**/
        /*
        

        NAME

               learningMagicForm::SelectedSpell - Property returning/setting the selectedSpell string

        SYNOPSIS

                public string SelectedSpell

        DESCRIPTION

                  Property for the selectedSpell string
                  -get
                  --Return selectedString
                  -set
                  --Set selectedSpell to value

        RETURNS

                On get, return string value of the selectedSpell variable from the learningMagicForm

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public string SelectedSpell
        {
            get { return selectedSpell; }
            set { selectedSpell = value; }
        }

        /**/
        /*
        

        NAME

               learningMagicForm::learningMagicForm - Constructor for the learningMagicForm form

        SYNOPSIS

                public learningMagicForm(Spellbook passInBoo, int maxLevel, string theClass)

            Spellbook passedInBook -> Spellbook item assigned to theBook variable.
            int maxLevel -> Int value assigned to the queueLevel variable
            string theClass -> String value assigned to the queueClass variable
            -Note, these three variables are initialized for my own organization

        DESCRIPTION

                  Constructor for learningMagicForm
                  -Set theBook to passedInBook
                  -Set queueClass to theClass
                  -Set queueLevel to maxLevel
                  -Set spellList to the result of theBook quereyList function with queueLevel and queueClass as the variables passed in
                  -Add all names of items from the spellList to the spellNames list
                  -InitializeComponent
                  -Add to the spellBox items all of the names in the spellNames list
                  -Set the selected index of spellBox to 0

        RETURNS

                NA, constructor

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public learningMagicForm(SpellBook passedInBook, int maxLevel, string theClass)
        {
            theBook = passedInBook;
            queueClass = theClass;
            queueLevel = maxLevel;
            spellList = theBook.quereyList(queueLevel, queueClass);
            for (int i = 0; i < spellList.Count(); i++)
            {
                spellNames.Add(spellList[i].Name);
            }
            InitializeComponent();
            spellBox.Items.AddRange(spellNames.ToArray());
            spellBox.SelectedIndex = 0;
            
             
        }

        /**/
        /*
        

        NAME

               learningMagicForm::spellBox_SelectedValueChanged - Event handler used for handling the changed selected value event

        SYNOPSIS

                private void spellBox_SelectedValueChanged(object sender, EventArgs e)

        DESCRIPTION

                  Event handler for the spellBox's selected value being changed
                  -Sets SelectedSpell string to spellBox.SelectedItem.ToString()
                  -Sets the text in the DescriptionBox text to the description of a spell from the spellbook whos name matches the SelectedSpell string

        RETURNS

                NA, void function that only adds the description of a spell to the DescriptionBox

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void spellBox_SelectedValueChanged(object sender, EventArgs e)
        {
            SelectedSpell = spellBox.SelectedItem.ToString();
            DescriptionBox.Text = spellList.Find(x => x.Name == selectedSpell).Name + Environment.NewLine + spellList.Find(x => x.Name == selectedSpell).Effect;
        }

        /**/
        /*
        

        NAME

               learningMagicForm::learnButton_Click - Event handler used for handling the click of the learnButton

        SYNOPSIS

                private void learnButton_Click(object sender, EventArgs e)

        DESCRIPTION

                  Event handler for the learnButton being clicked
                  -Handler does nothing, but sets the DialogResultt of learningMagicForm to OK

        RETURNS

                NA, listener void function, but does set the dialog result to OK

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        private void learnButton_Click(object sender, EventArgs e)
        {

        }
    }
}
