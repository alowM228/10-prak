using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal interface cr
    {
        public List<acc> Create(List<acc> list);
        public void Read(acc account);
        public List<acc> Update(List<acc> list, acc account);
        public List<acc> Delete(List<acc> list);
    }
}
