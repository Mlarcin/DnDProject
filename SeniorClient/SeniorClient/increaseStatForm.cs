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
    public partial class increaseStatForm : Form
    {
        public string selectedStat1, selectedStat2;

        /**/
        /*
        

        NAME

               increaseStatForm::increaseStatForm - Constructor for increaseStatForm form

        SYNOPSIS

                increaseStatForm

        DESCRIPTION

                  Constructor for increaseStatForm
                  -InitializeComponent
                  -Set statBox1.SelectedIndex to 0
                  -Set statBox2.SelectedIndex to 0

        RETURNS

                NA, constructor function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public increaseStatForm()
        {
            InitializeComponent();
            statBox1.SelectedIndex = 0;
            statBox2.SelectedIndex = 0;
        }
        /**/
        /*
        

        NAME

               Fighter::sendStats_Click - Handler function used to handle the sendStats button click event

        SYNOPSIS

                public void sendStats_Click

        DESCRIPTION

                  Handler for the sendStats button click event
                 -Set selectedStat1 to statBox1.Text
                 -Set selectedStatt2 to statBox2.Text

        RETURNS

                NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        private void sendStats_Click(object sender, EventArgs e)
        {
            selectedStat1 = statBox1.Text;
            selectedStat2 = statBox2.Text;
        }
    }
}
