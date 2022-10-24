using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CognitiveCoreUCU;


namespace CompAndDel
{
    public class CognitiveConditional
    {
        public bool FoundFace(string path)
        {
            CognitiveFace cog = new CognitiveFace(false);
            cog.Recognize(path);
            if (cog.FaceFound)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}