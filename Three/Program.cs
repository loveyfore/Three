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
                
                //��������ȱʡ�������ļ�����ô����������������������е�Դ��Ȼ���Լ�ָ��Ҫ��ȡ�������ļ�
                //��ע�ͼ��ɣ���
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

                    //��ִ���ڽ�web����ʱ��ϵͳ���ڲ����Զ�����
                    //webBuilder.UseKestrel();
                });
    }
}
