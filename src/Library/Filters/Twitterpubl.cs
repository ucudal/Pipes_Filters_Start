using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterUCU;
namespace CompAndDel.Filters
{
    public class Twitterpubl: IFilter
    {
        //Filtro de Twitter, encargada de subir la imagen a Twitter
        public IPicture Filter(IPicture image)
        {
            Guardar imagenguardada = new Guardar();
            var path=imagenguardada.GeneratePath();
            imagenguardada.GuardarImagen(image,path);
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("OK", path));
            return image;
        }
        //public void SendTwitter(string path)
       // {
        //    var twitter = new TwitterImage();
         //   Console.WriteLine(twitter.PublishToTwitter("OK", path));
        //}
            
    }
}