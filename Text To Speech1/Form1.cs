using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis; 

namespace Text_To_Speech1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SpeechSynthesizer sp = new SpeechSynthesizer();
        private void BtnSpeak_Click(object sender, EventArgs e)
        {
           
            sp.Dispose();
            sp = new SpeechSynthesizer ();
            sp.Rate = SpeedTrackBar.Value;
            sp.Volume  = SoundTrackBar.Value;

            if (PersonComboBox.Text == "Male")
            {
                sp.SelectVoiceByHints(VoiceGender.Male);
            }

            if (PersonComboBox.Text == "Female")
            {
                sp.SelectVoiceByHints(VoiceGender.Female);

            }

            sp.SpeakAsync (TxtBox.Text);

            if (TxtBox.Text == "")
            {
                MessageBox.Show("Enter Some Text First!");
                return;
            }
     }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            if (sp.State== SynthesizerState.Speaking )

        {
                 sp.Pause();
             }
        }

        private void BtnResume(object sender, EventArgs e)
        {
            if (sp.State == SynthesizerState.Paused)
            {
                sp.Resume();
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            if (sp.State == SynthesizerState.Speaking)
            {
                sp.Dispose();
            }
        }
    }
}
