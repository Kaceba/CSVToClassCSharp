using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV2Class
{
    class ParseCSVToCsharp
    {
        static readonly string Indent = "    ";
        public string file { get; set; }
        string[] FileLines { get; set; }
        string NomeClasse { get; set; }
        string[] HeaderTypeParse { get; set; }

        List<string> FileFinale { get; set; }

        public ParseCSVToCsharp(string FilePath)
        {
            this.file = FilePath;
            this.FileLines = File.ReadAllLines(FilePath);
            this.NomeClasse = Path.GetFileNameWithoutExtension(FilePath);
            this.HeaderTypeParse = this.FileLines.First().Split(';');
        }

        private List<string> BaseClassBuilder()
        {
            List<string> CSharpClass = new List<string>();

            string Using = @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
";

            CSharpClass.Add(Using);

            CSharpClass.Add($"public class {NomeClasse}Spec");

            CSharpClass.Add("{");

            CSharpClass.Add($"{Indent}public class {NomeClasse}Class");
            CSharpClass.Add(Indent + "{");

            foreach (var property in HeaderTypeParse)
            {
                CSharpClass.Add($"{Indent}{Indent}" + "public string " + property + " { get; set; }");
            }

            CSharpClass.Add(Indent + "}");
            //CSharpClass.Add("}");

            return CSharpClass;
        }
        private Tuple<bool, string> CreaClasseConDatiDaCSV()
        {
            try
            {
                FileFinale.Add("");
                FileFinale.Add($"{Indent}public static List<{NomeClasse}Class> {NomeClasse}List = Get{NomeClasse}SpecList();");
                FileFinale.Add("");

                #region PopolaSpecList
                FileFinale.Add($"{Indent}internal static List<{NomeClasse}Class> Get{NomeClasse}SpecList()");
                FileFinale.Add(Indent + "{");

                FileFinale.Add($"{Indent}{Indent}var {NomeClasse}SpecList = new List<{NomeClasse}Class>();");
                FileFinale.Add($"{Indent}{Indent}var source = RawData();");

                FileFinale.Add($"{Indent}{Indent}foreach (var Line in source)");
                FileFinale.Add($"{Indent}{Indent}" + "{");

                FileFinale.Add($"{Indent}{Indent}{Indent}{NomeClasse}SpecList.Add(FromCsv(Line));");

                FileFinale.Add($"{Indent}{Indent}" + "}");

                FileFinale.Add($"{Indent}{Indent}" + $"return {NomeClasse}SpecList;");

                FileFinale.Add(Indent + "}");
                #endregion

                FileFinale.Add("");

                #region FromCsv
                FileFinale.Add($"{Indent}public static {NomeClasse}Class FromCsv(string csvLine)");
                FileFinale.Add(Indent + "{");

                FileFinale.Add($"{Indent}{Indent}" + "var values = csvLine.Split(';');");
                FileFinale.Add($"{Indent}{Indent}" + $"{NomeClasse}Class {NomeClasse} = new {NomeClasse}Class();");


                //foreach (var ClassType in HeaderTypeParse)
                for (int i = 0; i < HeaderTypeParse.Count(); i++)
                {
                    string ClassType = HeaderTypeParse[i];
                    FileFinale.Add($"{Indent}{Indent}" + $"{NomeClasse}.{ClassType} = Convert.ToString(values[{i}]);");
                }

                FileFinale.Add($"{Indent}{Indent}" + $"return {NomeClasse};");

                FileFinale.Add(Indent + "}");
                #endregion

                FileFinale.Add("");

                #region RawData
                string quote = "\"";
                FileFinale.Add($"{Indent}internal static List<string> RawData()");
                FileFinale.Add(Indent + "{");

                FileFinale.Add($"{Indent}{Indent}" + "return new List<string>()");
                FileFinale.Add($"{Indent}{Indent}" + "{");

                foreach (var Line in FileLines)
                {
                    FileFinale.Add($"{quote}{Line}{quote},");
                }

                FileFinale.Add($"{Indent}{Indent}" + "}");

                FileFinale.Add(Indent + "}");
                #endregion

                return new Tuple<bool, string>(true, "Successo");
            }
            catch (Exception ee)
            {
                return new Tuple<bool, string>(false, $"{ee.Message}");
            }
        }

        /// <summary>
        /// Crea un file .cs inserendo il path di un file .csv da convertire
        /// </summary>
        /// <param name="file">Path del file da convertire</param>
        /// <returns>Una stringa che indica lo stato di completamento del metodo</returns>
        /// 
        public Tuple<bool, string> CreaClasseDaCSV(bool conDati)
        {
            try
            {
                FileFinale = BaseClassBuilder();

                if (conDati)
                {
                    var Result = CreaClasseConDatiDaCSV();

                    if(Result.Item1 is false) 
                    {
                        return new Tuple<bool, string>(false, $"{Result.Item2}");
                    }
                }

                FileFinale.Add("}");
                File.WriteAllLines(Path.ChangeExtension(file, ".cs"), FileFinale);

                return new Tuple<bool, string>(true, "Successo");
            }
            catch (Exception ee)
            {
                return new Tuple<bool, string>(false, $"{ee.Message}");
            }
        }

    }
}
