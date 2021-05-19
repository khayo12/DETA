using CheckService.Models;

namespace CheckService.Interfaces
{
    public interface IStatus
    {
        string ServiceStatus(string servicename);
        string UpdateStatus(StatusRequest statusRequest);
    }
}
