using System;
using System.Windows.Forms;

using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Diagnostics;


namespace VoiceBot
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            repeat();
        }

        SpeechSynthesizer synt = new SpeechSynthesizer();
        PromptBuilder pbuilder = new PromptBuilder();
        SpeechRecognitionEngine rEngine = new SpeechRecognitionEngine();

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        void repeat()
        {
            Choices commands = new Choices();
            commands.Add(new String[] {"open opera","open twitter","open telegram","music","open education",
            "open counter strike globbal offensive","open visual studio code","open visual studio","open unity","open blender",
            "standart","open news","open medium"
            });
            Grammar gramer = new Grammar(new GrammarBuilder(commands));
            rEngine.RequestRecognizerUpdate();
            rEngine.LoadGrammar(gramer);
            rEngine.SpeechRecognized += REngine_SpeechRecognized;
            rEngine.SetInputToDefaultAudioDevice();
            rEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void REngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                
                case "open twitter":
                    {
                        pbuilder.ClearContent();
                        pbuilder.AppendText("Twitter opening");
                        synt.Speak(pbuilder);
                        Process.Start("www.twitter.com");
                        break;
                    }
             
                case "open news":
                    {
                        pbuilder.ClearContent();
                        pbuilder.AppendText("BBC News Opening");
                        synt.Speak(pbuilder);
                        Process.Start("https://www.bbc.com/news");
                        break;
                    }

                 
                case "open medium":
                    {
                        pbuilder.ClearContent();
                        pbuilder.AppendText("Meduim Opening");
                        synt.Speak(pbuilder);
                        Process.Start("https://sukrubeyy.medium.com");
                        break;
                    }
            }
        }
    }
}
