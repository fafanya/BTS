using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;

namespace Kernel.Common
{
    public class ExcelMaker
    {
        public static string CreateFile(IEnumerable<TObject> objects, string fileName)
        {
            TObject firstObj = objects.FirstOrDefault();
            if (firstObj == null)
                return null;

            using (var package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Main");

                int i = 1;
                int j = 1;
                foreach (var f in firstObj.Values)
                {
                    worksheet.Cells[i, j].Value = f.Key.Header;
                    j++;
                }

                i++;
                foreach(TObject obj in objects)
                {
                    j = 1;
                    foreach (var f in obj.Values)
                    {
                        if(f.Value is DateTime)
                        {
                            worksheet.Cells[i, j].Value = Convert.ToDateTime(f.Value).ToString("dd.MM.yyyy HH:ss");
                        }
                        else
                        {
                            worksheet.Cells[i, j].Value = f.Value;
                        }
                        j++;
                    }
                    i++;
                }

                var xlFile = new FileInfo(fileName);
                package.SaveAs(xlFile);
                return xlFile.FullName;
            }
        }
    }
}
