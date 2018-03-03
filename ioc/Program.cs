using System;
using Ninject;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using System.IO;

namespace ioc
{
    public class ConsoleModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>().To<DateLogger>().InSingletonScope();
            Bind<IDatabase>().To<Database>().InTransientScope();
        }
    }

    //public class Resolver
    //{
    //    IKernel ninjectKernel = new StandardKernel(new ConsoleModule());
    //    public IKernel getKernel()
    //    {
    //        return ninjectKernel;
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            IKernel ninjectKernel = new StandardKernel(new ConsoleModule());
            for (int i=0; i<10; i++)
            {
                ninjectKernel.Get<IDatabase>().Execute(i.ToString(), ninjectKernel);
            }
        }
    }
}
