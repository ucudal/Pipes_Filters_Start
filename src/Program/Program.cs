using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture("BillMurray.jpg");
            
            PipeNull pipenull = new PipeNull();

            FilterNegative filter2 = new FilterNegative();
            FilterGreyscale filter1 = new FilterGreyscale();
            Twitterpubl twitter = new Twitterpubl();

            PipeSerial pipserialTwitter= new PipeSerial(twitter,pipenull);
            PipeSerial pipserialnoTwitter= new PipeSerial(filter2,pipenull);
            PipeFork pipeFork = new PipeFork(pipserialTwitter,pipserialnoTwitter);
            
            PipeSerial aplicagrey = new PipeSerial(filter1,pipeFork);
            aplicagrey.Send(picture);

            //PictureProvider provider2 = new PictureProvider();
           // provider.SavePicture(image, "segu.jpg");

/*           PipeSerial pipeserial2apipenull = new PipeSerial(filter2,pipenull);
            PipeSerial pipeserial1a2 = new PipeSerial(filter1,pipeserial2apipenull);
            PipeSerial pipeserialanull = new PipeSerial(filter1,pipenull);

            pipeserialanull.Send(picture);
            IPicture image2 = pipeserialanull.Send(picture);
            IPicture image = pipenull.Send(image2);

            PictureProvider provider1 = new PictureProvider();
            provider.SavePicture(image, "Primer2filtro.jpg");

            IPicture image3= pipeserial2apipenull.Send(image2);
            
            PictureProvider provider2 = new PictureProvider();
            provider.SavePicture(image3, "segundo1filtro.jpg");
*/
            //CognitiveConditional cognitive = new CognitiveConditional();
            //if (cognitive.FoundFace("BillMurray.jpg"))
            //{

            //}
        }
    }
}
