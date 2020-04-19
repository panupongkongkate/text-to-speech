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
using System.Speech.AudioFormat;
using System.Diagnostics;


namespace textspees
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer synth;


        int vAluE = 0;

        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //ประกาซตัวแปร 
            synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice(); //เซต ให้เป็นออโต้
            //synth.SelectVoice("Microsoft Server Speech Text to Speech Voice (th-TH, Pattara)");
            label1.Text = vAluE.ToString();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            vScrollBar1.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            synth.Dispose(); //คำสั่งนี้เป็นการทำให้มันค่า ไม่ทำงาน = null
            if ((richTextBox1.Text != "") && (comboBox1.Text != "")) //แปลว่า ถ้าข้อความไม่ว่างจะไม่สามารถเล่นได้
            {

                synth = new SpeechSynthesizer();
                if (comboBox1.Text == "men")
                {
                    synth.SelectVoiceByHints(VoiceGender.Male); //เลือกเสียงผู้ชาย
                    synth.SelectVoice("Microsoft David Desktop"); //ใช้เสียงผู้ชาย
                }
                if (comboBox1.Text == "girls")
                {
                    synth.SelectVoiceByHints(VoiceGender.Female); //เลือกเสียงผู้หญิง
                    synth.SelectVoice("Microsoft Zira Desktop"); //ใช้เสียงผู้หญิง
                }
                Prompt textsound = new Prompt(richTextBox1.Text);
                synth.SpeakAsync(textsound);
                synth.Volume = vAluE;
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
                comboBox1.Enabled = false;
                vScrollBar1.Enabled = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (synth != null) // เซ็ตว่า ถ้า systh ไม่ว่า จะทำงาน
            {
                synth.Dispose();
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                vScrollBar1.Enabled = true;
                comboBox1.Enabled = true;
            }
        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            vAluE = vScrollBar1.Value;
            label1.Text = vAluE.ToString();
        }
        private void label1_Click(object sender, EventArgs e)
        {


        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //test
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (synth != null)
            {
                if (synth.State == SynthesizerState.Speaking) //ถ้าโปรแกรมกำลังอ่าน
                {
                    synth.Pause();
                    button4.Enabled = true;
                    button3.Enabled = false;
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (synth != null)
            {
                if (synth.State == SynthesizerState.Paused) //ถ้าโปรแกรมกำลังพอต
                {
                    synth.Resume();
                    button3.Enabled = true;
                    button4.Enabled = false;
                }
            }
        }
    }
}
