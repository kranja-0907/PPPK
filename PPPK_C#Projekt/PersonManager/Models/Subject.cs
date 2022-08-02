using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Zadatak.Utils;

namespace Zadatak.Models
{
    public class Subject
    {
        public int IDSubject { get; set; }
        public string SubjectName { get; set; }
        public int ECTS { get; set; }
        //public byte[] Picture { get; set; }
        //public BitmapImage Image
        //{
        //    get => ImageUtils.ByteArrayToBitmapImage(Picture);
        //}

        public override string ToString()
            => $"{SubjectName}";
    }
}
