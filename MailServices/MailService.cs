using ConfigServices;
using LogServices;

namespace MailServices;

public class MailService : IMailService
{
    private readonly ILogProvider logProvider;
    // private readonly IConfigService configService;
    private readonly IConfigReader configService;

    public MailService(ILogProvider logProvider, IConfigReader configService)
    {
        this.logProvider = logProvider;
        this.configService = configService;
    }

    public void SendMail(string title, string to, string body)
    {
        logProvider.LogInfo("准备发送邮件");
        var smtpServer = configService.GetValue("SmtpServer");
        var userName = configService.GetValue("UserName");
        var password = configService.GetValue("Password");
        Console.WriteLine($"{smtpServer},{userName},{password}");
        Console.WriteLine($"发送邮件：{title}{to}{body}");
        logProvider.LogInfo("邮件发送完成");
    }
}