using ConfigServices;
using LogServices;
using MailServices;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleAppMail;

class Program
{
    static void Main(string[] args)
    {
        ServiceCollection service = new ServiceCollection();
        // service.AddScoped<IConfigService,EnvVarConfigService>();
        service.AddScoped(typeof(IConfigService), s => new IniFileConfigService() { FilePath = "mail.ini" });
        service.AddScoped<IMailService, MailService>();

        // 1. 面向接口开发，解耦


        // 2. 提供一个AddXX方法，能够自动提示 
        // using LogServices; 这里我们不需要引用这个类库，类也不许要对外开发
        // 用户就不用知道内容，直接.方法，具体提供方法，注入，由提供者提供
        // service.AddScoped<ILogProvider, ConsoleLogProvider>();
        service.AddConsoleLog();

        // 3. 可覆盖的配置读取器

        using (var serviceProvider = service.BuildServiceProvider())
        {
            var mailService = serviceProvider.GetService<IMailService>();
            mailService.SendMail("hello", "1111@qq.com", "你好");
        }
    }
}