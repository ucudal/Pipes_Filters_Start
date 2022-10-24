using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompAndDel
{
    public class Guardar
    {
        private PictureProvider provider;

        public string path{get;set;}
        public void GuardarImagen(IPicture picture,string path)
        {
            provider = new PictureProvider();
            provider.SavePicture(picture,path);
            this.path=path;
        }

        public string GeneratePath()
    {
        return DateTime.Now.ToString("yyyyMMdd_hhmmssfff") + ".jpg";
    }
    }
}