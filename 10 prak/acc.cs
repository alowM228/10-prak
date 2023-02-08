using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class acc : cr
    {
        public int ID;
        public string Login;
        public string Password;
        public string Post;

        public virtual List<acc> Create(List<acc> list)
        {
            throw new NotImplementedException();
        }

        public virtual List<acc> Delete(List<acc> list)
        {
            throw new NotImplementedException();
        }

        public virtual void Read(acc account)
        {
            throw new NotImplementedException();
        }

        public virtual List<acc> Update(List<acc> list, acc account)
        {
            throw new NotImplementedException();
        }
    }
}
