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
        //注入IConfiguration实例，使用它可以读取配置文件appsettings.json中的配置信息！！
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            

            //获取配置值，用:号间隔
            //方法一，简单直接
            //var Three = Configuration["Three:BoldDepartmentEmployeeCountThreshold"];
            //Console.WriteLine(Three);

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //使用MVC（但不支持Razor）
            services.AddControllersWithViews();

            //不需要view，只需要支持api
            //services.AddControllers();

            //提供的功能过于强大，一般不需要使用
            //services.AddMvc();

            //依赖注入自己写的服务
            services.AddSingleton<IClock, ChinaClock>();

            services.AddSingleton<IDepartmentService, DepartmentService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();

            //只映射Three对应的配置信息！！！
            services.Configure<ThreeOptions>(Configuration.GetSection("Three"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //判断自己写的环境变量
            //env.IsEnvironment("Ok")

            //生产环境
            //env.IsProduction()

            //staging环境（发布前验证阶段？）
            //env.IsStaging()

            //判断环境变量
            if (env.IsDevelopment())
            {//开发环境
                //开发模式显示出错详情
                app.UseDeveloperExceptionPage();
            }
            else
            {//生产环境
                app.UseExceptionHandler("/Home/Error");
            }

            //这些Use方法的书写位置，决定了在HTTP请求管道中的执行顺序，是与顺序强相关的！！！


            //serve静态文件（js,css,images）
            app.UseStaticFiles();

            //强制将http请求转化为https请求
            //app.UseHttpsRedirection();

            app.UseRouting();

            //授权认证，配置在UseRouting和UseEndpoints之间！！
            app.UseAuthorization();

            
            //endpoint：端点（可以理解为最终处理的地方，比如MVC使用MapControllerRoute方法，Razor Pages又是采用另外的方法）
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                

                //如果使用属性路由，缺省不建议使用
                //endpoints.MapControllers();
            });
            

            /*
            //最简单的web服务器
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    //最佳做法，采用扩展方法
                    await context.Response.WriteAsync("Hello World!中国！", Encoding.Unicode);
                    
                    //中文乱码
                    //await context.Response.WriteAsync("Hello World!中国！");

                    //建议使用BodyWriter，3.1才有？3.0是Response.WriteAsync
                    //await context.Response.BodyWriter.WriteAsync(Encoding.UTF8.GetBytes("Hello World!"));
                    //await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes("Hello World!"));
                });
            });
            */
        }
    }
}
