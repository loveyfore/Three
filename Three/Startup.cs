using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Three.Services;

namespace Three
{
    public class Startup
    {
        //ע��IConfigurationʵ����ʹ�������Զ�ȡ�����ļ�appsettings.json�е�������Ϣ����
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            

            //��ȡ����ֵ����:�ż��
            //����һ����ֱ��
            //var Three = Configuration["Three:BoldDepartmentEmployeeCountThreshold"];
            //Console.WriteLine(Three);

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //ʹ��MVC������֧��Razor��
            services.AddControllersWithViews();

            //����Ҫview��ֻ��Ҫ֧��api
            //services.AddControllers();

            //�ṩ�Ĺ��ܹ���ǿ��һ�㲻��Ҫʹ��
            //services.AddMvc();

            //����ע���Լ�д�ķ���
            services.AddSingleton<IClock, ChinaClock>();

            services.AddSingleton<IDepartmentService, DepartmentService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();

            //ֻӳ��Three��Ӧ��������Ϣ������
            services.Configure<ThreeOptions>(Configuration.GetSection("Three"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //�ж��Լ�д�Ļ�������
            //env.IsEnvironment("Ok")

            //��������
            //env.IsProduction()

            //staging����������ǰ��֤�׶Σ���
            //env.IsStaging()

            //�жϻ�������
            if (env.IsDevelopment())
            {//��������
                //����ģʽ��ʾ��������
                app.UseDeveloperExceptionPage();
            }
            else
            {//��������
                app.UseExceptionHandler("/Home/Error");
            }

            //��ЩUse��������дλ�ã���������HTTP����ܵ��е�ִ��˳������˳��ǿ��صģ�����


            //serve��̬�ļ���js,css,images��
            app.UseStaticFiles();

            //ǿ�ƽ�http����ת��Ϊhttps����
            //app.UseHttpsRedirection();

            app.UseRouting();

            //��Ȩ��֤��������UseRouting��UseEndpoints֮�䣡��
            app.UseAuthorization();

            
            //endpoint���˵㣨�������Ϊ���մ���ĵط�������MVCʹ��MapControllerRoute������Razor Pages���ǲ�������ķ�����
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                

                //���ʹ������·�ɣ�ȱʡ������ʹ��
                //endpoints.MapControllers();
            });
            

            /*
            //��򵥵�web������
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    //���������������չ����
                    await context.Response.WriteAsync("Hello World!�й���", Encoding.Unicode);
                    
                    //��������
                    //await context.Response.WriteAsync("Hello World!�й���");

                    //����ʹ��BodyWriter��3.1���У�3.0��Response.WriteAsync
                    //await context.Response.BodyWriter.WriteAsync(Encoding.UTF8.GetBytes("Hello World!"));
                    //await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes("Hello World!"));
                });
            });
            */
        }
    }
}
