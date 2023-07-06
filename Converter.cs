using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV2Class
{
    public partial class Converter : Form
    {
        private string daElaborare { get; set; }

        public Converter()
        {
            InitializeComponent();
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            var Files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (Files.Count() > 1)
            {
                MessageBox.Show($"Trascinare un file per volta", $"Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

#if DEBUG
            var fileExt = Path.GetExtension(Files[0]);
#endif

            if (Path.GetExtension(Files[0]) != ".txt" && Path.GetExtension(Files[0]) != ".csv")
            {
                MessageBox.Show($"Estensione file non compatibile, solo .csv e .txt sono supportati.", $"Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> FileLines = File.ReadAllLines(Files[0]).ToList();

            int TotalLines = FileLines.Count();
            int RigheVuote = 0;

            foreach (var Line in FileLines)
            {
                if (string.IsNullOrEmpty(Line) || string.IsNullOrWhiteSpace(Line))
                {
                    RigheVuote++;
                }
            }

            if (RigheVuote == TotalLines)
            {
                MessageBox.Show($"Il file è vuoto.", $"Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Se tutto và bene allora il file è da elaborare
            daElaborare = Files[0];

            {

            }

            if(radioButtonSenzaDati.Checked is true) 
            {
                FirstCaseHandler();
            }
            //Else if messo in caso vogliamo aggiungere altri tipi
            else if(radioButtonConDati.Checked is true)
            {
                SecondCaseHandler();
            }
        }

        private void FirstCaseHandler()
        {
            Tuple<bool, string> isCreated = new ParseCSVToCsharp(daElaborare).CreaClasseDaCSV(false);

            MessageBox.Show(isCreated.Item1 is true ? $"Creata la classe con successo a {daElaborare}" : $"Si è presentato un'errore nella creazione della classe {isCreated.Item2}", isCreated.Item1 is true ? isCreated.Item2 : "Attenzione", MessageBoxButtons.OK, isCreated.Item1 is true ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }

        private void SecondCaseHandler()
        {
            Tuple<bool, string> isCreatedComplex = new ParseCSVToCsharp(daElaborare).CreaClasseDaCSV(true);

            MessageBox.Show(isCreatedComplex.Item1 is true ? $"Creata la classe con successo a {daElaborare}" : $"Si è presentato un'errore nella creazione della classe {isCreatedComplex.Item2}", isCreatedComplex.Item1 is true ? isCreatedComplex.Item2 : "Attenzione", MessageBoxButtons.OK, isCreatedComplex.Item1 is true ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }

        private void radioButtonConDati_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonConDati.Checked = !radioButtonSenzaDati.Checked;
        }

        private void radioButtonSenzaDati_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonSenzaDati.Checked = !radioButtonConDati.Checked;
        }
    }
}
