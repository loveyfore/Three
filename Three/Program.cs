using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Three
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                
                //如果不想读缺省的配置文件，那么可以这样做，先清除掉所有的源，然后自己指定要读取的配置文件
                //打开注释即可！！
                /*
                .ConfigureAppConfiguration((context, configBuilder) =>
                {
                    configBuilder.Sources.Clear();
                    configBuilder.AddJsonFile("nick.json");
                })
                */

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                    //在执行内建web服务时，系统在内部会自动调用
                    //webBuilder.UseKestrel();
                });
    }
}
