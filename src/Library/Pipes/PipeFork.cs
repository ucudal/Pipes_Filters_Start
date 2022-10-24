using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;


namespace CompAndDel.Pipes
{
    public class PipeFork : IPipe
    {
        IPipe next2Pipe;
        IPipe nextPipe;
        
        /// <summary>
        /// La cañería recibe una imagen, la clona y envìa la original por una cañeria y la clonada por otra.
        /// </summary>
        /// <param name="tipoFiltro">Tipo de filtro que se debe aplicar sobre la imagen. Se crea un nuevo filtro con los parametros por defecto</param>
        /// <param name="nextPipe">Siguiente cañeria con filtro</param>
        /// <param name="next2Pipe">Siguiente cañeria sin filtro</param>
        public PipeFork(IPipe nextPipe, IPipe next2Pipe) 
        {
            this.next2Pipe = next2Pipe;
            this.nextPipe = nextPipe;           
        }
        
        /// <summary>
        /// La cañería recibe una imagen, construye un duplicado de la misma, 
        /// y envía la original por una cañería y el duplicado por otra.
        /// </summary>
        /// <param name="picture">imagen a filtrar y enviar a las siguientes cañerías</param>

        //Estoy preguntando si la imagen recibida tiene una cara, si tiene una imagen la envía a un cierto Pipe sino la envía a otro. 
        public IPicture Send(IPicture picture)
        {
            Guardar path = new Guardar();
            var path1 = path.GeneratePath();
            CognitiveConditional cognitive = new CognitiveConditional();
            if (cognitive.FoundFace(path1))
            {
                return this.next2Pipe.Send(picture);
            }
            else
            {
                return this.nextPipe.Send(picture);
            }
        }
    }
}
