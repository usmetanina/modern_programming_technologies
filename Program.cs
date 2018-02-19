using System;
using Ninject;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace ioc
{
    public class ConsoleModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>().To<ConsoleLogger>().InSingletonScope();
            Bind<IDatabase>().To<Database>().InTransientScope();
        }
    }

    public interface ILogger
    {
        void Log(string message);
    }

    class ConsoleLogger: ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

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
