using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_P3
{
    class scenenode
    {
        public Mesh current, parent;

        public scenenode(Mesh mesh, Mesh ouder)
        {
            current = mesh;
            parent = ouder;
        }
    }
}
