using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ioc
{
    public interface IDatabase
    {
        void Execute(string query, IKernel kernel);
    }

    class Database : IDatabase
    {
        public void Execute(string query, IKernel kernel)
        {
            kernel.Get<ILogger>().Log(query);
        }
    }
}
