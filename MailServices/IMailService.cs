namespace MailServices;

public interface IMailService
{
    public void SendMail(string title, string to, string body);
}